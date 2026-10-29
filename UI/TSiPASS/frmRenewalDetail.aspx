<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmRenewalDetail.aspx.cs" Inherits="UI_TSiPASS_frmRenewalDetail" %>

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
                                Renewal Details</h1>
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
                                                            <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name of the Enterprise/Applicant <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtindustrialName" runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
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
                                                        <asp:HiddenField ID="hdncreatedby" runat="server" />
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtPromotor" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
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
                                                                Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSoromoter"
                                                                ErrorMessage="Please enter  S/O  Promoter" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" colspan="3">
                                                            <strong>Location of the Enterprise</strong>
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
                                                            <asp:Label ID="Label352" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged" TabIndex="1"
                                                                Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddldistrict"
                                                                ErrorMessage="Please select  District" InitialValue="--Select--" ValidationGroup="group"
                                                                Visible="true">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            5.
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
                                                                ErrorMessage="Please select  Mandal" InitialValue="--Select--" ValidationGroup="group"
                                                                Visible="true">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            6
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
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlvillage_SelectedIndexChanged">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlvillage"
                                                                ErrorMessage="Please select  Village" InitialValue="--Select--" ValidationGroup="group"
                                                                Visible="true">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            7.
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
                                                                MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtstreetName"
                                                                ErrorMessage="Please enter  Street Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            14.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label400" runat="server" CssClass="LBLBLACK" Width="165px">Sector of Enterprise<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlSector" runat="server" class="form-control txtbox" Height="33px"
                                                                TabIndex="1" Width="180px">
                                                                <%-- <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="2">Service</asp:ListItem>
                                                                    <asp:ListItem Value="1" Selected="True">Manufacturing</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlSector"
                                                                ErrorMessage="Please Select Sector" InitialValue="--Select--" ValidationGroup="group"
                                                                Visible="true">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            15.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="165px">Line of Activity<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlintLineofActivity" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged"
                                                                Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlintLineofActivity"
                                                                ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 15px; margin: 5px" valign="top">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK">Pollution Category of Enterprise<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" id="trPOPCategory" runat="server">
                                                            <asp:Label ID="LblPol_Category" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                Font-Size="18px" Width="200px"></asp:Label>
                                                            <asp:HiddenField ID="HdfLblPol_Category" runat="server" />
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <tr id="trprojectcost" runat="server" visible="true">
                                                            <td style="padding: 5px; margin: 5px">
                                                                16.
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" data-balloon="Please Select Project Cost"
                                                                    data-balloon-length="large" data-balloon-pos="down" Font-Bold="True">Project Cost</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlcurrencytype" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                    Height="33px" OnSelectedIndexChanged="ddlcurrencytype_SelectedIndexChanged" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlcurrencytype"
                                                                    ErrorMessage="Please Select Currency" InitialValue="--Select--" ValidationGroup="group"
                                                                    Visible="true">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
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
                                                            8.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Door No<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtDoorNo"
                                                                ErrorMessage="Please Enter Door Number" ValidationGroup="group" Visible="true">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            9.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Pincode<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtPincode0" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="6" onblur="checkLength(this)" onkeypress="NumberOnly()" TabIndex="1"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtPincode0"
                                                                ErrorMessage="Please Enter Pincode" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            10.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Mobile No<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtmobileNo" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onblur="checkLength1(this)" onkeypress="NumberOnly()" TabIndex="1"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtmobileNo"
                                                                ErrorMessage="Please enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            11.
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
                                                    <tr runat="server" id="trpwd">
                                                        <td style="padding: 5px; margin: 5px">
                                                            12.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Designation<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtdesignation" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtdesignation"
                                                                ErrorMessage="Please enter Designation" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="tr2">
                                                        <td style="padding: 5px; margin: 5px">
                                                            13.
                                                        </td>
                                                        <td style="width: 200px;">
                                                            Age<span class="style5">*</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtage" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="15" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtage"
                                                                ErrorMessage="Please enter Age" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="minority">
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 200px;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="lblqueid" runat="server" CssClass="LBLBLACK" Width="200px" Visible="false"></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="Tr1">
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 200px;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px" Visible="false"></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="Tr3">
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 200px;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px" Visible="false"></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                       


                                        <tr id="trinvestment" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                <tr>
                                                    <td>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td colspan="3" style="padding: 5px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black">
                                                                    (Mention Zero in case of leased premises)
                                                                </td>
                                                                <td id="tdprojectcostname" runat="server" align="left" style="padding: 5px; margin: 5px;
                                                                    font-weight: bold; border-top: solid 1px black;" valign="top">
                                                                    Existing Investment
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 15px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black; border-right: solid 1px black" valign="top">
                                                                    a)
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" valign="top">
                                                                    <asp:Label ID="Label390" runat="server" CssClass="LBLBLACK">Value of Land</asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="txtlandvalueActul" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Height="28px" MaxLength="15" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtlandvalueActul_TextChanged"
                                                                        TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtlandvalueActul"
                                                                        ErrorMessage="Please enter Value of Land" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td align="right" style="padding: 5px; margin: 5px">
                                                                    In Rs. Lakhs
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtlandvalue" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Enabled="false" Height="28px" MaxLength="15" onkeypress="return inputOnlyNumbers(event)"
                                                                        OnTextChanged="txtlandvalue_TextChanged" TabIndex="1" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 15px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black; border-right: solid 1px black" valign="top">
                                                                    b)
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" valign="top">
                                                                    <asp:Label ID="Label391" runat="server" CssClass="LBLBLACK">Value of Building<font 
                                color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="txtbuildingvalueActual" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Height="28px" MaxLength="15" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtbuildingvalueActual_TextChanged"
                                                                        TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtbuildingvalueActual"
                                                                        ErrorMessage="Please enter Value of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td align="right" style="padding: 5px; margin: 5px">
                                                                    In Rs. Lakhs
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtbuildingvalue" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Enabled="false" Height="28px" MaxLength="15" onkeypress="return inputOnlyNumbers(event)"
                                                                        OnTextChanged="txtbuildingvalue_TextChanged" TabIndex="1" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 15px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black; border-right: solid 1px black">
                                                                    c)
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" valign="top">
                                                                    <asp:Label ID="Label392" runat="server" CssClass="LBLBLACK">Value of Plant &amp; Machinery or Service Equipment<font 
                                color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="txtPlantvalueActual" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Height="28px" MaxLength="15" onkeypress="return inputOnlyNumbers(event)" OnTextChanged="txtPlantvalueActual_TextChanged"
                                                                        TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPlantvalueActual"
                                                                        ErrorMessage="Please enter Value of Plant" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td align="right" style="padding: 5px; margin: 5px">
                                                                    In Rs. Lakhs
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtPlantvalue" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Enabled="false" Height="28px" MaxLength="15" onkeypress="return inputOnlyNumbers(event)"
                                                                        OnTextChanged="txtPlantvalue_TextChanged" TabIndex="1" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-left: solid 1px black;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:Label ID="Label393" runat="server" CssClass="LBLBLACK">Total Project Cost(in Lakhs) <font 
                                color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:Label ID="txttotal" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="180px"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                        ControlToValidate="txttotal" ErrorMessage="Please enter Total Project"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="border-left: solid 1px black; padding: 5px; margin: 5px; border-top: solid 1px black;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr id="trentis" runat="server" visible="true">
                                                                <td style="border-left: solid 1px black; padding: 5px; margin: 5px; border-top: solid 1px black;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:Label ID="Label394" runat="server" CssClass="LBLBLACK" Width="165px">Your enterprise is</asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:Label ID="LblEnt_is" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Size="18px"
                                                                        Width="165px"></asp:Label>
                                                                    <asp:HiddenField ID="HdfLblEnt_is" runat="server" />
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" style="padding: 5px; margin: 5px; height: 25px; border-top: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </td>
                                        </tr>
                                        <tr id="trheading" runat="server" visible="false">
                                        <td> <asp:Label ID="lblheading" runat="server">Police Noc Details</asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        </tr>
                                         <tr id="trps" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" class="auto-style1">
                                        <tr id="trpolicedetails" runat="server">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr id="troccupancycertificatenumber" runat="server" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="200px">Commissionerate<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlcommissionerate" runat="server" class="form-control txtbox" AutoPostBack="true" 
                                                    Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlcommissionerate_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                        <tr id="trbuildingpermissiondate" runat="server" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Zone<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlzone" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlzone_SelectedIndexChanged"  >
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                        <tr id="troccupancycertificatedate" runat="server" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="200px">Division<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddldivision" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged"  >
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="200px">
                                                    Police Station
                                                    <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlpolicestation" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" >
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>

                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                &nbsp;</td>
                                        </tr>
                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                            </td>
                                            <td valign="top">
                                                <table cellpadding="4" cellspacing="5" class="auto-style2">
                                                    <tr id="trdrilldowns" runat="server" >
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="200px">Traffic Zone<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:DropDownList ID="ddltrafficzone" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddltrafficzone_SelectedIndexChanged" TabIndex="1" Width="180px">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                    </tr>
                                                    <tr id="trtrafficdivision0" runat="server">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label403" runat="server" CssClass="LBLBLACK" Width="200px">Traffic Division<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:DropDownList ID="ddltrafficdivision" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddltrafficdivision_SelectedIndexChanged" TabIndex="1" Width="180px">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                    </tr>
                                                    <tr id="tr13" runat="server">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label404" runat="server" CssClass="LBLBLACK" Width="200px">Traffic Police Station<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:DropDownList ID="ddltrafficpolicestation" runat="server" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                    Width="90px" />
                                                &nbsp;
                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                                &nbsp;
                                                <asp:Button ID="btnprevious" runat="server" CssClass="btn btn-danger" Height="32px"
                                                    OnClick="btnprevious_Click" TabIndex="10" Text="Previous" Visible="False" Width="90px" />
                                                &nbsp;
                                                <asp:Button ID="btnnext" runat="server" CssClass="btn btn-danger" Height="32px" OnClick="btnnext_Click"
                                                    TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" class="alert alert-success" visible="false">
                                                    <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                        ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                    <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:HiddenField ID="hdfID" runat="server" />
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="group" />
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="child" />
                                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                                                <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                                <asp:HiddenField ID="hdfFlagID1" runat="server" />
                                                <asp:HiddenField ID="hdfpencode" runat="server" />
                                            </td>
                                        </tr>
                                        </td> </tr>
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
        .auto-style1 {
            width: 70%;
        }
        .auto-style2 {
            width: 83%;
        }
    </style>
</asp:Content>
