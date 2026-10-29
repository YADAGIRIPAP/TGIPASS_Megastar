<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmPMEGPSuccessStories.aspx.cs" Inherits="UI_TSiPASS_frmPMEGPSuccessStories" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <style type="text/css">
        td.top-bar {
    display: none;
}
        .logo img {
    margin-top: -30px;
}
        section#form {
    margin-top: -30px;
}
        .col-md-12 {
    padding: 0px 10px;
    margin: 6px 0px;
    border: 1px solid #ccc;
    border-radius: 8px;
    box-shadow: 1px 2px 3px #ccc;
}
        .col-md-2 {
    margin: -10px 0px;
}
        table#oldcode {
    display: none;
}
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
        $(document).ready(function () {
            $('input[type="text"]').on('paste', function (e) {
                e.preventDefault();
            });
        });
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

        td#MstLftMenu {
            display: none;
        }

        .algnCenter {
            text-align: center;
        }

        h4 {
            font-weight: 600;
            font-family: 'Raleway';
            text-transform: capitalize;
        }
    </style>
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
    <contenttemplate>
        <br />
        <form>
            <section id="form">
                <div class="container-fluid">
                    <div class="row">
                        <%--BENIFICIARY DETAILS--%>
                        <div class="col-md-12">
                            <h4 style="position: relative;margin-top: -7px;background: #fff;width: 12%;border-radius: 20px;margin-left: 15px;">Benificiary Details</h4>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Applicant Name:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Father/Spouse Name:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail2" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Age:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail3" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Special Category:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Education Qualification:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Social Status:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <%--second row ADDRESS Details--%>
                        <div class="col-md-12">
                            <h4 style="position: relative;margin-top: -7px;background: #fff;width: 12%;border-radius: 20px;margin-left: 15px;">Address</h4>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">H. No:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Street:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail2" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Village/Ward:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail3" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Mandal/Municipality:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">District:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Region/Area:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <%--Third row UNIQUE IDENTIFIERS Details--%>
                        <div class="col-md-12">
                            <h4 style="position: relative;margin-top: -7px;background: #fff;width: 12%;border-radius: 20px;margin-left: 15px;">Unique Identifiers</h4>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Aadhar Card No.:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">PAN No.:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail2" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Udyam Registration No.:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail3" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Ration Card No.:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Phone No.:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <%--<div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Email Id::</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>--%>
                            
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">PMEGP Id:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <%--Fourth Row TRAINING & Family Details--%>
                        <div class="col-md-12">
                            <div class="col-md-4">
                          <h4 style="position: relative;margin-top: -7px;background: #fff;width: 12%;border-radius: 20px;margin-left: 15px;">Training</h4>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">EDP Certificate from Which Training Institute:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Any Other Training Programs Attended(Y/N):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail2" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            </div>
                            <div class="col-md-8">
                            <h4 style="position: relative;margin-top: -7px;background: #fff;width: 16%;border-radius: 20px;margin-left: 15px;">Family Details</h4>
                                <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Relation:<br /><BR /></label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                                 <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Name:<br /><BR /></label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                                 <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Age:<br /><BR /></label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                                 <div class="col-md-3">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Profession:<br /><BR /></label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                                </div>
                            
                            
                        </div>


                        <%--Five Row BENIFICIARY DETAILS--%>
                        <div class="col-md-12">
                            <h4 style="position: relative;margin-top: -7px;background: #fff;width: 12%;border-radius: 20px;margin-left: 15px;">Benificiary Details</h4>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Unit Name:<br /><br /></label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Line Of Activity:<br /><br /></label>
                                    <input type="email" class="form-control" id="exampleInputEmail2" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Product Name:<br /><br /></label>
                                    <input type="email" class="form-control" id="exampleInputEmail3" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Units Of Production Per Annum:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Units Of Production Per Annum:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Employment:<br /><br /></label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <%--Six Row BENIFICIARY DETAILS--%>
                        <div class="col-md-12">
                            <h4 style="position: relative;margin-top: -7px;background: #fff;width: 22%;border-radius: 20px;margin-left: 15px;">Unit Financials (Amount in lakhs) </h4>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Beneficiary Contribution:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Bank Loan:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail2" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Investment:</label>
                                    <input type="email" class="form-control" id="exampleInputEmail3" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Subsidy Claim:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">MM Adjustments:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Employment:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <%--Seven Row BENIFICIARY DETAILS--%>
                        <div class="col-md-12">
                            <h4 style="position: relative;margin-top: -7px;background: #fff;width: 12%;border-radius: 20px;margin-left: 15px;">Present State</h4>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Annual Sales <br />(Rs.in Lakhs):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Annual Profit <br />(Rs.in Lakhs):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail2" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Loan Repayment Completed (Y/N):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail3" aria-describedby="emailHelp" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Physical Verification <br />Date:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Please Upload Applicant Photo here in this Section:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Please Upload Unit Photo here in this Section:</label>
                                    <select class="form-control" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <%--Eight Row IMPACT ASSESMENT--%>
                        <div class="col-md-12">
                            <h4 style="position: relative;margin-top: -7px;background: #fff;width: 12%;border-radius: 20px;margin-left: 15px;">Impact Assesment</h4>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">ASSETS VALUE <br />(AMOUNT IN LAKHS):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Before">
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="After">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">HOUSE (AREA IN SQUARE YARDS):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Before">
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="After">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">LAND<br /> (AREA IN ACRES):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Before">
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="After">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">VEHICLES<br /> (2/4 WHEELER):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Before">
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="After">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">HEALTH (TREATMENT FROM GOVT/PVT):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Before">
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="After">
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">CHILDREN EDUCATION<br /> (GOVT/PVT):</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Before">
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="After">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                RE-INVESTMENT (EXPANSION)(AMOUNT IN LAKHS):
                                    </div>
                            </div>
                             <div class="col-md-3">
                                <div class="form-group">
                                   
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Before">
                                   
                                </div>
                            </div>
                             <div class="col-md-3">
                                <div class="form-group">
                                    
                                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="After">
                                </div>
                            </div>

                        </div>

                        <div class="col-md-12">
                            <div class="col-md-6"></div>
                            <div class="col-md-3">
                                <button type="submit" class="btn btn-primary">Submit</button>
                            </div>
                            <div class="col-md-3">
                                <button type="submit" class="btn btn-primary">Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

        </form>
        <table width="100%" align="center" id="oldcode">
            <tr>
                <td>
                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">BENIFICIARY DETAILS</h5>
                    <table id="Beneficiary_Block" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                        <tr id="trdates" runat="server" visible="true">
                            <td style="vertical-align: middle; padding: 15px; font-weight: bold;" align="left" class="auto-style1">Applicant Name:
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="aplicantname" runat="server" oninput="validateInputName(this)" TabIndex="1" autocomplete="off" ValidationGroup="group" class="form-control"> </asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Father/Spouse Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtfname" runat="server" oninput="validateInputName(this)" TabIndex="1" autocomplete="off" ValidationGroup="group" class="form-control"> </asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Age:
                            </td>
                            <td style="width: 120px;">
                                <asp:TextBox ID="txtage" runat="server" autocomplete="off" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Special Category:
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txtqualification" runat="server" class="form-control" oninput="validateInput(this)" TabIndex="1" ValidationGroup="group"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlSpecialCategory" runat="server" class="form-control"></asp:DropDownList>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Education Qualification:
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txtqualification" runat="server" class="form-control" oninput="validateInput(this)" TabIndex="1" ValidationGroup="group"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlEducation" runat="server" class="form-control"></asp:DropDownList>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Social Status:
                            </td>
                            <td>
                                <%--<asp:TextBox ID="txtcaste" runat="server" oninput="validateInput(this)" TabIndex="1" ValidationGroup="group" class="form-control"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlCaste" runat="server" class="form-control"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%" align="center" id="oldcode">
            <tr>
                <td>
                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">ADDRESS</h5>
                    <table id="Table1" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                        <tr id="tr1" runat="server" visible="true">
                            <td style="vertical-align: middle; padding: 15px; font-weight: bold;" align="left" class="auto-style1">H.NO:
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txthno" runat="server" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Street:
                            </td>
                            <td>
                                <asp:TextBox ID="txtstreet" runat="server" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Village/Ward:
                            </td>
                            <td>
                                <asp:TextBox ID="txtvillage" runat="server" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Mandal/Municipality:
                            </td>
                            <td>
                                <asp:TextBox ID="txtmandal" runat="server" autocomplete="off" class="form-control" TabIndex="3"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">District:
                            </td>
                            <td>
                                <asp:TextBox ID="txtdistrict" runat="server" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Region/Area:
                            </td>
                            <td style="font-weight: bold;">
                                <asp:RadioButtonList ID="RadioButton" runat="server" RepeatDirection="Horizontal" class="form-control" CssClass="radio-list">
                                    <asp:ListItem Text="URBAN" Value="Urban" />
                                    <asp:ListItem Text="RURAL" Value="Rural" />
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%" align="center" id="oldcode">
            <tr>
                <td>
                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">UNIQUE IDENTIFIERS</h5>
                    <table id="Table2" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                        <tr id="tr2" runat="server" visible="true">
                            <td style="vertical-align: middle; padding: 15px; font-weight: bold;" align="left" class="auto-style1">Aadhar Card No.:
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtadhar" runat="server" MaxLength="14" onkeypress="NumberOnly()" oninput="formatTextbox(this)" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">PAN No.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtpannber" runat="server" MaxLength="10" autocomplete="off" oninput="validatePAN(this)" class="form-control"></asp:TextBox>
                                <span id="panValidationMessage"></span>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Udyam Registration No.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtrgnumber" runat="server" autocomplete="off" oninput="CapitalizeText(this)" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Ration Card No.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtrcnmber" runat="server" autocomplete="off" oninput="CapitalizeText(this)" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Phone No.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtpnenmber" runat="server" autocomplete="off" onkeypress="NumberOnly()" onkeyup="validatePhoneNumber()" MaxLength="10" class="form-control"></asp:TextBox>
                                <div id="error" style="color: red;"></div>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Email Id:
                            </td>
                            <td>
                                <asp:TextBox ID="txtmail" runat="server" autocomplete="off" oninput="CapitalizeText(this)" onkeyup="validateEmail(this.value)" class="form-control"></asp:TextBox>
                                <span id="error-message" style="color: red;"></span></td>
                        </tr>
                        <tr>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">PMEGPID:
                            </td>
                            <td>
                                <asp:TextBox ID="PMEGP_ID_TSIPASS" runat="server" oninput="CapitalizeText(this)" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%" align="center" id="oldcode">
            <tr>
                <td>
                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">TRAINING</h5>
                    <table id="Table3" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                        <tr id="tr3" runat="server" visible="true">
                            <td style="vertical-align: middle; padding: 15px; font-weight: bold;" align="left" class="auto-style1">EDP Certificate from Which Training Institute:
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtedpcerticte" runat="server" autocomplete="off" class="form-control"> </asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Any Other Training Programs Attended(Y/N):
                            </td>
                            <td>
                                <asp:TextBox ID="txtatendprgrm" runat="server" autocomplete="off" oninput="validateInput(this);" class="form-control"> </asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%" align="center" id="oldcode">
            <tr>
                <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">FAMILY DETAILS</h5>
            </tr>
            <tr>
                <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Relation:
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control txtbox"
                        AutoPostBack="false" Height="33px" TabIndex="1">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Spouse</asp:ListItem>
                        <asp:ListItem Value="2">Child 1</asp:ListItem>
                        <asp:ListItem Value="3">Child 2</asp:ListItem>
                        <asp:ListItem Value="4">Child 3</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="vertical-align: middle; padding: 15px; font-weight: bold;" align="left" class="auto-style1">Name:
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" class="form-control txtbox" oninput="validateInputName(this)" autocomplete="off" Width="280px" Height="32px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                </td>
                <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Age:
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" autocomplete="off" runat="server" class="form-control txtbox" Width="80px" Height="32px" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                </td>
                <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Profession:
                </td>
                <td>
                    <asp:TextBox ID="txtProfession" autocomplete="off" runat="server" oninput="validateInputName(this)" class="form-control txtbox" Width="280px" Height="32px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <div class="col-xs-12" style="text-align: center; margin-top: -10px;" id="oldcode">
            <asp:Button ID="btnaddfamily" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                TabIndex="10" Text="Add" ValidationGroup="child" Width="90px" OnClick="btnaddfamily_Click" />
            &nbsp;<asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click"
                CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10"
                Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
        </div>
        <br />
        <div class="col-xs-12" style="text-align: center; margin-top: 12px" id="oldcode">
            <b style="color: red">Please click on Add after entering details.</b>
        </div>
        <br />
        <asp:GridView ID="GVFamily" runat="server" AutoGenerateColumns="False" OnRowDeleting="GVFamily_RowDeleting" ShowHeaderWhenEmpty="true" CellPadding="2"
            CssClass="GRD" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px"
            ForeColor="#333333" AutoPostBack="true" Width="100%">
            <HeaderStyle CssClass="gridcolor" />
            <RowStyle BackColor="#ffffff" />
            <Columns>
                <asp:TemplateField HeaderText="S No.">
                    <ItemTemplate>
                        <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label></ItemTemplate>
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
        <br />
        <br />
        <table width="100%" align="center" id="oldcode">
            <tr>
                <td>
                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">BENIFICIARY DETAILS</h5>
                    <table id="Table4" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                        <tr id="tr4" runat="server" visible="true">
                            <td style="vertical-align: middle; padding: 15px; font-weight: bold;" align="left" class="auto-style1">Unit Name:
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtuitname" runat="server" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Line Of Activity:
                            </td>
                            <td>
                                <asp:TextBox ID="txtloakvt" runat="server" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Product Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtpname" runat="server" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Units Of Production Per Annum:
                            </td>
                            <td>
                                <asp:TextBox ID="txtprodctonpa" runat="server" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Date of Commencement of Production:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateOfCommencement" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Employment:
                            </td>
                            <td>
                                <asp:TextBox ID="txtemlynt" runat="server" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%" align="center" id="oldcode">
            <tr>
                <td>
                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">UNIT FINANCIALS (Amount in lakhs)</h5>
                    <table id="Table5" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                        <tr id="tr5" runat="server" visible="true">
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Beneficiary Contribution:
                            </td>
                            <td>
                                <asp:TextBox ID="txtbenfryctrion" runat="server" onkeypress="NumberOnly()" autocomplete="off" class="form-control" oninput="calculateSum()"></asp:TextBox>
                                <%--<asp:TextBox ID="txtbenfryctrion" runat="server" class="form-control"  onkeyup="calculateSum()"></asp:TextBox>--%>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Bank Loan:
                            </td>
                            <td>
                                <asp:TextBox ID="txtbkloan" runat="server" onkeypress="NumberOnly()" autocomplete="off" class="form-control" oninput="calculateSum()"></asp:TextBox>
                                <%--<asp:TextBox ID="txtbkloan" runat="server" class="form-control" onkeyup="calculateSum()"></asp:TextBox>--%>
                            </td>
                            <td style="vertical-align: middle; padding: 15px; font-weight: bold;" align="left" class="auto-style1">Investment:
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtinvrstment" runat="server" class="form-control" autocomplete="off" Enabled="false"></asp:TextBox>
                                <asp:HiddenField ID="hfInvestment" runat="server" />
                                <%--<asp:TextBox ID="txtinvrstment" runat="server" class="form-control"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <%--<td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Production:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtprodcton" runat="server" class="form-control"></asp:TextBox>
                                </td>--%>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Subsidy Claim:
                            </td>
                            <td>
                                <asp:TextBox ID="txtsubclaim" runat="server" onkeypress="NumberOnly()" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">MM Adjustments:
                            </td>
                            <td>
                                <asp:TextBox ID="txtmmadjsmts" runat="server" onkeypress="NumberOnly()" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%" align="center" id="oldcode">
            <tr>
                <td>
                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">PRESENT STATE</h5>
                    <table id="Table6" runat="server" autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                        <tr id="tr6" runat="server" visible="true">
                            <td style="vertical-align: middle; padding: 15px; font-weight: bold;" align="left" class="auto-style1">Annual Sales (Rs.in Lakhs):
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtanalsales" runat="server" onkeypress="NumberOnly()" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Annual Profit (Rs.in Lakhs):
                            </td>
                            <td>
                                <asp:TextBox ID="txtannalprfit" runat="server" onkeypress="NumberOnly()" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Loan Repayment Completed(Y/N):
                            </td>
                            <td>
                                <asp:TextBox ID="txtrepament" runat="server" oninput="validateInput(this);" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                            <td style="padding: 15px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Physical Verification Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server" autocomplete="off" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%" align="left" id="oldcode">
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Please Upload Applicant Photo here in this Section: </td>
                <td>
                    <asp:FileUpload ID="fileUploadControl" runat="server" AutoPostback="false" />
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" align="left" class="auto-style6">Please Upload Unit Photo here in this Section: </td>
                <td>
                    <asp:FileUpload ID="fileUpload1" runat="server" AutoPostBack="false" />
                </td>
            </tr>
        </table>
        <br />
        <table autopostback="true" align="left" cellpadding="10" cellspacing="5" style="width: 100%" id="oldcode">
            <h5 class="text-blue font-SemiBold col col-sm-12 mt-3" style="text-align: center; font-size: large; text-decoration: underline; font-weight: bold">IMPACT ASSESMENT</h5>
            <tr>
                <th></th>
                <th style="text-align: center; font-size: medium; text-decoration: underline; font-weight: bold">BEFORE</th>
                <th style="text-align: center; font-size: medium; text-decoration: underline; font-weight: bold">AFTER</th>
            </tr>
            <tr>
                <td style="font-weight: bold;">ASSETS VALUE (AMOUNT IN LAKHS):</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="350px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="350px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold;">HOUSE (AREA IN SQUARE YARDS):</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="350px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="350px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold;">LAND (AREA IN ACRES):</td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Width="350px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Width="350px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="font-weight: bold;">VEHICLES (2/4 WHEELER):</td>
                <td>
                    <asp:DropDownList ID="ddlVehicleBefore" runat="server" Width="350px" class="form-control" AutoPostBack="false" TabIndex="1">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="1">2 Wheeler</asp:ListItem>
                        <asp:ListItem Value="2">4 Wheeler</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="ddlVehicleAfter" runat="server" Width="350px" class="form-control" AutoPostBack="false" TabIndex="1">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="1">2 Wheeler</asp:ListItem>
                        <asp:ListItem Value="2">4 Wheeler</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="font-weight: bold;">HEALTH (TREATMENT FROM GOVT/PVT):</td>
                <td>
                    <asp:DropDownList ID="ddlhealthbefore" runat="server" Width="350px" class="form-control" AutoPostBack="false" TabIndex="1">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="1">GOVERNMENT</asp:ListItem>
                        <asp:ListItem Value="2">PRIVATE</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="ddlhealthafter" runat="server" Width="350px" class="form-control" AutoPostBack="false" TabIndex="1">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="1">GOVERNMENT</asp:ListItem>
                        <asp:ListItem Value="2">PRIVATE</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="font-weight: bold;">CHILDREN EDUCATION (GOVT/PVT):</td>
                <td>
                    <asp:DropDownList ID="ddlchildeducationbefore" runat="server" Width="350px" class="form-control" AutoPostBack="false" TabIndex="1">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="1">GOVERNMENT</asp:ListItem>
                        <asp:ListItem Value="2">PRIVATE</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="ddlchildeducationafter" runat="server" Width="350px" class="form-control" AutoPostBack="false" TabIndex="1">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="1">GOVERNMENT</asp:ListItem>
                        <asp:ListItem Value="2">PRIVATE</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="font-weight: bold;">RE-INVESTMENT (EXPANSION)(AMOUNT IN LAKHS):</td>
                <td>
                    <asp:TextBox ID="TextBox14" runat="server" Width="350px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server" Width="350px" autocomplete="off" onkeypress="NumberOnly()" class="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td>.</td>
            </tr>
        </table>
        <div align="center" id="oldcode">
            <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" Style="background-color: forestgreen; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnPrint" runat="server" Text="PRINT" Style="background-color: blue; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="btnPrint_Click" />
            <asp:Button ID="Btn_Cancel" runat="server" Text="CANCEL" Style="background-color: red; color: ghostwhite; border-radius: 5px;" Height="35px" Width="150px" OnClick="Btn_Cancel_Click" />
        </div>
    </contenttemplate>
    <%-- //Added --%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="pan-validation.js" type="text/javascript"></script>
    <%--xgfhjkljhgfcgvhb--%>
    
    
</asp:Content>

