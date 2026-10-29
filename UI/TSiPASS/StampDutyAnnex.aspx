<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="StampDutyAnnex.aspx.cs" Inherits="UI_TSiPASS_IncentivesAnnexure_StampDutyAnnex" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/basic.css" rel="stylesheet" />
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

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }

        .update {
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

        .style5 {
            color: #FF0000;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
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
        function alpha(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k >= 48 && k <= 57) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>
    <script type="text/javascript">
        function Names() {
            var AsciiValue = event.keyCode
            //if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 47 && AsciiValue <= 57) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                //alert("Enter Alphabets, '.' and Space Only");
                alert("Enter Alphabets,Digits,'/',''.' and Space Only");
            }
        }
    </script>
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 6) {
                alert("Pin number length must be exactly 6 characters")
            }
        }
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload1" />
            <asp:PostBackTrigger ControlID="btnUpload2" />
        </Triggers>
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i></li>
                </ol>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="background-color: #339966">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblheadTPRIDE" runat="server" Visible="false" Text="APPLICATION CUM VERIFICATION FOR CLAIMING INVESTMENT SUBSIDY UNDER T-PRIDE—TELANGANA STATE PROGRAM FOR 
                                        RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME.(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)
                                        PART - A CLAIM">
                                        </asp:Label>
                                        <asp:Label ID="lblheadTIDEA" runat="server" Visible="false" Text="APPLICATION CUM VERIFICATION FOR CLAIMING REIMBURSEMENT OF STAMP DUTY
/ TRANSFER DUTY / MORTGAGE DUTY / LAND CONVESERSION CHARGES /
REIMBURSEMENT OF LAND COST PURCHASED IN IE/IDA/IP’s UNDER T-IDEA
(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR
ADVANCEMENT) INCENTIVE SCHEME 2014">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="panel-body" align="left">
                                    <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;" valign="top">1
                                                        </td>
                                                        <td colspan="8" style="font: bold; font-weight: bold" valign="top">Land purchased details
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1.1
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 80px;" valign="top">
                                                            <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Area as per registered sale deed in Sq Mts.<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                            <asp:TextBox ID="txtAreaRegdSaledeed" runat="server" class="form-control txtbox"
                                                                Height="28px" onkeypress="return inputOnlyNumbers(event)" MaxLength="40" TabIndex="1"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAreaRegdSaledeed"
                                                                ErrorMessage="Please enter Area as per registered sale deed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1.2
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 120PX;" valign="top">
                                                            <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="200px">Plinth area of the building as per approved plan By HMDA / DT&CP /KUDA / IALA in Sq. Mts<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:TextBox ID="txtPlnthAreaBuild" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtPlnthAreaBuild_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPlnthAreaBuild"
                                                                ErrorMessage="Please enter Plinth area of the building" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1.3
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="200px" Height="50px">5 times of the plinth area of factory building in Sq. Mts<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:TextBox ID="txtFivePlnthAreaBuild" runat="server" class="form-control txtbox"
                                                                onkeypress="return inputOnlyNumbers(event)" Height="28px" MaxLength="30" TabIndex="1"
                                                                ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFivePlnthAreaBuild"
                                                                ErrorMessage="Please enter 5 times of the plinth area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1.4
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="200px">Area required for the factory as per the appraisal in Sq. Mts.<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:TextBox ID="txtAreaReqdAppraisal" runat="server" class="form-control txtbox"
                                                                onkeypress="return inputOnlyNumbers(event)" Height="28px" MaxLength="30" TabIndex="1"
                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtAreaReqdAppraisal"
                                                                ErrorMessage="Please enter  Area required for the factory as per the appraisal"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1.5
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 120PX;" valign="top">
                                                            <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="200px">Area required for the factory as per the norms of TSPCB or any other state govt. department in Sq. Mts.<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:TextBox ID="txtAreaReqdTSPCB" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtAreaReqdTSPCB"
                                                                ErrorMessage="Please enter  Area required for the factory as per TSPCB" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" valign="top">2
                                                        </td>
                                                        <td colspan="8" style="font: bold; font-weight: bold" valign="top">Registered Deed Details
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2.1
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 80px;" valign="top">
                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="210px">Nature of transaction / deed registered for industrial use <font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                            <asp:DropDownList ID="txtNatureofTrans" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="True">
                                                                <asp:ListItem Value="Sale Deed">Sale Deed</asp:ListItem>
                                                                <asp:ListItem Value="Lease Deed">Lease Deed</asp:ListItem>
                                                                <asp:ListItem Value="Mortgage">Mortgage</asp:ListItem>
                                                                <asp:ListItem Value="LandConversion">Mortgage</asp:ListItem>
                                                                <asp:ListItem Value="TransferDeed">Mortgage</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNatureofTrans"
                                                                ErrorMessage="Please enter Nature of transaction" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 35px" valign="top">2.2
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 120PX;" valign="top">
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">Sub Registrar office<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:TextBox ID="txtSubRegOffc" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSubRegOffc"
                                                                ErrorMessage="Please enter Sub Registrar office" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 50px" valign="top">2.3
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Registered Document number<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:TextBox ID="txtRegdDeedNo" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRegdDeedNo"
                                                                ErrorMessage="Please enter  Registered deed number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" valign="top">2.4
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" valign="top">
                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="200px">Date Of Registration<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:TextBox ID="txtRegDate" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRegDate"
                                                                ErrorMessage="Please enter Date Of Registration" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top"></td>
                                                        <td style="padding: 5px; margin: 5px" valign="top"></td>
                                                        <td style="padding: 5px; margin: 5px" valign="top"></td>
                                                        <td style="padding: 5px; margin: 5px" valign="top"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;" valign="top"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: center;">
                                                <table style="width: 80%">
                                                    <tr>
                                                        <td align="left" style="padding: 5px; margin: 5px; font-weight: bold" valign="middle">3
                                                        </td>
                                                        <td colspan="3" style="font-weight: bold; text-align: left" valign="middle">Details of duty paid and claimed
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center" valign="top"></td>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center" valign="top">Nature Of Payment
                                                        </td>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center" valign="top">Amount Paid
                                                        </td>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center" valign="top">Amount Claimed
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; background: white; color: black"
                                                            valign="middle">3.1
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black" valign="middle">Stamp Duty / transfer duty
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black; width: 150px" valign="middle">
                                                            <asp:TextBox ID="txtStampTranfrDutyAP" runat="server" class="form-control txtbox"
                                                                MaxLength="30" onkeypress="inputOnlyNumbers(evt)" TabIndex="1"
                                                                ValidationGroup="group" Width="150px"></asp:TextBox>

                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black; width: 150px" valign="middle">
                                                            <asp:TextBox ID="txtStampTranfrDutyAC" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="30" onkeypress="inputOnlyNumbers(evt)" TabIndex="1"
                                                                ValidationGroup="group" Width="150px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtStampTranfrDutyAP"
                                                                ErrorMessage="Please enter Stamp Tranfer Duty Amount Paid" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtStampTranfrDutyAC"
                                                                ErrorMessage="Please enter Stamp Tranfer Duty Amount Claimed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; background: white; color: black"
                                                            valign="top">3.2
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black" valign="top">Mortgage & Hypothecations Duty
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:TextBox ID="txtMortgageHypothDutyAP" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="30" onkeypress="inputOnlyNumbers(evt)" TabIndex="1"
                                                                ValidationGroup="group" Width="150px"></asp:TextBox>

                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:TextBox ID="txtMortgageHypothDutyAC" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="30" onkeypress="inputOnlyNumbers(evt)" TabIndex="1"
                                                                ValidationGroup="group" Width="150px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtMortgageHypothDutyAP"
                                                                ErrorMessage="Please enter Mortgage Hypothications Duty Amount Paid" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtRegDate"
                                                                ErrorMessage="Please enter Mortgage Hypothications Duty Amount Claimed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; background: white; color: black"
                                                            valign="top">3.3
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black" valign="top">Land Conversion charges
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:TextBox ID="txtLandConvrChrgAP" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="30" onkeypress="inputOnlyNumbers(evt)" TabIndex="1" ValidationGroup="group"
                                                                Width="150px"></asp:TextBox>

                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:TextBox ID="txtLandConvrChrgAC" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="30" onkeypress="inputOnlyNumbers(evt)" TabIndex="1" ValidationGroup="group"
                                                                Width="150px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtLandConvrChrgAC"
                                                                ErrorMessage="Please enter Land Conversion Charges Amount Claimed" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtLandConvrChrgAP"
                                                                ErrorMessage="Please enter Land Convrersion Charges Amount Paid" ValidationGroup="group">*</asp:RequiredFieldValidator>


                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; background: white; color: black"
                                                            valign="top">3.4
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black" valign="top">Cost of land in case of purchase in IE / IDA / IP
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:TextBox ID="txtLandCostIeIdaIpAP" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="30" onkeypress="inputOnlyNumbers(evt)" TabIndex="1"
                                                                ValidationGroup="group" Width="150px"></asp:TextBox>

                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:TextBox ID="txtLandCostIeIdaIpAC" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="30" onkeypress="inputOnlyNumbers(evt)" TabIndex="1"
                                                                ValidationGroup="group" Width="150px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtLandCostIeIdaIpAP"
                                                                ErrorMessage="Please enter  S/O  Promoter" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtStampTranfrDutyAC"
                                                                ErrorMessage="Please Enter Stamp Tranfer Duty Amount Claimed" ValidationGroup="group">*</asp:RequiredFieldValidator>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: center;">
                                                <table style="width: 80%">
                                                    <tr>
                                                        <td colspan="4" align="left" style="padding: 5px; margin: 5px; font-weight: bold"
                                                            valign="middle">Enclosures
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center">Sl.No
                                                        </td>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center">Document Name
                                                        </td>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center">Upload Document
                                                        </td>
                                                        <td style="border: solid thin white; background: #013161; color: white" align="center">File Name
                                                        </td>
                                                    </tr>
                                                    <tr id="trEnclosures" runat="server">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">1
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">Attested copy of registered document
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:FileUpload ID="fuDocuments1" runat="server" CssClass="CS" />
                                                            <asp:Button ID="btnUpload1" runat="server" Text="Click here to Upload" OnClick="btnUpload1_Click" />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:HyperLink ID="lblupload1" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[lblFileName]</asp:HyperLink>
                                                            <asp:Label ID="lblAttachedFileName1" runat="server" Font-Bold="true" ForeColor="Green"
                                                                Visible="false" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr1" runat="server">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">2
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">Attested Copy of payment proof
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:FileUpload ID="fuDocuments2" runat="server" CssClass="CS" />
                                                            <asp:Button ID="btnUpload2" runat="server" Text="Click here to Upload" OnClick="btnUpload2_Click" />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:HyperLink ID="lblUpload2" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank">[lblFileName]</asp:HyperLink>
                                                            <asp:Label ID="lblAttachedFileName2" runat="server" Font-Bold="true" ForeColor="Green"
                                                                Visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>DECLARATION :  </b>
                                                <br />
                                                I am authorized to file this application and I will take full responsibility of the information mentioned. I / We
hereby confirm that to the best of our knowledge and belief, information given herein before and other
papers enclosed are true and correct in all respects. We further undertake to substantiate the particulars
about promoter(s) and other details with documentary evidence as and when called for. I/We hereby
agree that I/We shall forthwith repay the amount to me/us under   &nbsp;
                                                <asp:Label ID="lblscheme" runat="server"></asp:Label>
                                                &nbsp;, if the amount of Stamp
Duty/Transfer Duty / Mortgage Duty / Land Conversion Charges/ Land Cost are found to be disbursed in
excess of the amount actually admissible whatsoever the reason.
Authorisation by the other Partners/Board of Directors Resolution wherein the Name, Designation and
signature are attested.

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    TabIndex="10" Text="Submit" Width="90px" ValidationGroup="group" OnClick="BtnSave_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-danger" Height="32px"
                                                    TabIndex="10" Text="Previous" Width="90px" OnClick="BtnPrevious_Click" />
                                                &nbsp; &nbsp;&nbsp;<asp:Button ID="BtnNext" runat="server" CssClass="btn btn-danger"
                                                    Height="32px" TabIndex="10" Text="Next" Width="90px" ValidationGroup="group" Enabled="false"
                                                    OnClick="BtnNext_Click" />
                                                &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                    Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px"
                                                    OnClick="BtnClear_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong></strong>
                                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--  </div>--%>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
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

            $("input[id$='txtRegDate']").datepicker(
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
            $("input[id$='txtRegDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 200px;
        }

        .LBLBLACK {
        }
    </style>
</asp:Content>
