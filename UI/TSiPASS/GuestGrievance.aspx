<%@ page title=":: TS-iPASS ::  " language="C#" masterpagefile="~/UI/TSiPASS/EmptyMaster.master" autoeventwireup="true" codefile="GuestGrievance.aspx.cs" inherits="TSTBDCReg1" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">

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

        .style21 {
            height: 35px;
        }

        .style26 {
            height: 21px;
        }

        .style27 {
            height: 21px;
        }

        .style34 {
            height: 21px;
            width: 261px;
        }

        .style35 {
            height: 35px;
            width: 261px;
        }

        .style36 {
            width: 261px;
        }

        .style41 {
            height: 29px;
        }

        .style42 {
            width: 261px;
            height: 29px;
        }

        .style46 {
            height: 44px;
        }

        .style47 {
            height: 44px;
            width: 261px;
        }

        .style48 {
            width: 10px;
            height: 44px;
        }

        .style49 {
            width: 206px;
            height: 44px;
        }

        .LBLBLACK {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script language="javascript" type="text/javascript">
        function confirmMAUD() {
            if (confirm("Are you sure you want to send the record to MA & UD"))
                return true;
            return false;
        }
    </script>

    <div align="left">
        <ol class="breadcrumb">
            You are here  &nbsp;!&nbsp; &nbsp; &nbsp;<li><i></i><a href="Home.aspx">Home</a></li>
            <li class="active">
                <a href="#">
                    <asp:label id="lblHead1" runat="server" cssclass="LBLBLACK" text="Grievance/Feedback" font-bold="True"></asp:label>
                </a></li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:label id="lblHead2" runat="server" cssclass="LBLBLACK" font-bold="True"
                                width="199px"></asp:label>
                        </h3>
                    </div>

                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td align="center" class="style21" style="padding: 5px; margin: 2px">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="style26" colspan="5"
                                                style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label558" runat="server" cssclass="LBLBLACK" font-bold="True"
                                                    width="199px"></asp:label>
                                            </td>
                                            <td class="style27" colspan="5" style="padding: 5px; margin: 5px;"><font
                                                color="red"><strong>* Fields are mandatory</strong></font></td>
                                        </tr>
                                        <tr id="trgrivenance" runat="server" visible="true">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label1" runat="server" cssclass="LBLBLACK" width="199px">Register Your:</asp:label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:dropdownlist id="ddlRegisterAs" runat="server" class="form-control txtbox"
                                                    height="33px" tabindex="1" width="270px" autopostback="True" onselectedindexchanged="ddlRegisterAs_SelectedIndexChanged">
                                                    <asp:listitem>--Select--</asp:listitem>
                                                    <asp:listitem value="G">Grievance</asp:listitem>
                                                    <asp:listitem value="F">Feedback</asp:listitem>
                                                    <asp:listitem value="S">Suggestions</asp:listitem>
                                                </asp:dropdownlist>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server"
                                                    controltovalidate="ddlRegisterAs" errormessage="Please Select Register Your"
                                                    validationgroup="group" initialvalue="--Select--">
                                                    *</asp:requiredfieldvalidator>
                                            </td>

                                        </tr>
                                        <tr runat="server" id="trData" visible="false">
                                            <td colspan="10">
                                                <table>
                                                    <tr id="tr1" runat="server" visible="true">
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label2" runat="server" cssclass="LBLBLACK" width="199px">Grievance Type</asp:label>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px;" colspan="4" align="left">
                                                            <asp:radiobuttonlist id="RadioButtonList1" runat="server" width="500px" repeatdirection="Horizontal" textalign="Right" autopostback="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                                                                <asp:listitem text="Registered Industries" value="1" selected="True"></asp:listitem>
                                                                <asp:listitem text="Non-Registered Industries" value="2"></asp:listitem>
                                                            </asp:radiobuttonlist>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server"
                                                                controltovalidate="ddlRegisterAs" errormessage="Please Select Register Your"
                                                                validationgroup="group" initialvalue="--Select--">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>

                                                    </tr>

                                                    <tr id="truidno" runat="server" visible="true">
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label567" runat="server" cssclass="LBLBLACK">TS-ipass UID Number:</asp:label>
                                                            <asp:label id="lblstar" runat="server" width="16px" text="*" visible="False"><font
                                                                color="red">*</font></asp:label>
                                                            <br />
                                                            <asp:label id="LBLAVAIABLE" runat="server" text="(If Applicable)" visible="false"></asp:label>
                                                        </td>
                                                        <td class="style26" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="6">
                                                            <asp:textbox id="txtuidno" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                                width="400px" autopostback="True" ontextchanged="txtuidno_TextChanged">
                                                            </asp:textbox>

                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr style="height: 30px">
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                        <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label537" runat="server" cssclass="LBLBLACK">Name<font
                                                                color="red">*</font></asp:label><asp:label id="lblindustar" cssclass="LBLBLACK" runat="server" text="*" visible="false"><font
                                                                    color="red">*</font></asp:label>
                                                        </td>
                                                        <td class="style26" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="6">
                                                            <asp:textbox id="txtindname" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                                width="400px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td>
                                                            <asp:requiredfieldvalidator id="Reqfvindname" runat="server"
                                                                controltovalidate="txtindname" errormessage="Please Enter Industry Name"
                                                                validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="TRdEPTnAME">
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                        <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label566" runat="server" cssclass="LBLBLACK">Department Name<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                            <asp:dropdownlist id="ddldept" runat="server" class="form-control txtbox"
                                                                height="33px" tabindex="1" width="400px">
                                                                <asp:listitem>--Select--</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server"
                                                                controltovalidate="ddldept" errormessage="Please Select Department"
                                                                validationgroup="group" initialvalue="--Select--">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;"
                                                            valign="middle">
                                                            <asp:label id="lblSlno3" runat="server" text="Label">3</asp:label></td>
                                                        <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label565" runat="server" cssclass="LBLBLACK" width="100px">District Name<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                            <asp:dropdownlist id="ddldist" runat="server" class="form-control txtbox"
                                                                height="33px" tabindex="1" width="400px">
                                                                <asp:listitem>--Select--</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="ReqfvDist" runat="server"
                                                                controltovalidate="ddldist" errormessage="Please Select District"
                                                                validationgroup="group" initialvalue="--Select--">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="lblSlno4" runat="server" text="Label">4</asp:label></td>
                                                        <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label556" runat="server" cssclass="LBLBLACK" width="148px">E-Mail<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:textbox id="txtEmail" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="40" tabindex="1" validationgroup="group"
                                                                width="400px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:requiredfieldvalidator id="Refvemail" runat="server"
                                                                controltovalidate="txtEmail" errormessage="Please Enter Email"
                                                                validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                            <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server"
                                                                controltovalidate="txtEmail" errormessage="Please Enter Correct Email"
                                                                validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                validationgroup="group">
                                                                *</asp:regularexpressionvalidator>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>

                                                        <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;"
                                                            valign="middle">
                                                            <asp:label id="lblSlno5" runat="server" text="Label">6</asp:label></td>
                                                        <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label564" runat="server" cssclass="LBLBLACK" height="18px"
                                                                width="111px">Mobile Number<font
                                                                    color="red">*</font></asp:label>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:textbox id="txtMob" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="10" onkeypress="NumberOnly()" tabindex="1" validationgroup="group"
                                                                width="400px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td>
                                                            <asp:requiredfieldvalidator id="reqfvmob" runat="server"
                                                                controltovalidate="txtMob" errormessage="Please Enter Mobile Number"
                                                                validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                <tr runat="server" id="trSubject">
                                                    <td class="style21"
                                                        style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:label id="lblSlno6" runat="server" text="Label">5</asp:label></td>
                                                    <td class="style35" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:label id="Label563" runat="server" cssclass="LBLBLACK" width="137px">Subject<font
                                                            color="red">*</font></asp:label>
                                                    </td>
                                                    <td class="style21" style="padding: 5px; margin: 5px">:</td>
                                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left;"
                                                        colspan="4">
                                                        <asp:dropdownlist id="ddlsubject" runat="server" class="form-control txtbox"
                                                            height="33px" tabindex="1" width="400px" autopostback="True" onselectedindexchanged="ddlsubject_SelectedIndexChanged">
                                                            <asp:listitem>--Select--</asp:listitem>
                                                        </asp:dropdownlist>
                                                        <asp:dropdownlist id="ddlSugSubj" runat="server" class="form-control txtbox" visible="false"
                                                            height="33px" tabindex="1" width="400px" autopostback="True" onselectedindexchanged="ddlsubject_SelectedIndexChanged">
                                                            <asp:listitem text="--Select--" value="0">--Select--</asp:listitem>
                                                            <asp:listitem text="Approvals" value="9">Approvals</asp:listitem>
                                                            <asp:listitem text="Incentives" value="5">Incentives</asp:listitem>
                                                            <asp:listitem text="ODOP" value="7">ODOP</asp:listitem>
                                                            <asp:listitem text="DEAP" value="10">DEAP</asp:listitem>
                                                            <asp:listitem text="Others" value="6">Others</asp:listitem>

                                                        </asp:dropdownlist>
                                                        <br />
                                                        <asp:textbox id="txtSub" runat="server" class="form-control txtbox"
                                                            maxlength="150" tabindex="1" visible="false"
                                                            validationgroup="group" width="400px">
                                                        </asp:textbox>
                                                    </td>
                                                    <td>
                                                        <asp:requiredfieldvalidator id="RefvSub" runat="server"
                                                            controltovalidate="ddlsubject" errormessage="Please Select Grievance Subject"
                                                            validationgroup="group" initialvalue="--Select--">
                                                            *</asp:requiredfieldvalidator>
                                                    </td>
                                                </tr>
                                        <tr>
                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;"
                                                valign="middle">
                                                <asp:label id="lblSlno7" runat="server" text="Label">6</asp:label></td>
                                            <td class="style42" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label543" runat="server" cssclass="LBLBLACK" width="210px">Description<font
                                                    color="red">*</font></asp:label>
                                            </td>
                                            <td class="style41" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;"
                                                colspan="6">
                                                <asp:textbox id="txtDesc" runat="server" class="form-control txtbox"
                                                    height="100px" maxlength="40" tabindex="1" textmode="MultiLine"
                                                    validationgroup="group" width="643px">
                                                </asp:textbox>
                                            </td>
                                            <td>
                                                <asp:requiredfieldvalidator id="RefvDesc" runat="server"
                                                    controltovalidate="txtDesc" errormessage="Please Enter Description"
                                                    validationgroup="group">
                                                    *</asp:requiredfieldvalidator>
                                            </td>
                                        </tr>
                                        <tr id="rem" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                valign="middle">
                                                <asp:label id="lblSlno8" runat="server" text="Label">7</asp:label></td>
                                            <td class="style36" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:label id="Label549" runat="server" cssclass="LBLBLACK" width="114px">Upload:</asp:label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                                colspan="3">
                                                <asp:fileupload id="FileUpload" runat="server" class="form-control txtbox" width="400px"
                                                    height="28px" />
                                                <asp:hyperlink id="lblFileName1" runat="server" cssclass="LBLBLACK"
                                                    target="_blank" width="165px">
                                                    [lblFileName]</asp:hyperlink>
                                                <br />
                                                <asp:label id="Label560" runat="server" visible="False"></asp:label>
                                            </td>
                                            <td class="style6" colspan="3"
                                                style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                <asp:button id="BtnUpload" runat="server" cssclass="btn btn-xs btn-warning"
                                                    height="28px" tabindex="10" text="Upload" width="72px"
                                                    onclick="BtnUpload_Click" visible="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center; height: 50px" colspan="10">&nbsp;&nbsp;<asp:button id="BtnSave" runat="server" cssclass="btn btn-primary"
                                                height="32px" tabindex="10" text="Submit" validationgroup="group"
                                                width="90px" onclick="BtnSave_Click" />
                                                &nbsp;
                                            <asp:button id="BtnClear" runat="server" causesvalidation="False"
                                                cssclass="btn btn-warning" height="32px" onclick="BtnClear_Click" tabindex="10"
                                                text="Cancel" tooltip="To Clear  the Screen" width="90px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>

                                <td colspan="6" align="center" style="padding: 5px; margin: 5px">
                                    <div id="DIV1" runat="server" visible="false">
                                        <b>
                                            <h4>
                                                <asp:label id="Label3" runat="server" text="Note: No fee or cost is charged by the government to enterprises or applicants for submitting grievances"></asp:label>
                                                <asp:label id="Label4" runat="server"></asp:label>
                                            </h4>
                                        </b>
                                    </div>

                                </td>
                            </tr>
                            </table>
                                </td>
                            </tr>

                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" class="alert alert-success">
                                        <a aria-label="close" class="close" data-dismiss="alert"
                                            href="AddQualification.aspx">×</a> <strong></strong>
                                        <asp:label
                                            id="lblmsg" runat="server"></asp:label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:label id="lblmsg0" runat="server"></asp:label>
                                    </div>

                                    <asp:hiddenfield id="hdfID" runat="server" />
                                    <asp:validationsummary id="ValidationSummary1" runat="server"
                                        showmessagebox="True" showsummary="False" validationgroup="group" />
                                    <asp:validationsummary id="ValidationSummary2" runat="server"
                                        showmessagebox="True" showsummary="False" validationgroup="child" />
                                    <asp:hiddenfield id="hdfFlagID" runat="server" />
                                </td>
                            </tr>
                        </table>



                    </div>

                </div>
            </div>
        </div>

    </div>


</asp:content>

