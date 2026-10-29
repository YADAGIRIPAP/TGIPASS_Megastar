<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSIPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmOccupencyCertificateHMDA.aspx.cs" Inherits="UI_TSIPASS_frmOccupencyCertificateHMDA" %>

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
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
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
                                    <td style="font-weight: bold">Occupency Certificate Application Form
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
            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">
                <table width="100%" align="left">
                    <tr>
                        <td>
                            <ul class="nav nav-pills nav-wizard">
                                <li class="active" id="Tab1" style="width: 150px" runat="server"><a href="#" data-toggle="tab">1. Form</a></li>
                                <li id="Tab2" style="width: 150px" runat="server"><a href="#" data-toggle="tab">2. Documents</a></li>
                            </ul>
                        </td>
                    </tr>
                    <tr style="height: 10px">
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <tr>
                                <td>
                                    <%--<asp:MultiView ID="MainView" runat="server">
                                        <asp:View ID="View1" runat="server">--%>
                                    <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">
                                        <tr>
                                            <td style="height: 15px; font-weight: bold;"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center; height: 60px">1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Do you have DPMS Building Permit No<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="RbtsDPMScheck" RepeatDirection="Horizontal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RbtsDPMScheck_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="Y" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center; height: 60px">2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Enter File No<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtfileNo" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="80" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td style="padding: 5px; margin: 5px" colspan="3">
                                                <asp:Button ID="btngetdata" CssClass="btn btn-primary" runat="server" Text="Proceed" OnClick="btngetdata_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">4&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Work Commenced Date&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtWorkCommencedDate" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="80" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" align="center">5
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Work Completion Date&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtWorkCompletionDate" runat="server" class="form-control txtbox" Height="28px"
                                                    onkeypress="Names()" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">4&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Due Date for Completion of Building&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtDueDateforCompletionofBuilding" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="80" onkeypress="return alphanumeric(this)" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" align="center">5
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Occupancy Applied For&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtOccupancyAppliedFor" runat="server" class="form-control txtbox" Height="28px"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">District<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlUnitDIst" runat="server" class="form-control txtbox" Visible="true"
                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddldistrictunit_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Mandal&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control txtbox" Visible="true"
                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlUnitMandal_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Village&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox"
                                                    Visible="true" Height="33px" Width="180px">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Zone Office<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:DropDownList ID="ddlOfficeZone" runat="server" class="form-control txtbox" Visible="true"
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        </asp:DropDownList>--%>
                                                <asp:TextBox ID="txtofficezone" runat="server" class="form-control txtbox" Height="28px"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td></td>

                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Plot No.<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtPlotNo" runat="server" class="form-control txtbox" Height="28px"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td style="padding: 5px; margin: 5px;">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Survey No.<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtSurveyNo" runat="server" class="form-control txtbox" Height="28px"
                                                    Width="180px">                                                                    
                                                </asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr id="trmaindtlstab1" runat="server" visible="false">
                                            <td style="width: 100%" colspan="12">
                                                <table style="width: 100%; border-width: 1px; font-weight: bold;">
                                                    <tr>
                                                        <td style="height: 25px; font-weight: bold;" colspan="12"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 15px; font-size: 16pt; font-weight: bold;" colspan="12">Proceeding Issued Info </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Proceeding Issued On Date<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtProceedingIssuedOnDate" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Proceeding Issued By<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtProceedingIssuedBy" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px">                                                                    
                                                            </asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">Drawing Plan
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">Scrutiny Report
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3">Proceding Letter
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 15px; font-size: 16pt; font-weight: bold;" colspan="12">Plot Details</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%" colspan="12">
                                                            <table style="width: 100%; border-width: 1px; font-weight: bold;">
                                                                <tr>
                                                                    <td style="height: 25px; font-weight: bold;"></td>
                                                                    <td style="height: 25px; font-weight: bold;" colspan="16">Set Backs(m)
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Front
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtFront" runat="server" class="form-control txtbox" Height="28px"
                                                                            Width="100px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Rear
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtRear" runat="server" class="form-control txtbox" Height="28px"
                                                                            Width="100px">                                                                    
                                                                        </asp:TextBox>
                                                                    </td>

                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Side 1
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtSide1" runat="server" class="form-control txtbox" Height="28px"
                                                                            Width="100px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Side 2
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtSide2" runat="server" class="form-control txtbox" Height="28px"
                                                                            Width="100px">                                                                    
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Site Area(m2)<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtSiteArea" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Road Affected Area(m2)<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtRoadAffectedArea" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px">                                                                    
                                                            </asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Net Area(m2)<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtNetArea" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Tot-Lot(m2)<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtTotLot" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px">                                                                    
                                                            </asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Height(m)<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtbuildingHeight" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">No of RWHPs<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtNoofRWHPs" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px">                                                                    
                                                            </asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">No. Of Trees<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtnooftrees" runat="server" class="form-control txtbox" Height="28px" onkeypress="return inputOnlyNumbers(event)"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td style="padding: 5px; margin: 5px"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 15px; font-size: 16pt; font-weight: bold;" colspan="12">Buildings Details</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Building Proposed Building - Height(M)<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtBuildingProposedBuilding" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Building Use<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtBuildingUse" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px">                                                                    
                                                            </asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Building SubUse<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtBuildingSubUse" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">No of Floors<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtNoofFloors" runat="server" class="form-control txtbox" Height="28px"
                                                                onkeypress="return inputOnlyNumbers(event)" Width="180px">                                                                    
                                                            </asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 15px; font-size: 16pt; font-weight: bold;" colspan="12">License Technical Person Details</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Name<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtTechnicalName" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Email Id<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtTechnicalEmailId" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px">                                                                    
                                                            </asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mobile No<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtTechnicalMobileNo" runat="server" class="form-control txtbox" Height="28px"
                                                                onkeypress="return inputOnlyNumbers(event)" MaxLength="12" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td style="padding: 5px; margin: 5px"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 15px; font-size: 16pt; font-weight: bold;" colspan="12">Owner Details</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Name<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtOwnerName" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Email Id<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txttxtOwnerEmailId" runat="server" class="form-control txtbox" Height="28px"
                                                                Width="180px">                                                                    
                                                            </asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mobile No<span style="font-weight: bold; color: Red;"> *</span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtMobileNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="12"
                                                                onkeypress="return inputOnlyNumbers(event)" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td style="padding: 5px; margin: 5px"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <%-- </asp:View>
                                        <asp:View ID="View2" runat="server">--%>
                                    <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">
                                        <tr>
                                            <td style="height: 15px; font-weight: bold;"></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px; font-size: 16pt; font-weight: bold;" colspan="12">Technical Aspects(Mandatory)</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                    data-balloon="Form" data-balloon-pos="down">Copy of completed building plan as per physical ground position<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                <asp:FileUpload ID="FileUploadcompletedbuildingplan" runat="server" Width="300px" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="hplcompletedbuildingplan" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblcompletedbuildingplan" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="BtnSavecompletedbuildingplan" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="BtnSavecompletedbuildingplan_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" ata-balloon-length="large"
                                                    data-balloon="Registration Sale Deed" data-balloon-pos="down">Photographs of constructed building showing setbacks on four sides, elevation and roof level<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadPhotographsofconstructed" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="hplPhotographsofconstructed" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblPhotographsofconstructed" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnPhotographsofconstructed" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="btnPhotographsofconstructed_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" ata-balloon-length="large"
                                                    data-balloon="form" data-balloon-pos="down">Land value certificate issued by the revenue department<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadLandvaluecertificate" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="hplLandvaluecertificate" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblLandvaluecertificate" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnLandvaluecertificate" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="btnLandvaluecertificate_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" ata-balloon-length="large"
                                                    data-balloon="" data-balloon-pos="down">Building Completion notice by Architect / Structural Engineer duly signed by the owner, builder(if any), Architech & Sructural Engineer<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadBuildingCompletionArchitect" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="hplBuildingCompletionArchitect" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblBuildingCompletionArchitect" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnBuildingCompletionArchitect" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="btnBuildingCompletionArchitect_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px; font-size: 16pt; font-weight: bold;" colspan="12">Technical Aspects(Cond. Mandatory)</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                    data-balloon="Self Certification Form" data-balloon-pos="down">Copy of the registered gift deed handling over the road affected area to the local body<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left; width: 350px">
                                                <asp:FileUpload ID="FileUploadregisteredgiftdeed" runat="server" Width="300px" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="hplregisteredgiftdeed" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblregisteredgiftdeed" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnregisteredgiftdeed" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="btnregisteredgiftdeed_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" ata-balloon-length="large"
                                                    data-balloon="" data-balloon-pos="down">State / Central government order copy on the fee waiver<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadgovernmentordercopy" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="hplgovernmentordercopy" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblgovernmentordercopy" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btngovernmentordercopy" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="btngovernmentordercopy_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" ata-balloon-length="large"
                                                    data-balloon="Mutation issued by MRO" data-balloon-pos="down">Architect / Structural Engineer completion certificate<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadEngineercompletioncertificate" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="hplEngineercompletioncertificate" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblEngineercompletioncertificate" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnEngineercompletioncertificate" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="btnEngineercompletioncertificate_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" ata-balloon-length="large"
                                                    data-balloon="Mutation issued by MRO" data-balloon-pos="down">Final Fire Noc<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fileuploadFinalFireNoc" Width="300px" runat="server" class="form-control txtbox"
                                                    Height="33px" />
                                                <asp:HyperLink ID="hplFinalFireNoc" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblFinalFireNoc" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnFinalFireNoc" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="btnFinalFireNoc_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trprevioud" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" colspan="12" align="right">
                                                <asp:Button Text="Back" CssClass="btn btn-warning" Height="45px"
                                                    Width="150px" Font-Size="Large" ValidationGroup="group" ForeColor="White" BorderStyle="Solid"
                                                    ID="btntab6previous" runat="server" OnClick="btntab6previous_Click" />&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" colspan="12" align="center">
                                                <asp:Button Text="Next" CssClass="btn btn-danger" Height="32px" Width="90px"
                                                    ForeColor="White" ID="btntab1next" runat="server"
                                                    OnClick="btntab1next_Click" />&nbsp;&nbsp;
                                            
                                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    Width="90px" Text="Save" OnClick="BtnSave_Click" />
                                                &nbsp;
                                                        <asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                            Height="32px" OnClick="BtnDelete0_Click" TabIndex="10" Text="Previous"
                                                            Width="90px" />
                                                &nbsp;
                                                        
                                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                Height="32px" Text="Clear" ToolTip="To Clear  the Screen"
                                                                OnClick="BtnClear_Click" />

                                            </td>
                                        </tr>
                                    </table>
                                    <%-- </asp:View>
                                    </asp:MultiView>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
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

    <style type="text/css">
        .ui at k r font- 8pt; i or eight: 250px; d n 0.2 em 0 dth; 2 px; .auto-style8 {
            height: 29px;
        }
    </style>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />


    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
        }

        select {
            color: Black !important;
        }
    </style>

    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtWorkCommencedDate']").datepicker(
              {
                  dateFormat: "dd-mm-yy",
                  changeMonth: true,
                  changeYear: true,
                  yearRange: yrRange

                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
            $("input[id$='txtWorkCompletionDate']").datepicker(
              {
                  dateFormat: "dd-mm-yy",
                  changeMonth: true,
                  changeYear: true,
                  yearRange: yrRange

                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDueDateforCompletionofBuilding']").datepicker(
             {
                 dateFormat: "dd-mm-yy",
                 changeMonth: true,
                 changeYear: true,
                 yearRange: yrRange

                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback
            $("input[id$='txtProceedingIssuedOnDate']").datepicker(
             {
                 dateFormat: "dd-mm-yy",
                 changeMonth: true,
                 changeYear: true,
                 yearRange: yrRange

                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "2015:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtWorkCommencedDate']").datepicker(
               {
                   //dateFormat: "dd/mm/yy",
                   dateFormat: "dd-mm-yy",
                   //maxDate: new Date(currentYear, currentMonth, currentDate)
                   changeMonth: true,
                   changeYear: true,
                   yearRange: yrRange
               });
            $("input[id$='txtWorkCompletionDate']").datepicker(
              {
                  dateFormat: "dd-mm-yy",
                  changeMonth: true,
                  changeYear: true,
                  yearRange: yrRange

                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDueDateforCompletionofBuilding']").datepicker(
              {
                  dateFormat: "dd-mm-yy",
                  changeMonth: true,
                  changeYear: true,
                  yearRange: yrRange

                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
            $("input[id$='txtProceedingIssuedOnDate']").datepicker(
             {
                 dateFormat: "dd-mm-yy",
                 changeMonth: true,
                 changeYear: true,
                 yearRange: yrRange

                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback
        });
    </script>
</asp:Content>

