<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmQuesstionniareReg1_restarunts.aspx.cs" Inherits="UI_TSiPASS_frmQuesstionniareReg1_restarunts" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDateofCommenceAct1']").keydown(function () {
                //code to not allow any changes to be made to input field 
                return false;
            });

            $("input[id$='txtDateofCommenceAct1']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                  // minDate: 0,
                   //yearRange: "1930:2017",
                   //changeYear: true
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
           
        }
        $(function () {
            $("input[id$='txtDateofCommenceAct1']").keydown(function () {
                //code to not allow any changes to be made to input field 
                return false;
            });
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateofCommenceAct1']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //minDate: 0,
                    //yearRange: "1930:2017",
                    // changeYear: true
                    // maxDate: new Date(currentYear, currentMonth, currentDate) txtinspectiondate
                });
           

            // 

        });
        function getParameterByName(name) {
            debugger;
            name = name.replace(/[[]/, "\[").replace(/[]]/, "\]");
            var regexS = "[\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(window.location.href);
            if (results == null)
                return "";
            else
                return decodeURIComponent(results[1].replace(/\+/g, ' '));
        }
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {

            var f = $('#ctl00_ContentPlaceHolder1_hdnfocus').val();
            if (f != "") {
                $('#' + f).focus();
            }
        }
        function ConfirmSave() {
            var x = confirm("Please Confirm whether the Entered Details are Correct");
            if (x) {
                return true;
                Response.redirect("frmDepartmentApprovalDetails_Restarunt.aspx");
            }
            else { return false; }
        }


    </script>
    <asp:HiddenFielD ID="HDNSUDAKHAMMAM" runat="server" />
    <asp:HiddenFielD ID="HDNSUDASIDDIPET" runat="server" />
    <asp:HiddenFielD ID="HDNSUDAKARIMNAGAR" runat="server" />
    <asp:HiddenFielD ID="HDNNUDANIZAMABAD" runat="server" />
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
    <style type="text/css">
        .blink
        {
            -webkit-animation-name: blink;
            -webkit-animation-iteration-count: infinite;
            -webkit-animation-timing-function: cubic-bezier(1.0,0,0,1.0);
            -webkit-animation-duration: 1s;
        }
    </style>
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
    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="hdnfocus" value="" runat="server" />
            <div>
                <table style="width: 100%">
                    <tr>
                        <td align="center" colspan="8" style="padding: 5px; margin: 5px">
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
                </table>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <table style="width: 100%">
                                <tr>
                                    <td style="font-weight: bold">
                                        Questionnaire - Consent for Establishment
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
            <table width="100%" align="left">
                <tr>
                    <td>
                        <ul class="nav nav-pills nav-wizard">
                            <li class="active" id="Tab1" runat="server"><a href="#" data-toggle="tab">1. Project
                                Details</a></li>
                            <li id="Tab2" runat="server"><a href="#" data-toggle="tab">2. Project Financials</a></li>
                            <li id="Tab3" runat="server"><a href="#" data-toggle="tab">3. Project Requirements</a></li>
                        </ul>
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td>
                    </td>
                </tr>
                <%--<tr style="height: 15px">
                    <td>
                        <asp:Button Text="1. Project Details" CssClass="active" Height="60px" Font-Bold="true" Width="200px" BorderWidth="1px" BackColor="ForestGreen" ForeColor="White" BorderColor="#00cc00" ID="Tab1" runat="server"
                            OnClick="Tab1_Click" />
                        &nbsp;&nbsp;&nbsp;
                <asp:Button Text="2. Project Financials" Height="60px" Font-Bold="true" Width="200px" BorderWidth="1px" BackColor="ForestGreen" ForeColor="White" BorderColor="#00cc00" ID="Tab2" runat="server"
                    OnClick="Tab2_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button Text="3. Project Requirements" Height="60px" Font-Bold="true" Width="200px" BorderWidth="1px" BackColor="ForestGreen" ForeColor="White" BorderColor="#00cc00" ID="Tab3" runat="server"
                    OnClick="Tab3_Click" />
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:MultiView ID="MainView" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid;
                                    font-weight: bold; background-color: #d9d9d9">
                                    <tr>
                                        <td style="height: 15px; font-weight: bold;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            1.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label10" runat="server" data-balloon-length="large" data-balloon="Name of Unit"
                                                data-balloon-pos="down" Width="180px">Name of Unit</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="TxtnameofUnit" runat="server" class="form-control txtbox" Height="28px"
                                                ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px" OnTextChanged="TxtnameofUnit_TextChanged"
                                                AutoPostBack="True"></asp:TextBox>
                                        </td>
                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtnameofUnit"
                                                ErrorMessage="Please Enter Name of Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            2.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label377" runat="server" data-balloon-length="large" data-balloon="Please Eneter Constitution of the unit"
                                                data-balloon-pos="down">Constitution of the unit</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlConst_of_unit" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlConst_of_unit"
                                                ErrorMessage="Please Select Constitition of Unit" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            3.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label13" runat="server" data-balloon-length="large" data-balloon="Is Land purchased from IALA"
                                                data-balloon-pos="down" Width="260px">Whether land purchased from TSIIC</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rdIaLa_Lst" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            3.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label352" runat="server" data-balloon-length="large" data-balloon="Please Select Proposed Location"
                                                data-balloon-pos="down" CssClass="LBLBLACK">Proposed Location</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--District--</asp:ListItem>
                                                <asp:ListItem Value="5">Hyderabad</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProp_intDistrictid"
                                                ErrorMessage="Please Select Proposed Location (District)" InitialValue="--District--"
                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            4.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please Eneter Total Extent of Land" data-balloon-pos="down" Width="180px">Total Extent of Land</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddllandmesurements" runat="server" Height="33px" Width="180px"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddllandmesurements_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trIndustries" visible="false">
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label runat="server" ID="lblIndusText" Text="Name of the Industrial Park"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlIndustrialParkName" runat="server" AutoPostBack="true" class="form-control txtbox"
                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlIndustrialParkName_SelectedIndexChanged">
                                            </asp:DropDownList>
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
                                        <td style="height: 38px; padding: 5px; margin: 5px">
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
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlProp_intMandalid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intMandalid_SelectedIndexChanged">
                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProp_intMandalid"
                                                ErrorMessage="Please Select Proposed Location (Mandal)" InitialValue="--Mandal--"
                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--  <td colspan="5" style="Width: 100%">
                                            <table style="width: 100%">--%>
                                        <%-- <tr>--%>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 230px" align="right" id="tdTxtTot_ExtentNew"
                                            runat="server">
                                            Acres
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px">
                                            <asp:TextBox ID="TxtTot_ExtentNew" runat="server" class="form-control txtbox" Height="30px"
                                                placeholder="Acre" MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                Width="180px" AutoPostBack="True" OnTextChanged="TxtTot_ExtentNew_TextChanged"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtTot_ExtentNew"
                                                ErrorMessage="Please Enter Total Extent of Land (In Sq mtrs)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <%--</table>
                                        </td>--%>
                                    <tr id="trtxtgunthas" runat="server">
                                        <td style="padding: 5px; margin: 5px" colspan="5">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px" align="right">
                                            Gunthas
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtgunthas" runat="server" Text="0" class="form-control txtbox"
                                                Height="30px" placeholder="gunthas" MaxLength="10" onkeypress="DecimalOnly()"
                                                TabIndex="0" ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtgunthas_TextChanged"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlProp_intVillageid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intVillageid_SelectedIndexChanged">
                                                <asp:ListItem>--Village--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlProp_intVillageid"
                                                ErrorMessage="Please Select Proposed Location (Village)" InitialValue="--Village--"
                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; font-weight: bold;">
                                        </td>
                                        <td class="LBLBLACK" style="padding: 5px; margin: 5px" align="right">
                                            In Square Meters &nbsp;&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                            <td style="height: 38px; padding: 5px; margin: 5px">
                                                <asp:TextBox ID="TxtTot_Extent" runat="server" class="form-control txtbox" Height="28px"
                                                    Enabled="false" MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                    </tr>
                                    <tr id="trtsiicplotno" runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            Plot Number
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txttsiixplotno" runat="server" class="form-control txtbox" Height="28px"
                                                 TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txttsiixplotno"
                                                ErrorMessage="Please Enter Plot Number" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; font-weight: bold;">
                                            &nbsp;
                                        </td>
                                        <td align="right" class="LBLBLACK" style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;<td style="height: 38px; padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </td>
                                    </tr>
                                    <tr id="trunderlimits" runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            Under Limits
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="lblLimits" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td class="LBLBLACK" style="padding: 5px; margin: 5px" align="right">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            5.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label350" runat="server" data-balloon-length="large" data-balloon="Please select Location of the unit"
                                                data-balloon-pos="down" CssClass="LBLBLACK">Location of the unit</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlLoc_of_unit" runat="server" class="form-control txtbox"
                                                Height="33px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlLoc_of_unit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlLoc_of_unit"
                                                ErrorMessage="Please Select Location of Unit" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;" valign="top">
                                            6.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label4" runat="server" data-balloon-length="large" data-balloon="Please Enter Built up Area"
                                                data-balloon-pos="down" CssClass="LBLBLACK">Built up Area (Including Parking Cellars)</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="TxtBuilt_up_Area" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="6" TabIndex="0" ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                OnTextChanged="TxtBuilt_up_Area_TextChanged"></asp:TextBox>
                                            Square Meters
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TxtBuilt_up_Area"
                                                ErrorMessage="Please Enter Built up Area (Including Parking Cellars)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trApplType" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            6a.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label397" runat="server" data-balloon-length="large" data-balloon="Please Select Application Type"
                                                data-balloon-pos="down" CssClass="LBLBLACK">Application Type</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlAppl_Type" runat="server" class="form-control txtbox" Height="33px"
                                                Width="300px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlAppl_Type"
                                                ErrorMessage="Please Select Application Type" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            7.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label395" runat="server" data-balloon-length="large" data-balloon="Please Select Line of Activity"
                                                data-balloon-pos="down" CssClass="LBLBLACK" Width="165px">Line of Activity</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px; height: 38px" colspan="1">
                                            <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="custom-select"
                                                Height="33px" AutoPostBack="True" OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged"
                                                Width="300px">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlintLineofActivity"
                                                ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            8.
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please Select Type of Enterprise" data-balloon-pos="down">Type of Enterprise</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:DropDownList ID="ddlSector_Ent" runat="server" class="form-control txtbox" Height="33px"
                                                Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlSector_Ent_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSector_Ent"
                                                ErrorMessage="Please Select Sector of Enterprise" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            9.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label8" runat="server" data-balloon-length="large" data-balloon="Pollution Category of Enterprise"
                                                data-balloon-pos="down" CssClass="LBLBLACK">Pollution Category of Enterprise</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" id="trPOPCategory">
                                            <asp:Label ID="LblPol_Category" runat="server" CssClass="LBLBLACK" Width="200px"
                                                Font-Bold="True" Font-Size="18px"></asp:Label>
                                            <asp:HiddenField ID="HdfLblPol_Category" runat="server" />
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trFallinPolution">
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="180px" data-balloon-length="large"
                                                data-balloon="Please Select Yes if your unit fall under the list of Industries"
                                                data-balloon-pos="down">Does your unit fall under the list of </asp:Label>
                                            <a style="color: Black" target="_blank" href="LIST OF POLLUTING INDUSTRIES IN SMALL SCALE SECTOR.pdf">
                                                <%--66 polluting industries--%></a>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="RdPol_Indus" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr style="height: 50px">
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td colspan="3" style="padding: 5px; margin: 5px" valign="bottom">
                                            <%--   <a href="DisplayDocs/HMDAListofVillagesexcel.pdf" target="_blank"><b>Click here for HMDA Villages List</b></a>--%>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" colspan="5" align="right">
                                            <asp:Button Text="Next" Height="60px" Width="200px" Font-Size="Large" BackColor="ForestGreen"
                                                ForeColor="White" ID="btntab1next" ValidationGroup="group" runat="server" OnClick="btntab1next_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width: 100%; border-width: 2px; border-color: #666; border-style: solid;
                                    font-weight: bold; background-color: #d9d9d9">
                                    <tr>
                                        <td colspan="6" style="height: 15px; font-weight: bold;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                            10.
                                        </td>
                                        <td>
                                            <asp:Label ID="Label388" runat="server" data-balloon-length="large" data-balloon="Please Enter Proposed Employment"
                                                data-balloon-pos="down" CssClass="LBLBLACK">Proposed Employment</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 2px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">
                                            <asp:TextBox ID="TxtProp_Emp" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="6" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px"
                                                AutoPostBack="True" OnTextChanged="TxtProp_Emp_TextChanged"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtProp_Emp"
                                                ErrorMessage="Please Enter Proposed Employment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 430px; font-weight: bold;">
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            12.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            Proposal For
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlproposal" runat="server" class="form-control txtbox" TabIndex="1"
                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlproposal_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">New</asp:ListItem>
                                                <asp:ListItem Value="2">Expansion</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlproposal"
                                                ErrorMessage="Please Select Proposed For" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                 <tr id="trCFECFO" runat="server" visible="false">
                                        <td>

                                        </td>
                                        <td>
                                            Please enter <br /> Previous CFE UID No
                                        </td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtCFEUID"  AutoPostBack="True" class="form-control txtbox" runat="server" OnTextChanged="txtCFEUID_TextChanged" Width="189px"></asp:TextBox>
                                        </td>
                                        <td>

                                        </td>
                                        <td>
                                            <table>
                                                 <tr>
                                                     <td>Please enter
                                                         <br />
                                                         Previous CFO UID No </td>
                                                     <td></td>
                                                     <td>
                                                         <asp:TextBox ID="txtCFOUID" AutoPostBack="True" Enabled="false" runat="server" class="form-control txtbox" OnTextChanged="txtCFOUID_TextChanged" Width="189px"></asp:TextBox>
                                                     </td>
                                                 </tr>
                                            </table>
                                        </td>
                                      
                                       
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            11.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label389" runat="server" data-balloon-length="large" data-balloon="Please Select Project Cost"
                                                data-balloon-pos="down" CssClass="LBLBLACK" Font-Bold="True">Project Cost</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" font-bold="True">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlcurrencytype" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlcurrencytype_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlcurrencytype"
                                                ErrorMessage="Please Choose the amount in" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black" colspan="3">
                                                                    (Mention Zero in case of leased premises)
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; font-weight: bold; border-top: solid 1px black;"
                                                                    align="left" valign="top" id="tdprojectcostname" runat="server">
                                                                    New/Existing Investment
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
                                                                    <asp:Label ID="Label390" runat="server" CssClass="LBLBLACK">Value of Land as per saleDeed</asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="TxtVal_Land_Actual" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Land_Actual_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtVal_Land_Actual"
                                                                        ErrorMessage="Please Enter Value of Land" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px" align="right">
                                                                    In Rs. Lakhs
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="TxtVal_Land" runat="server" class="form-control txtbox" Height="28px"
                                                                        Enabled="false" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Land_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="lblLand" CssClass="lblinv" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr id="trmarketvalue" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    Land Market Value as Per SRO
                                                                    <asp:Label ID="lblnalavalue" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtmarketvalue" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="20" ValidationGroup="group"
                                                                        Width="180px" onkeypress="DecimalOnly()" ></asp:TextBox>
                                                                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtmarketvalue"
                                                                        ID="RegularExpressionValidator1" ValidationExpression="^[0-9]{5,20}$" runat="server"
                                                                        ErrorMessage="Market value of land cannot be lessthan Rs.10000/-">

                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtmarketvalue"
                                                                        ErrorMessage="Please Enter Land Market Value" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trmarketurl" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <%--"http://registration.telangana.gov.in/TGMV_Client/index.jsp"--%>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:HyperLink ID="HyperLinkmarketvalue0" ForeColor="Red" runat="server" NavigateUrl="http://registration.telangana.gov.in/UnitRateMV/getDistrictList.htm"
                                                                        Target="_blank" CssClass="blink" Text="Click Here to Calculate Market Value as Per SRO"></asp:HyperLink>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 15px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black; border-right: solid 1px black" valign="top">
                                                                    b)
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" valign="top">
                                                                    <asp:Label ID="Label391" runat="server" CssClass="LBLBLACK">Value of Building, Civil, MEPF Works<font 
                                color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="TxtVal_Build_Actual" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Build_Actual_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtVal_Build_Actual"
                                                                        ErrorMessage="Please Enter Value of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px" align="right">
                                                                    In Rs. Lakhs
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="TxtVal_Build" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Enabled="false" Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Build_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="lblBuild" CssClass="lblinv" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 15px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black; border-right: solid 1px black" class="auto-style1">
                                                                    c)
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" valign="top" class="auto-style1">
                                                                    <asp:Label ID="Label392" runat="server" CssClass="LBLBLACK">Value of Plant & Machinery or Service Equipment (including fixtures and furniture)<font 
                                color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" class="auto-style1">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" class="auto-style1">
                                                                    <asp:TextBox ID="TxtVal_Plant_Actual" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Plant_Actual_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black" class="auto-style1">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtVal_Plant_Actual"
                                                                        ErrorMessage="Please Enter Value of Plant &amp; Machinery Or Service Equipment"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px" align="right">
                                                                    In Rs. Lakhs
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="TxtVal_Plant" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Enabled="false" Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Plant_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="lblPlant" CssClass="lblinv" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>

                                                             <tr>
                                                                <td style="padding: 15px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black; border-right: solid 1px black">
                                                                    d)
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" valign="top">
                                                                    <asp:Label ID="lblpreoperativeexpensives" runat="server" CssClass="LBLBLACK">Other Pre-Operative Expenses<font 
                                color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="txtotherpreoperativeexpensives" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="20" onkeypress="DecimalOnly()" OnTextChanged="txtotherpreoperativeexpensives_TextChanged" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtotherpreoperativeexpensives"
                                                                        ErrorMessage="Please Enter Turnover"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px" align="right">
                                                                    In Rs. Lakhs
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" class="form-control txtbox" Enabled="false" Height="28px" MaxLength="20" onkeypress="DecimalOnly()" OnTextChanged="TextBox2_TextChanged" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                                                                                        
                                                            
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="lblTurnovr" CssClass="lblinv" runat="server"></asp:Label>
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
                                                                    <asp:Label ID="TxtTot_PrjCost" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                        Width="180px"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; height: 25px; border-top: solid 1px black"
                                                                    colspan="5">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label394" runat="server" CssClass="LBLBLACK">Category enterprise</asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="LblEnt_is" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True"
                                                                        Font-Size="18px"></asp:Label>
                                                                    <asp:HiddenField ID="HdfLblEnt_is" runat="server" />
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table id="tblexpansion" runat="server" visible="false">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black;">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-right: solid 1px black" align="left" valign="top" colspan="2">
                                                                    <span style="font-weight: bold"><u>Expansion Investment </u></span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-right: solid 1px black" align="left" valign="top">
                                                                    <span style="font-weight: bold"><u>Total Investment(In Rs. Lakhs) </u></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="TxtVal_Land_ActualExpansion" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Land_ActualExpansion_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="TxtVal_Land_ActualExpansion"
                    ErrorMessage="Please Enter Value of Expansion Land" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px;">
                                                                    <asp:TextBox ID="TxtVal_LandExpansion" runat="server" class="form-control txtbox"
                                                                        Height="28px" Enabled="false" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0"
                                                                        ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_LandExpansion_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black;">
                                                                    <asp:Label ID="lbltotalexpvalulandexp" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                        Width="180px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; height: 23px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; height: 23px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black;">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; height: 23px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black;">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="TxtVal_Build_ActualExpn" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Build_ActualExpn_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="TxtVal_Build_ActualExpn"
                                                                        ErrorMessage="Please Enter Value of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="TxtVal_BuildExpanstion" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Enabled="false" Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_BuildExpanstion_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black;">
                                                                    <asp:Label ID="lblbuildtotalexpvavalue" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                        Width="180px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; height: 23px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="TxtVal_Plant_ActualExpansion" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_Plant_ActualExpansion_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="TxtVal_Plant_ActualExpansion"
                                                                        ErrorMessage="Please Enter Value of Plant &amp; Machinery Or Service Equipment"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="TxtVal_PlantExpanstion" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                                        Enabled="false" Width="180px" AutoPostBack="True" OnTextChanged="TxtVal_PlantExpanstion_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black;">
                                                                    <asp:Label ID="lblplantotalexp" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                        Width="180px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; height: 23px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black;">
                                                                </td>
                                                            </tr>
                                                               <tr>
                                                                <td style="padding: 15px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black">
                                                                  
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" valign="top">
                                                                    <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True" class="form-control txtbox" Height="28px" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group" Width="180px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK">Expected Annual Turnover<font 
                                color="red">*</font></asp:Label>
                                                                    
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="TextBox3"
                                                                        ErrorMessage="Please Enter Turnover(Expansion)"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px" align="right">
                                                                    <asp:TextBox ID="TextBox4" runat="server" AutoPostBack="True" class="form-control txtbox" Enabled="false" Height="28px" MaxLength="20" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group" Width="180px" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                                                                    
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :</td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    In Rs. Lakhs</td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                                                                                        
                                                            
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-left: solid 1px black">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:Label ID="Label17" runat="server" CssClass="lblinv"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    &nbsp;</td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:Label ID="txtlbltotalprojectcostexpanstion" runat="server" CssClass="LBLBLACK"
                                                                        Font-Bold="True" Width="180px"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:Label ID="lblfinaltotalvalue" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                        Width="180px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; height: 25px; border-top: solid 1px black"
                                                                    colspan="6">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                        </td>
                                        <td align="right">
                                            <asp:Button Text="Previous" Height="60px" Width="200px" Font-Size="Large" BackColor="ForestGreen"
                                                ForeColor="White" ID="Button1" runat="server" OnClick="Button1_Click" />
                                            &nbsp;&nbsp;&nbsp
                                            <asp:Button Text="Next" Height="60px" Width="200px" Font-Size="Large" ValidationGroup="group"
                                                BackColor="ForestGreen" ForeColor="White" ID="btntab2next" runat="server" OnClick="btntab2next_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; font-weight: bold;">
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <table style="width: 100%; border-width: 2px; border-color: #666; border-style: solid;
                                    font-weight: bold; background-color: #d9d9d9">
                                    <tr>
                                        <td colspan="15" style="height: 15px; font-weight: bold;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; font-weight: bold;" valign="top">
                                            12.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label358" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please Enter Power requirement in HP" data-balloon-pos="down" Width="200px">Power requirement in HP<font 
                                    color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlPower_Req" runat="server" class="form-control txtbox" Height="33px"
                                                Width="180px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlPower_Req"
                                                ErrorMessage="Please Select Power requirement in HP" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; font-weight: bold;" valign="top" runat="server" visible="false">
                                            15(a).
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" visible="false">
                                            <asp:Label ID="Label379" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please Select store Rectified Spirit/Kerosene/Naptha" data-balloon-pos="down">
                                                    Do you manufacture,store,sale,<br />transport explosives </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" visible="false">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style1" runat="server" visible="false">
                                            <asp:RadioButtonList ID="RdDo_Store_Kerosine" runat="server" RepeatDirection="Horizontal"
                                                Height="16px" Width="210px" AutoPostBack="true" OnTextChanged="RdDo_Store_Kerosine_TextChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td style="padding: 15px; font-weight: bold;" valign="top">
                                            16.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            Do you have Existing borewell in proposed factory Location
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rdo_borewell" runat="server" Height="16px" RepeatDirection="Horizontal"
                                                OnSelectedIndexChanged="rdo_borewell_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Selected="True" Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td colspan="5" style="padding: 5px; margin: 5px">
                                            <table>
                                                <tr id="trExplosiveNOC" >
                                                    <td>
                                                          <td style="padding: 15px; font-weight: bold;" valign="top">
                                                              &nbsp;15<br /> (b).</td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style2">
                                            <asp:Label ID="Label398" runat="server" CssClass="LBLBLACK" data-balloon="Please Select store Rectified Spirit/Kerosene/Naptha" data-balloon-length="large" data-balloon-pos="down">
                                                    Do you Manufacture,store,sale,<br />Petroleum, Diesel, Kerosene </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style3">
                                            :&nbsp;
                                        </td>
                                        <td class="auto-style1" style="padding: 5px; margin: 5px">
                                            &nbsp; 
                                            <asp:RadioButtonList ID="RdDo_Store_Kerosine0" runat="server" Height="16px" RepeatDirection="Horizontal" Width="210px" OnTextChanged="RdDo_Store_Kerosine0_TextChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        
                                                    </td>
                                                </tr>
                                            </table>
                                            &nbsp;
                                        </td>
                                      
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                        13.</td>
                                        <td style="padding: 5px; margin: 5px;" colspan="8" align="left">
                                            <asp:GridView ID="gvmodelsnames" TabIndex="41" runat="server" Width="661px" border="0"
                                                CellPadding="4" AutoGenerateColumns="False" HorizontalAlign="Left" EnableModelValidation="True"
                                                ForeColor="#333333" GridLines="both">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="srn" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select" ShowHeader="False">
                                                        <%--  <HeaderTemplate>
                                                            <asp:CheckBox ID="chkAll" runat="server" onclick="javascript:selectGridChkAll(this)" />
                                                        </HeaderTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkmodelname" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle Width="70px" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Water required from" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblModelname"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="150px" HorizontalAlign="left"></HeaderStyle>
                                                        <ItemStyle Width="150px" HorizontalAlign="left"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Water Required per day( in KLD)" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtwaterrequired" MaxLength="10" Width="180px"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="left" Width="250px"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="trwater" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            16.
                                        </td>
                                        <td>
                                            <asp:Label ID="Label370" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please Enter Water Required per day( in KLD)" data-balloon-pos="down"
                                                Width="280px">Water Required per day( in KLD)</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="LBLBLACK">
                                            <asp:TextBox ID="TxtWater_req_Perday" runat="server" CssClass="form-control txtbox"
                                                Height="28px" MaxLength="8" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
                                                Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtWater_req_Perday"
                                                ErrorMessage="Please Enter Water Required per day (In KLD)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; font-weight: bold;">
                                            15.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="250px" data-balloon-length="large"
                                                data-balloon="Please Select Water required from" data-balloon-pos="down">Water required from </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:CheckBoxList ID="ChkWater_reg_from" runat="server" Height="60px" Width="180px">
                                                <asp:ListItem>New Bore well</asp:ListItem>
                                                <asp:ListItem>HMWS &amp; SB</asp:ListItem>
                                                <asp:ListItem>Rivers/Canals</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trUserid">
                                         <td style="padding: 15px; font-weight: bold;" valign="top">
                                            14.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please Eneter Height of the building(in Meters)" data-balloon-pos="down">Height of the building(in Meters)</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                            <asp:TextBox ID="TxtHight_Build" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="3" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TxtHight_Build"
                                                ErrorMessage="Please Enter Height of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;" runat="server" visible="false">
                                            17.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" visible="false">
                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please Select Generator Requirement" data-balloon-pos="down">Generator Requirement</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" visible="false">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" visible="false">
                                            <asp:RadioButtonList ID="RdGen_Reqired" runat="server" RepeatDirection="Horizontal"
                                                Height="16px" Width="180px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                       
                                    </tr>
                                    
                                    <tr id="lbr1" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            20.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="middle" colspan="8">
                                            <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please select Application Type" data-balloon-pos="down" Font-Bold="True">Labour Application Type</asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="lbr2" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            20a.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                            Does your establishment employ 05 or more contract Labour as defined in the Contract
                                            Labour(Regulation and Abolition)Act,1970?
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="RdbExecpted0" runat="server" Height="17px" RepeatDirection="Horizontal"
                                                Width="210px" AutoPostBack="True" OnSelectedIndexChanged="RdbExecpted0_SelectedIndexChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tract3" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 15px;" colspan="7" align="right">
                                            No of Workers
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:TextBox ID="txtContractLabourAct" runat="server" Height="28px" class="form-control txtbox"
                                                MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="lbr3" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            20b.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                            Does your establishment employ 05 or more Inter-State migrant workmen as defined
                                            in the Inter-state Migrant Workmen Act,1979?
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="RdbExecpted1" runat="server" Height="17px" RepeatDirection="Horizontal"
                                                Width="210px" OnSelectedIndexChanged="RdbExecpted1_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tract4new" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 15px" colspan="7" align="right">
                                            No of Workers
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                            <asp:TextBox ID="txtMigrantWorkmanAct" runat="server" Height="28px" class="form-control txtbox"
                                                MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="lbr4" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            20c.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                            Does your establishment fall under the definition of establishment as per Building
                                            and Other Constrution Worker(RE&amp;COS) Act,1996?
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="RdbExecpted2" runat="server" Height="17px" RepeatDirection="Horizontal"
                                                Width="210px" OnSelectedIndexChanged="RdbExecpted2_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tract4" runat="server" visible="false">
                                        <td style="padding: 20px; margin: 5px; width: 2px; font-weight: bold;">
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                            <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please select Application Type" data-balloon-pos="down">--> Whether your establishment has employed or had employed on any day of the preceding 12 months, 10 or more building workers in any “Building & Other Construction Works”.</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <asp:RadioButtonList ID="rdbact2" runat="server" RepeatDirection="Horizontal" Height="16px"
                                                Width="210px" AutoPostBack="True" OnSelectedIndexChanged="rdbact2_SelectedIndexChanged">
                                                <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tract2" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 15px" colspan="7" align="right">
                                            No of Workers
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                            <asp:TextBox ID="txtNoofworkers" runat="server" Height="28px" class="form-control txtbox"
                                                MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="Tr1" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">20d.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Does your establishment provide 05 or more inter-state migrant workmen on contractual
                                            basis as defined in the Inter-state Migrant Workmen Act, 1979?(for Contractor)
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="Rdb20d" runat="server" Height="17px" RepeatDirection="Horizontal"
                                                Width="210px" OnSelectedIndexChanged="Rdb20d_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tr20d" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 15px" colspan="7" align="right">
                                            No of Workers
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                            <asp:TextBox ID="txtNoofworkers20d" runat="server" Height="28px" class="form-control txtbox"
                                                MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="tract5License" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            20e.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                            Does your establishment employ 05 or more contract Laour as defined in the Contract
                                            Labour Act(Contractor) - License?
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="Rdbact5License" runat="server" Height="17px" RepeatDirection="Horizontal"
                                                Width="210px" AutoPostBack="True" OnSelectedIndexChanged="Rdbact5License_SelectedIndexChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tract5Licenseemp" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 15px;" colspan="7" align="right">
                                            No of Workers
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:TextBox ID="txtact5emp" runat="server" Height="28px" class="form-control txtbox"
                                                MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                Width="180px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="Tr2" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            20e.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                         <%--   Does your establishment fall under the definition of establishment under shops &amp;
                                            establishment Act,1988?--%>
                                             Does your establishment employ 05 or more contract labour(License for contractors) as defined in the contract labour(Regulation and Abolition) act,1970?
                                             
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="RdbExecptedactShop" runat="server" Height="17px" RepeatDirection="Horizontal"
                                                Width="210px" OnSelectedIndexChanged="RdbExecptedactShop_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem  Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tr3" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 15px" colspan="7" align="right">
                                            No of Workers
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                            <asp:TextBox ID="txtliccontractor" runat="server" Height="28px" class="form-control txtbox"
                                                MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                Width="180px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtNoofworkers"
                                                                ErrorMessage="Please enter Number of workers for Shops and Establishment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="tract2dateofcommencement" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 15px" colspan="7" align="right">
                                            
                                            Date of Commencement of business(DD-MM-YYYY)
                                            
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                            <%--<asp:TextBox ID="txtDateofCommenceAct1" runat="server" class="form-control txtbox"
                                                Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                Width="180px"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtDateofCommenceAct1" autocomplete="off" class="form-control txtbox" Width="150px" Height="30px" runat="server" ValidationGroup="group" />
                                                <%--<asp:TextBox ID="" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtDateofCommenceAct1"
                                                                ErrorMessage="Please enter No of Workers" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateofCommenceAct1">
                                            </cc1:CalendarExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            15
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                            Does the unit location fall within 100 mts of vicinity of any water body, school, hospital or religious institution?
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rdvicinitywaterbody" runat="server" Height="17px" RepeatDirection="Horizontal"
                                                Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">16</td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require approval from Commerical Tax</td>
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rdprofessiontax" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Selected="True" Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px" valign="top" height="40px">
                                            23.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="200px">DO you Use (High Tension)HT meter Above 70KVA<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="RdpIndustry" runat="server" RepeatDirection="Horizontal"
                                                Width="200px" TabIndex="1" OnTextChanged="RdpIndustry_TextChanged" AutoPostBack="true">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="RdpIndustry"
                                                ErrorMessage="Please Select meter to your (HT)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trregulation" runat="server" visible="false">
                                        <td height="40px" style="padding: 15px; margin: 5px" valign="top">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            Regulation
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlregulation" runat="server" class="form-control txtbox" Height="33px"
                                                TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlregulation_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>43(3)- Electrical Installation/ 32 - Generating Unit/Generators
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="ddlregulation"
                                                ErrorMessage="Please select Regulation" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trvoltage" runat="server" visible="false">
                                        <td height="40px" style="padding: 15px; margin: 5px" valign="top">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            Voltage
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlvoltage" runat="server" class="form-control txtbox" Height="33px"
                                                TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlvoltage_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddlvoltage"
                                                ErrorMessage="Please select Voltage" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trPlant" runat="server" visible="false">
                                        <td height="40px" style="padding: 15px; margin: 5px" valign="top">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            Plant
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlplant" runat="server" class="form-control txtbox" Height="33px"
                                                TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlplant_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="ddlplant"
                                                ErrorMessage="Please select Plant" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trvolcapacity" runat="server" visible="false">
                                        <td height="40px" style="padding: 15px; margin: 5px" valign="top">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="lblaggregate" runat="server" data-balloon-length="large" data-balloon="Please Enter Aggregate Capacity"
                                                data-balloon-pos="down">Aggregate Capacity</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                             <asp:TextBox ID="txtagrcapacity" runat="server" Height="28px" class="form-control txtbox"
                                                MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtagrcapacity"
                                                ErrorMessage="Please Enter Aggregate Capacity" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr runat="server" visible="false">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">17</td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you store RS, DS</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rdexcise" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trfactorylicense" visible="false" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Factory License</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="Rbtfactorylicense" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr  id="trlabourlicense" visible="true" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Does your establishment fall under the definition of establishment under shops & establishment Act,1988?</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rdshopsandestact" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trtradelicense" visible="true" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Approval for Trade License	</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rdtradelicense" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tr2blicensepreapproval" visible="false" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Excise 2B License - Pre Approval	</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rbt2blicense" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="tr2blicensefinal" visible="false" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Excise 2B License - Final 	</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rbt2blicensefinal" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trmicrobrewary" visible="false" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Approval for Microbrewery License 	</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rbtmicrolicense" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trtankcallibration" visible="false" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Approval for Tank Callibration	</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rbttankcalllicense" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trpolicelicense" visible="false" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Approval for Police License	</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rbtpolicense" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trfoodlicense" visible="true" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Approval for Food License	</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rbtfoodlicense" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trAdversingorsignboardlicense" visible="false" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Approval for Advertising / Sign Board License	</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rbtadvertiseorsignboard" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trpolluctioncontrollicense" visible="false" runat="server">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;"></td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">Do you require Approval for Pollution Control License</td>
                                         
                                        <td style="padding: 5px; margin: 5px" valign="top">:</td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="rbtpollutioncontrollicense" runat="server" Height="17px" RepeatDirection="Horizontal" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="8" align="right">
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">23. </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">Do you pack and label your product
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                        <td colspan="6" style="padding: 5px; margin: 5px" valign="top">
                                            <asp:RadioButtonList ID="rbtnLstLabel" runat="server" RepeatDirection="Horizontal" Height="17px" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="11">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding: 20px; margin: 5px; width: 2px; font-weight: bold;">
                                                    </td>
                                                    <td style="width: 200px">
                                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn-warning"
                                                            Height="40px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                            Width="185px" />
                                                    </td>
                                                    <td style="width: 200px">
                                                        <asp:Button ID="BtnSave1" runat="server" CssClass="button" Height="40px" OnClick="BtnSave_Click"
                                                            TabIndex="10" Text="Show Approvals Required" Width="195px" ValidationGroup="group" />
                                                    </td>
                                                    <td style="width: 200px">
                                                        <asp:Button ID="BtnSave" runat="server" CausesValidation="False" CssClass="button"
                                                            Height="40px" OnClick="BtnClear0_Click" TabIndex="10" Text="Submit Questionnaire"
                                                            ValidationGroup="group" Width="180px" OnClientClick="ConfirmSave()" />
                                                    </td>
                                                    <td style="width: 200px">
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <%--<asp:Button ID="btnShowEnclosers" runat="server" CausesValidation="False" CssClass="btn-primary"
                                                                    Height="40px" TabIndex="10" Text="Show Enclousers List" Width="180px" OnClick="btnShowEnclosers_Click" />--%>
                                                                                                                                    <asp:Button ID="BTNCOMMONAPPLICATIONFORM" runat="server" Text="Cleck here to view common application form"  OnClick="BTNCOMMONAPPLICATIONFORM_Click" />

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="8" align="right">
                                            <asp:Button Text="Previous" Height="60px" Width="200px" Font-Size="Large" BackColor="ForestGreen"
                                                ForeColor="White" BorderStyle="Solid" ID="btntab3privious" runat="server" OnClick="btntab3privious_Click" />&nbsp;&nbsp;&nbsp
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; font-weight: bold;">
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
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
                <tr>
                    <td>
                        <div class="panel panel-default" id="dvfeedetails" runat="server" visible="false">
                            <div class="panel-heading">
                                Fee Details(in Rs.)
                            </div>
                            <div class="panel-body">
                                <table style="width: 90%">
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" Width="100%" OnRowDataBound="grdDetails_RowDataBound"
                                                ShowFooter="True">
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required ">
                                                        <ItemStyle Width="450px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Dept_Full_name" HeaderText="Department">
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Fees" FooterStyle-HorizontalAlign="Right" HeaderText="Fees (Rs.)"
                                                        DataFormatString="{0:0}">
                                                        <FooterStyle CssClass="GRDITEM2" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle CssClass="GRDITEM2" Width="150px" HorizontalAlign="Right" />
                                                    </asp:BoundField>
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
                            </div>
                        </div>
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
                        <asp:HiddenField ID="hdfFapplicationdate" Value="Y" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    --%>
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
    
    <style type="text/css">
        .custom-select > div
        {
            width: 750px !important;
        }
        
        .custom-select > div > div
        {
            max-height: 500px !important;
        }
        
        .custom-select input
        {
            width: 400px !important;
        }
        
        .custom-select div ul li
        {
            border-bottom: 1px solid !important;
        }
        .auto-style1 {
            height: 53px;
        }
        .auto-style2 {
            width: 289px;
        }
        .auto-style3 {
            width: 5px;
        }
    </style>
</asp:Content>
