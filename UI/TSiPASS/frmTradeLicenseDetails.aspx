<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmTradeLicenseDetails.aspx.cs" Inherits="UI_TSiPASS_frmTradeLicenseDetails" %>

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

        .auto-style2 {
            height: 35px;
        }

        .auto-style3 {
            width: 203px;
            height: 35px;
        }

        .auto-style4 {
            width: 10px;
            height: 35px;
        }

        .auto-style5 {
            width: 174px;
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

            $("input[id$='txtfromdate']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txttodate']").datepicker(
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

            $("input[id$='txttodate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtrentorleasedeeddate']").datepicker(
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
                    <h3 class="panel-title" style="color: white">TRADE LICENSE DETAILS</h3>
                </div>
                <div class="panel panel-primary" id="divCDMA" runat="server" visible="false">

                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="200px">Trade Nature<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtnature" runat="server" OnSelectedIndexChanged="rbtnature_SelectedIndexChanged" AutoPostBack="true"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="T">Temperory</asp:ListItem>
                                                    <asp:ListItem Value="P">Permanent</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="rbtnature"
                                                    ErrorMessage="Please select trade natre type" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">From Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtfromdate" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Enabled="false"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtfromdate"
                                                    ErrorMessage="Please enter from date" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                            <td style="padding: 5px; margin: 5px" valign="top">2.</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="200px">Trade title</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txttradetitle" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txttradetitle"
                                                    ErrorMessage="Please Enter trade type" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">To Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txttodate" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Enabled="false"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="txttodate"
                                                    ErrorMessage="Please enter to date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="280px"
                                        Font-Bold="True">Trade Categoeries</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px">Trade ULB<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlulb" runat="server" class="form-control txtbox" AutoPostBack="true"
                                                    Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlulb_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <%--<asp:ListItem Value="1">Hotel</asp:ListItem>
                                                    <asp:ListItem Value="2">Industry</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Sub Category <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlcdmasubcategoery" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlcdmasubcategoery_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="200px">Width <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtwidth" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" OnTextChanged="txtwidth_TextChanged" AutoPostBack="true"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>



                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="200px">Category Type<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlcdmacategoery" runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddlcdmacategoery_SelectedIndexChanged" 
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="200px">Height <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtheight" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" OnTextChanged="txtheight_TextChanged" AutoPostBack="true"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label47" runat="server" CssClass="LBLBLACK" Width="200px">Plinth Area <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtplinthareacdma" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                            <tr id="tr2" runat="server">

                                <td style="padding: 5px; margin: 5px" colspan="1" align="center">&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td style="padding: 5px; margin: 5px" colspan="1" align="center">&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td style="padding: 5px; margin: 5px" colspan="1" align="center">&nbsp;&nbsp;&nbsp;&nbsp;</td>



                            </tr>

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>



                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="center">
                                    <asp:Label ID="Label4" runat="server"><strong>Documents To Upload</strong></asp:Label></td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table style="width: 60%">
                                        <tr runat="server" id="trerector" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="210px">Ownership Document/Lease Agreement Document (if not owner)/ Registered or Unregistered lease deed showing legal occupancy of the applicant<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupleasedeed" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hyperlinkleasedeed" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblleasedeed" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnleasedeed" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnleasedeed_Click" />
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center" class="style7">&nbsp;<tr>
                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                </tr>
                                    <caption>
                                        &nbsp;</caption>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">&nbsp;</td>
                            </tr>

                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px"></td>
                            </tr>
                        </table>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <div class="panel panel-primary" id="divGHMC" runat="server" visible="false">

                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="200px">Category Type<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlghmccategoery" runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddlghmccategoery_SelectedIndexChanged" AutoPostBack="true"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="200px">Road Type<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style2">:</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlroadtype" runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddlroadtype_SelectedIndexChanged"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true">
                                                    <asp:ListItem>--Select Road Type--</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style4"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Maximum Ceilling Amount<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtmaxceilamount" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group" Enabled="false"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">7.</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label48" runat="server" CssClass="LBLBLACK" Width="200px">Trade title</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtghmctradetile" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                    Height="28px"   TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="txtghmctradetile"
                                                    ErrorMessage="Please Enter trade Title" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="200px">Sub Category <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlghmcsubcategoery" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="middle">4.</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="200px">Road Width</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtroadwidth" runat="server" class="form-control txtbox" Enabled="false"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="200px">Plinth Area in Sft<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtplintharea" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off" onkeypress="DecimalOnly()"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" OnTextChanged="txtplintharea_TextChanged" AutoPostBack="true"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="280px"
                                        Font-Bold="True">Trade Categoeries</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="200px">Circle<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlcircle" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlcircle_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem>--Select Circle--</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="200px">Locality<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddllocality" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select Locality--</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>


                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="200px">Ward Name <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlwardname" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select Ward Name--</asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>


                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <table cellpadding="4" cellspacing="5" class="nav-justified">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style5">
                                                <asp:Label ID="Label424" runat="server" Width="132px"><b>Property Type </b><font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rbtpropertytype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtpropertytype_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="1" Width="324px">
                                                    <asp:ListItem Value="1">Assessed</asp:ListItem>
                                                    <asp:ListItem Value="2">Un-Assessed</asp:ListItem>
                                                    <asp:ListItem Value="3">Un-Authorized</asp:ListItem>

                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trpropertytax">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="200px">property Tax No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtproertytaxnumber" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off" OnTextChanged="txtproertytaxnumber_TextChanged"
                                                    TabIndex="1" ValidationGroup="group" AutoPostBack="true" onkeypress="NumberOnly()"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr runat="server" visible="false" id="trplotno">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="200px">Plot No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtplotnumber" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off" OnTextChanged="txtplotnumber_TextChanged"
                                                    TabIndex="1" ValidationGroup="group" AutoPostBack="true" onkeypress="NumberOnly()"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="200px">Door No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtdoornumber" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group" Enabled="false"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" class="nav-justified">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>

                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label426" runat="server" CssClass="LBLBLACK" Width="200px">Owner Name<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtownername" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group" Enabled="false"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label427" runat="server" CssClass="LBLBLACK" Width="200px">Address<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtaddress" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group" TextMode="MultiLine"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>



                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>




                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px"></td>
                            </tr>
                        </table>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <div class="panel panel-primary" id="DIVPRD" runat="server" visible="false">

                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style6">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style6">
                                                <asp:Label ID="Label49" runat="server" CssClass="LBLBLACK" Width="200px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style6">:</td>
                                            <td class="auto-style7" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   <%-- <asp:ListItem Value="1">Trade With Stream(Horse Power)</asp:ListItem>--%>
                                                   <%-- <asp:ListItem Value="2">Shop/Business/Establishment</asp:ListItem>
                                                    <asp:ListItem Value="3">Cell Tower</asp:ListItem>--%>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style8"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style6">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style6">
                                                <asp:Label ID="Label51" runat="server" CssClass="LBLBLACK" Width="200px">Gram Panchayat<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style6">:</td>
                                            <td class="auto-style7" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlgrampanchayat" runat="server" class="form-control txtbox" 
                                                    Height="33px" Width="180px" TabIndex="1" >
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   <%-- <asp:ListItem Value="1">Trade With Stream(Horse Power)</asp:ListItem>--%>
                                                   <%-- <asp:ListItem Value="2">Shop/Business/Establishment</asp:ListItem>
                                                    <asp:ListItem Value="3">Cell Tower</asp:ListItem>--%>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style8"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="200px">Trade <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style2">:</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddltrade" runat="server" class="form-control txtbox" Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddltrade_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <%--<asp:ListItem Value="1">Cold Storages</asp:ListItem>
                                                    <asp:ListItem Value="2">Toys Shop</asp:ListItem>
                                                    <asp:ListItem Value="3">Cell Tower</asp:ListItem>--%>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style4"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="middle">7.</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="200px">Annual License Fee in Rs </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtannuallicensefee" runat="server" class="form-control txtbox" Enabled="false"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                        </tr>
                                        <tr id="trinstallationfee" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="middle">7a.</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label52" runat="server" CssClass="LBLBLACK" Width="200px">Installation Fee in Rs </asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtinstallationfee" runat="server" class="form-control txtbox" Enabled="false"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">9.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="200px">License Period From<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtlicenseperiodfrom" runat="server" class="form-control txtbox" Enabled="false" Height="28px" AutoComplete="off"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">11.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label36" runat="server" CssClass="LBLBLACK" Width="200px">Proposed License/Establishment Building <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style2">:</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlestablishbilding" runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddlestablishbilding_SelectedIndexChanged" Height="33px" Width="180px" TabIndex="1" AutoPostBack="true">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Own</asp:ListItem>
                                                    <asp:ListItem Value="2">Rented</asp:ListItem>
                                                    <asp:ListItem Value="3">Leased</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style4"></td>
                                        </tr>
                                        
                                        <tr id="trrentorleasedeedno" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">13.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label39" runat="server" CssClass="LBLBLACK" Width="200px">Rent/Lease Deed No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtrentorleasedeedno" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr id="trrentorleaseperiodfrom" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">15.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label41" runat="server" CssClass="LBLBLACK" Width="200px">Rent/Lease Period From<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtrentorleaseperiodfrom" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label50" runat="server" CssClass="LBLBLACK" Width="200px">Mandal <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style2">:</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlmandal" runat="server" class="form-control txtbox" Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <%--<asp:ListItem Value="1">Cold Storages</asp:ListItem>
                                                    <asp:ListItem Value="2">Toys Shop</asp:ListItem>
                                                    <asp:ListItem Value="3">Cell Tower</asp:ListItem>--%>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style4"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style6">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style6">
                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="200px">Trade License For<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style6">:</td>
                                            <td class="auto-style7" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddltradelicensefor" runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddltradelicensefor_SelectedIndexChanged"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   <%-- <asp:ListItem Value="1">Trade With Stream(Horse Power)</asp:ListItem>--%>
                                                   <%-- <asp:ListItem Value="2">Shop/Business/Establishment</asp:ListItem>
                                                    <asp:ListItem Value="3">Cell Tower</asp:ListItem>--%>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style8"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Sub Trade<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style2">:</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlsubtrade" runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddlsubtrade_SelectedIndexChanged"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <%--<asp:ListItem Value="1">Other Installations exceeding one Horse Power</asp:ListItem>
                                                    <asp:ListItem Value="2">Toys Shop</asp:ListItem>
                                                    <asp:ListItem Value="3">Roof Top Tower</asp:ListItem>--%>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style4"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">8.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label34" runat="server" CssClass="LBLBLACK" Width="200px">Trade License Year<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="auto-style2">:</td>
                                            <td class="auto-style3" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddltradelicenseyear" runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddltradelicenseyear_SelectedIndexChanged"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <%--<asp:ListItem Value="1">2019-2020</asp:ListItem>
                                                    <asp:ListItem Value="2">2020-2021</asp:ListItem>
                                                    <asp:ListItem Value="3">2021-2020</asp:ListItem>--%>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px;" class="auto-style4"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">10.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label37" runat="server" CssClass="LBLBLACK" Width="200px">License Period To<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtlicenseperiodto" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group" Enabled="false"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr id="trbuildingownername" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">12.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label38" runat="server" CssClass="LBLBLACK" Width="200px">Building Owner Name <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtbuildingownername" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr id="trrentorleasedeeddate" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">14.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label40" runat="server" CssClass="LBLBLACK" Width="200px">Rent/Lease Deed Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtrentorleasedeeddate" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                        <tr id="trrentorleaseperiodto" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">16.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="200px">Rent/Lease Period To<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtrentorleaseperiodto" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group"
                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="center">
                                    <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="280px"
                                        Font-Bold="True">Department License Details</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="200px">Concerned Department License is Required <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlconcerndeptlicensereqired" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" OnSelectedIndexChanged="ddlconcerndeptlicensereqired_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                        </tr>
                                        <tr id="trdeptlicensedetails" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="200px">Department License Details<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtdeptlicensedetails" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>


                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="200px">If Available TAN/GST Number<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtTANorGSt" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;"></td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>


                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">&nbsp;</td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>



                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="center">
                                    <asp:Label ID="Label30" runat="server"><strong>Documents To Upload</strong></asp:Label></td>

                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table style="width: 60%">
                                        <tr runat="server" id="tr1" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label32" runat="server" CssClass="LBLBLACK" Width="210px">Recent Tax Paid receipt of that Building<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupbuildingtaxpaidreceipt" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hyptaxpaidreceipt" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblbuildingtaxpaidreceipt" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnbuildingtaxpaidreceipt" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnbuildingtaxpaidreceipt_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr3" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="210px">OwnerShip Document/Lease Agreement Document(if not Owner)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupownershiporleaseagrmntdocment" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hyperownershiporleaseagrmntdocment" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblownershiporleaseagrmntdocment" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnownershiporleaseagrmntdocment" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnownershiporleaseagrmntdocment_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr4" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="210px">Where Department License is required and obtained,Upload Support Documents<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fupdepartmentlicense" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hyperdepartmentlicense" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lbldepartmentlicense" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btndepartmentlicense" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btndepartmentlicense_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr5" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label44" runat="server" CssClass="LBLBLACK" Width="210px">TAN/GST Document<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; width: 500px; text-align: left;">
                                                <asp:FileUpload ID="fuptanorgstdocment" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hypertanorgstdocment" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lbltanorgstdocment" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btntanorgstdocment" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btntanorgstdocment_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;</td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>




                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px"></td>
                            </tr>
                        </table>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <div style="padding: 5px; margin: 5px; text-align: center;">

                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                        CssClass="btn btn-warning" Height="32px" TabIndex="10"
                        Text="ClearAll" ToolTip="To Clear  the Screen" ValidationGroup="group"
                        Width="90px" />
                    &nbsp;&nbsp;
                                   
                                    <asp:Button ID="BtnSave" runat="server" CausesValidation="False"
                                        CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="10"
                                        Text="Save" ValidationGroup="group" Width="90px" />
                    &nbsp; &nbsp;
                                   
                                           <asp:Button ID="BtnDelete0" runat="server"
                                               CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click" TabIndex="10"
                                               Text="Previous" Width="90px" CausesValidation="False" />

                    &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server"
                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
                        Text="Next" Width="90px"
                        ValidationGroup="group" />



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
