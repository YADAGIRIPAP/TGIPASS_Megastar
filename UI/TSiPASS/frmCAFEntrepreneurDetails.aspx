<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmCAFEntrepreneurDetails.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
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
        .style6
        {
            height: 34px;
        }
        .style7
        {
            width: 42px;
        }
        .style8
        {
            height: 34px;
            width: 42px;
        }
        .style10
        {
            width: 9px;
        }
        .style11
        {
            width: 210px;
        }
        .style12
        {
            width: 199px;
        }
        .style13
        {
            width: 13px;
        }
        .auto-style2 {
            width: 241px;
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
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Entrepreneur Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="280px">Location of the Unit</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label454" runat="server" CssClass="LBLBLACK" Width="200px">Survey No/Plot Number(s)<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtSurveyNo" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="100" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtSurveyNo"
                                                                    ErrorMessage="Please enter Location Survey/Plot/Door Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                2
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label453" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlLand_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                    Height="33px" OnSelectedIndexChanged="ddlLand_intDistrictid_SelectedIndexChanged"
                                                                    TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlLand_intDistrictid"
                                                                    ErrorMessage="Please Select Location District" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlLand_intMandalid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                    Height="33px" OnSelectedIndexChanged="ddlLand_intMandalid_SelectedIndexChanged"
                                                                    TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlLand_intMandalid"
                                                                    ErrorMessage="Please Select Location Mandal" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                4
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="165px">Village/Town<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlLand_intVillageid" runat="server" class="form-control txtbox"
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlLand_intVillageid"
                                                                    ErrorMessage="Please Select Location Village" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                5
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="165px">Street Name<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtName_Gramapachayat" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtName_Gramapachayat"
                                                                    ErrorMessage="Please enter Location Steet Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp; 6
                                                            </td>
                                                            <td style="width: 200px;">
                                                                &nbsp;
                                                                <asp:Label ID="Label449" runat="server" CssClass="LBLBLACK" Width="165px">PinCode<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:TextBox ID="txtLand_Pincode" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="6" onblur="checkLength(this)" onkeypress="NumberOnly()" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtLand_Pincode"
                                                                    ErrorMessage="Please enter Location Pincode" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:Label ID="lblNameandAddressofPromoter" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="580px">Name Address of the Promoter/Industrial undertaking in full(BLOCK LETTERS)</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblNameofIndus" runat="server" CssClass="LBLBLACK" Width="210px"><font 
                                                            color="Red">*</font>Name of Industrial Undertaking </asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtNameOfIndustrialUndertaking" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="60" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNameOfIndustrialUndertaking"
                                                                    ErrorMessage="Please enter Industries Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                2
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="210px"><font 
                                                            color="Red">*</font>Name of Promoter /M.D./Mg. Partner with surname first</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtNameOfPromoter" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"
                                                                    OnTextChanged="txtcontact7_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNameOfPromoter"
                                                                    ErrorMessage="Please enter Name of Promoter" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="200px"><font 
                                                            color="Red">*</font>S/o.D/o.W/o</asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtSonOfDOWO" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSonOfDOWO"
                                                                    ErrorMessage="Please enter  S/O name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style2">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                4
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="150px"><font 
                                                            color="Red">*</font>Age </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtage" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="2" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtage"
                                                                    ErrorMessage="Please enter  Age" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                5
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="150px"><font 
                                                            color="Red">*</font>Occupation </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtOccupation" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOccupation"
                                                                    ErrorMessage="Please enter  Occupation" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
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
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                    <asp:Label ID="Label426" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Address for Communication</asp:Label>
                                                </td>
                                                <td class="auto-style2">
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
                                                            <td style="padding: 5px; margin: 5px">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                                <asp:Label ID="Label428" runat="server" CssClass="LBLBLACK" Width="210px">Door No</asp:Label>
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcontact35_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDoorNo"
                                                                    ErrorMessage="Please enter  Door Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                                Landmark
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtLandmark" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtLandmark"
                                                                    ErrorMessage="Please enter  land Marks" TabIndex="1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                                State
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlState" runat="server" class="form-control txtbox" Height="33px"
                                                                    Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlState"
                                                                    ErrorMessage="Please select State" TabIndex="1" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="dist1" visible="false" runat="server">
                                                            <td style="padding: 5px; margin: 5px">
                                                                4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                                District
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox" Height="33px"
                                                                    Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlDistrict"
                                                                    ErrorMessage="Please select district" InitialValue="--Select--" TabIndex="1"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="dist" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px">
                                                                4
                                                            </td>
                                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                                District
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px">
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
                                                        <tr id="mandal1" visible="false" runat="server">
                                                            <td style="padding: 5px; margin: 5px">
                                                                5
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                                Mandal
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                                                                    Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlMandal"
                                                                    ErrorMessage="Please Select Mandal" InitialValue="--Select--" TabIndex="1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="mandal" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px">
                                                                5
                                                            </td>
                                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                                Mandal
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px">
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
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                6
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                                Telephone(Incl STD Code)
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtTelephone" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="11" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtTelephone"
                                                                    ErrorMessage="Please enter  telephone" TabIndex="1" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                7
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                                Nature of Organisation
                                                            </td>
                                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlNatureofOrg" runat="server" class="form-control txtbox"
                                                                    TabIndex="1" Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlNatureofOrg"
                                                                    ErrorMessage="Please enter  nature of Organization" InitialValue="--Select--"
                                                                    TabIndex="1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style2">
                                                    &nbsp;
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;8
                                                            </td>
                                                            <td style="width: 200px;">
                                                                Street Name
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtStreetName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr id="vill1" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                9
                                                            </td>
                                                            <td style="width: 200px;" valign="middle">
                                                                Village/Town
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control txtbox" TabIndex="1"
                                                                    Height="33px" Width="180px" AutoPostBack="True">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlVillage"
                                                                    ErrorMessage="Please select Village" InitialValue="--Select--" TabIndex="1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="Vill" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px">
                                                                9
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                Village
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
                                                        <tr id="trpwd0" runat="server">
                                                            <td style="padding: 5px; margin: 5px">
                                                                10
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" Width="150px">Email</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="100" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server"
                                                                ControlToValidate="txtEmail" ErrorMessage="Please Enter Email"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr3" runat="server">
                                                            <td style="padding: 5px; margin: 5px">
                                                                11
                                                            </td>
                                                            <td style="width: 200px;">
                                                                Fax
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtFax" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr id="tr4" runat="server">
                                                            <td style="padding: 5px; margin: 5px">
                                                                12
                                                            </td>
                                                            <td style="width: 200px;">
                                                                Mobile Number
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtMobileNo" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtMobileNo"
                                                                    ErrorMessage="Please enter  Mobile Number" TabIndex="1" ValidationGroup="group" Visible="true">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trdiffable">
                                                            <td style="padding: 5px; margin: 5px">
                                                                13
                                                            </td>
                                                            <td style="width: 200px;">
                                                                Differently abled<span class="style5">*</span>
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
                                                                14
                                                            </td>
                                                            <td style="width: 200px;">
                                                                Women entrepreneur <span class="style5">*</span>
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
                                                                15
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
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label427" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Registration Particulars</asp:Label>
                                                </td>
                                                <td class="auto-style2">
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
                                                            <td style="padding: 5px; margin: 5px">
                                                                1
                                                            </td>
                                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                                Category Of Registration
                                                            </td>
                                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlCateORg" runat="server" class="form-control txtbox" TabIndex="1"
                                                                    Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlCateORg"
                                                                    ErrorMessage="Please Select Category" InitialValue="--Select--" TabIndex="1"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                2
                                                            </td>
                                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="210px">Registration Number</asp:Label>
                                                            </td>
                                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtRegNo" runat="server" class="form-control txtbox" oncopy="return false"
                                                                    onpaste="return false" oncut="return false" Height="28px" MaxLength="25" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtRegNo"
                                                                    ErrorMessage="Please enter RegNo" TabIndex="1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                3
                                                            </td>
                                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                                Registration Expiry Date
                                                            </td>
                                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtRegExpDate" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <%--<cc1:CalendarExtender
                                                                        ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy" PopupButtonID="txtRegExpDate"
                                                                        TargetControlID="txtRegExpDate">
                                                                    </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtRegExpDate"
                                                                    ErrorMessage="Please enter Reg Expiry date" TabIndex="1" ValidationGroup="group"
                                                                    Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style2">
                                                    &nbsp;
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                4
                                                            </td>
                                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="200px">select Registration Date(DD-MMM-YYYY)</asp:Label>
                                                            </td>
                                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtRegDate" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <%--<cc1:CalendarExtender
                                                                        ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" PopupButtonID="txtRegDate"
                                                                        TargetControlID="txtRegDate">
                                                                    </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtRegDate"
                                                                    ErrorMessage="Please enter Registration date" TabIndex="1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                5
                                                            </td>
                                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="200px">Type of Project</asp:Label>
                                                            </td>
                                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlProject" runat="server" class="form-control txtbox" TabIndex="1"
                                                                    Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">New</asp:ListItem>
                                                                    <asp:ListItem Value="2">Expansion</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlProject"
                                                                    ErrorMessage="Please Select Type of Project" TabIndex="1" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Employment Details</asp:Label>
                                                </td>
                                                <td class="auto-style2">
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
                                                                <asp:Label ID="Label409" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="165px">Adults (above 18 
                                                        Yrs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Label>
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
                                                            <td style="vertical-align: top;">
                                                                1
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Male<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                :
                                                            </td>
                                                            <td style="vertical-align: top;" valign="top">
                                                                <asp:TextBox ID="txtAdultMale" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                                    MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox><asp:RangeValidator ID="AdultMale" runat="server" ErrorMessage="Age must be above 18 years"
                                                                        ControlToValidate="txtAdultMale" ForeColor="Red" MinimumValue="18" MaximumValue="99"
                                                                        Type="Integer"></asp:RangeValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtAdultMale"
    ErrorMessage="Please Enter Adults-male employee count" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                2
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="165px">Female<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                :
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                <asp:TextBox ID="txtAdultFemale" runat="server" class="form-control txtbox" Height="28px"  oncopy="return false" onpaste="return false" oncut="return false"
                                                                    MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox><asp:RangeValidator ID="AdultFemale" runat="server" ErrorMessage="Age must be above 18 years" 
                                                                        ControlToValidate="txtAdultFemale" ForeColor="Red" MinimumValue="18" MaximumValue="99"
                                                                        Type="Integer"></asp:RangeValidator>
                                                                                                                           
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtAdultFemale"
ErrorMessage="Please Enter Adults-female employee count" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                3
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">Transgender<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                :
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                <asp:TextBox ID="TXTTRANSADULTS" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Age must be above 18 years"
                                                                        ControlToValidate="TXTTRANSADULTS" ForeColor="Red" MinimumValue="18" MaximumValue="99"
                                                                        Type="Integer"></asp:RangeValidator>
                                                                                                                            
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="TXTTRANSADULTS"
ErrorMessage="Please Enter Adults-transgender employee count" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: top;" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                <asp:Label ID="Label410" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="165px">Adolescents (15-18 
                                                        Yrs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                <asp:Label ID="Label411" runat="server" CssClass="LBLBLACK" Width="165px">Male<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtAdoleMale" runat="server" class="form-control txtbox" Height="28px"  oncopy="return false" onpaste="return false" oncut="return false"
                                                                    MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox><asp:RangeValidator ID="AdoleMale" runat="server" ErrorMessage="Age must be 15-18 years"
                                                                        ControlToValidate="txtAdoleMale" ForeColor="Red" MinimumValue="15" MaximumValue="18"
                                                                        Type="Integer"></asp:RangeValidator>                                                           
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtAdoleMale"
ErrorMessage="Please Enter adolescents-male employee count" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                5
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                <asp:Label ID="Label412" runat="server" CssClass="LBLBLACK" Width="165px">Female<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtAdoleFemale" runat="server" class="form-control txtbox" Height="28px"  oncopy="return false" onpaste="return false" oncut="return false" 
                                                                    MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox><asp:RangeValidator ID="AdoleFemale" runat="server" ErrorMessage="Age must be 15-18 years"
                                                                        ControlToValidate="txtAdoleFemale" ForeColor="Red" MinimumValue="15" MaximumValue="18"
                                                                        Type="Integer"></asp:RangeValidator>                                                          
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtAdoleFemale"
ErrorMessage="Please Enter adolescents-female employee count" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                6
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Transgender<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TXTTRANSADOLESCENTS" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox><asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Age must be 15-18 years"
                                                                        ControlToValidate="TXTTRANSADOLESCENTS" ForeColor="Red" MinimumValue="15" MaximumValue="18"
                                                                        Type="Integer"></asp:RangeValidator>                                                          
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="TXTTRANSADOLESCENTS"
ErrorMessage="Please Enter adolescents-Transgender employee count" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style2">
                                                    &nbsp;
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="165px">Children (14-15 
                                                        Yrs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
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
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                7
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="165px">Male<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                <asp:TextBox ID="txtChildMale" runat="server" class="form-control txtbox" Height="28px"  oncopy="return false" onpaste="return false" oncut="return false"
                                                                    MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox><asp:RangeValidator ID="ChildMale" runat="server" ErrorMessage="Age must be 14-15 years"
                                                                        ControlToValidate="txtChildMale" ForeColor="Red" MinimumValue="14" MaximumValue="15"
                                                                        Type="Integer"></asp:RangeValidator>                                                          
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="txtChildMale"
ErrorMessage="Please Enter children-male employee count" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                8
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="165px">Female<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                <asp:TextBox ID="txtChildFemale" runat="server" class="form-control txtbox" Height="28px"  oncopy="return false" onpaste="return false" oncut="return false"
                                                                    MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox><asp:RangeValidator ID="ChildFemale" runat="server" ErrorMessage="Age must be 14-15 years"
                                                                        ControlToValidate="txtChildFemale" ForeColor="Red" MinimumValue="14" MaximumValue="15"
                                                                        Type="Integer"></asp:RangeValidator>                                                           
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="txtChildFemale"
ErrorMessage="Please Enter children- female employee count" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                9
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">Transgender<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;">
                                                                <asp:TextBox ID="TXTTRANSCHILDREN" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="4" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox><asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Age must be 14-15 years"
                                                                        ControlToValidate="TXTTRANSCHILDREN" ForeColor="Red" MinimumValue="14" MaximumValue="15"
                                                                        Type="Integer"></asp:RangeValidator>                                                           
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="TXTTRANSCHILDREN"
ErrorMessage="Please Enter children -Transgender employee count" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Other Details</asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    &nbsp;
                                                </td>
                                                <td valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr valign="top" runat="server" id="tr2">
                                                            <td style="padding: 5px; margin: 5px">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="180px">Height of the building(in Meters)<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TxtHight_Build" runat="server" class="form-control txtbox" Height="28px"  onkeypress="NumberOnly()"   oncopy="return false" onpaste="return false" oncut="return false" 
                                                                    MaxLength="20" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtHight_Build"
                                                                    ErrorMessage="Please Enter Height of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style2">
                                                    &nbsp;
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr valign="top" runat="server" id="tr1">
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="180px">Built up Area (Including Parking Cellars)<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TxtBuilt_up_Area" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="6" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                Square Meters
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TxtBuilt_up_Area"
                                                                    ErrorMessage="Please Enter Built up Area (Including Parking Cellars)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trheading" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">POLICE NOC DEtails</asp:Label>
                                                </td>
                                                <td class="auto-style2">
                                                    &nbsp;
                                                </td>
                                                <td valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="trpolicedetails" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                                          <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                              <tr id="troccupancycertificatenumber" runat="server">
                                                                                  <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                                                                  <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                      <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="200px">Commissionerate<font 
                                                            color="red">*</font></asp:Label>
                                                                                  </td>
                                                                                  <td style="padding: 5px; margin: 5px">:</td>
                                                                                  <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                                      <asp:DropDownList ID="ddlcommissionerate" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlcommissionerate_SelectedIndexChanged" TabIndex="1" Width="180px">
                                                                                          <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                      </asp:DropDownList>
                                                                                  </td>
                                                                                  <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                                              </tr>
                                                                              <tr id="trbuildingpermissiondate" runat="server">
                                                                                  <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                                                                  <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                      <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Zone<font 
                                                            color="red">*</font></asp:Label>
                                                                                  </td>
                                                                                  <td style="padding: 5px; margin: 5px">:</td>
                                                                                  <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                                      <asp:DropDownList ID="ddlzone" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlzone_SelectedIndexChanged" TabIndex="1" Width="180px">
                                                                                          <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                      </asp:DropDownList>
                                                                                  </td>
                                                                                  <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                                              </tr>
                                                                              <tr id="troccupancycertificatedate" runat="server">
                                                                                  <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                                                                  <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                      <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="200px">Division<font 
                                                            color="red">*</font></asp:Label>
                                                                                  </td>
                                                                                  <td style="padding: 5px; margin: 5px">:</td>
                                                                                  <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                                      <asp:DropDownList ID="ddldivision" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged" TabIndex="1" Width="180px">
                                                                                          <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                      </asp:DropDownList>
                                                                                  </td>
                                                                                  <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
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
                                                                                      <asp:DropDownList ID="ddlpolicestation" runat="server" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                                                          <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                      </asp:DropDownList>
                                                                                  </td>
                                                                                  <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                                              </tr>
                                                                          </table>
                                                                      </td>
                                                <td class="auto-style2">
                                                    &nbsp;
                                                </td>
                                               <td valign="top" >
                                                                     <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                         
                                                                          <tr id="trplotorsitedocumentno" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="200px">Traffic Zone<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddltrafficzone" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddltrafficzone_SelectedIndexChanged"  >
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                        <tr id="trtrafficdivision" runat="server" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="200px">Traffic Division<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddltrafficdivision" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddltrafficdivision_SelectedIndexChanged"  >
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                        <tr id="tr12" runat="server" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="200px">Traffic Police Station<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddltrafficpolicestation" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                                     </table>
                                                                 </td>
                                            </tr>
                                            <tr id="tr5" runat="server"  >
                                                 <td style="padding: 5px; margin: 5px" valign="top">
                                                     <table align="center" cellpadding="4" cellspacing="5" style="width: 83%">
                                                 <tr>
                                                     <%--<td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" align="center" colspan="9">Employment
                                                                            </td>--%>
                                                     <td align="left"  style="background: white; color: black; font-weight: bold; width: 100px; height: 30px">Employment </td>
                                                 </tr>
                                                 <tr>
                                                     <td align="center" style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 30px;">Sl.No </td>
                                                     <td align="center" style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 250px;">Cadare </td>
                                                     <td align="left" style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 200px;">Male(Nos) </td>
                                                     <td align="left" style="border: solid thin white; background: #013161; color: white; border: solid thin black; width: 100px;">Female(Nos) </td>
                                                     <td align="left" style="border: solid thin white; background: #013161; color: white; border: solid thin black; width: 100px;">Qualification </td>
                                                     <td align="left" style="border: solid thin white; background: #013161; color: white; border: solid thin black; width: 100px;">Others(Qualification) </td>
                                                 </tr>
                                                 <tr>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 20px;">1 </td>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 250px;">Management &amp; Staff </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtstaffMale" runat="server" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtstaffMale" Display="None" ErrorMessage="Please Enter Number of Male Staff" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtfemale" runat="server" class="txtalignright" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtfemale" Display="None" ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:DropDownList ID="ddlManagementandStaffQualification" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlManagementandStaffQualification_SelectedIndexChanged" TabIndex="1" Width="100px">
                                                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                         </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="ddlManagementandStaffQualification"
                                                                    ErrorMessage="Please select ManagementorStaffQuaification" TabIndex="1" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtmngmntstaffqualificationother" runat="server" onkeypress="Names()" class="txtalignright" Enabled="false" Height="28px" TabIndex="5" Width="100px"></asp:TextBox>
                                                         
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 20px;">2 </td>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 250px;">Supervisory </td>
                                                     <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                         <asp:TextBox ID="txtsupermalecount" runat="server" align="center" class="txtalignright" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtsupermalecount" Display="None" ErrorMessage="Please Enter Number of Supervisory Male" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtsuperfemalecount" runat="server" class="txtalignright" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtsuperfemalecount" Display="None" ErrorMessage="Please Enter Number of Supervisory FeMale" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:DropDownList ID="ddlSupervisor" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlSupervisor_SelectedIndexChanged" TabIndex="1" Width="100px">
                                                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                         </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="ddlSupervisor"
                                                                    ErrorMessage="Please select Supervisor Qualification" TabIndex="1" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtsupervisorqualificationother" runat="server" onkeypress="Names()" class="txtalignright" Enabled="false" Height="28px" TabIndex="5" Width="100px"></asp:TextBox>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 20px;">3 </td>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 250px;">Skilled workers </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtSkilledWorkersMale" runat="server" class="txtalignright" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtSkilledWorkersMale" Display="None" ErrorMessage="Please Enter Number of Skilled workers Male" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtSkilledWorkersFemale" runat="server" class="txtalignright" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtSkilledWorkersFemale" Display="None" ErrorMessage="Please Enter Number of Skilled workers FeMale" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:DropDownList ID="ddlskilledworkers" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlskilledworkers_SelectedIndexChanged" TabIndex="1" Width="100px">
                                                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                         </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="ddlskilledworkers"
                                                                    ErrorMessage="Please select Skilled workers Qualification" TabIndex="1" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtskilledworkerqualother" runat="server" onkeypress="Names()" class="txtalignright" Enabled="false" Height="28px" TabIndex="5" Width="100px"></asp:TextBox>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 20px;">4 </td>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 100px;">Semi-skilled workers </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtSemiSkilledWorkersMale" runat="server" class="txtalignright" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtSemiSkilledWorkersMale" Display="None" ErrorMessage="Please Enter Number of Semi-skilled workers Male" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtSemiSkilledWorkersFemale" runat="server" class="txtalignright" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtSemiSkilledWorkersFemale" Display="None" ErrorMessage="Please Enter Number of Semi-skilled workers FeMale" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:DropDownList ID="ddlsemiskilledworkers" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlsemiskilledworkers_SelectedIndexChanged" TabIndex="1" Width="100px">
                                                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                         </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddlsemiskilledworkers"
                                                                    ErrorMessage="Please select Semi Skilled workers Qualification" TabIndex="1" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtsemiskilledworkerqualother" runat="server" onkeypress="Names()" class="txtalignright" Enabled="false" Height="28px" TabIndex="5" Width="100px"></asp:TextBox>
                                                     </td>
                                                 </tr>
                                                 <tr>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 20px;">5 </td>
                                                     <td style="padding: 5px; margin: 5px; text-align: center; border: solid thin black; width: 100px;">Un-skilled workers </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="TXTUNSKILLEDWORKERMALE" runat="server" class="txtalignright" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="TXTUNSKILLEDWORKERMALE" Display="None" ErrorMessage="Please Enter Number of Un-skilled workers Male" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="TXTUNSKILLEDWORKERFEMALE" runat="server" class="txtalignright" Height="28px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" Width="100px"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="TXTUNSKILLEDWORKERFEMALE" Display="None" ErrorMessage="Please Enter Number of Semi-skilled workers FeMale" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:DropDownList ID="ddlunskilledworkers" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlunskilledworkers_SelectedIndexChanged" TabIndex="1" Width="100px">
                                                             <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                         </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="ddlunskilledworkers"
                                                                    ErrorMessage="Please select UnskilledworkersQualification" TabIndex="1" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                     </td>
                                                     <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 100px;">
                                                         <asp:TextBox ID="txtunskilledworkersqualother" runat="server" onkeypress="Names()" class="txtalignright" Enabled="false" Height="28px" TabIndex="5" Width="100px"></asp:TextBox>
                                                     </td>
                                                 </tr>
                                            </table>
                                                     </td>
                                                 <td class="auto-style2">
                                                    &nbsp;
                                                </td>
                                                 <td valign="top" >
                                                     </td>
                                                    </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                    &nbsp;</td>
                                                <td class="auto-style2">
                                                    &nbsp;
                                                </td>
                                                <td valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
    


                                                              
                                                                       

                                                                  <tr>
                                                                      
                                                                      <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                                          <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                                                          &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />
                                                                          &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                                      </td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                                          <div id="success" runat="server" class="alert alert-success" visible="false">
                                                                              <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                                          </div>
                                                                          <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                                              <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                                              <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                                          </div>
                                                                      </td>
                                                                  </tr>
                                                                  <asp:HiddenField ID="hdfID" runat="server" />
                                                                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                                                  <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                                                  <asp:HiddenField ID="hdfFlagID" runat="server" />
                                                                  <asp:HiddenField ID="HDNDATEOFPAYMENT" runat="server" />

    <asp:HiddenField ID="HDNAPPLNSTATUS" runat="server" />

                                                          


                                        </table>
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

            $("input[id$='txtRegExpDate']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
             $("input[id$='txtRegDate']").datepicker(
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
            $("input[id$='txtRegExpDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
             $("input[id$='txtRegDate']").datepicker(
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
