<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"
    AutoEventWireup="true" CodeFile="districtreforms.aspx.cs" Inherits="UI_TSiPASS_districtreforms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {

            var f = $('#ctl00_ContentPlaceHolder1_hdnfocus').val();
            if (f != "") {
                $('#' + f).focus();
            }
        }
        function ConfirmSave() {
            var x = confirm("Please Confirm whether the Entered Details are Correct");
            if (x)
                return true;
            else
                return false;
        }

        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }

        function checkField(fieldname) {
            if (/[^0-9a-bA-B\s]/gi.test(fieldname.value)) {
                alert("Only alphanumeric characters and spaces are valid in this field");
                fieldname.value = "";
                fieldname.focus();
                return false;
            }
        }

        function alphanumeric(alphane) {
            var numaric = alphane;
            for (var j = 0; j < numaric.length; j++) {
                var alphaa = numaric.charAt(j);
                var hh = alphaa.charCodeAt(0);
                if ((hh > 47 && hh < 58) || (hh > 64 && hh < 91) || (hh > 96 && hh < 123)) {
                }
                else {
                    alert("Enter Alpha Numerics Only");
                    return false;
                }
            }
            //alert("Your Alpha Numeric Test Passed");
            return true;
        }




    </script>
    <script type="text/javascript">
        var newWindow = null;
        function PopupCenter(url, title, w, h) {
            if (newWindow == null) {
                // Fixes dual-screen position                         Most browsers      Firefox  
                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                newWindow = window.open(url, title, 'scrollbars=yes,status=no,toolbar=no,menubar=no,location=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                // Puts focus on the newWindow  
                if (window.focus) {
                    newWindow.focus();
                }
                freezeParentPage();
            }
        }
        function freezeParentPage() {
            var divRef = document.getElementById('ModalBackgroundDiv');

            if (divRef != null) {
                divRef.style.display = 'block';

                if (document.body.clientHeight > document.body.scrollHeight) {
                    divRef.style.height = document.body.clientHeight + 'px';
                }
                else {
                    divRef.style.height = document.body.scrollHeight + 'px';
                }
                divRef.style.width = '100%';
            }
        }

    </script>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- BOOTSTRAP STYLES-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
    <style type="text/css">
        .nav-pills.nav-wizard > li {
            position: relative;
            overflow: visible;
            border-right: 15px solid transparent;
            border-left: 15px solid transparent;
        }


            .nav-pills.nav-wizard > li + li {
                margin-left: 0;
            }

            .nav-pills.nav-wizard > li:first-child {
                border-left: 0;
            }

                .nav-pills.nav-wizard > li:first-child a {
                    border-radius: 5px 0 0 5px;
                }

            .nav-pills.nav-wizard > li:last-child {
                border-right: 0;
            }

                .nav-pills.nav-wizard > li:last-child a {
                    border-radius: 0 5px 5px 0;
                }

            .nav-pills.nav-wizard > li a {
                border-radius: 0;
                background-color: #eee;
            }

            .nav-pills.nav-wizard > li:not(:last-child) a:after {
                position: absolute;
                content: "";
                top: 0px;
                right: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 20px 0 20px 20px;
                border-color: transparent transparent transparent #eee;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:not(:first-child) a:before {
                position: absolute;
                content: "";
                top: 0px;
                left: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 20px 0 20px 20px;
                border-color: #eee #eee #eee transparent;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:hover:not(:last-child) a:after {
                border-color: transparent transparent transparent #aaa;
            }

            .nav-pills.nav-wizard > li:hover:not(:first-child) a:before {
                border-color: #aaa #aaa #aaa transparent;
            }

            .nav-pills.nav-wizard > li:hover a {
                background-color: #aaa;
                color: #fff;
            }

            .nav-pills.nav-wizard > li.active:not(:last-child) a:after {
                border-color: transparent transparent transparent #428bca;
            }

            .nav-pills.nav-wizard > li.active:not(:first-child) a:before {
                border-color: #428bca #428bca #428bca transparent;
            }

            .nav-pills.nav-wizard > li.active a {
                background-color: #428bca;
            }



        .button {
            background-color: #004A7F;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: none;
            color: #FFFFFF;
            cursor: pointer;
            display: inline-block;
            font-family: Arial;
            font-size: 15px;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
        }
        /*Newly Added*/
        .rightAlign {
            text-align: right;
        }

        .tdh {
            border-bottom: solid thin black;
            border-top: solid thin black;
            border-left: solid thin black;
            border-right: solid thin white;
        }

        .td {
            border-bottom: solid thin black;
            border-top: solid thin black;
            border-left: solid thin black;
            border-right: solid thin black;
        }
        /*End*/

        @-webkit-keyframes glowing {
            0% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -webkit-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }
        }

        @-moz-keyframes glowing {
            0% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -moz-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }
        }



        @keyframes glowing {
            0% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }
        }

        .button {
            -webkit-animation: glowing 1500ms infinite;
            -moz-animation: glowing 1500ms infinite;
            -o-animation: glowing 1500ms infinite;
            animation: glowing 1500ms infinite;
        }

        .wizard > .content {
            height: 850px;
            width: 1085px;
        }

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

        .lblinv {
            font-weight: bolder;
            color: Red;
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

        .textboxPge {
            border: 1px solid #c4c4c4;
            height: 30px;
            width: 140px;
            font-size: 13px;
            padding: 4px 4px 4px 4px;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            box-shadow: 0px 0px 8px #d9d9d9;
            -moz-box-shadow: 0px 0px 8px #d9d9d9;
            -webkit-box-shadow: 0px 0px 8px #d9d9d9;
        }

            .textboxPge:focus {
                outline: none;
                border: 1px solid #7bc1f7;
                box-shadow: 0px 0px 8px #7bc1f7;
                -moz-box-shadow: 0px 0px 8px #7bc1f7;
                -webkit-box-shadow: 0px 0px 8px #7bc1f7;
            }
    </style>
    <style type="text/css">
        .tooltipDemo
        {
            position: relative;
            display: inline;
            text-decoration: none;
            left: 0px;
            top: 0px;
        }
        
        .tooltipDemo:hover:before
        {
            border: solid;
            border-color: transparent rgb(111, 13, 53);
            border-width: 6px 6px 6px 0px;
            bottom: 21px;
            content: "";
            left: 35px;
            top: 5px;
            position: absolute;
            z-index: 95;
        }
        
        .tooltipDemo:hover:after
        {
            /*background: rgb(111, 13, 53);*/
            background: #2184be;
            border-radius: 5px;
            color: #fff;
            width: 300px;
            left: 40px;
            top: -5px;
            content: attr(alt);
            position: absolute;
            padding: 5px 15px;
            z-index: 95;
        }
        
        .LBLBLACK
        {
            top: 0px;
            left: 0px;
        }
        
        
        /*.auto-style1 {
            width: 288px;
        }

        .auto-style2 {
            width: 277px;
        }*/
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript" language="javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
    </script>
    <script type="text/javascript" language="javascript">
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
    <%--<asp:RequiredFieldValidator ID="rfvIFSCCode" runat="server" ControlToValidate="txtIfscCode"
                                                                    ErrorMessage="Please enter IFSC Code" ValidationGroup="Save" SetFocusOnError="true"
                                                                    Display="None" />--%>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="hdnfocus" value="" runat="server" />
            <%--<div>
                <table style="width: 100%">
                    <tr>
                        <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>--%>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <table style="width: 100%">
                                <tr>
                                    <td style="font-weight: bold">
                                        Application Form
                                    </td>
                                    <td align="right">
                                        <span style="font-weight: bold"><font color="red">*</font>All Fields Are Mandatory</span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid;
                font-weight: bold;">
                <table width="100%" align="left">
                    <tr>
                        <td>
                            <ul class="nav nav-pills nav-wizard">
                                <li class="active" id="Tab1" runat="server"><a href="#" data-toggle="tab">Enterprise
                                    Details</a></li>
                                <%-- <li id="Tab2" runat="server" visible="false"><a href="#" data-toggle="tab">2. Project Financials</a></li>
                                <li id="Tab3" runat="server" visible="false"><a href="#" data-toggle="tab">3. Project Details</a></li>
                                <li id="Tab4" runat="server" visible="false"><a href="#" data-toggle="tab">4. Loan Details</a></li>
                                <%--<li id="Tab5" runat="server"><a href="#" data-toggle="tab">5. Coming Soon</a></li>
                                <li id="Tab5" runat="server" visible="false"><a href="#" data-toggle="tab">5. Bank Details</a></li>--%>
                            </ul>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <tr>
                                <td>
                                    <asp:MultiView ID="MainView" runat="server">
                                        <asp:View ID="View1" runat="server">
                                            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid;
                                                font-weight: bold;">
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td style="height: 15px; font-weight: bold;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; height: 60px">
                                                                    1
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="style42">
                                                                    Type of Sector<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px" class="style41">
                                                                    :
                                                                </td>
                                                                <td class="style41" style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                    <asp:DropDownList ID="rblSector" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSector_SelectedIndexChanged"
                                                                        class="form-control txtbox" AutoPostBack="true" TabIndex="1" Height="33px" Width="180px">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="1">Service</asp:ListItem>
                                                                        <asp:ListItem Value="2">Manufacture</asp:ListItem>
                                                                        <asp:ListItem Value="3">Textiles</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfvSector" runat="server" ControlToValidate="rblSector"
                                                                        ErrorMessage="Please Select Type of Sector" SetFocusOnError="true" InitialValue="--Select--"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    2
                                                                </td>
                                                                <%--<td>Udyog Aadhar/EM/IEM/IL/EOU No <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>--%>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlUdyogAadharType" runat="server" class="form-control txtbox"
                                                                        RepeatDirection="Horizontal" TabIndex="1" Height="33px" Width="200px" ValidationGroup="group">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="ddlUdyogAadharType"
                                                                        ErrorMessage="Please Select Udyog Aadhar/EM/IEM/IL/EOU No" SetFocusOnError="true"
                                                                        InitialValue="-- Select Udyog Aadhar/EM/IEM/IL/EOU No --" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtudyogAadharNo" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="80" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtudyogAadharNo"
                                                                        ErrorMessage="Please Enter Udyog Aadhar No" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                                    3
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Date of Registration &nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtUdyogAadhaarRegdDate" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtUdyogAadhaarRegdDate"
                                                                        class="form-control txtbox" ErrorMessage="Please Enter Date of Registration"
                                                                        SetFocusOnError="true" ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                                    4&nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Unit Name&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtUser_Id" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="80" TabIndex="1" onkeypress="return alphanumeric(this)" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfvUnitName" runat="server" ControlToValidate="txtUser_Id"
                                                                        ErrorMessage="Please Enter Unit Name" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;" align="center">
                                                                    5
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Applicant Name&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtApplciantName" runat="server" class="form-control txtbox" Height="28px"
                                                                        TabIndex="1" onkeypress="Names()" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApplciantName"
                                                                        ErrorMessage="Please Enter Applicant Name" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                                    6
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    TIN/ VAT/ CST/ GST Number <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtTinNO" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="100" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtTinNO_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfApplName" runat="server" ControlToValidate="txtTinNO"
                                                                        ErrorMessage="Please Enter TIN Number" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;" align="center">
                                                                    7
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    PAN Number<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtPanNo" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPanNo"
                                                                        ErrorMessage="Please Enter PAN Number" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"
                                                                    align="center">
                                                                    8
                                                                </td>
                                                                <td class="style36" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Other Details
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:CheckBox ID="cbDiffAbled" runat="server" AutoPostBack="true" OnCheckedChanged="cbDiffAbled_CheckedChanged"
                                                                        TabIndex="1" Text="     Physically handicapped" />
                                                                    <br />
                                                                    <%--<asp:CheckBox ID="cbWomen" runat="server" TabIndex="1" Text="Women" Visible="false" />
                                            <br />--%>
                                                                    <asp:CheckBox ID="cbMinority" runat="server" TabIndex="1" Text="     Minority" Visible="false" />
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"
                                                                    align="center">
                                                                    9
                                                                </td>
                                                                <td class="style36" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                                    width="15%">
                                                                    <asp:Label ID="lbldateofCommencement" runat="server" Text="Date of commencement for Production"></asp:Label><span
                                                                        style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtDateofCommencement" runat="server" class="form-control txtbox"
                                                                        TabIndex="1" Width="180px" Height="28px" AutoPostBack="true" OnTextChanged="txtDateofCommencement_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtDateofCommencement"
                                                                        ErrorMessage="Please Select Commenecement Date" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"
                                                                    align="center">
                                                                    10
                                                                </td>
                                                                <td>
                                                                    Gender
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                    <asp:DropDownList ID="ddlgender" runat="server" class="form-control txtbox" TabIndex="1"
                                                                        Height="33px" Width="180px">
                                                                        <asp:ListItem Value="0">--Gender--</asp:ListItem>
                                                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                                                        <asp:ListItem Value="T">Transgender</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlgender"
                                                                        ErrorMessage="Please Select Gender" SetFocusOnError="true" InitialValue="--Gender--"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; height: 60px">
                                                                    11
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Social Status<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                    <asp:DropDownList ID="rblCaste" runat="server" class="form-control txtbox" RepeatDirection="Horizontal"
                                                                        TabIndex="1" Height="33px" Width="180px" OnSelectedIndexChanged="rblCaste_SelectedIndexChanged"
                                                                        AutoPostBack="True">
                                                                        <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                                        <asp:ListItem Value="1">General</asp:ListItem>
                                                                        <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                        <asp:ListItem Value="3">SC</asp:ListItem>
                                                                        <asp:ListItem Value="4">ST</asp:ListItem>
                                                                        <asp:ListItem Value="5">Minority</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="rblCaste"
                                                                        ErrorMessage="Please Select Caste" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trsubcaste" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: center; height: 60px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Sub Caste<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                    <asp:DropDownList ID="ddlsubcaste" runat="server" Height="33px" Width="180px" RepeatDirection="Horizontal"
                                                                        TabIndex="1" OnSelectedIndexChanged="rblCaste_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                                        <asp:ListItem Value="1">BC-A</asp:ListItem>
                                                                        <asp:ListItem Value="2">BC-B</asp:ListItem>
                                                                        <asp:ListItem Value="3">BC-C</asp:ListItem>
                                                                        <asp:ListItem Value="4">BC-D</asp:ListItem>
                                                                        <asp:ListItem Value="5">BC-E</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator74" runat="server" ControlToValidate="ddlsubcaste"
                                                                        ErrorMessage="Please Select Sub Caste" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trrblVeh" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: left; height: 60px" valign="middle">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" colspan="6">
                                                                    <asp:RadioButtonList ID="rblVeh" runat="server" RepeatDirection="Horizontal" TabIndex="5"
                                                                        OnSelectedIndexChanged="rblVeh_SelectedIndexChanged" AutoPostBack="True">
                                                                        <asp:ListItem Value="1">Transport allied activities</asp:ListItem>
                                                                        <asp:ListItem Value="0">Other Service Sector</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="rblVeh"
                                                                        ErrorMessage="Please Select Transport allied activities" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr id="trvehicleno" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    Vehicle Number
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtregistrationno" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="10" TabIndex="4" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator92" runat="server" ControlToValidate="txtregistrationno"
                                                                        ErrorMessage="Please Enter Vehicle Number" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
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
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                    12 <u>Unit Address </u>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                    13 <u>Office Address </u>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Width="165px">State<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:DropDownList ID="ddlUnitstate" runat="server" class="form-control txtbox" Height="33px"
                                                                        Width="180px" AutoPostBack="True" TabIndex="2" OnSelectedIndexChanged="ddlUnitstate_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="ddlUnitstate"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select State" InitialValue="--Select--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">State<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:DropDownList ID="ddloffcstate" runat="server" class="form-control txtbox" Height="33px"
                                                                        Width="180px" AutoPostBack="True" TabIndex="4" OnSelectedIndexChanged="ddloffcstate_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator69" runat="server" ControlToValidate="ddloffcstate"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select State" InitialValue="--Select--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    District<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlUnitDIst" runat="server" class="form-control txtbox" Visible="true"
                                                                        TabIndex="3" Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddldistrictunit_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ControlToValidate="ddlUnitDIst"
                                                                        SetFocusOnError="true" ErrorMessage="Please Enter Unit District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    District&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlOffcDIst" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Height="33px" Width="180px" TabIndex="4" Visible="true" OnSelectedIndexChanged="ddldistrictoffc_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtofficedist" runat="server" class="form-control txtbox" Height="28px"
                                                                        Visible="false" MaxLength="30" TabIndex="4" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server" ControlToValidate="txtofficedist"
                                                                        SetFocusOnError="true" ErrorMessage="Please Enter Unit District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlOffcDIst"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Office District" InitialValue="--District--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Mandal&nbsp; <span style="font-weight: bold; color: Red;">*</span>
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
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Unit Mandal" InitialValue="--Mandal--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Mandal&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlOffcMandal" runat="server" AutoPostBack="True" Visible="true"
                                                                        TabIndex="4" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddloffcmandal_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtoffcicemandal" runat="server" class="form-control txtbox" Height="28px"
                                                                        Visible="false" MaxLength="30" TabIndex="4" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" ControlToValidate="txtoffcicemandal"
                                                                        SetFocusOnError="true" ErrorMessage="Please Enter Office Mandal" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="ddlOffcMandal"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Office Mandal" InitialValue="--Mandal--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Village&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox"
                                                                        Visible="true" TabIndex="3" Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlVillageunit_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddlVillageunit"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Unit Village" InitialValue="--Village--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Village&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlOffcVil" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        TabIndex="4" Height="33px" Width="180px" Visible="true">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtofficeviiage" runat="server" class="form-control txtbox" Height="28px"
                                                                        Visible="false" MaxLength="30" TabIndex="4" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ControlToValidate="txtofficeviiage"
                                                                        SetFocusOnError="true" ErrorMessage="Please Enter Office Village" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="ddlOffcVil"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Office Village" InitialValue="--Village--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trcommissionerates" runat="server">
                                                                 <td></td>
                                                                  <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Commissionerates&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                 <td></td>
                                                                 <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlcommissionerates" runat="server" class="form-control txtbox"
                                                                        Visible="true" TabIndex="3" Height="33px" Width="180px" AutoPostBack="True" >
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                 <td></td>
                                                                 
                                                             </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Grampanchayat/IE/IDA<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtUnitStreet" runat="server" class="form-control txtbox" Height="28px"
                                                                        TabIndex="3" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtUnitStreet"
                                                                        SetFocusOnError="true" ErrorMessage="Please enter Unit Street" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Street<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtOffcStreet" runat="server" class="form-control txtbox" Width="180px"
                                                                        Height="28px" TabIndex="4" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtOffcStreet"
                                                                        SetFocusOnError="true" ErrorMessage="Please enter Office Street" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Survey/Plot No.<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtUnitHNO" runat="server" class="form-control txtbox" Height="28px"
                                                                        TabIndex="3" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUnitHNO"
                                                                        SetFocusOnError="true" ErrorMessage="Please Enter Unit Survey Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Survey/Plot/Door No.<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtoffaddhnno" runat="server" class="form-control txtbox" Height="28px"
                                                                        Width="180px" TabIndex="4">                                                                    
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtoffaddhnno"
                                                                        SetFocusOnError="true" ErrorMessage="Please Enter Office Survey Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                    Mobile Number<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtunitmobileno" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="3" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtunitmobileno"
                                                                        SetFocusOnError="true" ErrorMessage="Please enter Unit Mobile Number" ValidationGroup="group"
                                                                        Display="None">*
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                    Mobile Number<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtOffcMobileNO" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="4" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOffcMobileNO"
                                                                        SetFocusOnError="true" ErrorMessage="Please enter Office Mobile Number" ValidationGroup="group"
                                                                        Display="None">*
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                    Email Id<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtunitemailid" runat="server" class="form-control txtbox" Height="28px"
                                                                        TabIndex="3" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtunitemailid"
                                                                        SetFocusOnError="true" ErrorMessage="Please Enter Unit Email" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtunitemailid"
                                                                        ErrorMessage="Please Enter Unit Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                        ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RegularExpressionValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;" align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">
                                                                    Email Id<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtOffcEmail" runat="server" class="form-control txtbox" Height="28px"
                                                                        TabIndex="4" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtOffcEmail"
                                                                        SetFocusOnError="true" ErrorMessage="Please Enter Office Email" ValidationGroup="group"
                                                                        Display="None">*
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtOffcEmail"
                                                                        ErrorMessage="Please Enter Office Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                        ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center;">
                                                                    14
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Type of Organization<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlOrgType" runat="server" class="form-control txtbox" Height="33px"
                                                                        TabIndex="5" Width="180px" ValidationGroup="group">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfvTypofOrg" runat="server" ControlToValidate="ddlOrgType"
                                                                        ErrorMessage="Please select Type of Organization" ValidationGroup="group" SetFocusOnError="true"
                                                                        InitialValue="--Select--" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; height: 60px" align="center"
                                                                    valign="middle">
                                                                    15
                                                                </td>
                                                                <td valign="middle" colspan="8">
                                                                    <asp:RadioButtonList ID="rblGHMC" Enabled="false" runat="server" TabIndex="5" RepeatDirection="Horizontal"
                                                                        OnSelectedIndexChanged="rblGHMC_SelectedIndexChanged">
                                                                        <asp:ListItem Value="1">GHMC & other Municipal Corporations in the state</asp:ListItem>
                                                                        <asp:ListItem Value="0">Other areas in the state</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="rblGHMC"
                                                                        ErrorMessage="Please Select GHMC/Other Area" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trIsIALA" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: center;">
                                                                    16
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Whether Unit Located in TSIIC<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:RadioButtonList ID="rdIaLa_Lst" runat="server" RepeatDirection="Horizontal"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="rdIaLa_Lst"
                                                                        ErrorMessage="Please select whether the unit is located in TSIIC or not" ValidationGroup="group"
                                                                        SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr id="trIndusParkList" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: center;">
                                                                    17
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Name of the Industrial Park<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlIndustrialParkName" runat="server" AutoPostBack="true" class="form-control txtbox"
                                                                        Height="33px" Width="180px">
                                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" ControlToValidate="ddlIndustrialParkName"
                                                                        ErrorMessage="Please select Industrial Park" ValidationGroup="group" SetFocusOnError="true"
                                                                        InitialValue="--Select--" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr id="trLineofActivity" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: center;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblNatureofActitvity" runat="server" Text="Nature of Activity" Width="185px">Nature of Activity<font color="red">*</font></asp:Label>
                                                                    <%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                    <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="form-control txtbox"
                                                                        Height="33px" Width="80%" TabIndex="5" ValidationGroup="group">
                                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtBussinessActivity" runat="server" class="form-control txtbox"
                                                                        Height="28px" Width="80%" TabIndex="5" MaxLength="250" ValidationGroup="group"
                                                                        Visible="false"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfvLineOfAct" runat="server" InitialValue="--Select--"
                                                                        ControlToValidate="ddlintLineofActivity" ErrorMessage="Please select Nature of Activity"
                                                                        ValidationGroup="group" SetFocusOnError="true" Display="None">*
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtBussinessActivity"
                                                                        ErrorMessage="Please enter Nature of Activity" ValidationGroup="group" SetFocusOnError="true"
                                                                        Display="None">*
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr1" runat="server">
                                                                <td style="padding: 5px; margin: 5px; text-align: center;">
                                                                    17
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Upload Document<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <%--<asp:Label ID="Label1" runat="server" Text="Upload Document">17.Upload Document<font color="red">*</font></asp:Label>--%>
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" class="form-control txtbox"
                                                                        Height="33px" />
                                                                    <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                                    <br />
                                                                    <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                                                    <%--<asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" />--%>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                              <tr id="tr2" runat="server">
                                                                <td style="padding: 5px; margin: 5px; text-align: center;">
                                                                    18
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Upload Other Attachments<span style="font-weight: bold; color: Red;"></span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <%--<asp:Label ID="Label1" runat="server" Text="Upload Document">17.Upload Document<font color="red">*</font></asp:Label>--%>
                                                                     <asp:FileUpload ID="FileUpload2" runat="server" Width="300px" class="form-control txtbox"
                                                        Height="33px" />
                                                    <asp:HyperLink ID="lblFileNameOthers" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="lbl999" runat="server" Visible="False"></asp:Label>
                                                                    <%--<asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" />--%>

                                                                </td>
                                                                <td>
                                                                   
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <%-- <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>--%>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr style="height: 50px">
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td colspan="3" style="padding: 5px; margin: 5px" valign="bottom">
                                                                    <%--   <a href="DisplayDocs/HMDAListofVillagesexcel.pdf" target="_blank"><b>Click here for HMDA Villages List</b></a>--%>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px" colspan="5" align="right">
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 20px; font-weight: bold;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 50px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button Text="Save" CssClass="btn btn-primary" Height="40px" Width="170px" Font-Size="Large"
                                        TabIndex="5" ForeColor="White" ID="btntab1next" runat="server" OnClick="btntab1next_Click" />
                                    <span style="padding-left: 5px;">
                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                            Height="40px" TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" Width="170px"
                                            Visible="false" />
                                    </span><span style="padding-left: 5px;">
                                        <asp:Button ID="btnNextpayment" runat="server" CssClass="btn btn-warning" Height="40px"
                                            Width="190px" Text="Next" OnClick="btnNextpayment_Click" TabIndex="5" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                        &times;</a> <strong>Success!</strong>
                                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                        Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <h1 class="page-subhead-line">
                                            <asp:HiddenField ID="hdnfldtsiic" runat="server" />
                                        </h1>
                                    </div>
                                </td>
                            </tr>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdfID" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="group" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="child" />
                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="group1" />
                        </td>
                    </tr>
                </table>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btntab1next"></asp:PostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
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
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txtNewPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  

            $("input[id$='txttermload']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtdatesome']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtCSTRegDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            //added newly
            $("input[id$='txtUdyogAadhaarRegdDate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtGSTDate']").datepicker(
           {
               dateFormat: "dd/mm/yy",
               //  maxDate: new Date(currentYear, currentMonth, currentDate)
           }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
            {
                dateFormat: "dd/mm/yy",
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
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
            $("input[id$='txtDateofCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtNewPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback   

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txttermload']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtdatesome']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtCSTRegDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback 
            //added newly
            $("input[id$='txtGSTDate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
            {
                dateFormat: "dd/mm/yy",
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
           {
               dateFormat: "dd/mm/yy",
               //  maxDate: new Date(currentYear, currentMonth, currentDate)
           }); // Will run at every postback/AsyncPostback  

        });
    </script>
    <style type="text/css">
        .ui at k r font- 8pt; i or eight: 250px; d n 0.2 em 0 dth; 2 px; .auto-style8 {
            height: 29px;
        }

        </style>
</asp:Content>
