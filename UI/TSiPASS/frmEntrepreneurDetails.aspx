<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmEntrepreneurDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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
        
        .style5
        {
            color: #FF0000;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
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
   <%-- <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length = 6)
                return true;
            else {
                alert("Pin number length must be exactly 6 characters")
                return false;
            }

        }
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
                return false;
            }
            else {
                return true;
            }
        }
    </script>
--%>    
<asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Entrepreneur Details</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <%--<div class="panel panel-primary">
                           <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Entrepreneur Details</h3>
                            </div>--%>
                        <div class="col-md-12">
                            <h1 class="page-head-line" align="left" style="font-size: x-large">
                                Enterprise Details</h1>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="panel-body" align="left">
                                    <table align="left" cellpadding="10" cellspacing="5" style="width: 90%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 70%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name of Industrial Undertaking <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtindustrialName" runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="1"  MaxLength="300"  ValidationGroup="group" Width="250px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtindustrialName"
                                                                ErrorMessage="Please enter Industries Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Name of Promoter<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtPromotor" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                Height="28px" MaxLength="1000" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPromotor"
                                                                ErrorMessage="Please enter Promoter Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="200px">S/o.D/o.W/o<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtSoromoter" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                Height="28px" MaxLength="1000" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSoromoter"
                                                                ErrorMessage="Please enter  S/O  Promoter" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">Communication Address</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Width="165px">State<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlstate" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"
                                                                TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlstate"
                                                                ErrorMessage="Please select state" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="dist" runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px">
                                                            5.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtDistrict" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr id="mandal" runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px">
                                                            6.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtMandal" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr id="Vill" runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px">
                                                            7.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtVillage" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr id="dist1" visible="false" runat="server">
                                                        <td style="padding: 5px; margin: 5px">
                                                            5.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label352" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" TabIndex="1" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"
                                                                Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddldistrict"
                                                                ErrorMessage="Please select  District" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="mandal1" visible="false" runat="server">
                                                        <td style="padding: 5px; margin: 5px">
                                                            6.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label398" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMandal"
                                                                ErrorMessage="Please select  Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="vill1" runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px">
                                                            7.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label399" runat="server" CssClass="LBLBLACK" Width="165px">Village/Town<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlvillage" runat="server" class="form-control txtbox" TabIndex="1"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlvillage"
                                                                ErrorMessage="Please select  Village" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            8.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label388" runat="server" CssClass="LBLBLACK" Width="165px">Street Name<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtstreetName" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="300" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtstreetName"
                                                                ErrorMessage="Please enter  Street Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px">
                                                            9.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="165px">Uid Number<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtUIDnumber" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="15" TabIndex="1" ValidationGroup="group" Text="0" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            9.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Door No<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtDoorNo" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                                MaxLength="200" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtDoorNo"
                                                                ErrorMessage="Please enter Door Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            10.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Pincode<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtPincode" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength(this)"
                                                                ValidationGroup="group" Width="180px" OnTextChanged="txtcontact9_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPincode"
                                                                ErrorMessage="Please enter PinCode number" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                        <td style="padding: 5px; margin: 5px">
                                                            11.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Mobile No<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtmobileNo" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength1(this)" Onpaste="return false"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtmobileNo"
                                                                ErrorMessage="Please enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            12.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Alternative Mobile No<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtAltmobileno" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength1(this)"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtAltmobileno"
                                                                ErrorMessage="Please enter Alternative Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            13.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Email<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtEmail"
                                                                ErrorMessage="Please enter Email" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                                                ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trUserid">
                                                        <td style="padding: 5px; margin: 5px" valign="middle">
                                                            14.
                                                        </td>
                                                        <td style="width: 200px;" valign="middle">
                                                            <asp:Label ID="Label400" runat="server" CssClass="LBLBLACK" Width="165px">Type of Organization<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlType" runat="server" class="form-control txtbox" TabIndex="1"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">Proprietary</asp:ListItem>
                                                                <asp:ListItem Value="2">Partnership</asp:ListItem>
                                                                <asp:ListItem Value="3">PVT LTD</asp:ListItem>
                                                                <asp:ListItem Value="4">Public Limited</asp:ListItem>
                                                                <asp:ListItem Value="5">Co-Operative</asp:ListItem>
                                                                <asp:ListItem Value="6">LLP</asp:ListItem>
                                                                <asp:ListItem Value="7">Trust</asp:ListItem>
                                                                 <asp:ListItem Value="8">PPP</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddlType"
                                                                ErrorMessage="Please enter Type of Organization" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trpwd">
                                                        <td style="padding: 5px; margin: 5px">
                                                            15.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Tel No(Landline)(If available)
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txttelephone" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="15" TabIndex="1" onkeypress="NumberOnly()"  ValidationGroup="group" oncopy="return false" onpaste="return false" oncut="return false"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txttelephone"
                                                                ErrorMessage="Please enter Telephone Number" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="tr1">
                                                        <td style="padding: 5px; margin: 5px">
                                                            16.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Proposal For<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlproposal" runat="server" class="form-control txtbox" TabIndex="1"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">New</asp:ListItem>
                                                                <asp:ListItem Value="2">Expansion</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlproposal"
                                                                ErrorMessage="Please enter Proposed For" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="tr2">
                                                        <td style="padding: 5px; margin: 5px">
                                                            17 .
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Social Status<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" TabIndex="1"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">OC</asp:ListItem>
                                                                <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                <asp:ListItem Value="3">SC</asp:ListItem>
                                                                <asp:ListItem Value="4">ST</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlCaste"
                                                                ErrorMessage="Please enter Caste" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trdiffable">
                                                        <td style="padding: 5px; margin: 5px">
                                                            18.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Differently Abled<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlDifferentlyabled" runat="server" class="form-control txtbox"
                                                                TabIndex="1" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDifferentlyabled"
                                                                ErrorMessage="Please Select Differently Abled" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="womenEnterprenuer">
                                                        <td style="padding: 5px; margin: 5px">
                                                            19.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Women Entrepreneur <span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlWomenEnterprenuer" runat="server" class="form-control txtbox"
                                                                TabIndex="1" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlWomenEnterprenuer"
                                                                ErrorMessage="Please Select Women Enterprenuer" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="minority">
                                                        <td style="padding: 5px; margin: 5px">
                                                            20.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Minority<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlMinority" runat="server" class="form-control txtbox" TabIndex="1"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="ddlMinority"
                                                                ErrorMessage="Please Select Minority" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                <span style="font-weight: bold">Project Details</span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                &nbsp;&nbsp;&nbsp; <span style="font-weight: bold" id="tdprojectcostname" runat="server">
                                                    A). New/Existing Investment</span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtlandValue" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtlandValue_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtlandValue"
                                                                ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtbuilding" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtbuilding_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtbuilding"
                                                                ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtPlant" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtPlant_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPlant"
                                                                ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label432" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txttotal" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txttotal"
                                                                ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tblexpansionheading" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>B). Expansion Investment</u></span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tblexpansion" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtlandValueexp" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtlandValue_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                    ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtbuildingexp" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtbuilding_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                    ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
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
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtPlantexp" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtPlant_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                    ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txttotalexp" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                    ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="trtotalinv" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                &nbsp;&nbsp;&nbsp; <span style="font-weight: bold"><u>C). Total Investment</u></span>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trtotalinvinv" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="210px">Land Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtlandValueexptotal" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtlandValue_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtlandValue"
                                                                    ErrorMessage="Please enter  Land Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">Building Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtbuildingexptotal" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="1" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtbuilding_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtbuilding"
                                                                    ErrorMessage="Please enter  Building Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
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
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">Plant and Machinery Value(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtPlantexptotal" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtPlant_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPlant"
                                                                    ErrorMessage="Please enter  Plant and Machinery" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">Total Value(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txttotalexptotal" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txttotal"
                                                                    ErrorMessage="Please enter  Total Values" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="280px">Employment Details</asp:Label>
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
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label409" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="165px">Direct <font 
                                                            color="red">*</font></asp:Label>
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
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Male<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtDirectmale" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Onpaste="return false"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtDirectmale_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtDirectmale"
                                                                ErrorMessage="Please enter Direct male" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="165px">Female<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtdirectfemale" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Onpaste="return false"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtdirectfemale_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtdirectfemale"
                                                                ErrorMessage="Please enter Direct Female" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="lbltransgender" runat="server" CssClass="LBLBLACK" Width="165px">Transgender<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtdirectTransgender" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Onpaste="return false"
                                                                Width="180px" AutoPostBack="True" OnTextChanged="txtdirectTransgender_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtdirectTransgender"
                                                                ErrorMessage="Please enter Direct Transgender" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Total Employment</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="lbltotalEmployment" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label410" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="165px">In-direct <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label411" runat="server" CssClass="LBLBLACK" Width="165px">Male<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtIndirectMale" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Onpaste="return false"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtIndirectMale"
                                                                ErrorMessage="Please enter Direct Inmale" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label412" runat="server" CssClass="LBLBLACK" Width="165px">Female<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtindirectFemale" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Onpaste="return false"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtindirectFemale"
                                                                ErrorMessage="Please enter Direct Infemale" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            6.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px">Transgender<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="TXTINDIRECTTRANSGENDER" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Onpaste="return false"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="TXTINDIRECTTRANSGENDER"
                                                                ErrorMessage="Please enter InDirect Transgender" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
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
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            5.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label416" runat="server" CssClass="LBLBLACK" Width="165px">Category of Registration<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:DropDownList ID="ddlcategory" runat="server" class="form-control txtbox" Height="33px"
                                                                TabIndex="1" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">EM-PART I</asp:ListItem>
                                                                <asp:ListItem Value="2">Udyog Aadhaar</asp:ListItem>
                                                                <asp:ListItem Value="3">IND LICENSE</asp:ListItem>
                                                                <asp:ListItem Value="4">IEM</asp:ListItem>
                                                                <asp:ListItem Value="5">EOU</asp:ListItem>
                                                                <asp:ListItem Value="6">SEZ</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlcategory"
                                                                ErrorMessage="Please Select Category of Registration" ValidationGroup="group"
                                                                InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            6.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label417" runat="server" CssClass="LBLBLACK" Width="165px">Registration No<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtregNo" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="25" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtregNo_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            7.&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label420" runat="server" CssClass="LBLBLACK" Width="165px">Registration Date(dd-MM-yyyy)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtRegDate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtRegDate"
                                                                    TargetControlID="txtRegDate">
                                                                </cc1:CalendarExtender>--%>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            8.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label421" runat="server" CssClass="LBLBLACK" Width="165px">Type of Factories<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlfactoryType" runat="server" class="form-control txtbox"
                                                                TabIndex="1" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">Hazardous</asp:ListItem>
                                                                <asp:ListItem Value="2">Non-Hazardous</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                    Width="90px" />&nbsp;
                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    OnClick="BtnSave_Click" TabIndex="10" Text="Save" Width="90px" ValidationGroup="group" />
                                                <asp:Button ID="BtnDelete0" runat="server" CssClass="btn btn-danger" Height="32px"
                                                    OnClick="BtnDelete0_Click" TabIndex="10" Text="Privious" Width="90px" Visible="False" />
                                                &nbsp;
                                                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px"
                                                    OnClick="BtnClear0_Click" TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" />
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
                                        <tr>
                                            <td colspan="10">
                                                <asp:HiddenField ID="hdfID" runat="server" />
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="group" />
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="child" />
                                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                                                <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                                <asp:HiddenField ID="hdfFlagID1" runat="server" />
                                                <asp:HiddenField ID="hdfpencode" runat="server" />
                                                  <asp:HiddenField ID="HDNDATEOFPAYMENT" runat="server" />
                                                <asp:HiddenField ID="HDNAPPLSTATUS" runat="server" />


                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--  </div>--%>
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

            $("input[id$='txtRegDate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtRegDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
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
