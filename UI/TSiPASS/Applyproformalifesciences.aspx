<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/PDlifesicencesMaster.master" AutoEventWireup="true" CodeFile="Applyproformalifesciences.aspx.cs" Inherits="UI_TSiPASS_Applyproformalifesciences" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
    </style>
    <link href="<%= ResolveUrl("assets/css/basic.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("../../css/ui-lightness/jquery-ui-1.8.19.custom.css") %>"
        rel="stylesheet" />
    <script src="<%= ResolveUrl("../../js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("../../js/jquery-ui-1.8.19.custom.min.js") %>"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("../../Resource/Scripts/js/validations.js") %>" type="text/javascript"></script>
    <link href="<%= ResolveUrl("../../css/ui-lightness/jquery-ui-1.8.19.custom.css") %>"
        rel="stylesheet" />
    <script src="<%= ResolveUrl("../../js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("../../js/jquery-ui-1.8.19.custom.min.js") %>"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
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
        function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 12) {
                alert("Aadhar number length must be exactly 12 characters")
            }
        }
    </script>

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
    </style>
    <style>
        .algnCenter {
            text-align: center;
        }

        .auto-style1 {
            left: 3px;
            top: 0px;
        }
    </style>
    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsubmit" />
            <asp:PostBackTrigger ControlID="btnclear" />
              <asp:PostBackTrigger ControlID="btn_uplogorglogo" />
              <asp:PostBackTrigger ControlID="btn_uploadancillaryinndustires" />
        </Triggers>
        <ContentTemplate>
            <%--         <div align="left">
            </div>
            <div align="center">--%>
            <div class="row" align="center">
                <div class="col-lg-11">
                    <div class="panel panel-primary">
                        <div class="panel-heading" align="center">
                            <h3 class="panel-title">&nbsp;MSME PROFORMA OF DIRECTOR,LIFE SCIENCES</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h1 class="page-head-line" align="center" style="font-size: x-large">MSME PROFORMA OF DIRECTOR,LIFE SCIENCES</h1>
                                </div>
                            </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large"><b>organization Details</b></h1>
                            </div>
                            <asp:HiddenField ID="hf_msmeno" runat="server" />
                                <asp:HiddenField ID="hf_PDLSID" runat="server" />
                            <div class="row">
                                
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Name of Organization<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_NameofOrganization" autocomplete="off" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="500" onkeypress="Names()" TabIndex="1" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_NameofOrganization" Display="Dynamic"
                                        ErrorMessage="Please Enter Name of Organization" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Telephone Number<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_TelephoneNumber" autocomplete="off" runat="server" onkeypress="NumberOnly()"
                                        class="form-control txtbox" Height="28px" TabIndex="2" ValidationGroup="group" MaxLength="30"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_TelephoneNumber" Display="Dynamic"
                                        ErrorMessage="Please enter Telephone Number" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Fax<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_Fax" autocomplete="off" runat="server"
                                        class="form-control txtbox" Height="28px" TabIndex="3" ValidationGroup="group" MaxLength="100"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Fax" Display="Dynamic"
                                        ErrorMessage="Please enter Fax" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Website<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_Website" autocomplete="off" runat="server"
                                        class="form-control txtbox" Height="28px" TabIndex="4" ValidationGroup="group" MaxLength="300"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_Website" Display="Dynamic"
                                        ErrorMessage="Please enter Website" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Year of establishment<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_Yearofestablishment" autocomplete="off" runat="server" onkeypress="NumberOnly()"
                                        class="form-control txtbox" Height="28px" TabIndex="5" ValidationGroup="group" MaxLength="4"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Yearofestablishment" Display="Dynamic"
                                        ErrorMessage="Please enter Year of establishment" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Number of Employees(Total)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_NumbertofEmployeesTotal" autocomplete="off" runat="server" onkeypress="NumberOnly()"
                                        class="form-control txtbox" Height="28px" TabIndex="6" ValidationGroup="group" MaxLength="6"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_NumbertofEmployeesTotal" Display="Dynamic"
                                        ErrorMessage="Please enter Number of Employees(Total)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        No.of employees(Telangana)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_NumberofemployeesTelangana" autocomplete="off" runat="server" onkeypress="NumberOnly()"
                                        class="form-control txtbox" Height="28px" TabIndex="7" ValidationGroup="group" MaxLength="6"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_NumberofemployeesTelangana"
                                        ErrorMessage="Please enter Number of employees (Telangana)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Scientific Workforce(Masters &above)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_ScientificWorkforceMasters" autocomplete="off" runat="server"
                                        class="form-control txtbox" Height="28px" TabIndex="8" ValidationGroup="group" MaxLength="500"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ControlToValidate="txt_ScientificWorkforceMasters"
                                        ErrorMessage="Please enter Scientific Workforce(Masters and above)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Head Quarter Address<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_HeadQuarterAddress" autocomplete="off" runat="server" TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="9" ValidationGroup="group" MaxLength="500"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ControlToValidate="txt_HeadQuarterAddress"
                                        ErrorMessage="Please enter Head Quarter Address" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Head Quarter Address Pin Code<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_HeadQuarterAddressPinCode" autocomplete="off" runat="server"
                                        class="form-control txtbox" Height="28px" TabIndex="10" ValidationGroup="group" MaxLength="20"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_HeadQuarterAddressPinCode" Display="Dynamic"
                                        ErrorMessage="Please enter Head Quarter Address Pin Code" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>Plant Address(es)</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Address 1<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_plantAddress1" autocomplete="off" runat="server" TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="11" ValidationGroup="group" MaxLength="500"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_plantAddress1" Display="Dynamic"
                                        ErrorMessage="Please enter Plant Address 1" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Address 1 PinCode<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_Address1PinCode" autocomplete="off" runat="server"
                                        class="form-control txtbox" Height="28px" TabIndex="12" ValidationGroup="group" MaxLength="20"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_Address1PinCode" Display="Dynamic"
                                        ErrorMessage="Please enter Plant Address 1 PinCode" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Address 2<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_PlantAddress2" autocomplete="off" runat="server" TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="13" ValidationGroup="group" MaxLength="500"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_PlantAddress2" Display="Dynamic"
                                        ErrorMessage="Please enter Plant Address 2" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Address 2 Pincode<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_PlantAddress2pincode" autocomplete="off" runat="server" MaxLength="20"
                                        class="form-control txtbox" Height="28px" TabIndex="14" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_PlantAddress2pincode" Display="Dynamic"
                                        ErrorMessage="Please enter Plant Address 2 Pincode" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Address 3<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_plantaddress3" autocomplete="off" runat="server" MaxLength="500" TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="15" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_plantaddress3" Display="Dynamic"
                                        ErrorMessage="Please enter Plant Address 3" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Address 3 PinCode<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_Address3PinCode" autocomplete="off" runat="server" MaxLength="20"
                                        class="form-control txtbox" Height="28px" TabIndex="16" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_Address3PinCode" Display="Dynamic"
                                        ErrorMessage="Please enter Plant Address 3 PinCode" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <label class="formlabel">
                                        Additional Address(es) with PinCodes:[Please Specify other addressess(if any) with the a titlt Add1,Add2,etc..,]<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_AdditionalAddresses" autocomplete="off" runat="server" TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="17" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" Display="Dynamic" ControlToValidate="txt_AdditionalAddresses"
                                        ErrorMessage="Please enter Plant Additional Address(es)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large"><b>Senior Leadership and Contact Details</b></h1>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Name 1<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdname1" autocomplete="off" runat="server" onkeypress="Names()" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="18" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txt_slcdname1"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Name 1" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Designation (1)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdDesignation1" autocomplete="off" runat="server" onkeypress="Names()" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="19" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" Display="Dynamic" ControlToValidate="txt_slcdDesignation1"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Designation (1)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Mobile No(1)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdmobileno1" autocomplete="off" runat="server"
                                        class="form-control txtbox" Height="28px" TabIndex="20" ValidationGroup="group" MaxLength="200"
                                        Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txt_slcdmobileno1"
                                        ErrorMessage="Invalid Mobile Number" ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" Display="Dynamic" runat="server" ControlToValidate="txt_slcdmobileno1"
                                        ErrorMessage="Please enter  Senior Leadership and Contact Details Mobile No(1)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Email ID (1)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdEmailID1" autocomplete="off" runat="server"
                                        class="form-control txtbox" Height="28px" TabIndex="21" ValidationGroup="group" MaxLength="200"
                                        Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_slcdEmailID1"
                                        ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="group">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txt_slcdEmailID1"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Email ID (1)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Name 2<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdname2" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="22" ValidationGroup="group" onkeypress="Names()"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" Display="Dynamic" ControlToValidate="txt_slcdname2"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Name 2" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Designation (2)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdDesignation2" autocomplete="off" runat="server" onkeypress="Names()" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="23" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txt_slcdDesignation2"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Designation (2)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Mobile No(2)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdmobileno2" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="24" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txt_slcdmobileno2"
                                        ErrorMessage="Invalid Mobile Number" ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txt_slcdmobileno2"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Mobile No(2)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Email ID (2)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdEmailID2" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="25" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_slcdEmailID2"
                                        ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="group">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txt_slcdEmailID2"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Email ID (2)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Name 3<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdname3" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="26" ValidationGroup="group" onkeypress="Names()"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txt_slcdname3"
                                        ErrorMessage="Please enter  Senior Leadership and Contact Details Name 3" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Designation (3)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdDesignation3" autocomplete="off" runat="server" onkeypress="Names()" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="27" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txt_slcdDesignation3"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Designation (3)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Mobile No(3)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdmobileno3" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="28" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_slcdmobileno3"
                                        ErrorMessage="Invalid Mobile Number" ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" Display="Dynamic" ControlToValidate="txt_slcdmobileno3"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Mobile No(3)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Email ID (3)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_slcdEmailID3" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="29" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_slcdEmailID3"
                                        ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="group">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txt_slcdEmailID3"
                                        ErrorMessage="Please enter Senior Leadership and Contact Details Email ID (3)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large"><b>Contact Person</b></h1>
                                <br />
                                <b>Government intends to communicate all relevant correspondece on this mail-ID.Hence details of senior Leadership is desirable</b>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Name<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_cpname" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="30" ValidationGroup="group" onkeypress="Names()"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txt_cpname"
                                        ErrorMessage="Please enter Contact Person Name" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Designation<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_cpdesignation" autocomplete="off" runat="server" onkeypress="Names()" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="31" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txt_cpdesignation"
                                        ErrorMessage="Please enter Contact Person Designation" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Mobile No<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_CpMobileNumber" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="32" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txt_CpMobileNumber"
                                        ErrorMessage="Invalid Mobile Number" ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txt_CpMobileNumber"
                                        ErrorMessage="Please enter Contact Person Mobile No" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Email ID<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_cpEmailID" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="33" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_cpEmailID"
                                        ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="group">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" Display="Dynamic" ControlToValidate="txt_cpEmailID"
                                        ErrorMessage="Please enter Contact Person Email ID" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large"><b>Other Details</b></h1>
                                <br />
                                <b>Turnover of last Three fiacial Years(INR in Cr)</b>
                                 <br />
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        FY 2020-21 (INR in Cr)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_odFY202021INRinCr" autocomplete="off" runat="server" MaxLength="9"
                                        class="form-control txtbox" Height="28px" TabIndex="34" ValidationGroup="group" onkeypress="NumberOnly()"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txt_odFY202021INRinCr"
                                        ErrorMessage="Please enter FY 2020-21 (INR in Cr)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        FY 2019-20 (INR in Cr)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_odFY201920INRinCr" autocomplete="off" runat="server" onkeypress="NumberOnly()" MaxLength="9"
                                        class="form-control txtbox" Height="28px" TabIndex="35" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" Display="Dynamic" runat="server" ControlToValidate="txt_odFY201920INRinCr"
                                        ErrorMessage="Please enter FY 2019-20 (INR in Cr)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        FY 2018-19 (INR in Cr)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_odFY201819INRinCr" autocomplete="off" runat="server" onkeypress="NumberOnly()" MaxLength="9"
                                        class="form-control txtbox" Height="28px" TabIndex="36" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txt_odFY201819INRinCr" Display="Dynamic"
                                        ErrorMessage="Please enter FY 2018-19 (INR in Cr)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Whether registered as MSME<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddl_odWhetherregisteredasMSME" runat="server" ValidationGroup="group" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_odWhetherregisteredasMSME_SelectedIndexChanged"
                                        Height="33px" Width="180px"
                                        TabIndex="37">
                                         <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                        <asp:ListItem  Text="Yes" Value="Y"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                    </asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="ddl_odWhetherregisteredasMSME"
                                        ErrorMessage="Please select Whether registered as MSME" InitialValue="0" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left" runat="server" id="div_WhetherregisteredMSMEother" visible="false" >
                                    <label class="formlabel">
                                        Udyog Aadhar Number<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_odUdyogAadharNumber" autocomplete="off" runat="server" MaxLength="50"
                                        class="form-control txtbox" Height="28px" TabIndex="38" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txt_odUdyogAadharNumber"
                                        ErrorMessage="Please enter if yes,Provide Udyog Aadhar Number" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Legal Status of Organization<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddl_LegalStatusofOrganization" runat="server" ValidationGroup="group" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_LegalStatusofOrganization_SelectedIndexChanged"
                                        Height="33px" Width="180px" TabIndex="39">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="ddl_LegalStatusofOrganization"
                                        ErrorMessage="Please select Legal Status of Organization" Display="Dynamic" InitialValue="0" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left" runat="server" id="div_LegalStatusofOrganizationother" visible="false">
                                    <label class="formlabel">
                                        Others<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_LegalStatusofOrganizationother" autocomplete="off" runat="server" MaxLength="100"
                                        class="form-control txtbox" Height="28px" TabIndex="40" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txt_LegalStatusofOrganizationother"
                                        ErrorMessage="Please enter Legal Status of Organization others" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large"><b>Focus Sectors</b></h1>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Organization Type<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddl_fsOrganizationType" runat="server" ValidationGroup="group" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_fsOrganizationType_SelectedIndexChanged"
                                        Height="33px" Width="180px" TabIndex="41">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddl_fsOrganizationType"
                                        ErrorMessage="Please select Organization Type" InitialValue="0" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left" runat="server" id="div_fsOrganizationTypeothers" visible="false">
                                    <label class="formlabel">
                                        Others<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_fsOrganizationTypeothers" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="42" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txt_fsOrganizationTypeothers"
                                        ErrorMessage="Please enter Organization Type others" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Focus Sectors<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddl_FocusSectors" runat="server" ValidationGroup="group" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_FocusSectors_SelectedIndexChanged"
                                        Height="33px" Width="180px" TabIndex="43">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddl_FocusSectors"
                                        ErrorMessage="Please select Focus Sectors" InitialValue="0" ValidationGroup="group" Display="Dynamic" ></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left" runat="server" id="div_FocusSectorsothers" visible="false">
                                    <label class="formlabel">
                                        Others<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_FocusSectorsothers" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="44" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator44" Display="Dynamic" runat="server" ControlToValidate="txt_FocusSectorsothers"
                                        ErrorMessage="Please enter Focus Sectors others" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <label class="formlabel">
                                        Define the sub-Sector that appropriately defines your focus sector<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_DefsubSectorapprofocussector" autocomplete="off" runat="server" TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="45" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" Display="Dynamic" ControlToValidate="txt_DefsubSectorapprofocussector"
                                        ErrorMessage="Please enter Define the sub-Sector that appropriately defines your focus sector" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large"><b>R & D Services</b></h1>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>Captive R & D</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-8 form-group" align="left">
                                    <label class="formlabel">
                                        Focus Therapeutic Areas(Like Orals,Nasals,MABs,etc.)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_rdFocusTherapeuticAreas" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="46" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator46" Display="Dynamic" runat="server" ControlToValidate="txt_rdFocusTherapeuticAreas"
                                        ErrorMessage="Please enter Focus Therapeutic Areas(Like Orals,Nasals,MABs,etc.)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>Contract Research Organization</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Services <font color="red">*</font></label>
                                    <asp:TextBox ID="txt_rdcontracrresearchorgservices" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="47" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator47" Display="Dynamic" runat="server" ControlToValidate="txt_rdcontracrresearchorgservices"
                                        ErrorMessage="Please enter Contract Research Organization Services" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Capabilities<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_rdcontracrresearchorgcapabilites" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="48" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator48" Display="Dynamic" runat="server" ControlToValidate="txt_rdcontracrresearchorgcapabilites"
                                        ErrorMessage="Please enter Capabilities" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large"><b>Manufacturing services</b></h1>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>Captive Manufacturing</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Areas of Focus <font color="red">*</font></label>
                                    <asp:TextBox ID="txt_mscmAreasofFocus" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="49" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator49" Display="Dynamic" runat="server" ControlToValidate="txt_mscmAreasofFocus"
                                        ErrorMessage="Please enter Areas of Focus" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Capacity<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_mscmCapacity" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="50" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator50" Display="Dynamic" runat="server" ControlToValidate="txt_mscmCapacity"
                                        ErrorMessage="Please enter Capacity" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-6 form-group" align="left">
                                    <label class="formlabel">
                                        Accreditations/Certifications(FDA,MHRA,etc.) <font color="red">*</font></label>
                                    <asp:TextBox ID="txt_mscmAccreditationsCertificationsfdamhra" autocomplete="off" TextMode="MultiLine" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="51" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" Display="Dynamic" ControlToValidate="txt_mscmAccreditationsCertificationsfdamhra"
                                        ErrorMessage="Please enter Accreditations/Certifications(FDA,MHRA,etc.)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>

                               
                            </div>
                            <div class="row">
                                 <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Export Value (INR Cr)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_mscmExportValue" autocomplete="off" runat="server" onkeypress="NumberOnly()" MaxLength="9"
                                        class="form-control txtbox" Height="28px" TabIndex="52" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" Display="Dynamic" runat="server" ControlToValidate="txt_mscmExportValue"
                                        ErrorMessage="Please enter Export Value (INR Cr)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Export Value (in Tonnes) <font color="red">*</font></label>
                                    <asp:TextBox ID="txt_exportvalueintonnes" autocomplete="off" runat="server" onkeypress="NumberOnly()" MaxLength="9"
                                        class="form-control txtbox" Height="28px" TabIndex="53" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator53" Display="Dynamic" runat="server" ControlToValidate="txt_exportvalueintonnes"
                                        ErrorMessage="Please enter Export Value (in Tonnes)" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <h4>
                                        <b>Contract Manufacturing Organizations</b></h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Services<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_cmoservices" autocomplete="off" runat="server" MaxLength="200" TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="54" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator54" Display="Dynamic" runat="server" ControlToValidate="txt_cmoservices"
                                        ErrorMessage="Please enter Services" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Core Capabilities<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddl_cmocorecapabilities" runat="server" ValidationGroup="group" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_cmocorecapabilities_SelectedIndexChanged"
                                        Enabled="true" Height="33px" Width="180px" TabIndex="55">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddl_cmocorecapabilities"
                                        ErrorMessage="Please select  Core Capabilities" InitialValue="0" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left" runat="server" id="div_cmocorecapabilitiesothers" visible="false"> 
                                    <label class="formlabel">
                                        Others<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_cmocorecapabilitiesothers" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="56" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator56" Display="Dynamic" runat="server" ControlToValidate="txt_cmocorecapabilitiesothers"
                                        ErrorMessage="Please enter Core Capabilities Others" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                  <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Infrastructure Highlights<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_cmoInfrastructureHighlights" autocomplete="off" runat="server" MaxLength="200" TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="57" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" Display="Dynamic" ControlToValidate="txt_cmoInfrastructureHighlights"
                                        ErrorMessage="Please enter Infrastructure Highlights" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                 </div>
                            <div class="row">
                                 <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Accreditations/Certifications<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_cmoAccreditationsCertifications" autocomplete="off" runat="server" MaxLength="200" TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="58" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator58" Display="Dynamic" runat="server" ControlToValidate="txt_cmoAccreditationsCertifications"
                                        ErrorMessage="Please enter Accreditations/Certifications" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                 <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Number of international Clients<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_cmonoofinternationalClients" autocomplete="off" runat="server" onkeypress="NumberOnly()" MaxLength="9"
                                        class="form-control txtbox" Height="28px" TabIndex="59" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="txt_cmonoofinternationalClients"
                                        ErrorMessage="Please enter Number of international Clients" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                               
                               
                                <div class="col-sm-6 form-group">
                                    <label class="formlabel">
                                        Please Provide a List of ancillary Industries in Telangana along with their contacts(In excel(.xls,.xlsx) format)<font color="red"></font></label>
                                    <asp:FileUpload ID="file_ancillaryinndustires" runat="server" class="form-control txtbox" Height="33px" TabIndex="60" />
                                    <asp:HiddenField ID="hf_ancillaryinndustires" runat="server" />
                                    <asp:HyperLink ID="hyp_ancillaryinndustires" runat="server" Text="View" Visible="false" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                    <br />
                                </div>
                                <div class="col-sm-3 form-group" style="text-align: center; margin-top: -10px;">
                                    <label class="formlabel"></label>
                                    <br />
                                    <asp:Button ID="btn_uploadancillaryinndustires" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="61" OnClick="btn_uploadancillaryinndustires_Click"
                                        Text="Upload" ValidationGroup="child" Width="90px" />
                                </div>
                            </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large"><b>Global Presence (Presece outside India)</b></h1>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 form-group" align="left">
                                    <label class="formlabel">
                                        Country Names(Specify all Country names)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_gpcountrynames" autocomplete="off" runat="server" 
                                        class="form-control txtbox" Height="28px" TabIndex="62" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="txt_gpcountrynames"
                                        ErrorMessage="Please enter Country Names(Specify all Country names)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        No of Employees(Outside India)<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_gpnoofemployees" autocomplete="off" runat="server" onkeypress="NumberOnly()"
                                        class="form-control txtbox" Height="28px" TabIndex="63" ValidationGroup="group" MaxLength="6"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="txt_gpnoofemployees"
                                        ErrorMessage="Please enter No of Employees(Outside India)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <h1 class="page-head-line" align="left" style="font-size: x-large"><b>Companies Track Record</b></h1>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Unique Offering/Recent Achievements during past 5 Years<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_ctruniqueofferingpast5years" autocomplete="off" runat="server"  TextMode="MultiLine"
                                        class="form-control txtbox" Height="28px" TabIndex="64" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="txt_ctruniqueofferingpast5years"
                                        ErrorMessage="Please enter Capabilities" ValidationGroup="group" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Interested in Global Partnership<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddl_ctrInterestedinGlobalPartnership" runat="server" ValidationGroup="group" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_ctrInterestedinGlobalPartnership_SelectedIndexChanged"
                                        Height="33px" Width="180px" TabIndex="65">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="ddl_ctrInterestedinGlobalPartnership"
                                        ErrorMessage="Please select  Interested in Global Partnership" Display="Dynamic" InitialValue="0" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 form-group" align="left" runat="server" id="div_ctrInterestedinGlobalPartnershipothers" visible="false">
                                    <label class="formlabel">
                                        Others<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_ctrInterestedinGlobalPartnershipothers" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="66" ValidationGroup="group" 
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" Display="Dynamic" ControlToValidate="txt_ctrInterestedinGlobalPartnershipothers"
                                        ErrorMessage="Please enter Interested in Global Partnership Others" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                                 
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Description<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_ctrdescription" autocomplete="off" runat="server" TextMode="MultiLine"  
                                        class="form-control txtbox" Height="28px" TabIndex="67" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ControlToValidate="txt_ctrdescription"
                                        ErrorMessage="Please enter Description" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 form-group">
                                    <label class="formlabel">
                                        Upload Organization Logo(.png,.jpg,.jpeg Only) (If Any)<font color="red"></font></label>
                                    <asp:FileUpload ID="fpdOrganizationLogo" runat="server" class="form-control txtbox" Height="33px" />
                                    <asp:HiddenField ID="hf_OrganizationLogopath" runat="server" />
                                    <asp:HyperLink ID="hyp_OrganizationLogo" runat="server" Visible="false" Text="View" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                    <br />
                                </div>
                                <div class="col-sm-3 form-group" style="text-align: center; margin-top: -10px;">
                                    <label class="formlabel"></label>
                                    <br />
                                    <asp:Button ID="btn_uplogorglogo" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" OnClick="btn_uplogorglogo_Click"
                                        Text="Upload" ValidationGroup="child" Width="90px" />
                                </div>
                                 </div>
                            <div class="row">
                                <div class="col-sm-3 form-group" align="left">
                                    <label class="formlabel">
                                        Any Policy Suggestion to the State Government<font color="red">*</font></label>
                                    <asp:TextBox ID="txt_ctrAnyPolicySuggestionStateGovernment" autocomplete="off" runat="server" MaxLength="200"
                                        class="form-control txtbox" Height="28px" TabIndex="69" ValidationGroup="group" TextMode="MultiLine"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" Display="Dynamic" ControlToValidate="txt_ctrAnyPolicySuggestionStateGovernment"
                                        ErrorMessage="Please enter Any Policy Suggestion to the State Government" ValidationGroup="group"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" align="left">
                                    <label class="formlabel">
                                     
                                    <asp:CheckBox ID="chk_fordeclaration" runat="server"  AutoPostBack="true" OnCheckedChanged="chk_fordeclaration_CheckedChanged" TabIndex="68" /><font color="red">*</font></label>
                                       I hereby confirm that i belong to this compay and i am authorized to furnish the requested information on behalf of the company to the government.
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 form-group" style="text-align: center; margin-top: 12px">
                                    <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" CausesValidation="False" OnClick="btnsubmit_Click"
                                        Height="28px" Text="Submit" ValidationGroup="group" Width="72px" OnClientClick="confrim()" />
                                    &nbsp;<asp:Button ID="btnclear" runat="server" CausesValidation="false" CssClass="btn btn-xs btn-danger" OnClick="btnclear_Click"
                                        Height="28px" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="auREMARKSto-style1">
                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>







</asp:Content>

