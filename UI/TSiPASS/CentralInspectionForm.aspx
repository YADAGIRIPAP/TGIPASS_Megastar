<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="CentralInspectionForm.aspx.cs" Inherits="UI_TSiPASS_CentralInspectionForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <link type="text/css" href="css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.8.19.custom.min.js"></script>

    <script type="text/javascript">
        $(function() {
            $("#txtdateofinspection").datepicker();
        });
    </script>

    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
        }
    </style>
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
        .style21
        {
            height: 35px;
        }
        .style26
        {
            height: 21px;
        }
        .style27
        {
            height: 21px;
        }
        .style36
        {
            width: 261px;
        }
        .style46
        {
            height: 44px;
        }
        .style47
        {
            height: 44px;
            width: 261px;
        }
        .style48
        {
            width: 10px;
            height: 44px;
        }
        .style49
        {
            height: 44px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;<li class="active"><a href="#">Upload Inspection
                Details</a></li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            Central Inspection Details
                        </h3>
                    </div>
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td align="center" class="style21" style="padding: 5px; margin: 2px">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="style26" colspan="5" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label558" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="199px">Inspection Details</asp:Label>
                                            </td>
                                            <td class="style27" colspan="4" style="padding: 5px; margin: 5px;">
                                                <asp:Label ID="Label543" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="143px">Location of the Unit</asp:Label>
                                            </td>
                                        </tr>



                                           <tr>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                1
                                            </td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="162px">Date 
                                                        of Inspection<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                 <asp:TextBox ID="txtdateofinspection" autocomplete ="off" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="11" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdateofinspection">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtdateofinspection"
                                                    ErrorMessage="Please Select Date of Inspection" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                          
                                        </tr>



                                        <tr>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                2</td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label566" runat="server" CssClass="LBLBLACK" Width="162px">Department Name<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox" Height="33px"
                                                    TabIndex="1" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                     

                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDepartment"
                                                    ErrorMessage="Please Select Department" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" valign="middle">
                                                6</td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label565" runat="server" CssClass="LBLBLACK" Width="100px">District 
                                                        Name<font color="red">*</font>:</asp:Label>
                                            </td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                :&nbsp;
                                            </td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                                                    Height="33px" TabIndex="8" Width="180px" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDistrict"
                                                    ErrorMessage="Please Select District" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                3</td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label556" runat="server" CssClass="LBLBLACK" Width="180px">Inspection 
                                                        Authority Designation<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtDesignation" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="2" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDesignation"
                                                    ErrorMessage="Please Enter Inspection Authority Designation" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" valign="middle">
                                                7</td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label571" runat="server" CssClass="LBLBLACK" Width="100px">Mandal<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                                                    OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" TabIndex="9" Width="180px"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMandal"
                                                    ErrorMessage="Please Select Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                4</td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label567" runat="server" CssClass="LBLBLACK" Width="148px">Type of Inspection<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddltypofinspection" runat="server" class="form-control txtbox"
                                                    
                                                    Height="33px" TabIndex="3" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Spot Inspection</asp:ListItem>
                                                    <asp:ListItem Value="2">Scheduled Inspection</asp:ListItem>
                                                    <asp:ListItem Value="3">Inspection Against Complaint</asp:ListItem>
                                                    <asp:ListItem Value="4">Premises Inspection</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddltypofinspection"
                                                    ErrorMessage="Please Select Type of Inspection" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" valign="middle">
                                                8</td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label572" runat="server" CssClass="LBLBLACK" Width="100px">Village<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control txtbox" Height="33px"
                                                    TabIndex="10" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlVillage"
                                                    ErrorMessage="Please Select Village" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trOthers" visible="false" runat="server">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="100px"></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox runat="server" ID="txtother" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="6" Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                5</td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label568" runat="server" CssClass="LBLBLACK" Width="148px">Name 
                                                        of Unit<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtNameofUnit" runat="server" class="form-control txtbox" Height="45px"
                                                    MaxLength="40" TabIndex="4" ValidationGroup="group" TextMode="MultiLine" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNameofUnit"
                                                    ErrorMessage="Please Enter Name of Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                          
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                5
                                            </td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label569" runat="server" CssClass="LBLBLACK" Width="148px">Type 
                                                        of Unit<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtTypofunit" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="5" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTypofunit"
                                                    ErrorMessage="Enter Type of Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" valign="middle">
                                                12
                                            </td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label574" runat="server" CssClass="LBLBLACK" Width="135px">Mobile 
                                                        number of promoter or owner<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtP" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="10" TabIndex="12" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPromotermobile"
                                                    ErrorMessage="Please Enter Mobile number of promoter or owner" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPromotermobile"
                                                    ErrorMessage="Please Enter Correct Mobile number" ValidationExpression="^[789][0-9]{9}$"
                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                6
                                            </td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label570" runat="server" CssClass="LBLBLACK" Width="148px">UID / 
                                                        Registration <font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtUID" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPromotermobile"
                                                    ErrorMessage="Please Enter UID / Registration Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" valign="middle">
                                                13
                                            </td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label575" runat="server" CssClass="LBLBLACK" Width="135px">Email 
                                                        id of promoter or owner<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtPrl" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="13" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPromotermobile"
                                                    ErrorMessage="Please Enter Email id of promoter or owner" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPromotermobile"
                                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>--%>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                7
                                            </td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="148px">Aadhaar Number</asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtAadhaar" runat="server"  onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" Height="28px"
                                                    MaxLength="12" TabIndex="7" Width="180px"></asp:TextBox>
                                            </td>
                                            
                                        </tr>


                                         <tr>
                                            <td class="style26" colspan="5" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="199px">Whom did you Inspect</asp:Label>
                                            </td>
                                           
                                        </tr>
                                         <tr runat="server">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                9</td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="148px">Name
                                                       <font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtPromoterName" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPromoterName"
                                                    ErrorMessage="Please Enter Promoter Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" valign="middle">
                                                10
                                            </td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="135px">Email 
                                                        id of promoter or owner<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtPrmoterEmail" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="13" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPrmoterEmail"
                                                    ErrorMessage="Please Enter Email id of promoter or owner" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator91" runat="server" ControlToValidate="txtPrmoterEmail"
                                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                11</td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="148px">Mobile Number<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtPromotermobile" runat="server"  onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" Height="28px"
                                                    MaxLength="12" TabIndex="7" Width="180px"></asp:TextBox>
                                            </td>
                                             <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtPromotermobile"
                                                    ErrorMessage="Please Enter Mobile No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            
                                        </tr>


                                          <tr>
                                            <td class="style26" colspan="5" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="199px">To Whom should the Report be Submitted</asp:Label>
                                               <asp:Label runat="server"><b><asp:CheckBox AutoPostBack="true" OnCheckedChanged="sameasAbove_CheckedChanged" runat="server" ID="sameasAbove" />&nbsp;If Same As Above</b></asp:Label> 
                                            </td>
                                           
                                        </tr>
                                         <tr runat="server">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                12</td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="148px">Name 
                                                        <font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtInspnSub_Name" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="6" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtInspnSub_Name"
                                                    ErrorMessage="Please Enter Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" valign="middle">
                                                13
                                            </td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="135px">Email 
                                                        <font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtInspnSubEMail" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="13" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtInspnSubEMail"
                                                    ErrorMessage="Please Enter Email id " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtInspnSubEMail"
                                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                14
                                            </td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="148px">Mobile Number</asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">
                                                :&nbsp;
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtInspnSubMobileNo" runat="server"  onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" Height="28px"
                                                    MaxLength="12" TabIndex="7" Width="180px"></asp:TextBox>
                                            </td>
                                             <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtInspnSubMobileNo"
                                                    ErrorMessage="Please Enter Mobile No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                            
                                        </tr>

                                        <tr>
                                            <td class="style27" colspan="4" style="padding: 5px; margin: 5px;">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True">Attachments <font color="red">*</font><br /> (Please upload at least one Inspection document)</asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="rem" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                valign="middle">
                                                A.
                                            </td>
                                            <td class="style36" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label549" runat="server" CssClass="LBLBLACK" Width="125px">Inspection Report 1 </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                                <asp:FileUpload ID="FileUpload5" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="lblFileLink1" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                    Width="165px"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblfileUpload1" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style6" colspan="3" style="padding: 5px; margin: 5px; text-align: left;"
                                                valign="top">
                                                <asp:Button ID="BtnUpload1" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="BtnUpload1_Click" />
                                            </td>
                                        </tr>
                                        <tr id="Tr1" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                valign="middle">
                                                B.
                                            </td>
                                            <td class="style36" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="125px">Inspection Report 2</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="lblFileLink2" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                    Width="165px"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblfileUpload2" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style6" colspan="3" style="padding: 5px; margin: 5px; text-align: left;"
                                                valign="top">
                                                <asp:Button ID="BtnUpload2" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="BtnUpload2_Click" />
                                            </td>
                                        </tr>
                                        <tr id="Tr2" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                valign="middle">
                                                C.
                                            </td>
                                            <td class="style36" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="125px">Inspection Report 3</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                                <asp:FileUpload ID="FileUpload2" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="lblFileLink3" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                    Width="165px"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblfileUpload3" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style6" colspan="3" style="padding: 5px; margin: 5px; text-align: left;"
                                                valign="top">
                                                <asp:Button ID="BtnUpload3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="BtnUpload3_Click" />
                                            </td>
                                        </tr>
                                        <tr id="Tr3" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                valign="middle">
                                                D.
                                            </td>
                                            <td class="style36" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="125px">Inspection Report 4</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                                <asp:FileUpload ID="FileUpload3" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="lblFileLink4" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                    Width="165px"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblfileUpload4" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td class="style6" colspan="3" style="padding: 5px; margin: 5px; text-align: left;"
                                                valign="top">
                                                <asp:Button ID="BtnUpload4" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    Text="Upload" Width="72px" OnClick="BtnUpload4_Click" />
                                            </td>
                                        </tr>
                                        <asp:HiddenField ID="HdLink1" runat="server" />
                                        <asp:HiddenField ID="HdLink2" runat="server" />
                                        <asp:HiddenField ID="HdLink3" runat="server" />
                                        <asp:HiddenField ID="HdLink4" runat="server" />
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    &nbsp;&nbsp;<asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        Text="Submit" ValidationGroup="group" Width="90px" OnClick="BtnSave1_Click" />
                                    &nbsp;
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                </td>
                            </tr>
                            <%-- <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                                NavigateUrl="~/UI/TSiPASS/frmCFEDepartmentsApprovalProcess.aspx">Back</asp:HyperLink>
                                        </td>
                                    </tr>--%>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" class="alert alert-success">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                    </div>
                    <%-- </ContentTemplate>
</asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>
<div class="overlay">
<%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">
<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />

</div>
    
</div>
</ProgressTemplate>
</asp:UpdateProgress>   
                 --%>
    <%--                     
  </ContentTemplate>
  </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
