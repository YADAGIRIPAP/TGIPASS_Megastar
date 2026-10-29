<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmBoilerRenewals.aspx.cs" Inherits="UI_TSiPASS_frmBoilerRenewals" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

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
    <script type="text/javascript" language="javascript">
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter NumericValues Only");
            }
        }
    </script>
        <style type="text/css">
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

        .style12 {
        }

        .style13 {
            width: 13px;
        }
        .auto-style1 {
            height: 35px;
        }
        .auto-style2 {
            width: 13px;
            height: 35px;
        }
        .auto-style3 {
            width: 225px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%--<script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>
    --%>
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
            <li class="">
                <i class="fa fa-fw fa-edit">CAF</i>
            </li>
            <li class="active">
                <i class="fa fa-edit"></i><a href="#">Entrepreneur Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Boilers Details</h3>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>

                                <td style="padding: 5px; margin: 5px"></td>
                                <td style="padding: 5px; margin: 5px"></td>
                            </tr>

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label461" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="450px" style="color: Red;"><h4><b>Please fill the details as per your previous certificate</b></h4></asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr id="Tr1" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">1</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label10" runat="server" data-balloon-length="large" data-balloon="Name of Unit" data-balloon-pos="down" Width="180px">Name of Unit</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="TxtnameofUnit" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="TxtnameofUnit"
                                                    ErrorMessage="Please Enter Name of Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr id="Tr2" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Location of Unit</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged">
                                                    <%--<asp:ListItem>--District--</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlProp_intDistrictid"
                                                    ErrorMessage="Please Select Proposed Location (District)" InitialValue="0"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr id="Tr3" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td class="style12" style="padding: 5px; margin: 5px"></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlProp_intMandalid" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intMandalid_SelectedIndexChanged">
                                                    <%-- <asp:ListItem>--Mandal--</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlProp_intMandalid"
                                                    ErrorMessage="Please Select Proposed Location (Mandal)" InitialValue="0"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr4" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td class="style12" style="padding: 5px; margin: 5px"></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlProp_intVillageid" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <%--  <asp:ListItem>--Village--</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlProp_intVillageid"
                                                    ErrorMessage="Please Select Proposed Location (Village)" InitialValue="0"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr5" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td class="style12" style="padding: 5px; margin: 5px"></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtstreetName" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtstreetName"
                                                    ErrorMessage="Please enter  Street Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">1</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="200px">Maker's/Registration Number of the Boiler
(Ex:  AP/XXXX  (or)  TS/XXX  )</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtRegistrationNumber" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="30" TabIndex="1" AutoPostBack="true"
                                                    ValidationGroup="group" Width="180px"  OnTextChanged="txtRegistrationNumber_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtRegistrationNumber"
                                                    ErrorMessage="Please Enter Registration Number of Boiler"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr6" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">3</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="200px">Name of the Owner/Agent</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNameOfOwner" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtNameOfOwner"
                                                    ErrorMessage="Please Enter Name of The Owner/Agent" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr7" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">4</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="200px">Where situated</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtWhereStudied" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtWhereStudied" ErrorMessage="Please Enter Where Studied"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr8" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">5</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="200px">Date of Inspection desirable(dd-mm-yyyy)</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtDateOfInspection" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateOfInspection" PopupButtonID="txtDateOfInspection"></cc1:CalendarExtender>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="txtDateOfInspection"
                                                    ErrorMessage="Please Enter Date Of Inspection desirable"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr9" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">6</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="200px">Description of Boiler and Age</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtDescriptionofboilersAge" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="txtDateOfInspection"
                                                    ErrorMessage="Please Enter Date Of Inspection desirable"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr10" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">7</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="200px">Maker&#39;s Name</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMakersName" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                    ControlToValidate="txtMakersName" ErrorMessage="Please Enter Maker's Name"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr11" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">8</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="200px">Maker's Number/Registration Number of the Boiler</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMakersNumber" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="txtMakersNumber" ErrorMessage="Please Enter Maker's Number"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">2</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" Width="200px">Type Of Boiler & Risk criteria</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlTypeofBoiler" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="280px" TabIndex="1">
                                                   <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">SIB Boiler - Low Risk</asp:ListItem>
                                                    <asp:ListItem Value="4">Lancashire and VCT Boiler - Medium Risk</asp:ListItem>
                                                    <asp:ListItem Value="2">Package Boiler - High Risk</asp:ListItem>
                                                    <asp:ListItem Value="3">Assembled Boiler - High Risk</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="ddlTypeofBoiler" ErrorMessage="Please Select Type Of Boiler"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">3</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label449" runat="server" CssClass="LBLBLACK" Width="200px">Boiler Used for</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlBoilersUsedfor" runat="server" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Process</asp:ListItem>
                                                    <asp:ListItem Value="2">Cogeneration</asp:ListItem>
                                                    <asp:ListItem Value="3">Power</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    ControlToValidate="ddlBoilersUsedfor"
                                                    ErrorMessage="Please Select Boiler Used For" InitialValue="--Select--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">4</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">Boiler Rating/Heating Surface</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtBoilerRatingSurface" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">sqm<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                ControlToValidate="txtBoilerRatingSurface"
                                                ErrorMessage="Please Enter Boilers Rating/Heating Surface"
                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="auto-style1">5</td>
                                            <td class="auto-style1" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px"
                                                    Font-Bold="True">Place &amp; Year of Manufature</asp:Label>
                                            </td>
                                            <td class="auto-style2" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style1"></td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style1"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label482" runat="server" CssClass="LBLBLACK" Width="200px">Place</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtPlace" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    ControlToValidate="txtPlace" ErrorMessage="Please Enter Place of Manifacture"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label483" runat="server" CssClass="LBLBLACK" Width="200px">Year</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtYear" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                    ControlToValidate="txtYear" ErrorMessage="Please Enter Year Of Manufacture"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">6</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label500" runat="server" CssClass="LBLBLACK" Width="200px">Allowed Working Pressure</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtAllowedMaximumPresure" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">Kg/Cm2
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                ControlToValidate="txtAllowedMaximumPresure"
                                                ErrorMessage="Please Enter Allowed Maximum Pressure" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr id="Tr12" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">14</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label501" runat="server" CssClass="LBLBLACK" Width="200px">Economiser Maker&#39;s Number</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtEconomiserMarker" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                    ControlToValidate="txtEconomiserMarker"
                                                    ErrorMessage="Please Enter Economiser Markers Number" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">7</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label502" runat="server" CssClass="LBLBLACK" Width="200px">Maximum Continous Evaporation</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMaximumContinousEvapration" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                    ControlToValidate="txtMaximumContinousEvapration"
                                                    ErrorMessage="Please Enter Maximum Continous Evo" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr id="Tr13" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">16</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label503" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                    Width="200px">Details of Boiler Erector</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr id="Tr14" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label504" runat="server" CssClass="LBLBLACK" Width="200px">Class of Erector</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtClassofErector" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                    ControlToValidate="txtClassofErector"
                                                    ErrorMessage="Please Enter Class of Erector" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr15" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label505" runat="server" CssClass="LBLBLACK" Width="200px">Name of Erector</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNameOfErector" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                                    ControlToValidate="txtNameOfErector"
                                                    ErrorMessage="Please Enter Name of Erector" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr16" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label506" runat="server" CssClass="LBLBLACK" Width="200px">State</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlState" runat="server" class="form-control txtbox"
                                                    Height="33px" OnSelectedIndexChanged="ddlstatus28_SelectedIndexChanged"
                                                    Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                    ControlToValidate="ddlState" ErrorMessage="Please Select District"
                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr17" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">17</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label507" runat="server" CssClass="LBLBLACK" Width="200px">Maximum Pressure of Economiser</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMaximumPresureofEconomiser" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                    ControlToValidate="txtMaximumPresureofEconomiser"
                                                    ErrorMessage="Please Enter Maximum Presure of Economiser"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">8</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">Registration number of Steam Pipe Line</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtregnsteampipeline" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                            <td style="padding: 5px; margin: 5px">
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server"
                                                    ControlToValidate="txtregnsteampipeline"
                                                    ErrorMessage="Please Enter Registration Number of Stream PipeLine"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">9</td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label508" runat="server" CssClass="LBLBLACK" Width="200px">Total Length of Steam PipeLine</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtTotalLengthOfStreamPipeLine" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                    ControlToValidate="txtTotalLengthOfStreamPipeLine"
                                                    ErrorMessage="Please Enter Total Length Of Stream PipeLine"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">10</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">Inspector Authority Type</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlinspector" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlinspector_SelectedIndexChanged" TabIndex="1" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">State Boiler Department</asp:ListItem>
                                                    <asp:ListItem Value="2">Third Party Certificate</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlinspector" InitialValue="--Select--" ValidationGroup="group" ErrorMessage="Please select Inspector Authority Type" >*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trthirdpratydetails" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.a</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">Third Party</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlthirdparty" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlthirdparty_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">BOE</asp:ListItem>
                                                    <asp:ListItem Value="2">Competent person</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="ddlthirdparty" InitialValue="--Select--" ValidationGroup="group" ErrorMessage="Please select Third Party">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trthirdpraty" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.b</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px"><asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="200px" Text=""></asp:Label></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtcomponentperson" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
                                                    ControlToValidate="txtcomponentperson"
                                                    ErrorMessage="Please Enter Component Person Details"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trboenamedropdown" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.b</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">Boe Name</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlboename" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlboename_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trboeexistedlist" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.C</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px"><b>Wheather your selected BOE name not exist in the above list</b></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rbtboeexistedinlist" runat="server" RepeatDirection="Horizontal" Height="16px" Width="210px" OnSelectedIndexChanged="rbtboeexistedinlist_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trboename" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.b</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px"><asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="200px" Text="">BOENAME</asp:Label></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtboename" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    ControlToValidate="txtcomponentperson"
                                                    ErrorMessage="Please Enter Component Person Details"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trboecertificateno" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.c</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px"><asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="200px" Text="">Certificate No.</asp:Label></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtboecertificateno" Enabled="false" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trboeaddress" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.d</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px"><asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px" Text="">Address</asp:Label></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtboeaddress" runat="server" Enabled="false" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trboemobileno" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.e</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px"><asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="200px" Text="">MobileNo</asp:Label></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtboemobileno" runat="server" Enabled="false" class="form-control txtbox" Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trboeemailid" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.f</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px"><asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="200px" Text="">EmailId</asp:Label></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtboeEmailid" runat="server" Enabled="false" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtboeEmailid"
                                                                ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                &nbsp;</td>
                                        </tr>
                                       <tr runat="server" id="trexperience" visible="false">
                                            <td style="padding: 5px; margin: 5px">10.g</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">BOE Experience</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlboeexperience" runat="server"  class="form-control txtbox" Height="33px" TabIndex="1" Width="180px" >
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr runat="server" id="trregister" visible="false">
                                            <td style="padding: 5px; margin: 5px"></td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px"></td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; color:black; margin: 5px">
                                                <asp:Button ID="btnregister" runat="server" BackColor="Blue" Text="Register" OnClick="btnregister_Click" />
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        
                                        <tr id="Tr18" runat="server">
                                            <td style="padding: 5px; margin: 5px">11.</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">Whether Certification of Boiler U/R 376 (ff) / 376 (fff) / 34(2) is Required</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rdur376" runat="server" RepeatDirection="Horizontal" Height="16px" Width="210px" OnSelectedIndexChanged="rdur376_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server"
                                                    ControlToValidate="rdur376"
                                                    ErrorMessage="Please Select Whether Certification of Boiler U/R 376 (ff) is Required"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                         
                                        <tr id="trrepairers" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">12.</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">If Any Repairs</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rdrepairers" runat="server" RepeatDirection="Horizontal" Height="16px" Width="210px" AutoPostBack="true" OnSelectedIndexChanged="rdrepairers_SelectedIndexChanged">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server"
                                                    ControlToValidate="rdrepairers"
                                                    ErrorMessage="Please Select if Any Repairs"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trrepairername" visible="false">
                                            <td style="padding: 5px; margin: 5px">12.a</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">Name of the Repairer</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtrepairername" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server"
                                                    ControlToValidate="txtrepairername"
                                                    ErrorMessage="Please Enter Name of the Repairer"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trrepairerclass" visible="false">
                                            <td style="padding: 5px; margin: 5px">12.b</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">Class of the Repairer</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtrepairerclass" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server"
                                                    ControlToValidate="txtrepairerclass"
                                                    ErrorMessage="Please Enter Class of the Repairer"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trfeedetails" visible="false">
                                            <td style="padding: 5px; margin: 5px">13.</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">Fee Details </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtfeedetails" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server"
                                                    ControlToValidate="txtfeedetails"
                                                    ErrorMessage="Please Enter Fee Details"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trmodeofpayment" visible="false">
                                            <td style="padding: 5px; margin: 5px">14</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px">Mode Of Payment</td>
                                            <td class="style13" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtmodeofpayment" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server"
                                                    ControlToValidate="txtmodeofpayment"
                                                    ErrorMessage="Please Enter Mode Of Payment"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                    </tr>
                                    <caption>
                                        &nbsp;</caption>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table style="width: 50%">


                                        <tr runat="server" id="trerector" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Upload Erector License Copy<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadErector" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="lblFileNameErector" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameErector]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelErector" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="BtnErector" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="BtnErector_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trreqdoc" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="210px">Required Documents(Form II/XVII/Release Note)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadRequiredDoc" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkRequiredDoc" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameRequiredDoc]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelRequiredDoc" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnreqdoc" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnreqdoc_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trotherdoc" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="210px">Upload Any Other Document<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadOtherDoc" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkOtherDoc" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameOtherDoc]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelOtherDoc" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnanyotherdoc" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnanyotherdoc_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trformvi" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="210px">Upload Form VI or V<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadFormVI" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkFormVI" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameFormVI]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelFormVI" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnformvi" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnformvi_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trformv" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="210px">Upload Form V<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadFormV" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkFormV" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameFormV]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelFormV" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnformv" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnformv_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trdrawing" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">Upload Drawing Design<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadDrawing" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkDrawing" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameDrawing]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelDrawing" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btndrawing" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btndrawing_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trcbb" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1 </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="210px">Upload CBB authority certification letter<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadCBB" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkCBB" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameCBB]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelCBB" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnuploadcbb" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnuploadcbb_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trAnnexure" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="210px">Upload Anexure<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadAnexure" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkAnexure" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameAnexure]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelAnexure" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Btnanexure" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Btnanexure_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trur376" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">8</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="210px">Upload Form XIX<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadFormXIX" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="HyperLinkFormXIX" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblFileNameFormXIX]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LabelFormXIX" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnFormXIX" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnFormXIX_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trrepairerdoc" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="210px">Upload Repair details<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fileuploadrepairer" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hyperlinkrepairer" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblRepairer]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="labelrepairer" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnrepairer" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnrepairer_Click" />
                                            </td>
                                        </tr>

                                        <tr runat="server" id="trboecertification" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="210px">Upload BOE Certification<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fileuploadboecertification" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hyperlinkboecertification" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblboecertification]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="labelboecertification" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnboecertification" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnboecertification_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trboequalification" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="210px">Upload BOE Qualification<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fileuploadboequalification" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hyperlinkboequalification" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank">[lblboequalification]</asp:HyperLink>
                                                <br />
                                                <asp:Label ID="labelboequalification" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnboequalification" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnboequalification_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                        ValidationGroup="group" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
                                        Text="Next" Width="90px"
                                        ValidationGroup="group" />
                                    &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False"
                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click"
                                        TabIndex="10" Text="Previous" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        <strong>Success!</strong><asp:Label ID="lblmsg1" runat="server"></asp:Label>
                                    </div>


                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg2" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                    </div>
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>

    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
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


    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

