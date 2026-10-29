<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmSupportToWeakerSection.aspx.cs" Inherits="UI_TSiPASS_frmSupportToWeakerSection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <%--<style type="text/css">
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

        .style6 {
            width: 464px;
        }

        .LBLBLACK {
        }

        .auto-style1 {
            width: 68px;
        }

        .auto-style2 {
            width: 14px;
        }

        .auto-style3 {
            height: 35px;
        }

        .auto-style4 {
            width: 27px;
            height: 35px;
        }

        .auto-style5 {
            width: 464px;
            height: 35px;
        }

        .auto-style8 {
            width: 1689px;
        }
        .auto-style9 {
            width: 1221px;
        }
    </style>--%>

    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>
    

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
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
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-edit">IPO</i>
                    </li>
                    <li class="active">
                        <i class="fa fa-edit"></i><a href="#">Bank Wise</a>
                    </li>
                </ol>
            </div>

            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Constitution of Women Cell-District Level</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">


                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                        <tr id="TRDISTRICT" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 197px;" class="style3">
                                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="171px">District<font id="lbl1" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control txtbox"
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>

                                                                </asp:DropDownList>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td class="style6" valign="top" runat="server" id="tdnoofmembers">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">


                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" >2</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 264px;">
                                                                <asp:Label ID="Label438" runat="server" Width="253px">No of IE's in the District  (<a style="color:red"> Please enter newly adding IE's count only</a>)</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtnoofiesindistrict" autoComplete="off" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trdetails">
                                                <td style="padding: 5px; margin: 5px" valign="top" >
                                                    <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="210px">Details<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td ></td>
                                                <td valign="top" ></td>
                                            </tr>
                                            <tr runat="server" id="trfacilitatordetails">
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label1" runat="server" Width="165px">Name of the Industrial Estate<font id="lbl6" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtindustrialestatename" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                    MaxLength="200" TabIndex="1" ValidationGroup="group" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">3</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="180px">Name of Nodal Officer Alloted to IE<font id="lb3" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtnodalofficername" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">5</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="180px">Total No.of Plots available<font id="Font1" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtnoofplotsavailable" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">7</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="180px">Total No.of Plots vacant<font id="Font2" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtnoofplotsvacant" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">9</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="180px">No of plots available for reallocation to weaker sections<font id="Font3" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtplotsforreallocation" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>






                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top" class="style6">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">



                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">2</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="257px">Whether TSIIC Promoted/Private<font id="lbl7" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">

                                                                <asp:RadioButtonList ID="RBTPROMOTEDORPRIVATE" runat="server" AutoPostBack="true"
                                                                    Height="33px" TabIndex="1" Width="201px" RepeatDirection="Horizontal">

                                                                    <asp:ListItem Value="PROMOTED">PROMOTED</asp:ListItem>
                                                                    <asp:ListItem Value="PRIVATE">PRIVATE</asp:ListItem>

                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">4</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="255px">Designation<font
                                                                    color="red" id="lbl4" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtdesignation" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">6</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="180px">Total No.of Plots alloted<font id="Font4" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtnoofplotsalloted" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">8</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="180px">No.of Plots where units are not set up after mandatory period<font id="Font5" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtplotsnotsetupaftermandatoryperiod" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="tr1">
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="386px">10. Total Plots mandated category wise<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top" class="style6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">




                                                        <tr id="TR3" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">a</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 193px;" class="style3">
                                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="171px">SC<font id="Font6" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtsc_mandated" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr id="TR4" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">c</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 193px;" class="style3">
                                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="171px">BC<font id="Font7" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtbc_mandated" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr id="TR5" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">e</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 193px;" class="style3">
                                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="171px">Women<font id="Font8" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtwomen_mandated" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td class="style6" valign="top" runat="server" id="td1">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">


                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">b</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 259px;">
                                                                <asp:Label ID="Label10" runat="server" Width="253px">ST</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtst_mandated" autoComplete="off" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">d</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 259px;">
                                                                <asp:Label ID="Label15" runat="server" Width="253px">Minority</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtminority_mandated" autoComplete="off" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="tr6">
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="386px">11. Total Plots actually allotted category wise<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top" class="style6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                        <tr id="TR7" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">a</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 202px;" class="style3">
                                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="171px">SC<font id="Font9" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtsc_alloted" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr id="TR8" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">c</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 202px;" class="style3">
                                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="171px">BC<font id="Font10" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtbc_alloted" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr id="TR9" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">e</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 202px;" class="style3">
                                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="171px">Women<font id="Font11" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtwomen_alloted" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td class="style6" valign="top" runat="server" id="td2">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">


                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">b</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 247px;">
                                                                <asp:Label ID="Label20" runat="server" Width="253px">ST</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtst_alloted" autoComplete="off" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">d</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 247px;">
                                                                <asp:Label ID="Label21" runat="server" Width="253px">Minority</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtminority_alloted" autoComplete="off" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="tr10">
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="386px">12. Total Plots actually vacant category wise<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top" class="style6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                        <tr id="TR11" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">a</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 204px;" class="style3">
                                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="171px">SC<font id="Font12" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtsc_vacant" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr id="TR12" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">c</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 204px;" class="style3">
                                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="171px">BC<font id="Font13" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtbc_vacant" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr id="TR13" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">e</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 204px;" class="style3">
                                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="171px">Women<font id="Font14" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtwomen_vacant" runat="server" class="form-control txtbox" onkeypress="NumberOnly()"
                                                                    Height="28px" TabIndex="1" ValidationGroup="child" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td class="style6" valign="top" runat="server" id="td3">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">


                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">b</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 251px;">
                                                                <asp:Label ID="Label26" runat="server" Width="253px">ST</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtst_vacant" autoComplete="off" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">d</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 251px;">
                                                                <asp:Label ID="Label27" runat="server" Width="253px">Minority</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtminority_vacant" autoComplete="off" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 80%">

                                                        <tr id="TR14" runat="server">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">13</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 159px;">
                                                                <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="161px">Any other remarks<font id="Font15" runat="server"
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtanyotherremarks" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                    MaxLength="200" TabIndex="1" ValidationGroup="group" autoComplete="off"
                                                                    Width="180px"></asp:TextBox>

                                                            </td>

                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td class="style6" valign="top" runat="server" id="td4">
                                                    <table cellpadding="4" cellspacing="5" style="width: 88%">


                                                        <tr id="tr2" runat="server">
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="width: 200px;">&nbsp; </td>
                                                            <td style="padding: 5px; margin: 5px" >&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp; 
                                                        <asp:Button ID="btnadd" runat="server" CssClass="btn btn-xs btn-warning"
                                                            Height="28px" OnClick="btnadd_Click" TabIndex="10" Text="Add New"
                                                            ValidationGroup="child" Width="72px" />
                                                                &nbsp;
                                                        <asp:Button ID="btnclear" runat="server" CausesValidation="False"
                                                            CssClass="btn btn-xs btn-danger" Height="28px" OnClick="btnclear_Click"
                                                            TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="77px" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                    <div style="width:100%">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 30%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left"  >
                                                    <asp:GridView runat="server" CssClass="GRDITEM" ID="gridindustrialestates" AutoGenerateColumns="false" AllowSorting="true" OnRowCommand="gridindustrialestates_RowCommand"
                                                        BorderColor="#003399" BorderStyle="Solid" OnRowCreated="gridindustrialestates_RowCreated" 
                                                        BorderWidth="1px" CellPadding="4" 
                                                        ForeColor="#333333" Width="26%">
                                                        <HeaderStyle CssClass="gridcolor"  BorderColor="White" BorderWidth="2px" ForeColor="White" BackColor="White"/>
                                                        <RowStyle BackColor="#ffffff" />
                                                         <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="District">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldistrict" runat="server" Text='<%#Eval("district") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IE Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnameofindestate" runat="server" Text='<%#Eval("nameofindestate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="TSIIC Promoted/Prompted">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblwhethertsiicpromotedorprivate" runat="server" Text='<%#Eval("whethertsiicpromotedorprivate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Officer Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnodalofficername" runat="server" Text='<%#Eval("nodalofficername") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Designation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnodalofficerdesignation" runat="server" Text='<%#Eval("nodalofficerdesignation") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Available">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalnoofplotsavailable" runat="server" Text='<%#Eval("totalnoofplotsavailable") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Allotted">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalnoofplotsalloted" runat="server" Text='<%#Eval("totalnoofplotsalloted") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Vacant">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalnoofplotsvacant" runat="server" Text='<%#Eval("totalnoofplotsvacant") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Not set up after mandatory period">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnoofplotsunitsnotsetmandatory" runat="server" Text='<%#Eval("noofplotsunitsnotsetmandatory") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="For reallocation to weaker sections">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnoofplotsforreallocation" runat="server" Text='<%#Eval("noofplotsforreallocation") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SC">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsmandatedforsc" runat="server" Text='<%#Eval("totalplotsmandatedforsc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ST">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsmandatedforst" runat="server" Text='<%#Eval("totalplotsmandatedforst") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="BC">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsmandatedforbc" runat="server" Text='<%#Eval("totalplotsmandatedforbc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Minority">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsmandatedforminority" runat="server" Text='<%#Eval("totalplotsmandatedforminority") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Women">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsmandatedforwomen" runat="server" Text='<%#Eval("totalplotsmandatedforwomen") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="SC">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsallottedforsc" runat="server" Text='<%#Eval("totalplotsallottedforsc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ST">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsallottedforst" runat="server" Text='<%#Eval("totalplotsallottedforst") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="BC">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsallottedforbc" runat="server" Text='<%#Eval("totalplotsallottedforbc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Minority">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsallottedforminority" runat="server" Text='<%#Eval("totalplotsallottedforminority") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Women">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsallottedforwomen" runat="server" Text='<%#Eval("totalplotsallottedforwomen") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="SC">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsvacantforsc" runat="server" Text='<%#Eval("totalplotsvacantforsc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ST">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsvacantforst" runat="server" Text='<%#Eval("totalplotsvacantforst") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="BC">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsvacantforbc" runat="server" Text='<%#Eval("totalplotsvacantforbc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Minority">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsvacantforminority" runat="server" Text='<%#Eval("totalplotsvacantforminority") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Women">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotalplotsvacantforwomen" runat="server" Text='<%#Eval("totalplotsvacantforwomen") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remarks">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblanyotherremarks" runat="server" Text='<%#Eval("anyotherremarks") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-Font-Size="16px" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                                HeaderText="Delete">
                                                                <ItemStyle Font-Size="Small" CssClass="BorderRight" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkRenRemove" runat="server" CommandName="INDUSTRIALESTATEDELETE" Font-Bold="true"
                                                                        ForeColor="#ff3300"><u>Delete</u></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="SteelBlue" CssClass="GRDHEADER" Font-Bold="True"   />

                                                        <EditRowStyle BackColor="#013161" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            </table>
                                            <table align="center" cellpadding="10" cellspacing="5" style="width: 60%">
                                            <tr >
                                                <td align="center" 
                                                    style="padding: 2px; margin: 2px; text-align: center;" >
                                                    <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="btnsave_Click" TabIndex="10" Text="Save"
                                                        Width="90px" ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear1" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear1_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                </td>
                                            </tr>
                                                 </table>
                                            <table align="center"  style="width: 30%">
                                            <tr align="center">
                                                <td align="center"  >

                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" OnRowCreated="grdDetails_RowCreated"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" ShowFooter="false" >
                                                        <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Industrial Estate ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="LBLINDESTID_GRID" runat="server" Text='<%#Eval("INDESTID_GRID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                            </asp:TemplateField>


                                                            <asp:BoundField DataField="DISTRICT" HeaderText="District" ItemStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="INDUSTRIALESTATENAME" HeaderText="IE Name" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="TSIICPROMOTEDORPRIVATE" HeaderText="Whether TSIIC Promoted/Private" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="NODALOFFICERNAME" HeaderText="Officer Name" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="NODALOFFICERDESIGNATION" HeaderText="Designation" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSAVAILABLE" HeaderText="available" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSALLOTED" HeaderText="allotted" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSVACANT" HeaderText="vacant" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="NOOFPLOTSWHEREUNITSNOTSETUPFORMANDATORYPERIOD" HeaderText="Not set up after mandatory period" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="NOOFPLOTSAVAILABLEFORREALLOCATION" HeaderText="For reallocation to weaker sections" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="TOTALNOOFPLOTSMANDATEDSC" HeaderText="SC" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSMANDATEDST" HeaderText="ST" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSMANDATEDBC" HeaderText="BC" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSMANDATEDMINORITY" HeaderText="Minority" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSMANDATEDWOMEN" HeaderText="Women" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="TOTALNOOFPLOTSALLOTEDSC" HeaderText="SC" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSALLOTEDST" HeaderText="ST" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSALLOTEDBC" HeaderText="BC" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSALLOTEDMINORITY" HeaderText="Minority" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSALLOTEDWOMEN" HeaderText="Women" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="TOTALNOOFPLOTSVACANTSC" HeaderText="SC" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSVACANTST" HeaderText="ST" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSVACANTBC" HeaderText="BC" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSVACANTMINORITY" HeaderText="Minority" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TOTALNOOFPLOTSVACANTWOMEN" HeaderText="Women" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="ANYOTHEREMARKS" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center"
                                                                Visible="true">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>


                                                            <asp:TemplateField HeaderText="Remarks to Delete">
                                                                <ItemTemplate>

                                                                    <asp:TextBox runat="server" class="form-control txtbox" Height="50px"  Width="100PX"
                                                                        ID="txtremarks" placeholder="Remarks" TextMode="MultiLine" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Submit">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btndelete" runat="server" CausesValidation="False" CssClass="btn-success"
                                                                        Height="32px" OnClick="btndelete_Click" OnClientClick="return confirm('Do you want to update the record ? ');"
                                                                        TabIndex="10" Text="Delete" ValidationGroup="group"  />

                                                                    <br />

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                       
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />

                        </div>

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
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave" />
            <asp:PostBackTrigger ControlID="btnadd"></asp:PostBackTrigger>

        </Triggers>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>


