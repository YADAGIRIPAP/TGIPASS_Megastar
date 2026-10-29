<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmPCBDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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

        .style7 {
            color: #FF3300;
        }

        .style8 {
        }

        .auto-style1 {
            height: 45px;
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

    <asp:UpdatePanel ID="upd1" runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnEmpDoc" />
             <asp:PostBackTrigger ControlID="btnC5Form" />
             </Triggers>
        <ContentTemplate>
            <div align="left">
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
            </div>

            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">PCB Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <Triggers>
            <asp:PostBackTrigger ControlID="btnEmpDoc" />
             <asp:PostBackTrigger ControlID="btnC5Form" />
             </Triggers>
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
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                    Width="310px">A) Waste Water Generation (in KLD)</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Process<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtProcess" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                                    OnTextChanged="txtProcess_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                    ControlToValidate="txtProcess" ErrorMessage="Please enter Process"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style8">
                                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Washings<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtwashing" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                                    OnTextChanged="txtwashing_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                    ControlToValidate="txtwashing" ErrorMessage="Please enter Washings"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">Boiler Blow Down<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtboiler" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                                    OnTextChanged="txtboiler_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                    ControlToValidate="txtboiler" ErrorMessage="Please enter  Boiler"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="165px">Cooling Tower Bleed Off<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtcooling" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                                    OnTextChanged="txtcooling_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                    ControlToValidate="txtcooling" ErrorMessage="Please enter Cooling Tower Bleed"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">Domestic<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtdomestic" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                                    OnTextChanged="txtdomestic_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                    ControlToValidate="txtdomestic" ErrorMessage="Please enter Cooling Domestic"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="165px">Total<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txttotal" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                                    ControlToValidate="txttotal" ErrorMessage="Please enter Total"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>




                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                    Width="310px">B) Process</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="210px">Emission Characteristics and Source Details</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="Txtemission" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style8">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="200px">Quantity of Emissions</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TxtQuantity" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="200px">Does the Unit use a generator</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlproject" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px"
                                                                    OnSelectedIndexChanged="ddlproject_SelectedIndexChanged" TabIndex="1">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="2">No</asp:ListItem>

                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>

                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="200px">Control Equipment/System</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TxtcontrolEquipement" runat="server"
                                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                    Width="310px">C) Air Pollution</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;"
                                                                colspan="3">
                                                                <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK" Width="291px">I DG Set/Boiler/Thermic Fluid Heater</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="210px">Capacity(In KVA)<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TxtCapacity" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                                    ControlToValidate="TxtCapacity" ErrorMessage="Please enter Capacity"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style8">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Fuel Consumption Per Day (in Litre&#39;s per day)<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="Txtfuel" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                    ControlToValidate="Txtfuel" ErrorMessage="Please enter Fuel"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">Fuel Storage Details<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TxtFuelstorage" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px" OnTextChanged="TextBox7_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                    ControlToValidate="TxtFuelstorage" ErrorMessage="Please enter Fuel Storage"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="200px">Stack Height &amp; Diameters(mts)</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="200px">Height(mts)</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="Txtheight" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="200px">Diameters(mts)</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TxtDiameter" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="200px">Air Pollution Control Equipement Details</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtAirpollution" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label444" runat="server" CssClass="LBLBLACK" Width="210px"
                                                                    Font-Bold="True">D) Solid and hazardous waste</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Name Of Waste<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtwaste" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="60" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                    ControlToValidate="txtwaste" ErrorMessage="Please enter waste Name"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="200px">Category As Per Hw Rules<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtcatagory" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                    ControlToValidate="txtcatagory" ErrorMessage="Please enter Category"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label411" runat="server" CssClass="LBLBLACK" Width="200px">Quanity Generated Per Day<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtQntGenerated" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="18" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                                    ControlToValidate="txtQntGenerated"
                                                                    ErrorMessage="Please enter Quantity Generated per day" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label416" runat="server" CssClass="LBLBLACK" Width="165px">Storage And Treatment<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 192px;">
                                                                <asp:TextBox ID="txtstorage" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                                    ControlToValidate="txtstorage" ErrorMessage="Please enter storage"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label417" runat="server" CssClass="LBLBLACK" Width="165px">Disposal<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtdisposal" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="18" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                                    ControlToValidate="txtdisposal" ErrorMessage="Please enter Disposal"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" TabIndex="10" Text="Add New" ValidationGroup="child"
                                                                    Width="72px" OnClick="BtnSave3_Click" />
                                                                &nbsp;<asp:Button ID="BtnClear1" runat="server" CausesValidation="False" Visible="false"
                                                                    CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel"
                                                                    ToolTip="To Clear  the Screen" Width="73px" OnClick="BtnClear1_Click" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center" class="style7">
                                                    <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                        OnRowDataBound="gvCertificate_RowDataBound"
                                                        OnRowDeleting="gvCertificate_RowDeleting" Width="100%"
                                                        DataKeyNames="intCFEPCBBulkid">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />
                                                            <asp:BoundField DataField="NameofWaste" HeaderText="Waste" />
                                                            <asp:BoundField DataField="Category" HeaderText="Category" />
                                                            <asp:BoundField DataField="Qunt_Generated" HeaderText="Quantity" />
                                                            <asp:BoundField DataField="Storage_Treatment" HeaderText="Storage" />
                                                            <asp:BoundField DataField="Disposal" HeaderText="Disposal" />
                                                        </Columns>
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#013161" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                
                                            </tr>
                                                    <tr>
                                                        <td colspan="3" align="center">
                                                            <table align="center">
                                                                    <tr id="trEmpUpload" runat="server" visible="false" align="center">
                                                                    <td>
                                                                        Environment Management Plan
                                                                        </td>

                                                                    <td align="center" style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                        <asp:FileUpload ID="fupEmpDoc" Height="28px" Width="300px" class="form-control txtbox" runat="server" />
                                                                        <asp:HyperLink ID="hlEmpDoc" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                                        <br />
                                                                        <asp:Label ID="lblEmpDoc" runat="server" Visible="False"></asp:Label>
                                                                    </td>
                                                                         <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnEmpDoc" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnEmpDoc_Click"  />
                                            </td>
                                                                    </tr>

                                                                <tr id="trc5Upload" runat="server" visible="false">
                                                                    <td>
                                                                        C5 Form
                                                                        </td>

                                                                    <td align="center" style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                        <asp:FileUpload ID="fupc5Form" runat="server" class="form-control txtbox" Height="28px" Width="300px" />
                                                                        <asp:HyperLink ID="hlc5Form" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                                        <br />
                                                                        <asp:Label ID="lblc5Form" runat="server" Visible="False"></asp:Label>
                                                                    </td>
                                                                                          <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnC5Form" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" OnClick="btnC5Form_Click"
                                                    Width="72px"/>
                                            </td>
                                                    
                                                                </tr>
                                                                </table>

                                                            
                                                                    
                                                                    <tr id="trc5form" runat="server" visible="false">
                                                                        <td align="center" class="style7" colspan="3" style="padding: 5px; margin: 5px">NOTE: If your industry falls under Red Category, kindly download, fill and upload C5. <a href="../../docs/C5.pdf" target="_blank">Click here to download C5</a><tr>
                                                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                        </tr>
                                                                        </td>
                                                                    </tr>                                                                   
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>


                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3"
                                                    style="padding: 5px; margin: 5px; text-align: center;">

                                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />&nbsp;

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


                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>


                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                        <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

