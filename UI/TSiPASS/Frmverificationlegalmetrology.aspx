<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="Frmverificationlegalmetrology.aspx.cs" Inherits="Frmverificationlegalmetrology" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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

        .update {
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

        .style5 {
            color: #FF0000;
        }

        .auto-style1 {
            height: 45px;
        }

        .auto-style2 {
            height: 57px;
        }

        .auto-style3 {
            width: 344px;
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
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
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

    <%-- <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length = 6)
                return true;
            else {
                alert("Pin number length must be exactly 6 characters")
                return false;
            }

        }
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    --%>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
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
                        <%--<div class="panel panel-primary">
                           <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Entrepreneur Details</h3>
                            </div>--%>
                        <div class="col-md-12">
                            <h1 class="page-head-line" align="center" style="font-size: x-large">Application for Legal Metrology Verification</h1>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="panel-body" align="left">
                                    <table align="left" cellpadding="10" cellspacing="5" style="width: 90%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 70%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">1.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name of the unit<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:TextBox ID="txtindustrialName" runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="1" ValidationGroup="group" Width="250px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtindustrialName"
                                                                ErrorMessage="Please enter Industries Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px">2.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Width="165px">State<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlstate" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px"
                                                                TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtindustrialName"
                                                                ErrorMessage="Please select State" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">3.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                            <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"
                                                                TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <%--<asp:ListItem Value="31">31</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtindustrialName"
                                                                ErrorMessage="Please select District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">4.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlmandal" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlmandal_SelectedIndexChanged"
                                                                TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <%--<asp:listitem value="311">311</asp:listitem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtindustrialName"
                                                                ErrorMessage="Please select Mandal" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">5.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlvillage" runat="server" class="form-control txtbox" TabIndex="1"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <%-- <asp:ListItem Value="7546">7546</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtindustrialName"
                                                                ErrorMessage="Please select Village" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">6.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">Registartion Type<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:DropDownList ID="ddlregtype" runat="server" class="form-control txtbox" TabIndex="1"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">User WM verification</asp:ListItem>
                                                                <asp:ListItem Value="2">OEM other state services</asp:ListItem>
                                                                <asp:ListItem Value="3">Repairer WM verification</asp:ListItem>
                                                                <%--<asp:ListItem Value="4">--Select--</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtindustrialName"
                                                                ErrorMessage="Please select Village" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <%--    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">6.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Door No<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtdoorno" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdoorno"
                                                                ErrorMessage="Please enter door number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">7.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Pin Code<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtpincode" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="6" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpincode"
                                                                ErrorMessage="Please enter pincode" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">8.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="txttelno1" runat="server" CssClass="LBLBLACK" Width="165px">Telephone No<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txttelno" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txttelno"
                                                                ErrorMessage="Please enter Latitude No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>

                                                    <%--<tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">9.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Latitude<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtlat" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtlat"
                                                                ErrorMessage="Please enter Latitude No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">10.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="txtlong4" runat="server" CssClass="LBLBLACK" Width="165px">Longitude<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtlong" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtlong"
                                                                ErrorMessage="Please enter Longitude" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>
                                                    <%-- <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">11.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">E-Mail<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtemail" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtemail"
                                                                ErrorMessage="Please enter Email" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">12.
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                            <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">GST Number<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style2">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                            <asp:TextBox ID="txtgstno" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style2">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtgstno"
                                                                ErrorMessage="Please enter GST Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>
                                                    <%--  <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">13.&nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label420" runat="server" CssClass="LBLBLACK" Width="211px">Validity of  Battery Dealer Registration(dd-MM-yyyy)<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:TextBox ID="txtRegDate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="80" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtRegDate"
                                                                    TargetControlID="txtRegDate">
                                                                </cc1:CalendarExtender>--%>
                                            </td>
                                            <%-- <tr>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtindustrialName" ErrorMessage="Please select validity date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>--%>
                                        </tr>
                                        <%-- <caption>
                                                --%&gt;
                                            </caption>--%>
                                                    </tr>
                                    </table>
                                    </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                    Width="90px" />&nbsp;
                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    OnClick="BtnSave1_Click" TabIndex="10" Text="Submit" Width="90px" ValidationGroup="group" />
                                                <asp:Button ID="btnnext" runat="server" ValidationGroup="group" CssClass="btn btn-danger"
                                                    Height="32px" TabIndex="10" Text="Next" Width="90px" OnClick="Btnnext_Click" Visible="true" />
                                            </td>
                                        </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">×times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    </table>

                                    <%--<tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
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
                                        </tr>--%>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--  </div>--%>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
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

    </asp:UpdatePanel>
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

            $("input[id$='txtRegDate']").datepicker(
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
            $("input[id$='txtRegDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
</asp:Content>
