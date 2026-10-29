<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="IncetivesNewForm2.aspx.cs" Inherits="UI_TSiPASS_IncetivesNewForm2" %>

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
        .tooltipDemo {
            position: relative;
            display: inline;
            text-decoration: none;
            left: 0px;
            top: 0px;
        }

            .tooltipDemo:hover:before {
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

            .tooltipDemo:hover:after {
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

        .LBLBLACK {
            top: 0px;
            left: 0px;
        }


        /*.auto-style1 {
            width: 288px;
        }

        .auto-style2 {
            width: 277px;
        }*/

        .auto-style6 {
            width: 213px;
        }

        .auto-style7 {
            width: 375px;
        }
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
        function validateVerhoeff(ctrlStartID) {

            var num = ctrlStartID.value;
            //alert(num);
            //alert('hi');
            var num;
            var cc;
            var c = 0;
            var myArray = StringToReversedIntArray(num);

            for (var i = 0; i < myArray.length; i++) {

                c = d[c][p[(i % 8)][myArray[i]]];

            }

            cc = c;
            if (cc == 0) {

            }
            else {

                alert("This is not Valid Aadhar Number");
                document.getElementById(ctrlStartID.ClientID).value = "";

            }
        }
        function StringToReversedIntArray(num) {

            var myArray = [num.length];

            for (var i = 0; i < num.length; i++) {

                myArray[i] = (num.substring(i, i + 1));

            }

            myArray = Reverse(myArray);


            return myArray;

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
                                        Incentive Application Form
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
                                <li class="active" id="Tab1" runat="server"><a href="#" data-toggle="tab">1. Enterprise
                                    Details</a></li>
                                <li id="Tab2" runat="server"><a href="#" data-toggle="tab">2. Project Financials</a></li>
                                <li id="Tab3" runat="server"><a href="#" data-toggle="tab">3. Project Details</a></li>
                                <li id="Tab4" runat="server"><a href="#" data-toggle="tab">4. Loan Details</a></li>
                                <%--<li id="Tab5" runat="server"><a href="#" data-toggle="tab">5. Coming Soon</a></li>--%>
                                <li id="Tab5" runat="server"><a href="#" data-toggle="tab">5. Bank Details</a></li>
                            </ul>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HDNMSMENO" runat="server" />
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
                                                                <td class="style41" style="padding: 5px; margin: 5px; text-align: left;" colspan="1">
                                                                    <asp:DropDownList ID="rblSector" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblSector_SelectedIndexChanged"
                                                                        class="form-control txtbox" AutoPostBack="true" TabIndex="1" Height="33px" Width="180px"
                                                                        Enabled="false">
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
                                                                <td style="padding: 5px; margin: 5px; text-align: center; height: 60px" id="td1" runat="server" visible="false">
                                                                    1.1
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="style42" id="td2" runat="server" visible="false">
                                                                    Service Line of Activity<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px" class="style41" id="td3" runat="server" visible="false">
                                                                    :
                                                                </td>
                                                                <td class="style41" style="padding: 5px; margin: 5px; text-align: left;" colspan="6"  id="td4" runat="server" visible="false">
                                                                    <asp:DropDownList ID="ddllineofactivitynew" runat="server" RepeatDirection="Horizontal"
                                                                        class="form-control txtbox" TabIndex="1" Height="33px" Width="180px" Enabled="false"
                                                                        OnSelectedIndexChanged="ddllineofactivitynew_SelectedIndexChanged" AutoPostBack="true" >
                                                                        <%--<asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                                                                        <%--       <asp:ListItem Value="1">Service</asp:ListItem>
                                                                        <asp:ListItem Value="2">Manufacture</asp:ListItem>
                                                                        <asp:ListItem Value="3">Textiles</asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="Othersactivty" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="80" TabIndex="1" ValidationGroup="group" Width="180px" Visible="false"></asp:TextBox>
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
                                                                    Date of Registration (DD/MM/YYYY) &nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtUdyogAadhaarRegdDate" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
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
                                                                    <asp:Label ID="lbldateofCommencement" runat="server" Text="Date of commencement for Production (DD/MM/YYYY)"></asp:Label><span
                                                                        style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtDateofCommencement" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
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
                                                                        TabIndex="3" ValidationGroup="group" Width="180px" Onblur="validateEmail(this);"></asp:TextBox>
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
                                                                        TabIndex="4" ValidationGroup="group" Width="180px" Onblur="validateEmail(this);"></asp:TextBox>
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
                                                                        TabIndex="5" Width="180px" ValidationGroup="group" AutoPostBack="True" OnSelectedIndexChanged="ddlOrgType_SelectedIndexChanged">
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
                                                                    Whether Unit Located in TGIIC<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:RadioButtonList ID="rdIaLa_Lst" runat="server" RepeatDirection="Horizontal"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="rdIaLa_Lst"
                                                                        ErrorMessage="Please select whether the unit is located in TGIIC or not" ValidationGroup="group"
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
                                                            <tr id="trcfecfo" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: center;">
                                                                    17
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    CFE UID NO<span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtcfeuidno" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="60" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcfeuidno_TextChanged"
                                                                        AutoPostBack="true"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    CFO UID NO <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtcfouidno" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="60" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcfouidno_TextChanged"
                                                                        AutoPostBack="true"></asp:TextBox>
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
                                                            <tr id="trfoodprocessing" runat="server" visible="false"  >
                                                                <td  style="padding: 5px; margin: 5px; text-align: center;">
                                                                    18
                                                                </td>
                                                                <td id="food1" runat="server" visible="false"  style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Is your unit Food Processing <span style="font-weight: bold; color: Red;"> *</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td id="food2" runat="server" visible="false" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:RadioButtonList ID="rbtfoodprocessing" runat="server" RepeatDirection="Horizontal"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="rbtfoodprocessing_SelectedIndexChanged">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ControlToValidate="rdIaLa_Lst"
                                                                        ErrorMessage="Please select whether the unit is located in TGIIC or not" ValidationGroup="group"
                                                                        SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td align="left" valign="middle" id="food3" runat="server" visible="false"  >Please Enter Food Processing Zone Name : </td>
                                                                <td>
                                                                </td>
                                                                <td id="food4" runat="server" visible="false"><asp:TextBox ID="txtfoodprocessing" runat="server" class="form-control txtbox" Height="28px" MaxLength="1000" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="height: 20px; font-weight: bold;">
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
                                                                    <asp:Button Text="Next" CssClass="btn btn-warning" Height="50px" Width="150px" Font-Size="Large"
                                                                        TabIndex="5" ForeColor="White" ID="btntab1next" runat="server" OnClick="btntab1next_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                        <asp:View ID="View2" runat="server">
                                            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid;
                                                font-weight: bold;">
                                                <tr>
                                                    <td width="100%">
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                                    <asp:Label ID="lblIndStatus" runat="server" Visible="true" Text="Industry Status"></asp:Label>
                                                                    <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td class="auto-style9">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: central"
                                                                    class="auto-style10">
                                                                    <asp:DropDownList ID="ddlIndustryStatus" runat="server" class="form-control txtbox"
                                                                        Height="35px" TabIndex="5" Width="180px" ValidationGroup="group" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlindustryStatus_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                        <asp:ListItem Value="1">New Industry</asp:ListItem>
                                                                        <asp:ListItem Value="2">Expansion</asp:ListItem>
                                                                        <asp:ListItem Value="3">Diversification</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="5" class="auto-style10">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlIndustryStatus"
                                                                        ErrorMessage="Please select Industry Status" InitialValue="-- Select --" ValidationGroup="group"
                                                                        SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trIndustryExpansionType" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">
                                                                    <asp:Label ID="Label9" runat="server" Visible="true" Text="Expansion Type"></asp:Label>
                                                                    <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="width: 2px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: central">
                                                                    <asp:DropDownList ID="ddlInustryExpansionType" runat="server" class="form-control txtbox"
                                                                        Height="35px" TabIndex="5" Width="180px" ValidationGroup="group">
                                                                        <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                                                        <asp:ListItem Value="1">Expansion1</asp:ListItem>
                                                                        <asp:ListItem Value="2">Expansion2</asp:ListItem>
                                                                        <asp:ListItem Value="3">Expansion3</asp:ListItem>
                                                                        <asp:ListItem Value="4">Expansion4</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="5">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator79" runat="server" ControlToValidate="ddlInustryExpansionType"
                                                                        ErrorMessage="Please select Industry Expansion Type" InitialValue="-- Select --"
                                                                        ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trexstngDCP" runat="server" visible="false">
    <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">
        <asp:Label ID="Label25" runat="server" Visible="true" Text="Existing Unit Date of Commencement of Production (DD/MM/YYYY)"></asp:Label>
        <span style="font-weight: bold; color: Red;">*</span>
    </td>
    <td style="width: 2px">:
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: central">
        <asp:TextBox ID="txtExistingDCP" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
            TabIndex="1" Width="180px" Height="28px" AutoPostBack="false" OnTextChanged="txtExistingDCP_TextChanged"></asp:TextBox>
    </td>
    <td colspan="5">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator103" runat="server" ControlToValidate="txtExistingDCP"
            ErrorMessage="Please select Existing Unit DCP" InitialValue=""
            ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
    </td>
</tr>
                                                            <tr id="trNewIndustry" runat="server" visible="false" align="center">
                                                                <td colspan="9" align="center">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="9" align="left">
                                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="465px">New Enterprise Line of Activity<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trlineofactivityNew" runat="server">
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="center">
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            1
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:Label ID="Label2" runat="server">Line Of Activity<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtLOActivity" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" oncut="return false" autocomplete="off" 
                                                                                                MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            3
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:Label ID="Label3" runat="server">Unit<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:DropDownList ID="ddlquantityin" runat="server" class="form-control txtbox" TabIndex="5"
                                                                                                Height="33px" Width="180px" AutoPostBack="True" Visible="true" OnSelectedIndexChanged="ddlquantityin_SelectedIndexChanged">
                                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                                <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                                                <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                                                <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                                                                <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:TextBox ID="txtunit" runat="server" class="form-control txtbox" Visible="false" oncopy="return false" oncut="return false" autocomplete="off" 
                                                                                                Height="28px" MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group"
                                                                                                Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                        ControlToValidate="txtunit" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td valign="top" align="center">
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            2
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Installed Capacity<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            <asp:TextBox ID="txtinstalledccap" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" oncut="return false" autocomplete="off" 
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                        ControlToValidate="txtinstalledccap" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            4
                                                                                        </td>
                                                                                        <td style="width: 200px;">
                                                                                            <asp:Label ID="Label5" runat="server">Value (in Rs.)<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            <asp:TextBox ID="txtvalue" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" oncut="return false" autocomplete="off" 
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                        ControlToValidate="txtvalue" ErrorMessage="Please enter Value"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Button ID="btnInstalledcap" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                                Height="28px" TabIndex="5" Text="Add New" Width="72px" OnClick="btnInstalledcap_Click" />
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                                                                                Height="28px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px"
                                                                                                OnClick="Button2_Click" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3" width="100%">
                                                                                <asp:GridView ID="gvInstalledCap" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                                    GridLines="Both" Visible="false" Width="90%" DataKeyNames="intLineofActivityMid"
                                                                                    OnRowDataBound="gvInstalledCap_RowDataBound" OnRowDeleting="gvInstalledCap_RowDeleting">
                                                                                    <RowStyle BackColor="#ffffff" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                                                                        <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                                        <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                                        <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                                    </Columns>
                                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                                        HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                                        Font-Names="Arial" Font-Size="9px" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="center">
                                                                            <td style="padding: 5px; margin: 5px;" valign="top" align="center" colspan="9" width="100%">
                                                                                <center>
                                                                                    <asp:GridView ID="gvInstalledCapNew" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                                        GridLines="Both" Visible="false" Width="90%">
                                                                                        <RowStyle BackColor="#ffffff" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                                                                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                                            <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                                                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                                        </Columns>
                                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                                            HorizontalAlign="Center" />
                                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                                    </asp:GridView>
                                                                                </center>
                                                                            </td>
                                                                        </tr>
                                                                        <%-- <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                                                <asp:GridView ID="gvInstalledCap1" runat="server" AutoGenerateColumns="False"
                                                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                                                    CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                                                    Width="100%">
                                                                                    <RowStyle BackColor="#ffffff" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                                                                        <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                                        <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                                        <asp:BoundField DataField="Column4" HeaderText="Value" />
                                                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                                    </Columns>
                                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <EditRowStyle BackColor="#013161" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>--%>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="trexpansionnew" runat="server" visible="false">
                                                                <td colspan="9" align="center">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="9">
                                                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="465px">Expansion of Enterprise<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trlineofactivityexpansion" runat="server">
                                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            1
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:Label ID="Label19" runat="server">Line Of Activity<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtLOActivityExpan" runat="server" class="form-control txtbox" Height="28px"  oncopy="return false" oncut="return false" autocomplete="off" 
                                                                                                MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                        ControlToValidate="txtLOActivity" ErrorMessage="Please enter Line Of Activity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            3
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:Label ID="Label20" runat="server">Unit<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:DropDownList ID="ddlquantityinExpan" runat="server" class="form-control txtbox"
                                                                                                TabIndex="5" Height="33px" Width="180px" AutoPostBack="True" Visible="true" OnSelectedIndexChanged="ddlquantityinExpan_SelectedIndexChanged">
                                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                                <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                                                <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                                                <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                                                                <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:TextBox ID="txtunitExpan" runat="server" class="form-control txtbox" Visible="false"  oncopy="return false" oncut="return false" autocomplete="off" 
                                                                                                Height="28px" MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group"
                                                                                                Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                        ControlToValidate="txtunit" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td valign="top">
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            2
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="165px">Installed Capacity<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            <asp:TextBox ID="txtinstalledccapExpan" runat="server" class="form-control txtbox"  oncopy="return false"  oncut="return false" autocomplete="off" 
                                                                                                Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                        ControlToValidate="txtinstalledccap" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            4
                                                                                        </td>
                                                                                        <td style="width: 200px;">
                                                                                            <asp:Label ID="Label22" runat="server">Value (in Rs.)<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtvalueExpan" runat="server" class="form-control txtbox" Height="28px"  oncopy="return false"  oncut="return false" autocomplete="off" 
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                Width="180px" Visible="true"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                        ControlToValidate="txtvalue" ErrorMessage="Please enter Value"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Button ID="btnInstalledcapExpan" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                                Height="28px" TabIndex="5" Text="Add New" Width="72px" OnClick="btnInstalledcapExpan_Click" />
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button ID="Button3" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                                                                                Height="28px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px"
                                                                                                OnClick="Button3_Click" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                                                                <asp:GridView ID="gvInstalledCapExpan" runat="server" AutoGenerateColumns="False"
                                                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                                                                    ForeColor="#333333" GridLines="Both" Visible="false" Width="60%" DataKeyNames="intLineofActivityMid"
                                                                                    OnRowDataBound="gvInstalledCapExpan_RowDataBound" OnRowDeleting="gvInstalledCapExpan_RowDeleting">
                                                                                    <RowStyle BackColor="#ffffff" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                                                                        <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                                        <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                                        <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                                    </Columns>
                                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                                        HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                                        Font-Names="Arial" Font-Size="9px" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                                                                <asp:GridView ID="gvInstalledCapExpanNew" runat="server" AutoGenerateColumns="False"
                                                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                                                                    ForeColor="#333333" GridLines="Both" Visible="false" Width="60%">
                                                                                    <RowStyle BackColor="#ffffff" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                                                                        <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                                        <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                                        <asp:BoundField DataField="Column4" HeaderText="Value" />
                                                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                                    </Columns>
                                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                                        HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                                        Font-Names="Arial" Font-Size="9px" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="trexpansion" runat="server" visible="false">
                                                                <td colspan="9" align="center">
                                                                    <table style="width: 100%; font-weight: bold;" id="tblexpsnsion" runat="server" visible="false">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="4">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="4">
                                                                                <asp:Label ID="lblexpan1" runat="server"></asp:Label>
                                                                                &nbsp; PROJECT(In Rs.)<font color="red">*</font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin white; background: #013161; color: white" align="center">
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white"
                                                                                class="auto-style6">
                                                                                Line Of Activity
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white"
                                                                                class="auto-style7">
                                                                                Installed Capacity
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                % of increase under
                                                                                <br />
                                                                                <asp:Label ID="lblexpan2" runat="server"></asp:Label>
                                                                            </td>
                                                                            <%--Expansion--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                            </td>
                                                                            <td align="center" style="padding: 5px; margin: 5px; border: solid thin white; background: #013161;
                                                                                color: white">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="center" style="background: #013161; color: white; width: 50%">
                                                                                            Quantity
                                                                                        </td>
                                                                                        <td align="center" style="background: #013161; color: white; width: 50%">
                                                                                            Unit
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="border: solid thin black; background: white; color: black">
                                                                                &nbsp;&nbsp;Existing Enterprise
                                                                            </td>
                                                                            <td align="left" style="border: solid thin black; width: 180px;">
                                                                                <asp:TextBox ID="txteeploa" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="Names()" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black" class="auto-style7">
                                                                                <%--<asp:TextBox ID="txteepinscap" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>--%>
                                                                                <table style="font-weight: bold; width: 90%;">
                                                                                    <tr>
                                                                                        <td align="center" style="border: solid thin black; width: 50%" class="auto-style6">
                                                                                            <asp:TextBox ID="txteepinscap" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                Width="100px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="center" style="text-align: center; width: 50%">
                                                                                            <asp:DropDownList ID="ddleepinscap" runat="server" class="form-control txtbox" Height="28px"
                                                                                                TabIndex="5" Width="150px">
                                                                                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                                                <asp:ListItem Value="1">Liters</asp:ListItem>
                                                                                                <asp:ListItem Value="2">Kg</asp:ListItem>
                                                                                                <asp:ListItem Value="3">Tones</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ControlToValidate="ddleepinscap"
                                                                                                ErrorMessage="Please select Installed Capacity Unit" InitialValue="-- Select --"
                                                                                                SetFocusOnError="true" ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black">
                                                                                <asp:TextBox ID="txteeppercentage" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" style="border: solid thin black; background: white; color: black">
                                                                                &nbsp;&nbsp;<asp:Label ID="lblexpan3" runat="server"></asp:Label>&nbsp;Project
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black; width: 180px;">
                                                                                <asp:TextBox ID="txtedploa" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="Names()" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black" class="auto-style7">
                                                                                <table style="width: 90%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td align="center" class="auto-style6" style="border: solid thin black; width: 50%">
                                                                                            <asp:TextBox ID="txtedpinscap" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                Width="100px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td align="center" style="text-align: center; border: solid thin black; width: 50%">
                                                                                            <asp:DropDownList ID="ddledpinscap" runat="server" class="form-control txtbox" Height="28px"
                                                                                                TabIndex="5" Width="150px">
                                                                                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                                                <asp:ListItem Value="1">Liters</asp:ListItem>
                                                                                                <asp:ListItem Value="2">Kg</asp:ListItem>
                                                                                                <asp:ListItem Value="3">Tones</asp:ListItem>
                                                                                                <asp:ListItem Value="4">Other</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" ControlToValidate="ddledpinscap"
                                                                                                Display="None" ErrorMessage="Please Select Installed Capacity Unit" InitialValue="-- Select --"
                                                                                                SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black;">
                                                                                <asp:TextBox ID="txtedppercentage" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="Tr1" runat="server" visible="false">
                                                                <td align="center" colspan="9" style="padding: 5px; margin: 5px" valign="top" width="100%">
                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                        GridLines="Both" Visible="true" Width="60%">
                                                                        <RowStyle BackColor="#ffffff" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" ItemStyle-HorizontalAlign="Left" />
                                                                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity">
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                            <asp:BoundField DataField="Column4" HeaderText="Value" />
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                        <RowStyle BackColor="#F7F6F3" Font-Names="Arial" Font-Size="12px" ForeColor="#333333"
                                                                            HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" Font-Names="Arial" Font-Size="9px"
                                                                            ForeColor="White" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table style="font-weight: bold;" align="left" width="100%">
                                                                        <tr>
                                                                            <td colspan="9" style="padding: 5px; margin: 5px; width: 100%;" valign="top">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="9" style="padding: 5px; margin: 5px; text-align: left; width: 100%;"
                                                                                valign="top">
                                                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Font-Bold="True">FIXED CAPITAL INVESTMENT (In Rs.)<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <%--<table style="width: 100%;  font-weight: bold;">--%>
                                                            <tr id="trFixedcap" runat="server" visible="true" align="center">
                                                                <td colspan="9" style="width: 80%;">
                                                                    <table style="font-weight: bold;" align="center" width="80%">
                                                                        <%--<tr>
                                                                <td colspan="9" style="padding: 5px; margin: 5px" valign="top"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="9" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                    <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Font-Bold="True">FIXED CAPITAL INVESTMENT (In Rs.)<font color="red">*</font></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <table>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin white; border-left: solid thin black; border-top: solid thin black; background: #013161; color: white">Sl No</td>
                                                                            <td align="center" style="border: solid thin white; border-left: solid thin black; border-top: solid thin black; background: #013161; color: white" width="55%">Nature of
                                                                                <br />
                                                                                Assets </td>
                                                                            <td align="center" style="border: solid thin black; border-top: solid thin black; background: #013161; color: white">Value (in Rs.)</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin black; border-top: solid thin black; background: white; color: black; text-align: center">1</td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; background: white; color: black; text-align: left">Land</td>
                                                                            <td align="center" style="border: solid thin black; text-align: center">
                                                                                <asp:TextBox ID="txtlandexisting" runat="server" class="form-control txtbox" Height="30px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="txtlandexisting" ErrorMessage="Please enter Land Existing Enterprise" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin black; border-top: solid thin black; background: white; color: black; text-align: center">2</td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; background: white; color: black">Building</td>
                                                                            <td align="center" style="border: solid thin black; text-align: center">
                                                                                <asp:TextBox ID="txtbuildingexisting" runat="server" class="form-control txtbox" Height="30px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator90" runat="server" ControlToValidate="txtbuildingexisting" ErrorMessage="Please enter Building Existing Enterprise" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin black; border-top: solid thin black; background: white; color: black; text-align: center">3</td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; background: white; color: black; text-align: left">Plant &amp; Machinery</td>
                                                                            <td align="center" style="border: solid thin black">
                                                                                <asp:TextBox ID="txtplantexisting" runat="server" class="form-control txtbox" Height="30px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group" OnTextChanged="txtplantexisting_TextChanged"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="txtplantexisting" ErrorMessage="Please enter Plant &amp; Machinery Existing Enterprise" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td id="tdzxz" runat="server" visible="false">
                                                                    <table>
                                                                        <tr>
                                                                            <td id="Td1" runat="server" align="center" style="border: solid thin white; border-top: solid thin black; background: #013161; color: white" visible="false" colspan="2">Under Expansion/ Diversification Project</td>
                                                                            <td id="Td2" runat="server" align="center" style="border: solid thin white; border-right: solid thin black; border-top: solid thin black; background: #013161; color: white" visible="false" colspan="2">% of increase under
                                                                                <br />
                                                                                Expansion/Diversification</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td id="Td3" runat="server" align="center" style="border: solid thin black" visible="true" width="25%">
                                                                                <asp:TextBox ID="txtlandcapacity" runat="server" class="form-control txtbox" Height="30px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border-bottom: solid thin black; width: 1px">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="txtlandcapacity" ErrorMessage="Please enter Land Under Expansion/Diversification Project" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td id="Td4" runat="server" align="center" style="border: solid thin black" visible="true" width="25%">
                                                                                <asp:TextBox ID="txtlandpercentage" runat="server" class="form-control txtbox" Height="30px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator92" runat="server" ControlToValidate="txtlandpercentage" ErrorMessage="Please enter Land Percentage of increase under Expansion/Diversification" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td id="Td5" runat="server" align="center" style="border: solid thin black" visible="true" width="25%">
                                                                                <asp:TextBox ID="txtbuildingcapacity" runat="server" class="form-control txtbox" Height="30px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>

                                                                            </td>
                                                                            <td style="border-bottom: solid thin black; width: 1px">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="txtbuildingcapacity" ErrorMessage="Please enter Building Under Expansion/Diversification Project" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                                            <td id="Td6" runat="server" align="center" style="border: solid thin black" visible="true" width="25%">
                                                                                <asp:TextBox ID="txtbuildingpercentage" runat="server" class="form-control txtbox" Height="30px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator94" runat="server" ControlToValidate="txtbuildingpercentage" ErrorMessage="Please enter Building Percentage of increase under Expansion/Diversification" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td id="Td7" runat="server" align="center" style="border: solid thin black" visible="true" width="25%">
                                                                                <asp:TextBox ID="txtplantcapacity" runat="server" class="form-control txtbox" Height="30px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border-bottom: solid thin black; width: 1px">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator95" runat="server" ControlToValidate="txtplantcapacity" ErrorMessage="Please enter Plant &amp; Machinery Under Expansion/Diversification Project" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                                            <td id="Td8" runat="server" align="center" style="border: solid thin black" visible="true" width="25%">
                                                                                <asp:TextBox ID="txtplantpercentage" runat="server" class="form-control txtbox" Height="30px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator96" runat="server" ControlToValidate="txtplantpercentage" ErrorMessage="Please enter Plant &amp; Machinery Percentage of increase under Expansion/Diversification" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>--%>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin black; border-left: solid thin black;
                                                                                border-top: solid thin black; background: #013161; color: white">
                                                                                Sl.No
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; border-left: solid thin black;
                                                                                border-top: solid thin black; background: #013161; color: white">
                                                                                Nature of Assets
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; border-top: solid thin black;
                                                                                background: #013161; color: white">
                                                                                Value (in Rs.)
                                                                            </td>
                                                                            <td id="trFixedCapitalexpansion" runat="server" align="center" style="border: solid thin white;
                                                                                border-top: solid thin black; background: #013161; color: white" visible="false">
                                                                                Under Expansion/ Diversification Project
                                                                            </td>
                                                                            <td id="trFixedCapitalexpnPercent" runat="server" align="center" style="border: solid thin black;
                                                                                border-right: solid thin black; border-top: solid thin black; background: #013161;
                                                                                color: white" visible="false">
                                                                                % of increase under
                                                                                <br />
                                                                                Expansion/Diversification
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black;">
                                                                                1
                                                                            </td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; background: white;
                                                                                color: black; text-align: left">
                                                                                Land
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black; text-align: center">
                                                                                <asp:TextBox ID="txtlandexisting" runat="server" CssClass="text-center" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                                                    Height="25px" Width="190px" MaxLength="80" TabIndex="5" ValidationGroup="group"
                                                                                    AutoPostBack="True" OnTextChanged="txtlandexisting_TextChanged"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="txtlandexisting"
                                                                                    ErrorMessage="Please enter Land Existing Enterprise" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                    </td>--%>
                                                                            <td id="trFixedCapitalland" runat="server" align="center" style="border: solid thin black"
                                                                                visible="false">
                                                                                <asp:TextBox ID="txtlandcapacity" runat="server" CssClass="text-center" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group" AutoPostBack="True" OnTextChanged="txtlandcapacity_TextChanged"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="txtlandcapacity"
                                                                                    ErrorMessage="Please enter Land Under Expansion/Diversification Project" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                    </td>--%>
                                                                            <td id="txtbuildcapacityPercet" runat="server" align="center" style="border: solid thin black"
                                                                                visible="false">
                                                                                <asp:TextBox ID="txtlandpercentage" runat="server" CssClass="text-center" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="txtlandpercentage"
                                                                                    ErrorMessage="Please enter Land Percentage of increase under Expansion/Diversification"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                    </td>--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black;">
                                                                                2
                                                                            </td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; background: white;
                                                                                color: black">
                                                                                Building
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black; text-align: center">
                                                                                <asp:TextBox ID="txtbuildingexisting" runat="server" CssClass="text-center" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group" AutoPostBack="True" OnTextChanged="txtbuildingexisting_TextChanged"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="txtbuildingexisting"
                                                                                    ErrorMessage="Please enter Building Existing Enterprise" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black">
                                                                        </td>--%>
                                                                            <td id="trFixedCapitalBuilding" runat="server" align="center" style="border: solid thin black"
                                                                                visible="false">
                                                                                <asp:TextBox ID="txtbuildingcapacity" runat="server" CssClass="text-center" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    AutoPostBack="True" ValidationGroup="group" OnTextChanged="txtbuildingcapacity_TextChanged"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="txtbuildingcapacity"
                                                                                    ErrorMessage="Please enter Building Under Expansion/Diversification Project"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                        </td>--%>
                                                                            <td id="trFixedCapitBuildPercent" runat="server" align="center" style="border: solid thin black"
                                                                                visible="false">
                                                                                <asp:TextBox ID="txtbuildingpercentage" runat="server" CssClass="text-center" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="txtbuildingpercentage"
                                                                                    ErrorMessage="Please enter Building Percentage of increase under Expansion/Diversification"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                        </td>--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black;">
                                                                                3
                                                                            </td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; background: white;
                                                                                color: black; text-align: left">
                                                                                Plant &amp; Machinery
                                                                            </td>
                                                                            <td align="center" style="border: solid thin black">
                                                                                <asp:TextBox ID="txtplantexisting" runat="server" CssClass="text-center" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group" OnTextChanged="txtplantexisting_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtplantexisting"
                                                                                    ErrorMessage="Please enter Plant &amp; Machinery Existing Enterprise" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black">
                                                                        </td>--%>
                                                                            <td id="trFixedCapitalMach" runat="server" align="center" style="border: solid thin black"
                                                                                visible="false">
                                                                                <%-- <asp:TextBox ID="txtplantcapacity" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group" AutoPostBack="True" OnTextChanged="txtplantcapacity_TextChanged"></asp:TextBox>--%>
                                                                                <asp:TextBox ID="txtplantcapacity" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5" oncopy="return false" onpaste="return false" oncut="return false"
                                                                                    ValidationGroup="group" AutoPostBack="True" OnTextChanged="txtplantcapacity_TextChanged"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="revMemComment" runat="server" CssClass="validatorMemComment"
                                                                                    ControlToValidate="txtplantcapacity" ValidationExpression="^[a-zA-Z0-9]*$" Text="*"
                                                                                    ErrorMessage="Invalid character" ForeColor="Red" Display="Dynamic" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtplantcapacity"
                                                                                    ErrorMessage="Please enter Plant &amp; Machinery Under Expansion/Diversification Project"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                        </td>--%>
                                                                            <td id="trFixedCapitMachPercent" runat="server" align="center" style="border: solid thin black"
                                                                                visible="false">
                                                                                <asp:TextBox ID="txtplantpercentage" runat="server" CssClass="text-center" class="form-control txtbox" onpaste="return false" oncut="return false"
                                                                                    Height="25px" Width="190px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                                    ValidationGroup="group"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="txtplantpercentage"
                                                                                    ErrorMessage="Please enter Plant &amp; Machinery Percentage of increase under Expansion/Diversification"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator runat="server" id="valrNumberOfPreviousOwners"    ControlToValidate="txtplantpercentage"    
                                                                                     MinimumValue="0"    MaximumValue="999"    CssClass="input-error"    ErrorMessage="Please enter numbers only"    Display="Dynamic">
                                                                                </asp:RangeValidator>
                                                                            </td>
                                                                            <%--<td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                        </td>--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 20px; font-weight: bold;">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%;">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr id="trMSME_Expn_Percentage" runat="server" visible="false">
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label26" runat="server">Percentage of increase under expansion/diversification project<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtIncreasePercentage" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off"
                                                                                    MaxLength="5" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                Category&nbsp;: <span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td style="text-align: left;" align="left">
                                                                                &nbsp;&nbsp;
                                                                                <asp:Label ID="lblEnterpriseCategory" runat="server"> </asp:Label>
                                                                                <asp:HiddenField ID="HiddenFieldEnterpriseCategory" runat="server" />
                                                                                 <asp:HiddenField ID="HiddenIsMSME" runat="server" />
                                                                                <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="33px"
                                                                                    TabIndex="5" ValidationGroup="group" Width="180px" Visible="false">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td colspan="2">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCategory"
                                                                                    ErrorMessage="Please select Category" InitialValue="-- SELECT --" SetFocusOnError="true"
                                                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                    <td style="width: 100%;">
                                                                        <table style="width: 100%; font-weight: bold;">
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                    <asp:Label ID="lblMSMEapplicable" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="padding: 5px; margin: 5px; text-align: left;">As per your DCP you are eligible under: <span style="font-weight: bold; color: Red;">*</span>
                                                                                </td>
                                                                                <td style="text-align: left;" align="left">&nbsp;&nbsp;
                                                                                   <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" AutoPostBack="true" ID="rblMSMEorExisting" OnSelectedIndexChanged="rblMSMEorExisting_SelectedIndexChanged">
                                                                                       <asp:ListItem Text="MSME policy" Value="Y"></asp:ListItem>
                                                                                       <asp:ListItem Text="Earlier T-IDEA/T-PRIDE Schemes" Value="N"></asp:ListItem>
                                                                                   </asp:RadioButtonList>
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            <tr align="left">
                                                                <td style="width: 100%;" align="right">
                                                                    <table style="width: 100%;" align="center">
                                                                        <tr>
                                                                            <%-- <td colspan="3" width="100%" ></td>--%>
                                                                            <td align="right" colspan="4">
                                                                                <asp:Button ID="btntab2previous" runat="server" CssClass="btn btn-warning" Font-Size="Large"
                                                                                    ForeColor="White" Height="50px" OnClick="btntab2previous_Click" TabIndex="5"
                                                                                    Text="Previous" Width="150px" />
                                                                                &nbsp;&nbsp;&nbsp;
                                                                                <asp:Button ID="btntab2next" runat="server" CssClass="btn btn-warning" Font-Size="Large"
                                                                                    ForeColor="White" Height="50px" OnClick="btntab2next_Click" TabIndex="5" Text="Next"
                                                                                    Width="150px" />
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                        <asp:View ID="View3" runat="server">
                                            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid;
                                                font-weight: bold;">
                                                <tr>
                                                    <td>
                                                        <table style="width: 100%; font-weight: bold;" id="tblview3" runat="server" visible="false">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; height: 28px" valign="top" colspan="9">
                                                                </td>
                                                            </tr>
                                                            <tr id="trLabel12" runat="server">
                                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="9">
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True">Details of the Director(s)/ Partner(s) : <font color="red">*</font></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="9">
                                                                </td>
                                                            </tr>
                                                            <tr id="trdirectordetails" runat="server" visible="true">
                                                                <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="4">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                1
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label13" runat="server">Name <font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtnamedparter" runat="server" class="form-control txtbox" Height="28px"
                                                                                    TabIndex="5" onkeypress="Names()" Width="180px" ValidationGroup="group">
                                                                                </asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                            ControlToValidate="txtnamedparter" ErrorMessage="Please enter Existing Enterprise"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                3
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label14" runat="server">Community<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:DropDownList ID="ddlcommunity" runat="server" class="txtalignright" TabIndex="5"
                                                                                    Height="40px" Width="180px">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="1">General</asp:ListItem>
                                                                                    <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                                    <asp:ListItem Value="3">SC</asp:ListItem>
                                                                                    <asp:ListItem Value="4">ST</asp:ListItem>
                                                                                    <asp:ListItem Value="5">Minority</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%--<asp:TextBox ID="txtcommunity" runat="server" class="form-control txtbox"
                                                                                    Height="28px" MaxLength="40" TabIndex="5" onkeypress="Names()" Width="180px"
                                                                                    ValidationGroup="group"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                            ControlToValidate="txtcommunity" ErrorMessage="Please enter Under Expansion/Diversification Project"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                5&nbsp;
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label11" runat="server">Designation<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                                <asp:DropDownList ID="ddlAuthorisedDesignation" runat="server" class="form-control txtbox"
                                                                                    TabIndex="5" Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlAuthorisedDesignation_SelectedIndexChanged">
                                                                                    <asp:ListItem Value="0">--Designation--</asp:ListItem>
                                                                                    <asp:ListItem Value="GM">GM</asp:ListItem>
                                                                                    <asp:ListItem Value="AGM">AGM</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="ddlAuthorisedDesignation"
                                                                                    ErrorMessage="Please Select Authorised Designation" SetFocusOnError="true" InitialValue="--Designation--" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trdesignation" runat="server" visible="false">
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td style="width: 200px;">
                                                                                <asp:Label ID="lbldesignationOther" runat="server">Other</asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                <asp:TextBox ID="txtdesignationOther" runat="server" class="form-control txtbox"
                                                                                    Height="28px" TabIndex="5" Width="180px"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                            ControlToValidate="txtpercentage" ErrorMessage="Please enter Quantity"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top" colspan="4">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                2
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label15" runat="server">Share %<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtshare" runat="server" class="form-control txtbox" Height="28px"
                                                                                    TabIndex="5" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                            ControlToValidate="txtshare" ErrorMessage="Please enter Existing Enterprise"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                4
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label8" runat="server">Gender<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                                <asp:DropDownList ID="ddlgender2" runat="server" class="form-control txtbox" TabIndex="5"
                                                                                    Height="33px" Width="180px">
                                                                                    <asp:ListItem Value="0">--Gender--</asp:ListItem>
                                                                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                                                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                                                                    <asp:ListItem Value="T">Transgender</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="ddlgender2"
                                                                                    ErrorMessage="Please Select Gender" SetFocusOnError="true" InitialValue="--Gender--" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trdirpercent" runat="server" visible="false">
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                6
                                                                            </td>
                                                                            <td style="width: 200px;">
                                                                                <asp:Label ID="Label16" runat="server">%<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                <asp:TextBox ID="txtpercentage" runat="server" class="form-control txtbox" Height="28px"
                                                                                    onkeypress="DecimalOnly()" TabIndex="5" Width="180px"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                            ControlToValidate="txtpercentage" ErrorMessage="Please enter Quantity"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 55px">
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:Button ID="Button5" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                                    TabIndex="5" Text="Add New" Width="72px" OnClick="Button5_Click" />
                                                                            </td>
                                                                            <td align="right">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="Button6" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                                                                    Height="28px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="8">
                                                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="Both"
                                                                        Width="60%" Visible="false" DataKeyNames="intLineofActivityMid" OnRowDataBound="GridView3_RowDataBound"
                                                                        OnRowDeleting="GridView3_RowDeleting">
                                                                        <RowStyle BackColor="#ffffff" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Column1" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column2" HeaderText="Community" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column7" HeaderText="Gender" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column3" HeaderText="Share %" HeaderStyle-HorizontalAlign="Center" />
                                                                            <%--<asp:BoundField DataField="Column5" HeaderText="Authorised Signatory" HeaderStyle-HorizontalAlign="Center" />--%>
                                                                            <asp:BoundField DataField="Column6" HeaderText="Designation" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column4" HeaderText="%" Visible="false" />
                                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                        </Columns>
                                                                        <%--<FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#013161" />
                                                                        <AlternatingRowStyle BackColor="White" />--%>
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                            HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 20px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="height: 10px">
                                                                    <asp:Label ID="lblpartner" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="8">
                                                                    <asp:GridView ID="gvdirector2" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                        GridLines="Both" Width="60%">
                                                                        <RowStyle BackColor="#ffffff" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Column1" HeaderText="Name" />
                                                                            <asp:BoundField DataField="Column2" HeaderText="Community" />
                                                                            <asp:BoundField DataField="Column7" HeaderText="Gender" />
                                                                            <asp:BoundField DataField="Column3" HeaderText="Share %" />
                                                                            <%-- <asp:BoundField DataField="AuthorisedSign" HeaderText="Authorised Signatory" /> --%>
                                                                            <asp:BoundField DataField="Authdesignation" HeaderText="Designation" />
                                                                            <asp:BoundField DataField="Column4" HeaderText="%" Visible="false" />
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                            HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="tblTransportServiceAadhaar" runat="server" visible="false">
                                                            <tr>
                                                                <td>
                                                                    Aadhaar Details for Transport Activity
                                                                </td>
                                                                <td style="width: 15px" align="center">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    Enter number of family members
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNoofAadhar" Width="50px" class="form-control txtbox" runat="server"
                                                                        AutoPostBack="true" OnTextChanged="txtNoofAadhar_TextChanged"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="grd_dynamic" runat="server" AutoGenerateColumns="false" CellPadding="1"
                                                                        CellSpacing="1" Width="100%" OnRowCommand="grd_dynamic_RowCommand" OnRowDataBound="grd_dynamic_RowDataBound">
                                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    Sno
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <b>
                                                                                        <%# Container.DataItemIndex+1 %></b>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>
                                                                                    Aadhaar Card Number
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtAadhaar" MaxLength="12" CssClass="form-control" placeholder="Aadhaar Number"
                                                                                        Width="150px" onpaste="return false" AutoPostBack="true" onchange="validateVerhoeff(this)"
                                                                                        autocomplete="off" runat="server"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtAadhaar"
                                                                                        ValidationExpression="^[0-9]*\.?[0-9]+$" Display="Dynamic" ErrorMessage="Only Numbers"
                                                                                        ForeColor="Red" runat="server"></asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtAadhaar"
                                                                                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle VerticalAlign="Middle" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-VerticalAlign="Middle">
                                                                                <HeaderTemplate>
                                                                                    Aadhaar Card Copy
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updFU">
                                                                                        <ContentTemplate>
                                                                                            <asp:FileUpload ID="fupAadhaar" runat="server" EnableViewState="true" />
                                                                                            <asp:Button ID="btnUploadAadhaar" CssClass="btn btn-xs btn-warning" runat="server"
                                                                                                Text="Upload" CommandName="Click" CausesValidation="false" />
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:PostBackTrigger ControlID="btnUploadAadhaar" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                    <br />
                                                                                    <asp:Label ID="lblAttachedFileName1" runat="server" Font-Bold="true" ForeColor="Green"
                                                                                        Text="Aadhaar File" Visible="false" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle VerticalAlign="Middle" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#B9D684" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label10" runat="server">Authorised Signatory<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtAuthorisedSign" runat="server" class="txtalignright" TabIndex="5"
                                                                        Height="30px" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label6" runat="server">Authorised Signatory Designation<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                    <asp:DropDownList ID="ddlAuthorisedSignDesignation" runat="server" class="form-control txtbox"
                                                                        Enabled="true" TabIndex="5" Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlAuthorisedSignDesignation_SelectedIndexChanged">
                                                                        <asp:ListItem Value="NULL">--Designation--</asp:ListItem>
                                                                        <asp:ListItem Value="GM">GM</asp:ListItem>
                                                                        <asp:ListItem Value="AGM">AGM</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="ddlAuthorisedDesignation"
                                                                                    ErrorMessage="Please Select Authorised Designation" SetFocusOnError="true" InitialValue="--Designation--" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr id="trAuthSignatoryDesignation" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 200px;">
                                                                    <asp:Label ID="Label24" runat="server">Other</asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtAuthSignOtherDesignation" runat="server" class="form-control txtbox"
                                                                        Height="28px" TabIndex="5" onkeypress="Names()" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <table style="width: 100%; font-weight: bold;" id="Table1" runat="server" align="center">
                                                            <tr>
                                                                <td style="width: 20px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 150px" align="left">
                                                                    Is power applicable
                                                                </td>
                                                                <td align="left">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlIspowApplicable" runat="server" Visible="true" Height="28px"
                                                                        Width="180px" TabIndex="5" AutoPostBack="True" OnSelectedIndexChanged="ddlIspowApplicable_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" ControlToValidate="ddlIspowApplicable"
                                                                        ErrorMessage="Please select is power applicable" InitialValue="-- Select --"
                                                                        ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trpower" runat="server" visible="false">
                                                                <td>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">
                                                                    <strong>Power Details
                                                                </td>
                                                                <td align="left">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlPowerStatus" runat="server" Visible="false" Height="55px"
                                                                        Width="180px" TabIndex="5" AutoPostBack="True" OnSelectedIndexChanged="ddlPowerStatus_SelectedIndexChanged1">
                                                                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="New Industry"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Expansion/Diversification"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="ddlPowerStatus"
                                                                        ErrorMessage="Please select Power Status" InitialValue="-- Select --" ValidationGroup="group"
                                                                        SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="width: 90%; font-weight: bold;" id="tblpower1" runat="server" visible="false"
                                                            align="center">
                                                            <tr>
                                                                <td style="height: 15px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="9" style="border: solid thin black; background: #013161; color: white;
                                                                    height: 40px" align="left">
                                                                    <asp:Label ID="lblpowerHEAD" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 30px; border: solid thin black; color: black; border: solid thin black"
                                                                    align="center">
                                                                    1
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left; width: 150px;">
                                                                    Power Released Date <span style="font-weight: normal; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                                                    <asp:TextBox ID="txtNewPowerReleaseDate" runat="server" class="txtalignright" TabIndex="5"
                                                                        Height="28px" Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtNewPowerReleaseDate"
                                                                        ErrorMessage="Please Select Power Release Date" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; width: 30px; color: black; text-align: center;">
                                                                    2
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left; width: 130px;">
                                                                    Contracted load <span style="font-weight: normal; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                                                    <asp:TextBox ID="txtNewContractedLoad" runat="server" class="txtalignright" Height="28px"
                                                                        MaxLength="40" TabIndex="5" ValidationGroup="group" onkeypress="DecimalOnly()"
                                                                        Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtNewContractedLoad"
                                                                        ErrorMessage="Please Enter Contracted load " SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                                                    Unit &nbsp;&nbsp;
                                                                    <asp:DropDownList ID="ddlContractpowerunit" runat="server" TabIndex="5">
                                                                        <asp:ListItem Value="0">-- Select Unit --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator81" runat="server" ControlToValidate="ddlContractpowerunit"
                                                                        ErrorMessage="Please select Power Unit " SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: solid thin black; color: black; text-align: center;">
                                                                    3
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    Service Connection Number<span style="font-weight: normal; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                                                    <asp:TextBox ID="txtServiceConnectionNumber" runat="server" class="txtalignright"
                                                                        Height="28px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtServiceConnectionNumber"
                                                                        ErrorMessage="Please Enter Service Connection Number" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: center;">
                                                                    4
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    Connected load <span style="font-weight: normal; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                                                    <asp:TextBox ID="txtNewConnectedLoad" runat="server" class="txtalignright" Height="28px"
                                                                        TabIndex="5" Width="180px" onkeypress="DecimalOnly()" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server" ControlToValidate="txtNewConnectedLoad"
                                                                        ErrorMessage="Please Enter Connected load (In HP)" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                                                    Unit &nbsp;&nbsp;
                                                                    <asp:DropDownList ID="ddlConnectPowUnit" runat="server">
                                                                        <asp:ListItem Value="0">-- Select Unit --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator82" runat="server" ControlToValidate="ddlConnectPowUnit"
                                                                        ErrorMessage="Please select Connected Power Unit " SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: solid thin white; color: black; text-align: left;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="width: 90%; font-weight: bold;" id="tblpower2" runat="server" visible="false"
                                                            align="center">
                                                            <tr>
                                                                <td colspan="10" style="border: solid thin black; background: #013161; color: white;
                                                                    height: 40px" align="left">
                                                                    <asp:Label ID="lblexistingpower" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 30px; text-align: center; border: solid thin black; color: black;">
                                                                    1
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    Power Released Date <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    <asp:TextBox ID="txtExistingPowerReleaseDate" runat="server" class="txtalignright"
                                                                        Height="28px" Width="180px" TabIndex="5"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtExistingPowerReleaseDate"
                                                                        ErrorMessage="Please Select Existing Power Release Date" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; width: 30px; text-align: center;">
                                                                    2
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    Contracted load <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    <asp:TextBox ID="txtExistingContractedLoad" runat="server" class="txtalignright"
                                                                        Height="28px" MaxLength="40" TabIndex="5" ValidationGroup="group" onkeypress="DecimalOnly()"
                                                                        Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtExistingContractedLoad"
                                                                        ErrorMessage="Please Enter Contracted load (In HP)" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                                                    <asp:DropDownList ID="ddlExsitContractPowerUnit" runat="server" TabIndex="5">
                                                                        <asp:ListItem>-- Select Unit --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator83" runat="server" ControlToValidate="ddlExsitContractPowerUnit"
                                                                        ErrorMessage="Please select expansion Power Unit " SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td style="border: solid thin black; color: black; text-align: center;">
                                                                    </td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: solid thin black; color: black; text-align: center;" class="auto-style11">
                                                                    3
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;" class="auto-style12">
                                                                    Service Connection Number<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;" class="auto-style12">
                                                                    <asp:TextBox ID="txtExistingServiceConnectionNO" runat="server" class="txtalignright"
                                                                        Height="28px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtExistingServiceConnectionNO"
                                                                        ErrorMessage="Please Enter Service Connection Number" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td class="auto-style12">
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: center;" class="auto-style11">
                                                                    4
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;" class="auto-style12">
                                                                    Connected load <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;" class="auto-style12">
                                                                    <asp:TextBox ID="txtExistingConnectedLoad" runat="server" class="txtalignright" Height="28px"
                                                                        TabIndex="5" Width="180px" onkeypress="DecimalOnly()" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtExistingConnectedLoad"
                                                                        ErrorMessage="Please Enter Existing Contracted loan" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td class="auto-style12">
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: center;" class="auto-style13">
                                                                    <asp:DropDownList ID="ddlExistConnectPowerUnit" runat="server">
                                                                        <asp:ListItem>-- Select Unit --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator84" runat="server" ControlToValidate="ddlExistConnectPowerUnit"
                                                                        ErrorMessage="Please select expansion Power Unit " SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td class="auto-style12">
                                                                    </td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="8" style="border: solid thin black; background: #013161; color: white;
                                                                    height: 40px" align="left">
                                                                    <asp:Label ID="lblexpandiverpower" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    1
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    Power Released Date <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    <asp:TextBox ID="txtExpanDiverPowerReleaseDate" runat="server" class="txtalignright"
                                                                        Height="28px" Width="180px" TabIndex="5"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtExpanDiverPowerReleaseDate"
                                                                        ErrorMessage="Please Select Existing Power Release Date" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    2
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    Contracted load <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    <asp:TextBox ID="txtExpanDiverContractedLoad" runat="server" class="txtalignright"
                                                                        Height="28px" MaxLength="40" TabIndex="5" ValidationGroup="group" onkeypress="DecimalOnly()"
                                                                        Width="180px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtExpanDiverContractedLoad"
                                                                        ErrorMessage="Please Enter Diversification Contracted loan" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                                                    <asp:DropDownList ID="ddlDiversPowContrUnit" runat="server">
                                                                        <asp:ListItem Value="0">-- Select Unit --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator85" runat="server" ControlToValidate="ddlDiversPowContrUnit"
                                                                        ErrorMessage="Please select Diversification Power Unit " SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    3
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    Service Connection Number<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    <asp:TextBox ID="txtExpanDiverServiceConnectionNO" runat="server" class="txtalignright"
                                                                        Height="28px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtExpanDiverServiceConnectionNO"
                                                                        ErrorMessage="Please Enter Service Connection No." SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    4&nbsp;
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    Connected load <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="border: solid thin black; color: black; text-align: left;">
                                                                    <asp:TextBox ID="txtExpanDiverConnectedLoad" runat="server" class="txtalignright"
                                                                        Height="28px" TabIndex="5" Width="180px" onkeypress="DecimalOnly()" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtExpanDiverConnectedLoad"
                                                                        ErrorMessage="Please Enter Diversification Connected Load." SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                                <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                                                    <asp:DropDownList ID="ddlDiverpowConnectUnit" runat="server">
                                                                        <asp:ListItem Value="0">-- Select Unit --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator86" runat="server" ControlToValidate="ddlDiverpowConnectUnit"
                                                                        ErrorMessage="Please select Diversification Power Unit " SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td>
                                                                    </td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td colspan="8">
                                                                    <table style="width: 680px;" align="center">
                                                                        <tr id="triflocal" runat="server">
                                                                            <%--<td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" align="center" colspan="9">Employment
                                                                            </td>--%>
                                                                           <%-- <td style="background: white; color: black; font-weight: bold; width: 100px; height: 30px"
                                                                                align="left" colspan="9">
                                                                                Employment--%>
                                                                            <td style="background: white; color: black; font-weight: bold; "
                                                                                align="left" colspan="6" class="auto-style17">Whether applicant willing to apply for additional incentives provided under local employment policy, as per G.O. MS No. 20 industries and commerce IP and INF department dated :13.11.2020.
                                                                            </td>
                                                                             <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style19">
                                                                    <asp:CheckBox ID="cblocalemp" runat="server" AutoPostBack="true" OnCheckedChanged="cblocalemp_CheckedChanged"
                                                                        TabIndex="1" Text="     " />
                                                                                 </td>
                                                                               </tr>
                                                                        <tr id="trlocalempdtls" runat="server" visible="false">
                                                                            <td style="background: white; color: black; font-weight: bold; width: 100px; height: 30px"
                                                                                align="left" colspan="2"><label>Local Employment Details&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</label>
                                                                            </td>
                                                                            </tr>
                                                                     

                                                                        <tr style="width:100px">
                                                                            <td style="width:200px" colspan="5">

                                                                            <table ID="tbl1" runat="server" style="width:200px" >
                                                                            <tr style="width:100px">
<%--                                                                            <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 60px;"
                                                                                align="center">&nbsp;</td>
                                                                            <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 60px;"
                                                                                align="center">&nbsp;</td>
                                                                            <td style="border-left: thin solid black; border-bottom: thin solid black; border-top: thin solid black; border-right: thin solid white; background: #013161; color: white; "
                                                                                align="left" class="auto-style20" colspan="2">&nbsp;</td>
                                                                             <td style="border-left: thin solid black; border-bottom: thin solid black; border-top: thin solid black; border-right: thin solid white; background: #013161; color: white; "
                                                                                align="left" class="auto-style20" colspan="2">&nbsp;</td>--%>
                                                                       
                                                                            </tr>
                                                                                <tr id="trlocalempdtlsheader" runat="server" visible="false">
                                                                             <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 60px;"
                                                                                align="center">Sl.No
                                                                            </td>
                                                                            <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 200px;"
                                                                                align="center">Local Employment</td>
                                                                            <td style="border-left: thin solid black; border-bottom: thin solid black; border-top: thin solid black; border-right: thin solid white; background: #013161; color: white; "
                                                                                align="left" class="auto-style20">Total Male(Nos)
                                                                            </td>
                                                                            <td style="border: solid thin white; background: #013161; color: white; border: solid thin black; "
                                                                                align="left" class="auto-style21">Total Female(Nos)
                                                                            </td>
                                                                             <td style="border-left: thin solid black; border-bottom: thin solid black; border-top: thin solid black; border-right: thin solid white; background: #013161; color: white; "
                                                                                align="left" class="auto-style20">Local Male(Nos)
                                                                            </td>
                                                                            <td style="border: solid thin white; background: #013161; color: white; border: solid thin black; width: 200px;"
                                                                                align="left">Local Female(Nos)
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trlocalempdtlsskilled" runat="server" visible="false">
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">1
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 250px;" >Skilled workers
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; "
                                                                                align="center" class="auto-style20">
                                                                                <asp:TextBox ID="txtskilledmaletotal" runat="server" class="txtalignright" Height="28px" Width="75px"
                                                                                    onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator94" runat="server" ControlToValidate="txtstaffMale"
                                                                                    ErrorMessage="Please Enter Number of Male Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; "
                                                                                align="center" class="auto-style21">
                                                                                <asp:TextBox ID="txtskilledfemaletotal" runat="server" class="txtalignright" Height="28px" Width="75px"
                                                                                    onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator95" runat="server" ControlToValidate="txtfemale"
                                                                                    ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                                                align="center">
                                                                                <asp:TextBox ID="txtskilledmalelocal" runat="server" class="txtalignright" Height="28px" Width="75px"
                                                                                    onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator98" runat="server" ControlToValidate="txtfemale"
                                                                                    ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                                                align="center">
                                                                                <asp:TextBox ID="txtskilledfemalelocal" runat="server" class="txtalignright" Height="28px" Width="75px"
                                                                                    onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ControlToValidate="txtfemale"
                                                                                    ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        
                                                                        <tr id="trlocalempdtlssemskilled" runat="server" visible="false">
                                                                            <td align="center" style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">2
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 250px;">Semi-skilled workers
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; "
                                                                                align="center" class="auto-style20">
                                                                                <asp:TextBox ID="txtsemiskilledmaletotal" runat="server" class="txtalignright" Height="28px" Width="75px"
                                                                                    onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator96" runat="server" ControlToValidate="txtstaffMale"
                                                                                    ErrorMessage="Please Enter Number of Male Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; "
                                                                                align="center" class="auto-style21">
                                                                                <asp:TextBox ID="txtsemiskilledfemaletotal" runat="server" class="txtalignright" Height="28px" Width="75px"
                                                                                    onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator97" runat="server" ControlToValidate="txtfemale"
                                                                                    ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                                                align="center">
                                                                                <asp:TextBox ID="txtsemiskilledmalelocal" runat="server" class="txtalignright" Height="28px" Width="75px"
                                                                                    onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator100" runat="server" ControlToValidate="txtfemale"
                                                                                    ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                                                align="center">
                                                                                <asp:TextBox ID="txtsemiskilledfemalelocal" runat="server" class="txtalignright" Height="28px" Width="75px"
                                                                                    onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator101" runat="server" ControlToValidate="txtfemale"
                                                                                    ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                            </table>
                                                                         </td>
                                                                                </tr>
                                                                            </td>
                                                                        </tr>
                                                            <tr>                             
                                                                            <td style="background: white; color: black; font-weight: bold; "
                                                                                align="left" colspan="7" class="auto-style18">Employment&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 60px;">Sl.No </td>
                                                                            <td align="center" style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 250px;">Cadare </td>
                                                                            <td align="left" style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 200px;">Male(Nos) </td>
                                                                            <td align="left" style="border: solid thin white; background: #013161; color: white; border: solid thin black; width: 200px;">Female(Nos) </td>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 20px;">
                                                                                1
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 250px;">
                                                                                Management & Staff
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 200px;" align="center">
                                                                                <asp:TextBox ID="txtstaffMale" runat="server" Height="28px" TabIndex="5" Width="200px"
                                                                                    onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtstaffMale"
                                                                                    ErrorMessage="Please Enter Number of Male Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 200px;" align="center">
                                                                                <asp:TextBox ID="txtfemale" runat="server" class="txtalignright" Height="28px" Width="200px"
                                                                                    onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtfemale"
                                                                                    ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 20px;">
                                                                                2
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 250px;">
                                                                                Supervisory
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 200px;">
                                                                                <asp:TextBox ID="txtsupermalecount" runat="server" class="txtalignright" Height="28px"
                                                                                    Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" align="center"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtsupermalecount"
                                                                                    ErrorMessage="Please Enter Number of Supervisory Male" SetFocusOnError="true"
                                                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 200px;" align="center">
                                                                                <asp:TextBox ID="txtsuperfemalecount" runat="server" class="txtalignright" Height="28px"
                                                                                    Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtsuperfemalecount"
                                                                                    ErrorMessage="Please Enter Number of Supervisory FeMale" SetFocusOnError="true"
                                                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 20px;">
                                                                                3
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 250px;">
                                                                                Skilled workers
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 200px;" align="center">
                                                                                <asp:TextBox ID="txtSkilledWorkersMale" runat="server" class="txtalignright" Height="28px"
                                                                                    Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtSkilledWorkersMale"
                                                                                    ErrorMessage="Please Enter Number of Skilled workers Male" SetFocusOnError="true"
                                                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 200px;">
                                                                                <asp:TextBox ID="txtSkilledWorkersFemale" runat="server" class="txtalignright" Height="28px"
                                                                                    Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtSkilledWorkersFemale"
                                                                                    ErrorMessage="Please Enter Number of Skilled workers FeMale" SetFocusOnError="true"
                                                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 20px;">
                                                                                4
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 200px;">
                                                                                Semi-skilled workers
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 200px;" align="center">
                                                                                <asp:TextBox ID="txtSemiSkilledWorkersMale" runat="server" class="txtalignright"
                                                                                    Height="28px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtSemiSkilledWorkersMale"
                                                                                    ErrorMessage="Please Enter Number of Semi-skilled workers Male" SetFocusOnError="true"
                                                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black;
                                                                                width: 200px;">
                                                                                <asp:TextBox ID="txtSemiSkilledWorkersFemale" runat="server" class="txtalignright"
                                                                                    Height="28px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtSemiSkilledWorkersFemale"
                                                                                    ErrorMessage="Please Enter Number of Semi-skilled workers FeMale" SetFocusOnError="true"
                                                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 20px; font-weight: bold;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td colspan="9">
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Button Text="Previous" CssClass="btn btn-warning" Height="50px" Width="150px"
                                                                        Font-Size="Large" ForeColor="White" TabIndex="5" ID="btntab3previous" runat="server"
                                                                        OnClick="btntab3previous_Click" />
                                                                    &nbsp;&nbsp;&nbsp
                                                                    <asp:Button Text="Next" CssClass="btn btn-warning" Height="50px" Width="150px" Font-Size="Large"
                                                                        TabIndex="5" ForeColor="White" ID="btntab3next" runat="server" OnClick="btntab3next_Click" />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                        <asp:View ID="View4" runat="server">
                                            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid;
                                                font-weight: bold;">
                                                <tr>
                                                    <td colspan="9">
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9">
                                                                    Implementation Steps Taken - Project Finance
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 100%;" colspan="9">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                Have you availed Term Loan:<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px;">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:DropDownList ID="ddlIsTermLoanAvailed" runat="server" class="form-control txtbox"
                                                                                    Height="33px" MaxLength="80" TabIndex="5" ValidationGroup="Save" Width="180px"
                                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlIsTermLoanAvailed_SelectedIndexChanged">
                                                                                    <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="ddlIsTermLoanAvailed"
                                                                                    InitialValue="0" ErrorMessage="Please Select Term Loan Availability" SetFocusOnError="true"
                                                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%;" colspan="9">
                                                                    <table style="width: 100%; font-weight: bold;" id="tblTermLoanDtls" runat="server"
                                                                        visible="false">
                                                                        <tr id="trTermLoanLine1" runat="server">
                                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                                1
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                Term Loan No<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:DropDownList ID="ddlTermLoanNo" runat="server" class="form-control txtbox" Height="33px"
                                                                                    MaxLength="40" TabIndex="5" ValidationGroup="group" Width="180px">
                                                                                    <asp:ListItem Value="--Select--" Text="Select Term Loan Type"></asp:ListItem>
                                                                                    <asp:ListItem Value="TermLoan1" Text="Term Loan1"></asp:ListItem>
                                                                                    <asp:ListItem Value="TermLoan2" Text="Term Loan2"></asp:ListItem>
                                                                                    <asp:ListItem Value="TermLoan3" Text="Term Loan3"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator89" runat="server" ControlToValidate="ddlTermLoanNo"
                                                                                    ErrorMessage="Please Select Term Loan No ." SetFocusOnError="true" ValidationGroup="group1"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                                2
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">
                                                                                Date of application for Term Loan<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txttermload" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Width="180px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txttermload"
                                                                                    ErrorMessage="Please Enter Term Loan Application Date." SetFocusOnError="true"
                                                                                    ValidationGroup="group1" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trTermLoanLine2" runat="server">
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                3
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                Name of the Institution<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtnmofinstitution" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="80" TabIndex="5" onkeypress="Names()" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtnmofinstitution"
                                                                                    ErrorMessage="Please Enter Name of the Institution" SetFocusOnError="true" ValidationGroup="group1"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                                4
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                Term Loan Sanctioned reference No.<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtsactionedloan" runat="server" class="form-control txtbox" TabIndex="5"
                                                                                    Height="28px" Width="180px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtsactionedloan"
                                                                                    ErrorMessage="Please Enter Term Loan Sanctioned reference No." SetFocusOnError="true"
                                                                                    ValidationGroup="group1" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trTermLoanLine3" runat="server">
                                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                                5
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                Term Loan Sanctioned Date<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                :
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtdatesome" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Width="180px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtdatesome"
                                                                                    ErrorMessage="Please Enter Term Loan Sanctioned Date." SetFocusOnError="true"
                                                                                    ValidationGroup="group1" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                                6
                                                                            </td>
                                                                            <td align="left">
                                                                                Term Loan Released Date<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td align="right">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtTermLoanReleasedDate" runat="server" class="form-control txtbox"
                                                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Width="180px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="txtTermLoanReleasedDate"
                                                                                    ErrorMessage="Please Enter Term Loan Released Date." SetFocusOnError="true" ValidationGroup="group1"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                           <tr id="trTermLoanLine7" runat="server" visible="false">
    <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">8
    </td>
    <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">Loan Amount</td>
    <td class="style21" style="padding: 5px; margin: 5px">:
    </td>
    <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="txtLoanAmount" runat="server" class="form-control txtbox" Height="28px"
            MaxLength="25" TabIndex="5" ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator105" runat="server" ControlToValidate="txtLoanAmount"
            ErrorMessage="Please Loan Amount" ValidationGroup="group" SetFocusOnError="true"
            Display="None">*</asp:RequiredFieldValidator>
    </td>
    <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">9
    </td>
    <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">Amount sanctioned in Existing term loan</td>
    <td style="padding: 5px; margin: 5px">:
    </td>
    <td style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="txtExistingSacnctionedloan" runat="server" class="form-control txtbox"
            Height="28px" MaxLength="30" TabIndex="5" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px" ></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server" ControlToValidate="txtExistingSacnctionedloan"
            ErrorMessage="Please Enter Loan/Aggrement Account Number" ValidationGroup="group1"
            SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
    </td>
</tr>
<tr id="trTermLoanLine8" runat="server" visible="false">
    <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">9.
    </td>
    <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">Term Loan Released Amount(Rs)</td>
    <td class="style21" style="padding: 5px; margin: 5px">:
    </td>
    <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
        <asp:TextBox ID="txtLoanReleased" onkeypress="NumberOnly()" runat="server" class="form-control txtbox" Height="28px"
            MaxLength="25" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator107" runat="server" ControlToValidate="txtLoanReleased"
            ErrorMessage="Please Loan Amount" ValidationGroup="group1" SetFocusOnError="true"
            Display="None">*</asp:RequiredFieldValidator>
    </td>

</tr>                                                                               
                                                                        
                                                                        <tr id="trTermLoanLine6" runat="server">
                                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:Button ID="btnTermloanAdd" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                    Height="28px" TabIndex="5" Text="Add New" Width="72px" OnClick="btnTermloanAdd_Click" />
                                                                            </td>
                                                                            <td align="right">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btnTermLoanClear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                                                                    Height="28px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trTermLoanLine4" runat="server">
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="9">
                                                                                <asp:GridView ID="GVTermLoandtls" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="Both"
                                                                                    Width="60%" Visible="false" OnRowDataBound="GVTermLoandtls_RowDataBound" DataKeyNames="intLineofActivityMid"
                                                                                    OnRowDeleting="GVTermLoandtls_RowDeleting">
                                                                                    <RowStyle BackColor="#ffffff" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Column1" HeaderText="Term Loan No" HeaderStyle-HorizontalAlign="Center" />
                                                                                        <asp:BoundField DataField="Column2" HeaderText="Application Date" HeaderStyle-HorizontalAlign="Center" />
                                                                                        <asp:BoundField DataField="Column3" HeaderText="Institute Name" HeaderStyle-HorizontalAlign="Center" />
                                                                                        <asp:BoundField DataField="Column4" HeaderText="Term Loan Sanctioned Date" HeaderStyle-HorizontalAlign="Center" />
                                                                                        <asp:BoundField DataField="Column7" HeaderText="Term Loan Sanctioed Reference No"  HeaderStyle-HorizontalAlign="Center" />
                                                                                        <asp:BoundField DataField="Column6" HeaderText="Term Loan Released Date" HeaderStyle-HorizontalAlign="Center" />
                                                                                        <asp:BoundField DataField="Column5" HeaderText="Loan Amount" HeaderStyle-HorizontalAlign="Center" />
                                                                                         <asp:BoundField DataField="Column8" HeaderText="Amount sanctioned in Existing term loan" HeaderStyle-HorizontalAlign="Center" />
                                                                                         <asp:BoundField DataField="Column9" HeaderText="Amount Released" HeaderStyle-HorizontalAlign="Center" />
                                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                                        <asp:BoundField DataField="Createdby" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="IncentveID" HeaderText="Incentive Id" Visible="false" />
                                                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                                    </Columns>
                                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                                        HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                                        Font-Names="Arial" Font-Size="9px" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="trTermLoanLine5" runat="server">
                                                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="9">
                                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="Both"
                                                                        Width="60%" Visible="false">
                                                                        <RowStyle BackColor="#ffffff" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Column1" HeaderText="Term Loan No" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column2" HeaderText="Application Date" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column3" HeaderText="Institute Name" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column4" HeaderText="Term Loan Sanctioned Date" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column7" HeaderText="Term Loan Sanctioed Reference No"  HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column6" HeaderText="Term Loan Released Date" HeaderStyle-HorizontalAlign="Center" />
                                                                             <asp:BoundField DataField="Column5" HeaderText="Loan Amount" HeaderStyle-HorizontalAlign="Center" />
                                                                             <asp:BoundField DataField="Column8" HeaderText="Amount sanctioned in Existing term loan" HeaderStyle-HorizontalAlign="Center" />
                                                                             <asp:BoundField DataField="Column9" HeaderText="Amount Released" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Createdby" HeaderText="Created By" Visible="false" />
                                                                            <asp:BoundField DataField="IncentveID" HeaderText="Incentive Id" Visible="false" />
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                            HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr id="tris1" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Have you availed subsidy earlier<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 1px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlsubsidy" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="80" TabIndex="5" ValidationGroup="Save" Width="180px" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlsubsidy_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="ddlsubsidy"
                                                                        ErrorMessage="Please Select availed subsidy" SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="9">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="10">
                                                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Font-Bold="True">Approved/Estimated projected cost, term loan sanctioned and released, assets acquired etc<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="9" style="padding: 5px; margin: 5px" valign="top">
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            &nbsp;&nbsp;&nbsp;Name of Asset&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            Approved Project
                                                                                            <br />
                                                                                            Cost (In Rs.)
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            Loan Sanctioned
                                                                                            <br />
                                                                                            (In Rs.)
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            Equity from
                                                                                            <br />
                                                                                            the promoters
                                                                                            <br />
                                                                                            (In Rs.)
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            Loan Amount
                                                                                            <br />
                                                                                            Released (In Rs.)
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            Value of assets (as
                                                                                            <br />
                                                                                            certified by financial<br />
                                                                                            institution) (In Rs.)
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            Value of assets certified
                                                                                            <br />
                                                                                            by Chartered Accoutant
                                                                                            <br />
                                                                                            (In Rs.)
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            1
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            2&nbsp;
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            3
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            4
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            5
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            6
                                                                                        </td>
                                                                                        <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                            7
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            Land
                                                                                        </td>
                                                                                        <td style="padding-top: 5px; border: solid thin black; background: white; color: black;">
                                                                                            <asp:TextBox ID="txtLand2" runat="server" class="form-control txtbox" Height="28px"
                                                                                                TabIndex="5" onkeypress="DecimalOnly()" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtLand3" runat="server" class="form-control txtbox" Height="28px"
                                                                                                TabIndex="5" onkeypress="DecimalOnly()" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtLand4" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtLand5" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtLand6" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtLand7" runat="server" class="form-control txtbox" Height="28px"
                                                                                                AutoPostBack="false" onkeypress="DecimalOnly()" MaxLength="40" TabIndex="5" OnTextChanged="txtLand7_TextChanged"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            Buildings
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtBuilding2" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtBuilding3" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtBuilding4" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtBuilding5" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtBuilding6" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtBuilding7" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                OnTextChanged="txtBuilding7_TextChanged"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            Plant & Machinery
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtPM2" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtPM3" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtPM4" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtPM5" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtPM6" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtPM7" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                OnTextChanged="txtPM7_TextChanged"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            Machinery Contingencies
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtMCont2" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtMCont3" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtMCont4" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtMCont5" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtMCont6" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtMCont7" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            Erection
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtErec2" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtErec3" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtErec4" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtErec5" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtErec6" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtErec7" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            Technical know-how,<br />
                                                                                            feasibility study
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtTFS2" runat="server" class="form-control txtbox" Height="40px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtTFS3" runat="server" class="form-control txtbox" Height="40px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtTFS4" runat="server" class="form-control txtbox" Height="40px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtTFS5" runat="server" class="form-control txtbox" Height="40px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtTFS6" runat="server" class="form-control txtbox" Height="40px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtTFS7" runat="server" class="form-control txtbox" Height="40px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            Working Capital
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtWC2" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtWC3" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtWC4" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtWC5" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtWC6" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="border: solid thin black; background: white; color: black">
                                                                                            <asp:TextBox ID="txtWC7" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%--<tr>
                                                                    <td style="border:solid thin black; background: white; color:black">Total</td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal2" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal3" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal4" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal5" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal6" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal7" runat="server"></asp:Label></td>                                                                                    
                                                                </tr>--%>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 100%" valign="top">
                                                                                            <strong>Note :</strong> The data on the above should be prior to date of filing
                                                                                            of claim or within 6 months of Commencement of Production, whichever is earlier
                                                                                            in case of aided Enterprise/Industry. If it is self financed Enterprise/Industry,
                                                                                            the data on the above should be prior to date of commencement of Commercial Production.
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 20px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" width="300px;">
                                                                    Have you Installed Secondhand machinery<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 1px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlHvuInstalledScndhndMech" runat="server" class="form-control txtbox"
                                                                        Height="33px" MaxLength="80" TabIndex="5" ValidationGroup="group" Width="180px"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlHvuInstalledScndhndMech_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlHvuInstalledScndhndMech"
                                                                        ErrorMessage="Please Select subsidy" SetFocusOnError="true" ValidationGroup="group"
                                                                        InitialValue="-- SELECT --" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 20px">
                                                                </td>
                                                            </tr>
                                                            <tr id="trSecondhandmachinery" runat="server" visible="false">
                                                                <td colspan="9">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="border: solid thin white; background: #013161; color: white" align="center">
                                                                                Second hand machinery
                                                                                <br />
                                                                                value in Rs
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                New machinery value in Rs
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                Total value in Rs<br />
                                                                                (1+2)
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                % of second hand machinery
                                                                                <br />
                                                                                value in total machinery value
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                Value of the machinery
                                                                                <br />
                                                                                purchaced from TSIDC<br />
                                                                                /TSSFC/Bank in Rs
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                Total value in Rs
                                                                                <br />
                                                                                (2+5)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                1
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                2
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                3
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                4
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                5
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">
                                                                                6
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin white; background: #013161; color: white">
                                                                                <asp:TextBox ID="txtsecondhndmachine" runat="server" class="form-control txtbox"
                                                                                    Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    AutoPostBack="True" OnTextChanged="txtsecondhndmachine_TextChanged"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin white; background: #013161; color: white">
                                                                                <asp:TextBox ID="txtnewmachine" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    AutoPostBack="True" OnTextChanged="txtnewmachine_TextChanged"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin white; background: #013161; color: white">
                                                                                <asp:TextBox ID="txtTotalvalue12" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    AutoPostBack="True" Enabled="False" OnTextChanged="txtTotalvalue12_TextChanged"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin white; background: #013161; color: white">
                                                                                <asp:TextBox ID="txtpercentage12" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin white; background: #013161; color: white">
                                                                                <asp:TextBox ID="txtmachinepucr" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    AutoPostBack="True" OnTextChanged="txtmachinepucr_TextChanged"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin white; background: #013161; color: white">
                                                                                <asp:TextBox ID="txttotal25" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Enabled="False"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white;
                                                                                height: 1px" colspan="6">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 20px" colspan="9">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="8">
                                                                    Registration with Commercial taxes Department Registration
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="9">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">
                                                                                1
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">
                                                                                TIN/ VAT/ CST/ GST No.<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td class="auto-style16">
                                                                                <asp:TextBox ID="txtvatno" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="100" TabIndex="5" Width="150px" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">
                                                                                2
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                Registration Date.<span style="font-weight: bold; color: Red;"></span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td class="auto-style16">
                                                                                <asp:TextBox ID="txtCSTRegDate" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="100" TabIndex="5" Width="150px"> </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtCSTRegDate"
                                                                                    ErrorMessage="Please Select Registration Date." SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">
                                                                                3
                                                                            </td>
                                                                            <td class="auto-style15">
                                                                                &nbsp; Registring Authority<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCSTRegAuthority" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="100" TabIndex="5" Width="150px" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="txtCSTRegAuthority"
                                                                                    ErrorMessage="Please Enter Registration Authority." SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">
                                                                                4&nbsp;
                                                                            </td>
                                                                            <td width="300px;">
                                                                                &nbsp; Registering Authority Address.<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td class="auto-style16">
                                                                                <asp:TextBox ID="txtCSTRegAuthAddress" runat="server" class="form-control txtbox"
                                                                                    Height="50px" MaxLength="500" TabIndex="5" TextMode="MultiLine" ValidationGroup="group"
                                                                                    Width="200px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txtCSTRegAuthAddress"
                                                                                    Display="None" ErrorMessage="Please Enter Registration Authority Address." SetFocusOnError="true"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <caption>
                                                                            &nbsp;</caption>
                                                                        <tr id="trEMpartNo1" runat="server" visible="false">
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">
                                                                                6
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style15">
                                                                                GST No.<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGSTNo" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="100" TabIndex="5" ValidationGroup="group" Width="150px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" ControlToValidate="txtGSTNo"
                                                                                    Display="None" ErrorMessage="Please Enter GST No." SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">
                                                                                7
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 100px">
                                                                                GST Date.<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td class="auto-style16">
                                                                                <asp:TextBox ID="txtGSTDate" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="100" TabIndex="5" ValidationGroup="group" Width="150px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ControlToValidate="txtGSTDate"
                                                                                    Display="None" ErrorMessage="Please Enter GST Date." SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trEMpartNo" runat="server" visible="false">
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">
                                                                                8
                                                                            </td>
                                                                            <td>
                                                                                EM Part - II/IEM/IL No.
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td class="auto-style16">
                                                                                <asp:TextBox ID="txtEmpart" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="100" TabIndex="5" ValidationGroup="group" Width="150px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">
                                                                                2&nbsp;
                                                                            </td>
                                                                            <td class="auto-style15">
                                                                                &nbsp; CST No.<span style="font-weight: bold; color: Red;">*</span>
                                                                            </td>
                                                                            <td>
                                                                                :
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtcstno" runat="server" class="form-control txtbox" Height="28px"
                                                                                    MaxLength="100" TabIndex="5" Width="150px" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator80" runat="server" ControlToValidate="txtcstno"
                                                                                    ErrorMessage="Please Enter CST No." SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <caption>
                                                                <b>Term Loan details:</b>
                                                                <br />
                                                            </caption>
                                                        </table>
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Button ID="btntab4previous" runat="server" CssClass="btn btn-warning" Font-Size="Large"
                                                                        ForeColor="White" Height="50px" OnClick="btntab4previous_Click" TabIndex="5"
                                                                        Text="Previous" Width="150px" />
                                                                    &nbsp;&nbsp;&nbsp;
                                                                    <asp:Button ID="btntab4next" runat="server" CssClass="btn btn-warning" Font-Size="Large"
                                                                        ForeColor="White" Height="50px" OnClick="btntab4next_Click" TabIndex="5" Text="Next"
                                                                        Width="150px" />
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
                                        <asp:View ID="View6" runat="server">
                                            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid;
                                                font-weight: bold;">
                                                <tr>
                                                    <td>
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td>
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <span style="font-weight: bold;">Bank Details</span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                                    <tr>
                                                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                                            1
                                                                                        </td>
                                                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                                            Name of the Bank
                                                                                        </td>
                                                                                        <td class="style21" style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                                            <asp:DropDownList ID="ddlBank" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"
                                                                                                AutoPostBack="true" runat="server" class="form-control txtbox" TabIndex="5" ValidationGroup="group">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvBank" runat="server" InitialValue="-- SELECT --"
                                                                                                ControlToValidate="ddlBank" ErrorMessage="Please Select Bank Name" ValidationGroup="group"
                                                                                                SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="trNBFC" runat="server" visible="false">
                                                                                        <td>
                                                                                        </td>
                                                                                        <td style="float: left">
                                                                                            NBFC Name
                                                                                        </td>
                                                                                        <td>
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtNbfc" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="100" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                                            2
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            Branch Name<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtBranchName" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="txtBranchName"
                                                                                                ErrorMessage="Please Enter Bank Name" ValidationGroup="group" SetFocusOnError="true"
                                                                                                Display="None">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;">
                                                                                            3
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            Account Type<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control txtbox"
                                                                                                Height="33px" MaxLength="40" TabIndex="5" ValidationGroup="group" Width="180px">
                                                                                                <asp:ListItem Value="0" Text="-- SELECT --"> </asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="ddlAccountType"
                                                                                                ErrorMessage="Please Enter Account Type" ValidationGroup="group" SetFocusOnError="true"
                                                                                                Display="None">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                                            4
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            Account Holder Name<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtAccountName" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator90" runat="server" ControlToValidate="txtAccountName"
                                                                                                ErrorMessage="Please Enter Account Name" ValidationGroup="group" SetFocusOnError="true"
                                                                                                Display="None">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                        <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                                            5
                                                                                        </td>
                                                                                        <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            Account Number<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                                        <td class="style21" style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtAccNumber" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="25" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvAcNo" runat="server" ControlToValidate="txtAccNumber"
                                                                                                ErrorMessage="Please Enter Bank Account Number" ValidationGroup="group" SetFocusOnError="true"
                                                                                                Display="None">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">
                                                                                            6
                                                                                        </td>
                                                                                        <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            IFSC Code<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtIfscCode" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="12" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvIFSCCode" runat="server" ControlToValidate="txtIfscCode"
                                                                                                ErrorMessage="Please Enter IFSC Code" ValidationGroup="group" SetFocusOnError="true"
                                                                                                Display="None">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                        <td colspan="3">
                                                                                            <a href="https://www.bankifsccode.com/" target="_blank">Find IFSC code</a>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">
                                                                                            7
                                                                                        </td>
                                                                                        <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            Loan/Aggrement Account Number<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtLoanAggrementAcNo" runat="server" class="form-control txtbox"
                                                                                                Height="28px" MaxLength="30" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvLoanAggrementAcNo" runat="server" ControlToValidate="txtLoanAggrementAcNo"
                                                                                                ErrorMessage="Please Enter Loan/Aggrement Account Number" ValidationGroup="group"
                                                                                                SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    
                                                                                    <tr runat="server" id="powertr1" visible="false">
                                                                                        <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            Whether you have Power Connection Incentive
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:DropDownList ID="ddlPower" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                                                OnSelectedIndexChanged="ddlPower_SelectedIndexChanged" TabIndex="5" Width="180px">
                                                                                                <asp:ListItem Value="-1">-- Select --</asp:ListItem>
                                                                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" InitialValue="-- Select --"
                                                                                                ControlToValidate="ddlPower" ErrorMessage="Please Select Power" ValidationGroup="group"
                                                                                                SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                        <td colspan="3">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr runat="server" id="powertr" visible="false">
                                                                                        <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            Request to Department
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="TxtRequesttoDepartment" runat="server" class="form-control txtbox"
                                                                                                Height="72px" MaxLength="450" TabIndex="5" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td colspan="3" style="color: #FF0000">
                                                                                            Please contact Industry Department for futher process and Register this in help
                                                                                            desk
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 20px; font-weight: bold;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="8" align="right">
                                                                    <asp:Button Text="Previous" CssClass="btn btn-warning" Height="50px" TabIndex="5"
                                                                        Width="150px" Font-Size="Large" ValidationGroup="group" ForeColor="White" BorderStyle="Solid"
                                                                        ID="btntab6previous" runat="server" OnClick="btntab6previous_Click" />&nbsp;&nbsp;&nbsp
                                                                </td>
                                                                <td>
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
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="40px"
                                        Visible="false" Width="190px" TabIndex="5" Text="Submit" OnClick="BtnSave_Click" Enabled="false" />
                                    <span style="padding-left: 5px;" >
                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                            Height="40px" TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" Width="190px"
                                            OnClick="BtnClear_Click" />
                                    </span><span style="padding-left: 5px;">
                                        <asp:Button ID="btnNext" runat="server" CssClass="btn btn-warning" Height="40px"
                                            Width="190px" Text="Next" Visible="false" OnClick="btnNext_Click" TabIndex="5" Enabled="true" />
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
                                                 <asp:HiddenField ID="hdnUserID" runat="server" />
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
            $("input[id$='txtExistingDCP']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    maxDate: 0
                });
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

        .auto-style8 {
            width: 150px;
            height: 40px;
        }

        .auto-style9 {
            width: 2px;
            height: 40px;
        }

        .auto-style10 {
            height: 40px;
        }

        .auto-style11 {
            width: 30px;
            height: 62px;
        }

        .auto-style12 {
            height: 62px;
        }

        .auto-style13 {
            width: 180px;
            height: 62px;
        }

        .auto-style15 {
            width: 175px;
        }

        .auto-style16 {
            width: 250px;
        }
    </style>
    <style type="text/css">
        .custom-select > div {
            width: 750px !important;
        }

            .custom-select > div > div {
                max-height: 500px !important;
            }

        .custom-select input {
            width: 400px !important;
        }

        .custom-select div ul li {
            border-bottom: 1px solid !important;
        }
    </style>
</asp:Content>
