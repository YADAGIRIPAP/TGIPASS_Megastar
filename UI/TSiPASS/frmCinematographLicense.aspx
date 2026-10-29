<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    CodeFile="frmCinematographLicense.aspx.cs" Inherits="UI_TSiPASS_frmCinematographLicense" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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

            $("input[id$='txtreferancedate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txtlongevitydate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  minDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
            $("input[id$='txtelectricalcertificatevaliddate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               });
            $("input[id$='txtfirenocvaliddate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               });
            $("input[id$='txtrentorleaseperiodto']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtreferancedate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)

                });

            $("input[id$='txtlongevitydate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtelectricalcertificatevaliddate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtfirenocvaliddate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtrentorleaseperiodto']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
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
        
        .style6
        {
            width: 192px;
        }
        
        .style7
        {
            color: #FF3300;
        }
        
        .LBLBLACK
        {
        }
    </style>
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
        .style5
        {
            width: 13px;
        }
        .style6
        {
            width: 203px;
        }
        .auto-style6
        {
            width: 858px;
        }
        .auto-style7
        {
            height: 57px;
        }
        .auto-style8
        {
            width: 192px;
            height: 57px;
        }
        .auto-style9
        {
            width: 10px;
            height: 57px;
        }
        .auto-style10
        {
            height: 57px;
            width: 74px;
        }
        .auto-style11
        {
            width: 74px;
        }
    </style>
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate < new Date()) {
                alert("You cannot select a day olderr than today!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }

        }
    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtbuildingpermissiondate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txtoccupancycertificatedate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  minDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
            $("input[id$='txtrentorleasedeeddate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               });
            $("input[id$='txtrentorleaseperiodfrom']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               });
            $("input[id$='txtrentorleaseperiodto']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtfromdate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)

                });

            $("input[id$='txtbuildingpermissiondate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtoccupancycertificatedate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtrentorleaseperiodfrom']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtrentorleaseperiodto']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
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
    <script type="text/javascript" language="javascript">
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
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
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
    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Cinematograph License & License
                for Screening a Film</a> </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel-heading" align="center" style="background-color: forestgreen">
                    <h3 class="panel-title" style="color: white">
                        Cinematograph License & License for Screening a Film</h3>
                </div>
                <div class="panel panel-primary" id="divCDMA" runat="server">
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style6">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" Width="259px">Full Name of the Applicant
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtapplicantfllname" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" Width="259px">District
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddldist_applicant" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddldist_applicant_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" Width="259px">Mandal
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlmandal_applicant" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_applicant_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" Width="259px">Village
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlvillage_applicant" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" Width="259px">Plot Number
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtplotnumber_applicant" runat="server" class="form-control txtbox"
                                                    onkeypress="DecimalOnly()" Height="28px" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server" Width="259px">Pincode
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtpincode_applicant" runat="server" class="form-control txtbox"
                                                    onkeypress="DecimalOnly()" Height="28px" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style10">
                                                7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style7">
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px">Status and previous experience of the Applicant
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style7">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                <asp:DropDownList ID="ddlexpyear" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style9">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                8.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label21" runat="server" Width="259px">9B File Number  of the building granted
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txt9Bfileno" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                9.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label4" runat="server" Width="249px">Date of the Reference in which permission for construction of the building granted<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtreferancedate" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" Width="246px">The period for which the license has to be granted
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddllicenseperiod" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>--%>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                10.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" Width="252px">The Date upto which the certificate of longevity of the building issued by the executive engineer (R&B) is valid 
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtlongevitydate" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                11.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" Width="252px">
                                                     The date upto which the Electrical certificate in form -D is Valid
                                                  <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtelectricalcertificatevaliddate" runat="server" class="form-control txtbox"
                                                    onkeypress="DecimalOnly()" Height="28px" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                12.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" Width="252px">
                                                     The date upto which the NOC of Fire Department is Valid
                                                  <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtfirenocvaliddate" runat="server" class="form-control txtbox"
                                                    onkeypress="DecimalOnly()" Height="28px" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                13.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label20" runat="server" Width="252px">
                                                     The period for which the license has to be granted

                                                  <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddllicenseperiod" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                14.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server" Width="243px">
                                                    Type of Cinema Theatre
                                                    <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RadioButtonList ID="rbttheatretype" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                    Width="190px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Single Screen theater</asp:ListItem>
                                                    <asp:ListItem Value="N">Multiplex</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                15.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label17" runat="server" Width="259px">Number of Screens in multiplex
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtnoofscreens" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="true"
                                                    OnTextChanged="txtnoofscreens_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trmaingrid" runat="server">
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td class="auto-style12">
                                                <asp:GridView ID="grd_dynamic" runat="server" AutoGenerateColumns="false" border="3"
                                                    CellPadding="1" CellSpacing="1" Width="100%">
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Screen
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <b>Screen -
                                                                    <%# Container.DataItemIndex+1 %></b>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Seat Capcity
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txt_seatcapcity" CssClass="form-control" placeholder="Seat Capacity"
                                                                    AutoPostBack="true" OnTextChanged="txt_seatcapcity_TextChanged" runat="server"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_seatcapcity"
                                                                    ValidationExpression="^\d+" Display="Dynamic" ErrorMessage="Only Numbers" ForeColor="Red"
                                                                    runat="server"></asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txt_seatcapcity"
                                                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Fee
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txt_screenfee" Enabled="false" CssClass="form-control" placeholder="Fee"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_screenfee"
                                                                    ValidationExpression="^\d+" Display="Dynamic" ErrorMessage="Only Numbers" ForeColor="Red"
                                                                    runat="server"></asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txt_screenfee"
                                                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Total Fee
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txt_totscreenfee" Enabled="false" CssClass="form-control" placeholder="Total screen Fee"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_totscreenfee"
                                                                    ValidationExpression="^\d+" Display="Dynamic" ErrorMessage="Only Numbers" ForeColor="Red"
                                                                    runat="server"></asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txt_totscreenfee"
                                                                    ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                        <tr id="trtotalfee" runat="server" visible="false">
                                            <td style="padding: 15px; margin: 5px; font-weight: bold;" class="auto-style1">
                                                15a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px" valign="middle">
                                                Approval Fee(Cinematographic License)
                                            </td>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                &nbsp;
                                            </td>
                                            <td colspan="6" style="padding: 5px; margin: 5px" valign="top">
                                                <asp:TextBox ID="txtapprovalfeecinemalicense" runat="server" Enabled="false" Height="30px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="trnoofshods" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                16.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label9" runat="server" Width="256px">
                                                    Number of Shows proposed to be screened for single screen/Multiplex
                                                    <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlnoofshows" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">01</asp:ListItem>
                                                    <asp:ListItem Value="2">02</asp:ListItem>
                                                    <asp:ListItem Value="3">03</asp:ListItem>
                                                    <asp:ListItem Value="4">04</asp:ListItem>
                                                    <asp:ListItem Value="5">05</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                17.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label33" runat="server" Width="295px">
                                                    If the Licensee is not the owner of the Place or Building, the name and address of the owner

                                                    <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtlicense" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                    Width="190px" TabIndex="1">
                                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                18.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label31" runat="server" Width="259px">Name of the Owner
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtownername" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                19.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server" Width="259px">District
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddldistrict_owner" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_owner_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                20.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label23" runat="server" Width="259px">Mandal
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlmandal_owner" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_owner_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                22.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label25" runat="server" Width="259px">Village
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlvillage_owner" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                23.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label27" runat="server" Width="259px">Plot Number
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtplotno_owner" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                24.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label29" runat="server" Width="259px">Pincode
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtpincode_owner" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trcommissionerate" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                25.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="200px">Commissionerate<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlcommissionerate" runat="server" class="form-control txtbox"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlcommissionerate_SelectedIndexChanged"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trzone" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                26.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="200px">Zone<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlzone" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlzone_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="troccupancycertificatedatedivision" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                27.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="200px">Division<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddldivision" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                28.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="200px">
                                                    Police Station
                                                    <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlpolicestation" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trpolicestation" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                29.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label38" runat="server" CssClass="LBLBLACK" Width="200px">Traffic Zone<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddltrafficzone" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddltrafficzone_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr11" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                30.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="200px">Traffic Division<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddltrafficdivision" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddltrafficdivision_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr12" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                31.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="200px">Traffic Police Station<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddltrafficpolicestation" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr2" runat="server">
                                <td style="padding: 5px; margin: 5px" colspan="1" align="center" class="auto-style6">
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px" colspan="1" align="center">
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px" colspan="1" align="center">
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style6">
                                    &nbsp;
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="trUploads" runat="server" visible="false">
                                <td colspan="6">
                                    <table style="width: 60%">
                                        <tr>
                                            <td colspan="5">
                                                <asp:Label runat="server"><strong>Documents To Upload</strong></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trerector" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="210px">8B NOC
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fup8BNOC" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="hyper8BNOC" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lbl8BNOC" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btn8BNOC" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btn8BNOC_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr1" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                2.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="210px">9B NOC
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fup9BNOC" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="hyper9BNOC" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lbl9BNOC" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btn9BNOC" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btn9BNOC_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr3" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="210px">
                                                    Fire Occupancy Certificate
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupfireoccupancycertificate" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="hyperfireoccupancycertificate" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblfireoccupancycertificate" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnfireoccupancycertificate" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnfireoccupancycertificate_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr4" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                4.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="210px">GHMC Occupancy Certificate
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupGHMCoccupancycertificate" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="hyperGHMCoccupancycertificate" runat="server" CssClass="LBLBLACK"
                                                    Width="165px" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblGHMCoccupancycertificate" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnGHMCoccupancycertificate" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnGHMCoccupancycertificate_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr5" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="210px">NOC of TSFTV & TDC
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupTSFTCANDTDCNOC" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="hyperTSFTCANDTDCNOC" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblTSFTCANDTDCNOC" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnTSFTCANDTDCNOC" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnTSFTCANDTDCNOC_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr6" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="210px">NOC of Film Chamber of Commerce
 <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupfirmchambernoc" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="hyperfirmchambernoc" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblfirmchambernoc" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnfirmchambernoc" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnfirmchambernoc_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr7" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="210px">Film Division
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupfirmdivision" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="hyperfirmdivision" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblfirmdivision" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnfirmdivision" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnfirmdivision_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr8" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                8.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="210px">Lease Agreement or any other relavent document
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupleaseagreement" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="hyperleaseagreement" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblleaseagreement" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnleaseagreement" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnleaseagreement_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr9" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                9.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="210px">Blue print of Cinema Theatre/Multiplex with Screens and seating Capacity
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupblueprint" runat="server" class="form-control txtbox" Height="28px" />
                                                <asp:HyperLink ID="hyperblueprint" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblblueprint" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnblueprint" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btnblueprint_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr10" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                10.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="210px">Details with regard to Screens, seating and Ticket Rates proposed
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupseatingdetails" runat="server" class="form-control txtbox"
                                                    Height="28px" />
                                                <asp:HyperLink ID="hyperseatingdetails" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblseatingdetails" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnseatingdetails" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload" Width="72px" OnClick="btnseatingdetails_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center" class="style7">
                                    &nbsp;<tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <caption>
                                        &nbsp;</caption>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <div style="padding: 5px; margin: 5px; text-align: center;">
                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                        Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" ValidationGroup="group"
                        Width="90px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnSave" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group"
                        Width="90px" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnPayment" runat="server" CssClass="btn btn-danger" Height="32px"
                        TabIndex="10" Text="PAYMENT" Width="90px" ValidationGroup="group" OnClick="BtnDelete_Click"
                        Visible="false" />
                </div>
                <div id="success" runat="server" visible="false" style="text-align: center" class="alert alert-success">
                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                        &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                </div>
                <div id="Failure" runat="server" visible="false" style="text-align: center" class="alert alert-danger">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                        Warning!</strong>
                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                </div>
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="group" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="group1" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="child" />
                <asp:HiddenField ID="hdfFlagID" runat="server" />
                <asp:HiddenField ID="hdfFlagID0" runat="server" />
                <asp:HiddenField ID="hdnflagapprovalid" runat="server" />
                <asp:HiddenField ID="hdnidentityid" runat="server" />
                <br />
                <asp:HiddenField ID="hdfpencode" runat="server" />
                <asp:HiddenField ID="hdnapplicationid" runat="server" />
                <asp:HiddenField ID="hdnTransactionNumber" runat="server" />
            </div>
        </div>
    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="upd1">
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
</asp:Content>
