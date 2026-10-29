<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true"
    codefile="AdvanceSubsidyForSCandST.aspx.cs" inherits="UI_TSiPASS_IncentivesAnnexure_AdvanceSubsidyForSCandST" %>

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
                            <table class="nav-justified">
                                <tr>
                                    <td>
                                        <asp:label id="lblheadTPRIDE" runat="server" visible="false"></asp:label>
                                        <asp:label id="lblheadTIDEA" runat="server" visible="false"></asp:label>
                                        <asp:label id="lblMSMEPolicy" runat="server" forecolor="White" font-bold="true" font-size="20px" visible="false" text="Application cum Verification for claiming Claiming Advance Subsidy under MSME Policy-2024 "></asp:label>
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
                                <asp:postbacktrigger controlid="btnUpload2" />
                                <asp:postbacktrigger controlid="btnUpload3" />
                                <asp:postbacktrigger controlid="btnUpload4" />
                                <asp:postbacktrigger controlid="btnCommDoc" />
                                
                            </triggers>
                            <contenttemplate>
                                <div class="panel-body" align="left">
                                    <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 90%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center; font-weight: bold">1
                                                        </td>
                                                        <td colspan="8" style="font: bold; font-weight: bold">Means of Finance
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.1
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Total equity from promotors / share holders / partners to be brought in Rs.<font
                                                            color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:textbox id="txtTotalEquity" runat="server" class="form-control txtbox" height="28px"
                                                                maxlength="40" tabindex="1" validationgroup="group" width="180px" onkeypress="inputOnlyNumbers(evt)">
                                                            </asp:textbox>
                                                        </td>
                                                        <%-- NumberOnly()--%>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txtTotalEquity"
                                                                errormessage="Please enter Total Equity from Promoters" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.2
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Own capital in Rs.<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:textbox id="txtOwnCapital" runat="server" class="form-control txtbox" onkeypress="inputOnlyNumbers(evt)"
                                                                height="28px" maxlength="40" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" controltovalidate="txtOwnCapital"
                                                                errormessage="Please enter Own capital" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.3
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Borrowed from outside Rs.<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtBorrowed" runat="server" class="form-control txtbox" onkeypress="inputOnlyNumbers(evt)"
                                                                height="28px" maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator29" runat="server" controltovalidate="txtBorrowed"
                                                                errormessage="Please enter Borrowed from outside" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 40px;">
                                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.4
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Advance Subsidy claimed in Rs.<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtAdvSubClaimed" runat="server" class="form-control txtbox" onkeypress="inputOnlyNumbers(evt)"
                                                                height="28px" maxlength="30" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" controltovalidate="txtAdvSubClaimed"
                                                                errormessage="Please enter Advance Subsidy claimed" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.5
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Advance Subsidy claimed<font color="red">*</font>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:dropdownlist id="ddlinstallment" runat="server" width="180px" class="form-control txtbox">
                                                                <asp:listitem selected="True" value="1" text="1st Instalment"></asp:listitem>
                                                                <asp:listitem value="2" text="2nd Instalment"></asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px"></td>
                                                    </tr>
                                                    <tr id="trMSME1" runat="server" visible="false">
                                                        <td colspan="5">
                                                            <table>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.6
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Expected Date of Commencement of Production<font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:textbox id="txtExpectedDCP" runat="server" class="form-control txtbox"
                                                                            height="28px" maxlength="10" tabindex="1" validationgroup="group" width="180px">
                                                                        </asp:textbox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="txtBorrowed"
                                                                            errormessage="Please enter Expected Date of Commencement of Production" validationgroup="group">
                                                                            *</asp:requiredfieldvalidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.6
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Date of Application with DISCOM<font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:textbox id="txtDISCOMApplDate" runat="server" class="form-control txtbox"
                                                                            height="28px" maxlength="10" tabindex="1" validationgroup="group" width="180px">
                                                                        </asp:textbox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" controltovalidate="txtBorrowed"
                                                                            errormessage="Please enter Date of Application with DISCOM" validationgroup="group">
                                                                            *</asp:requiredfieldvalidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">1.6
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Contracted Load(KW/HP)<font color="red">*</font>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:textbox id="txtContractedLoad" runat="server" class="form-control txtbox"
                                                                            height="28px" maxlength="10" tabindex="1" validationgroup="group" width="180px">
                                                                        </asp:textbox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="txtBorrowed"
                                                                            errormessage="Please enter Contracted Load(KW/HP)" validationgroup="group">
                                                                            *</asp:requiredfieldvalidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;">
                                            </td>
                                        </tr--%>
                                        <caption>
                                            &gt;
                                            <tr>
                                                <td colspan="4" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <table style="width: 80%">
                                                        <tr>
                                                            <td align="left" colspan="4" style="padding: 5px; margin: 5px; font-weight: bold" valign="middle">Enclosures </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">Sl.No </td>
                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">Document Name </td>
                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">Upload Document </td>
                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">File Name </td>
                                                        </tr>
                                                        <tr id="trEnclosures" runat="server">
                                                            <td align="center" style="border: solid thin black; background: white; color: black">1 </td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black; text-align: left;">Electrical feasibility certificate </td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black">
                                                                <asp:fileupload id="fuDocuments1" runat="server" />
                                                                <asp:button id="btnUpload1" runat="server" onclick="btnUpload1_Click" text="Click here to Upload" />
                                                            </td>
                                                            <td align="left" style="border: solid thin black; background: white; color: black">
                                                                <asp:hyperlink id="lblupload1" runat="server" cssclass="LBLBLACK" target="_blank" width="165px">[lblFileName]</asp:hyperlink>
                                                                <asp:label id="lblAttachedFileName1" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr1" runat="server">
                                                            <td align="center" style="border: solid thin black; background: white; color: black">2 </td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black; text-align: left;">Proof of own capital invested </td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black">
                                                                <asp:fileupload id="fuDocuments2" runat="server" />
                                                                <asp:button id="btnUpload2" runat="server" onclick="btnUpload2_Click" text="Click here to Upload" />
                                                            </td>
                                                            <td align="left" style="border: solid thin black; background: white; color: black">
                                                                <asp:hyperlink id="lblupload2" runat="server" cssclass="LBLBLACK" target="_blank" width="165px">[lblFileName]</asp:hyperlink>
                                                                <asp:label id="lblAttachedFileName2" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr2" runat="server">
                                                            <td align="center" style="border: solid thin black; background: white; color: black">3 </td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black; text-align: left;">Proof of borrowed capital from outside </td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black">
                                                                <asp:fileupload id="fuDocuments3" runat="server" />
                                                                <asp:button id="btnUpload3" runat="server" onclick="btnUpload3_Click" text="Click here to Upload" />
                                                            </td>
                                                            <td align="left" style="border: solid thin black; background: white; color: black">
                                                                <asp:hyperlink id="lblupload3" runat="server" cssclass="LBLBLACK" target="_blank" width="165px">[lblFileName]</asp:hyperlink>
                                                                <asp:label id="lblAttachedFileName3" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                            </td>
                                                        </tr>
                                                        <tr id="tr3" runat="server">
                                                            <td align="center" style="border: solid thin black; background: white; color: black">4 </td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black; text-align: left;">Term loan release statement as per format </td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black">
                                                                <asp:fileupload id="fuDocuments4" runat="server" />
                                                                <asp:button id="btnUpload4" runat="server" onclick="btnUpload4_Click" text="Click here to Upload" />
                                                            </td>
                                                            <td align="left" style="border: solid thin black; background: white; color: black">
                                                                <asp:hyperlink id="lblupload4" runat="server" cssclass="LBLBLACK" target="_blank" width="165px">[lblFileName]</asp:hyperlink>
                                                                <asp:label id="lblAttachedFileName4" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trMSME2" runat="server" visible="false">
                                                            <td align="center" style="border: solid thin black; background: white; color: black">5 </td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black; text-align: left;">Registration Copy with Commercial taxes Department</td>
                                                            <td align="center" style="border: solid thin black; background: white; color: black">
                                                                <asp:fileupload id="fupCommDoc" runat="server" />
                                                                <asp:button id="btnCommDoc" runat="server" onclick="btnCommDoc_Click" text="Click here to Upload" />
                                                            </td>
                                                            <td align="left" style="border: solid thin black; background: white; color: black">
                                                                <asp:hyperlink id="hplCommDoc" runat="server" cssclass="LBLBLACK" target="_blank" width="165px">[lblFileName]</asp:hyperlink>
                                                                <asp:label id="lblCommDoc" runat="server" font-bold="true" forecolor="Green" visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:button id="BtnSave" runat="server" cssclass="btn btn-primary" height="32px" onclick="BtnSave_Click" tabindex="10" text="Submit" validationgroup="group" width="90px" />
                                                    &nbsp;&nbsp;
                                                    <asp:button id="BtnPrevious" runat="server" cssclass="btn btn-danger" height="32px" onclick="BtnPrevious_Click" tabindex="10" text="Previous" width="90px" />
                                                    &nbsp; &nbsp;&nbsp;<asp:button id="BtnNext" runat="server" cssclass="btn btn-danger" height="32px" onclick="BtnNext_Click" tabindex="10" text="Next" validationgroup="group" width="90px" enabled="false" />
                                                    &nbsp; &nbsp;<asp:button id="BtnClear" runat="server" causesvalidation="False" cssclass="btn btn-warning" height="32px" onclick="BtnClear_Click" tabindex="10" text="ClearAll" tooltip="To Clear  the Screen" width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a>
                                                        <asp:label id="lblmsg" runat="server"></asp:label>
                                                    </div>
                                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                        <asp:label id="lblmsg0" runat="server"></asp:label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </caption>
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

            $("input[id$='txtExpectedDCP']").datepicker(
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
            $("input[id$='txtExpectedDCP']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDISCOMApplDate']").datepicker(
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
            $("input[id$='txtDISCOMApplDate']").datepicker(
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
