<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmFilmShootingApplication.aspx.cs" MasterPageFile="~/UI/TSiPASS/CCMaster.master" Inherits="UI_TSiPASS_frmFilmShootingApplication" %>



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

        .style6 {
            height: 34px;
        }

        .style7 {
            width: 42px;
        }

        .style8 {
            height: 34px;
            width: 42px;
        }

        .style10 {
            width: 9px;
        }

        .style11 {
            width: 210px;
        }

        .style12 {
        }

        .style13 {
            width: 13px;
        }

        .style14 {
            height: 50px;
        }

        .style15 {
            width: 210px;
            height: 50px;
        }

        .style16 {
            width: 9px;
            height: 50px;
        }

        .style17 {
            width: 5%;
        }

        .style18 {
            width: 2%;
        }

        .style19 {
            width: 42%;
        }

        .style20 {
            width: 41%;
        }
        .auto-style1 {
            color: #555555;
            background-color: #FFFFFF;
        }
    </style>
     <script type="text/javascript">
         function checkLength(el) {
             if (el.value.length != 6) {
                 alert("Pin number length must be exactly 6 characters")
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
    <script type="text/javascript" language="javascript">
        function CharOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Charcters Only");
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
                   dateFormat: "yy/mm/dd",
                   minDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txttodate']").datepicker(
              {
                  dateFormat: "yy/mm/dd",
                  minDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtfromdate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "yy/mm/dd",
                    minDate: new Date(currentYear, currentMonth, currentDate)

                });

            $("input[id$='txttodate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "yy/mm/dd",
                    minDate: new Date(currentYear, currentMonth, currentDate)
                });

        });
    </script>
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
                                <h3 class="panel-title">Film Shooting Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td colspan="5"><b>Production Details</b></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;1.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="214px">Name of the Production Agency / Company<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtnameofproductionagency" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;2.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="180px">Company GSTIN <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtcompanyGstin" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label27" runat="server" Width="259px">District
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddldist_agency" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddldist_agency_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label28" runat="server" Width="259px">Mandal
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlmandal_agency" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_agency_SelectedIndexChanged"
                                                    >
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label29" runat="server" Width="259px">Village
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlvillage_agency" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label30" runat="server" Width="259px">Plot Number
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtplotnumber_agency" runat="server" class="form-control txtbox" 
                                                    Height="28px"   TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">7.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label31" runat="server" Width="259px">Pincode
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtpincode_agency" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px"   TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                        <tr>
                                                            <td colspan="5"><asp:CheckBox ID="checkaddress" runat="server" AutoPostBack="true" OnCheckedChanged="checkaddress_CheckedChanged" /><asp:Label ID="lbladdress" runat="server"><b>Same as Permanent Address</b></asp:Label></td>
                                                        </tr>
                                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">8.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label32" runat="server" Width="259px">District
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddldistrict_temp" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_temp_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">9.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label33" runat="server" Width="259px">Mandal
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlmandal_temp" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_temp_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">10.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label34" runat="server" Width="259px">Village
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlvillage_temp" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">11.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label35" runat="server" Width="259px">Plot Number
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtplotno_temp" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px"   TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">12.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label36" runat="server" Width="259px">Pincode
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtpincode_temp" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px"   TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                                                                 <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">13.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label37" runat="server" Width="259px">Phone No 1
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtphno1_agency" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px"   TabIndex="1" MaxLength="10"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                                                                 <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">14.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label38" runat="server" Width="259px">Phone No 2
                                            <font color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtphno2_agency" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px"   TabIndex="1" MaxLength="10"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                 <tr>
                                                     <td colspan="5"><b>Application filed by</b></td>
                                                 </tr>       
 </tr>   <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label47" runat="server" Width="259px">Name
                                            <font color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtapplicantname" runat="server" class="form-control txtbox" 
                                                    Height="28px"   TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                               <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label48" runat="server" Width="259px">Mobile No
                                            <font color="red"></font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" class="auto-style1">
                                                <asp:TextBox ID="txtapplicantmobileno" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px"   TabIndex="1" MaxLength="10"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                      <tr>
                                                          <td colspan="5"><b>Producer Details</b></td>
                                                      </tr>
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;1.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="180px">Name of the Producer<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtproducername" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1" onkeypress="Names()"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label39" runat="server" Width="259px">District
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddldistrict_producer" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_producer_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label40" runat="server" Width="259px">Mandal
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlmandal_prodcer" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_prodcer_SelectedIndexChanged"
                                                    >
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label41" runat="server" Width="259px">Village
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlvillage_prodcer" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                   
                                                    
                                                </asp:DropDownList>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label42" runat="server" Width="259px">Plot Number
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtplotno_producer" runat="server" class="form-control txtbox" 
                                                    Height="28px"   TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label43" runat="server" Width="259px">Pincode
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtpincode_producer" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px"   TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">7.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label44" runat="server" Width="259px">Phone No1
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtphno1_producer" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px"   TabIndex="1" MaxLength="10"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">8.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label45" runat="server" Width="259px">Phone No 2
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtphno2_producer" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()"
                                                    Height="28px"   TabIndex="1" MaxLength="10"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                         <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11">9.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label46" runat="server" Width="259px">EmailId
                                            <font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtemailid_producer" runat="server" class="form-control txtbox" 
                                                    Height="28px"   TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                               </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                &nbsp;</td>
                                        </tr>
                                                        <tr>
                                                            <td colspan="5"><b>Other Details</b></td>
                                                        </tr>
                                                                                                                <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Whether a member of any Trade-body<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rbttradebody" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbttradebody_SelectedIndexChanged"
                                                                    RepeatDirection="Horizontal" TabIndex="1">
                                                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="trtradebodydetails" runat="server" visible="false">
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txttradebodydetails" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                      
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;2.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="180px">Title of the Film<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtfilmtitle" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="180px">Language<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddllanguage" runat="server"  class="form-control txtbox" AutoPostBack="true" Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddllanguage_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Telugu</asp:ListItem>
                                                                    <asp:ListItem Value="2">Hindi</asp:ListItem>
                                                                    <asp:ListItem Value="3">English</asp:ListItem>
                                                                    <asp:ListItem Value="4">Other Language</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="trotherlanguage" runat="server" visible="false">
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtotherlanguage" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1" onkeypress="CharOnly()"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr >
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">4</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="200px">Type of Film<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;<asp:DropDownList ID="ddlfilmType" runat="server" AutoPostBack="true"  class="form-control txtbox" Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlfilmType_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Children Film</asp:ListItem>
                                                                    <asp:ListItem Value="2">Docmentary Film</asp:ListItem>
                                                                    <asp:ListItem Value="3">Feature Film</asp:ListItem>
                                                                    <asp:ListItem Value="4">TV Serial</asp:ListItem>
                                                                    <asp:ListItem Value="5">Others</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="trotherfilmtype" runat="server" visible="false">
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtotherfilmtype" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1" onkeypress="CharOnly()"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label458" runat="server" CssClass="LBLBLACK" Width="200px">Shooting Time<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlshootingtime" runat="server"   class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Day</asp:ListItem>
                                                                    <asp:ListItem Value="2">Night</asp:ListItem>
                                                                    <asp:ListItem Value="3">Day&Night</asp:ListItem>
                                                                    
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr >
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">6</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label459" runat="server" CssClass="LBLBLACK" Width="200px">Director<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtdirector" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="180" TabIndex="1" onkeypress="Names()"
                                                                     ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">7</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label460" runat="server" CssClass="LBLBLACK" Width="200px">Cameraman<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtcameraman" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="180" TabIndex="1" onkeypress="Names()"
                                                                     ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">8</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Main Artists<font color="red">*</font></td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                 <asp:TextBox ID="txtmainartists" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="180" TabIndex="1"
                                                                     ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">9</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">  <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">Total Crew Number<font color="red">*</font></asp:Label></td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                 <asp:TextBox ID="txttotalcrewno" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="180" TabIndex="1" onkeypress="NumberOnly()"
                                                                     ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">10</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"><asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">Proposed shooting Schedule in detail (indoor/outdoor/ Song/scene) with description<font color="red">*</font></asp:Label></td>
                                                            <td class="style7" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                 <asp:TextBox ID="txtproposedshootingscheduule" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="180" TabIndex="1"
                                                                     ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server"><b>Location and Fee Details </b></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3" align="center">
                                                    <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="180px">Location Name </asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddllocationname" runat="server"  class="form-control txtbox" AutoPostBack="true"
                                                                    Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddllocationname_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    
                                                                    
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                            <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="200px">From Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtfromdate" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                                    MaxLength="40"  TabIndex="1" ValidationGroup="group"  
                                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                                            <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="200px">To Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txttodate" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"  AutoPostBack="true" OnTextChanged="txttodate_TextChanged"
                                                                    MaxLength="40"  TabIndex="1" ValidationGroup="group"  
                                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;4.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="180px">Blocking Days</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtblockingdays" runat="server" class="form-control txtbox" Enabled="false"
                                                                    Height="28px" MaxLength="30" TabIndex="1" onkeypress="NumberOnly()"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                             <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;5.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="180px">Shooting Days</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtshootingdays" runat="server" class="form-control txtbox" OnTextChanged="txtshootingdays_TextChanged"
                                                                    Height="28px" MaxLength="30" TabIndex="1" onkeypress="NumberOnly()" AutoPostBack="true"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        
                                                        <tr >
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;6.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;<asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="180px">Number of Police Persons Required</asp:Label></td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtnoofpolicepersionsrequired" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="30" TabIndex="1" OnTextChanged="txtnoofpolicepersionsrequired_TextChanged" AutoPostBack="true"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <%--<tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                                                colspan="3">
                                                                <asp:Label ID="Label430" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                    Width="450px">Reference by which Plans approved by the Chief Inspector (if applicable).</asp:Label>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;7.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="180px">Price per Location ( ₹ )</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtpriceperlocation" runat="server" class="form-control txtbox" Enabled="false"
                                                                    Height="28px" MaxLength="30" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        
                                                        
                                                    </table></td>
                                                    <td class="style11" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    <td class="style10" style="padding: 5px; margin: 5px"><table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: center;">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="180px"><b>Fee Details(₹)</b> </asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                            <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="200px">Shooting Fee(₹)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtshootingfee" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off" Enabled="false"
                                                                    MaxLength="40"  TabIndex="1" ValidationGroup="group"  
                                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                &nbsp;</td>
                                        </tr>
                                                            <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px">Caution Deposit(₹)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtcautiondeposit" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"  Enabled="false"
                                                                    MaxLength="40"  TabIndex="1" ValidationGroup="group"  
                                                                    Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txttodate"
                                                    ErrorMessage="Please enter to date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;3.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="180px">Service Fee(₹)</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtservicefee" runat="server" class="form-control txtbox" Enabled="false"
                                                                    Height="28px" MaxLength="30" TabIndex="1" onkeypress="NumberOnly()"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                             <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;4.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="180px">Police Fee(₹)</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtpolicefee" runat="server" class="form-control txtbox" Enabled="false"
                                                                    Height="28px" MaxLength="30" TabIndex="1" onkeypress="NumberOnly()"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        
                                                        <tr >
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;5.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;<asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="180px">GST(₹)d</asp:Label></td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtgst" runat="server" class="form-control txtbox" Enabled="false"
                                                                    Height="28px" MaxLength="30" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <%--<tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                                                colspan="3">
                                                                <asp:Label ID="Label430" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                                    Width="450px">Reference by which Plans approved by the Chief Inspector (if applicable).</asp:Label>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;6.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="180px">Extra Hours Amount(₹)</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtextrahorsamount" runat="server" class="form-control txtbox" Enabled="false"
                                                                    Height="28px" MaxLength="30" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;7.</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="180px">Total Amount(₹)</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txttotalamount" runat="server" class="form-control txtbox" Enabled="false"
                                                                    Height="28px" MaxLength="30" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table></td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                </tr>
                                                    <tr >
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:CheckBox ID="chkdepartmentname" runat="server" /><asp:Label ID="Label22" runat="server">  I agreee to the terms & conditions of</asp:Label>
                                                            <%--<asp:HyperLink ID="hyperdepartmentname" runat="server"></asp:HyperLink>--%>
                                                           <b> <asp:Label ID="lbldepartmentname" runat="server"></asp:Label></b>

                                                        </td>
                                                        <td>

                                                        </td>
                                                    </tr>
                                                    <tr >
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:CheckBox ID="chktermsandconditions" runat="server" />
                                                            <asp:Label ID="Label23" runat="server">I accept Film Development Corporation Terms and conditions. </asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr >
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:CheckBox ID="chkparticularsfurnished" runat="server" />
                                                            <asp:Label ID="Label24" runat="server">I certify that the particulars furnished above are true.</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr >
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:CheckBox ID="chkundertake" runat="server" />
                                                            <asp:Label ID="Label25" runat="server">  I undertake to reimburse the damages caused if any, during the above film shooting from the caution
                                                                deposit amount to the respective department/organization/Institution.</asp:Label>                                                     
                                                        </td>
                                                    </tr>
                                                    <tr id="trpolicedetails" runat="server" >
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                                            &nbsp;&nbsp;<%--<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px" OnClick="btnNext_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />--%><%--     &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger" Height="32px" OnClick="btnNext0_Click" TabIndex="10" Text="Previous" ValidationGroup="group" Width="90px" />&nbsp;--%><asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                            <asp:Button ID="btnPayment" runat="server" CssClass="btn btn-danger" Height="32px"
                                                    TabIndex="10" Text="PAYMENT" Width="90px" ValidationGroup="group" OnClick="BtnDelete_Click" Visible="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                            <div id="success" runat="server" class="alert alert-success" visible="false">
                                                                <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdnapplicationid" runat="server" />
                                        <asp:HiddenField ID="hdnidentityid" runat="server" />
                                        <asp:HiddenField ID="hdnTransactionNumber" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </div>
            <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />

</div>
    
</div>
</ProgressTemplate>
</asp:UpdateProgress> --%>

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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

