<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmcoispeechMSMEDATA.aspx.cs" Inherits="UI_TSiPASS_frmcoispeechMSMEDATA" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <%--<script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>--%>
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

        .auto-style6 {
            width: 137px;
        }

        .auto-style8 {
            width: 42px;
        }

        .auto-style9 {
            width: 424px;
        }

        .auto-style12 {
            width: 345px
        }

        .auto-style13 {
            width: 45px;
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
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">LINE OF ACTIVITY</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Industries Department Speech Note:</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top"
                                                    colspan="3">
                                                    <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="136px">Targets Completed</asp:Label>
                                                    <asp:Label ID="lblmsg1" runat="server" Font-Bold="True"></asp:Label>
                                                    /<asp:Label ID="lblmsg2" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top"></td>


                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">

                                                    <table cellpadding="14" cellspacing="15" width="70%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" ></td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" class="auto-style9">Confirmed as on date</span></td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="TXTMSMEUNITSREGYEAR_UNTILL" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" onkeypress="NumberOnly()" Enabled="false" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5" style="padding-top:15px">1. IIPC Section: </td>
                                                           
                                                        </tr>
                                                        <tr>

                                                            <td style="padding: 5px; width: 20px; margin: 5px; vertical-align: central" >1a.&nbsp;</td>
                                                            <td class="auto-style12">The year for which DPIIT has communicated set of reforms </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtDBIITYEAR" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" >1b.&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" class="auto-style9">
                                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="294px">No of Reforms DPIIT communicated<font
                                                                    color="red" id="fn10" runat="server"></font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TXTNOOFREFORMS" runat="server" onkeypress="NumberOnly()" class="form-control txtbox" AutoComplete="off"
                                                                    Height="28px" MaxLength="13" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>


                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;                                                            
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" >1c.</td>
                                                            <td class="auto-style12">
                                                                <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="304px">Year for which Telangana stood among the top achievers for the year<font
                                                                    color="red" id="fn4" runat="server"></font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TXTTOPACHIEVERYEAR" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="100" TabIndex="1" AutoComplete="off"
                                                                    ValidationGroup="group" Width="180px"
                                                                    onkeypress="NumberOnly()"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                              
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                           
                                                            <td colspan="5" style="padding-top:25px"> 2. MSME:</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" >2a</td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" class="auto-style9">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="315px">No of Sick Units assisted by TIHCL.<font
                                                                    color="red" id="fn11" runat="server"></font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="TXTNOOFSICKUNITS" runat="server"
                                                                    class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" onkeypress="NumberOnly()"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;
                                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: central;" >2b. </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style12">No of Units registered under UDYAM   
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TXTNOOFMSMEUNITS" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" >2c. </td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style12">No of cases filed under TSMSEFC&nbsp; 
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtnoofapplicationsfiled" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" onkeypress="NumberOnly()" Width="180px"></asp:TextBox>

                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" >2d.&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" class="auto-style9">Total cases disposed</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="TXTNOOFCASES" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" onkeypress="NumberOnly()" Width="180px"></asp:TextBox>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" >2e.&nbsp;</td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style12">Amount involved in disposed cases (In Cr)
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TXTAMOUNTDISPOSED" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" onkeypress="NumberOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        
                                                        
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" >2f.&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: central" class="auto-style9">Technology/Extension Centers Investment(In lacks)</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txttechorextcentersinvestment" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>

                                                        
                                                        
                                                        
                                                        


                                                    </table>

                                                </td>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="20px"></asp:Label>
                                                </td>
                                                <td valign="top" visible="false" runat="server">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style6">4&nbsp;</td>
                                                            <td class="auto-style9">Amount to setting up Telangana Industrial Health Clinic as Non-Banking Finance Company(NBFC)(In Cr.)</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TXTAMOUNTSETTINGUPFORNBFC" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px" onkeypress="DecimalOnly()"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>

                                                        <tr runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style13">5&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style12">The amount funded by Telangana Govt(In Cr)</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TXTAMOUNTFOUNDEDBYTGGOVT" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="100" TabIndex="1" AutoComplete="off"
                                                                    ValidationGroup="group" Width="180px"
                                                                    onkeypress="NumberOnly()"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>

                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style13">13&nbsp;</td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style12">Budget Allocated(T-IDEA)<span style="color: rgb(51, 51, 51); font-family: &quot; helvetica neue&quot; , helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">(In Cr)</span></td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TXTBUDGETALLOCATEDTIDEA" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style6">14&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style9">Budget Released(T-IDEA)<span style="color: rgb(51, 51, 51); font-family: &quot; helvetica neue&quot; , helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">(In Cr)</span></td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="TXTBUDGETRELEASEDTIDEA" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style13">15&nbsp;</td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style12">Budget Pending(T-IDEA)<span style="color: rgb(51, 51, 51); font-family: &quot; helvetica neue&quot; , helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">(In Cr)</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TXTBUDGETPENDINGTIDEA" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style6">16&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style9">Budget Utilized(T-IDEA)<span style="color: rgb(51, 51, 51); font-family: &quot; helvetica neue&quot; , helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">(In Cr)</span></td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="TXTBUDGETUNILIZEDTIDEA" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style13">17&nbsp;</td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style12">Budget Allocated(T-PRIDE)<span style="color: rgb(51, 51, 51); font-family: &quot; helvetica neue&quot; , helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">(In Cr)</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TXTBUDGETALLOCATEDTPRIDE" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style6">18&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style9">Budget Released(T-PRIDE)<span style="color: rgb(51, 51, 51); font-family: &quot; helvetica neue&quot; , helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">(In Cr)</span></td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="TXTBUDGETRELEASEDTPRIDE" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style13">19&nbsp;</td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style12">Budget Pending(T-PRIDE)<span style="color: rgb(51, 51, 51); font-family: &quot; helvetica neue&quot; , helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">(In Cr)</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="TXTBUDGETPENDINGTPRIDE" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style6">20</td>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top" class="auto-style9">Budget Utilized(T-PRIDE)<span style="color: rgb(51, 51, 51); font-family: &quot; helvetica neue&quot; , helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">(In Cr)</span></td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="TXTBUDGETUNILIZEDTPRIDE" runat="server" class="form-control txtbox" Height="28px" TabIndex="1" ValidationGroup="group" onkeypress="DecimalOnly()" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="center" colspan="3"
                                                    style="padding: 5px; margin: 5px; text-align: center; width: 100px">
                                                    <div class="row">
                                                    </div>




                                                    <%--  Adding New Fields--%>


                                                    <%--    //upto Here--%>
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" Width="90px"
                                                        ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                        Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            </tr>
                                        </table>
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
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='TxtDateofCloser']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='TxtDateofCloserFirst']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

            $("input[id$='txttermload']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtdatesome']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtCSTRegDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            //added newly
            $("input[id$='txtUdyogAadhaarRegdDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtGSTDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='TxtDateofCloser']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='TxtDateofCloserFirst']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback   

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txttermload']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtdatesome']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtCSTRegDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 
            //added newly
            $("input[id$='txtGSTDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

        });
    </script>
</asp:Content>
