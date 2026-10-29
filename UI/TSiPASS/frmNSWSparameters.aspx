<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmNSWSparameters.aspx.cs" Inherits="UI_TSiPASS_frmNSWSparameters" %>

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
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupfrmClosedUnits.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "1920:" + (date.getFullYear());

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var yrRange = "1920:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });
            $("input[id$='txtTodate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        });
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Central Approval</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <%--<div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    CLOSED UNIT REGISTRATION</h3>
                            </div>--%>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <div class="row">
                                            <table>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="inputdefault">
                                                                PAN NO</label>
                                                            <asp:TextBox ID="txtpanno" runat="server" OnTextChanged="txtpanno_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                            <%--<asp:TextBox class="form-control" id="inputIncId" type="text"></asp:TextBox>--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="inputdefault">
                                                                Unit Name</label>
                                                            <asp:TextBox ID="txtunitname" runat="server"></asp:TextBox>
                                                            <%--  <input class="form-control" id="inputUnit" type="text">--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="selDist">
                                                                Date of Birth</label>
                                                            <asp:TextBox ID="txtFromDate" runat="server" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <%--<input type="button" id="btnSearch" class="btn btn-success" style="margin-top: 0px;" value="Search" />--%>
                                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-success" Text="Validate" OnClick="btnSearch_Click" />
                                                        <asp:Label ID="lblpanstatus" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" id="cintr" runat="server" visible="false">
                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label for="inputdefault">
                                                                    Please Enter CIN Number</label>
                                                                <asp:TextBox ID="txtcinnumber" runat="server" AutoPostBack="true" OnTextChanged="txtcinnumber_TextChanged" Width="150%"></asp:TextBox>
                                                                <%--  <input class="form-control" id="inputUnit" type="text">--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%" id="nsws" runat="server" visible="false">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">

                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">1</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">fullname<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">

                                                                <asp:TextBox ID="txtfullname" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">2</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="165px">email</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtemail" runat="server" Width="175px" TextMode="MultiLine"></asp:TextBox>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">3&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="165px">Mobile Number<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtmobilenumber" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">4&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Entity Type<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlentitytype" Width="175px" runat="server"></asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">5&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">PAN<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtpan" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">Registered Address</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">6</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="165px">Country<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlcountry_regaddr" runat="server" Width="178px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">7</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="165px">State<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlstate_regaddr" runat="server"></asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">8</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddldistrict_regaddr" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_regaddr_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">9</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlmandal_regaddr" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlmandal_regaddr_SelectedIndexChanged"></asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">10</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlvillage_regaddr" runat="server" Width="175px"></asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">11&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Sy.No<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtsyno_regaddr" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">12&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">City<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtcity_regaddr" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">13</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Pincode<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtpincode_regaddr" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>






                                                    </table>

                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">


                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="width: 200px;">
                                                                <%--<asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">CIN<font 
                                                            color="red">*</font></asp:Label>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">

                                                                <%-- <asp:TextBox ID="" runat="server"></asp:TextBox>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">15</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="165px">Name of Unit<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtnameofunit" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;     
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">16</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="165px">Company Name<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtcompanyname" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">17</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="165px">llpin<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtllpin" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="165px">Postal Address</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">18</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="165px">Country<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlpostalcountry" runat="server" Width="175px" AutoPostBack="true" OnSelectedIndexChanged="ddlpostalcountry_SelectedIndexChanged"></asp:DropDownList>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">19</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="165px">State<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlpostalstate" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlpostalstate_SelectedIndexChanged"></asp:DropDownList>
                                                                <asp:TextBox ID="txtpostalstate" runat="server" Visible="false"></asp:TextBox>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">20</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlpostaldistrict" runat="server" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="ddlpostaldistrict_SelectedIndexChanged"></asp:DropDownList>
                                                                <asp:TextBox ID="txtpostaldistrict" runat="server" Visible="false"></asp:TextBox>


                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">21</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlpostalmandal" runat="server" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="ddlpostalmandal_SelectedIndexChanged"></asp:DropDownList>
                                                                <asp:TextBox ID="txtpostalmandal" runat="server" Visible="false"></asp:TextBox>


                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">22</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlpostalvillage" runat="server" Width="100%"></asp:DropDownList>
                                                                <asp:TextBox ID="txtpostalvillage" runat="server" Visible="false"></asp:TextBox>


                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">23</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="165px">Sy.No<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtsyno_postaladdr" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">24</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="165px">city<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtpostalcity" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">25</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="165px">Pincode<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtpostalpincode" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                                
                                                              
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="save" runat="server" visible="false">
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BTNSAVE" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        TabIndex="10" Text="Save Details" Width="150px" OnClick="BTNSAVE_Click"
                                                        ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:GridView ID="grdcindata1" runat="server" AutoGenerateColumns="True"
                                                        CellPadding="5" ForeColor="#333333" Height="62px"
                                                        ShowFooter="True" Width="80%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:GridView ID="grdcindata2" runat="server" AutoGenerateColumns="True"
                                                        CellPadding="5" ForeColor="#333333" Height="62px"
                                                        ShowFooter="True" Width="100%">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="btnclick" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        TabIndex="10" Text="Click here for Central Approval" Width="250px" OnClick="btnclick_Click"
                                                        ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                </td>
                                            </tr>

                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                        <asp:HiddenField ID="hdnPanSignature" runat="server" />
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
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
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
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
     
</asp:Content>

