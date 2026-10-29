<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frm_Renewalcelltower.aspx.cs" Inherits="UI_TSiPASS_frm_Renewalcelltower" %>

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

</script>
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
            <li class=""><i class="fa fa-fw fa-edit">Renewal</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Cell Tower</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">&nbsp;APPLICATION FOR RENEWAL CELL TOWER</h3>
                    </div>
                    <div class="col-md-12">
                        <h1 class="page-head-line" align="left" style="font-size: x-large">APPLICATION FOR RENEWAL CELL TOWER</h1>
                    </div>
                    <div class="panel-body" align="left">
                        <table align="left" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 70%" runat="server" id="div_prdview">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:        
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddl_prddistricts" AutoPostBack="true" OnSelectedIndexChanged="ddl_prddistricts_SelectedIndexChanged" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_prddistricts"
                                                    ErrorMessage="Please select Districts" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="210px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:        
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddl_prdmandal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_prdmandal_SelectedIndexChanged" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_prdmandal"
                                                    ErrorMessage="Please select Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="210px">Gram panchayat<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:        
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddl_prdgrampanchayat" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddl_prdgrampanchayat"
                                                    ErrorMessage="Please select Gram Panchayat" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="239px">Enter Trade License No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt_prdtradelicenseno" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvNameOFtheOwner" runat="server" ControlToValidate="txt_prdtradelicenseno"
                                                    ErrorMessage="Please enter Enter Trade License No." ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label47" runat="server" CssClass="LBLBLACK" Width="210px">Trade License Year<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:        
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddl_tradelicenseyear" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddl_tradelicenseyear"
                                                    ErrorMessage="Please select Trade License Year" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="btn_clear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" TabIndex="10"  Text="ClearAll" ToolTip="To Clear  the Screen" OnClick="btn_clear_Click"
                                                    Width="90px" />&nbsp;
                                                <asp:Button ID="btn_getrenewaldetails" CausesValidation="false" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    Text="Save" OnClick="btn_getrenewaldetails_Click" Width="90px" ValidationGroup="group" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="div_prddetails">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 70%" title="Cell Tower Application">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="210px">Cell Tower License Number<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:        
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdcelltowerlice" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_prdcelltowerlice"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label59" runat="server" CssClass="LBLBLACK" Width="210px">Cell Tower For<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdcelltowerfor" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="2" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txt_prdcelltowerfor"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label53" runat="server" CssClass="LBLBLACK" Width="210px">Trade.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdtrade" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="3" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_prdtrade"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label54" runat="server" CssClass="LBLBLACK" Width="210px">Sub Trade.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdsubtrade" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="4" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_prdsubtrade"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label55" runat="server" CssClass="LBLBLACK" Width="210px">Name of Firm/ Shop/ Business/ Establishment.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdnameoffirm" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_prdnameoffirm"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label57" runat="server" CssClass="LBLBLACK" Width="210px">Annual License Fee in Rs.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdannuallicensefee" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_prdannuallicensefee"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label58" runat="server" CssClass="LBLBLACK" Width="210px">Door No./Locality.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prddoorlocality" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="7" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txt_prddoorlocality"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">8.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label60" runat="server" CssClass="LBLBLACK" Width="210px">District.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdDistrictname" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="8" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txt_prdDistrictname"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">9.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label61" runat="server" CssClass="LBLBLACK" Width="210px">Mandal.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdmandalname" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="9" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txt_prdmandalname"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">10.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label62" runat="server" CssClass="LBLBLACK" Width="210px">Village.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdvillagename" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txt_prdvillagename"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">11.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label63" runat="server" CssClass="LBLBLACK" Width="210px">Renewal Period From.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdrenewalperiodfrom" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="11" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txt_prdrenewalperiodfrom"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">12.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label64" runat="server" CssClass="LBLBLACK" Width="210px">Renewal Period To.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt_prdrenewalperiodto" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="12" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txt_prdrenewalperiodto"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <asp:HiddenField ID="hf_PrdTradeID" runat="server" />
                                         <asp:HiddenField ID="hf_PrdSubTradeID" runat="server" />
                                         <asp:HiddenField ID="hf_PrdCellTowerID" runat="server" />

                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="div_prdsubmit">
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="Btnprevious" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" TabIndex="10" Text="Previous" ToolTip="Previous" OnClick="Btnprevious_Click"
                                        Width="90px" />&nbsp;
                                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    Text="Save" OnClick="BtnSave_Click" Width="90px" ValidationGroup="group" />
                                    &nbsp;
                                                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                                    TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" OnClick="btnNext_Click" />
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

                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

