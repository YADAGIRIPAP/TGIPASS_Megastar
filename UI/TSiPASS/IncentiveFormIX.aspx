<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true"
    codefile="IncentiveFormIX.aspx.cs" inherits="UI_TSiPASS_IncentiveFormIX" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <style type="text/css">
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

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }

        .style5 {
            color: #FF0000;
        }
    </style>

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

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel panel-primary" align="center">
                        <div class="panel-heading" style="background-color: #339966">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:label id="lblheadTPRIDE" runat="server" visible="false"></asp:label>
                                        <asp:label id="lblheadTIDEA" runat="server" visible="false"></asp:label>
                                        <asp:Label ID="lblMSMEPolicy" runat="server" Visible="false" Text="Reimbursement of 
                                            Cost Involved in Skill Upgradation and Training"
                                            ForeColor="White" Font-Bold="true" Font-Size="20px">
                                        </asp:Label><asp:HiddenField ID="hdnMSMEApplied" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-body">
                            <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                <tr>
                                    <td colspan="5" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; font-size: 12pt"
                                        valign="top">Training Undergone
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">1
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:label id="Label387" runat="server" cssclass="LBLBLACK" width="210px">Name of the training institute<font
                                            color="red">*</font></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                        <asp:textbox id="txtagencyName" runat="server" class="form-control txtbox" height="28px"
                                            maxlength="40" tabindex="1" validationgroup="group" width="180px">
                                        </asp:textbox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txtagencyName"
                                            errormessage="Please Enter Name of Certifying Agency" validationgroup="group">
                                            *</asp:requiredfieldvalidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">2
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:label id="Label396" runat="server" cssclass="LBLBLACK" width="165px">Duration of training<font
                                            color="red">*</font></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:textbox id="txtDurationoftraining" runat="server" class="form-control txtbox"
                                            height="28px" maxlength="40" onkeypress="Names()" tabindex="1" validationgroup="group"
                                            width="180px">
                                        </asp:textbox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" controltovalidate="txtDurationoftraining"
                                            errormessage="Please Enter Duration of training" validationgroup="group">
                                            *</asp:requiredfieldvalidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:dropdownlist id="ddlTrainingDurationMode" runat="server" class="form-control txtbox"
                                            height="33px" maxlength="40" tabindex="1" validationgroup="group" width="180px">
                                            <asp:listitem text="--Select--" value="--Select--"></asp:listitem>
                                            <asp:listitem text="Days" value="D"></asp:listitem>
                                            <asp:listitem text="Weeks" value="W"></asp:listitem>
                                            <asp:listitem text="Months" value="M"></asp:listitem>
                                            <asp:listitem text="Years" value="Y"></asp:listitem>
                                        </asp:dropdownlist>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" controltovalidate="ddlTrainingDurationMode" initialvalue="--Select--"
                                            errormessage="Please Enter Duration of training" validationgroup="group">
                                            *</asp:requiredfieldvalidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">3
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:label id="Label351" runat="server" cssclass="LBLBLACK" width="200px">Name of the skill development programme<font
                                            color="red">*</font></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:textbox id="txtNameoftheskilldevelopmentprogramme" runat="server" class="form-control txtbox"
                                            height="28px" maxlength="30" onkeypress="Names()" tabindex="1" validationgroup="group"
                                            width="180px">
                                        </asp:textbox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" controltovalidate="txtNameoftheskilldevelopmentprogramme"
                                            errormessage="Please Eneter Name of the skill development programme" validationgroup="group">
                                            *</asp:requiredfieldvalidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">4
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:label id="Label1" runat="server" cssclass="LBLBLACK" width="200px">Number of skilled employees trained by the industry<font
                                            color="red">*</font></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:textbox id="txtNumberskilledemployees" runat="server" class="form-control txtbox"
                                            height="28px" maxlength="30" onkeypress="Names()" tabindex="1" validationgroup="group"
                                            width="180px">
                                        </asp:textbox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" controltovalidate="txtNumberskilledemployees"
                                            errormessage="Please Eneter Number of skilled employees trained by the industry"
                                            validationgroup="group">
                                            *</asp:requiredfieldvalidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">5
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:label id="Label2" runat="server" cssclass="LBLBLACK" width="200px">Expenditure incurred for training programme<font color="red">*</font></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:textbox id="txtExpenditureincurredfortrainingprogramme" runat="server" class="form-control txtbox"
                                            height="28px" maxlength="30" onkeypress="Names()" tabindex="1" validationgroup="group"
                                            width="180px">
                                        </asp:textbox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="txtExpenditureincurredfortrainingprogramme"
                                            errormessage="Please Eneter Expenditure incurred for training programme" validationgroup="group">
                                            *</asp:requiredfieldvalidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">6
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:label id="Label3" runat="server" cssclass="LBLBLACK" width="200px">Amount claimed in Rs.<font
                                            color="red">*</font></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:textbox id="txtAmountclaimedinRs" runat="server" class="form-control txtbox"
                                            height="28px" maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                        </asp:textbox>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="txtAmountclaimedinRs"
                                            errormessage="Please Eneter Amount claimed in Rs." validationgroup="group">
                                            *</asp:requiredfieldvalidator>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px" colspan="10" align="center"></td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr id="Tr1" runat="server">
                                    <td style="padding: 5px; margin: 5px"></td>
                                    <td colspan="10" style="padding: 5px; margin: 5px; text-align: left;"><b>Enclosures: </b>
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                </tr>
                                <tr id="Panelpcb1" runat="server">
                                    <td style="padding: 5px; margin: 5px">1
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">Copy of certification of institute along with the list of participants with their
                                signature
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px;"
                                        colspan="4">
                                        <asp:fileupload id="FileUpload10" runat="server" cssclass="CS" height="28px" />
                                        <asp:hyperlink id="Label453" runat="server" cssclass="LBLBLACK" target="_blank"></asp:hyperlink>
                                        <br />
                                        <asp:label id="Label454" runat="server" visible="False"></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:button id="Button8" runat="server" cssclass="btn btn-xs btn-warning" height="28px"
                                            tabindex="10" text="Upload" validationgroup="gg" width="72px" onclick="Button8_Click" />
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>

                                </tr>
                                <tr id="panelTSCT1" runat="server">
                                    <td style="padding: 5px; margin: 5px">2
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">Original bills & payment proof certified by the training institute<br />
                                        (Rar Or Pdf)</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">
                                        <asp:fileupload id="FileUpload11" runat="server" cssclass="CS" height="28px" />
                                        <asp:hyperlink id="HyperLink1" runat="server" cssclass="LBLBLACK" target="_blank"></asp:hyperlink>
                                        <br />
                                        <asp:label id="Label8" runat="server" visible="False"></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:button id="Button9" runat="server" cssclass="btn btn-xs btn-warning" height="28px"
                                            tabindex="10" text="Upload" validationgroup="gg" width="72px" onclick="Button9_Click" />
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr id="panelPRD1" runat="server">
                                    <td style="padding: 5px; margin: 5px">3
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">Details of employees trained as per format
                                        (FORM - C)
                                        <br />
                                        <asp:hyperlink id="HyperLink2" runat="server" visible="true" cssclass="LBLBLACK" width="300px" target="_blank" navigateurl="~/docs/Employee Details Format (FORM - C ).pdf">Click here for Prescribed Format</asp:hyperlink>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;:&nbsp;
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">
                                        <asp:fileupload id="FileUpload13" runat="server" cssclass="CS" height="28px" />
                                        <asp:hyperlink id="HyperLink3" runat="server" cssclass="LBLBLACK" target="_blank"></asp:hyperlink>
                                        <br />
                                        <asp:label id="Label14" runat="server" visible="False"></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:button id="Button11" runat="server" cssclass="btn btn-xs btn-warning" height="28px"
                                            tabindex="10" text="Upload" validationgroup="gg" width="72px" onclick="Button11_Click" />
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr id="Tr2" runat="server">
                                    <td style="padding: 5px; margin: 5px">3
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">CA Certificate as per prescribed format
                                        <asp:hyperlink id="HyperLinkCivilEngineersFormat" runat="server" visible="true" cssclass="LBLBLACK" width="300px" target="_blank" navigateurl="~/docs/Skil Upgradation CA Format.pdf">Click here for Prescribed Format</asp:hyperlink>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;:&nbsp;
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">
                                        <asp:fileupload id="FileUpload14" runat="server" cssclass="CS" height="28px" />
                                        <asp:hyperlink id="HyperLink4" runat="server" cssclass="LBLBLACK" target="_blank"></asp:hyperlink>
                                        <br />
                                        <asp:label id="Label4" runat="server" visible="False"></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:button id="Button12" runat="server" cssclass="btn btn-xs btn-warning" height="28px"
                                            tabindex="10" text="Upload" validationgroup="gg" width="72px" onclick="Button12_Click" />
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr id="trMSME1" runat="server" visible="false">
                                    <td style="padding: 5px; margin: 5px">4. 
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">Proforma VI  
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;:&nbsp;
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">
                                        <asp:fileupload id="fupProforma" runat="server" cssclass="CS" height="28px" />
                                        <asp:hyperlink id="hplProforma" runat="server" cssclass="LBLBLACK" target="_blank"></asp:hyperlink>
                                        <br />
                                        <asp:label id="lblProforma" runat="server" visible="False"></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:button id="btnProforma" runat="server" cssclass="btn btn-xs btn-warning" height="28px"
                                            tabindex="10" text="Upload" validationgroup="gg" width="72px" onclick="btnProforma_Click" />
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr id="trMSME2" runat="server" visible="false">
                                    <td style="padding: 5px; margin: 5px">5
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">Local Employee proof study certificate or Residence certificate.
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;:&nbsp;
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                        colspan="4">
                                        <asp:fileupload id="fupEmpProof" runat="server" cssclass="CS" height="28px" />
                                        <asp:hyperlink id="hplEmpProof" runat="server" cssclass="LBLBLACK" target="_blank"></asp:hyperlink>
                                        <br />
                                        <asp:label id="lblEmpProof" runat="server" visible="False"></asp:label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:button id="btnEmpProof" runat="server" cssclass="btn btn-xs btn-warning" height="28px"
                                            tabindex="10" text="Upload" validationgroup="gg" width="72px" onclick="btnEmpProof_Click" />
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr>
                                    <td colspan="11" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                    <td style="padding: 5px; margin: 5px"></td>

                                </tr>
                                <tr>
                                    <td colspan="11" style="padding: 5px; margin: 5px; text-align: left;">
                                        <b>DECLARATION :  </b>
                                        <br />
                                        I / We hereby confirm that to the best of our knowledge and belief, information given herein before and
other papers enclosed are true and correct in all respects. We further undertake to substantiate the
particulars about promoter(s) and other details with documentary evidence as and when called for.<br />
                                        I/We hereby agree that I/We shall forthwith repay the amount to me/us under &nbsp;
                                        <asp:label id="lblscheme" runat="server"></asp:label>
                                        &nbsp;, if it is found to be
disbursed in excess actually admissible whatsoever the reason. 

                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="11" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="11" style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:button id="BtnSave1" runat="server" cssclass="btn btn-primary" height="32px"
                                            onclick="BtnSave_Click" tabindex="10" text="Submit" width="90px" validationgroup="group" />
                                        &nbsp;
                                <asp:button id="BtnDelete0" runat="server" cssclass="btn btn-danger" height="32px"
                                    onclick="BtnDelete0_Click" tabindex="10" text="Previous" width="90px" visible="true" />
                                        &nbsp; &nbsp;&nbsp;<asp:button id="BtnDelete" runat="server" cssclass="btn btn-danger"
                                            height="32px" onclick="BtnClear0_Click" tabindex="10" text="Next" width="90px" enabled="false"
                                            validationgroup="group" />
                                        &nbsp;<asp:button id="BtnClear" runat="server" causesvalidation="False" cssclass="btn btn-warning"
                                            height="32px" onclick="BtnClear_Click" tabindex="10" text="ClearAll" tooltip="To Clear  the Screen"
                                            width="90px" />
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="11" style="padding: 5px; margin: 5px">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                            <asp:label id="lblmsg" runat="server"></asp:label>
                                        </div>
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                            <asp:label id="lblmsg0" runat="server"></asp:label>
                                        </div>
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr>
                                    <td colspan="10">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:content>
