<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="PMEGPSuccessPage.aspx.cs" Inherits="UI_TSiPASS_PMEGPSuccessPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .custom-delete-button {
            text-align: center;
            color: #004A7F;
            font-weight: bold;
        }

        .radio-list {
            display: inline;
            margin-right: 10px; /* Add some spacing between items */
        }

            .radio-list input[type="radio"] {
                vertical-align: baseline; /* Align radio button vertically with text */
                margin-right: 5px; /* Add space between the radio button and text */
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

        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 1px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
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

        .error-border {
            /*border: 2px solid red;*/
            box-shadow: 0 0 5px red;
            width: 100%;
            padding: 8px 12px;
            border: 1px solid red;
            border-radius: 4px;
            background-color: #fff;
            color: #333;
            font-size: 14px;
            line-height: 1.4;
        }

        .form-control {
            width: 100%;
            padding: 8px 12px;
            border: 1px solid #ccc;
            border-radius: 4px;
            background-color: #fff;
            color: #333;
            font-size: 14px;
            line-height: 1.4;
            box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.1);
        }

        .GRD {
            margin-left: auto;
            margin-right: auto;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupTST.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != null && el.value.length != 0 && el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    $('input[type="text"]').on('paste', function (e) {
        //        e.preventDefault();
        //    });
        //});
        function pageLoad() {
            var date = new Date();
            var yrRange = "1990:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDateOfCommencement']").datepicker(
                {
                    dateFormat: "yy-mm-dd",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });

            $("input[id$='txtDate']").datepicker(
                {
                    dateFormat: "yy-mm-dd",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
        }

        $(function () {
            var date = new Date();
            var yrRange = "1990:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateOfCommencement']").datepicker(
                {
                    dateFormat: "yy-mm-dd",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });

            $("input[id$='txtDate']").datepicker(
                {
                    dateFormat: "yy-mm-dd",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange,
                    maxDate: dateToday
                });
        });
        window.addEventListener('popstate', function (event) {
            location.reload(true);
        });
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 12) {
                alert("Aadhar number length must be exactly 12 characters")
            }
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>


    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }

        .full-width {
            width: 100%;
            max-width: 100%;
            margin: 0;
            padding: 0;
        }

        .auto-style13 {
            width: 659px;
        }

        .auto-style14 {
            width: 316px;
        }

        .auto-style15 {
            width: 301px
        }

        .auto-style16 {
            width: 229px;
            height: 58px;
        }

        .auto-style41 {
            width: 208px;
        }

        .auto-style60 {
            position: relative;
            min-height: 1px;
            top: -4px;
            left: 0px;
            float: left;
            width: 100%;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
    <%-- <style>
        .algnCenter {
            text-align: center;
        }
              
        .auto-style2 {
            width: 311px;
        }
        .auto-style4 {
            width: 227px;
        }
       
        .auto-style6 {
            width: 310px;
        }
        .auto-style7 {
            width: 229px
        }
       
        .auto-style9 {
            width: 89px;
        }
        .auto-style12 {
            height: 60px;
            width: 76px;
        }
        .auto-style13 {
            width: 76px;
        }
       
        .auto-style16 {
            width: 309px;
        }
        .auto-style21 {
            height: 60px;
            width: 159px;
        }
        .auto-style26 {
            width: 458px;
        }
        .auto-style27 {
            height: 60px;
            width: 256px;
        }
        .auto-style29 {
            height: 60px;
            width: 243px;
        }
        .auto-style30 {
            height: 60px;
            width: 114px;
        }
        .auto-style31 {
            height: 60px;
            width: 139px;
        }
        .auto-style36 {
            height: 60px;
            width: 192px;
        }
        .auto-style37 {
            width: 192px;
        }
        .auto-style38 {
            width: 249px
        }
       
        .auto-style45 {
            width: 100%;
            height: 138px;
        }
        .auto-style46 {
            width: 309px;
            height: 60px;
        }
        .auto-style47 {
            width: 309px;
            height: 35px;
        }
               
        .auto-style49 {
            width: 22%;
            height: 60px;
        }
        .auto-style50 {
            width: 357px;
            height: 60px;
        }
        .auto-style51 {
            height: 60px;
        }
        .auto-style52 {
            width: 22%
        }
        .auto-style53 {
            width: 414px;
            height: 60px;
        }
        .auto-style54 {
            width: 574px;
        }
        .auto-style55 {
            width: 674px;
        }
        .auto-style56 {
            width: 371px;
        }
        .auto-style57 {
            height: 60px;
            width: 173px;
        }
        .auto-style58 {
            width: 357px;
        }
               
        </style>--%>

    <script type="text/javascript">
        function onlyAlphabetsAndSpaces(event) {
            var keyCode = event.keyCode || event.which;

            if ((keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || keyCode === 32) {
                return true;
            } else {
                return false;
            }
        }

        function validateInputName(input) {
            input.value = input.value.replace(/[^A-Za-z ]/g, '');
            input.value = input.value.replace(/ {2,}/g, ' ');
            input.value = input.value.split(' ').map(function (word) {
                return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
            }).join(' ');
        }


        function calculateSum() {
            var textBox1Value = parseFloat(document.getElementById("<%= txtbenfryctrion.ClientID %>").value) || 0;
            var textBox2Value = parseFloat(document.getElementById("<%= txtbkloan.ClientID %>").value) || 0;
            var sum = textBox1Value + textBox2Value;
            document.getElementById("<%= txtinvrstment.ClientID %>").value = sum;

            document.getElementById("<%= hfInvestment.ClientID %>").value = sum;
        }

        window.onload = function () {
            calculateSum();
        };

        function validateInput(input) {
            var allowedChars = /^[YN]$/i;

            if (!allowedChars.test(input.value)) {
                input.value = '';
            } else {
                input.value = input.value.toUpperCase();
            }
        }

        function validatePhoneNumber() {
            var phoneNumber = document.getElementById("<%= txtpnenmber.ClientID %>").value;
            var errorDiv = document.getElementById("error");
            var regex = /^[6-9]\d{9}$/;

            if (phoneNumber === "") {
                errorDiv.innerHTML = "";
            } else if (regex.test(phoneNumber)) {
                errorDiv.innerHTML = "";
            } else {
                errorDiv.innerHTML = "Invalid Phone Number";
            }
        }

        function validatePAN(textbox) {
            var panNumber = textbox.value.replace(/\s/g, '').toUpperCase();
            var panPattern = /^[A-Z]{5}[0-9]{4}[A-Z]{1}$/;

            var panValidationMessage = document.getElementById("panValidationMessage");

            if (panNumber === "") {
                panValidationMessage.innerHTML = "";
            } else if (panPattern.test(panNumber)) {
                panValidationMessage.innerHTML = "";
            } else {
                panValidationMessage.style.color = "red";
                panValidationMessage.innerHTML = "Invalid PAN number";
            }
            textbox.value = panNumber;
        }

        function CapitalizeText(textbox) {
            var EnteredText = textbox.value.replace(/\s/g, '').toUpperCase();
            textbox.value = EnteredText;
        }

        function validateEmail(txtmail) {
            var pattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
            var errorMessage = document.getElementById("error-message");

            if (txtmail === "") {
                errorMessage.innerHTML = "";
            } else if (pattern.test(txtmail)) {
                errorMessage.innerHTML = "";
            } else {
                errorMessage.style.color = "red";
                errorMessage.innerHTML = "Invalid email address";
            }
        }

        function formatTextbox(input) {  // Aadhar No.
            var numericValue = input.value.replace(/\D/g, '');
            var formattedValue = numericValue.replace(/(\d{4})(?=\d)/g, '$1-');
            input.value = formattedValue;
        }

    </script>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">PMEGP Success Stories</asp:Label></h3>
                    </div>

                    <div class="panel-body">
                        <%-- <contenttemplate>--%>
                        <input type="hidden" id="hdnfocus" value="" runat="server" />
                        <br />
                        <table width="100%" align="center">
                            <tr>
                                <td colspan="6">
                                    <h5 class="text-blue font-SemiBold " style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">1. Benificiary Details</h5>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; width: 210px" align="left">1. Applicant Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="aplicantname" runat="server" Style="width: 200px;" oninput="validateInputName(this)" TabIndex="1" ValidationGroup="group" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; width: 220px" align="left">2. Father/Spouse Name:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 250px">
                                    <asp:TextBox ID="txtfname" runat="server" Style="width: 200px;" oninput="validateInputName(this)" TabIndex="1" ValidationGroup="group" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 200px" align="left">3. Age:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtage" runat="server" autocomplete="off" Style="width: 200px;" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="margin: 5px;" align="left">4. Special Category:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSpecialCategory" runat="server" class="form-control" Style="width: 200px;" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">5. Education Qualification:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlEducation" runat="server" TabIndex="1" class="form-control" Style="width: 200px;">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">6. Social Status:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlCaste" runat="server" class="form-control" TabIndex="1" Style="width: 200px;">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <h5 class="text-blue font-SemiBold " style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">2. Address</h5>
                                </td>
                            </tr>

                            <tr>
                                <td style="vertical-align: middle; padding: 5px;" align="left">1. District:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProp_intDistric" runat="server" class="form-control" TabIndex="1"
                                        Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intDistric_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">2. Mandal/Municipality:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlProp_intMandalid" runat="server" class="form-control" TabIndex="1"
                                        Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intMandalid_SelectedIndexChanged1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">3. Village/Ward:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlProp_intVillageid" runat="server" class="form-control" TabIndex="1"
                                        Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intVillageid_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; padding: 5px;" align="left">4. House NO:
                                </td>
                                <td>
                                    <asp:TextBox ID="txthno" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">5. Street:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtstreet" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>

                                <td style="padding: 5px; margin: 5px;" align="left">6. Region/Area:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:RadioButtonList ID="RadioButton" runat="server" Style="width: 200px;" RepeatDirection="Horizontal" TabIndex="1">
                                        <asp:ListItem Text="Urban" Value="Urban" />
                                        <asp:ListItem Text="Rural" Value="Rural" />
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">3. Unique Identifiers</h5>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; padding: 5px;" align="left">1. Aadhar Card No:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtadhar" runat="server" Style="width: 200px;" TabIndex="1" MaxLength="14" onkeypress="NumberOnly()" oninput="formatTextbox(this)" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">2. PAN No:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtpannber" runat="server" Style="width: 200px;" TabIndex="1" MaxLength="10" autocomplete="off" oninput="validatePAN(this)" class="form-control"></asp:TextBox>
                                    <span id="panValidationMessage"></span>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">3. Udyam Reg No:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtrgnumber" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" oninput="CapitalizeText(this)" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" align="left">4. Ration Card No:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtrcnmber" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" oninput="CapitalizeText(this)" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">5. Phone No:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtpnenmber" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" onkeypress="NumberOnly()" onkeyup="validatePhoneNumber()" MaxLength="10" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">6.Email Id:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtmail" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" oninput="CapitalizeText(this)" onkeyup="validateEmail(this.value)" class="form-control"></asp:TextBox>
                                    <span id="error-message" style="color: red;"></span></td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" align="left">7. PMEGP ID:
                                </td>
                                <td>
                                    <asp:TextBox ID="PMEGP_ID_TSIPASS" runat="server" Style="width: 200px;" TabIndex="1" oninput="CapitalizeText(this)" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <%-- </table>
                        <table width="100%" align="center">--%>
                            <tr>
                                <td colspan="6">
                                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">4. Training</h5>
                                    <%--                                    <table id="Table3" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" class="nav-justified">--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" style="vertical-align: middle; padding: 5px; width: 200px;" align="left" class="auto-style41">1. EDP Certificate Obtained:</td>
                                <td style="padding: 5px; margin: 5px; width: 200px;">
                                    <asp:RadioButtonList ID="txtedpcerticte1" runat="server" Style="width: 160px;" TabIndex="1" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="txtedpcerticte1_SelectedIndexChanged">
                                        <asp:ListItem Text="Online"></asp:ListItem>
                                        <asp:ListItem Text="Offline"></asp:ListItem>

                                    </asp:RadioButtonList>
                                </td>
                                <%--  <td style="vertical-align: middle; padding: 15px; font-weight: bold;" align="left" class="auto-style1">EDP Certificate from Which Training Institute:
                                </td>--%>

                                <td colspan="2" style="padding: 5px; margin: 5px;" align="center">2. Any Other Training Programs Attended(Y/N):
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 200px;">
                                    <asp:RadioButtonList ID="txtatendprgrm" runat="server" Style="width: 130px;" TabIndex="1" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="txtatendprgrm_SelectedIndexChanged1">
                                        <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>

                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; width: 200px;" align="left">
                                    <asp:Label ID="lblcertice" runat="server" Text="1a. Enter Details:" Visible="false"></asp:Label></td>
                                <td style="padding: 5px; margin: 5px; width: 200px;">
                                    <asp:TextBox ID="txtedpcerticte" runat="server" Visible="false" Style="width: 200px;" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; padding-left:40px; margin: 5px; width: 200px;" align="center">
                                    <asp:Label ID="lblent" runat="server" Style="" Text="2a. Enter Details:" Visible="false"></asp:Label></td>
                                <td style="padding: 5px; margin: 5px; width: 200px;">
                                    <asp:TextBox ID="txtatendprgrm1" runat="server" Visible="false" Style="width: 200px;" autocomplete="off" class="form-control"></asp:TextBox></td>

                            </tr>

                            <%-- </table>
                                </td>--%>
                            <%-- </tr>
                       </table>--%>

                            <%-- <table width="100%" align="center">--%>
                            <tr>
                                <td colspan="6">
                                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">5. Family Details</h5>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="padding: 5px; margin: 5px; width: 150px;" align="left" >1. Relation:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 200px;" >
                                    <asp:DropDownList ID="DropDownList1" runat="server" Style="width: 200px;" class="form-control txtbox"
                                        AutoPostBack="false" Height="33px" TabIndex="1">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Spouse</asp:ListItem>
                                        <asp:ListItem Value="2">Child 1</asp:ListItem>
                                        <asp:ListItem Value="3">Child 2</asp:ListItem>
                                        <asp:ListItem Value="4">Child 3</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="vertical-align: middle; padding: 5px; width: 200px;" align="left" >2. Name:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 200px;" >
                                    <%--                        <asp:TextBox ID="txtName" runat="server" class="form-control txtbox" oninput="validateInputName(this)" autocomplete="off" Width="280px" Height="32px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtName" runat="server" class="form-control txtbox" oninput="validateInputName(this)" autocomplete="off" Style="width: 200px;" onkeypress="Names()" TabIndex="1" ValidationGroup="group"></asp:TextBox>

                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="padding: 5px; margin: 5px; width: 200px;" align="left" >3. Age:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 200px;" >
                                    <%--                        <asp:TextBox ID="TextBox1" autocomplete="off" runat="server" class="form-control txtbox" Width="80px" Height="32px" style="width: 200px;"  onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"></asp:TextBox>--%>
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control txtbox" Style="width: 200px;" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"></asp:TextBox>

                                </td>

                                <td style="padding: 5px; margin: 5px; width: 150px;" align="left" >4. Profession:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 200px;" >
                                    <%--                        <asp:TextBox ID="txtProfession" autocomplete="off" runat="server" oninput="validateInputName(this)" class="form-control txtbox" style="width: 200px;" Width="280px" Height="32px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group"></asp:TextBox>--%>
                                    <%--                        <asp:TextBox ID="txtProfession" autocomplete="off" runat="server" oninput="validateInputName(this)" class="form-control txtbox" style="width: 160px;" onkeypress="Names()" TabIndex="1" ValidationGroup="group"></asp:TextBox>--%>
                                    <asp:DropDownList ID="txtProfession" runat="server" class="form-control txtbox" Style="width: 200px;" TabIndex="1">
                                        <asp:ListItem Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Text="Below 5th"></asp:ListItem>
                                        <asp:ListItem Text="5th-10th"></asp:ListItem>
                                        <asp:ListItem Text="Inter"></asp:ListItem>
                                        <asp:ListItem Text="Graduate/Degree"></asp:ListItem>
                                        <asp:ListItem Text="P.G"></asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td></td>
                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td colspan="2">
                                    <div class="auto-style60" style="text-align: center; margin-top: 12px; padding-bottom: 15px;">
                                        <b style="color: red">Please click on Add after entering details.</b>
                                    </div>

                                    <div class="col-xs-12" style="text-align: center; margin-top: -10px;">
                                        <asp:Button ID="btnaddfamily" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                            TabIndex="10" Text="Add" ValidationGroup="child" Width="90px" OnClick="btnaddfamily_Click" />
                                        &nbsp;<asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click"
                                            CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                                            Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                                    </div>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="4" style="padding-top:10px">
                                    <asp:GridView ID="GVFamily" runat="server" AutoGenerateColumns="False" Width="800px" OnRowDeleting="GVFamily_RowDeleting" Visible="false" ShowHeaderWhenEmpty="true" CellPadding="2"
                                        CssClass="GRD" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px"
                                        ForeColor="#333333" AutoPostBack="true">
                                        <HeaderStyle CssClass="gridcolor" />
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DropDownList1" HeaderText="Relation" />
                                            <asp:BoundField DataField="txtName" HeaderText="Name" />
                                            <asp:BoundField DataField="TextBox1" HeaderText="Age" />
                                            <asp:BoundField DataField="txtProfession" HeaderText="Profession" />
                                            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="custom-delete-button" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="text-align: Center">No Records Entered</div>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#013161" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                                <td></td>
                            </tr>




                            <tr>
                                <td colspan="6" style="padding-top:10px">
                                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">6. Benificiary Details</h5>
                                </td>
                            </tr>
                            <%-- <table id="Table4" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%">--%>
                            <tr>
                                <td style="vertical-align: middle; padding: 5px;" align="left">1. Unit Name:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtuitname" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">2. Line Of Activity:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtloakvt" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>

                                <td style="padding: 5px; margin: 5px;" align="left">3. Product Name:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtpname" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" align="left">4. Production Per Annum: </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtprodctonpa" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">5. Units:</td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddl_Units" runat="server" Style="width: 200px;" class="form-control txtbox" AutoPostBack="true" TabIndex="1" OnSelectedIndexChanged="ddl_Units_SelectedIndexChanged">
                                        <asp:ListItem Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Text="Nos"></asp:ListItem>
                                        <asp:ListItem Text="Tons"></asp:ListItem>
                                        <asp:ListItem Text="Kgs"></asp:ListItem>
                                        <asp:ListItem Text="Other"></asp:ListItem>
                                    </asp:DropDownList></td>

                                <td style="padding: 5px; margin: 5px;" align="left">6. Date of Commencement of Production:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtDateOfCommencement" autocomplete="off" runat="server" TabIndex="1" Style="width: 200px;" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" align="left">7. Employment:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtemlynt" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left" visible="false" runat="server" id="lblunits">5a. Enter other units</td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtUnits" runat="server" Visible="false" Style="width: 200px;" autocomplete="off" class="form-control"> </asp:TextBox>
                                </td>
                            </tr>


                            <%-- <table width="100%" align="center">--%>
                            <tr>
                                <td colspan="6">
                                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">7. Unit Financials (Amount in lakhs)</h5>
                                </td>
                            </tr>
                            <%--<table id="Table5" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%">--%>
                            <tr>
                                <td style="vertical-align: middle; padding: 5px;" align="left">1. Investment:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtinvrstment" runat="server" Style="width: 200px;" class="form-control" autocomplete="off" Enabled="false"></asp:TextBox>
                                    <asp:HiddenField ID="hfInvestment" runat="server" />
                                    <%--<asp:TextBox ID="txtinvrstment" runat="server" class="form-control"></asp:TextBox>--%>
                                </td>

                                <td style="padding: 5px; margin: 5px;" align="left">2. Bank Loan:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtbkloan" runat="server" Style="width: 200px;" TabIndex="1" onkeyup="calculateSum()" onkeypress="NumberOnly()" autocomplete="off" class="form-control" oninput="calculateSum()"></asp:TextBox>
                                    <%--<asp:TextBox ID="txtbkloan" runat="server" class="form-control" onkeyup="calculateSum()"></asp:TextBox>--%>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">3. Beneficiary Contribution:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtbenfryctrion" runat="server" Style="width: 200px;" TabIndex="1" onkeyup="calculateSum()" onkeypress="NumberOnly()" autocomplete="off" class="form-control" oninput="calculateSum()"></asp:TextBox>
                                    <%--<asp:TextBox ID="txtbenfryctrion" runat="server" class="form-control"  onkeyup="calculateSum()"></asp:TextBox>--%>
                                </td>

                            </tr>
                            <tr>
                                <%--<td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Production:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtprodcton" runat="server" class="form-control"></asp:TextBox>
                                </td>--%>
                                <td style="padding: 5px; margin: 5px;" align="left">4. Subsidy Claim:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtsubclaim" runat="server" Style="width: 200px;" TabIndex="1" onkeypress="NumberOnly()" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">5. MM Adjustments:
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtmmadjsmts" runat="server" Style="width: 200px;" TabIndex="1" onkeypress="NumberOnly()" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lbllabel" runat="server"></asp:Label></td>
                            </tr>
                            <%--</table>
                                    </td>
                                </tr>
                            </table>--%>
                            <%--                        <table width="100%" align="center">--%>
                            <tr>
                                <td colspan="6">
                                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">8. Present State</h5>
                                </td>
                            </tr>
                            <%--<table id="Table6" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" class="nav-justified">--%>
                            <tr>
                                <td></td>
                                <td style="vertical-align: middle; padding: 5px;" align="left">1. Annual Sales (Rs.in Lakhs):
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtanalsales" runat="server" Style="width: 200px;" TabIndex="1" onkeypress="NumberOnly()" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px;" align="left">2. Annual Profit (Rs.in Lakhs):
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="txtannalprfit" runat="server" Style="width: 200px;" TabIndex="1" onkeypress="NumberOnly()" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="padding: 5px; margin: 5px; width: 250px;" align="left" class="auto-style14">3. Loan Repayment Completed(Y/N):
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 200px;">
                                    <%--                                <asp:TextBox ID="txtrepament" runat="server" Style="width: 160px;" TabIndex="1" oninput="validateInput(this);" autocomplete="off" class="form-control"></asp:TextBox>--%>
                                    <asp:RadioButtonList ID="txtrepament" runat="server" Style="width: 160px;" TabIndex="1" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                        <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 200px;" align="left" class="auto-style15">4. Physical Verification Date:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 200px;">
                                    <asp:TextBox ID="txtDate" runat="server" Style="width: 200px;" TabIndex="1" autocomplete="off" class="form-control"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <%--</table>
                                </td>
                            </tr>
                        </table>
                        <br />--%>
                            <%--<table width="80%" align="left" style="margin-left: 2%;">--%>
                            <tr>
                                <td colspan="6">
                                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">9. Upload Attachments</h5>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px;" align="left">1. Please Upload Applicant Photo here&nbsp; </td>
                                <td>
                                    <asp:FileUpload ID="fileUploadControl" runat="server" AutoPostback="false" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px;" align="left">2. Please Upload Unit Photo here&nbsp; 

                                </td>
                                <td>
                                    <asp:FileUpload ID="fileUpload1" runat="server" AutoPostBack="false" />
                                </td>
                            </tr>
                           
                            <tr>
                                <td colspan="6">
                                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">10. Impact Assesment</h5>
                                </td>
                            </tr>

                            <tr>
                                <th></th>
                                <th></th>
                                <th style="text-align: center; font-size: medium;">Before</th>
                                <th style="text-align: center; font-size: medium;">After</th>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px;">1. Assets Value (Amount In Lakhs):</td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="TextBox2" runat="server" Style="width: 200px;" Width="200px" autocomplete="off" TabIndex="1" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="TextBox3" runat="server" Style="width: 200px;" Width="200px" autocomplete="off" TabIndex="1" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px;" >2. House (Area In Square Yards):</td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="TextBox4" runat="server" Style="width: 200px;" Width="200px" autocomplete="off" TabIndex="1" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="TextBox5" runat="server" Style="width: 200px;" Width="200px" autocomplete="off" TabIndex="1" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px;">3. Land (Area In Acres):</td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="TextBox6" runat="server" Style="width: 200px;" Width="200px" autocomplete="off" TabIndex="1" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="TextBox7" runat="server" Style="width: 200px;" Width="200px" autocomplete="off" TabIndex="1" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px;">4. Vehicles (2/4 Wheeler):</td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlVehicleBefore" runat="server" Style="width: 200px;" Width="200px" class="form-control" AutoPostBack="false" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">2 Wheeler</asp:ListItem>
                                        <asp:ListItem Value="2">4 Wheeler</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlVehicleAfter" runat="server" Style="width: 200px;" Width="200px" class="form-control" AutoPostBack="false" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">2 Wheeler</asp:ListItem>
                                        <asp:ListItem Value="2">4 Wheeler</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px;">5. Health (Treatment From (GOVT/PVT):</td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlhealthbefore" runat="server" Style="width: 200px;" Width="200px" class="form-control" AutoPostBack="false" TabIndex="1" OnSelectedIndexChanged="ddlhealthbefore_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">GOVERNMENT</asp:ListItem>
                                        <asp:ListItem Value="2">PRIVATE</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlhealthafter" runat="server" Style="width: 200px;" Width="200px" class="form-control" AutoPostBack="false" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">GOVERNMENT</asp:ListItem>
                                        <asp:ListItem Value="2">PRIVATE</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px;">6. Children Education (GOVT/PVT):</td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlchildeducationbefore" runat="server" Style="width: 200px;" Width="200px" class="form-control" AutoPostBack="false" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">GOVERNMENT</asp:ListItem>
                                        <asp:ListItem Value="2">PRIVATE</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:DropDownList ID="ddlchildeducationafter" runat="server" Style="width: 200px;" Width="200px" class="form-control" AutoPostBack="false" TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">GOVERNMENT</asp:ListItem>
                                        <asp:ListItem Value="2">PRIVATE</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; margin: 5px;">7. Re-Investment (Expansion)(Amount In Lakhs):</td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="TextBox14" runat="server" TabIndex="1" Style="width: 200px;" Width="200px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                                <td style="padding: 5px; margin: 5px;">
                                    <asp:TextBox ID="TextBox15" runat="server" TabIndex="1" Style="width: 200px;" Width="200px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                            </tr>

                        </table>


                        <div style="padding-left: 30px; width: 100%; align-content: center">
                            <br />
                            <table align="center" style="margin: 0 auto;">
                                <tr>
                                    <td style="text-align: center; padding-top: 30px">
                                        <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" Style="background-color: forestgreen; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="btnSubmit_Click" />
                                    </td>
                                    <td style="text-align: center; padding-top: 30px">
                                        <asp:Button ID="btnPrint" runat="server" Text="PRINT" Style="background-color: blue; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="btnPrint_Click" />
                                    </td>
                                    <td style="text-align: center; padding-top: 30px">
                                        <asp:Button ID="Btn_Cancel" runat="server" Text="CANCEL" Style="background-color: red; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="Btn_Cancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%-- </div>--%>
                        <%-- </contenttemplate>--%>
                    </div>

                </div>
            </div>
        </div>

    </div>
    <%-- //Added --%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="pan-validation.js" type="text/javascript"></script>
    <br />
    <br />




</asp:Content>

