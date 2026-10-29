<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmMobileTowerApplication.aspx.cs" Inherits="UI_TSiPASS_frmMobileTowerApplication" %>

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
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style6 {
            width: 192px;
        }

        .style7 {
            color: #FF3300;
        }

        .LBLBLACK {
        }
    </style>
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

        .style5 {
            width: 13px;
        }

        .style6 {
            width: 203px;
        }

        .auto-style6 {
            width: 858px;
        }

        .auto-style7 {
            height: 57px;
        }

        .auto-style8 {
            width: 192px;
            height: 57px;
        }

        .auto-style9 {
            width: 10px;
            height: 57px;
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
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            WinPrint.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');
            WinPrint.document.write('<h3 style="width: 100%;text-align: center;">Mobile Tower Application</h3>');
            WinPrint.document.write(' <center><img src="telanganalogo.png" width="75px" height="75px" /></center>');
            WinPrint.document.write('</head><body style="width: 100%;text-align: center;">');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
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
            debugger;
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127 ))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter NumericValues Only");
            }
        }
  
        });

    </script>

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
                <i class="fa fa-edit"></i><a href="#">Fire Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel-heading" align="center" style="background-color: forestgreen">
                    <h3 class="panel-title" style="color: white">MOBILE TOWER APPLICATION</h3>
                </div>
                <div class="panel panel-primary" id="divCDMA" runat="server" visible="true">

                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">

                        <div id="divprint">

                            <table>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" valign="top" align="center" class="auto-style6">

                                        <table>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label49" runat="server" CssClass="LBLBLACK" Width="200px">Proposed District<font color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox"
                                                        Height="33px" Width="180px" TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                                                        <asp:ListItem>--District--</asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 5px; margin: 5px; text-align: right;">
                                                    <asp:Label ID="Label50" runat="server" CssClass="LBLBLACK" Width="200px">Proposed Mandal&nbsp;<span style="color: red">*</span></asp:Label>

                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:DropDownList ID="ddlmandal" runat="server" class="form-control txtbox"
                                                        Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlProp_intMandalid_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem>--Mandal--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="Label62" runat="server" CssClass="LBLBLACK" Width="200px">Proposed Village<font color="red">*</font></asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:DropDownList ID="ddlProp_intVillageid" runat="server" class="form-control txtbox"
                                                        Height="33px" Width="180px" TabIndex="1">
                                                        <asp:ListItem>--Village--</asp:ListItem>
                                                    </asp:DropDownList></td>
                                                <td style="padding: 5px; margin: 5px; text-align: right;">
                                                   

                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                                <tr runat="server" id="traddressoftheapplicationheader" visible="false">
                                    <td style="padding: 5px; margin: 5px" valign="top" align="center" class="auto-style6">
                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="280px"
                                            Font-Bold="True"><h4>Address Of The Applicant</h4></asp:Label>
                                    </td>

                                </tr>
                                <tr runat="server" id="traddressoftheapplicationdetails" visible="false">
                                    <td>

                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <div id="updatepanels1">
                                                            <table style="width: 720px" cellspacing="2" cellpadding="2" border="0">
                                                                <tbody>

                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Name of the Infrastructure Provider Companie</asp:Label></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">

                                                                            <asp:TextBox ID="txtname" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="200px">Door No./Flat No.</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtdoor" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="200px"> Road/Street</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtroad" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="200px"> Area</asp:Label>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtarea" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="200px"> Mandal</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtmandal" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="200px"> District</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtdistrct" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="200px">  PIN Code</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtpin" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="200px"> E-mail</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtmail" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; height: 10px"></td>
                                </tr>
                                <tr runat="server" id="trLocationOfTheProposedSiteheader" visible="false">
                                    <td style="padding: 5px; margin: 5px" valign="top" align="center" class="auto-style6">
                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="280px"
                                            Font-Bold="True"><h4>Location Of The Proposed Site</h4></asp:Label>
                                    </td>

                                </tr>
                                <tr runat="server" id="trLocationOfTheProposedSitedetails" visible="false">
                                    <td>

                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <div id="updatepanels3">

                                                            <table style="width: 720px; height: 133px" cellspacing="2" cellpadding="2" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="200px">Plot Nos.</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtplot" runat="server" class="form-control txtbox" MaxLength="20"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox></td>

                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px">Sanctioned Layout No.(if any)</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtlayout" runat="server" class="form-control txtbox" MaxLength="30"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="200px">Survey No.</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtsurvey" runat="server" class="form-control txtbox" MaxLength="30"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="200px">Premises/Door No.</asp:Label>
                                                                        </td>
                                                                        <td style="text-align: left">

                                                                            <table>
                                                                                <tr>

                                                                                    <td style="padding: 1px; margin: 1px; text-align: left;">
                                                                                        <asp:TextBox ID="txtrevward" runat="server" class="form-control txtbox" MaxLength="3" Width="40px"
                                                                                            Height="28px" TabIndex="1" ValidationGroup="group" onkeypress="NumberOnly()"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding: 0px; margin: 0px; text-align: left;">-</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtrevblock" runat="server" class="form-control txtbox" MaxLength="3"
                                                                                            Height="28px" TabIndex="1" ValidationGroup="group" Width="40px" onkeypress="NumberOnly()"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding: 0px; margin: 0px; text-align: left;">-</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtdoorno" runat="server" class="form-control txtbox" MaxLength="55"
                                                                                            Height="28px" TabIndex="1" ValidationGroup="group" Width="70px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="200px">Example.</asp:Label>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <span id="lblrevward" style="display: inline-block; width: 30px;">8</span>&nbsp;
                                                            -
                                                            <span id="Label1" style="display: inline-block; width: 20px;">5</span>&nbsp; -
                                                            <span id="Label2" style="display: inline-block; width: 60px;">120/A</span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="200px">Road/Street No.</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtstreetroad" runat="server" class="form-control txtbox" MaxLength="5"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Election Ward No.</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtward" runat="server" class="form-control txtbox" MaxLength="3"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="200px">Election Block No.</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtblock" runat="server" class="form-control txtbox" MaxLength="3"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="200px">Circle</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlcircle" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlcircle_SelectedIndexChanged" AutoPostBack="true">
                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="1049">1-Kapra</asp:ListItem>
                                                                                <asp:ListItem Value="1057">2-Uppal</asp:ListItem>
                                                                                <asp:ListItem Value="1051">3-Hayathnagar</asp:ListItem>
                                                                                <asp:ListItem Value="1004">6-Malakpet</asp:ListItem>
                                                                                <asp:ListItem Value="1005">9-Charminar</asp:ListItem>
                                                                                <asp:ListItem Value="1054">11-Rajendra Nagar</asp:ListItem>
                                                                                <asp:ListItem Value="1007">12-Mehdipatnam</asp:ListItem>
                                                                                <asp:ListItem Value="1008">14-Gosha Mahal</asp:ListItem>
                                                                                <asp:ListItem Value="1009">15-Musheerabad</asp:ListItem>
                                                                                <asp:ListItem Value="1010">17-Khairatabad</asp:ListItem>
                                                                                <asp:ListItem Value="1055">20-Serilingampally</asp:ListItem>
                                                                                <asp:ListItem Value="1012">21-Chanda Nagar</asp:ListItem>
                                                                                <asp:ListItem Value="1013">22-R C Puram and Patancheruvu </asp:ListItem>
                                                                                <asp:ListItem Value="1050">23-Moosapet</asp:ListItem>
                                                                                <asp:ListItem Value="1053">25-Qutbullapur</asp:ListItem>
                                                                                <asp:ListItem Value="1047">27-Alwal</asp:ListItem>
                                                                                <asp:ListItem Value="1052">28-Malkajigiri</asp:ListItem>
                                                                                <asp:ListItem Value="1018">29-Secunderabad</asp:ListItem>
                                                                                <asp:ListItem Value="1064">5-Saroornagar</asp:ListItem>
                                                                                <asp:ListItem Value="1058">18-Jubilee Hills</asp:ListItem>
                                                                                <asp:ListItem Value="1059">16-Amberpet</asp:ListItem>
                                                                                <asp:ListItem Value="1060">13-Karwan</asp:ListItem>
                                                                                <asp:ListItem Value="1068">26-Gajularamaram</asp:ListItem>
                                                                                <asp:ListItem Value="1069">30-Begumpet</asp:ListItem>
                                                                                <asp:ListItem Value="1061">24-Kukatpally</asp:ListItem>
                                                                                <asp:ListItem Value="1062">4-L B Nagar</asp:ListItem>
                                                                                <asp:ListItem Value="1063">7-Santoshnagar</asp:ListItem>
                                                                                <asp:ListItem Value="1065">8-Chandrayangutta</asp:ListItem>
                                                                                <asp:ListItem Value="1066">10-Falaknuma</asp:ListItem>
                                                                                <asp:ListItem Value="1067">19-Yousufguda</asp:ListItem>
                                                                            </asp:DropDownList>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label30" runat="server" CssClass="LBLBLACK" Width="200px">Locality</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlloc" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" TabIndex="1">
                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="200px">Area</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtaarea" runat="server" class="form-control txtbox" MaxLength="75"
                                                                                Height="28px" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>

                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label51" runat="server" CssClass="LBLBLACK" Width="200px">GPS Co-ordinates</asp:Label>
                                                                        </td>

                                                                        <td align="left" colspan="3">
                                                                            <table width="50%">
                                                                                <tr>
                                                                                    <td style="padding: 1px; margin: 1px; text-align: left;">
                                                                                        <asp:TextBox ID="txtgpsdd" runat="server" class="form-control txtbox" MaxLength="2"
                                                                                            Height="28px" TabIndex="1" ValidationGroup="group" Width="40px" onkeypress="NumberOnly()"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding: 0px; margin: 0px; text-align: left;">Degrees&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtgpsmm" runat="server" class="form-control txtbox" MaxLength="2"
                                                                                            Height="28px" TabIndex="1" ValidationGroup="group" Width="40px" onkeypress="NumberOnly()"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding: 0px; margin: 0px; text-align: left;">Minutes&nbsp;</td>
                                                                                    <td>&nbsp;<asp:TextBox ID="txtgpsss" runat="server" class="form-control txtbox" MaxLength="2"
                                                                                        Height="28px" TabIndex="1" ValidationGroup="group" Width="40px" onkeypress="NumberOnly()" Style="height: 28px; margin: -18px 0px 0px 0px;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding: 0px; margin: 0px; text-align: left; width: 100px">&nbsp; Secounds</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>

                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; height: 10px"></td>
                                </tr>
                                <tr runat="server" id="trDetailsOfTheProposedTITheader" visible="false">
                                    <td style="padding: 5px; margin: 5px" valign="top" align="center" class="auto-style6">
                                        <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="280px"
                                            Font-Bold="True"><h4>Details Of The Proposed TIT</h4></asp:Label>
                                    </td>

                                </tr>

                                <tr runat="server" id="trDetailsOfTheProposedTITdetails" visible="false">
                                    <td>

                                        <table style="width: 720px; height: 60px" cellspacing="2" cellpadding="2" border="1">
                                            <tbody>
                                                <tr>
                                                    <td style="height: 12px" colspan="4">
                                                        <strong>Site Area (in Sq.m)</strong></td>
                                                </tr>

                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lblDocid" runat="server" CssClass="LBLBLACK" Width="200px">As Per Documents</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lblsubmitplan" runat="server" CssClass="LBLBLACK" Width="200px">As Per Submitted Plan</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Lblroadwideningarea" runat="server" CssClass="LBLBLACK" Width="200px">Road Widening Area</asp:Label>

                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="LblNetarea" runat="server" CssClass="LBLBLACK" Width="200px">Net Area</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">

                                                        <asp:TextBox ID="txtdocument" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="1" MaxLength="18" onkeypress="DecimalOnly()"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox ID="txtsubplan" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="1" MaxLength="18" onkeypress="DecimalOnly()"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">

                                                        <asp:TextBox ID="txtwidenarea" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="1" MaxLength="18" onkeypress="DecimalOnly()"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>

                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox ID="txtnet" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="1" MaxLength="18" onkeypress="DecimalOnly()"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; height: 10px"></td>
                                </tr>
                                <tr runat="server" id="trSetBacksofRoomheader" visible="false">
                                    <td>

                                        <table style="width: 720px; height: 60px" cellspacing="2" cellpadding="2" border="1">
                                            <tbody>
                                                <tr>
                                                    <td style="height: 12px" colspan="4">
                                                        <strong>Set Backs of Room/Tower(Minimum-3mtrs)</strong></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lbleast" runat="server" CssClass="LBLBLACK" Width="200px">East</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lblwest" runat="server" CssClass="LBLBLACK" Width="200px">West</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lblnorth" runat="server" CssClass="LBLBLACK" Width="200px">North</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lblsouth" runat="server" CssClass="LBLBLACK" Width="200px">South</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox ID="txteast" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="1" MaxLength="5" onblur="maxvalueeast();" onkeypress="NumberOnly()"
                                                            ValidationGroup="group" Width="100px"></asp:TextBox>mtrs</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox ID="txtwest" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="1" MaxLength="5" onblur="maxvaluewest();" onkeypress="NumberOnly()"
                                                            ValidationGroup="group" Width="100px"></asp:TextBox>
                                                        mtrs
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox ID="txtnorth" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="1" MaxLength="5" onblur="maxvaluenorth();" onkeypress="NumberOnly()"
                                                            ValidationGroup="group" Width="100px"></asp:TextBox>
                                                        mtrs
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:TextBox ID="txtsouth" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="1" MaxLength="5" onblur="maxvaluesouth();" onkeypress="NumberOnly()"
                                                            ValidationGroup="group" Width="100px"></asp:TextBox>
                                                        mtrs
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; height: 10px"></td>
                                </tr>
                                <tr runat="server" id="trSetBacksofRoomdetails" visible="false">
                                    <td>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <div id="updatepanels6">
                                                            <table style="width: 720px; height: 133px" cellspacing="2" cellpadding="2" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Lblproposal" runat="server" CssClass="LBLBLACK" Width="200px">Proposals &nbsp;<span style="color: red">*</span></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlproposal" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlproposal_SelectedIndexChanged" AutoPostBack="true">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="1">GROUND BASED TOWER (GBT)</asp:ListItem>
                                                                                <asp:ListItem Value="2">ROOF TOP TOWER (RTT)</asp:ListItem>
                                                                                <asp:ListItem Value="3">ROOF TOP POLES (RTP)</asp:ListItem>
                                                                            </asp:DropDownList>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="200px">Accessory Room</asp:Label></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <table id="rtnaccroom">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td colspan="2" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:RadioButtonList ID="rdaccroom" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                                                                <%--OnSelectedIndexChanged="rbtproposedonbilding_SelectedIndexChanged"--%>
                                                                                                <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                                                <asp:ListItem Value="N">NO</asp:ListItem>
                                                                                            </asp:RadioButtonList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="200px">Generator Room</asp:Label></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <table id="rtngenroom">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td colspan="2" style="padding: 5px; margin: 5px; text-align: left;">

                                                                                            <asp:RadioButtonList ID="rdgenroom" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                                                                <%--OnSelectedIndexChanged="rbtproposedonbilding_SelectedIndexChanged"--%>
                                                                                                <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                                                <asp:ListItem Value="N">NO</asp:ListItem>
                                                                                            </asp:RadioButtonList></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="200px"> Whether Proposed &nbsp;<span style="color: red">*</span></asp:Label>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlproposed" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" TabIndex="1">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                            </asp:DropDownList>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="200px">Vacant Land Tax Identification No.</asp:Label>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtvltno" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="14" onkeypress="NumberOnly()"
                                                                                ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="200px"> Property Tax Identification No.</asp:Label>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtptino" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="14" MaxLength="10" onkeypress="NumberOnly()"
                                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="200px">  Building Permit No.</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtperno" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="14" MaxLength="50"
                                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="200px">  Occupancy Certificate No.</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtocccer" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="14" 
                                                                                ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="200px"> Tower Construction.</asp:Label>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <table id="rtbtncon">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:RadioButtonList ID="rdtbtncon" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                                                                <%--OnSelectedIndexChanged="rbtproposedonbilding_SelectedIndexChanged"--%>
                                                                                                <asp:ListItem Value="E" Selected="True">Existing</asp:ListItem>
                                                                                                <asp:ListItem Value="N">New</asp:ListItem>
                                                                                            </asp:RadioButtonList></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="200px"> Name of Owner</asp:Label></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtowner" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="14" ValidationGroup="group" Width="180px" MaxLength="100"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="200px"> Net Work Agency/Firm Name&nbsp;<span style="color: red">*</span></asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">

                                                                            <asp:DropDownList ID="ddlnet" runat="server" class="form-control txtbox"
                                                                                Height="33px" Width="180px" TabIndex="1">
                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="1">AIRTEL</asp:ListItem>
                                                                                <asp:ListItem Value="2">AIRCELL</asp:ListItem>
                                                                                <asp:ListItem Value="3">IDEA</asp:ListItem>
                                                                                <asp:ListItem Value="4">RELIANCE</asp:ListItem>
                                                                                <asp:ListItem Value="5">TATA</asp:ListItem>
                                                                                <asp:ListItem Value="6">TATA DOCOMO</asp:ListItem>
                                                                                <asp:ListItem Value="7">TATA INDICOM</asp:ListItem>
                                                                                <asp:ListItem Value="8">VODAFONE</asp:ListItem>
                                                                                <asp:ListItem Value="9">UNINOR</asp:ListItem>
                                                                                <asp:ListItem Value="10">BSNL</asp:ListItem>
                                                                                <asp:ListItem Value="11">T24</asp:ListItem>
                                                                                <asp:ListItem Value="12">VIRGIN</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="200px"> Lessee / License Agrement</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <table id="rtnlessee">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:RadioButtonList ID="rdnlessee" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                                                                <%--OnSelectedIndexChanged="rbtproposedonbilding_SelectedIndexChanged"--%>
                                                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                                                <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                                            </asp:RadioButtonList></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Lease Years
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtleaseyears" runat="server" class="form-control txtbox"
                                                                                Height="28px" TabIndex="14" MaxLength="3" ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: right;">
                                                                            <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="200px"> Authorised Agent</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <table id="rtnauagent">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">

                                                                                            <asp:RadioButtonList ID="rdnauagent" runat="server" RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                                                                <%--OnSelectedIndexChanged="rbtproposedonbilding_SelectedIndexChanged"--%>
                                                                                                <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                                                            </asp:RadioButtonList></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="200px"> Authorised Agent Name</asp:Label>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtauagentname" runat="server" class="form-control txtbox" MaxLength="75"
                                                                                Height="28px" TabIndex="14"
                                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    </tr>

                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>

                                <tr runat="server" id="trLicenseTechnicalPersonalheader" visible="false">
                                    <td style="padding: 5px; margin: 5px" valign="top" align="center" class="auto-style6">
                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="280px"
                                            Font-Bold="True"><h4>License Technical Personal</h4></asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" id="trLicenseTechnicalPersonaldetails" visible="false">
                                    <td>
                                        <table style="width: 720px; height: 133px" cellspacing="2" cellpadding="2" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px"> Architect Name</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtarchitectname" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" MaxLength="75"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:Label ID="Label38" runat="server" CssClass="LBLBLACK" Width="200px"> Architect License No</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:TextBox ID="txtarchitectno" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" MaxLength="20"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="200px"> Architect Address</asp:Label></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:TextBox ID="txtarchitectaddress" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" TextMode="MultiLine"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;"></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="200px"> Engineer Name</asp:Label></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:TextBox ID="txtengname" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" MaxLength="75"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:Label ID="Label41" runat="server" CssClass="LBLBLACK" Width="200px"> Engineer License No</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:TextBox ID="txtengno" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" MaxLength="35"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="200px"> Engineer Address</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:TextBox ID="txtengaddress" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" TextMode="MultiLine"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="200px"> Surveyor Name</asp:Label></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtsurvename" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" MaxLength="75"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="200px"> Surveyor License No.</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:TextBox ID="txtsurveno" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" MaxLength="20"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label44" runat="server" CssClass="LBLBLACK" Width="200px"> Surveyor Address</asp:Label></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:TextBox ID="txtsurveaddress" runat="server" class="form-control txtbox"
                                                            Height="40px" TabIndex="14" TextMode="MultiLine"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="200px"> Structural Engineer</asp:Label></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtstreng" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" MaxLength="75"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:Label ID="Label47" runat="server" CssClass="LBLBLACK" Width="200px"> Structural Engineer License No.</asp:Label></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: right;">
                                                        <asp:TextBox ID="txtstrenglicno" runat="server" class="form-control txtbox"
                                                            Height="28px" TabIndex="14" MaxLength="20"
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div id="divsaveclearbuttons" runat="server" visible="false" style="padding: 5px; margin: 5px; text-align: center;">
                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                CssClass="btn btn-warning" Height="32px" TabIndex="10"
                                Text="ClearAll" ToolTip="To Clear  the Screen" ValidationGroup="group" OnClick="btnNext0_Click"
                                Width="90px" />
                            &nbsp;&nbsp;
                                            <asp:Button ID="BtnSave" runat="server" CausesValidation="False"
                                                CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="10"
                                                Text="Save" ValidationGroup="group" Width="90px" />
                        </div>
                        <div id="divuploadforms" runat="server" visible="false" style="padding: 5px; margin: 5px; text-align: center;">

                            <br />
                            <br />
                            <table>
                                <tr runat="server" id="tr1" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label53" runat="server" CssClass="LBLBLACK" Width="210px">Location Plan <font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fuplocation" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperlocation" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblloction" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnlocation" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnlocation_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr2" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label61" runat="server" CssClass="LBLBLACK" Width="210px">Site Plan<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fusiteplan" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperSitePlan" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblSitePlan" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnsiteplan" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnsiteplan_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr3" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label52" runat="server" CssClass="LBLBLACK" Width="210px">Elevation Plan <font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupelevationplan" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperelevationplan" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblelevationplan" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnelevationplan" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnelevationplan_Click" />
                                    </td>
                                </tr>
                                <tr runat="server" id="tr4" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">4.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label65" runat="server" CssClass="LBLBLACK" Width="210px">Sections <font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupSections" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperSections" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblSections" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnSections" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnSections_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr5" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">5.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label63" runat="server" CssClass="LBLBLACK" Width="210px">Structural Stability Certificate<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupstabilitycertificate" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperstabilitycertificate" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblstabilitycertificate" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnstabilitycertificate" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnstabilitycertificate_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr6" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">6.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label79" runat="server" CssClass="LBLBLACK" Width="210px">Sanctioned Plan of the Building & Occupancy Certificate <font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupSPBOcertificate" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperSPBOcertificate" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblSPBOcertificate" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnSPBOC" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnSPBOC_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr7" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">7.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label54" runat="server" CssClass="LBLBLACK" Width="210px">Ownership Document<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupownershipdocment" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperownershipdocment" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblownershipdocment" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnownershipdocment" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnownershipdocment_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr8" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">8.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label55" runat="server" CssClass="LBLBLACK" Width="210px">Lease Agreement Deed<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupleaseagreementdeed" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperleaseagreementdeed" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblleaseagreementdeed" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnleaseagreementdeed" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" /><%-- OnClick="btnleaseagreementdeed_Click"--%> 
                                    </td>
                                </tr>
                                <tr runat="server" id="tr9" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">9.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label56" runat="server" CssClass="LBLBLACK" Width="210px">Agreement <font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupagreement" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperagreement" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblagreement" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnagreement" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" /><%--OnClick="btnagreement_Click"--%>
                                    </td>
                                </tr>



                                <tr runat="server" id="tr10" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">10.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label57" runat="server" CssClass="LBLBLACK" Width="210px">Tower Details<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fuptowerdetails" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hypertowerdetails" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lbltowerdetails" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btntowerdetails" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btntowerdetails_Click" />
                                    </td>
                                </tr>
                                <tr runat="server" id="tr11" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">11.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label58" runat="server" CssClass="LBLBLACK" Width="210px">Indemnity Bond<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupindemnitybond" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperindemnitybond" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblindemnitybond" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnindemnitybond" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnindemnitybond_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr12" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">12.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label59" runat="server" CssClass="LBLBLACK" Width="210px">No Objection Certificate<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupnoobjectioncertificate" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hypernoobjectioncertificate" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblnoobjectioncertificate" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnnoobjectioncertificate" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnnoobjectioncertificate_Click" />
                                    </td>
                                </tr>
                                <tr runat="server" id="tr13" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">13.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label60" runat="server" CssClass="LBLBLACK" Width="210px">Issue Permission Base On the copy Of SACFA<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupissuepermission" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperissuepermission" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblissuepermission" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnissuepermission" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnissuepermission_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr14" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">14.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label69" runat="server" CssClass="LBLBLACK" Width="210px">NOC from ATC&AAI <font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupNOCATCAAI" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperNOCATCAAI" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblNOCATCAAI" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnNOCATCAAI" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnNOCATCAAI_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr15" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">15.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label71" runat="server" CssClass="LBLBLACK" Width="210px">Access Service License/IP Registration certificate from DOT.<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupCertificatefromDOT" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="hyperCertificatefromDOT" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblCertificatefromDOT" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnCertificatefromDOT" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnCertificatefromDOT_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr16" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">16.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label73" runat="server" CssClass="LBLBLACK" Width="210px">Permit Fee<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fuppermitfee" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="Hyperpermitfee" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblpermitfee" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnpermitfee" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnpermitfee_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr17" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">17.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label75" runat="server" CssClass="LBLBLACK" Width="210px">NOC from Building Owner<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupnocfrombuildowner" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="Hypernocfrombuildowner" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblnocfrombuildowner" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btnnocfrombuildowner" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btnnocfrombuildowner_Click" />
                                    </td>
                                </tr>

                                <tr runat="server" id="tr18" visible="true">
                                    <td style="padding: 5px; margin: 5px; text-align: left;">18.</td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Label ID="Label77" runat="server" CssClass="LBLBLACK" Width="210px">Copy of certificate issued by ARAI<font 
                                                            color="red">*</font></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:</td>
                                    <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                        <asp:FileUpload ID="fupcertificateissuedARAI" runat="server" class="form-control txtbox"
                                            Height="28px" />

                                        <asp:HyperLink ID="HypercertificateissuedARAI" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Target="_blank"></asp:HyperLink>
                                        <br />
                                        <asp:Label ID="lblcertificateissuedARAI" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:Button ID="btncertificateissuedARAI" runat="server" CssClass="btn btn-xs btn-warning"
                                            Height="28px" TabIndex="10" Text="Upload"
                                            Width="72px" OnClick="btncertificateissuedARAI_Click" />
                                    </td>
                                </tr>

                            </table>



                        </div>

                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>


                <div id="divnextbuttons" runat="server" visible="false" style="padding: 5px; margin: 5px; text-align: center;">

                    <%--<asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger"
                        Height="32px" OnClick="" TabIndex="10" Text="Next"
                        ValidationGroup="group" Width="90px" />--%>
                    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                        TabIndex="10" Text="PAYMENT" Width="90px" ValidationGroup="group" OnClick="btnNext_Click" />

                    <asp:Button ID="btnprint" runat="server" Height="32px" CausesValidation="False" Width="90px"
                        CssClass="btn btn-warning" UseSubmitBehavior="False" Text="Print " OnClientClick="javascript:CallPrint('divprint');return false;"  Visible="false"/>


                </div>

                <div id="success" runat="server" visible="false" style="text-align: center" class="alert alert-success">
                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                </div>


                <div id="Failure" runat="server" visible="false" style="text-align: center" class="alert alert-danger">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Warning!</strong>
                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                </div>
                <asp:HiddenField ID="hdfID" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                <asp:ValidationSummary ID="ValidationSummary3" runat="server"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
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
