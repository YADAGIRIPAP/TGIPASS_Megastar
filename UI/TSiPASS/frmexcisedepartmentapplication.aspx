<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmexcisedepartmentapplication.aspx.cs" Inherits="UI_TSiPASS_frmexcisedepartmentapplication" %>

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
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style5 {
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
        var d = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
        [1, 2, 3, 4, 0, 6, 7, 8, 9, 5],
        [2, 3, 4, 0, 1, 7, 8, 9, 5, 6],
        [3, 4, 0, 1, 2, 8, 9, 5, 6, 7],
        [4, 0, 1, 2, 3, 9, 5, 6, 7, 8],
        [5, 9, 8, 7, 6, 0, 4, 3, 2, 1],
        [6, 5, 9, 8, 7, 1, 0, 4, 3, 2],
        [7, 6, 5, 9, 8, 2, 1, 0, 4, 3],
        [8, 7, 6, 5, 9, 3, 2, 1, 0, 4],
        [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];
        // The permutation table
        var p = [
            [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 5, 7, 6, 2, 8, 3, 0, 9, 4],
            [5, 8, 0, 3, 7, 9, 6, 1, 4, 2],
            [8, 9, 1, 6, 0, 4, 3, 5, 2, 7],
            [9, 4, 5, 3, 1, 2, 6, 8, 7, 0],
            [4, 2, 8, 6, 5, 7, 3, 9, 0, 1],
            [2, 7, 9, 3, 8, 0, 6, 4, 1, 5],
            [7, 0, 4, 6, 9, 1, 3, 2, 5, 8]];
        // The inverse table
        var inv = [0, 4, 3, 2, 1, 5, 6, 7, 8, 9];
        /*
        * Converts a string to a reversed integer array.
        */
        function StringToReversedIntArray(num) {
            var myArray = [num.length];
            for (var i = 0; i < num.length; i++) {
                myArray[i] = (num.substring(i, i + 1));
            }
            myArray = Reverse(myArray);
            return myArray;
        }
        /*
        * Reverses an int array
        */
        function Reverse(myArray) {
            var reversed = [myArray.length];
            for (var i = 0; i < myArray.length; i++) {
                reversed[i] = myArray[myArray.length - (i + 1)];
            }
            return reversed;
        }

        function ValidatePAN() {
            var Obj = document.getElementById("txtcontact0");
            if (Obj.value != "") {
                ObjVal = Obj.value;
                var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
                if (ObjVal.search(panPat) == -1) {
                    alert("Invalid Pan No");
                    Obj.focus();
                    return false;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function CharnumOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphanumeric Only");
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
    <script type="text/javascript">
        function alpha(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <span>' + message + '</span></div>');

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
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">Department of Excise</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Grant of Liquor (A4) Shop License for excise </a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">&nbsp;Grant of Liquor (A4) Shop License for excise</h3>
                    </div>
                    <div class="col-md-12">
                        <h1 class="page-head-line" align="left" style="font-size: x-large">Grant of Liquor (A4) Shop License for excise</h1>
                    </div>
                    <div class="panel-body" align="left">
                        <table align="left" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                    <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">Details of  Shop Applied For </asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 70%">
                                        <asp:HiddenField ID="hf_exciseliquorid" runat="server" />
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="210px">Gazette Serial No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_gazetteserialno" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_gazetteserialno"
                                                    ErrorMessage="Please enter Gazette Seria1 No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label47" runat="server" CssClass="LBLBLACK" Width="239px">Location<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_Location" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Location"
                                                    ErrorMessage="Please enter txt_Location" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label75" runat="server" CssClass="LBLBLACK" Width="210px">Excise Station<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_ExciseStation" onkeypress="Names()" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txt_ExciseStation"
                                                    ErrorMessage="Please enter Excise Station" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Excise District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddl_excisedistrict" runat="server" class="form-control txtbox" 
                                                    Height="33px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_excisedistrict"
                                                    ErrorMessage="Please selectDistrict" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label77" runat="server" CssClass="LBLBLACK" Width="210px">Retail Excise Tax Slab per year(Rs.in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_RetailExciseTaxSlabperyearinLakhs" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txt_RetailExciseTaxSlabperyearinLakhs"
                                                    ErrorMessage="Please enter Retail Excise Tax Slab per year(Rs.in Lakhs)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:Label ID="Label82" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">APPLICANT’S DETAILS:</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label79" runat="server" CssClass="LBLBLACK" Width="210px">Name:(Mr/Mrs/Ms.) <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_applicantname" onkeypress="Names()" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txt_applicantname"
                                                    ErrorMessage="Please enter Name:(Mr/Mrs/Ms.)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label81" runat="server" CssClass="LBLBLACK" Width="239px">Father/Husband Name: <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_applicantfathusname" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txt_applicantfathusname"
                                                    ErrorMessage="Please enter Father/Husband Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">8a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label83" runat="server" CssClass="LBLBLACK" Width="239px">Date of Birth<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_applicantdateofbirth" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txt_applicantdateofbirth"
                                                    ErrorMessage="Please enter Date of Birth" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">8b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label84" runat="server" CssClass="LBLBLACK" Width="239px">Age on 29.11.2019 <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_applicantage" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txt_applicantage"
                                                    ErrorMessage="Please enter Age on 29.11.2019" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:Label ID="Label85" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">ADDRESS </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">9a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label87" runat="server" CssClass="LBLBLACK" Width="239px">House No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_HouseNo" runat="server" class="form-control txtbox" 
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txt_HouseNo"
                                                    ErrorMessage="Please enter House No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">9b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label88" runat="server" CssClass="LBLBLACK" Width="239px">Road/Street/Locality<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_RoadStreetLocality" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txt_RoadStreetLocality"
                                                    ErrorMessage="Please enter Road/Street/Locality" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">9c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label89" runat="server" CssClass="LBLBLACK" Width="239px">Pincode<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_pincode" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txt_pincode"
                                                    ErrorMessage="Please enter Name of the Owner/Director/Partner" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">9d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label90" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddl_district" runat="server" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged"
                                                    Height="33px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddl_district"
                                                    ErrorMessage="Please selectDistrict" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">9e.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label91" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddl_mandal" runat="server" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_mandal_SelectedIndexChanged"
                                                    Height="33px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="ddl_mandal"
                                                    ErrorMessage="Please select Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">9f.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label92" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddl_village" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddl_village"
                                                    ErrorMessage="Please select type of agency" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">10a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="165px">Mobile No1.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_mobileno1" onkeypress="NumberOnly()" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_mobileno1"
                                                    ErrorMessage="Please enter Mobile Number 1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">10b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label86" runat="server" CssClass="LBLBLACK" Width="165px">Mobile No2.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_mobileno2" onkeypress="NumberOnly()" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txt_mobileno2"
                                                    ErrorMessage="Please enter Mobile Number 2" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">10C.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label49" runat="server" CssClass="LBLBLACK" Width="165px">Email ID.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_emailid" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_emailid"
                                                    ErrorMessage="Please enter Email ID" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_emailid"
                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:Label ID="Label93" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">IF PARTNERSHIP FIRM/ COMPANY:</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">11a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label94" runat="server" CssClass="LBLBLACK" Width="239px">Name of the firm/company<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_Nameofthefirmcompany" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txt_Nameofthefirmcompany"
                                                    ErrorMessage="Please enter Name of the firm/company" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">11b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label95" runat="server" CssClass="LBLBLACK" Width="239px">Registration No: <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_RegistrationNo" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txt_RegistrationNo"
                                                    ErrorMessage="Please enter Registration No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">11C.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label96" runat="server" CssClass="LBLBLACK" Width="239px">Registration Date <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_RegistrationDate" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txt_RegistrationDate"
                                                    ErrorMessage="Please enter Registration Date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">11d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label97" runat="server" CssClass="LBLBLACK" Width="239px">GSTIN<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_gstin" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txt_gstin"
                                                    ErrorMessage="Please enter GSTIN" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:Label ID="Label98" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">IDENTIFICATION DETAILS:</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                            </td>
                                        </tr>

                                        <tr runat="server">
                                            <td style="padding: 5px; margin: 5px">12a.
                                            </td>
                                            <td class="auto-style4">PAN No.<span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtPanFinacial" runat="server" class="form-control txtbox" Height="28px" onblur="fnValidatePAN(this);"
                                                    MaxLength="10" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtPanFinacial" runat="server" ControlToValidate="txtPanFinacial"
                                                    ErrorMessage="Please enter Pan Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">12b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label50" runat="server" CssClass="LBLBLACK" Width="165px">Aadhaar No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_adharno" autocomplete="off" Height="28px" onkeypress="NumberOnly()" TabIndex="1" onpaste="return false"
                                                    runat="server" class="form-control txtbox" MaxLength="16" Width="56px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: left;" class="auto-style1">a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label53" runat="server" CssClass="LBLBLACK" Width="321px">
                                                    Self certified copy of Local Tribe Certificate (only in case Agency Area A4 Shops)
                                                    <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rd_certificatea4" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="rd_certificatea4_SelectedIndexChanged"
                                                    Height="33px" Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Selected="True" Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                        </tr>

                                    </table>
                                </td>


                            </tr>
                            <tr runat="server" id="trUploads" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 70%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label56" runat="server" CssClass="LBLBLACK" Width="300px"><b>Documents Required to Upload</b><font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">**</td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label80" runat="server" CssClass="LBLBLACK" Width="200px">Passport Size Photo</asp:Label>
                                            </td>
                                            <td class="auto-style5" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupPhoto" runat="server" />
                                                <asp:HyperLink ID="HyperLinkfupPhoto" Visible="false" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblfupPhoto" runat="server" ForeColor="Red" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnfupPhoto" CssClass="btn btn-success" runat="server" Text="Upload"  OnClick="btnfupPhoto_Click" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">**</td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="312px">Pan Card</asp:Label>
                                            </td>
                                            <td class="auto-style5" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fuppancardDoc" runat="server" />
                                                <asp:HyperLink ID="HyperLinkpancardDoc" Visible="False" runat="server" CssClass="LBLBLACK" Width="149px"
                                                    Target="_blank" NavigateUrl="#">[HyperLinkpancardDoc]</asp:HyperLink>
                                                <asp:Label ID="lblpancardDoc" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnpancardDoc" CssClass="btn btn-success" runat="server" Text="Upload" OnClick="btnpancardDoc_Click" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">**</td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="200px">Aadhar Card</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupAadharCardDoc" runat="server" />
                                                <asp:HyperLink ID="HyperLinkAadharCardDoc" Visible="False" runat="server" CssClass="LBLBLACK" Width="182px"
                                                    Target="_blank" NavigateUrl="#">[HyperLinkAadharCardDoc]</asp:HyperLink>
                                                <asp:Label ID="lblAadharCardDoc" runat="server" ForeColor="Red" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnAadharCardDoc" CssClass="btn btn-success" runat="server" Text="Upload"  OnClick="btnAadharCardDoc_Click" />

                                            </td>
                                        </tr>
                                        <tr  runat="server" id="trcertdoc" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">**</td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="200px">Self certified copy of Local Tribe Certificate (only in case Agency Area A4 Shcps) </asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupEncloseAuditorsCertificate" runat="server" />
                                                <asp:HyperLink ID="HyperLinkfupEncloseAuditorsCertificate" Visible="false" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblfupEncloseAuditorsCertificate" runat="server" ForeColor="Red" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnfupEncloseAuditorsCertificate" CssClass="btn btn-success" runat="server" Text="Upload" OnClick="btnfupEncloseAuditorsCertificate_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Visible="false"
                                        Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" OnClick="BtnClear_Click"
                                        Width="90px" />&nbsp;
                                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    Text="Save" OnClick="BtnSave_Click" Width="90px" ValidationGroup="group"  />
                                    &nbsp;
                                                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px" Visible="false"
                                                    TabIndex="10" Text="Payment" Width="90px" ValidationGroup="group"  OnClick="btnNext_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <div class="messagealert" id="alert_container"></div>
                            </tr>

                            <tr>
                                <td colspan="10">
                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="child" />
                                    
                                   

                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
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

            $("input[id$='txt_applicantdateofbirth']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $("input[name='rbtregisteredwithanyTourismDepartment']").change(function () {
            debugger;
            var status = $(this).val();
            if (status == 0) {
                $(".divEnclosedDoc").show();
            } else {
                $(".divEnclosedDoc").hide();
            }
        });
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txt_RegistrationDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }

        .auto-style1 {
            width: 18px;
        }

        .auto-style2 {
            color: #555555;
            background-color: #FFFFFF;
        }

        .auto-style4 {
            width: 277px;
        }

        .auto-style5 {
            width: 226px;
        }
    </style>


</asp:Content>

