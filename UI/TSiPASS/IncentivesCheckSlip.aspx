<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true"
    codefile="IncentivesCheckSlip.aspx.cs" inherits="UI_TSiPASS_IncentivesAnnexure_IncentivesCheckSlip" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
            <asp:postbacktrigger controlid="Button101" />
            <asp:postbacktrigger controlid="Button102" />
            <asp:postbacktrigger controlid="Button103" />
            <asp:postbacktrigger controlid="Button104" />
            <asp:postbacktrigger controlid="Button105" />
            <asp:postbacktrigger controlid="Button106" />
            <asp:postbacktrigger controlid="Button201" />
            <asp:postbacktrigger controlid="Button202" />
            <asp:postbacktrigger controlid="Button203" />
            <asp:postbacktrigger controlid="Button204" />
            <asp:postbacktrigger controlid="Button205" />
            <asp:postbacktrigger controlid="Button206" />
            <asp:postbacktrigger controlid="Button207" />
            <asp:postbacktrigger controlid="Button208" />
            <asp:postbacktrigger controlid="Button209" />
            <asp:postbacktrigger controlid="Button210" />
            <asp:postbacktrigger controlid="Button211" />
            <asp:postbacktrigger controlid="Button212" />
            <asp:postbacktrigger controlid="Button213" />
            <asp:postbacktrigger controlid="Button214" />
            <asp:postbacktrigger controlid="Button215" />
            <asp:postbacktrigger controlid="Button216" />
            <asp:postbacktrigger controlid="Button217" />
            <asp:postbacktrigger controlid="Button218" />
            <asp:postbacktrigger controlid="Button219" />
            <asp:postbacktrigger controlid="Button220" />
            <asp:postbacktrigger controlid="Button221" />
            <asp:postbacktrigger controlid="Button222" />
            <asp:postbacktrigger controlid="Button223" />
            <asp:postbacktrigger controlid="Button224" />
            <asp:postbacktrigger controlid="Button225" />
            <asp:postbacktrigger controlid="Button226" />
            <asp:postbacktrigger controlid="Button227" />
            <asp:postbacktrigger controlid="Button228" />
            <asp:postbacktrigger controlid="Button229" />
            <asp:postbacktrigger controlid="btnBLAStatement_Brw" />
            <asp:postbacktrigger controlid="btnddlCCCoBorrwer" />
            <asp:postbacktrigger controlid="btnFacLicense" />
            <asp:postbacktrigger controlid="btnTMCStar" />
            <asp:postbacktrigger controlid="btnlocalemp1" />
            <asp:postbacktrigger controlid="btnlocalemp2" />
            <asp:postbacktrigger controlid="btndeetregack" />
            <asp:postbacktrigger controlid="btnCAMSME1" />
            <asp:postbacktrigger controlid="btnCivilCert" />
            <asp:postbacktrigger controlid="btnEnterpsriseDecl" />
            <asp:postbacktrigger controlid="btnloanstmt" />
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
                            <table class="nav-justified">
                                <tr>
                                    <td style="font-weight: bold;">Incentives Check Slip
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
                        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                        <div class="panel-body" align="left">
                            <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                                <tr>
                                    <td style="padding: 5px; margin: 5px" valign="top">
                                        <table cellpadding="4" cellspacing="5" width="100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center; font-weight: bold">1
                                                </td>
                                                <td colspan="8" style="font: bold; font-weight: bold">Documents to be enclosed
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">1.1
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 1000px; text-align: left;" valign="top">Certificate from the financing institution concerned showing term loan released
                                                    and the value of assets acquired as on prior to filing of claim/within 6 months
                                                    from the date of commencement of commercial production whichever is earlier together
                                                    with other details and machinery statement as a statement of account in the form
                                                    prescribed with attested copies of bills in case of institutionally financed Enterprises/industries.
                                                    (OR)
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 30px;" valign="top">
                                                    <asp:dropdownlist id="ddlCSbillsofinstitutfinancedEnterpriseindustries" runat="server"
                                                        autopostback="True" class="form-control txtbox" height="28px" maxlength="40"
                                                        tabindex="1" validationgroup="group" width="100px" onselectedindexchanged="ddlCSbillsofinstitutfinancedEnterpriseindustries_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <%-- NumberOnly()--%>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="ddlCSbillsofinstitutfinancedEnterpriseindustries"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 1.1" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fuDocuments1" runat="server" visible="false" />
                                                    <asp:button id="btnUpload1" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="btnUpload1_Click1" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="lblupload1" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                    </asp:hyperlink>
                                                    <asp:label id="lblAttachedFileName1" runat="server" font-bold="true" forecolor="Green"
                                                        visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle"></td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">List of Plant & Machinery & Equipment purchased and installed in the prescribed
                                                    form with attested copies of bills and payment proof in respect of self financed
                                                    Enterprises/industries.
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top">
                                                    <asp:dropdownlist id="ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries"
                                                        runat="server" autopostback="True" class="form-control txtbox" height="28px"
                                                        maxlength="40" tabindex="1" validationgroup="group" width="100px" onselectedindexchanged="ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 1.1" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload101" runat="server" visible="false" />
                                                    <asp:button id="Button101" runat="server" text="Click here to Upload" onclick="Button101_Click"
                                                        visible="False" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink101" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank" navigateurl='<%#Eval("FilePath") %>'>
                                                    </asp:hyperlink>
                                                    <asp:label id="Label101" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.2
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Caste Certificates issued by Tahsildar/ M.R.O&#39;s concerned in case of SC/ST Entrepreneur.
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: top">
                                                    <asp:dropdownlist id="ddlCSCasteCertificatesSCST" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSCasteCertificatesSCST_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" controltovalidate="ddlCSCasteCertificatesSCST"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 1.3" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload102" runat="server" visible="False" />
                                                    <asp:button id="Button102" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button102_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink102" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label102" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.3
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;Aadhar of the Entrepreneur.
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; vertical-align: top">
                                                    <asp:dropdownlist id="ddlCSEntrepreneurAadhar" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSEntrepreneurAadhar_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator29" runat="server" controltovalidate="ddlCSEntrepreneurAadhar"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 1.3" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload103" runat="server" visible="false" />
                                                    <asp:button id="Button103" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button103_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink103" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label103" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.4
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">PAN Card of the Entrepreneur.
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; vertical-align: top; margin: 5px">
                                                    <asp:dropdownlist id="ddlCSEntrepreneurPANCard" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSEntrepreneurPANCard_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" controltovalidate="ddlCSEntrepreneurPANCard"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 1.4" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload104" runat="server" visible="false" />
                                                    <asp:button id="Button104" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button104_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink104" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label104" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">1.5
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Certificate from the Chartered Accountant and % of holding of equity in the company
                                                    by each partner/director.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; vertical-align: top; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSCertificateofCA" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlCSCertificateofCA_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="ddlCSCertificateofCA"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 1.5" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload105" runat="server" visible="false" />
                                                    <asp:button id="Button105" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button105_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink105" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label105" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">1.6
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Regd. Partnership Deed/Articles of Association and Memorandum of Association in
                                                    case of Pvt. Ltd and Limited companies along with incorporation certificate / Bye-laws
                                                    in case of Indl. Cooperative along with Registration Certificate.
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; vertical-align: top; margin: 5px">
                                                    <asp:dropdownlist id="ddlCSRegdPartnershipDeedArticles" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSRegdPartnershipDeedArticles_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" controltovalidate="ddlCSRegdPartnershipDeedArticles"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 1.6" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload106" runat="server" visible="false" />
                                                    <asp:button id="Button106" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button106_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink106" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label106" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr id="trMSME1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">1.7
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Charted Accountant Certificate in prescribed proforma on the values of fixed capital investment.<font color="red">*</font>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; vertical-align: top; margin: 5px"></td>
                                                <td style="padding: 5px; margin: 5px"></td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fupCAMSME1" runat="server" />
                                                    <asp:button id="btnCAMSME1" runat="server" text="Click here to Upload"
                                                        onclick="btnCAMSME1_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hplCAMSME1" runat="server" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                    </asp:hyperlink>
                                                    <asp:label id="lblCAMSME1" runat="server" font-bold="true" forecolor="Green" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" valign="top">
                                        <table cellpadding="4" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center; font-weight: bold">2
                                                </td>
                                                <td colspan="6" style="font: bold; font-weight: bold">Documents in original to be produced to the inspecting officer of DIC for verification
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.1
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 1500px;" valign="top">Approval of Director of Factories.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                                    <asp:dropdownlist id="ddlCSApprovalDirectorFactories" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSApprovalDirectorFactories_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <%-- NumberOnly()--%>
                                                <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" controltovalidate="ddlCSApprovalDirectorFactories"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.1" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload201" runat="server" visible="false" />
                                                    <asp:button id="Button201" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button201_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink201" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label201" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">2.2
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Boilers Certificate.
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:dropdownlist id="ddlCSBoilersCertificate" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSBoilersCertificate_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" controltovalidate="ddlCSBoilersCertificate"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.2" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload202" runat="server" visible="false" />
                                                    <asp:button id="Button202" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button202_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink202" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label202" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">2.3
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Approval of Director of Town & Country Planning / UDA.
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:dropdownlist id="ddlCSApprovalDirectorTownCountryPlanningUDA" runat="server"
                                                        autopostback="True" class="form-control txtbox" height="28px" maxlength="40"
                                                        tabindex="1" validationgroup="group" width="100px" onselectedindexchanged="ddlCSApprovalDirectorTownCountryPlanningUDA_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" controltovalidate="ddlCSApprovalDirectorTownCountryPlanningUDA"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.3" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload203" runat="server" visible="false" />
                                                    <asp:button id="Button203" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button203_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink203" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label203" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">2.4
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Regular building plans approval of Municipality or Gram Panchayat.
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:dropdownlist id="ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat"
                                                        runat="server" autopostback="True" class="form-control txtbox" height="28px"
                                                        maxlength="40" tabindex="1" validationgroup="group" width="100px" onselectedindexchanged="ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" controltovalidate="ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.4" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload204" runat="server" visible="false" style="height: 22px" />
                                                    <asp:button id="Button204" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button204_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink204" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label204" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">2.5
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:label runat="server" id="lblPCB">Consent for Operation from TSPCB/Acknowledgement from the General Manager, DIC concerned.</asp:label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:dropdownlist id="ddlCSOperationTSPCBAcknowledgementGM" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSOperationTSPCBAcknowledgementGM_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator12" runat="server" controltovalidate="ddlCSOperationTSPCBAcknowledgementGM"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.5" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload205" runat="server" visible="false" />
                                                    <asp:button id="Button205" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button205_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink205" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label205" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.6
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Power release Certificate from TSTRANSCO/DISCOM.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM" runat="server"
                                                        autopostback="True" class="form-control txtbox" height="28px" maxlength="40"
                                                        tabindex="1" validationgroup="group" width="100px" onselectedindexchanged="ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator13" runat="server" controltovalidate="ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.6" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload206" runat="server" visible="false" />
                                                    <asp:button id="Button206" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button206_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink206" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label206" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.7
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Environmental clearance.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSEnvironmentalclearance" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSEnvironmentalclearance_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" controltovalidate="ddlCSEnvironmentalclearance"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.7" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload207" runat="server" visible="false" />
                                                    <asp:button id="Button207" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button207_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink207" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label207" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.8
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Other statutory approvals (specify).
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSOtherstatutoryapprovalsspecif" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSOtherstatutoryapprovalsspecif_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator14" runat="server" controltovalidate="ddlCSOtherstatutoryapprovalsspecif"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.8" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload208" runat="server" visible="false" />
                                                    <asp:button id="Button208" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button208_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink208" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label208" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.9
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">EM Part – I full set/IEM/IL.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSEMPartIfullsetIEMIL" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSEMPartIfullsetIEMIL_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator15" runat="server" controltovalidate="ddlCSEMPartIfullsetIEMIL"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.9" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload209" runat="server" visible="false" />
                                                    <asp:button id="Button209" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button209_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink209" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label209" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.10
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Udyog Aadhar.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSUdyogAadhar" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlCSUdyogAadhar_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator17" runat="server" controltovalidate="ddlCSUdyogAadhar"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.10" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload210" runat="server" visible="false" />
                                                    <asp:button id="Button210" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button210_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink210" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label210" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.11
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Project Report.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSProjectReport" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlCSProjectReport_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator18" runat="server" controltovalidate="ddlCSProjectReport"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.11" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload211" runat="server" visible="false" />
                                                    <asp:button id="Button211" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button211_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink211" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label211" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.12
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Term loan sanction letters.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSTermloansanctionletters" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSTermloansanctionletters_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator19" runat="server" controltovalidate="ddlCSTermloansanctionletters"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.12" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload212" runat="server" visible="false" />
                                                    <asp:button id="Button212" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button212_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink212" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label212" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.13
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Board Resolution authorizing to sign and file claim etc., in case of Pvt./Ltd.,
                                                    Companies, Cooperatives and similar authorization in respect of partnership firms.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSBoardResolutionauthorizing" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSBoardResolutionauthorizing_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator20" runat="server" controltovalidate="ddlCSBoardResolutionauthorizing"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.13" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload213" runat="server" visible="false" />
                                                    <asp:button id="Button213" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button213_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink213" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label213" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.14
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Registered land Sale deed/Premises Lease deed.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSRegisteredlandSaledeedPremisesLeasedeed" runat="server"
                                                        autopostback="True" class="form-control txtbox" height="28px" maxlength="40"
                                                        tabindex="1" validationgroup="group" width="100px" onselectedindexchanged="ddlCSRegisteredlandSaledeedPremisesLeasedeed_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator21" runat="server" controltovalidate="ddlCSRegisteredlandSaledeedPremisesLeasedeed"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.14" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload214" runat="server" visible="false" />
                                                    <asp:button id="Button214" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button214_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink214" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label214" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.15
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">C.A. and C.E. Certificate regarding 2nd hand plant & machinery.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSCACECertificateregarding2handplantmachinery" runat="server"
                                                        autopostback="True" class="form-control txtbox" height="28px" maxlength="40"
                                                        tabindex="1" validationgroup="group" width="100px" onselectedindexchanged="ddlCSCACECertificateregarding2handplantmachinery_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator22" runat="server" controltovalidate="ddlCSCACECertificateregarding2handplantmachinery"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.15" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload215" runat="server" visible="false" />
                                                    <asp:button id="Button215" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button215_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink215" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label215" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.16
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">C.E. Certificate for Self fabricated machinery.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSCECertificateSelffabricatedmachinery" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSCECertificateSelffabricatedmachinery_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator23" runat="server" controltovalidate="ddlCSCECertificateSelffabricatedmachinery"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.16" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload216" runat="server" visible="false" />
                                                    <asp:button id="Button216" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button216_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink216" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label216" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.17
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:label runat="server" id="lblBIS">BIS Certificate.</asp:label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSBISCertificate" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlCSBISCertificate_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator24" runat="server" controltovalidate="ddlCSBISCertificate"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.17" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload217" runat="server" visible="false" />
                                                    <asp:button id="Button217" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button217_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink217" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label217" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.18
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Drug License.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSDrugLicense" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlCSDrugLicense_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator25" runat="server" controltovalidate="ddlCSDrugLicense"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.18" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload218" runat="server" visible="false" />
                                                    <asp:button id="Button218" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button218_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink218" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label218" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.19
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Explosive License.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSExplosiveLicense" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlCSExplosiveLicense_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator26" runat="server" controltovalidate="ddlCSExplosiveLicense"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.19" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload219" runat="server" visible="false" />
                                                    <asp:button id="Button219" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button219_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink219" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label219" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.20
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">VAT/CST/GST Certificate.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSVATCSTSGSTCertificate" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCSVATCSTSGSTCertificate_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator27" runat="server" controltovalidate="ddlCSVATCSTSGSTCertificate"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.20" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload220" runat="server" visible="false" />
                                                    <asp:button id="Button220" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button220_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink220" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label220" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr id="trFormA" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.21
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Form – A.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSFormA" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlCSFormA_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator28" runat="server" controltovalidate="ddlCSFormA"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.21" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload221" runat="server" visible="false" />
                                                    <asp:button id="Button221" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button221_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink221" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label221" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr id="trFormB" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.22
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Form – B.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCSFormB" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlCSFormB_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator16" runat="server" controltovalidate="ddlCSFormB"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.22" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload222" runat="server" visible="false" />
                                                    <asp:button id="Button222" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button222_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink222" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label222" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.23
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Production particulars for the last 3 years as per fixed capital investment and
                                                    Line of Activity of the application duly certified by CA for the 1st time of the
                                                    claim, if it is expansion / diversification project.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlProductionParticulars3Years" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlProductionParticulars3Years_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator30" runat="server" controltovalidate="ddlProductionParticulars3Years"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.23" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload223" runat="server" visible="false" />
                                                    <asp:button id="Button223" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button223_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink223" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label223" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.24
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">RTA Certificate.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlRTACertificate" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlRTACertificate_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator31" runat="server" controltovalidate="ddlRTACertificate"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.24" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload224" runat="server" visible="false" />
                                                    <asp:button id="Button224" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button224_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink224" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label224" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.25
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">PH Certificate.
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlPHCertificate" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlPHCertificate_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator32" runat="server" controltovalidate="ddlPHCertificate"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.25" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload225" runat="server" visible="false" />
                                                    <asp:button id="Button225" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button225_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink225" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label225" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.26
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Undertaking and Finance Certificate Prescrbed Format
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlUntertakingForm" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlUntertakingForm_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator33" runat="server" controltovalidate="ddlUntertakingForm"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.26" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload226" runat="server" visible="false" />
                                                    <asp:button id="Button226" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button226_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink226" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label226" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.27
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Photo of the applicant along with the equipment in respect of mobile units
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlApplicantVehiclePhoto" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlApplicantVehiclePhoto_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator34" runat="server" controltovalidate="ddlApplicantVehiclePhoto"
                                                        initialvalue="S" errormessage="Please select File Upload Slno 2.27" validationgroup="group">
                                                        *</asp:requiredfieldvalidator>
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload227" runat="server" visible="false" />
                                                    <asp:button id="Button227" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button227_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink227" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                        [lblFileName]</asp:hyperlink>
                                                    <asp:label id="Label227" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.28
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">First Sale Bill
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlfirstsalebill" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlfirstsalebill_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px"></td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload228" runat="server" visible="false" />
                                                    <asp:button id="Button228" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="Button228_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink228" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                    </asp:hyperlink>
                                                    <asp:label id="Label228" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.29
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">UNDERTAKING ON CO-BORROWER / CO-APPLICANT / CO-OBLIGANT(T-Pride)
                                                    <asp:hyperlink id="HypLnkFinancialInstidtutionFormat" runat="server" visible="true"
                                                        cssclass="LBLBLACK" width="300px" target="_blank" navigateurl="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/UI/TSIPASS/DisplayDocs/UNDERTAKINGs.pdf">
                                                        Click here for Prescribed Format</asp:hyperlink>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCOBORROWER" enabled="false" runat="server" autopostback="True"
                                                        class="form-control txtbox" height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                        width="100px" onselectedindexchanged="ddlCOBORROWER_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="FileUpload229" runat="server" visible="false" />
                                                    <asp:button id="Button229" runat="server" text="Click here to Upload" visible="false"
                                                        onclick="Button229_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="HyperLink229" runat="server" cssclass="LBLBLACK" target="_blank"
                                                        visible="false" width="100px">
                                                    </asp:hyperlink>
                                                    <asp:label id="Label229" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.30
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Bank loan account statement showing the details of borrower and co-borrower etc,
                                                    if any
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlBLAStatement_Brw" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlBLAStatement_Brw_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fulBLAStatement_Brw" runat="server" visible="false" />
                                                    <asp:button id="btnBLAStatement_Brw" runat="server" text="Click here to Upload" visible="false"
                                                        onclick="btnStatementBrw_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hplBLAStatement_Brw" runat="server" cssclass="LBLBLACK" target="_blank"
                                                        visible="false" width="100px">
                                                    </asp:hyperlink>
                                                    <asp:label id="lblBLAStatement_Brw" runat="server" font-bold="true" forecolor="Green"
                                                        visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.31
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Caste certificate of co-borrower if any
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlCCCoBorrwer" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlCCCoBorrwer_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fulddlCCCoBorrwer" runat="server" visible="false" />
                                                    <asp:button id="btnddlCCCoBorrwer" runat="server" text="Click here to Upload" visible="false"
                                                        onclick="btnCCCoBorrwer_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hplddlCCCoBorrwer" runat="server" cssclass="LBLBLACK" target="_blank"
                                                        visible="false" width="100px">
                                                    </asp:hyperlink>
                                                    <asp:label id="lblddlCCCoBorrwer" runat="server" font-bold="true" forecolor="Green"
                                                        visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.32
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Factory License
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlFacLicense" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlFacLicense_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fulFacLicense" runat="server" visible="false" />
                                                    <asp:button id="btnFacLicense" runat="server" text="Click here to Upload" visible="false"
                                                        onclick="btnFacLicense_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hplFacLicense" runat="server" cssclass="LBLBLACK" target="_blank"
                                                        visible="false" width="100px">
                                                    </asp:hyperlink>
                                                    <asp:label id="lblFacLicense" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.33
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">TMC and Star Rating certificate for cotton ginning industries
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddlTMCStar" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddlTMCStar_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fulTMCStar" runat="server" visible="false" />
                                                    <asp:button id="btnTMCStar" runat="server" text="Click here to Upload" visible="false"
                                                        onclick="btnTMCStar_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hplTMCStar" runat="server" cssclass="LBLBLACK" target="_blank"
                                                        visible="false" width="100px">
                                                    </asp:hyperlink>
                                                    <asp:label id="lblTMCStar" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr id="trlocal1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="auto-style2">2.34
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style2">Additional Local Employment
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top" class="auto-style2">
                                                    <asp:dropdownlist id="ddladdlocalemp1" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddladdlocalemp1_SelectedIndexChanged">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" class="auto-style2"></td>
                                                <td align="center" style="vertical-align: top" class="auto-style3">
                                                    <asp:fileupload id="Addlocalempup1" runat="server" visible="false" />
                                                    <asp:button id="btnlocalemp1" runat="server" text="Click here to Upload" visible="false"
                                                        onclick="btnlocalemp1_Click" />
                                                </td>
                                                <td align="left" class="auto-style3" style="vertical-align: top">
                                                    <asp:hyperlink id="hplAddlocalemp1" runat="server" cssclass="LBLBLACK" target="_blank"
                                                        visible="false" width="100px">
                                                    </asp:hyperlink>
                                                    <asp:label id="lbllocalemp1" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>
                                            <tr id="trlocal2" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.35
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Additional Local Employment
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddladdlocalemp2" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px"
                                                        onselectedindexchanged="ddladdlocalemp2_SelectedIndexChanged" visible="true">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="Addlocalempup2" runat="server" visible="false" />
                                                    <asp:button id="btnlocalemp2" runat="server" text="Click here to Upload" visible="false"
                                                        onclick="btnlocalemp2_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hplAddlocalemp2" runat="server" cssclass="LBLBLACK" target="_blank"
                                                        visible="false" width="100px">
                                                    </asp:hyperlink>
                                                    <asp:label id="lbllocalemp2" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                </td>
                                            </tr>

                                            <tr id="TRDEETDOCUMENT" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top"></td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">DEET Registration Acknowledgement
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:dropdownlist id="ddldeetregack" runat="server" autopostback="True" class="form-control txtbox"
                                                        height="28px" maxlength="40" tabindex="1" validationgroup="group" width="100px" enabled="false"
                                                        onselectedindexchanged="ddldeetregack_SelectedIndexChanged" visible="true">
                                                        <asp:listitem value="S">--Select--</asp:listitem>
                                                        <asp:listitem value="Y">Yes</asp:listitem>
                                                        <asp:listitem value="N">No</asp:listitem>
                                                        <asp:listitem value="I">NA</asp:listitem>
                                                    </asp:dropdownlist>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fupdeetregack" runat="server" visible="false" />
                                                    <asp:button id="btndeetregack" runat="server" visible="false" text="Click here to Upload"
                                                        onclick="btndeetregack_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hypdeetregack" runat="server" visible="false" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                    </asp:hyperlink>
                                                    <asp:label id="lbldeetregack" runat="server" font-bold="true" forecolor="Green"
                                                        visible="false" />
                                                </td>

                                            </tr>
                                            <tr id="trMSME3" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.37</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Civil Engineer Certificate in prescribed format<font color="red">*</font>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top"></td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fupCivilCert" runat="server" />
                                                    <asp:button id="btnCivilCert" runat="server" text="Click here to Upload"
                                                        onclick="btnCivilCert_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hplCivilCert" runat="server" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                    </asp:hyperlink>
                                                    <asp:label id="lblCivilCert" runat="server" font-bold="true" forecolor="Green"
                                                        visible="false" />
                                                </td>

                                            </tr>
                                            <tr id="trMSME4" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.38</td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">Declaration by enterprise in prescribed format<font color="red">*</font>
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top">:
                                                </td>
                                                <td style="padding: 5px; margin: 5px" valign="top"></td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fupEnterpsriseDecl" runat="server" />
                                                    <asp:button id="btnEnterpsriseDecl" runat="server" text="Click here to Upload"
                                                        onclick="btnEnterpsriseDecl_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hplEnterpsriseDecl" runat="server" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                    </asp:hyperlink>
                                                    <asp:label id="lblEnterpsriseDecl" runat="server" font-bold="true" forecolor="Green"
                                                        visible="false" />
                                                </td>

                                            </tr>
                                            <tr id="trMSME5" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">2.39
                                                </td>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Loan Agreement copy/Term loan account statement.<font color="red">*</font>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td style="padding: 5px; vertical-align: top; margin: 5px"></td>
                                                <td style="padding: 5px; margin: 5px"></td>
                                                <td align="center" style="width: 50px; vertical-align: top">
                                                    <asp:fileupload id="fuploanstmt" runat="server" visible="true" />
                                                    <asp:button id="btnloanstmt" runat="server" text="Click here to Upload"
                                                        onclick="btnloanstmt_Click" />
                                                </td>
                                                <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                                    <asp:hyperlink id="hplloanstmt" runat="server" cssclass="LBLBLACK"
                                                        width="100px" target="_blank">
                                                    </asp:hyperlink>
                                                    <asp:label id="lblloanstmt" runat="server" font-bold="true" forecolor="Green" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="TRDEETHEADING" runat="server" visible="false">

                                    <td style="width: 100%; color: red;">
                                        <asp:hyperlink id="Hyperlink1" runat="server" visible="true"
                                            cssclass="LBLRED" width="100%" target="_blank" navigateurl="https://deet.telangana.gov.in/">
                                            Please click here to register in DEET (It is mandatory to register in DEET portal and upload registerred acknowledgement in attachment check slip)<span class="detail-gif" data-balloon-length="large"
                                                data-balloon-pos="right">&nbsp;&nbsp;&nbsp;
        <img alt="" width="40px" height="20px" src="../../images/animated-hand-image-0117.gif" /></span></asp:hyperlink><span style="color: red">(For Technical Assistance, Please call: +91 9281423576 (Dr. M.Chandrashekar, Additional Program Director))</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:button id="BtnSave" runat="server" cssclass="btn btn-primary" height="32px"
                                            tabindex="10" text="Save" width="90px" validationgroup="group" onclick="BtnSave_Click" />
                                        &nbsp;&nbsp;
                                        <asp:button id="BtnPrevious" runat="server" cssclass="btn btn-danger" height="32px"
                                            tabindex="10" text="Previous" width="90px" onclick="BtnPrevious_Click" visible="true" />
                                        &nbsp; &nbsp;&nbsp;<asp:button id="BtnNext" runat="server" cssclass="btn btn-danger"
                                            height="32px" enabled="false" tabindex="10" text="Next" width="90px" validationgroup="group"
                                            onclick="BtnNext_Click" />
                                        <%--<asp:Button ID="BtnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        TabIndex="10" Text="Next" Width="90px"  OnClick="BtnNext_Click" />--%>
                                        &nbsp; &nbsp;<asp:button id="BtnClear" runat="server" causesvalidation="False" cssclass="btn btn-warning"
                                            height="32px" tabindex="10" text="ClearAll" tooltip="To Clear  the Screen" width="90px"
                                            onclick="BtnClear_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:label id="lblmsg" runat="server"></asp:label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:label id="lblmsg0" runat="server"></asp:label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:hiddenfield id="hdnisph" runat="server" />
                                        <asp:hiddenfield id="hdncaste" runat="server" />
                                        <asp:hiddenfield id="hdfID" runat="server" />
                                        <asp:hiddenfield id="hdnMSMEApplied" runat="server" />
                                        <asp:validationsummary id="ValidationSummary1" runat="server" showmessagebox="True"
                                            showsummary="False" validationgroup="group" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
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

        .auto-style1 {
            width: 50px;
        }

        .auto-style2 {
            height: 55px;
        }

        .auto-style3 {
            width: 50px;
            height: 55px;
        }
    </style>
</asp:content>
