<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmPowerCeig.aspx.cs" Inherits="UI_TSiPASS_frmPowerCeig" %>

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

        .style6 {
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
                        <h3 class="panel-title">Power Details</h3>
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
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="400px" Font-Bold="True">Contracted Maximum Demand in KVA <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label449" runat="server" CssClass="LBLBLACK" Width="200px">Already installed<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtKVAAlreadyInstalled" runat="server"
                                                    class="form-control txtbox" Style="text-align: right"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True"
                                                    OnTextChanged="txtKVAAlreadyInstalled_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                    ControlToValidate="txtKVAAlreadyInstalled"
                                                                    ErrorMessage="Please enter Already Installed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">Proposed<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtKVAProposed" runat="server" class="form-control txtbox"
                                                    Height="28px" Style="text-align: right"
                                                    MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True"
                                                    OnTextChanged="txtKVAProposed_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                    ControlToValidate="txtKVAAlreadyInstalled"
                                                                    ErrorMessage="Please enter Already Installed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px">Total<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtKVATotal" runat="server" class="form-control txtbox"
                                                    Height="28px" Style="text-align: right"
                                                    MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                    ControlToValidate="txtKVATotal" ErrorMessage="Please enter Total"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="400px" Font-Bold="True">Connected Load in KW/HP<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="200px">Type of Connected Load<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
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
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="ddlConnectLoad" ErrorMessage="Please select Connected Load"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label453" runat="server" CssClass="LBLBLACK" Width="200px">Already installed<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtConnectedAlreadyInstalled" runat="server"
                                                    class="form-control txtbox" Style="text-align: right"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True"
                                                    OnTextChanged="txtConnectedAlreadyInstalled_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                    ControlToValidate="txtConnectedAlreadyInstalled"
                                                    ErrorMessage="Please select Already Installed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label454" runat="server" CssClass="LBLBLACK" Width="200px">Proposed<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtConnectProposed" runat="server" class="form-control txtbox"
                                                    Height="28px" Style="text-align: right"
                                                    MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True"
                                                    OnTextChanged="txtConnectProposed_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="txtConnectProposed" ErrorMessage="Please enter Proposed"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label457" runat="server" CssClass="LBLBLACK" Width="200px">Total<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtConnectTotal" runat="server" class="form-control txtbox"
                                                    Height="28px" Style="text-align: right"
                                                    MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="txtConnectTotal" ErrorMessage="Please enter Connected Total"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                         <tr id="Tr2" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">13
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="165px">Telephone(incl STD Code)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtTelephone" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="18" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                                                    ControlToValidate="txtTelephone" ErrorMessage="Please enter Telephone"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr9" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">14
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="200px">Nearest Telephone No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNearTelephone" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="18" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                            </td>
                                        </tr>
                                        <tr id="Tr10" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">15</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="200px">Date of Commencement of Production(dd-MMM-yyyy)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtDateofCommencement" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" OnTextChanged="txtcontact32_TextChanged"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                                    PopupButtonID="txtDateofCommencement" TargetControlID="txtDateofCommencement">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                                    ControlToValidate="txtDateofCommencement"
                                                                    ErrorMessage="Please enter Commencement date" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                            <td style="padding: 5px; margin: 5px" valign="top">3</td>
                                            <td style="width: 200px;">Regulation</td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlregulation" runat="server" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlregulation_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server"
                                                                    ControlToValidate="ddlregulation" ErrorMessage="Please select Regulation"
                                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trvoltage" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                            <td style="width: 200px;">Voltage</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlvoltage" runat="server" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddlvoltage" ErrorMessage="Please select Voltage" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr id="trPlant" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                            <td style="width: 200px;">Plant</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlplant" runat="server" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlplant" ErrorMessage="Please select  Plant" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="middle">4</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">Aggregate Transformer Capacity(ATC) (in KVA)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtaggregatecapacity" runat="server" class="form-control txtbox" Height="28px" MaxLength="8" onkeypress="NumberOnly()" Style="text-align: right" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtaggregatecapacity" ErrorMessage="Please Aggregate Transformer Capacity(ATC) (in KVA) " ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr align="center" style="text-align: center" valign="middle" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top">5&nbsp;</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label458" runat="server" CssClass="LBLBLACK" Width="200px">Proposed Location of Factory<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlProject" runat="server" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">IE</asp:ListItem>
                                                    <asp:ListItem Value="2">IDA</asp:ListItem>
                                                    <asp:ListItem Value="3">SEZ</asp:ListItem>
                                                    <asp:ListItem Value="4">Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlProject" ErrorMessage="Please select  Project" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">6
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="200px">Survey No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtSurvey" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                    ControlToValidate="txtSurvey" ErrorMessage="Please enter Survey Number"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">7
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label444" runat="server" CssClass="LBLBLACK" Width="165px">Extent<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtExtent" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtcontact29_TextChanged"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                    ControlToValidate="txtExtent" ErrorMessage="Please enter Extent"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">8
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="200px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                ControlToValidate="ddlDistrict" ErrorMessage="Please select District"
                                                InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                &nbsp;</td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">9
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                                    ControlToValidate="ddlMandal" ErrorMessage="Please select Mandals"
                                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">10
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="200px">Village/Town<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" AutoPostBack="True" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                                    ControlToValidate="ddlVillage" ErrorMessage="Please select Villages"
                                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">11
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="165px">Street Name<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStreet" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="30"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                                    ControlToValidate="txtStreet" ErrorMessage="Please enter street name"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">12
                                            </td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="200px">PinCode <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtPinCode" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" onkeypress="NumberOnly()" onblur="checkLength(this)" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                                    ControlToValidate="txtPinCode" ErrorMessage="Please enter PIN number"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                       
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;
                                </td>
                                <td style="width: 27px">&nbsp;
                                </td>
                                <td valign="top">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table style="width: 60%">
                                        <tr runat="server" id="trerector" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="210px">Agreement letter between Contractor & Owner<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="FileAgreement" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="lblAgreement" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelAgreement" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="BtnAgreement" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="BtnAgreement_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr1" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="210px">Contractor License copy<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadLicense" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HpLicense" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblLicense" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnLicense" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnLicense_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr3" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="210px">Contractor/Project electrical supervisor permit copy  <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadpermit" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="Hppermit" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblpermitr" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnpermit" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnpermit_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr4" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="210px">Feasibility report from the DISCOMS<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
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
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnFeasibility_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr5" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="210px">Electrical Single line diagram from Point of Commencement of supply to the end use of electrical energy   <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
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
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnElectricalDiagram_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr6" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label38" runat="server" CssClass="LBLBLACK" Width="210px">The structural layout showing plan and Elevations with sectional and safe clearances<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadlayout" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="Hplayout" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lbllayout" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnlayout" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnlayout_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr7" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">7.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="210px">General arrangement of the equipment drawing showing the location of various equipments.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
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
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnequipmentdrawing_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr8" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">8.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="210px">The earthing layout diagram </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
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
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnearthinglayout_Click" />
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
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger"
                                        Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Next"
                                        Width="90px" ValidationGroup="group" />
                                    &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click"
                                        TabIndex="10" Text="Previous" Width="90px" />
                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
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
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
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
</asp:Content>

