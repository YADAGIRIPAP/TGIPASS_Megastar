<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmLabourCFO.aspx.cs" Inherits="UI_TSiPASS_frmLabourCFO" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .update
        {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
        
        .AjaxCalendar .ajax__calendar_container
        {
            border: 1px solid #646464;
            background-color: yellow;
            color: red;
        }
        
        .AjaxCalendar .ajax__calendar_other .ajax__calendar_day, .AjaxCalendar .ajax__calendar_other .ajax__calendar_year
        {
            color: Black;
        }
        
        .AjaxCalendar .ajax__calendar_hover .ajax__calendar_day, .AjaxCalendar .ajax__calendar_hover .ajax__calendar_month, .AjaxCalendar .ajax__calendar_hover .ajax__calendar_year
        {
            color: White;
        }
        
        .AjaxCalendar .ajax__calendar_active .ajax__calendar_day, .AjaxCalendar .ajax__calendar_active .ajax__calendar_month, .AjaxCalendar .ajax__calendar_active .ajax__calendar_year
        {
            color: Purple;
            font-weight: bold;
        }
    </style>
    <script language="javascript" type="text/javascript">
        var hexvalues
            = Array("A", "B", "C", "D", "E", "F", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9");

        function flashtext() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext").style.color = colour;
        }

        setInterval("flashtext()", 500);
        function flashtext1() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext1").style.color = colour;
        }

        setInterval("flashtext1()", 500);
        function flashtext2() {

            var colour = '#';
            for (var counter = 1; counter <= 6; counter++) {
                var hexvalue = hexvalues[Math.floor(hexvalues.length * Math.random())];

                colour = colour + hexvalue;

            }
            document.getElementById("flashingtext2").style.color = colour;
        }

        setInterval("flashtext2()", 500);


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
        
        .style6
        {
            width: 192px;
        }
        
        .auto-style1
        {
            width: 200px;
        }
        
        .auto-style2
        {
            width: 47px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
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
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">
                <asp:Label ID="lblHead2" runat="server" Text="Labour Details"></asp:Label></a>
            </li>
        </ol>
    </div>
    <div align="center">
        <div align="left" class="row">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div align="center" class="panel-heading">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead1" runat="server" Text="Labour Details"></asp:Label>
                        </h3>
                    </div>
                    <%--      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5">
                            <tr runat="server" visible="false" id="trAct3Registration">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%" id="tddetails" runat="server">
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbl" runat="server" CssClass="LBLBLACK" Width="300px">Select Already Registered Act/Scheme <font color="red">*</font></asp:Label>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlSchemAct3" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" OnSelectedIndexChanged="ddlSchemAct3_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="250px">Registration/License No <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtRegLicAct3" runat="server" class="form-control txtbox" Height="28px"
                                                    ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK">Re- enter Registration/License No <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtReRegLicAct3" runat="server" class="form-control txtbox" Height="28px"
                                                    ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtRegLicAct3"
                                                    ControlToValidate="txtReRegLicAct3" ErrorMessage="Registration/ License Number not matched"
                                                    Display="Dynamic" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr runat="server" visible="false" id="trClassification">
                                            <td style="text-align: left; font-weight: bold" class="auto-style23">
                                                Classification of Establishment <font color="red">*</font>
                                            </td>
                                            <td style="">
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlEstClassification" runat="server" class="form-control txtbox"
                                                    Height="33px" OnSelectedIndexChanged="ddlEstClassification_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlEstClassification"
                                                                    ErrorMessage="Please Select Classification of Establishment" InitialValue="--Select--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trCategory">
                                            <td style="text-align: left; font-weight: bold" class="auto-style23">
                                                <asp:Label ID="lblCategoryofEstab" runat="server" data-balloon-pos="down" data-balloon-length="large"
                                                    CssClass="LBLBLACK">&nbsp; Category of Establishment<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="">
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlCategoryofEstablishment" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="">
                                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlCategoryofEstablishment"
                                                                    ErrorMessage="Please Select Category of Establishment" InitialValue="--Select--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trNameofEstab">
                                            <td style="text-align: left;" class="auto-style23">
                                                Name of Shop/Establishment <font color="red">*</font>
                                            </td>
                                            <td style="">
                                                :
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtNameofShopAct1" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"></asp:TextBox>
                                            </td>
                                            <td>
                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtNameofShopAct1"
                                                                    ErrorMessage="Please Enter Name of the Shop/Establishment" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="tr2">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <%--Name and address of the worksite for contractor lab license--%>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="3">
                                                <asp:Label ID="lblPostalAddress" runat="server" Text="Address of the Shop/Establishment"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            Door No. <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtShopDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtShopDoorNo"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Locality <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtShopLocality" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtShopLocality"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            District <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlShopDistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlShopDistrict_SelectedIndexChanged">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlShopDistrict"
                                                                ErrorMessage="Please Select District of Shop/Establishment" InitialValue="--District--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Mandal <font color="red">*</font>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlShopMandal" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlShopMandal_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlShopMandal"
                                                                ErrorMessage="Please Select Mandal of Shop/Establishment" InitialValue="--Mandal--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            Village <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlShopVillage" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlShopVillage"
                                                                ErrorMessage="Please Slect Village of Shop/Establishment (Village)" InitialValue="--Village--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Pin Code <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtShopPincode" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="6" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtShopPincode"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Pin Code)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trselectZone" visible="false">
                                            <td class="auto-style3">
                                                <table class="auto-style16">
                                                    <tr>
                                                        <td colspan="7" class="auto-style17">
                                                            <strong>
                                                                <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK">&nbsp;3.Please select Zone <font color="red">*</font></asp:Label></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:CheckBox ID="chkZone1" Text="Zone1" runat="server" />
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Adilabad, Karimnagar, Khammam, Warangal
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:CheckBox ID="chkZone2" Text="Zone2" runat="server" />
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Hyderabad
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:CheckBox ID="chkZone3" Text="Zone3" runat="server" />
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Nizambad, Medak, Ranga Reddy, Mahbubnagar, Nalgonda
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="trduration" runat="server" visible="false">
                                            <td colspan="3">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td colspan="4">
                                                            <b>&nbsp;4.Duration of the proposed contract work(give particulars of proposed date
                                                                of commencing and ending) </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style10">
                                                            Commence Date
                                                        </td>
                                                        <td class="auto-style24">
                                                            <asp:TextBox ID="txtStartDate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="auto-style10">
                                                            End Date
                                                        </td>
                                                        <td class="auto-style10">
                                                            <asp:TextBox ID="txtEndDate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tragentormanageraddress" runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="3">
                                                            <asp:Label ID="Label17" runat="server" Text=" 5.Name and address of the Agent or Manager of contractor at the work site"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="tragentormanagerdetails" runat="server" visible="false">
                                                        <td colspan="3">
                                                            <table class="auto-style14">
                                                                <tr>
                                                                    <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                                    </td>
                                                                    <td class="auto-style1" style="text-align: left">
                                                                        Name. <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtagentormanagername" runat="server" class="form-control txtbox"
                                                                            Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                            Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtagentormanagername"
                                                                            ErrorMessage="Please Enter name of agent or manager of contractor at work site"
                                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                        Door No. <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtagentormanagerdoorno" runat="server" class="form-control txtbox"
                                                                            Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                            Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top" class="auto-style15">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtagentormanagerdoorno"
                                                                            ErrorMessage="Please Enter Door No of agent or manager of contractor at work site"
                                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                                    </td>
                                                                    <td class="auto-style1" style="text-align: left">
                                                                        Locality. <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtagentormanagerlocality" runat="server" class="form-control txtbox"
                                                                            Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                            Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtagentormanagerlocality"
                                                                            ErrorMessage="Please Enter locality of agent or manager of contractor at work site"
                                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                        Address <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtagentormanageraddress" runat="server" class="form-control txtbox"
                                                                            Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                            Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top" class="auto-style15">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtagentormanageraddress"
                                                                            ErrorMessage="Please Enter Address of agent or manager of contractor at work site"
                                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                                    </td>
                                                                    <td class="auto-style1" style="text-align: left">
                                                                        District <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlagentormanagerdistrict" runat="server" AutoPostBack="True"
                                                                            class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlagentormanagerdistrict_SelectedIndexChanged">
                                                                            <asp:ListItem>--District--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="ddlagentormanagerdistrict"
                                                                            ErrorMessage="Please Select District of agent or manager of contractor at work site"
                                                                            InitialValue="--District--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                        Mandal <font color="red">*</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlagentormanagermandal" runat="server" AutoPostBack="True"
                                                                            class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlagentormanagermandal_SelectedIndexChanged">
                                                                            <asp:ListItem>--Mandal--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px" class="auto-style15">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="ddlagentormanagermandal"
                                                                            ErrorMessage="Please Select Mandal of agent or manager of contractor at work site"
                                                                            InitialValue="--Mandal--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                                    </td>
                                                                    <td class="auto-style1" style="text-align: left">
                                                                        Village <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlagentormanagervillage" runat="server" class="form-control txtbox"
                                                                            Height="33px" Width="180px">
                                                                            <asp:ListItem>--Village--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="ddlagentormanagervillage"
                                                                            ErrorMessage="Please Slect Village of agent or manager of contractor at work site"
                                                                            InitialValue="--Village--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                        Pin Code <font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtagentormanagerpincode" runat="server" class="form-control txtbox"
                                                                            Height="28px" MaxLength="6" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                            Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top" class="auto-style15">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtagentormanagerpincode"
                                                                            ErrorMessage="Please Enter PINCODE agent or manager of contractor at work site"
                                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="trContractAddressDetails" runat="server" visible="false">
                                            <td colspan="3">
                                                <table class="auto-style9">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="6">
                                                            <asp:Label ID="Label32" runat="server" Text="6.Name and address of the contractor(including his father's name in case of individuals)"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                            &nbsp;
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            Name of the Contractor/Firm <font color="red">*</font>
                                                        </td>
                                                        <td colspan="3" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtNameofContractor" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="70" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="250px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtShopLocality"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            District <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="ddlShopDistrict"
                                                                ErrorMessage="Please Select District of Shop/Establishment" InitialValue="--District--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Mandal <font color="red">*</font>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList8" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="ddlShopMandal"
                                                                ErrorMessage="Please Select Mandal of Shop/Establishment" InitialValue="--Mandal--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            Village <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="DropDownList9" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddlShopVillage"
                                                                ErrorMessage="Please Slect Village of Shop/Establishment (Village)" InitialValue="--Village--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Pin Code <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtContAddPincode" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="6" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtShopPincode"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Pin Code)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td class="auto-style1" style="text-align: left">
                                                            Email id<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtContrEmail" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="ddlShopVillage"
                                                                ErrorMessage="Please Slect Village of Shop/Establishment (Village)" InitialValue="--Village--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Mobile No <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtContrMobile" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtShopPincode"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Pin Code)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtShopDoorNo"
                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Locality <font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtContLocality" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="100" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Note: If you are outside Telangana State, enter the address here (Other State Address)</b>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtContOutsideLoc" TextMode="MultiLine" runat="server" class="form-control txtbox"
                                                                Height="50px" MaxLength="500" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr4">
                                            <td style="padding: 5px; margin: 5px" valign="top" class="auto-style3">
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trGodown1">
                                            <td>
                                                <b>Location of Office, Godown, Warehouse or workplace attached to the shop/establishment
                                                    but situated outside the premisis of it </b>
                                            </td>
                                            <%--<td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>--%>
                                        </tr>
                                        <tr runat="server" id="trGodown2" visible="false">
                                            <td colspan="3" style="text-align: left;">
                                                <asp:GridView ID="gvWorkerDtls" runat="server" AutoGenerateColumns="False" border="3"
                                                    CellPadding="1" CellSpacing="1" OnRowCommand="gvWorkerDtls_RowCommand" OnRowDataBound="gvWorkerDtls_RowDataBound">
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Work Place">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlWorkPlace" runat="server">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Door No.">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtDoorNo" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Locality">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtLocality" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:ButtonField CommandName="Add" Text="Add">
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:ButtonField>
                                                        <asp:ButtonField CommandName="Remove" Text="Delete">
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                                <b>Please click on ADD,before Proceeding</b>
                                            </td>
                                            <td>
                                                <div id="flashingtext" style="font-size: 15px;">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr5">
                                            <td style="padding: 5px; margin: 5px" valign="top" class="auto-style3">
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trEmployerDetails1">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold"
                                                class="auto-style4">
                                                <asp:Label ID="lblEmployer" runat="server" Text="Employer, Managing Partner or Managing Director as the case may be (Name, Father Name, Designation, Age, Mobile, e-Mail)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trEmployerDetails2">
                                            <td colspan="4">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Name <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="TxtnameofUnitAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TxtnameofUnitAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Name)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Father's Name <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtPGNameAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtPGNameAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Father's Name)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Designation <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDesigAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDesigAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Designation)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Age <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtAgeAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAgeAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Age)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Mobile <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtMobileAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtMobileAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Mobile)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Email <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtEmailAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtEmailAct1"
                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Email)"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trEmployerAddress1">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                <asp:Label ID="lblEmployerAddress" runat="server" Text="Residential address of the employer"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trEmployerAddress2">
                                            <td colspan="3">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Door No.<font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                            <asp:TextBox ID="txtDoorNoResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtDoorNoResidentialAct1"
                                                                ErrorMessage="Please Enter  Residential address of the employer (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Locality <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtLocalResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtLocalResidentialAct1"
                                                                ErrorMessage="Please Enter  Residential address of the employer (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            District <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                            <asp:DropDownList ID="ddlDistrictResidentialAct1" runat="server" AutoPostBack="True"
                                                                class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlDistrictResidentialAct1_SelectedIndexChanged"
                                                                Width="180px">
                                                                <%--<asp:ListItem>--District--</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDistrictResidentialAct1"
                                                                ErrorMessage="Please Select District of Employer" InitialValue="--District--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Mandal <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlMandalResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlMandalResidentialAct1_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMandalResidentialAct1"
                                                                ErrorMessage="Please Select Mandal of Employer" InitialValue="--Mandal--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Village <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                            <asp:DropDownList ID="ddlVillageResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlVillageResidentialAct1"
                                                                ErrorMessage="Please Select Residential Village of the Employer (Village)" InitialValue="--Village--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trdobnumdatedetails">
                                            <td colspan="3">
                                                <table>
                                                    <tr runat="server" visible="false" id="trDOB">
                                                        <td class="auto-style25">
                                                            <b>7.Date of birth in case of individuals</b> <font color="red" size="3">*</font>
                                                        </td>
                                                        <td class="auto-style8">
                                                            <asp:TextBox ID="txtDOB" runat="server" class="form-control txtbox" Height="28px"
                                                                AutoPostBack="true" OnTextChanged="txtDOB_TextChanged" MaxLength="50" TabIndex="0"
                                                                ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="auto-style11">
                                                            <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="ddlVillageResidentialAct1"
                                                                ErrorMessage="Please Select Date of Birth" InitialValue="--Village--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="text-align: center" class="auto-style22">
                                                            <asp:Label ID="lblage" runat="server">Age</asp:Label>
                                                        </td>
                                                        <td class="auto-style13">
                                                            <asp:TextBox ID="txtage" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="178px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="trParticularofEst" runat="server" visible="false">
                                                        <td colspan="4">
                                                            <b>8.Particulars of Establishment where Contract Labour is to be employed</b>
                                                        </td>
                                                    </tr>
                                                    <tr id="trnoanddate" runat="server" visible="false">
                                                        <td colspan="4">
                                                            <b>&nbsp;&nbsp;&nbsp;Number and date of certificate of registration of the establishment
                                                                underthe act(of Principal Employer)</b>
                                                        </td>
                                                    </tr>
                                                    <tr id="trNumberdateEst" runat="server" visible="false">
                                                        <td class="auto-style25" style="text-align: justify; text-align: left">
                                                            <b>&nbsp;&nbsp; Number </b>
                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:TextBox ID="txtPartEstablNumber" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td style="text-align: center" valign="middle">
                                                            <b>Date</b>
                                                        </td>
                                                        <td class="auto-style13" style="text-align: center" valign="top">
                                                            <asp:TextBox ID="txtPartEstablDate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tr">
                                            <td colspan="4">
                                                <table class="auto-style27">
                                                    <tr id="trMaxnoEmployee" runat="server" style="height: 40px">
                                                        <td class="auto-style5" style="height: 40px">
                                                            <b>
                                                                <asp:Label ID="lblEmployerAddress0" runat="server" Text="9.Maximum No. of contract labour proposed to be employed in the establishment on any date"></asp:Label>
                                                            </b>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMaxoEmployees" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="10" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <tr runat="server" visible="false" id="trWhetherContract">
                                                                <td colspan="4">
                                                                    <table class="auto-style14">
                                                                        <tr>
                                                                            <td colspan="2" style="text-align: left;">
                                                                                <b>10.Whether the contractor was convicted of any offence within the preceding five
                                                                                    years. If&nbsp;&nbsp;
                                                                                    <br />
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; so&nbsp;&nbsp; give details </b>
                                                                            </td>
                                                                            <td colspan="3" style="text-align: left;" class="auto-style1">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td style="text-align: left;">
                                                                                <asp:RadioButtonList ID="rblcontractConvict" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                                                    Width="100px" OnSelectedIndexChanged="Rd_ManagerResidenceAct1_SelectedIndexChanged">
                                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="text-align: left;" class="auto-style6">
                                                                                <b>11.Whether there was any order against the contractor revoking or suspending license
                                                                                    or
                                                                                    <br />
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; forefeiting security deposits in respect of an earlier
                                                                                    contract . If so the date of such order</b>
                                                                            </td>
                                                                            <td colspan="3" style="text-align: left;" class="auto-style7">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td style="text-align: left;" class="auto-style6">
                                                                                <asp:RadioButtonList ID="rblcontractSuspend" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                                                    Width="100px" OnSelectedIndexChanged="Rd_ManagerResidenceAct1_SelectedIndexChanged">
                                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top" class="auto-style6">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="text-align: left;" class="auto-style6">
                                                                                <b>12.Whether the contractor has worked in any other establishment within the past five
                                                                                    years, If
                                                                                    <br />
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; so, give details of the Principal Emplyer,Establishments
                                                                                    and nature of work</b>
                                                                            </td>
                                                                            <td colspan="3" style="text-align: left;" class="auto-style7">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td style="text-align: left;" class="auto-style6">
                                                                                <asp:RadioButtonList ID="rblcontractEst" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                                                    Width="100px" OnSelectedIndexChanged="Rd_ManagerResidenceAct1_SelectedIndexChanged">
                                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top" class="auto-style6">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>13.Whether a certificate by the Principal Employer in Form V is enclosed </b>
                                                                            </td>
                                                                            <td class="auto-style26">
                                                                            </td>
                                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:FileUpload ID="fuFormvPrinEmp" runat="server" class="form-control txtbox" Height="48px" />
                                                                                <asp:HyperLink ID="hplFormvPrinEmp" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                                                    Width="165px">hplFormvPrinEmp</asp:HyperLink>
                                                                                <br />
                                                                                <asp:Label ID="lblFormvPrinEmp" runat="server" Visible="False"></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                                <asp:Button ID="btnPrinformV" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btnPrinformV_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--        <tr runat="server" id="trWorksite" visible="false">
                                            <td class="auto-style3">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td colspan="7">
                                                            <strong>
                                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK">Name and address of the worksite
                                                                <font color="red">*</font></asp:Label></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="110px"> Full Name
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="TextBox1" runat="server" class="form-control txtbox"
                                                                Height="28px" ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="110px"> District
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictPermAct2_SelectedIndexChanged">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="110px"> Mandal
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="DropDownList2" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlMandalPermAct2_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="110px"> Village
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="DropDownList3" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="110px"> Door No
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="TextBox2" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="110px"> Pin Code
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="TextBox3" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="6" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="110px"> Locality
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtworksiteLocality" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                           
                                                        </td>
                                                        
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                             
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>--%>
                                        <tr runat="server" visible="false" id="trDetailofPrinEmploy">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                <asp:Label ID="Label31" runat="server" Text="14.Details of the Principal Employer"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trDetailofPrinEmploy1">
                                            <td colspan="3">
                                                <table class="auto-style14">
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Name of Principal Employer<font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtNamePrinEmploy" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDoorNoResidentialAct1"
                                                                ErrorMessage="Please Enter  Residential address of the employer (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                            Door No & Locality <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDoornoPrinEmploy" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLocalResidentialAct1"
                                                                ErrorMessage="Please Enter  Residential address of the employer (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            District <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDistPrinEmploy" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlDistPrinEmploy_SelectedIndexChanged">
                                                                <%--<asp:ListItem>--District--</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlDistrictResidentialAct1"
                                                                ErrorMessage="Please Select District of Employer" InitialValue="--District--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Mandal <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlMandalPrinEmploy" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlMandalPrinEmploy_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlMandalResidentialAct1"
                                                                ErrorMessage="Please Select Mandal of Employer" InitialValue="--Mandal--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Village <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlVillagePrinEmploy" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlVillageResidentialAct1"
                                                                ErrorMessage="Please Select Residential Village of the Employer (Village)" InitialValue="--Village--"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Pin Code <font color="red" size="3">*</font>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPrinEmployPincode" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <font color="red"><b>Note:If you are outside Telangana State, enter the address here</b></font>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            Other State Address
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtOtherStateAddrPrinEmploy" runat="server" TextMode="MultiLine"
                                                                class="form-control txtbox" Height="40px" MaxLength="50" TabIndex="0" ToolTip="text"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trPermanentAddressofEstab" visible="false">
                                            <td class="auto-style3">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td colspan="7">
                                                            <strong>
                                                                <asp:Label ID="lblPermanentAddress" runat="server" CssClass="LBLBLACK">Full name and Permanent Address of the establishment, if any <font color="red">*</font></asp:Label></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="110px"> Full Name <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtFullNamePermAct2" runat="server" class="form-control txtbox"
                                                                Height="28px" ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="110px"> District <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDistrictPermAct2" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictPermAct2_SelectedIndexChanged">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="110px"> Mandal <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlMandalPermAct2" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlMandalPermAct2_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="110px"> Village <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlVillagePermAct2" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="110px"> Door No <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDoorNoPermAct2" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="110px"> Pin Code <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtPinCodePermAct2" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="6" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr8">
                                            <td style="padding: 5px; margin: 5px" valign="top" class="auto-style3">
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trDirectorAddress">
                                            <td class="auto-style3">
                                                <table style="width: 89%">
                                                    <tr>
                                                        <td colspan="7">
                                                            <strong>
                                                                <asp:Label ID="lblDirector" runat="server" CssClass="LBLBLACK">Name and address of the Director / Partners (in case of companies/firm)</asp:Label></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="110px"> Full Name <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDirFullName" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="110px"> Door No <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDirDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                                ToolTip="text" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="110px"> District <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDirDistrict" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlDirDistrict_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="110px"> Mandal <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDirMandal" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px" OnSelectedIndexChanged="ddlDirMandal_SelectedIndexChanged" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="110px"> Village/Town <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDirVillage" runat="server" class="form-control txtbox" Height="33px"
                                                                Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            :
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr9">
                                            <td style="padding: 5px; margin: 5px" valign="top" class="auto-style3">
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trManagerorNot">
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                <asp:Label ID="lblManagerOrNot" runat="server" CssClass="LBLBLACK">15.Manager/Agent if any (with residential address): <font color="red">*</font></asp:Label>
                                                <asp:RadioButtonList ID="Rd_ManagerResidenceAct1" runat="server" AutoPostBack="true"
                                                    RepeatDirection="Horizontal" Width="100px" OnSelectedIndexChanged="Rd_ManagerResidenceAct1_SelectedIndexChanged">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr id="trManagerResidenceAct1" runat="server" visible="false">
                                            <td class="auto-style3">
                                                <table cellpadding="4" cellspacing="5" style="width: 89%">
                                                    <tr>
                                                        <td colspan="5">
                                                            <asp:Label ID="lblManagerAddress" runat="server" Text="Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment"
                                                                Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Name <font color="red" size="3">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerNameAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Father&#39;s Name <span class="reqFields" style="display: inline;"><font color="red"
                                                                size="3">*</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerPGNameAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Designation <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerDesignationAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Door No <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerDoorNoAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Locality <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerLocalityAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            District <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlManagerDistrictAct1" runat="server" AutoPostBack="true"
                                                                class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlManagerDistrictAct1_SelectedIndexChanged">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlManagerDistrictAct1"
                                                                                ErrorMessage="Please Select District of Manager/Agent" InitialValue="--District--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Mandal <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font>
                                                            </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlManagerMandalAct1" runat="server" AutoPostBack="true" class="form-control txtbox"
                                                                Height="33px" Width="180px" OnSelectedIndexChanged="ddlManagerMandalAct1_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Village <span class="reqFields" style="display: inline;"><font color="red" size="3">
                                                                *</font> </span>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlManagerVillageAct1" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style2" style="padding: 3px; margin: 3px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="110px">Mobile No <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtMobileNoManagerAct2" runat="server" class="form-control txtbox"
                                                                Height="28px" ToolTip="text" MaxLength="10" onkeypress="NumberOnly()" TabIndex="0"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="110px">Email Id <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmailManagerAct2" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="trDeposit" runat="server" visible="false">
                                            <td>
                                                <table cellpadding="4" cellspacing="5" style="width: 100%; margin-top: 10px; margin-bottom: 10px">
                                                    <tr>
                                                        <td colspan="7">
                                                            <asp:Label ID="lblHDeposit" runat="server" Style="font-weight: bold; margin-right: 8px"
                                                                Text="17. Security Deposit Details"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 160px">
                                                            Amount paid (Rs) <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtAmountPaid" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="220px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtAmountPaid"
                                                                Display="None" ErrorMessage="Please Enter Security Deposit Amount paid" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Amount payable (Rs) <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtAmountPayable" runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="0" Width="220px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtAmountPayable"
                                                                Display="None" ErrorMessage="Please Enter Security Deposit Amount Payable" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Challan No. <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtChallanNo" runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="0" ToolTip="text" Width="220px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtChallanNo"
                                                                Display="None" ErrorMessage="Please Enter Security Deposit Challan No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Attach Challan <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <div style="float: left">
                                                                <asp:FileUpload ID="fucAttachChallan" runat="server" Width="220px" Height="28px" />
                                                                <asp:Label ID="lblAttachChallan" ForeColor="Blue" runat="server"></asp:Label>
                                                                <%--<asp:HyperLink ID="lnkEmpFrmV" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>--%>
                                                                <%--<asp:CustomValidator ValidateEmptyText="true" ControlToValidate="txtEmpFrmV"  ClientValidationFunction="Check(txtEmpFrmV)" Display="None" ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" ValidationGroup="group"></asp:CustomValidator>--%>
                                                            </div>
                                                            <div style="float: left">
                                                                <asp:Button ID="btnAttachChallan" runat="server" CssClass="btn btn-xs btn-warning"
                                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnAttachChallan_Click" />
                                                            </div>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 3px; margin: 3px; text-align: left;">
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            Challan Date. <font color="red" size="3"><font color="red">*</font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtchallandate" runat="server" class="form-control txtbox" Height="28px"
                                                                TabIndex="0" ToolTip="text" Width="220px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtchallandate"
                                                                Display="None" ErrorMessage="Please select challan date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <font color="red" size="3"><font color="red"></font></font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="tr3">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 89%">
                                        <tr>
                                            <td>
                                                <table cellpadding="4" cellspacing="5" style="width: 89%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="lblNatureofBusiness" runat="server" Text="Nature of business *" Font-Bold="true"
                                                                Width="600px"></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtNatureofBusinessAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="1000" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNatureofBusinessAct1"
                                                                ErrorMessage="Please Enter Nature of business " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="trDateofCommencement" runat="server" visible="false">
                                                        <td>
                                                            <asp:Label ID="lblDateofCommencement" runat="server" Text="Date of Commencement of business *"
                                                                Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDateofCommenceAct1" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateofCommenceAct1">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="tr10">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr runat="server" id="tr11">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr id="trFamilyMembers1" runat="server" visible="false">
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">
                                                <asp:Label ID="lblFamily" runat="server" Text="Name of family members of employees family engaged in Shop / Establishment"
                                                    Font-Bold="true"></asp:Label>
                                            </td>
                                            <%--   <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td></td>--%>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server" id="tr12">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                            </tr>
                            <tr id="trFamilyMembers2" runat="server" visible="false">
                                <td colspan="3">
                                    <table>
                                        <tr>
                                            <td colspan="3" style="text-align: left">
                                                <asp:GridView ID="gvFamilyMembersAct1" runat="server" AutoGenerateColumns="False"
                                                    border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvFamilyMembersAct1_RowCommand"
                                                    OnRowDataBound="gvFamilyMembersAct1_RowDataBound">
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtFamilyNameAct1" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Relationship">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlRelationshipAct1" runat="server">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Gender">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFamilyGenderAct1" runat="server">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Adult/Young Person">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFamilyAdultAct1" runat="server">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <%-- <asp:ListItem Value="1">Adult</asp:ListItem>
                                                                                      <asp:ListItem Value="2">Young Person</asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:TemplateField>
                                                        <asp:ButtonField CommandName="Add" Text="Add">
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:ButtonField>
                                                        <asp:ButtonField CommandName="Remove" Text="Delete">
                                                            <ItemStyle CssClass="scroll_td" />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>
                                            <td>
                                                <div id="flashingtext1" style="font-size: 15px;">
                                                    <b>Please click on ADD,before Proceeding</b>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%-- <tr>
                                                <td colspan="3" style="height: 35px;"></td>
                                            </tr>--%>
                            <tr runat="server" id="tr13">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                </td>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style19">
                                </td>
                            </tr>
                            <tr id="trTotalEmps" runat="server" visible="false">
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 84%">
                                        <tr>
                                            <td style="font-weight: bold">
                                                <asp:Label ID="lblTotalEmps" runat="server" Width="500px" Text="Total No. of Employees *:"></asp:Label>
                                            </td>
                                            <td style="height: 35px; text-align: left">
                                                <asp:TextBox ID="txtTotalEmployees" runat="server" class="form-control txtbox" Enabled="false"
                                                    MaxLength="6" onkeypress="NumberOnly()" Width="50px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trAgewiseEmployees" runat="server" visible="false">
                                <td colspan="3">
                                    <asp:Table ID="tblNoofEmployees" runat="server" CellPadding="1" CellSpacing="1" Font-Size="Medium"
                                        GridLines="Both" Width="400">
                                        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" Style="color: White; background-color: #013161;
                                            font-weight: bold;">
                                            <asp:TableHeaderCell Width="50px"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="150px">Adults (18 years and above)</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="170px">Young Persons (From 14 years to Below 18 years)</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                            <asp:TableCell>MALE</asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Male" Width="40px"
                                                    OnTextChanged="txtAbove18Male_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell Height="29px">
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18Male" Width="40px"
                                                    OnTextChanged="txtBelow18Male_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                            <asp:TableCell Height="29px">FEMALE</asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Female" Width="40px"
                                                    OnTextChanged="txtAbove18Female_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18FeMale" Width="40px"
                                                    OnTextChanged="txtBelow18FeMale_TextChanged" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableFooterRow ID="TableFooterRow1" runat="server" HorizontalAlign="Center"
                                            Style="background-color: #EBF2FE;">
                                            <asp:TableCell Height="29px">Total</asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" ID="txtTotalAbove18" Width="40px" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox runat="server" ID="txtTotalBelow18" Width="40px" Enabled="false"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableFooterRow>
                                    </asp:Table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 20px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="trNamesofEmployees1" runat="server" visible="false">
                                <td colspan="3" style="font-weight: bold">
                                    <asp:Label ID="lblEmployeeNames" runat="server" Text="Name of Employees (Optional):"
                                        Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trNamesofEmployees2" runat="server" visible="false">
                                <td colspan="3" style="text-align: left">
                                    <asp:GridView ID="gvEmployeeNames" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowCommand="gvEmployeeNames_RowCommand" OnRowDataBound="gvEmployeeNames_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Occupation">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlOccupationAct1" runat="server">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtEmployeeNameAct1" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gender">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlEmployeeGenderAct1" runat="server">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:ButtonField CommandName="Add" Text="Add">
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="Remove" Text="Delete">
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#B9D684" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <div id="flashingtext2" style="font-size: 15px;">
                                        <b>Please click on ADD,before Proceeding</b>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                                <tr id="trCompletionDate" runat="server" visible="false">
                                    <td>
                                        <table cellpadding="4" cellspacing="5" style="width: 50%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCompletionDate" runat="server" CssClass="LBLBLACK" Font-Bold="true"
                                                        Width="600px">Estimated date of completion of building or other construction work <font color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtEstDateCompAct2" runat="server" class="form-control txtbox" Height="28px"
                                                        MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEstDateCompAct2"
                                                        Display="None" ErrorMessage="Please give particulars of proposed date of commencing and ending"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                TargetControlID="txtEstDateCompAct2" PopupButtonID="txtEstDateCompAct2" Format="yyyy-MM-dd">
                                                            </cc1:CalendarExtender>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <%--  <tr runat="server" visible="false" id="trContractorDetailsAct3">
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td style="width: 5px"></td>
                                                            <td colspan="6">
                                                                <strong>6. Particulars of Contractors and Contract Labours</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:GridView ID="gvContractorAct3" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvContractorAct3_RowCommand" OnRowDataBound="gvContractorAct3_RowDataBound">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Name of the Contractor">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorNameAct4" runat="server" Width="150px" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Address">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorAddressAct4" TextMode="MultiLine" runat="server" Width="150px" Height="50px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Nature of Work">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorNatureAct4" runat="server" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Details of Manufacturing Depts">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtManufacturingDepts" runat="server" Width="35" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estimated Date of Commencement">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorCommenceAct4" runat="server" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Maximum No.of Contract Labour">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtMaxNoofContractLabour" runat="server" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estimated Date of Termination">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorCompAct4" runat="server" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:ButtonField CommandName="Add" Text="Add">
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:ButtonField>
                                                                        <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:ButtonField>
                                                                    </Columns>
                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                <tr id="trContractorDetailsAct4" runat="server" visible="false">
                                    <td>
                                        <table>
                                            <tr>
                                                <td colspan="6">
                                                    <strong>
                                                        <asp:Label ID="lblContractor" runat="server" CssClass="LBLBLACK" Font-Bold="true">Particulars of Contractors or migrant workmen</asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <asp:GridView ID="gvContractorAct4" runat="server" AutoGenerateColumns="False" border="3"
                                                        CellPadding="1" CellSpacing="1" OnRowCommand="gvContractorAct4_RowCommand" OnRowDataBound="gvContractorAct4_RowDataBound">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name of the Contractor">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorNameAct4" runat="server" Height="25px" Width="150px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Address">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorAddressAct4" runat="server" Height="50px" TextMode="MultiLine"
                                                                        Width="150px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mobile No.">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorMobileNoAct4" runat="server" Height="25px" MaxLength="10"
                                                                        onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nature of Work">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorNatureAct4" runat="server" Height="25px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Maximum No. of Migrant Workmen">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorMaximumNoAct4" runat="server" AutoPostBack="true" Height="25px"
                                                                        onkeypress="return inputOnlyNumbers(event)" OnTextChanged="GetTotalWorkMan" Width="35"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Estimated Date of Commencement">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorCommenceAct4" runat="server" Height="25px"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtContractorCommenceAct4">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Estimated Date of Completion">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtContractorCompAct4" runat="server" Height="25px"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="yyyy-MM-dd" TargetControlID="txtContractorCompAct4">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Details of Manufacturing Depts">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtManufacturingDepts" runat="server" Height="25px" TextMode="MultiLine"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:ButtonField CommandName="Add" Text="Add">
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:ButtonField>
                                                            <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:ButtonField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White"
                                                            HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="trTotalContractors" runat="server" visible="false">
                                    <%--  <td style="width:5px" ></td>--%>
                                    <td>
                                        <table style="width: 50%">
                                            <tr>
                                                <td>
                                                    <strong>Total No.of Contract Employees * :</strong>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtTotalContractors" runat="server" class="form-control txtbox"
                                                        Enabled="false" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group"
                                                        Width="54px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server" id="trattachment" visible="false">
                                    <td>
                                        <strong>Upload Attachments:</strong>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="trteluguboard" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    1
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="210px">Telugu Board Upload<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileTeluguBoard" runat="server" class="form-control txtbox" Height="48px" />
                                                    <asp:HyperLink ID="lblTeluguBoard" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblTeluguBoard]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="LabelTeluguBoard" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="BtnTeluguBoard" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" OnClick="BtnTeluguBoard_Click" TabIndex="10" Text="Upload" Width="72px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="tridproof" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    2
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="210px">ID Proof of Employer<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadidproof" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkidproof" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblidproof]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Labelidproof" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnidproof" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="btnidproof_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="trphoto" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    3
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="210px">Passport Size of Employee<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadphoto" runat="server" class="form-control txtbox" Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkphoto" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblphoto]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Labelphoto" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnphoto" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="btnphoto_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="trrenetaldeed" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    4
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="210px">Rental Deed/Sale Deed/Ownership Proof<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadrenetaldeed" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkrenetaldeed" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblrenetaldeed]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Labelrenetaldeed" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnrenetaldeed" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnrenetaldeed_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 50%">
                                            <tr id="trMemorandum" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    5
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">Memorandum of Articles(Companies)<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadMemorandum" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkMemorandum" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblMemorandum]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="LabelMemorandum" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnMemorandum" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" OnClick="btnMemorandum_Click" />
                                                </td>
                                            </tr>
                                            <tr id="trincorportaion" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    6
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="210px">Certification of Incorporation(Companies)<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    :
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="FileUploadincorportaion" runat="server" class="form-control txtbox"
                                                        Height="28px" />
                                                    <asp:HyperLink ID="HyperLinkincorportaion" runat="server" CssClass="LBLBLACK" Target="_blank"
                                                        Width="165px">[lblincorportaion]</asp:HyperLink>
                                                    <br />
                                                    <asp:Label ID="Labelincorportaion" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                    <asp:Button ID="btnincorportaion" runat="server" CssClass="btn btn-xs btn-warning"
                                                        Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnincorportaion_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" valign="top">
                                        &nbsp;
                                    </td>
                                    <td class="auto-style21">
                                        &nbsp;
                                    </td>
                                    <td valign="top" class="auto-style21">
                                        &nbsp;
                                    </td>
                                </tr>
                                <caption>
                                    &nbsp;</caption>
                                <tr id="trsubmitactual" runat="server">
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                            OnClick="BtnSave1_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                        &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                            OnClick="btnNext_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />
                                        <asp:Button ID="btnNext0" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                            Height="32px" OnClick="btnNext0_Click" TabIndex="10" Text="Previous" Width="90px" />
                                        &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                            Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                            ValidationGroup="group" Width="90px" />
                                    </td>
                                </tr>
                                <tr id="trsubmitqury" runat="server" visible="false">
                                    <td align="center" colspan="3">
                                        <asp:Button ID="btnsubmitform" runat="server" CssClass="btn btn-primary" Height="32px"
                                            OnClick="btnsubmitform_Click" TabIndex="10" Text="Save" ValidationGroup="group"
                                            Width="90px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" class="alert alert-success" visible="false">
                                            <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                                ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                        <br />
                        <asp:HiddenField ID="hdfpencode" runat="server" />
                    </div>
                    <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upd1">
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
    <%-- </ContentTemplate>
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

            $("input[id$='txtEstDateCompAct2']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtStartDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtEndDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDOB']").datepicker(
                {
                    dateFormat: "yy/mm/dd",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtPartEstablDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
//            $("input[id$='txtMaxoEmployees']").datepicker(
//                {
//                    dateFormat: "dd/mm/yy",
//                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
//                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtchallandate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtEstDateCompAct2']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtStartDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtEndDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDOB']").datepicker(
                {
                    dateFormat: "yy/mm/dd",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtPartEstablDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
//            $("input[id$='txtMaxoEmployees']").datepicker(
//                {
//                    dateFormat: "dd/mm/yy",
//                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
//                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtchallandate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
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
        
        .auto-style3
        {
            width: 725px;
        }
        
        .auto-style4
        {
            height: 35px;
        }
        
        .auto-style5
        {
            width: 724px;
        }
        
        .auto-style6
        {
            height: 60px;
        }
        
        .auto-style7
        {
            width: 200px;
            height: 60px;
        }
        
        .auto-style8
        {
            width: 189px;
        }
        
        .auto-style9
        {
            width: 89%;
        }
        
        .auto-style10
        {
            height: 38px;
        }
        
        .auto-style11
        {
            width: 103px;
        }
        
        .auto-style13
        {
            width: 174px;
        }
        
        .auto-style14
        {
            width: 99%;
        }
        
        .auto-style15
        {
            width: 1px;
        }
        
        .auto-style16
        {
            width: 130%;
        }
        
        .auto-style17
        {
            height: 31px;
        }
        .auto-style19
        {
            width: 10px;
        }
        .auto-style20
        {
            width: 1097px;
        }
        .auto-style21
        {
            width: 20px;
        }
        .auto-style22
        {
            width: 144px;
        }
        .auto-style23
        {
            width: 361px;
        }
        .auto-style24
        {
            width: 193px;
        }
        .auto-style25
        {
            width: 287px;
        }
        .auto-style26
        {
            width: 207px;
        }
        .auto-style27
        {
            width: 98%;
        }
    </style>
</asp:Content>
