<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmCAFPowerDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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
        
        .style6
        {
            width: 192px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
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
    <script type="text/javascript">
        function alpha(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>
    <script type="text/javascript">
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
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 6) {
                alert("Pin number length must be exactly 6 characters")
            }
        }
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>
    <%--    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <%-- <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Power Details</a> </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            Power Details</h3>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Power<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="2">
                                    Drawing Approval Number :
                                </td>
                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:TextBox ID="txtdrawingno" runat="server" class="form-control txtbox" Style="text-align: right"
                                        Height="28px" MaxLength="50" TabIndex="1" ValidationGroup="group" Width="180px"
                                        OnTextChanged="txtdrawingno_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </td>
                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                    (HT-RRD-2019-10061)
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="400px" Font-Bold="True">Contracted Maximum Demand in KVA <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label449" runat="server" CssClass="LBLBLACK" Width="200px">Already installed<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtKVAAlreadyInstalled" runat="server" class="form-control txtbox"
                                                    Style="text-align: right" Height="28px" MaxLength="8" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtKVAAlreadyInstalled_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtKVAAlreadyInstalled"
                                                    ErrorMessage="Please enter Already Installed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">Proposed<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtKVAProposed" runat="server" class="form-control txtbox" Height="28px"
                                                    Style="text-align: right" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtKVAProposed_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtKVAAlreadyInstalled"
                                                    ErrorMessage="Please enter Already Installed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px">Total<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtKVATotal" runat="server" class="form-control txtbox" Height="28px"
                                                    Style="text-align: right" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtKVATotal"
                                                    ErrorMessage="Please enter Total" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="400px" Font-Bold="True">Connected Load in KW/HP<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="200px">Type of Connected Load<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlConnectLoad" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">KW</asp:ListItem>
                                                    <asp:ListItem Value="2">HP</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlConnectLoad"
                                                    ErrorMessage="Please select Connected Load" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label453" runat="server" CssClass="LBLBLACK" Width="200px">Already installed<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtConnectedAlreadyInstalled" runat="server" class="form-control txtbox"
                                                    Style="text-align: right" Height="28px" MaxLength="8" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtConnectedAlreadyInstalled_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConnectedAlreadyInstalled"
                                                    ErrorMessage="Please select Already Installed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label454" runat="server" CssClass="LBLBLACK" Width="200px">Proposed<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtConnectProposed" runat="server" class="form-control txtbox" Height="28px"
                                                    Style="text-align: right" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtConnectProposed_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtConnectProposed"
                                                    ErrorMessage="Please enter Proposed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label457" runat="server" CssClass="LBLBLACK" Width="200px">Total<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtConnectTotal" runat="server" class="form-control txtbox" Height="28px"
                                                    Style="text-align: right" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConnectTotal"
                                                    ErrorMessage="Please enter Connected Total" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                3
                                            </td>
                                            <td style="width: 200px;">
                                                Regulation
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlregulation" runat="server" class="form-control txtbox" Height="33px"
                                                    TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlregulation_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlregulation"
                                                    ErrorMessage="Please select Regulation" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trvoltage" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="width: 200px;">
                                                Voltage
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlvoltage" runat="server" class="form-control txtbox" Height="33px"
                                                    TabIndex="1" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddlvoltage"
                                                    ErrorMessage="Please select Voltage" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trPlant" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="width: 200px;">
                                                Plant
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlplant" runat="server" class="form-control txtbox" Height="33px"
                                                    TabIndex="1" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlplant"
                                                    ErrorMessage="Please select  Plant" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                4
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">Aggregate Transformer Capacity(ATC) (in KVA)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtaggregatecapacity" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" Style="text-align: right"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtaggregatecapacity"
                                                    ErrorMessage="Please Aggregate Transformer Capacity(ATC) (in KVA) " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr align="center" style="text-align: center" valign="middle" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                5&nbsp;
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label458" runat="server" CssClass="LBLBLACK" Width="200px">Proposed Location of Factory<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlProject" runat="server" class="form-control txtbox" Height="33px"
                                                    TabIndex="1" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">IE</asp:ListItem>
                                                    <asp:ListItem Value="2">IDA</asp:ListItem>
                                                    <asp:ListItem Value="3">SEZ</asp:ListItem>
                                                    <asp:ListItem Value="4">Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProject"
                                                    ErrorMessage="Please select  Project" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle" >
                                                6
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="200px">Survey No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtSurvey" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtSurvey"
                                                    ErrorMessage="Please enter Survey Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                7
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label444" runat="server" CssClass="LBLBLACK" Width="165px">Extent<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtExtent" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtcontact29_TextChanged"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtExtent"
                                                    ErrorMessage="Please enter Extent" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                8
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="200px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                                                    TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlDistrict"
                                                    ErrorMessage="Please select District" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                9
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged"
                                                    TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlMandal"
                                                    ErrorMessage="Please select Mandals" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                10
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="200px">Village/Town<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" AutoPostBack="True" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlVillage"
                                                    ErrorMessage="Please select Villages" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                11
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="165px">Street Name<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStreet" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtStreet"
                                                    ErrorMessage="Please enter street name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                12
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="200px">PinCode <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtPinCode" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" onkeypress="NumberOnly()" onblur="checkLength(this)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtPinCode"
                                                    ErrorMessage="Please enter PIN number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                13
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="165px">Telephone(incl STD Code)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtTelephone" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="18" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtTelephone"
                                                    ErrorMessage="Please enter Telephone" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                14
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="200px">Nearest Telephone No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNearTelephone" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="18" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                15
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="200px">Date of Commencement of Production(dd-MMM-yyyy)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtDateofCommencement" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" OnTextChanged="txtcontact32_TextChanged"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                                    PopupButtonID="txtDateofCommencement" TargetControlID="txtDateofCommencement">
                                                </cc1:CalendarExtender>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtDateofCommencement"
                                                    ErrorMessage="Please enter Commencement date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="280px" Font-Bold="True">A)Upload Load Particulars</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="200px">Equipment Name <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtequipment" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidA" Width="180px"></asp:TextBox>
                                            </td>
                                           <%-- <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtequipment"
                                                    ErrorMessage="Please Equipment Name" ValidationGroup="ValidA">*</asp:RequiredFieldValidator>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Make <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtmake" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidA" Width="180px"></asp:TextBox>
                                            </td>
                                            <%--<td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtmake"
                                                    ErrorMessage="Please Enter Make" ValidationGroup="ValidA">*</asp:RequiredFieldValidator>
                                            </td>--%>
                                        </tr>
                                        <%--   <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Internal Stair Cases (min 2) <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtInter_Stairs" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtInter_Stairs"
                                                    ErrorMessage="Please Enter Internal Stair Cases" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="200px">External Stair Cases (min 1) <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtExernal_Stairs" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtcontact27_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="txtExernal_Stairs"
                                                    ErrorMessage="Please Enter External Stair Cases" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3.&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="165px">Width of Stair Case<br />(min 1)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtWidth_Stairs" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="txtWidth_Stairs"
                                                    ErrorMessage="Please Enter Width of Stair Cases" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="200px">Serial No. <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtserialno" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidA" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <%--  <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label416" runat="server" CssClass="LBLBLACK" Width="165px">No Of Exits<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtNoofExits" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtNoofExits_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="txtNoofExits" ErrorMessage="Please Enter Number of Exists"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label417" runat="server" CssClass="LBLBLACK" Width="165px">Width of each exit (in mts.)<br />(min 4.5 mtrs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtWidth_eachExit" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="txtWidth_eachExit"
                                                    ErrorMessage="Please Enter Width of each exit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="200px">Capacity in KV<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtcapinkv" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidA" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Capacity in HP<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtcaphp" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidA" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label54" runat="server" CssClass="LBLBLACK" Width="200px">Load Upload<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:FileUpload ID="fileloadupload" runat="server" CssClass="form-control txtbox"
                                                    Height="28px" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr2" runat="server">
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <asp:Button ID="btnloadsave" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Add" ValidationGroup="ValidA" Width="72px" OnClick="btnloadsave_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnloadclear" runat="server" CausesValidation="False"
                                        Visible="false" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btnloadclear_Click" />
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                    <asp:GridView ID="gvLoad" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="Both" Width="100%" OnRowDataBound="gvLoad_RowDataBound" OnRowDeleting="gvLoad_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"
                                                DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="EquipmentName" runat="server" Text='<%# Bind("EquipmentName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    EquipmentName
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Make" runat="server" Text='<%# Bind("Make") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Make
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="SerialNo" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    SerialNo
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="CapacityinKV" runat="server" Text='<%# Bind("CapacityinKV") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    CapacityinKV
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="CapacityinHP" runat="server" Text='<%# Bind("CapacityinHP") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    CapacityinHP
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="LoadUpload" runat="server" Text='<%# Bind("LoadUpload") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Load Upload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="capacityloadpath" runat="server" Text='<%# Bind("capacityloadpath") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Load Upload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#013161" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="280px" Font-Bold="True">B)Upload Circuit Breaker/Load Break Switch Test Reports</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="200px">Location <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtcircuitlocation" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidB" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtcircuitlocation"
                                                    ErrorMessage="Please Location Name" ValidationGroup="ValidB">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="200px">Capacity(A) <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtcircuitcapacity" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidB" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtcircuitcapacity"
                                                    ErrorMessage="Please Enter Capacity(A)" ValidationGroup="ValidB">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="200px">Make <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtcircuitmake" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidB" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtcircuitmake"
                                                    ErrorMessage="Please Enter Make" ValidationGroup="ValidB">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <%--   <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Internal Stair Cases (min 2) <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtInter_Stairs" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtInter_Stairs"
                                                    ErrorMessage="Please Enter Internal Stair Cases" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="200px">External Stair Cases (min 1) <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtExernal_Stairs" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtcontact27_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="txtExernal_Stairs"
                                                    ErrorMessage="Please Enter External Stair Cases" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3.&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="165px">Width of Stair Case<br />(min 1)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtWidth_Stairs" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="txtWidth_Stairs"
                                                    ErrorMessage="Please Enter Width of Stair Cases" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="200px">CB S.No. <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="TextBox5" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidB" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="TextBox5"
                                                    ErrorMessage="Please Enter CB S.No." ValidationGroup="ValidB">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <%--  <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label416" runat="server" CssClass="LBLBLACK" Width="165px">No Of Exits<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtNoofExits" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtNoofExits_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="txtNoofExits" ErrorMessage="Please Enter Number of Exists"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label417" runat="server" CssClass="LBLBLACK" Width="165px">Width of each exit (in mts.)<br />(min 4.5 mtrs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtWidth_eachExit" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="txtWidth_eachExit"
                                                    ErrorMessage="Please Enter Width of each exit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="200px">ISC KA<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtISCKA" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidB" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtISCKA"
                                                    ErrorMessage="Please Enter ISC KA" ValidationGroup="ValidB">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label55" runat="server" CssClass="LBLBLACK" Width="200px">TestCertificateUpload<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:FileUpload ID="TestCertificateupload" runat="server" CssClass="form-control txtbox"
                                                    Height="28px" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr9" runat="server">
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <asp:Button ID="btncircuitadd" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Add" ValidationGroup="ValidB" CausesValidation="true" Width="72px"
                                        OnClick="btncircuitadd_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btncircuitclear" runat="server" CausesValidation="False"
                                        Visible="false" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btncircuitclear_Click" />
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                    <asp:GridView ID="gvcircuit" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="Both" Width="100%" OnRowDataBound="gvcircuit_RowDataBound" OnRowDeleting="gvcircuit_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"
                                                DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Location" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Location
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Capacity" runat="server" Text='<%# Bind("CapacityA") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Capacity(A)
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Make" runat="server" Text='<%# Bind("Make") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Make
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="CBSNo" runat="server" Text='<%# Bind("CBSerialNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    CB S.No
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="ISCKA" runat="server" Text='<%# Bind("ISCKA") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    ISC KA
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="TestCertificateUpload" runat="server" Text='<%# Bind("TestCertificateUpload") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TestCertificateUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                           <%-- <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="testcertificatefilepath" runat="server" Text='<%# Bind("testcertificatefilepath") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TestCertificateUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#013161" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="280px" Font-Bold="True">C)Upload Transformer Test Certificates</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="200px">Transformer <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtTransformer" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidC" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtTransformer"
                                                    ErrorMessage="Please enter Transformer" ValidationGroup="ValidC">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px">Equipment Name <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txttransfEquipment" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidC" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txttransfEquipment"
                                                    ErrorMessage="Please Equipment Name" ValidationGroup="ValidC">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="200px">Type of Transformer<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddltransformer" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Dry</asp:ListItem>
                                                    <asp:ListItem Value="2">Oil</asp:ListItem>
                                                    <asp:ListItem Value="3">Cooled</asp:ListItem>
                                                    <asp:ListItem Value="4">Furnce</asp:ListItem>
                                                    <asp:ListItem Value="5">Power</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="ddltransformer"
                                                    ErrorMessage="Please Select Type of Transformer" ValidationGroup="ValidC">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="200px">Capacity<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtTransformercapacity" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" ValidationGroup="ValidC" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtTransformercapacity"
                                                    ErrorMessage="Please Enter Capacity" ValidationGroup="ValidC">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="200px">Make<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txttransmake" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidC" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txttransmake"
                                                    ErrorMessage="Please Enter Make" ValidationGroup="ValidC">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="200px">Serial No.	<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txttransserialno" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidC" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txttransserialno"
                                                    ErrorMessage="Please Enter Serial Number" ValidationGroup="ValidC">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label459" runat="server" CssClass="LBLBLACK" Width="200px">Voltage (HV/LV)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtVoltage" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidC" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtVoltage"
                                                    ErrorMessage="Please Enter Voltage (HV/LV)" ValidationGroup="ValidC">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                8.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label56" runat="server" CssClass="LBLBLACK" Width="200px">TransformerTestUpload<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:FileUpload ID="uploadTransformerTestUpload" runat="server" CssClass="form-control txtbox"
                                                    Height="28px" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr10" runat="server">
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <asp:Button ID="btnTransformersame" runat="server" CssClass="btn btn-xs btn-warning"
                                        Height="28px" TabIndex="10" Text="Add" ValidationGroup="ValidC" CausesValidation="true"
                                        Width="72px" OnClick="btnTransformersame_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnTransformerclear" runat="server" CausesValidation="False"
                                        Visible="false" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btnTransformerclear_Click" />
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                    <asp:GridView ID="gvTransformer" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="Both" Width="100%" OnRowDataBound="gvTransformer_RowDataBound" OnRowDeleting="gvTransformer_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"
                                                DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Transformer" runat="server" Text='<%# Bind("Transformer") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Transformer
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="EquipmentName" runat="server" Text='<%# Bind("EquipmentName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    EquipmentName
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="TypeofTransformer" runat="server" Text='<%# Bind("TypeofTransformer") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TypeofTransformer
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Capacity" runat="server" Text='<%# Bind("Capacity") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Capacity
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Make" runat="server" Text='<%# Bind("Make") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Make
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="SerialNo" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    SerialNo
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Voltage" runat="server" Text='<%# Bind("VoltageHVLV") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Voltage(HV/LV)
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="TransformerTestUpload" runat="server" Text='<%# Bind("TransformerTestUpload") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TransformerTestUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="transformeruploadfilepath" runat="server" Text='<%# Bind("transformeruploadfilepath") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TransformerTestUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#013161" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="280px" Font-Bold="True">D)Upload AB Switch / Isolator Test Report</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Location <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtSwitchlocation" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidE" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtSwitchlocation"
                                                    ErrorMessage="Please Enter Location" ValidationGroup="ValidE">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="200px">With or Without Earth Switch<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlearth" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">With Earth Switch</asp:ListItem>
                                                    <asp:ListItem Value="2">Without Earth Switch</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="ddlearth"
                                                    ErrorMessage="Please Select With or Without Earth Switch" ValidationGroup="ValidE">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="200px">Voltage(V)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtswitchVoltage" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidE" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtswitchVoltage"
                                                    ErrorMessage="Please Enter Sithch Voltage" ValidationGroup="ValidE">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label57" runat="server" CssClass="LBLBLACK" Width="200px">TestUpload<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:FileUpload ID="TestUpload" runat="server" CssClass="form-control txtbox" Height="28px" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="200px">Capacity(A)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtswitchcapacity" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidE" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtswitchcapacity"
                                                    ErrorMessage="Please Enter Capacity(A)" ValidationGroup="ValidE">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="200px">Make<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtswitchmake" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidE" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtswitchmake"
                                                    ErrorMessage="Please Enter Switch Make" ValidationGroup="ValidE">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="200px">Serial No.	<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtswitchserialno" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidE" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtswitchserialno"
                                                    ErrorMessage="Please Enter Switch Serial Number" ValidationGroup="ValidE">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr11" runat="server">
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <asp:Button ID="btnswitchsave" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Add" ValidationGroup="ValidE" Width="72px" OnClick="btnswitchsave_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnswitchclear" runat="server" CausesValidation="False"
                                        Visible="false" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btnswitchclear_Click" />
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                    <asp:GridView ID="gvswitch" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="Both" Width="100%" OnRowDataBound="gvswitch_RowDataBound" OnRowDeleting="gvswitch_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"
                                                DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Location" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Location
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="WithorWithoutEarthSwitch" runat="server" Text='<%# Bind("WithorWithoutEarthSwitch") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    With or Without Earth Switch
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Voltage" runat="server" Text='<%# Bind("VoltageV") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Voltage(V)
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Capacity" runat="server" Text='<%# Bind("CapacityA") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Capacity(A)
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Make" runat="server" Text='<%# Bind("Make") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Make
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="SerialNo" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    SerialNo
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="TestUpload" runat="server" Text='<%# Bind("TestUpload") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TestUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="testuploadpath" runat="server" Text='<%# Bind("testuploadpath") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TestUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#013161" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="280px" Font-Bold="True">E)Upload Lightning Arrestor Test Reports</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="200px">Location<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtlightinglocation" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" ValidationGroup="ValidF" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtlightinglocation"
                                                    ErrorMessage="Please Enter Location" ValidationGroup="ValidF">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="200px">Voltage(V)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtlightvoltage" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidF" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtlightvoltage"
                                                    ErrorMessage="Please Enter Light Voltage(V)" ValidationGroup="ValidF">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="200px">Capacity(A)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtlightcapacity" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidF" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtlightcapacity"
                                                    ErrorMessage="Please Enter Capacity(A)" ValidationGroup="ValidF">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label58" runat="server" CssClass="LBLBLACK" Width="200px">TestUpload<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:FileUpload ID="testUploadlightening" runat="server" CssClass="form-control txtbox"
                                                    Height="28px" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="200px">Make<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtlightmake" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidF" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtlightmake"
                                                    ErrorMessage="Please Enter Light Make" ValidationGroup="ValidF">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label41" runat="server" CssClass="LBLBLACK" Width="200px">Serial No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="TextBox24" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidF" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="200px"><font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="TextBox25" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidF" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr12" runat="server">
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <asp:Button ID="btnlightsave" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Add" ValidationGroup="ValidF" Width="72px" OnClick="btnlightsave_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnlightclear" runat="server" CausesValidation="False"
                                        Visible="false" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btnlightclear_Click" />
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                    <asp:GridView ID="gvlight" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="Both" Width="100%" OnRowDataBound="gvlight_RowDataBound" OnRowDeleting="gvlight_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"
                                                DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Location" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Location
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Voltage" runat="server" Text='<%# Bind("VoltageV") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Voltage(V)
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Capacity" runat="server" Text='<%# Bind("CapacityA") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Capacity(A)
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="Make" runat="server" Text='<%# Bind("Make") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Make
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="SerialNo" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    SerialNo
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="TestUpload" runat="server" Text='<%# Bind("TestUpload") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TestUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Testuploadfilepath" runat="server" Text='<%# Bind("Testuploadfilepath") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TestUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#013161" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label44" runat="server" CssClass="LBLBLACK" Width="280px" Font-Bold="True">F)Upload Generators Test Reports with Fuel</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="200px">Location<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtgeneratorlocation" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" ValidationGroup="ValidG" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtgeneratorlocation"
                                                    ErrorMessage="Please Enter Location" ValidationGroup="ValidG">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="200px">Capacity(A)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtgenercapacity" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidG" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtgenercapacity"
                                                    ErrorMessage="Please Enter Capacity(A)" ValidationGroup="ValidG">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label47" runat="server" CssClass="LBLBLACK" Width="200px">Make <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtgenemake" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidG" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtgenemake"
                                                    ErrorMessage="Please Enter Make" ValidationGroup="ValidG">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="200px">Serial No. <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtgeneserialno" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidG" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txtgeneserialno"
                                                    ErrorMessage="Please Enter Serial Number" ValidationGroup="ValidG">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label49" runat="server" CssClass="LBLBLACK" Width="200px">Fuel Type<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtfueltype" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidG" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="txtfueltype"
                                                    ErrorMessage="Please Enter Fuel Type" ValidationGroup="ValidG">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label50" runat="server" CssClass="LBLBLACK" Width="200px">Fuel Source<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtfuelsource" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidG" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtfuelsource"
                                                    ErrorMessage="Please Enter Fuel Source" ValidationGroup="ValidG">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label460" runat="server" CssClass="LBLBLACK" Width="200px">Sox/Nox Emission<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtsoxnox" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidG" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="txtsoxnox"
                                                    ErrorMessage="Please Enter Sox/Nox Emission" ValidationGroup="ValidG">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                8.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label461" runat="server" CssClass="LBLBLACK" Width="200px">Mercury<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtmercury" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidG" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="txtmercury"
                                                    ErrorMessage="Please Enter Mercury" ValidationGroup="ValidG">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                9
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label462" runat="server" CssClass="LBLBLACK" Width="200px">Heat Rate Details<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtheatrate" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidG" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtheatrate"
                                                    ErrorMessage="Please Enter Heat Rate Details" ValidationGroup="ValidG">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                10.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label59" runat="server" CssClass="LBLBLACK" Width="200px">FuelTestUpload<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:FileUpload ID="FuelTestUpload" runat="server" CssClass="form-control txtbox"
                                                    Height="28px" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr13" runat="server">
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <asp:Button ID="btngenesave" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Add" ValidationGroup="ValidG" Width="72px" OnClick="btngenesave_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btngeneclear" runat="server" CausesValidation="False"
                                        Visible="false" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btngeneclear_Click" />
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                    <asp:GridView ID="gvgene" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="Both" Width="100%" OnRowDataBound="gvgene_RowDataBound" OnRowDeleting="gvgene_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"
                                                DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Location
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCapacity" runat="server" Text='<%# Bind("CapacityA") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Capacity(A)
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMake" runat="server" Text='<%# Bind("Make") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Make
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerialNo" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    SerialNo
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFuelType" runat="server" Text='<%# Bind("FuelType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    FuelType
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFuelSource" runat="server" Text='<%# Bind("FuelSource") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    FuelSource
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSoxNoxEmission" runat="server" Text='<%# Bind("SoxNoxEmission") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Sox/NoxEmission
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMercury" runat="server" Text='<%# Bind("Mercury") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Mercury
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHeatRateDetails" runat="server" Text='<%# Bind("HeatRateDetails") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    HeatRateDetails
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="FuelTestUpload" runat="server" Text='<%# Bind("FuelTestUpload") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    FuelTestUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="FuelTestUploadfilepath" runat="server" Text='<%# Bind("FuelTestUploadfilepath") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    FuelTestUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#013161" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label51" runat="server" CssClass="LBLBLACK" Width="280px" Font-Bold="True">G)Upload Pre Commissioning Test Report</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label52" runat="server" CssClass="LBLBLACK" Width="200px">Equipment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtcommequipment" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidH" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtcommequipment"
                                                    ErrorMessage="Please Enter Equipment Name" ValidationGroup="ValidH">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label60" runat="server" CssClass="LBLBLACK" Width="200px">CommissioningUpload<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:FileUpload ID="CommissioningUpload" runat="server" CssClass="form-control txtbox"
                                                    Height="28px" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label463" runat="server" CssClass="LBLBLACK" Width="200px">Description<font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtcommdesc" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="ValidH" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtcommdesc"
                                                    ErrorMessage="Please Enter Description" ValidationGroup="ValidH">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr14" runat="server">
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <asp:Button ID="btncommsave" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Add" ValidationGroup="ValidH" Width="72px" OnClick="btncommsave_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btncommclear" runat="server" CausesValidation="False"
                                        Visible="false" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btncommclear_Click" />
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                    <asp:GridView ID="gvcomm" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="Both" Width="100%" OnRowDataBound="gvcomm_RowDataBound" OnRowDeleting="gvcomm_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"
                                                DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEquipmentH" runat="server" Text='<%# Bind("Equipment") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Equipment
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescriptionH" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Description
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCommissioningUpload" runat="server" Text='<%# Bind("CommissioningUpload") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    CommissioningUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCommissioningUpload" runat="server" Text='<%# Bind("CommissioningUploadfilepath") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    CommissioningUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#013161" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="280px" Font-Bold="True">H)Upload Transmission lines</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="200px">Description<font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txttransDescription" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" ValidationGroup="ValidI" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txttransDescription"
                                                    ErrorMessage="Please Enter Description" ValidationGroup="ValidI">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label61" runat="server" CssClass="LBLBLACK" Width="200px">TransmissionUpload<font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:FileUpload ID="TransmissionUpload" runat="server" CssClass="form-control txtbox"
                                                    Height="28px" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr15" runat="server">
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <asp:Button ID="btntransave" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Add" ValidationGroup="ValidI" Width="72px" OnClick="btntransave_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btntransclear" runat="server" CausesValidation="False"
                                        Visible="false" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                        Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" OnClick="btntransclear_Click" />
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                    <asp:GridView ID="gvtran" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="Both" Width="100%" OnRowDataBound="gvtran_RowDataBound" OnRowDeleting="gvtran_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"
                                                DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescriptionI" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    Description
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="TransmissionUpload" runat="server" Text='<%# Bind("TransmissionUpload") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TransmissionUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="TransmissionUploadfilepath" runat="server" Text='<%# Bind("TransmissionUploadfilepath") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    TransmissionUpload
                                                </HeaderTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#013161" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table style="width: 60%">
                                        <tr runat="server" id="trerector" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="210px">Work Completion Report from Supplier<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="FileAgreement" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="lblAgreement" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelAgreement" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="BtnAgreement" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="BtnAgreement_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr1" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="210px">Work Commencement Report (WR-I)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadLicense" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HpLicense" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblLicense" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnLicense" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btnLicense_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr3" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="210px">Work Completion Report (WR-II)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadpermit" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hppermit" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblpermitr" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnpermit" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btnpermit_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr4" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="210px">Feasibility report from the DISCOMS<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadFeasibility" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HpFeasibility" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblFeasibility" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnFeasibility" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnFeasibility_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr5" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="210px">Electrical Single line diagram from Point of Commencement of supply to the end use of electrical energy   <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadElectricalDiagram" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="HpElectricalDiagram" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblElectricalDiagram" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnElectricalDiagram" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnElectricalDiagram_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr6" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label38" runat="server" CssClass="LBLBLACK" Width="210px">The structural layout showing plan and Elevations with sectional and safe clearances<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadlayout" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hplayout" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lbllayout" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnlayout" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btnlayout_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr7" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="210px">General arrangement of the equipment drawing showing the location of various equipments.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadequipmentdrawing" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="Hpequipmentdrawing" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblequipmentdrawing" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnequipmentdrawing" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnequipmentdrawing_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr8" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                8.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="210px">The earthing layout diagram </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadearthinglayout" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="hpearthinglayout" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblearthinglayout" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnearthinglayout" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnearthinglayout_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <caption>
                                &nbsp;</caption>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px"
                                        OnClick="BtnClear0_Click" TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" />
                                    &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                        Height="32px" OnClick="BtnDelete0_Click" TabIndex="10" Text="Previous" Width="90px" />
                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                        Width="90px" />
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
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                    </div>
                    <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
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
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
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

            $("input[id$='txtDateofCommencement']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
           
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateofCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
           
        });
    </script>
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }
    </style>
</asp:Content>
