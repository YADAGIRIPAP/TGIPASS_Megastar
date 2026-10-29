<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="DIPCSanctionedDtlsEntryScreenNew.aspx.cs" Inherits="UI_TSiPASS_DIPCSanctionedDtlsEntryScreenNew" %>

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
    </script>
    <%--<script type="text/javascript">
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

            $("input[id$='txtsanctionDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtslcdate']").datepicker(
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
            $("input[id$='txtsanctionDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  
            $("input[id$='txtslcdate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback  
        });
    </script>--%>
    <%-- <script type="text/javascript">
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

    </script>--%>
    <style type="text/css">
        .blink {
            -webkit-animation-name: blink;
            -webkit-animation-iteration-count: infinite;
            -webkit-animation-timing-function: cubic-bezier(1.0,0,0,1.0);
            -webkit-animation-duration: 1s;
        }
    </style>
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
    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }
    </script>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- BOOTSTRAP STYLES-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
    <%--<script type="text/javascript" language="javascript">
        function OpenPopup() {
            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");
            return false;}
    </script>--%>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <input type="hidden" id="hdnfocus" value="" runat="server" />
            <div>
                <table style="width: 100%">
                    <tr>
                        <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><asp:Label ID="lblmsg0" runat="server"></asp:Label>
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
                                        <asp:Label ID="lblds" runat="server"></asp:Label>
                                        Sanctioned Details Entry</td>
                                    <td align="right"><span style="font-weight: bold"><font color="red">*</font>All Fields Are Mandatory</span></td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold" colspan="2">You have selected
                                        <asp:Label ID="lblunitname" runat="server"></asp:Label>
                                        unit.</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <table width="100%" align="left">
                <tr style="height: 10px">
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="height: 15px; font-weight: bold;"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">Committee <span style="font-weight: bold; color: Red;">*</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlCommittee" runat="server" class="form-control txtbox" Height="33px" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlCommittee_SelectedIndexChanged">
                                                    <asp:ListItem>-- Select --</asp:ListItem>
                                                    <asp:ListItem Value="1" Text="DIPC"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="SLC" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCommittee"
                                                    ErrorMessage="Please Select Committee" InitialValue="-- Select --" SetFocusOnError="true"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">Scheme Name <span style="font-weight: bold; color: Red;">*</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlSchemeName" runat="server" class="form-control txtbox" Height="33px" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True" TabIndex="2" OnSelectedIndexChanged="ddlCommittee_SelectedIndexChanged">
                                                    <asp:ListItem>-- Select --</asp:ListItem>
                                                    <asp:ListItem Value="T-IDEA" Text="T-IDEA"></asp:ListItem>
                                                    <asp:ListItem Value="T-IDEA" Text="T-PRIDE"></asp:ListItem>
                                                    <asp:ListItem Value="IIPP 2010-15" Text="IIPP Scheme 2010-15"></asp:ListItem>
                                                    <asp:ListItem Value="IIPP 2005-10" Text="IIPP Scheme 2005-10"></asp:ListItem>

                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlSchemeName"
                                                    ErrorMessage="Please Select Scheme Name" InitialValue="-- Select --" Display="None"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                        </tr>
                                        <tr id="trdipc" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">DIPC No. <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtDIPCNo" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="10" TabIndex="3" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDIPCNo" SetFocusOnError="true"
                                                    ErrorMessage="Please enter DIPC No." ValidationGroup="group" Display="None">*
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">DIPC Date<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtDIPCDate" runat="server" class="form-control txtbox" TabIndex="4"
                                                    Width="180px" Height="28px" AutoPostBack="true" OnTextChanged="txtDIPCDate_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDIPCDate"
                                                    ErrorMessage="Please Select DIPC Date" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                        </tr>
                                        <tr id="trslc" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">SLC No. <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtslcNo" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="10" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtslcNo" SetFocusOnError="true"
                                                    ErrorMessage="Please enter SLC No." ValidationGroup="group" Display="None">*
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">SLC Date<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtslcdate" runat="server" class="form-control txtbox" TabIndex="6"
                                                    Width="180px" Height="28px" AutoPostBack="true" OnTextChanged="txtslcdate_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtslcdate"
                                                    ErrorMessage="Please Select SLC Date" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Name of the Unit <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtName_Unit" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="80" TabIndex="7" onkeypress="return alphanumeric(this)" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvUnitName" runat="server" ControlToValidate="txtName_Unit"
                                                    ErrorMessage="Please Enter Name of the Unit" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" align="center">4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Applicant Name&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtApplciantName" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="8" onkeypress="Names()" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApplciantName"
                                                    ErrorMessage="Please Enter Applicant Name" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <%--Start--%>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Gender<span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlgender" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="80" TabIndex="7" ValidationGroup="group" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="TransGender"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlgender"
                                                    ErrorMessage="Please Select Gender" InitialValue="--Select--" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" align="center">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">T-IDEA/T-PRIDE<span style="font-weight: bold; color: Red;">*</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlpride" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="80" TabIndex="7" ValidationGroup="group" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1" Text="T-IDEA"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="T-PRIDE"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddlpride"
                                                    ErrorMessage="Please Select T-IDEA/T-PRIDE" InitialValue="--Select--" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">7.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Sector<span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlsector" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="80" TabIndex="7" ValidationGroup="group" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Service"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Manufacture"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Textiles"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlsector"
                                                    ErrorMessage="Please Select Sector" InitialValue="--Select--" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" align="center">8.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Category<span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlcategory" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="8" ValidationGroup="group" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlcategory"
                                                    ErrorMessage="Please Select Category" InitialValue="-- SELECT --" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center; height: 60px">9.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Social Status<span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="rblCaste" runat="server" RepeatDirection="Horizontal" TabIndex="9" Height="33px" Width="180px"
                                                    ValidationGroup="group">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">General</asp:ListItem>
                                                    <asp:ListItem Value="2">SC</asp:ListItem>
                                                    <asp:ListItem Value="3">ST</asp:ListItem>
                                                    <asp:ListItem Value="4">OBC</asp:ListItem>
                                                    <asp:ListItem Value="5">Others</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="rblCaste"
                                                    ErrorMessage="Please Select Caste" SetFocusOnError="true" ValidationGroup="group" InitialValue="--Select--"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;" align="center">10.</td>
                                            <td class="style36" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;" width="15%">
                                                <asp:Label ID="lbldateofCommencement" runat="server" Text="Date of commencement for Production"></asp:Label>&nbsp;<span style="font-weight: bold; color: Red;">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtDateofCommencement" runat="server" class="form-control txtbox" TabIndex="10" ValidationGroup="group"
                                                    Width="180px" Height="28px" AutoPostBack="true" OnTextChanged="txtDateofCommencement_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtDateofCommencement"
                                                    ErrorMessage="Please Select Commencement Date" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">11.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9">
                                                <u>Unit Address </u>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Width="165px">State<font color="red"> *</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlUnitstate" runat="server" class="form-control txtbox" Height="33px" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True" TabIndex="11" OnSelectedIndexChanged="ddlUnitstate_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="ddlUnitstate" SetFocusOnError="true"
                                                    ErrorMessage="Please select state" InitialValue="-- Select --" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">District<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlUnitDIst" runat="server" class="form-control txtbox" Visible="true" TabIndex="12" ValidationGroup="group"
                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddldistrictunit_SelectedIndexChanged">
                                                    <asp:ListItem>--District--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ControlToValidate="ddlUnitDIst"
                                                    InitialValue="--Select--" SetFocusOnError="true" ErrorMessage="Please Enter District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Mandal&nbsp; <span style="font-weight: bold; color: Red;">*</span></td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control txtbox" Visible="true" TabIndex="13" SetFocusOnError="true"
                                                    ValidationGroup="group" Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlUnitMandal_SelectedIndexChanged">
                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddlUnitMandal"
                                                    ErrorMessage="Please Select Mandal" InitialValue="--Mandal--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Village&nbsp; <span style="font-weight: bold; color: Red;">*</span></td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox" Visible="true" TabIndex="14" ValidationGroup="group"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Village--</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddlVillageunit"
                                                    ErrorMessage="Please Select Village" InitialValue="--Village--" SetFocusOnError="true"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>

                                            <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Street<span style="font-weight: bold; color: Red;"> *</span></td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtUnitStreet" runat="server" class="form-control txtbox" Height="28px" TabIndex="15"
                                                    Width="180px" ValidationGroup="group"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtUnitStreet" SetFocusOnError="true"
                                                    ErrorMessage="Please enter Street" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Survey/Plot/Door No.<span style="font-weight: bold; color: Red;"> *</span></td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtSurveyNo" runat="server" class="form-control txtbox" Height="28px" Width="180px" TabIndex="16"
                                                    ValidationGroup="group">                                                                    
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSurveyNo" SetFocusOnError="true"
                                                    ErrorMessage="Please Enter Survey/Plot/Door Number" ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">Mobile Number
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtunitmobileno" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="17" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style36">Email Id
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtunitemailid" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="18" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtunitemailid"
                                                    ErrorMessage="Please Enter Correct Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RegularExpressionValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center">&nbsp;</td>
                                        </tr>
                                        <%--Start 2--%>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">12.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9">
                                                <u>Bank Details</u>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Bank Name</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px" colspan="6">
                                                <asp:DropDownList ID="ddlBank" runat="server" class="form-control txtbox" TabIndex="5">
                                                </asp:DropDownList>
                                            </td>
                                            <td>                                                
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <%--Start 3--%>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">Branch Name</td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td colspan="6" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtbranchName" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="18" Width="180px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Type Of Account
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control txtbox" Visible="true" TabIndex="12"
                                                    Height="33px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">IFSC Code
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtIFSCCode" runat="server" class="form-control txtbox" Visible="true" TabIndex="12"
                                                    Height="33px" Width="180px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                            </td>

                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"><a href="https://www.bankifsccode.com/" target="_blank">Find IFSC code</a></td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Type Of Incentive<span style="font-weight: bold; color: Red;"> *</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlIncentiveType" runat="server" class="form-control txtbox" Visible="true" TabIndex="12" ValidationGroup="group"
                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlIncentiveType_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlIncentiveType" InitialValue="--Select--"
                                                    SetFocusOnError="true" ErrorMessage="Please Select Type Of Account" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr id="trinc1" runat="server">
                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="11">
                                                <table style="width: 100%; font-weight: bold;">
                                                    <tr>
                                                        <td style="font-weight: bold; font-size: medium" colspan="9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;One Time Incentives</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Financial year <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlFinYear1" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td style="padding: 5px; margin: 5px"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style1">2</td>
                                                        <td>
                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="200px">Final Recommended Amount (In Rs)<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtRecommendedAmount" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">3</td>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Sanctioned Amount (In Rs)<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtsanctionAmount" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                Height="28px" MaxLength="80" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">4</td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">Sanctioned Date<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtsanctionDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">5</td>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="200px">Seriatum No.<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtSeriatumNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td align="center">
                                                            <asp:Button ID="btnAdd1" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="39" Text="Add New" Width="72px" OnClick="btnAdd1_Click" />
                                                        </td>
                                                        <td align="right">&nbsp;</td>
                                                        <td>
                                                            <asp:Button ID="btnClear1" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="40" Text="Clear" ToolTip="To Clear the Screen" Width="73px" OnClick="btnClear1_Click" />
                                                        </td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9">
                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                                        <asp:GridView ID="gvincentivedtls" runat="server" AutoGenerateColumns="False"
                                                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                                            CssClass="GRD" ForeColor="#333333" GridLines="Both"
                                                                            Width="100%" DataKeyNames="intLineofActivityMid" OnRowDataBound="gvincentivedtls_RowDataBound" OnRowDeleting="gvincentivedtls_RowDeleting">
                                                                            <RowStyle BackColor="#ffffff" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="IncentiveType" HeaderText="Incentive Type" />
                                                                                <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                                                                                <asp:BoundField DataField="RecommendedAmount" HeaderText="Final Recommended Amount (In Rs)" />
                                                                                <asp:BoundField DataField="SanctionedAmount" HeaderText="Sanctioned Amount (In Rs)" />
                                                                                <asp:BoundField DataField="SanctionedDate" HeaderText="Sanctioned Date" />
                                                                                <asp:BoundField DataField="SeriatumNo" HeaderText="Seriatum No" />
                                                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                            </Columns>
                                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                            <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                            <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--<tr id="trOneTimeIncentives" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9">
                                                <asp:GridView ID="gvincentivedtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True" Width="100%" CellSpacing="4" OnRowDataBound="gvincentivedtls_RowDataBound">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" Width="2px" CssClass="GRD" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <HeaderStyle CssClass="GRD" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkSelect" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl. No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentive Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblincentiveType" runat="server" Text='<%# Bind("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentive ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblincentiveID" runat="server" Text='<%# Bind("IncentiveID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Financial Year">
                                                            <ItemTemplate>
                                                                <asp:Label ID="ddlFinancialYear" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Final Recommended Amount (In Rs)">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtrecommendedAnount" onkeypress="return inputOnlyNumbers(event)" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sanctioned Amount (In Rs)">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtsanctionAmount" runat="server" Enabled="false" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                <itemstyle horizontalalign="Left" width="140px" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sanctioned Date">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtsanctionDate" runat="server" Enabled="false"></asp:TextBox>
                                                                <itemstyle horizontalalign="Left" width="140px" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Seriatum No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSeriatumNo" runat="server"></asp:Label>
                                                                <itemstyle horizontalalign="Left" width="140px" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>--%>
                                        <%--<tr id="trRepetitiveIncentives" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9">
                                                <asp:GridView ID="gvincentivedtlsRep" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True" Width="100%" CellSpacing="4">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" Width="2px" CssClass="GRD" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <HeaderStyle CssClass="GRD" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkSelect" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl. No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Incentive Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblincentiveType" runat="server" Text='<%# Bind("IncentiveName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentive ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblincentiveID" runat="server" Text='<%# Bind("IncentiveID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Financial Year">
                                                            <ItemTemplate>
                                                                <asp:Label ID="ddlFinancialYear" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="1stHalf/2ndHalf">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFinHalfYear" runat="server">
                                                                    <asp:ListItem Value="1" Text="First Half"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Second Half"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Both"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Final Recommended Amount (In Rs)">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtrecommendedAnount" onkeypress="return inputOnlyNumbers(event)" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sanctioned Amount (In Rs)">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtsanctionAmount" runat="server" Enabled="false" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                <itemstyle horizontalalign="Left" width="140px" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sanctioned Date">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtsanctionDate" runat="server"></asp:TextBox>
                                                                <itemstyle horizontalalign="Left" width="140px" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Seriatum No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSeriatumNo" runat="server"></asp:Label>
                                                                <itemstyle horizontalalign="Left" width="140px" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>--%>
                                        <tr id="trinc2" runat="server">
                                            <td style="padding: 5px; margin: 5px" valign="top" colspan="11">
                                                <table style="width: 100%; font-weight: bold;">
                                                    <tr>
                                                        <td style="font-weight: bold; font-size: medium" colspan="9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Regular Incentives</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label5" runat="server">Financial year<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlFinYear2" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">1stHalf/2ndHalf<font color="red">*</font></td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlFinHalfYear" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="0" Text="Annual"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="First Half"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Second Half"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Both"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style1">3</td>
                                                        <td>
                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="200px">Final Recommended Amount (In Rs)<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtRecommendedAmount2" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">4</td>
                                                        <td>
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="200px">Sanctioned Amount (In Rs)<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtsanctionAmount2" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">5</td>
                                                        <td>
                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="200px">Sanctioned Date<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtsanctionDate2" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">6</td>
                                                        <td>
                                                            <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="200px">Seriatum No.<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtSeriatumNo2" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td class="auto-style1"></td>
                                                        <td align="center">
                                                            <asp:Button ID="btnAdd2" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="39" Text="Add New" Width="72px" OnClick="btnAdd2_Click" />
                                                        </td>
                                                        <td align="right">&nbsp;</td>
                                                        <td>
                                                            <asp:Button ID="btnClear2" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="40" Text="Clear" ToolTip="To Clear the Screen" Width="73px" OnClick="btnClear2_Click" />
                                                        </td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9">
                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                                        <asp:GridView ID="gvincentivedtlsRep" runat="server" AutoGenerateColumns="False"
                                                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                                            CssClass="GRD" ForeColor="#333333" GridLines="Both"
                                                                            Width="100%" DataKeyNames="intLineofActivityMid" OnRowDataBound="gvincentivedtlsRep_RowDataBound" OnRowDeleting="gvincentivedtlsRep_RowDeleting">
                                                                            <RowStyle BackColor="#ffffff" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="IncentiveType" HeaderText="Incentive Type" />
                                                                                <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                                                                                <asp:BoundField DataField="1stHalf2ndHalf" HeaderText="1stHalf/2ndHalf" />
                                                                                <asp:BoundField DataField="RecommendedAmount" HeaderText="Final Recommended Amount (In Rs)" />
                                                                                <asp:BoundField DataField="SanctionedAmount" HeaderText="Sanctioned Amount (In Rs)" />
                                                                                <asp:BoundField DataField="SanctionedDate" HeaderText="Sanctioned Date" />
                                                                                <asp:BoundField DataField="SeriatumNo" HeaderText="Seriatum No" />
                                                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                            </Columns>
                                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                            <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                            <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;vertical-align:top">Remarks
                                            </td>
                                            <td  style="padding: 5px; margin: 5px; text-align: left;vertical-align:top">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;vertical-align:top">
                                                <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" class="form-control txtbox" Height="80px" Width="200px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;" colspan="9">
                                                <span style="padding-left: 5px;">
                                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="40px" Width="190px" TabIndex="5" Text="Submit" ValidationGroup="group" OnClick="BtnSave_Click" />
                                                </span>
                                                <span style="padding-left: 5px;">
                                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="40px" TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" Width="190px" OnClick="BtnClear_Click" /></span></td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%; font-weight: bold;">
                                        <tr>
                                            <td style="height: 20px; font-weight: bold;"></td>
                                        </tr>
                                    </table>
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
                <%--  <tr>
                    <td>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hdfFapplicationdate" Value="Y" runat="server" />
                    </td>
                </tr>--%>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--   <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet" type="text/css" />

    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtsanctionDate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txtDateofCommencement']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDIPCDate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
            $("input[id$='txtslcdate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate) 
               }); // Will run at every postback/AsyncPostback 
            $("input[id$='txtsanctionDate2']").datepicker(
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
            $("input[id$='txtsanctionDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtDateofCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtDIPCDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtslcdate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtsanctionDate2']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
</asp:Content>
