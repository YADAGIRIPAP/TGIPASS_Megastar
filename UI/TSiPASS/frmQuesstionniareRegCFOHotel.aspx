<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmQuesstionniareRegCFOHotel.aspx.cs" Inherits="UI_TSiPASS_frmQuesstionniareRegCFOHotel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
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

        .wizard > .content {
            height: 560px;
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

        .style5 {
            width: 538px;
        }

        .style6 {
            height: 40px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
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
    <%--    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <input type="hidden" id="hdnfocus" value="" runat="server" />
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CFO</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Questionnaire - Consent for
                        Operations</a> </li>
                </ol>
            </div>
            <div>
                <table style="width: 100%">
                    <tr>
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
                                        Questionnaire - Consent for Operations
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
                <tr style="height: 15px">
                    <td>
                    </td>
                </tr>
                <%-- <tr style="height: 15px">
                    <td>
                        <asp:Button Text="1. Project Details" Height="60px" Font-Bold="true" Width="200px" BorderWidth="2px" BorderColor="Black" BorderStyle="Solid" ID="Tab1" CssClass="Initial" runat="server"
                            OnClick="Tab1_Click" />
                        &nbsp;&nbsp;&nbsp;
                <asp:Button Text="2. Project Financials" Height="60px" Font-Bold="true" Width="200px" BorderWidth="2px" BorderColor="Black" BorderStyle="Solid" ID="Tab2" CssClass="Initial" runat="server"
                    OnClick="Tab2_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button Text="3. Project Requirements" Height="60px" Font-Bold="true" Width="200px" BorderWidth="2px" BorderColor="Black" BorderStyle="Solid" ID="Tab3" CssClass="Initial" runat="server"
                    OnClick="Tab3_Click" />
                    </td>
                </tr>--%>
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
                <tr>
                    <td>
                        <asp:MultiView ID="MainView" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width: 100%; border-width: 2px; border-color: #666; border-style: solid;
                                    font-weight: bold; background-color: #d9d9d9">
                                    <tr>
                                        <td style="padding: 15px; margin: 5px">
                                            1
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="220px">Name of Unit<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtNameOfIndustrialUndertaking" runat="server" class="form-control txtbox"
                                                Height="28px" MaxLength="60" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNameOfIndustrialUndertaking"
                                                ErrorMessage="please select name of unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px; text-align: left;">
                                            2
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="lblSectorofEnterprise" runat="server" CssClass="LBLBLACK" Width="165px">Sector of Enterprise<font 
                                                            color="red">*</font></asp:Label>

                                            <asp:Label ID="lblHotelLineofActivity" runat="server" CssClass="LBLBLACK" Width="165px">Line of Activity<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:DropDownList ID="ddlSector" runat="server" class="form-control txtbox" Height="33px"
                                                Width="180px" TabIndex="1">
                                               
                                            </asp:DropDownList>
                                             <asp:DropDownList ID="ddlHotelType" runat="server" class="form-control txtbox" Height="33px"
                                                Width="180px"  >
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSector"
                                                ErrorMessage="Please select Sector Enterprise" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px;">
                                            3
                                        </td>
                                        <td style="padding: 5px; margin: 5px;">
                                            <asp:Label ID="Label352" runat="server" CssClass="LBLBLACK" Width="165px">Proposed Location<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged"
                                                TabIndex="1">
                                                <asp:ListItem>--District--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProp_intDistrictid"
                                                ErrorMessage="Please select District" InitialValue="--District--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px">
                                            4&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="lblLineofActivity" runat="server" CssClass="LBLBLACK" Width="165px">Line of Activity<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="form-control txtbox"
                                                Height="33px" AutoPostBack="True" OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged"
                                                Width="180px">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlintLineofActivity"
                                                ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlProp_intMandalid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intMandalid_SelectedIndexChanged"
                                                TabIndex="1">
                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProp_intMandalid"
                                                ErrorMessage="Please select Mandal" InitialValue="--Mandal--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px" valign="top">
                                            5
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK">Pollution Category of Enterprise<font 
                                                            color="red">*</font></asp:Label>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlProp_intVillageid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="ddlProp_intVillageid_SelectedIndexChanged">
                                                <asp:ListItem>--Village--</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlProp_intVillageid"
                                                ErrorMessage="Please select Village" InitialValue="--Village--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px" valign="top">
                                            6
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK">CFE UID Number</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" id="Td1">
                                           <asp:TextBox ID="txtcfeuidno" runat="server" class="form-control txtbox"
                                                Height="28px" MaxLength="60" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtcfeuidno_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                         <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtcfeuidno"
                                                ErrorMessage="please Enter CFE UID Number" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trFallinPolution" visible="false">
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK">Does your unit fall under the list of <font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="RdPol_Indus" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                   <%-- <tr runat="server" id="trTourismClassification" visible="false">
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK">Classification <font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                           <asp:DropDownList ID="ddlClassification" runat="server" class="form-control txtbox" TabIndex="1"
                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlClassification_SelectedIndexChanged">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem Value="5">5 Star</asp:ListItem>
                                                <asp:ListItem Value="3">3 Star</asp:ListItem>
                                               <asp:ListItem Value="2">3 Star</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>--%>
                                  <tr style="height: 50px">
                                        <td style="padding: 5px; margin: 5px" colspan="10" align="right">
                                            <asp:Button Text="Next" BackColor="ForestGreen" ForeColor="White" Height="60px" Width="200px"
                                                BorderStyle="Solid" ID="btntab1next" ValidationGroup="group" runat="server" OnClick="btntab1next_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; font-weight: bold;" colspan="3">
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width: 100%; border-width: 2px; border-color: #666; border-style: solid;
                                    font-weight: bold; background-color: #d9d9d9">
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            7.
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
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">New</asp:ListItem>
                                                <asp:ListItem Value="2">Expansion</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlproposal"
                                                ErrorMessage="Please enter Proposed For" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 430px; font-weight: bold;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            8.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label5" runat="server" data-balloon-length="large" data-balloon="Please Select Project Cost"
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
                                                ErrorMessage="Please Select Eneterd Emount Type" InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                                    <asp:Label ID="Label390" runat="server" CssClass="LBLBLACK">Value of Land</asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="txtlandvalueActul" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                        Width="180px" AutoPostBack="True" OnTextChanged="txtlandvalueActul_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtlandvalueActul"
                                                                        ErrorMessage="Please enter Value of Land" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                                    <asp:TextBox ID="txtlandvalue" runat="server" class="form-control txtbox" Enabled="false"
                                                                        Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                        ValidationGroup="group" Width="180px" OnTextChanged="txtlandvalue_TextChanged"
                                                                        AutoPostBack="True"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 15px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black; border-right: solid 1px black" valign="top">
                                                                    b)
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" valign="top">
                                                                    <asp:Label ID="Label391" runat="server" CssClass="LBLBLACK">Value of Building<font 
                                color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="txtbuildingvalueActual" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                        ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtbuildingvalueActual_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbuildingvalueActual"
                                                                        ErrorMessage="Please enter Value of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                                    <asp:TextBox ID="txtbuildingvalue" runat="server" class="form-control txtbox" Enabled="false"
                                                                        Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                        ValidationGroup="group" Width="180px" OnTextChanged="txtbuildingvalue_TextChanged"
                                                                        AutoPostBack="True"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-right: solid 1px black">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 15px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-left: solid 1px black; border-right: solid 1px black">
                                                                    c)
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black" valign="top">
                                                                    <asp:Label ID="Label392" runat="server" CssClass="LBLBLACK">Value of Plant &amp; Machinery or Service Equipment<font 
                                color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="txtPlantvalueActual" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                        ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtPlantvalueActual_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPlantvalueActual"
                                                                        ErrorMessage="Please enter Value of Plant" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                                    <asp:TextBox ID="txtPlantvalue" runat="server" class="form-control txtbox" Enabled="false"
                                                                        Height="28px" MaxLength="10" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                        ValidationGroup="group" Width="180px" OnTextChanged="txtPlantvalue_TextChanged"
                                                                        AutoPostBack="True"></asp:TextBox>
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
                                                                    <asp:Label ID="txttotal" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="180px"></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black; border-right: solid 1px black">
                                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                        ControlToValidate="txttotal" ErrorMessage="Please enter Total Project"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
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
                                                    <td valign="top">
                                                        <table id="tblexpansion" runat="server" visible="false">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black;">
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-right: solid 1px black" align="left" valign="top" colspan="2">
                                                                    <span style="font-weight: bold"><u>Expansion Investment </u></span>
                                                                </td>
                                                                <td style="width: 225px; padding: 5px; margin: 5px; font-weight: bold; border-top: solid 1px black;
                                                                    border-right: solid 1px black" align="left" valign="top">
                                                                    <span style="font-weight: bold"><u>Total Investment(In Rs. Lakhs) </u></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 15px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="TxtVal_Land_ActualExpansion" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
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
                                                                    &nbsp;&nbsp;:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px;">
                                                                    <asp:TextBox ID="TxtVal_LandExpansion" runat="server" class="form-control txtbox"
                                                                        Height="28px" Enabled="false" MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0"
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
                                                                <td style="padding: 15px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="TxtVal_Build_ActualExpn" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
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
                                                                    &nbsp;&nbsp;:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="TxtVal_BuildExpanstion" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
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
                                                                <td style="padding: 15px; margin: 5px; border-top: solid 1px black">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    <asp:TextBox ID="TxtVal_Plant_ActualExpansion" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
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
                                                                    &nbsp;&nbsp;:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="TxtVal_PlantExpanstion" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="10" onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group"
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
                                                                <td style="padding: 5px; margin: 5px; border-top: solid 1px black">
                                                                    &nbsp;&nbsp;:
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
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label394" runat="server" CssClass="LBLBLACK" Width="165px">Your enterprise is</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" colspan="2">
                                            <asp:Label ID="LblEnt_is" runat="server" CssClass="LBLBLACK" Width="165px" Font-Bold="True"
                                                Font-Size="18px"></asp:Label>
                                            <asp:HiddenField ID="HdfLblEnt_is" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                        </td>
                                        <td align="right">
                                            <asp:Button Text="Previous" Height="60px" BackColor="ForestGreen" ForeColor="White"
                                                Width="200px" BorderStyle="Solid" ID="Button1" runat="server" OnClick="Button1_Click" />
                                            &nbsp;&nbsp;&nbsp
                                            <asp:Button Text="Next" Height="60px" BackColor="ForestGreen" ForeColor="White" Width="200px"
                                                ValidationGroup="group" BorderStyle="Solid" ID="btntab2next" runat="server" OnClick="btntab2next_Click" />
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
                                <table style="width: 100%; background-color: #d9d9d9; border-width: 2px; border-color: #666;
                                    border-style: solid; font-weight: bold">
                                    <tr>
                                        <td colspan="15" style="height: 15px; font-weight: bold;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 15px; margin: 5px; text-align: left;" valign="top" height="70px">
                                            9.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Have you taken CFE from Pollution Control Board<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rdpPOLRDP" runat="server" RepeatDirection="Horizontal" Width="200px"
                                                TabIndex="1">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rdpPOLRDP"
                                                ErrorMessage="Please Select CFE Pollution Control Board" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px" valign="top" height="60px" runat="server" id="tdApprovalfromFactories1" visible="false" >
                                            9.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" id="tdApprovalfromFactories2" visible="false">
                                            <asp:Label ID="lblApprovalfromFactories" runat="server" CssClass="LBLBLACK" Width="200px" Height="60px">Have you taken Plan Approval from Factories Department<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" id="tdApprovalfromFactories3" visible="false">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" id="tdApprovalfromFactories4" visible="false">
                                            <asp:RadioButtonList ID="RdpFactory" runat="server" RepeatDirection="Horizontal"
                                                Width="200px" TabIndex="1">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="RdpFactory"
                                                ErrorMessage="Please Select Factories" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trceig" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px" valign="top" height="40px">
                                            10.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label350" runat="server" CssClass="LBLBLACK" Width="200px">DO you Need Electrical Installation Certificate(To apply this, Electrical Design Approval Must be Taken before)<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="RdpIndustry" runat="server" RepeatDirection="Horizontal"
                                                Width="200px" TabIndex="1">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="RdpIndustry"
                                                ErrorMessage="Please Select meter to your (HT)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px" colspan="3">
                                            <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="220px">Building Height</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false" id="trfire">
                                        <td height="50px" style="padding: 15px; margin: 5px">
                                            11.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="220px">Is your Building Height Greater than 14.99 meters<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="RdpBuildingHeight" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RdpBuildingHeight_SelectedIndexChanged"
                                                RepeatDirection="Horizontal" TabIndex="1" Width="200px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RdpNOC"
                                                ErrorMessage="Please Select NOC from FIRE" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px" valign="top" class="style6">
                                            12.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="style6">
                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">Do you need license from Drug control Authority<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="style6">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="style6">
                                            <asp:RadioButtonList ID="RdpDrugs" runat="server" TabIndex="1" RepeatDirection="Horizontal"
                                                Width="200px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="style6">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="RdpDrugs"
                                                ErrorMessage="Please Select product Related Drugs" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trNOC" visible="false">
                                        <td style="padding: 15px; margin: 5px" height="40px">
                                            11.a
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label370" runat="server" CssClass="LBLBLACK" Width="220px">Do you Require NOC from FIRE<font color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="RdpNOC" runat="server" AutoPostBack="true" TabIndex="1"
                                                RepeatDirection="Horizontal" Width="200px" OnSelectedIndexChanged="RdpNOC_SelectedIndexChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="RdpNOC"
                                                ErrorMessage="Please Select NOC from FIRE" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40px" style="padding: 15px; margin: 5px" valign="top">
                                            12.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label399" runat="server" CssClass="LBLBLACK" Width="220px">Do you have feasibility Details of TSSPDCL/TSNPDCL</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="RdpDrugs0" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RdpDrugs0_SelectedIndexChanged"
                                                RepeatDirection="Horizontal" TabIndex="1" Width="200px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="RdpDrugs0"
                                                ErrorMessage="Please Select Drugs" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="padding: 15px; margin: 5px" valign="top" height="40px" runat="server" id="tdboilers1" visible="false">
                                            14
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" id="tdboilers2" visible="false">
                                            <asp:Label ID="Label379" runat="server" CssClass="LBLBLACK" Width="220px">Do you use boilers in your Industry<font 
                                                            color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" id="tdboilers3" visible="false">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px" runat="server" id="tdboilers4" visible="false">
                                            <asp:RadioButtonList ID="RdpBoiler" runat="server" TabIndex="1" RepeatDirection="Horizontal"
                                                Width="200px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="RdpBoiler"
                                                ErrorMessage="Please Select Boilers" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="servicelat" runat="server" visible="false">
                                        <td height="40px" style="padding: 15px; margin: 5px" valign="top">
                                            12a
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label400" runat="server" CssClass="LBLBLACK" Width="220px">Do you want to apply for service connection certificate</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="RdpService" runat="server" RepeatDirection="Horizontal"
                                                TabIndex="1" Width="200px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="RdpService"
                                                ErrorMessage="Please Select Sevice Connection" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="lbr1" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            13
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="middle" colspan="8">
                                            <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" data-balloon-length="large"
                                                data-balloon="Please select Application Type" data-balloon-pos="down" Font-Bold="True">Labour Application Type</asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="lbr2" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            13a.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                            Does your establishment fall under the definition of establishment under shops &amp;
                                            establishment Act,1988?
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            :
                                        </td>
                                        <td style="padding: 5px; margin: 5px 5px 5px 45px" valign="top">
                                            <asp:RadioButtonList ID="RdbExecptedact1" runat="server" Height="17px" RepeatDirection="Horizontal"
                                                Width="210px" OnSelectedIndexChanged="RdbExecptedact1_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem  Value="N">No</asp:ListItem>
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
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNoofworkers"
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
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDateofCommenceAct1"
                                                                ErrorMessage="Please Select Date of Commencement of business" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateofCommenceAct1">
                                            </cc1:CalendarExtender>--%>
                                        </td>
                                    </tr>
                                    <tr id="lbr3" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            13b.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top" colspan="6">
                                            Does your establishment employ 05 or more contract Laour as defined in the Contract
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
                                    <tr id="lbr4" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            13c.
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
                                    <tr id="lbr5" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            14.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                           <%-- Do you pack and label your product--%>
                                            Certificate for verification of weights and measures and its renewal
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            &nbsp;
                                        </td>
                                        <td colspan="6" style="padding: 5px; margin: 5px" valign="top">
                                            <asp:RadioButtonList ID="rbtnLstLabel" runat="server" RepeatDirection="Horizontal"
                                                Height="17px" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="Trsteampipeline" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">
                                            17.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            Do you require Steam Pipeline Registration
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            &nbsp;
                                        </td>
                                        <td colspan="6" style="padding: 5px; margin: 5px" valign="top">
                                            <asp:RadioButtonList ID="rbtnLstBoilerSteamPipeline" runat="server" RepeatDirection="Horizontal"
                                                Height="17px" Width="210px">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="troc" runat="server" visible="true">
                                        <td style="padding: 15px; margin: 5px; width: 2px; font-weight: bold;">15. </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">Building Permission obtained from 
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                        <td colspan="6" style="padding: 5px; margin: 5px" valign="top">
                                            <asp:RadioButtonList ID="RDOC" runat="server" RepeatDirection="Horizontal" Height="17px" Width="210px" OnSelectedIndexChanged="RDOC_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="HMDA">HMDA</asp:ListItem>
                                                <%--<asp:ListItem Value="TSIIC">TSIIC</asp:ListItem>--%>
                                                 <asp:ListItem Value="GHMC">GHMC</asp:ListItem>
                                                <asp:ListItem Value="DTCP">DTCP</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="trhmdatsiicfileno" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 15px" colspan="7" align="left">Enter File number of Building Permission</td>
                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                            <asp:TextBox ID="txtfilenumber" runat="server" Height="28px" class="form-control txtbox"
                                                MaxLength="50" TabIndex="0" ValidationGroup="group"
                                                Width="220px" OnTextChanged="txtfilenumber_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trcanumber" runat="server" visible="false">
                                        <td style="padding: 15px; margin: 15px" colspan="7" align="left">Architect License No.</td>
                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px" class="auto-style1">
                                            <asp:TextBox ID="txtalic1" runat="server" class="textboxPge"
                                                TabIndex="1"
                                                ValidationGroup="group" Width="40px" Text="CA" ReadOnly="true"></asp:TextBox>
                                            <asp:TextBox ID="txtalic2" runat="server" class="textboxPge"
                                                TabIndex="1"
                                                ValidationGroup="group" Width="50px" MaxLength="4" onkeypress="NumberOnly()"></asp:TextBox>
                                            <asp:TextBox ID="txtalic3" runat="server" class="textboxPge"
                                                TabIndex="1"
                                                ValidationGroup="group" Width="60px" MaxLength="5" onkeypress="NumberOnly()"></asp:TextBox>
                                            (Ex : CA-Year-5 digits.)
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trhotelcfo" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">16.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                             <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK">Do you require star classification from ministry of tourism government of india</asp:Label>
                                         <%--   <asp:Label ID="Label19" runat="server" data-balloon-length="large" 
                                                data-balloon-pos="down" Width="260px"> </asp:Label>--%>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rdhotelcfo" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rdhotelcfo_SelectedIndexChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">17.
                                        </td>
                                        <td><asp:Label ID="Label11" runat="server" CssClass="LBLBLACK">Do you require BAR license? (Only classified 3star and above hotels are eligible for BAR license as per the Excise norms.)   </asp:Label> </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:RadioButtonList ID="rdBarLicense" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rdBarLicense_SelectedIndexChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList><br />
                                             <asp:Label ID="lblBarLicense" runat="server" Text="Please Apply after Notification issued by Government" Visible="false" ForeColor="#3333cc"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>

                                    <tr runat="server" id="trTourismPoliceNOC" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                             <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK">Police NOC for Operations of Unit in terms of Parking and Traffic</asp:Label>
                                         <%--   <asp:Label ID="Label19" runat="server" data-balloon-length="large" 
                                                data-balloon-pos="down" Width="260px"> </asp:Label>--%>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rdPoliceNOC" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rdPoliceNOC_SelectedIndexChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                        </td>
                                        <td> </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr> 

                                    <tr runat="server" id="trTourismPoliceNOCYesCond1" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label20" runat="server" data-balloon-length="large"  
                                                data-balloon-pos="down" Width="260px">Total parking area proposed in the Building Plan i.e. (% of the built up area as per the norms is available or not?  </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rdParkingCondition" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rdParkingCondition_SelectedIndexChanged"  >
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px"></td>
                                        <td></td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                           
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                    <tr runat="server" id="trParkingConditionYes" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtParkingConditionYesRemarks" runat="server" TextMode="MultiLine" Width="350px"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px"></td>
                                        <td></td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                    <tr runat="server" id="trTourismPoliceNOCYesCond2" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label21" runat="server"   Width="260px">Whether sufficient measures have been taken for storage of construction material and 
movement of construction vehicles without hindering the flow of traffic. </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rdStorageConstruction" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rdStorageConstruction_SelectedIndexChanged"  >
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px"></td>
                                        <td></td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                     <tr runat="server" id="trStorageConstructionYes" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtStorageConstructionYesRemarks" runat="server" TextMode="MultiLine" Width="350px"></asp:TextBox>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px"></td>
                                        <td></td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                     <tr runat="server" id="trPoliceBuiltupAreaInput" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            
                                            Total Built up Area</td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                             <asp:TextBox ID="TxtBuilt_up_Area" runat="server" class="form-control txtbox" Height="28px"
                                                MaxLength="6" TabIndex="0" ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                 ></asp:TextBox>
                                            Square Meters
                                        </td>
                                         <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="TxtBuilt_up_Area"
                                                ErrorMessage="Please Enter Built up Area " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px"></td>
                                        <td></td>
                                        <td style="padding: 5px; margin: 5px">
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;"></td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>

                                       <tr runat="server" id="trTradeLicense" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">18
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label3" runat="server" data-balloon-length="large" 
                                                data-balloon-pos="down" Width="260px">Do you require Trade License?  </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rbtnTradeLicense" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rbtnTradeLicense_SelectedIndexChanged">
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px">19</td>
                                        <td>Do you require approval of Health & Sanitary, Garbage Disposal?  </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                            <asp:RadioButtonList ID="rbtnHealthandSanitary" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="false"  >
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                          <tr runat="server" id="trFSSAI" visible="false">
                                        <td style="padding: 15px; margin: 5px; font-weight: bold;">20
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:Label ID="Label9" runat="server" data-balloon-length="large" 
                                                data-balloon-pos="down" Width="260px">Do you require FSSAI certificate?  </asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RadioButtonList ID="rbtnFSSAI" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="false"  >
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="height: 38px; padding: 5px; margin: 5px"></td>
                                        <td>  </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                             
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                    </tr>
                                  
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left" style="height: 70px;" colspan="10">
                                            <asp:Button ID="BtnSave2" runat="server" CssClass="button" Height="32px" OnClick="BtnSave2_Click1"
                                                TabIndex="10" Text="Show Approvals" ValidationGroup="group" Width="170px" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn-primary" Height="32px" OnClick="BtnSave_Click"
                                                TabIndex="10" Text="Save" ValidationGroup="group" Width="170px" OnClientClick="ConfirmSave()" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="8">
                                            <asp:Label ForeColor="Red" Font-Bold="true" ID="lblNOC" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblNOC0" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="8" align="right">
                                            <asp:Button Text="Previous" BackColor="ForestGreen" ForeColor="White" Height="60px"
                                                Width="200px" BorderStyle="Solid" ID="btntab3privious" runat="server" OnClick="btntab3privious_Click" />&nbsp;&nbsp;&nbsp
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
                        <div class="panel panel-default" id="dvfeedetails" runat="server" visible="false">
                            <div class="panel-heading">
                                Approval Details
                            </div>
                            <div class="panel-body">
                                <table style="width: 100%">
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound"
                                                PageSize="15" ShowFooter="True" Width="100%">
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                            <asp:HiddenField ID="HDFAmountdd" runat="server" />
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
                                                    <asp:TemplateField HeaderText="Fee" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmountnew" runat="server" Text='<%#Eval("Fees") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                    </td>
                </tr>
            </table>
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
    <%--<script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDateofCommenceAct1']").datepicker(
               {
                   dateFormat: "dd-mm-yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateofCommenceAct1']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
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
    </style>--%>
</asp:Content>


