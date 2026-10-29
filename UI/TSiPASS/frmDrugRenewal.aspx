<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmDrugRenewal.aspx.cs" Inherits="UI_TSiPASS_frmDrugRenewal" %>

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
        
        .auto-style12
        {
            width: 190px;
            height: 57px;
        }
        
        .auto-style13
        {
            height: 57px;
            width: 12px;
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
            <li class="active"><i class="fa fa-edit"></i><a href="#">Drug License Retention</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel-heading" align="center" style="background-color: forestgreen">
                    <h3 class="panel-title" style="color: white">
                        Drug License Retention</h3>
                </div>
                <div class="panel panel-primary" id="divCDMA" runat="server">
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style13">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style7">
                                                <asp:Label ID="Label23" runat="server" Width="238px">License No.
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style7">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style12">
                                                <asp:TextBox ID="txtlicenseNO" runat="server" class="form-control txtbox"
                                                    AutoPostBack="true" Height="28px" TabIndex="1" OnTextChanged="txtlicenseNO_TextChanged"
                                                    ValidationGroup="group" Width="250px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style9">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style6">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style10">
                                                a.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style7">
                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="200px">LicenseType
<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style7">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                <asp:TextBox ID="txtLicenseType" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style9">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style10">
                                                1.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style7">
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px">Name of the Firm
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style7">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                <asp:TextBox ID="txtnameofthefirm" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style9">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                3.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: justify;">
                                                <asp:Label ID="Label4" runat="server" Width="249px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtmandal" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
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
                                                5.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" Width="252px">Unit Address 
<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtunitaddress" runat="server" class="form-control txtbox" Height="38px"
                                                    TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                7.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" Width="252px">
                                                     Office Mandal
                                                  <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtmandal_office" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                9.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" Width="252px">
                                                     Office Address
                                                  <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtoffice_Address" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
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
                                                <asp:Label ID="Label20" runat="server" Width="252px">
                                                     To Date

                                                  <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txttodate" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trtotalproduct" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">
                                                13.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Total Product<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txttotalproduct" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
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
                                                b.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label26" runat="server" Width="259px">LicenseSubType
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtLicenseSubType" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
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
                                                <asp:Label ID="Label21" runat="server" Width="259px">District
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtdistrict" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                4.&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label7" runat="server" Width="243px">
                                                    Village
                                                    <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtvillage" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trofficedistrict" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                6.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" Width="243px">
                                                    Office District
                                                    <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtdistric_office" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trofficevillage" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                8.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="200px">Office Village<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtvillage_office" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trfromdate" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                10.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="200px">From Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtfromdate" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                12.
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Total Amount<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txttotalAmount" runat="server" class="form-control txtbox" Height="28px"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
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
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style6">
                                    &nbsp;
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
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
                        Width="90px" OnClick="BtnClear_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnSave" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group"
                        Width="90px" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnNext0" runat="server" CssClass="btn btn-danger" Height="32px"
                        OnClick="btnNext0_Click" TabIndex="10" Text="Previous" Width="90px" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px" OnClick="btnNext_Click"
                        TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />
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
