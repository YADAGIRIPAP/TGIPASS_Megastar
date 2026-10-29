<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true"
    codefile="IIDFund.aspx.cs" inherits="UI_TSiPASS_IncentivesAnnexure_IIDFund" %>

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
                                        <asp:label id="lblheadTPRIDE" runat="server" visible="false"></asp:label>
                                        <asp:label id="lblheadTIDEA" runat="server" visible="false"></asp:label>
                                        <asp:label id="lblMSMEPolicy" runat="server" visible="false" text="Industrial Infrastructure Development Fund(IIDF)"
                                            forecolor="White" font-bold="true" font-size="20px"></asp:label>
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
                            <triggers>
                                <asp:postbacktrigger controlid="btnUpload1" />
                                <asp:postbacktrigger controlid="btnEntrDeclaration" />
                                <asp:postbacktrigger controlid="btnDeptDeclaration" />
                                <asp:postbacktrigger controlid="btnInfraEstimates" />
                            </triggers>
                            <contenttemplate>
                                <div class="panel-body" align="left">
                                    <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 90%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">1
                                                        </td>
                                                        <td colspan="8" style="font: bold; font-weight: bold">IIDF Fund
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1.1
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Whether the unit is located in Industrial Area declared by the Governement<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:dropdownlist id="txtUnitLocatedinIndustArea" runat="server" class="form-control txtbox"
                                                                height="38px" tabindex="1" validationgroup="group" width="180px">
                                                                <asp:listitem value="--Select" text="--Select--"></asp:listitem>
                                                                <asp:listitem value="Y" text="YES"></asp:listitem>
                                                                <asp:listitem value="N" text="NO"></asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txtUnitLocatedinIndustArea"
                                                                errormessage="Please enter Unit Located in Industrial Area" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1.2
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Justification for the location of the Industry, if it is located outside IA declared
                                                            by the Government<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:textbox id="txtJustLocation" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                height="28px" maxlength="40" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" controltovalidate="txtJustLocation"
                                                                errormessage="Please enter Justfication for the Location" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1.3
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Source of Finance<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtFinanceSource" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                height="28px" maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator29" runat="server" controltovalidate="txtFinanceSource"
                                                                errormessage="Please enter Finance Source" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1.4
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Description of the infrastructure facilities required and its objectives<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtReqdInfraFacilities" runat="server" class="form-control txtbox"
                                                                onkeypress="Names()" height="28px" maxlength="30" tabindex="1" validationgroup="group"
                                                                width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator30" runat="server" controltovalidate="txtReqdInfraFacilities"
                                                                errormessage="Please enter Required Infrastructre Facilities" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1.5
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Estimates of Infrastructure facilities<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <%-- <asp:TextBox ID="txtEstimatesInfra" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                            <asp:textbox id="txtEstimatesInfra" runat="server" class="form-control txtbox" height="28px"
                                                                maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="txtEstimatesInfra"
                                                                errormessage="Please enter  Estimates of Infrastructre Facilities" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1.6
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">How the proposed infrastructure is critical to the Industrial Enterprise<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtProposedInfraCritical" runat="server" class="form-control txtbox"
                                                                onkeypress="Names()" height="28px" maxlength="30" tabindex="1" validationgroup="group"
                                                                width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" controltovalidate="txtProposedInfraCritical"
                                                                errormessage="Please enter How the proposed infrastructure is critical to the Industrial Enterprise"
                                                                validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1.7
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Name of the Chartered Engineer / Agency who prepared the estimates<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtCAName" runat="server" class="form-control txtbox" height="28px"
                                                                maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="txtCAName"
                                                                onkeypress="Names()" errormessage="Please enter Name of the Chartered Engineer"
                                                                validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1.8
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Duration of the project<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtProjDuration" runat="server" class="form-control txtbox" height="28px"
                                                                maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" controltovalidate="txtProjDuration"
                                                                errormessage="Please enter Project Duration" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">1.9
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Measures proposed to maintain the infrastructure created & its maintenance cost
                                                            per annum<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtMaintanCostAnnum" runat="server" class="form-control txtbox"
                                                                onkeypress="Names()" height="28px" maxlength="30" tabindex="1" validationgroup="group"
                                                                width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" controltovalidate="txtMaintanCostAnnum"
                                                                errormessage="Please enter Maintan Cost Per Annum" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">10.0
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Amount claimed in Rs.<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtAmtClaimed" runat="server" class="form-control txtbox" onkeypress="inputOnlyNumbers(evt)"
                                                                height="28px" maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" controltovalidate="txtAmtClaimed"
                                                                errormessage="Please enter  Amount Claimed" validationgroup="group">
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
                                                <table style="width: 100%">
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
                                                        <td align="left" style="border: solid thin black; background: white; color: black">Copy of the Project & its approval report
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:fileupload id="fuDocuments1" runat="server" />
                                                            <asp:button id="btnUpload1" runat="server" text="Click here to Upload" onclick="btnUpload1_Click" />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:hyperlink id="lblUpload1" runat="server" cssclass="LBLBLACK" width="165px" target="_blank">[lblFileName]</asp:hyperlink>
                                                            <asp:label id="lblAttachedFileName1" runat="server" font-bold="true" forecolor="Green"
                                                                visible="false" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trMSME1" runat="server" visible="false">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">2
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">Declaration by the Enterprise/Industry stating that they have not availed any financial assistance from the Government 
                                                    earlier for the proposed Infrastructure to be developed.
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:fileupload id="fupEntrDeclaration" runat="server" />
                                                            <asp:button id="btnEntrDeclaration" runat="server" text="Click here to Upload" onclick="btnEntrDeclaration_Click" />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:hyperlink id="hplEntrDeclaration" runat="server" cssclass="LBLBLACK" width="165px" target="_blank"></asp:hyperlink>
                                                            <asp:label id="lblEntrDeclaration" runat="server" font-bold="true" forecolor="Green"
                                                                visible="false" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trMSME2" runat="server" visible="false">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">3
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">Declaration from the line Department concerned stating that the project is not covered in the budgetary estimates of current year.
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:fileupload id="fupDeptDeclaration" runat="server" />
                                                            <asp:button id="btnDeptDeclaration" runat="server" text="Click here to Upload" onclick="btnDeptDeclaration_Click" />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:hyperlink id="hplDeptDeclaration" runat="server" cssclass="LBLBLACK" width="165px" target="_blank"></asp:hyperlink>
                                                            <asp:label id="lblDeptDeclaration" runat="server" font-bold="true" forecolor="Green"
                                                                visible="false" />
                                                        </td>
                                                    </tr>
                                                    <tr id="trMSME3" runat="server" visible="false">
                                                        <td align="center" style="border: solid thin black; background: white; color: black">4
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">The infrastructure estimates confirmed by the district head of the line department 
                                                            concerned stating that the project is not covered in the budgetary estimates of curreny year.
                                                        </td>
                                                        <td align="center" style="border: solid thin black; background: white; color: black">
                                                            <asp:fileupload id="fupInfraEstimates" runat="server" />
                                                            <asp:button id="btnInfraEstimates" runat="server" text="Click here to Upload" onclick="btnInfraEstimates_Click" />
                                                        </td>
                                                        <td align="left" style="border: solid thin black; background: white; color: black">
                                                            <asp:hyperlink id="hplInfraEstimates" runat="server" cssclass="LBLBLACK" width="165px" target="_blank"></asp:hyperlink>
                                                            <asp:label id="lblInfraEstimates" runat="server" font-bold="true" forecolor="Green"
                                                                visible="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                        </tr>
                                        <%--<tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>DECLARATION :  </b>
                                                <br />
                                                I / We hereby confirm that to the best of our knowledge and belief, information given herein
before and other papers enclosed are true and correct in all respects. We further undertake to
substantiate the particulars about promoter(s) and other details with documentary evidence as
and when called for.<br />
                                                I/We hereby agree that I/We shall forthwith repay the amount to me/us under scheme, if the
amount of seed capital assistance are found to be disbursed in excess of the amount actually
admissible whatsoever the reason.

                                            </td>
                                            <td></td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:button id="BtnSave" runat="server" cssclass="btn btn-primary" height="32px"
                                                    tabindex="10" text="Submit" width="90px" validationgroup="group" onclick="BtnSave_Click" />
                                                &nbsp;&nbsp;
                                                <asp:button id="BtnPrevious" runat="server" cssclass="btn btn-danger" height="32px"
                                                    tabindex="10" text="Previous" width="90px" onclick="BtnPrevious_Click" />
                                                &nbsp; &nbsp;&nbsp;<asp:button id="BtnNext" runat="server" cssclass="btn btn-danger"
                                                    height="32px" tabindex="10" text="Next" width="90px" validationgroup="group"
                                                    enabled="false" onclick="BtnNext_Click" />
                                                &nbsp; &nbsp;<asp:button id="BtnClear" runat="server" causesvalidation="False" cssclass="btn btn-warning"
                                                    height="32px" tabindex="10" text="ClearAll" tooltip="To Clear  the Screen" width="90px"
                                                    onclick="BtnClear_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
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
    </style>
</asp:content>
