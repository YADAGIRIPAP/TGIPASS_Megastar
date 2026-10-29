<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmDraftQuestionnaireRegistrationOfTravelAgent.aspx.cs"
    Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
    <script type="text/javascript">
      <%--  function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }--%>
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

        <%--function validateVerhoeff() {
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
        }--%>



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
    <%--<asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
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
                            &nbsp;APPLICATION FOR REGISTRATION OF TRAVEL AGENCY</h3>
                    </div>
                    <div class="col-md-12">
                        <h1 class="page-head-line" align="left" style="font-size: x-large">
                            APPLICATION FOR REGISTRATION OF TRAVEL AGENCY</h1>
                    </div>
                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                    <div class="panel-body" align="left">
                        <table align="left" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 70%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name of the Agency<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtNameoftheAgency" onkeypress="Names()" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvNameoftheAgency" runat="server" ControlToValidate="txtNameoftheAgency"
                                                    ErrorMessage="Please enter Name of the Agency" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="239px">Name of the Owner/Director/Partner <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNameoftheOwner" runat="server" class="form-control txtbox" onkeypress="Names()" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvNameOFtheOwner" runat="server" ControlToValidate="txtNameoftheOwner"
                                                    ErrorMessage="Please enter Name of the Owner/Director/Partner" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <%--   <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:FileUpload ID="fupPhoto" runat="server" class="form-control txtbox"
                                                                    Height="28px" />
                                                               
                                                                   <asp:HyperLink ID="HyperLinkPhoto" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                    Target="_blank" NavigateUrl="#">Click here to download</asp:HyperLink>
                                                                <br />
                                                               
                                                               
                                                                <asp:Label ID="lblPhoto" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:Button ID="btnPhoto" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" TabIndex="10" Text="Upload"
                                                                    Width="72px"/>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:RequiredFieldValidator ID="rfvphoto" Display="Dynamic" ControlToValidate="fupPhoto" SetFocusOnError="true"
                                                                    ForeColor="#ff0000" Font-Bold="true" runat="server" ErrorMessage="Please select file upload" ValidationGroup="Submit"></asp:RequiredFieldValidator>

                                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px">Mobile No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtMobileNumber" onkeypress="NumberOnly()" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ControlToValidate="txtMobileNumber"
                                                    ErrorMessage="Please enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="165px">Email ID.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtEmailID" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvEmailID" runat="server" ControlToValidate="txtEmailID"
                                                    ErrorMessage="Please enter Email ID" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmailID"
                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="traadhar" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="165px">Aadhaar No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
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
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="165px">Applied for.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlAppliedFor" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Travel Agency</asp:ListItem>
                                                    <asp:ListItem Value="2">Tour Operator</asp:ListItem>
                                                    <%--   <asp:ListItem Value="3">Adventure Tour Operator</asp:ListItem>
                                                                    <asp:ListItem Value="4">Tourist Transport Operator</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvAppliedFor" runat="server" ControlToValidate="ddlAppliedFor"
                                                    ErrorMessage="Please select type of agency" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">4.Nature of Operations </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: left;" class="auto-style1">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="321px">Agency engaged in arrangements of tickets for travel by air, rail, ship, passport, visa, etc. It may also arrange accommodation, tours, entertainment and other tourism related services.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtAgencyArrangementsTravel" class="form-control txtbox"
                                                    Height="33px" Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvAgencyArrangementsTravel" runat="server" ControlToValidate="rbtAgencyArrangementsTravel"
                                                    ErrorMessage="Please select Agency engaged in arrangements of tickets for travel"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: left;" class="auto-style1">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify; text-align: left;">
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="315px">Agency engaged in arrangements for transport, accommodation, sightseeing, entertainment and other tourism related services for tourists.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtAgencyArrangementsTransport" class="form-control txtbox"
                                                    Height="33px" Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvAgencyArrangementsTransport" runat="server" ControlToValidate="rbtAgencyArrangementsTransport"
                                                    ErrorMessage="Please select Agency engaged in arrangements for transport" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: left;" class="auto-style1">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="313px">Agency engaged in providing  tourist transport like cars, coaches   etc. to tourists for transfers, sightseeing and journeys to tourist places etc<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtAgencyProvidingTouristTransport" class="form-control txtbox"
                                                    Height="33px" Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvAgencyAdventureTourism" runat="server" ControlToValidate="rbtAgencyProvidingTouristTransport"
                                                    ErrorMessage="Agency engaged in providing tourist transport like cars, coaches etc. to tourists for transfers, sightseeing and journeys"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="165px">Applying for.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtApplyingFor" class="form-control txtbox" Height="60px"
                                                    Width="235px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Head Office" Value="HO"></asp:ListItem>
                                                    <asp:ListItem Text="Branch Office" Value="BO"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvApplyingFor" runat="server" ControlToValidate="rbtApplyingFor"
                                                    ErrorMessage="Please select type of office" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="267px">Date of Commencement of the Business(If applicable enclose relevant Documents)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtDateCommencementBusiness" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvDateCommencementBusiness" runat="server" ControlToValidate="txtDateCommencementBusiness"
                                                    ErrorMessage="Please Select Date of Commencement of Business" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="256px">Constitution of the Agency.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlConstitutionodAgency" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvconstagency" runat="server" ControlToValidate="ddlConstitutionodAgency"
                                                    ErrorMessage="Please select Constitution of the Agency." InitialValue="Select"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                8.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="273px">Whether the premises is .<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtPremises" class="form-control txtbox" OnSelectedIndexChanged="rbtPremises_SelectedIndexChanged"
                                                    Height="60px" Width="180px" RepeatDirection="Horizontal" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Text="Owned" Value="O"></asp:ListItem>
                                                    <asp:ListItem Text="Leased" Value="L"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvrPremises" runat="server" ControlToValidate="rbtPremises"
                                                    ErrorMessage="Please select Whether the premises is" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">9.Office Space Details </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="210px">Office Space <b>(Min 150 Sft.)</b><font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtOfficeSpace" runat="server" onkeypress="NumberOnly()" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvOfficeSpace" runat="server" ControlToValidate="txtOfficeSpace"
                                                    ErrorMessage="Please enter Office Space (Min 150 Sft.)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="210px">Reception Area (in Sft).<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtReceptionArea" onkeypress="NumberOnly()" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvReceptionArea" runat="server" ControlToValidate="txtReceptionArea"
                                                    ErrorMessage="Please enter Reception Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="210px">Location Area.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtLOcationArea" class="form-control txtbox" Height="60px"
                                                    Width="230px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Commercial " Value="C"></asp:ListItem>
                                                    <asp:ListItem Text="Residential" Value="R"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvLocationArea" runat="server" ControlToValidate="rbtLOcationArea"
                                                    ErrorMessage="Please Select Location Area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                d.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="210px">Address.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="100px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                                    ErrorMessage="Please enter Address" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                e.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="210px">District.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlDistrictOffice" runat="server" class="form-control txtbox"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlDistrictOffice_SelectedIndexChanged"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvtxtDistrictOffice" runat="server" ControlToValidate="ddlDistrictOffice"
                                                    ErrorMessage="Please enter District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                f.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="210px">Mandal.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlProp_intMandalid" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intMandalid_SelectedIndexChanged"
                                                    TabIndex="1">
                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDistrictOffice"
                                                    ErrorMessage="Please enter District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                g.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label44" runat="server" CssClass="LBLBLACK" Width="210px">village.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlProp_intVillageid" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Village--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDistrictOffice"
                                                    ErrorMessage="Please enter District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                h.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="210px">PIN Code.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtPinCode" MaxLength="6" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvPincode" runat="server" ControlToValidate="txtPinCode"
                                                    ErrorMessage="Please enter Pincode" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                i.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="210px">Phone No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtPhoneNumber" MaxLength="10" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhoneNumber"
                                                    ErrorMessage="Please enter Phone number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                j.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="210px">FAX No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtFAXNo" MaxLength="10" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvtxtFAXNo" runat="server" ControlToValidate="txtFAXNo"
                                                    ErrorMessage="Please enter FAX Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                k.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="210px">Mobile No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtMobileNumberOffice" MaxLength="10" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvMobileNumberOffice" runat="server" ControlToValidate="txtMobileNumberOffice"
                                                    ErrorMessage="Please enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                l.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="210px">Email ID.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtEmailIDOffice" MaxLength="100" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvEmailIDOffice" runat="server" ControlToValidate="txtEmailIDOffice"
                                                    ErrorMessage="Please enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailIDOffice"
                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: left;" class="auto-style1">
                                                m.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; vertical-align: top; text-align: left;">
                                                <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="208px">Website.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; vertical-align: top; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" class="auto-style2">
                                                <asp:TextBox ID="txtWebSite" MaxLength="100" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="rfvWebSite" runat="server" ControlToValidate="txtWebSite"
                                                    ErrorMessage="Please enter WebSite" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:Label ID="Label38" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">10.Staff Details </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style4">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="210px">No. of qualified Staff<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtqualifiedStaff" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtqualifiedStaff" runat="server" ControlToValidate="txtqualifiedStaff"
                                                    ErrorMessage="Please enter No. of qualified Staff" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style4">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">No. of experienced Staff<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtExperiencedStaff" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtExperiencedStaff" runat="server" ControlToValidate="txtExperiencedStaff"
                                                    ErrorMessage="Please enter No. of experienced Staff" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                c.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style4">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="210px">Total No. of Staff Employed<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStaffEmployed" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtStaffEmployed" runat="server" ControlToValidate="txtStaffEmployed"
                                                    ErrorMessage="Please enter Total No. of Staff Employed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">11.Financial Details </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style4">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="241px">Paid up capital(Rs. in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtPaidUpCapital" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtPaidUpCapital" runat="server" ControlToValidate="txtPaidUpCapital"
                                                    ErrorMessage="Please enter Paid up capital Rs. in Lakhs" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                b.
                                            </td>
                                            <td class="auto-style4">
                                                Previous Turnover if any Rs. in Lakhs<span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtPreviousTurnover" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtPreviousTurnover" runat="server" ControlToValidate="txtPreviousTurnover"
                                                    ErrorMessage="Please enter Previous Turnover if any Rs. in Lakhs" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server">
                                            <td style="padding: 5px; margin: 5px">
                                                c.
                                            </td>
                                            <td class="auto-style4">
                                                PAN No.<span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtPanFinacial" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    onblur="fnValidatePAN(this);" MaxLength="10" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtPanFinacial" runat="server" ControlToValidate="txtPanFinacial"
                                                    ErrorMessage="Please enter Pan Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                d.
                                            </td>
                                            <td class="auto-style4">
                                                Previous Year IT Returns (If applicable)
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rbtPreviousYearITReturns" class="form-control txtbox" OnSelectedIndexChanged="rbtPreviousYearITReturns_SelectedIndexChanged"
                                                    Height="33px" Width="180px" RepeatDirection="Horizontal" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                 <asp:RequiredFieldValidator ID="rfvpreviousyearitreturns" runat="server" ControlToValidate="rbtPreviousYearITReturns"
                                                                ErrorMessage="Please select previous year IT returns" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                e.
                                            </td>
                                            <td class="auto-style4">
                                                GST No.<span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtGSTNumber" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    onkeypress="CharnumOnly()" MaxLength="15" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvGSTNumber" runat="server" ControlToValidate="txtGSTNumber"
                                                    ErrorMessage="Please enter GST Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; vertical-align: top; margin: 5px">
                                                f.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;" class="auto-style4">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="282px"> Enclose reference letter from Bank on its original letterhead regarding firm’s bank account and address with telephone numbers<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rbtEncloseReferenceLetter" class="form-control txtbox" Height="33px"
                                                    Width="180px" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                  <asp:RequiredFieldValidator ID="rfvEncloseReferenceLetter" runat="server" ControlToValidate="rbtEncloseReferenceLetter"
                                                    ErrorMessage="Please select require Trade License" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana">12.Bank Account Details (Current Account) </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                a.
                                            </td>
                                            <td class="auto-style4">
                                                Bank Name <span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtBankAccountDtls" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtBankAccountDtls" runat="server" ControlToValidate="txtBankAccountDtls"
                                                    ErrorMessage="Please enter Bank Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                b.
                                            </td>
                                            <td class="auto-style4">
                                                Branch Name <span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtBranchName" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtBranchName" runat="server" ControlToValidate="txtBranchName"
                                                    ErrorMessage="Please enter Branch Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                c.
                                            </td>
                                            <td class="auto-style4">
                                                Account Number <span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtBankAccountNumber" onkeypress="NumberOnly()" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtBankAccountNumber" runat="server" ControlToValidate="txtBankAccountNumber"
                                                    ErrorMessage="Please enter Account Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                d.
                                            </td>
                                            <td class="auto-style4">
                                                IFSC <span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtIFSC" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    onkeypress="CharnumOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtIFSC" runat="server" ControlToValidate="txtIFSC"
                                                    ErrorMessage="Please enter IFSC Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                e.
                                            </td>
                                            <td class="auto-style4">
                                                MICR <span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMICR" runat="server" class="form-control txtbox" Height="28px" oncopy="return false" onpaste="return false" oncut="return false"
                                                    onkeypress="CharnumOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtMICR" runat="server" ControlToValidate="txtMICR"
                                                    ErrorMessage="Please enter MICR Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                13.
                                            </td>
                                            <td class="auto-style4">
                                                Do you require Trade License? <span class="style5">*</span>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rbtRequiredTradeLicense" class="form-control txtbox" Height="33px"
                                                    Width="180px" RepeatDirection="Horizontal" runat="server" OnSelectedIndexChanged="rbtRequiredTradeLicense_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvRequiredTradeLicense" runat="server" ControlToValidate="rbtRequiredTradeLicense"
                                                    ErrorMessage="Please select require Trade License" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                14.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="277px">Do you require Shops & Establishment License?<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rbtRequireShopsEstablishment" class="form-control txtbox"
                                                    Height="33px" Width="180px" RepeatDirection="Horizontal" runat="server" OnSelectedIndexChanged="rbtRequireShopsEstablishment_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvRequireShopsEstablishment" runat="server" ControlToValidate="rbtRequireShopsEstablishment"
                                                    ErrorMessage="Please select require Shops & Establishment License" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; vertical-align: top; margin: 5px">
                                                15.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="280px"> Whether registered with any Tourism Department/ Indian Association of Tour Operators (IATO) /Travel Agents Association of India (TAAI).<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rbtregisteredwithanyTourismDepartment" class="form-control txtbox"
                                                    OnSelectedIndexChanged="rbtregisteredwithanyTourismDepartment_SelectedIndexChanged"
                                                    Height="33px" Width="180px" RepeatDirection="Horizontal" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvregisteredwithanyTourismDepartment" runat="server"
                                                    ControlToValidate="rbtregisteredwithanyTourismDepartment" ErrorMessage="Please select registered with any Tourism Department"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; vertical-align: top; margin: 5px">
                                                16.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="279px">No. of Tourist Vehicles (Buses/Taxes/Cabs etc.) owned by the Agency/Firm .<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNoofTouristVehicles" runat="server" class="form-control txtbox" oncopy="return false" onpaste="return false" oncut="return false"
                                                    Height="28px" MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="rfvtxtNoofTouristVehicles" runat="server" ControlToValidate="txtNoofTouristVehicles"
                                                    ErrorMessage="Please enter No. of Tourist Vehicles" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label80" runat="server" CssClass="LBLBLACK" Width="200px">Passport Size Photo</asp:Label>
                                            </td>
                                            <td class="auto-style5" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupPhoto" runat="server" />
                                                <asp:HyperLink ID="HyperLinkfupPhoto" Visible="false" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblfupPhoto" runat="server" ForeColor="Red" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnfupPhoto" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnfupPhoto_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trowneddoc" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="312px">If Owned (upload the relevant Documents with self declaration stating that the premises being used for Agency purpose only)</asp:Label>
                                            </td>
                                            <td class="auto-style5" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupOwnedDoc" runat="server" />
                                                <asp:HyperLink ID="HyperLinkOwnedDoc" Visible="False" runat="server" CssClass="LBLBLACK"
                                                    Width="149px" Target="_blank" NavigateUrl="#">[HyperLinkOwnedDoc]</asp:HyperLink>
                                                <asp:Label ID="lblOwnedDoc" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnOwnedDoc" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnOwnedDoc_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trleaseddoc" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="200px">If leased upload the lease agreement.</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupLeasedDoc" runat="server" />
                                                <asp:HyperLink ID="HyperLinkLeasedDoc" Visible="False" runat="server" CssClass="LBLBLACK"
                                                    Width="182px" Target="_blank" NavigateUrl="#">[HyperLinkLeasedDoc]</asp:HyperLink>
                                                <asp:Label ID="lblLeasedDoc" runat="server" ForeColor="Red" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnLeasedDoc" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnLeasedDoc_Click" />
                                            </td>
                                        </tr>
                                        <tr id="traudit" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="200px">Enclose Auditors Certificate</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupEncloseAuditorsCertificate" runat="server" />
                                                <asp:HyperLink ID="HyperLinkfupEncloseAuditorsCertificate" Visible="false" runat="server"
                                                    CssClass="LBLBLACK" Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblfupEncloseAuditorsCertificate" runat="server" ForeColor="Red" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnfupEncloseAuditorsCertificate" CssClass="btn btn-success" runat="server"
                                                    Text="Upload" OnClick="btnfupEncloseAuditorsCertificate_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tritreturns" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Previos year IT returns</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupPreviousYearITReturns" runat="server" />
                                                <asp:HyperLink ID="HyperLinkPreviousYearITReturns" Visible="false" runat="server"
                                                    CssClass="LBLBLACK" Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblPreviousYearITReturns" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnPreviousYearITReturns" CssClass="btn btn-success" runat="server"
                                                    Text="Upload" OnClick="btnPreviousYearITReturns_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="248px">Enclose reference letter from Bank</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupEnclosereferenceletterfromBank" runat="server" />
                                                <asp:HyperLink ID="HyperLinkEnclosereferenceletterfromBank" Visible="false" runat="server"
                                                    CssClass="LBLBLACK" Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblEnclosereferenceletterfromBank" runat="server" ForeColor="Red"
                                                    Visible="False"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnEnclosereferenceletterfromBank" CssClass="btn btn-success" runat="server"
                                                    Text="Upload" OnClick="btnEnclosereferenceletterfromBank_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trencloseddoc">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label41" runat="server" CssClass="LBLBLACK" Width="200px">Enclosed Documents</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupEnclosedDoc" runat="server" />
                                                <asp:HyperLink ID="HyperLinkfupEnclosedDoc" Visible="false" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblfupEnclosedDoc" runat="server" ForeColor="Red" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnfupEnclosedDoc" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnfupEnclosedDoc_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="200px">Self Certification</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupSelfDeclaration" runat="server" />
                                                <asp:HyperLink ID="HyperLinkfupSelfDeclaration" Visible="false" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblfupSelfDeclaration" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnfupSelfDeclaration" CssClass="btn btn-success" runat="server"
                                                    Text="Upload" OnClick="btnfupSelfDeclaration_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trshopcopy" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="200px">Upload Shops & Establishment License Copy</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fushops" runat="server" />
                                                <asp:HyperLink ID="HyperLinkshop" Visible="false" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lblshop" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnshop" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btnshop_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trtradecopy" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                **
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label47" runat="server" CssClass="LBLBLACK" Width="200px">Trade License</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="futrade" runat="server" />
                                                <asp:HyperLink ID="HyperLinktrade" Visible="false" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank" NavigateUrl="#"></asp:HyperLink>
                                                <asp:Label ID="lbltrade" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btntrade" CssClass="btn btn-success" runat="server" Text="Upload"
                                                    OnClick="btntrade_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%--<tr>
                    <td>
                      <div class="panel panel-default" id="dvfeedetails" runat="server" visible="false">
                            <div class="panel-heading">
                                Fee Details(in Rs.)
                            </div>
                            <div class="panel-body">
                                <table style="width: 90%">
                                    <tr>
                                        <td align="center">
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
                                                              <asp:HiddenField ID="HdfAmount" runat="server" />
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
                </tr>--%>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />&nbsp;
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                        Text="Save" OnClick="btnSave_Click" Width="90px" ValidationGroup="group" />
                                    <%--  <asp:Button ID="BtnDelete0" runat="server" Enabled="false" CssClass="btn btn-danger" Height="32px"
                                                     TabIndex="10" Text="Privious" Width="90px" Visible="False" />--%>
                                    &nbsp;
                                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px" TabIndex="10"
                                        Text="Next" Width="90px" ValidationGroup="group" OnClick="btnNext_Click" />
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
                                <div class="messagealert" id="alert_container">
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
                                    <asp:HiddenField ID="hdnencloserauditorscertificate" runat="server" />
                                    <asp:HiddenField ID="hdnencloserauditorscertificatefilename" runat="server" />
                                    <asp:HiddenField ID="hdnencloserreferanceletterfrombank" runat="server" />
                                    <asp:HiddenField ID="hdnencloserreferanceletterfrombankfilename" runat="server" />
                                    <asp:HiddenField ID="hdnshop" runat="server" />
                                    <asp:HiddenField ID="hdnshopfilename" runat="server" />
                                    <asp:HiddenField ID="hdntrade" runat="server" />
                                    <asp:HiddenField ID="hdntradefilename" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%--  <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
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
        </ContentTemplate>
     <Triggers>

            <asp:PostBackTrigger ControlID="btnfupPhoto" />
               <asp:PostBackTrigger ControlID="btnOwnedDoc" />
               <asp:PostBackTrigger ControlID="btnLeasedDoc" />
               <asp:PostBackTrigger ControlID="btnPreviousYearITReturns" />
               <asp:PostBackTrigger ControlID="btnfupEnclosedDoc" />
             <asp:PostBackTrigger ControlID="btnfupSelfDeclaration" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
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

            $("input[id$='txtDateCommencementBusiness']").datepicker(
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
            $("input[id$='txtRegDate']").datepicker(
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
        .auto-style1
        {
            width: 18px;
        }
        .auto-style2
        {
            color: #555555;
            background-color: #FFFFFF;
        }
        .auto-style4
        {
            width: 277px;
        }
        .auto-style5
        {
            width: 226px;
        }
    </style>
</asp:Content>
