<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmMobileTowesTSROW.aspx.cs" Inherits="UI_TSiPASS_frmMobileTowesTSROW" %>

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

        .style8 {
            height: 59px;
        }

        .style9 {
            width: 192px;
            height: 59px;
        }

        .style10 {
            width: 27px;
        }
        .LBLBLACK {}
        .auto-style1 {
            width: 212px;
        }
        .auto-style2 {
            width: 516px;
        }
        .auto-style3 {
            width: 48px;
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
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 6) {
                alert("length must be exactly 6 characters")
            }
        }
    </script>
    <script type="text/javascript">

    </script>

    <%--<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />--%>
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
                <i class="fa fa-edit"></i><a href="#">Land Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Application for Issue of Permission for Establishment of Mobile Tower</h3>
                    </div>

                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 86%">

                            <tr id="Tr1" runat="server" >
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="210px">A. Details of the Applicant<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="280px"
                                        >1. Name of the Organization</asp:Label>
                                </td>
                                <td class="auto-style3"></td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtorganisationname" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" onkeypress="Names()"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr id="Tr2" runat="server" >
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="210px">2. Registered Address<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Plot/Flat No.<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtplotorflatno" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label417" runat="server" CssClass="LBLBLACK" Width="165px">City/ Town<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtcityortown" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">5.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label412" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1"
                                                    OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        
                                        
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">7.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label425" runat="server" CssClass="LBLBLACK" Width="165px">PinCode<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtpincode" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        
                 
                                    </table>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label416" runat="server" CssClass="LBLBLACK" Width="165px">Road/Street<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtroadorstreet" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddldistrict" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1"
                                                    OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">6.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control txtbox" TabIndex="1"
                                                    Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
</table>
                                </td>
                            </tr
                            <tr id="Tr3" runat="server" >
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="314px">3. Authorised Person With Designation<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="200px">Name<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtname_authorisedperson" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" onkeypress="Names()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="165px">Phone/Mobile No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtphoneno_authorisedperson" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        
                                        
                                        
                                        
                                        
                 
                                    </table>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="165px">Designation<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtdesignation_authorisedperson" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" onkeypress="Names()" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">4.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="165px">Email<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtemail_authorisedperson" runat="server" class="form-control txtbox"
                                                    Height="28px"  TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"  ></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        
                                        
</table>
                                </td>
                            </tr>
                            <tr id="Tr4" runat="server" >
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="286px">B. Details of the Proposed Site<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Extent<span>&nbsp;</span></span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlextent_proposedsite" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1"
                                                     AutoPostBack="true" OnSelectedIndexChanged="ddlextent_proposedsite_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Tower Height (sq.ft)</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txttowerheight" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Department </span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddldepartment" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1" 
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddldepartment_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">District</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlsitedistrict" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlsitedistrict_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr id="trpanchayatrajRD" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Panchayat - RD</span><p class="m-0" style="box-sizing: border-box; margin: 0px !important; color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
                                                    <small style="box-sizing: border-box; font-size: 12.8px; font-weight: 400;">(where the ROW to be carried out)</small></p>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlpanchayatRD" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        
                                        
                                        
                                        
                 
                                    </table>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Tower Type</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddltowertype" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">4.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Plot Size (sq.ft)</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtplotsize" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="20" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"  ></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr id="trward" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Ward</span><p class="m-0" style="box-sizing: border-box; margin: 0px !important; color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
                                                    <small style="box-sizing: border-box; font-size: 12.8px; font-weight: 400;">(where the ROW to be carried out)</small></p>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlward" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr id="trmuncipality" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Municipality</span><p class="m-0" style="box-sizing: border-box; margin: 0px !important; color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
                                                    <small style="box-sizing: border-box; font-size: 12.8px; font-weight: 400;">(where the ROW to be carried out)</small></p>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlmuncipality" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr id="trpanchayatrajED" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Panchayat - ED</span><p class="m-0" style="box-sizing: border-box; margin: 0px !important; color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
                                                    <small style="box-sizing: border-box; font-size: 12.8px; font-weight: 400;">(where the ROW to be carried out)</small></p>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlpanchayatED" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr id="trmandal_site" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Mandal</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlsitemandal" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px"
                                                    TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlsitemandal_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        
                                        
                                        
</table>
                                </td>
                            </tr>
                            <tr id="trinstallationofland" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="lblinstallationofland" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="286px"><font color="red"></font></asp:Label>
                                </td>
                            </tr>
                            <tr id="trlanddetails" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Land Required (Size &amp; Area in meter)</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtlandrequired" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Road/ Street</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtroadorstreet_private" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">City/ Town<span>&nbsp;</span></span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtcityortown_private" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        
                                        
                                        
                                        
                                        
                 
                                    </table>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Plot No</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtplotno_private" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="50" TabIndex="1" onkeypress="return inputOnlyNumbers(event)"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">4.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Ward No./ Block No. &amp; Locality<span>&nbsp;</span></span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtwardorblockno_private" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="60" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"  ></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        
                                        
                                        
</table>
                                </td>
                            </tr>
                            <tr id="trinstallationofbuildings" runat="server" visible="false">

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    <asp:Label ID="lblinstallationofbuildings" runat="server" CssClass="LBLBLACK" Width="280px"
                                        >&nbsp;&nbsp;1. Name of the Building/ Structure</asp:Label>
                                </td>
                                <td class="auto-style3"></td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtnameofthebuildingorstructure" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr id="trbuildingdetails" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
Height of building (Meters)</td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtbuildingheight" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1"><asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">Area of the building/structure</asp:Label></td>
 
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtareaofbuildingorstructure" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none; background-color: rgb(255, 255, 255)">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Street</span>&nbsp;</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtstreet_building" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">8.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Landmark<span>&nbsp;</span></span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtlandmark_building" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        
                                        
                                        
                                        
                                        
                 
                                    </table>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Stores of building</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlstoresofbuilding" runat="server"
                                                    class="form-control txtbox" Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">G+1</asp:ListItem>
                                                    <asp:ListItem Value="2">G+2</asp:ListItem>
                                                    <asp:ListItem Value="3">G+3</asp:ListItem>
                                                    <asp:ListItem Value="4">G+4</asp:ListItem>
                                                    <asp:ListItem Value="5">G+5 AND ABOVE</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">5.</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none; background-color: rgba(0, 0, 0, 0.05)">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">H.No</span>&nbsp;</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txthouseno_building" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="60" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"  ></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">7.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Locality</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtlocality_building" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"  onkeypress="Names()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">9.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Pin code</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtpincode_building" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                        
                                        
</table>
                                </td>
                            </tr>
                            <tr id="Tr7" runat="server" >
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="521px">Latitude and Longitude Values<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Exact Latitude of the Proposed Site</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtlatitude" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Exact Longitude of the Proposed Site</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtlongitude" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>                                  
</table>
                                </td>
                            </tr>
                        <tr id="Tr6" runat="server" >
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="521px">C. Details of Owner of Proposed Land/Building<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Name of Owner</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtowername" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"  onkeypress="Names()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Address of Owner</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtowneraddress" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" 
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>                                  
</table>
                                </td>
                            </tr>
                            <tr id="Tr8" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="356px">D. Other Relevant Information<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    The mode of and the time duration for execution of the work
                                </td>
                                <td class="auto-style3"></td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtmodeandtimeduration" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" onkeypress="Names()"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr>

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">The inconvenience that is likely to be caused to the public and the specific measures to be taken to mitigate such inconvenience</span>
                                </td>
                                <td class="auto-style3"></td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtinconvenience" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" onkeypress="Names()"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr>

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">The measures proposed to be taken to ensure public safety during the execution of the work</span></td>
                                <td class="auto-style3"></td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtmeasuresproposed" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" onkeypress="Names()"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr>

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">The names and contact details of the employees of the licensee for the purpose of communication in regard to the application made</span></td>
                                <td class="auto-style3">Name</td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtname_employee" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" onkeypress="Names()"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr>

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    &nbsp;</td>
                                <td class="auto-style3">Address</td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtaddress_employee" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr>

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    &nbsp;</td>
                                <td class="auto-style3">Mobile No</td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtmobileno_employee" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr>

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    &nbsp;</td>
                                <td class="auto-style3"><span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgba(0, 0, 0, 0.05); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Email</span></td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtemail_employee" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr>

                                <td style="padding: 5px; margin: 5px" valign="top" align="left" class="auto-style2">
                                    Any other matter relevant, in the opinion of the licensee, connected with or relative to the work proposed to be undertaken</td>
                                <td class="auto-style3">&nbsp;</td>
                                <td valign="top">                                               
                                    <asp:TextBox ID="txtanyothermatter" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="100" TabIndex="1" onkeypress="Names()"
                                                    ValidationGroup="group" Width="344px"></asp:TextBox>
                                            </td>
                            </tr>
                            <tr id="Tr9" runat="server" >
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="521px">E. Fee / Charges (ITE&C)<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">

                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Administrative Charges(Rs)(<span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 12.8px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">per 
                                                application</span>)</span></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtadministrativecharges" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="auto-style3">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <span style="color: rgb(0, 0, 0); font-family: Poppins, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">GST @ 18%<span>&nbsp;</span></span><i aria-hidden="true" class="fa fa-inr" style="box-sizing: border-box; display: inline-block; font: 400 16px / 1 FontAwesome; text-rendering: auto; -webkit-font-smoothing: antialiased; color: rgb(0, 0, 0); letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">(Rs)</i></td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtGST" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="30" TabIndex="1" onkeypress="NumberOnly()"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <asp:HiddenField ID="HDNMOBILETOWERID" runat="server" Visible="false" />
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>                                  
</table>
                                </td>
                            </tr>
                          
                        
                            
                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td align="center" colspan="3"
                                style="padding: 5px; margin: 5px; text-align: center;">
                                <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                    CssClass="btn btn-warning" Height="32px"  TabIndex="10"
                                    Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                &nbsp;
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                        ValidationGroup="group" Width="90px" />
                                
                                &nbsp;&nbsp;<asp:Button ID="btnnext" runat="server" Visible="true"
                                    CssClass="btn btn-danger" Height="32px" TabIndex="10"
                                    Text="Next" Width="90px" ValidationGroup="group" OnClick="btnnext_Click" />


                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>


                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                    <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
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
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                        <asp:HiddenField ID="hdfpencode" runat="server" />
                    </div>

                </div>
            </div>
        </div>

    </div>

</asp:Content>

