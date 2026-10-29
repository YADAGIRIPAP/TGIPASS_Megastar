<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="~/UI/TSiPASS/frmDraftQuestionnaireTourisamEvent.cs"
    Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
    <style type="text/css">
        .overlay
        {
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
        
        .style5
        {
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
    <%-- <script type="text/javascript">
     function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
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



        //  For a given number generates a Verhoeff digit

        //         Validates that an entered number is Verhoeff compliant.

        function validateVerhoeff() {
            //document.getElementById('txtadhar1'+'txtadhar2'+'txtadhar3').value

            var num = document.getElementById("<%=txtadhar1.ClientID %>").value + document.getElementById("<%=txtadhar2.ClientID %>").value + document.getElementById("<%=txtadhar3.ClientID %>").value;
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
                //alert("Valid UID");
            }
            else {

                alert("This is not Valid Aadhar Number");
                document.getElementById("<%=txtadhar1.ClientID %>").value = "";
                document.getElementById("<%=txtadhar2.ClientID %>").value = "";
                document.getElementById("<%=txtadhar3.ClientID %>").value = "";
            }
        }



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
        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter DecimalValues Only");
            }
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
        function Classification() {
            debugger;
            if (document.getElementById('rbtClassificationofEvent').checked) {
                var rate_value = document.getElementById('rbtClassificationofEvent').value;
                if (rate_value == "0") {
                    alert("test 0");
                }
                else {
                    alert("test 1");
                }
            }
            //         $('input:radio[name="rbtClassificationofEvent"]').change(function () {

            //if($(this).val() == '0'){
            //   alert("test");
            //}
        });
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
    <%--     
<asp:updatepanel id="upd1" runat="server">
        <contenttemplate>--%>
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
                            QUESTIONNAIRE FOR TOURISM EVENTS - PERFORMANCE LICENSE</h3>
                    </div>
                    <div class="col-md-12">
                        <h1 class="page-head-line" align="left" style="font-size: x-large">
                            QUESTIONNAIRE FOR TOURISM EVENTS - PERFORMANCE LICENSE</h1>
                    </div>
                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                    <div class="panel-body" align="left">
                        <table align="left" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 70%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Type of Event<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlTypeofEvent" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px" OnSelectedIndexChanged="ddlTypeofEvent_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvddlTypeofEvent" runat="server" ControlToValidate="ddlTypeofEvent"
                                                    ErrorMessage="Please Select Type of Event" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Classification of the event<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtClassificationofEvent" class="form-control txtbox" onchange="Classification()"
                                                    Height="40px" Width="220px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Major Event" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Minor Event" Value="1"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtClassificationofEvent" runat="server" ControlToValidate="rbtClassificationofEvent"
                                                    ErrorMessage="Please select Classification of Event" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>3.</b>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px"><b>Applicant Details</b><font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Name of the applicant<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNameofTheApplicant" runat="server" class="form-control txtbox"
                                                    MaxLength="250" onkeypress="Names()" Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNameofTheApplicant" runat="server" ControlToValidate="txtNameofTheApplicant"
                                                    ErrorMessage="Please Enter Name of TheApplicant" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Father’s Name<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtFatherName" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                    Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtFatherName" runat="server" ControlToValidate="txtFatherName"
                                                    ErrorMessage="Please Enter Father’s Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Aadhaar Card Number<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%-- <asp:TextBox ID="txtAadharNumber" onkeypress="NumberOnly()" TabIndex="1" runat="server" MaxLength="12" class="form-control txtbox"
                                                                    Height="28px" Width="180px"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtadhar1" autocomplete="off" onkeypress="NumberOnly()" TabIndex="1"
                                                    onpaste="return false" runat="server" class="textboxPge" MaxLength="4" Width="56px"></asp:TextBox>
                                                <asp:TextBox ID="txtadhar2" autocomplete="off" TabIndex="1" onpaste="return false"
                                                    runat="server" class="textboxPge" onkeypress="NumberOnly()" MaxLength="4" Width="56px"></asp:TextBox>
                                                <asp:TextBox onblur="validateVerhoeff()" autocomplete="off" onkeypress="NumberOnly()"
                                                    TabIndex="1" ID="txtadhar3" onpaste="return false" runat="server" class="textboxPge"
                                                    MaxLength="4" Width="56px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">PAN Card Number<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtPanNumber" runat="server" MaxLength="10" class="form-control txtbox"
                                                    onblur="fnValidatePAN(this);" Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvPanCard" runat="server" ControlToValidate="txtPanNumber"
                                                    ErrorMessage="Please Enter PAN Card" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label70" runat="server" CssClass="LBLBLACK" Width="210px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label81" runat="server" CssClass="LBLBLACK" Width="210px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlmandal" runat="server" class="form-control txtbox" Height="28px"
                                                    AutoPostBack="true" TabIndex="1" ValidationGroup="group" Width="180px" OnSelectedIndexChanged="ddlmandal_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                e.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label82" runat="server" CssClass="LBLBLACK" Width="210px">Village<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlvillage" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                f.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Address of the applicant :<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtAddressWithContact" TextMode="MultiLine" TabIndex="1" runat="server"
                                                    class="form-control txtbox" Height="100px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtAddressWithContact" runat="server" ControlToValidate="txtAddressWithContact"
                                                    ErrorMessage="Please Enter Address of the applicant along with contact number:"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                g.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label83" runat="server" CssClass="LBLBLACK" Width="165px">PINCODE<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtpincode" onkeypress="NumberOnly()" runat="server" MaxLength="6"
                                                    class="form-control txtbox" Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                h.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label65" runat="server" CssClass="LBLBLACK" Width="165px">Mobile Number<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtMobileNumberApplicant" onkeypress="NumberOnly()" runat="server"
                                                    MaxLength="10" class="form-control txtbox" Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtMobileNumber" runat="server" ControlToValidate="txtMobileNumberApplicant"
                                                    ErrorMessage="Please Enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                i.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label77" runat="server" CssClass="LBLBLACK" Width="165px">Email ID<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtEmailID" runat="server" class="form-control txtbox" Height="28px"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtEmailID" runat="server" ControlToValidate="txtEmailID"
                                                    ErrorMessage="Please Enter Email ID" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmailID"
                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: left;">
                                                <b>4.</b>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label79" runat="server" CssClass="LBLBLACK" Width="337px"><b>Event Management Company / Organization Details</b><font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="285px">Name of the Event Management Company / Organization<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNameAddEventManagement" runat="server" TextMode="MultiLine" TabIndex="1"
                                                    class="form-control txtbox" onkeypress="Names()" Height="50px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNameAddEventManagement" runat="server" ControlToValidate="txtNameAddEventManagement"
                                                    ErrorMessage="Please Enter Name and address of the Event Management Company"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label84" runat="server" CssClass="LBLBLACK" Width="210px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlcompanydistrict" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px" OnSelectedIndexChanged="ddlcompanydistrict_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label85" runat="server" CssClass="LBLBLACK" Width="210px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlcompanymandal" runat="server" class="form-control txtbox"
                                                    Height="28px" AutoPostBack="true" TabIndex="1" ValidationGroup="group" Width="180px"
                                                    OnSelectedIndexChanged="ddlcompanymandal_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label86" runat="server" CssClass="LBLBLACK" Width="210px">Village<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlcompanyvillage" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                e.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label66" runat="server" CssClass="LBLBLACK" Width="165px">Address<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtcompanyaddress" runat="server" TextMode="MultiLine" TabIndex="1"
                                                    class="form-control txtbox" Height="100px" Width="175px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNameAddEventManagement"
                                                    ErrorMessage="Please Enter Name and address of the Event Management Company"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                g.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label87" runat="server" CssClass="LBLBLACK" Width="165px">PINCODE<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtcompanypincode" onkeypress="NumberOnly()" runat="server" MaxLength="6"
                                                    class="form-control txtbox" Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">GST No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtGSTNumber" TabIndex="1" runat="server" MaxLength="16" class="form-control txtbox"
                                                    onkeypress="CharnumOnly()" Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtGSTNumber" runat="server" ControlToValidate="txtGSTNumber"
                                                    ErrorMessage="Please Enter GST Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="270px">Name and location of the place where the performance is to be held <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNameLocPerformance" MaxLength="250" runat="server" TextMode="MultiLine"
                                                    class="form-control txtbox" Height="100px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNameLocPerformance" runat="server" ControlToValidate="txtNameLocPerformance"
                                                    ErrorMessage="Please Enter Name and location of the place where the performance is to be held"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                6a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label78" runat="server" CssClass="LBLBLACK" Width="165px">Area(In sq.mts) <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtarea" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="1" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtarea"
                                                    ErrorMessage="Please enter area in sq.mts" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="323px">Type of structure planned<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlstructureType" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlstructureType_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Temporary</asp:ListItem>
                                                    <asp:ListItem Value="2">Permanent</asp:ListItem>
                                                    <asp:ListItem Value="3">Closed</asp:ListItem>
                                                    <asp:ListItem Value="4">Open</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvddlstructureType" runat="server" ControlToValidate="ddlstructureType"
                                                    ErrorMessage="Please Select Type of structure planned" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="165px">No. of stalls<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNoofStalls" MaxLength="4" onkeypress="NumberOnly()" TabIndex="1"
                                                    runat="server" class="form-control txtbox" Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNoofStalls" runat="server" ControlToValidate="txtNoofStalls"
                                                    ErrorMessage="Please No. of stalls" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>8.</b>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="165px"><b>Stall Specification</b></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="165px">Size (Sqt Meters)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtSize" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px" MaxLength="40" TabIndex="1" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvSize" runat="server" ControlToValidate="txtSize"
                                                    ErrorMessage="Please enter Size" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="165px">Fabrication Material used<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFabrication" runat="server" class="form-control txtbox"
                                                    Height="28px" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvddlFabrication" runat="server" ControlToValidate="ddlFabrication"
                                                    ErrorMessage="Please Select Fabrication Material details with the detailed plan and drawings"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="333px">Whether there is proposed to be a clear space of 3 mts. on all sides of the structure and the adjacent buildings or other structures<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtclearspace" class="form-control txtbox" Height="33px"
                                                    Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtclearspace" runat="server" ControlToValidate="rbtclearspace"
                                                    ErrorMessage="Please Select Whether there is proposed to be a clear space " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="332px">Whether the temporary structure is intended to be constructed near an electric Substation, railway line, chimney or furnace and if so the distance from the same<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtTemporaryStructure" class="form-control txtbox" OnSelectedIndexChanged="rbtTemporaryStructure_SelectedIndexChanged"
                                                    Height="28px" Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtTemporaryStructure" runat="server" ControlToValidate="rbtTemporaryStructure"
                                                    ErrorMessage="Please Select Whether the temporary structure is intended" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="divTemporarySturucture" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label71" runat="server" CssClass="LBLBLACK" Width="165px"><font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtTemporarySturucture" TabIndex="1" runat="server" class="form-control txtbox"
                                                    Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <%-- <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="rfvtxtTemporarySturucture" runat="server" ControlToValidate="txtStartDate"
                                                                ErrorMessage="Please Stating Date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>--%>
                                        </tr>
                                        <%--  <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label68" runat="server" CssClass="LBLBLACK" Width="165px"><font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                      <asp:TextBox ID="txtTemporaryStrucutres" runat="server" TabIndex="1" class="form-control txtbox"
                                                                    Height="33px" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="rfvtxtTemporaryStrucutres" runat="server" ControlToValidate="txtEndDate"
                                                                ErrorMessage="Please enterb " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>

                                                    </tr>--%>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>9.</b>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="340px"><b style="text-size-adjust:50%;">Duration of the event (Event Timings & Dates)</b><font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="165px">Stating Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtStartDate" TabIndex="1" runat="server" class="form-control txtbox"
                                                    Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtStartDate" runat="server" ControlToValidate="txtStartDate"
                                                    ErrorMessage="Please Stating Date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="165px">Ending Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtEndDate" runat="server" TabIndex="1" class="form-control txtbox"
                                                    Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtEndDate" runat="server" ControlToValidate="txtEndDate"
                                                    ErrorMessage="Please End Date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="165px">Working timings :<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlworktimingsfrom" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label58" runat="server" CssClass="LBLBLACK" Width="165px">To :<font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlworktimingsto" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="320px">Public performance timings<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlperformancetimingsfrom" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label57" runat="server" CssClass="LBLBLACK" Width="165px">To<font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlperformancetimingsto" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                e.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="307px">Expected strength of audience<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlExpectedstrength" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="100"><=100/</asp:ListItem>
                                                    <asp:ListItem Value="200">>101 to 200/</asp:ListItem>
                                                    <asp:ListItem Value="500">>201 to 500/</asp:ListItem>
                                                    <asp:ListItem Value="1000">>501 to 1000/</asp:ListItem>
                                                    <asp:ListItem Value="A">>1001 and above</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvddlExpectedstrength" runat="server" ControlToValidate="ddlExpectedstrength"
                                                    ErrorMessage="Please Expected strength" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>10.</b>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="337px"><b>Total No. of Stalls that have been planned</b><font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="165px">Product Related<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtProductRelated" TabIndex="1" runat="server" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtProductRelated" runat="server" ControlToValidate="txtProductRelated"
                                                    ErrorMessage="Please Product Related" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="165px">Food & Beverages<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtFoodBeverages" runat="server" TabIndex="1" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="28px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtFoodBeverages" runat="server" ControlToValidate="txtFoodBeverages"
                                                    ErrorMessage="Please Food & Beverages" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="165px">Games, Entertainment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtGamesEntertainment" TabIndex="1" runat="server" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtGamesEntertainment" runat="server" ControlToValidate="txtGamesEntertainment"
                                                    ErrorMessage="Please Games, Entertainment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="165px">Others (specify)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtOthers" runat="server" TabIndex="1" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <%--  <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="rfvtxtOthers" runat="server" ControlToValidate="txtOthers"
                                                                ErrorMessage="Please enter Others (specify)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>--%>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>11.</b>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="165px"><b>Visitor Entry Details</b><font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="245px">Free entry for all based on invitations <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtFreeEntryInvitation" class="form-control txtbox" Height="28px"
                                                    Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtFreeEntryInvitation" runat="server" ControlToValidate="rbtFreeEntryInvitation"
                                                    ErrorMessage="Please enter Free entry for all based on invitations" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="290px">Free entry without invitations<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtFreeEntryWithoutInvitation" class="form-control txtbox"
                                                    Height="33px" Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtFreeEntryWithoutInvitation" runat="server"
                                                    ControlToValidate="rbtFreeEntryWithoutInvitation" ErrorMessage="Please enter Free entry without invitations"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="165px">Ticketed show<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtTicketShow" AutoPostBack="true" class="form-control txtbox"
                                                    OnSelectedIndexChanged="rbtTicketShow_SelectedIndexChanged" Height="33px" Width="180px"
                                                    RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtTicketShow" runat="server" ControlToValidate="rbtTicketShow"
                                                    ErrorMessage="Please enter Ticketed show" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="165px">If yes, give details<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtTicketShowDetails" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtTicketShowDetails" runat="server" ControlToValidate="txtTicketShowDetails"
                                                    ErrorMessage="Please enter If yes, give details" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="divTicketEach" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c (i).
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="165px">Adult Ticket each(In Rs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtAdultTicket" TabIndex="1" runat="server" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtAdultTicket" runat="server" ControlToValidate="txtAdultTicket"
                                                    ErrorMessage="Please enter Adult Ticket each" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="divChildrenTicketEach" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c (ii).
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="205px">Children Ticket each (More than 5years below 12 years)(In Rs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtChildrensTicket" runat="server" TabIndex="1" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <%--  <asp:RequiredFieldValidator ID="rfvtxtChildrensTicket" runat="server" ControlToValidate="txtChildrensTicket"
                                                    ErrorMessage="Please enter Children Ticket each" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="296px">Total No. of Ticket Counters<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNoOfTicketCounters" TabIndex="1" runat="server" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNoOfTicketCounters" runat="server" ControlToValidate="txtNoOfTicketCounters"
                                                    ErrorMessage="Please enter Total No. of Ticket Counters" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                e.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label68" runat="server" CssClass="LBLBLACK" Width="165px">Any VIP Expected<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtAnyVIP" AutoPostBack="true" class="form-control txtbox"
                                                    OnSelectedIndexChanged="rbtAnyVIP_SelectedIndexChanged" Height="33px" Width="180px"
                                                    RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtAnyVIP" runat="server" ControlToValidate="rbtAnyVIP"
                                                    ErrorMessage="Please Select Any VIP Expected" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="divAnyVIP">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label72" runat="server" CssClass="LBLBLACK" Width="165px"><font 
                                                            color="black">Remarks</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtAnyVIP" runat="server" TabIndex="1" class="form-control txtbox"
                                                    onkeypress="Names()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <%-- <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rbtAnyVIP"
                                                                ErrorMessage="Please Select Any VIP Expected" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>--%>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                f.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label73" runat="server" CssClass="LBLBLACK" Width="165px">Any Foreigner Expected<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtAnyForeigner" AutoPostBack="true" class="form-control txtbox"
                                                    OnSelectedIndexChanged="rbtAnyForeigner_SelectedIndexChanged" Height="33px" Width="180px"
                                                    RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtAnyForeigner" runat="server" ControlToValidate="rbtAnyForeigner"
                                                    ErrorMessage="Please Select Any Foreigner Expected" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="divAnyForeigner">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label74" runat="server" CssClass="LBLBLACK" Width="165px"><font 
                                                            color="black">Remarks</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtAnyForeigner" runat="server" TabIndex="1" class="form-control txtbox"
                                                    onkeypress="Names()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <%-- <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rbtAnyVIP"
                                                                ErrorMessage="Please Select Any VIP Expected" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>--%>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                12.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="165px"><b>Traffic Management </b><font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="228px">Space in Sq. Meters made available for parking at the venue.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtParkingSpace" TabIndex="1" runat="server" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtParkingSpace" runat="server" ControlToValidate="txtParkingSpace"
                                                    ErrorMessage="Please enter Space in Sq. Meters made available for parking" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label38" runat="server" CssClass="LBLBLACK" Width="232px">No. of volunteers /security guards proposed to be deployed for vehicle checking along with equipments<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNoOfSecurityVehicleChecking" runat="server" TabIndex="1" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNoOfSecurityVehicleChecking" runat="server"
                                                    ControlToValidate="txtNoOfSecurityVehicleChecking" ErrorMessage="Please enter No. of volunteers"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>13.</b>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="165px"><b>Security Arrangements</b><font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtSecurityArrangements" TabIndex="1" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtSecurityArrangements" runat="server" ControlToValidate="txtSecurityArrangements"
                                                    ErrorMessage="Please enter Security Arrangements" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label69" runat="server" CssClass="LBLBLACK" Width="252px">Police approval/permission is mandatory for major & minor events<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtPoliceNOC" class="form-control txtbox" Height="33px"
                                                    Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtPoliceNOC" runat="server" ControlToValidate="rbtPoliceNOC"
                                                    ErrorMessage="Please Select Whether required Police NOC" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="165px">Proposed No. of CCTV’s<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtProposedNoOfCCTV" onkeypress="NumberOnly()" runat="server" TabIndex="1"
                                                    class="form-control txtbox" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtProposedNoOfCCTV" runat="server" ControlToValidate="txtProposedNoOfCCTV"
                                                    ErrorMessage="Please enter Proposed No. of CCTV’s" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label41" runat="server" CssClass="LBLBLACK" Width="224px">Proposed No. of DFMD’s and their location<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtProposedNoOfDFMD" onkeypress="NumberOnly()" TabIndex="1" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtProposedNoOfDFMD" runat="server" ControlToValidate="txtProposedNoOfDFMD"
                                                    ErrorMessage="Please enter Proposed No. of DFMD’s and their location" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="222px">Proposed No. of security guards and volunteers<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNoOfSecurityAndVolunteers" onkeypress="NumberOnly()" runat="server"
                                                    TabIndex="1" class="form-control txtbox" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNoOfSecurityAndVolunteers" runat="server" ControlToValidate="txtNoOfSecurityAndVolunteers"
                                                    ErrorMessage="Please enter Proposed No. of security guards and volunteers" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>14.</b>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="200px"><b>Fire Safety Arrangements</b><font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label44" runat="server" CssClass="LBLBLACK" Width="165px">No. of exits planned<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNoOfExitsWithWidth" onkeypress="NumberOnly()" TabIndex="1" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNoOfExitsWithWidth" runat="server" ControlToValidate="txtNoOfExitsWithWidth"
                                                    ErrorMessage="Please enter No. of exits planned along with width" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label75" runat="server" CssClass="LBLBLACK" Width="165px">width (in feet)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtExitsWidth" TabIndex="1" runat="server" class="form-control txtbox"
                                                    onkeypress="DecimalOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtExitsWidth" runat="server" ControlToValidate="txtExitsWidth"
                                                    ErrorMessage="Please enter No. of exits width" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="165px">No of gangways planned<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtWidthOfGangways" runat="server" TabIndex="1" class="form-control txtbox"
                                                    onkeypress="NumberOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtWidthOfGangways" runat="server" ControlToValidate="txtWidthOfGangways"
                                                    ErrorMessage="Please enter No. and width of the gangways planned" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label76" runat="server" CssClass="LBLBLACK" Width="165px">width (in feet)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtGangWaysWidth" TabIndex="1" runat="server" class="form-control txtbox"
                                                    onkeypress="DecimalOnly()" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtGangWaysWidth" runat="server" ControlToValidate="txtGangWaysWidth"
                                                    ErrorMessage="Please enter No. of Gangways width" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="265px">No. of Co2 type Cylinders<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtCO2Cylinders" onkeypress="NumberOnly()" TabIndex="1" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtCO2Cylinders" runat="server" ControlToValidate="txtCO2Cylinders"
                                                    ErrorMessage="Please enter No. of Co2 type Cylinders" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label47" runat="server" CssClass="LBLBLACK" Width="165px">No. of Foam Cylinders<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtFoamCylinders" onkeypress="NumberOnly()" runat="server" TabIndex="1"
                                                    class="form-control txtbox" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtFoamCylinders" runat="server" ControlToValidate="txtFoamCylinders"
                                                    ErrorMessage="Please enter No. of Foam Cylinders" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                e.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="165px">No. of Buckets<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNoOfBuckets" onkeypress="NumberOnly()" TabIndex="1" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNoOfBuckets" runat="server" ControlToValidate="txtNoOfBuckets"
                                                    ErrorMessage="Please enter No. of Buckets" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                f.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label49" runat="server" CssClass="LBLBLACK" Width="263px">No. of Water Storage Tanks<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNoOfWaterStorageTanks" onkeypress="NumberOnly()" runat="server"
                                                    TabIndex="1" class="form-control txtbox" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNoOfWaterStorageTanks" runat="server" ControlToValidate="txtNoOfWaterStorageTanks"
                                                    ErrorMessage="Please enter No. of Water Storage Tanks" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                g.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label50" runat="server" CssClass="LBLBLACK" Width="165px">No. of Sand Bags<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNoOfSandBags" TabIndex="1" onkeypress="NumberOnly()" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNoOfSandBags" runat="server" ControlToValidate="txtNoOfSandBags"
                                                    ErrorMessage="Please enter No. of Sand Bags" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                h.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label51" runat="server" CssClass="LBLBLACK" Width="200px">Whether standby fire service is required<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtStandbyFireService" class="form-control txtbox" OnSelectedIndexChanged="rbtStandbyFireService_SelectedIndexChanged"
                                                    AutoPostBack="true" Height="33px" Width="180px" RepeatDirection="Horizontal"
                                                    runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtStandbyFireService" runat="server" ControlToValidate="rbtStandbyFireService"
                                                    ErrorMessage="Please select  Whether standby fire service is required" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trCategoryForVehicleStandBy" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                i.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label89" runat="server" CssClass="LBLBLACK" Width="165px">Category For Vehicle Stand By<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:DropDownList ID="ddlcategoryvehiclestandby" runat="server" class="form-control txtbox"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlcategoryvehiclestandby_SelectedIndexChanged"
                                                    Height="28px" Width="180px">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>15.</b>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label52" runat="server" CssClass="LBLBLACK" Width="300px"><b>Medical Arrangements proposed at Venue</b><font 
                                                            color="red"></font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label53" runat="server" CssClass="LBLBLACK" Width="165px">First Aid facility<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtFirstAidFacility" class="form-control txtbox" Height="33px"
                                                    Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtFirstAidFacility" runat="server" ControlToValidate="rbtFirstAidFacility"
                                                    ErrorMessage="Please select First Aid facility" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label54" runat="server" CssClass="LBLBLACK" Width="165px">Medical Attender/Doctor<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtMedicalAttender" class="form-control txtbox" Height="33px"
                                                    Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtMedicalAttender" runat="server" ControlToValidate="rbtMedicalAttender"
                                                    ErrorMessage="Please select Medical Attender/Doctor" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label55" runat="server" CssClass="LBLBLACK" Width="267px">Standby ambulance facility<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtSatndbyAmbulanceFacility" class="form-control txtbox"
                                                    Height="33px" Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrbtSatndbyAmbulanceFacility" runat="server" ControlToValidate="rbtSatndbyAmbulanceFacility"
                                                    ErrorMessage="Please select Standby ambulance facility" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="trUploads">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 70%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label56" runat="server" CssClass="LBLBLACK" Width="300px"><b>Documents Required to Upload</b><font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trfabrication" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label80" runat="server" CssClass="LBLBLACK" Width="200px">Fabrication Material Plan</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupFabricationMaterialDoc" runat="server" />
                                                <asp:HyperLink ID="HyperLinkfupFabricationMaterialDoc" Visible="true" runat="server"
                                                    CssClass="LBLBLACK" Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblfupFabricationMaterialDoc" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                <asp:Button ID="btnfupFabricationMaterialDoc" CssClass="btn btn-success" runat="server"
                                                    Text="Upload" OnClick="btnfupFabricationMaterialDoc_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label59" runat="server" CssClass="LBLBLACK" Width="200px">Proof of address</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupProofofAddress" runat="server" />
                                                <asp:HyperLink ID="HyperLinkProofofAddress" Visible="true" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblProofofAddress" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                <asp:Button ID="btnProofofAddress" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnProofofAddress_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label60" runat="server" CssClass="LBLBLACK" Width="200px">PAN card of applicant</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload runat="server" ID="fupPanCard" />
                                                <asp:Button ID="btnPancard" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnPancard_Click" />
                                                <asp:Label ID="lblPandCard" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                <asp:HyperLink ID="HyperLinkPanCard" Visible="true" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr id="trrelevant" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label61" runat="server" CssClass="LBLBLACK" Width="200px">Relevant copy of plans</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload runat="server" ID="fupRelevantCopy" />
                                                <asp:Button ID="btnRelevantCopy" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnRelevantCopy_Click" />
                                                <asp:Label ID="lblRelevantCopy" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                <asp:HyperLink ID="HyperLinkRelevantcopy" Visible="true" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <br />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label62" runat="server" CssClass="LBLBLACK" Width="281px">Partnership deed/ Articles and Memorandum of Association of Company</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;">
                                                <asp:FileUpload runat="server" ID="fupPartnershipDeed" />
                                                <asp:Button ID="btnPartnershipDeed" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnPartnershipDeed_Click" />
                                                <asp:Label ID="lblPartnershipDeed" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                <asp:HyperLink ID="HyperLinkPartnershipDeed" Visible="true" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top;">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label63" runat="server" CssClass="LBLBLACK" Width="275px">Enclose traffic / security/ fire safety plan/ location plan/ approach plan</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload runat="server" ID="fupEnclosetraffic" />
                                                <asp:Button ID="btnEnclosetraffic" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnEnclosetraffic_Click" />
                                                <asp:Label ID="lblEnclosetraffic" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                <asp:HyperLink ID="HyperLinkEnclosetraffic" Visible="false" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label64" runat="server" CssClass="LBLBLACK" Width="200px">Self Certification</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload runat="server" ID="fupSelfCertification" />
                                                <asp:Button ID="btnSelfCertification" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnSelfCertification_Click" />
                                                <asp:Label ID="lblSelfCertification" runat="server" CssClass="LBLBLACK" Visible="false"></asp:Label>
                                                <asp:HyperLink ID="HyperLinkSelfCertification" Visible="true" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#" Text=""></asp:HyperLink>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                6
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label67" runat="server" CssClass="LBLBLACK" Width="200px">Upload Layout of the event</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload runat="server" ID="fupLayoutoftheevent" />
                                                <asp:Button ID="btnfupLayoutoftheevent" CssClass="btn btn-success" runat="server"
                                                    Text="Upload" OnClick="btnfupLayoutoftheevent_Click" />
                                                <asp:Label ID="lblfupLayoutoftheevent" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                <asp:HyperLink ID="HyperLinkfupLayoutoftheevent" Visible="true" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trloandocuuments" runat="server" visible="false">
                                <td>
                                    <table cellpadding="4" cellspacing="5" class="auto-style2">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                7
                                            </td>
                                            <td class="auto-style1" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label88" runat="server" CssClass="LBLBLACK" Width="200px">Loan Docments(Department Related)</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fuploandocuments" runat="server" />
                                                <asp:HyperLink ID="Hyperloandocuments" Visible="true" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblloandocuments" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                <asp:Button ID="btnloandocuments" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnloandocuments_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" OnClick="BtnClear_Click"
                                        Width="90px" />&nbsp;
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                        Text="Save" Width="90px" OnClick="BtnSave_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnPayment" runat="server" CssClass="btn btn-danger" Height="32px"
                                        TabIndex="10" Text="PAYMENT" Width="90px" ValidationGroup="group" OnClick="BtnDelete_Click"
                                        Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
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
                            <tr>
                                <td colspan="10">
                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="child" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                    <asp:HiddenField ID="hdfFlagID1" runat="server" />
                                    <asp:HiddenField ID="hdfpencode" runat="server" />
                                    <asp:HiddenField ID="hdnOwnedDoc" runat="server" />
                                    <asp:HiddenField ID="hdnOwnedDocFileName" runat="server" />
                                    <asp:HiddenField ID="hdnPhotoDoc" runat="server" />
                                    <asp:HiddenField ID="hdnPhotoDocFilename" runat="server" />
                                    <asp:HiddenField ID="hdnLeasedDoc" runat="server" />
                                    <asp:HiddenField ID="hdnLeasedDocFileName" runat="server" />
                                    <asp:HiddenField ID="hdnPreviousYearITReturns" runat="server" />
                                    <asp:HiddenField ID="hdnPreviousYearITReturnsFileName" runat="server" />
                                    <asp:HiddenField ID="hdnEnclosedDoc" runat="server" />
                                    <asp:HiddenField ID="hdnEnclosedDocFileName" runat="server" />
                                    <asp:HiddenField ID="hdnSelfDeclaration" runat="server" />
                                    <asp:HiddenField ID="hdnSelfDeclarationFileName" runat="server" />
                                    <asp:HiddenField ID="hdnTransactionNumber" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--   </ContentTemplate>
                        </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hdnProofofAddressType" />
        <asp:HiddenField runat="server" ID="hdnFileNameProofofAddress" />
        <asp:HiddenField runat="server" ID="hdnPanCard" />
        <asp:HiddenField runat="server" ID="hdnPanCardFilename" />
        <asp:HiddenField runat="server" ID="hdnRelevantCopy" />
        <asp:HiddenField runat="server" ID="hdnRelevantCopyFileName" />
        <asp:HiddenField runat="server" ID="hdnPartnershipDeed" />
        <asp:HiddenField runat="server" ID="hdnPartnershipDeedFileName" />
        <asp:HiddenField runat="server" ID="hdnEnclosetraffic" />
        <asp:HiddenField runat="server" ID="hdnEnclosetrafficFileName" />
        <asp:HiddenField runat="server" ID="hdnSelfCertification" />
        <asp:HiddenField runat="server" ID="hdnSelfCertificationFilename" />
        <asp:HiddenField runat="server" ID="hdnfabricationmaterialdoc" />
        <asp:HiddenField runat="server" ID="hdnfabricationmaterialdocfilename" />
        <asp:HiddenField runat="server" ID="hdnlayoutevent" />
        <asp:HiddenField runat="server" ID="hdnlayouteventfilename" />
        <asp:HiddenField runat="server" ID="hdnloandocument" />
        <asp:HiddenField runat="server" ID="hdnloandocumentfilename" />
    </div>
    <%--      <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
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
    <%--  </ContentTemplate>
     <Triggers>

            <asp:PostBackTrigger ControlID="btnProofofAddress" />
               <asp:PostBackTrigger ControlID="btnPancard" />
               <asp:PostBackTrigger ControlID="btnRelevantCopy" />
               <asp:PostBackTrigger ControlID="btnPartnershipDeed" />
               <asp:PostBackTrigger ControlID="btnEnclosetraffic" />
             <asp:PostBackTrigger ControlID="btnSelfCertification" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <%-- <form id="form1" runat="server">
         <asp:GridView ID="gvitems" runat="server" AutoGenerateColumns="false">    
             <Columns>    
                 <asp:BoundField DataField="ApprovalName" HeaderText="Approval Name" ItemStyle-Width="30" />    
                 <asp:BoundField DataField="Dept_Full_name" HeaderText="Department Name" ItemStyle-Width="150" />    
                 <asp:BoundField DataField="Fees" HeaderText="Fee" ItemStyle-Width="150" />    
             </Columns>    
         </asp:GridView>    
      </form> --%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript" src="datepair.js"></script>
    <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
    <script type="text/javascript">
        $('.timepicker').timepicker({
            timeFormat: 'h:mm p',
            interval: 30,
            minTime: '12:00AM',
            maxTime: '11:30pm',
            startTime: '12:00 AM',
            defaultTime: '12:00 AM',
            dynamic: false,
            dropdown: true,
            scrollbar: true
        });
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            //   $('txtPerformancetimingsfrm.timepicker').timepicker({});

            //            $(".rbtTicketShow").click(function () {
            //if($(this).val() == "0"){
            //    $('#divTicketEach .form-control').prop("disabled", false);

            //}else{
            //  $('#form_kps .form-control').prop("disabled", true);

            //}


            $("input[id$='txtStartDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtEndDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtEndDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
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
