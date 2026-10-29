<%@ page title="" language="C#" masterpagefile="~/UI/TSIPASS/CCMaster.master" autoeventwireup="true" codefile="StampDutyTransferdutyAnnex1.aspx.cs" inherits="UI_TSIPASS_StampDutyTransferdutyAnnex1" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
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
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
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
    <asp:updatepanel id="upd1" runat="server">
        <triggers>
            <asp:postbacktrigger controlid="btnUpload1" />
            <asp:postbacktrigger controlid="btnUpload2" />
        </triggers>
        <contenttemplate>
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
                                        <asp:label id="lblheadTPRIDE" runat="server" visible="false" text="APPLICATION CUM VERIFICATION FOR CLAIMING INVESTMENT SUBSIDY UNDER T-PRIDE—TELANGANA STATE PROGRAM FOR 
                                        RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME.(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)
                                        PART - A CLAIM"></asp:label>
                                        <asp:label id="lblheadTIDEA" runat="server" visible="false" text="APPLICATION CUM VERIFICATION FOR CLAIMING REIMBURSEMENT OF STAMP DUTY
/ TRANSFER DUTY / MORTGAGE DUTY / LAND CONVESERSION CHARGES /
REIMBURSEMENT OF LAND COST PURCHASED IN IE/IDA/IP’s UNDER T-IDEA
(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR
ADVANCEMENT) INCENTIVE SCHEME 2014"></asp:label>
                                        <asp:label id="lblMSMEPolicy" runat="server" visible="false" forecolor="White" font-bold="true" font-size="20px" text="Application for claiming Reimbursement of Stamp Duty
                                            / Transfer Duty Under MSME Policy"></asp:label>
                                        <asp:hiddenfield id="hdnMSMEApplied" runat="server" />
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
                        <asp:updatepanel id="UpdatePanel1" runat="server">
                            <contenttemplate>
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
                                                            <asp:label id="Label387" runat="server" cssclass="LBLBLACK" width="210px">Area as per registered sale deed in Sq Mts.<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; vertical-align: text-top;" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                            <asp:textbox id="txtAreaRegdSaledeed" runat="server" class="form-control txtbox"
                                                                height="28px" onkeypress="return inputOnlyNumbers(event)" maxlength="40" tabindex="1"
                                                                validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txtAreaRegdSaledeed"
                                                                errormessage="Please enter Area as per registered sale deed" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1.2
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 120PX;" valign="top">
                                                            <asp:label id="Label396" runat="server" cssclass="LBLBLACK" width="200px">Plinth area of the building as per approved plan By HMDA / DT&CP /KUDA / IALA in Sq. Mts<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:textbox id="txtPlnthAreaBuild" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                height="28px" maxlength="40" tabindex="1" validationgroup="group" width="180px" ontextchanged="txtPlnthAreaBuild_TextChanged" autopostback="True">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" valign="top">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" controltovalidate="txtPlnthAreaBuild"
                                                                errormessage="Please enter Plinth area of the building" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1.3
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:label id="Label351" runat="server" cssclass="LBLBLACK" width="200px" height="50px">5 times of the plinth area of factory building in Sq. Mts<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:textbox id="txtFivePlnthAreaBuild" runat="server" class="form-control txtbox"
                                                                onkeypress="return inputOnlyNumbers(event)" height="28px" maxlength="30" tabindex="1"
                                                                validationgroup="group" width="180px" enabled="false">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" controltovalidate="txtFivePlnthAreaBuild"
                                                                errormessage="Please enter 5 times of the plinth area" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1.4
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:label id="Label10" runat="server" cssclass="LBLBLACK" width="200px">Area required for the factory as per the appraisal in Sq. Mts.<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:textbox id="txtAreaReqdAppraisal" runat="server" class="form-control txtbox"
                                                                onkeypress="return inputOnlyNumbers(event)" height="28px" maxlength="30" tabindex="1"
                                                                validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator29" runat="server" controltovalidate="txtAreaReqdAppraisal"
                                                                errormessage="Please enter  Area required for the factory as per the appraisal"
                                                                validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1.5
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 120PX;" valign="top">
                                                            <asp:label id="Label11" runat="server" cssclass="LBLBLACK" width="200px">Area required for the factory as per the norms of TSPCB or any other state govt. department in Sq. Mts.<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:textbox id="txtAreaReqdTSPCB" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                height="28px" maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator30" runat="server" controltovalidate="txtAreaReqdTSPCB"
                                                                errormessage="Please enter  Area required for the factory as per TSPCB" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
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
                                                            <asp:label id="Label1" runat="server" cssclass="LBLBLACK" width="210px">Nature of transaction / deed registered for industrial use <font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                            <asp:dropdownlist id="txtNatureofTrans" runat="server" class="form-control txtbox"
                                                                height="33px" width="180px" autopostback="True">
                                                                <asp:listitem value="Sale Deed">Sale Deed</asp:listitem>
                                                                <asp:listitem value="Lease Deed">Lease Deed</asp:listitem>
                                                                <asp:listitem value="Mortgage">Mortgage</asp:listitem>
                                                                <asp:listitem value="LandConversion">Mortgage</asp:listitem>
                                                                <asp:listitem value="TransferDeed">Mortgage</asp:listitem>
                                                            </asp:dropdownlist>

                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="txtNatureofTrans"
                                                                errormessage="Please enter Nature of transaction" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 35px" valign="top">2.2
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 120PX;" valign="top">
                                                            <asp:label id="Label2" runat="server" cssclass="LBLBLACK" width="200px">Sub Registrar office<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:textbox id="txtSubRegOffc" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                height="28px" maxlength="40" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="txtSubRegOffc"
                                                                errormessage="Please enter Sub Registrar office" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; height: 50px" valign="top">2.3
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:label id="Label3" runat="server" cssclass="LBLBLACK" width="200px">Registered Document number<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:textbox id="txtRegdDeedNo" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                height="28px" maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" controltovalidate="txtRegdDeedNo"
                                                                errormessage="Please enter  Registered deed number" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" valign="top">2.4
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle" valign="top">
                                                            <asp:label id="Label4" runat="server" cssclass="LBLBLACK" width="200px">Date Of Registration<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:textbox id="txtRegDate" runat="server" class="form-control txtbox" height="28px"
                                                                maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" controltovalidate="txtRegDate"
                                                                errormessage="Please enter Date Of Registration" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
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
                                                            <asp:textbox id="txtStampTranfrDutyAP" runat="server" class="form-control txtbox"
                                                                maxlength="30" onkeypress="return inputOnlyNumbers(event)" tabindex="1"
                                                                validationgroup="group" width="150px">
                                                            </asp:textbox>

                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black; width: 150px" valign="middle">
                                                            <asp:textbox id="txtStampTranfrDutyAC" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="30" onkeypress="return inputOnlyNumbers(event)" tabindex="1"
                                                                validationgroup="group" width="150px">
                                                            </asp:textbox>

                                                        </td>
                                                        <td>
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" controltovalidate="txtStampTranfrDutyAP"
                                                                errormessage="Please enter Stamp Tranfer Duty Amount Paid" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" controltovalidate="txtStampTranfrDutyAC"
                                                                errormessage="Please enter Stamp Tranfer Duty Amount Claimed" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" visible="false" id="trduty1">
                                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; background: white; color: black"
                                                            valign="top">3.2
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black" valign="top">Mortgage & Hypothecations Duty
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:textbox id="txtMortgageHypothDutyAP" text="0" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="30" onkeypress="inputOnlyNumbers(evt)" tabindex="1"
                                                                validationgroup="group" width="150px">
                                                            </asp:textbox>

                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:textbox id="txtMortgageHypothDutyAC" text="0" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="30" onkeypress="inputOnlyNumbers(evt)" tabindex="1"
                                                                validationgroup="group" width="150px">
                                                            </asp:textbox>

                                                        </td>
                                                        <td>
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" controltovalidate="txtMortgageHypothDutyAP"
                                                                errormessage="Please enter Mortgage Hypothications Duty Amount Paid" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" controltovalidate="txtRegDate"
                                                                errormessage="Please enter Mortgage Hypothications Duty Amount Claimed" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" visible="false" id="trduty2">
                                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; background: white; color: black"
                                                            valign="top">3.3
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black" valign="top">Land Conversion charges
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:textbox id="txtLandConvrChrgAP" runat="server" text="0" class="form-control txtbox" height="28px"
                                                                maxlength="30" onkeypress="inputOnlyNumbers(evt)" tabindex="1" validationgroup="group"
                                                                width="150px">
                                                            </asp:textbox>

                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:textbox id="txtLandConvrChrgAC" runat="server" text="0" class="form-control txtbox" height="28px"
                                                                maxlength="30" onkeypress="inputOnlyNumbers(evt)" tabindex="1" validationgroup="group"
                                                                width="150px">
                                                            </asp:textbox>

                                                        </td>
                                                        <td>
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator13" runat="server" controltovalidate="txtLandConvrChrgAC"
                                                                errormessage="Please enter Land Conversion Charges Amount Claimed" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator12" runat="server" controltovalidate="txtLandConvrChrgAP"
                                                                errormessage="Please enter Land Convrersion Charges Amount Paid" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>


                                                        </td>
                                                    </tr>
                                                    <tr runat="server" visible="false" id="trduty3">
                                                        <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; background: white; color: black"
                                                            valign="top">3.4
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black" valign="top">Cost of land in case of purchase in IE / IDA / IP
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:textbox id="txtLandCostIeIdaIpAP" text="0" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="30" onkeypress="inputOnlyNumbers(evt)" tabindex="1"
                                                                validationgroup="group" width="150px">
                                                            </asp:textbox>

                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black" valign="top">
                                                            <asp:textbox id="txtLandCostIeIdaIpAC" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="30" text="0" onkeypress="inputOnlyNumbers(evt)" tabindex="1"
                                                                validationgroup="group" width="150px">
                                                            </asp:textbox>

                                                        </td>
                                                        <td>
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator14" runat="server" controltovalidate="txtLandCostIeIdaIpAP"
                                                                errormessage="Please enter  S/O  Promoter" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator15" runat="server" controltovalidate="txtStampTranfrDutyAC"
                                                                errormessage="Please Enter Stamp Tranfer Duty Amount Claimed" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>

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
                                                            <asp:fileupload id="fuDocuments1" runat="server" cssclass="CS" />
                                                            <asp:button id="btnUpload1" runat="server" text="Click here to Upload" onclick="btnUpload1_Click" />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:hyperlink id="lblupload1" runat="server" cssclass="LBLBLACK" width="165px" target="_blank">[lblFileName]</asp:hyperlink>
                                                            <asp:label id="lblAttachedFileName1" runat="server" font-bold="true" forecolor="Green"
                                                                visible="false" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr1" runat="server">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">2
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">Attested Copy of payment proof
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:fileupload id="fuDocuments2" runat="server" cssclass="CS" />
                                                            <asp:button id="btnUpload2" runat="server" text="Click here to Upload" onclick="btnUpload2_Click" />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:hyperlink id="lblUpload2" runat="server" cssclass="LBLBLACK" width="165px" target="_blank">[lblFileName]</asp:hyperlink>
                                                            <asp:label id="lblAttachedFileName2" runat="server" font-bold="true" forecolor="Green"
                                                                visible="false" />
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
                                                <asp:label id="lblscheme" runat="server"></asp:label>
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
                                                <asp:button id="BtnSave" runat="server" cssclass="btn btn-primary" height="32px"
                                                    tabindex="10" text="Submit" width="90px" validationgroup="group" onclick="BtnSave_Click" />
                                                &nbsp;&nbsp;
                                                <asp:button id="BtnPrevious" runat="server" cssclass="btn btn-danger" height="32px"
                                                    tabindex="10" text="Previous" width="90px" onclick="BtnPrevious_Click" />
                                                &nbsp; &nbsp;&nbsp;<asp:button id="BtnNext" runat="server" cssclass="btn btn-danger"
                                                    height="32px" tabindex="10" text="Next" width="90px" validationgroup="group" enabled="false"
                                                    onclick="BtnNext_Click" />
                                                &nbsp; &nbsp;<asp:button id="BtnClear" runat="server" causesvalidation="False" cssclass="btn btn-warning"
                                                    height="32px" tabindex="10" text="ClearAll" tooltip="To Clear  the Screen" width="90px"
                                                    onclick="BtnClear_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong></strong>
                                                    <asp:label id="lblmsg" runat="server"></asp:label>
                                                </div>
                                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                    <asp:label id="lblmsg0" runat="server"></asp:label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </contenttemplate>
                        </asp:updatepanel>
                        <%--  </div>--%>
                    </div>
                </div>
            </div>
            <asp:updateprogress id="UpdateProgress" runat="server" associatedupdatepanelid="upd1">
                <progresstemplate>
                    <div class="update">
                    </div>
                </progresstemplate>
            </asp:updateprogress>
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
        </contenttemplate>
    </asp:updatepanel>
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
</asp:content>

