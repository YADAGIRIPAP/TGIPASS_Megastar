<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="AgreementBondUploadEnterpriseChanges.aspx.cs" inherits="UI_TSiPASS_AgreementBondUploadEnterpriseChanges" %>


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

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .GRD {
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 10px;
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/
            padding: 10px; /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        .GRDHEADER {
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url(../images/bg_blue_grd.gif);
            border-color: #ffffff;
            border-style: solid;
            border-width: 1px;
        }

        .auto-style1 {
            height: 45px;
        }

        .auto-style2 {
            height: 45px;
            width: 291px;
        }

        .auto-style3 {
            width: 291px
        }

        .auto-style4 {
            height: 45px;
            width: 274px;
        }

        .auto-style5 {
            float: left;
            width: 274px;
        }

        .auto-style6 {
            width: 274px;
        }

        .auto-style8 {
            height: 30px;
            width: 502px;
        }

        .auto-style10 {
            float: left;
            width: 101px;
        }

        .auto-style11 {
            height: 57px;
        }

        .auto-style12 {
            width: 200px;
            height: 57px;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtBreakFromDate0']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtBreakFromDate']").datepicker(
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
            $("input[id$='txtDateofCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtNewPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
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
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>


    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3>Release Documents</h3>
                    </div>

                    <div class="panel-body">
                        <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                            width="90%">
                            <tr>
                                <td>
                                    <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                                        width="100%">
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                    </div>
                    <div class="panel-body" runat="server" id="divFirst">
                        <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                            width="90%">
                            <tr>
                                <td class="auto-style4">

                                    <div style="float: right; margin-top: 5px; margin-left: 20px;">
                                        <b>Upload Agreement Bond Copy : </b>

                                    </div>
                                </td>
                                <td class="auto-style2">

                                    <div style="float: left">
                                        <asp:fileupload id="fucAgreementBond" runat="server" class="form-control txtbox" />
                                    </div>
                                </td>
                                <td class="auto-style1">
                                    <div style="float: left">
                                        <asp:button runat="server" text="Upload" id="bntUpload" cssclass="btn btn-primary"
                                            style="margin-left: 12px; margin-top: 1px;" onclick="bntUploadAgreement_Click" />
                                    </div>

                                </td>
                            </tr>
                            <tr>

                                <td class="auto-style5">
                                    <div>
                                        <asp:hyperlink id="hplFilenameLink" text="Click here for format" runat="server" cssclass="LBLBLACK" width="165px" visible="false"
                                            target="_blank">
                                        </asp:hyperlink>
                                    </div>
                                </td>
                                <td class="auto-style3">

                                    <asp:hyperlink id="lblFileName" runat="server" cssclass="LBLBLACK" width="165px" visible="false"
                                        target="_blank">
                                    </asp:hyperlink>

                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style6">


                                    <div>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style6">

                                    <div style="float: right; margin-top: 5px; margin-left: 20px;">
                                        <b>Upload Assignment Letter : </b>

                                    </div>


                                </td>
                                <td class="auto-style3">
                                    <div style="float: left">
                                        <asp:fileupload id="fucAssignment" runat="server" class="form-control txtbox" />
                                    </div>
                                </td>
                                <td>
                                    <div style="float: left">
                                        <asp:button runat="server" text="Upload" id="btnUploadAssignmentLetter" cssclass="btn btn-primary"
                                            style="margin-left: 12px; margin-top: 1px;" onclick="btnUploadAssignmentLetter_Click" />
                                    </div>

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <div>
                                    </div>
                                </td>
                                <td class="auto-style3">

                                    <asp:hyperlink runat="server" id="lnkAssignmentLetter" target="_blank"></asp:hyperlink>

                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>

                    <div class="panel-body" runat="server" id="divSecond">
                        <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0" width="97%">


                            <tr>
                                <td colspan="2" style="float: left">
                                    <b>Please select the box, if there is</b>
                                </td>
                                <td></td>
                            </tr>

                        </table>

                        <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0" width="97%">


                            <tr>
                                <td style="text-align: left; height: 30px;">
                                    <asp:checkbox runat="server" id="chkBankChange" text="" autopostback="true" oncheckedchanged="chkBankChange_CheckedChanged" />
                                    Change of Bank by the Enterprise</td>
                            </tr>


                            <tr id="trBankDtls" runat="server" visible="false">
                                <td>
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">1
                                            </td>
                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">Name of the Bank
                                            </td>
                                            <td class="style21" style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                <asp:dropdownlist id="ddlBank" runat="server" class="form-control txtbox" tabindex="5"
                                                    width="250px" validationgroup="group">
                                                </asp:dropdownlist>
                                                <asp:requiredfieldvalidator id="rfvBank" runat="server" initialvalue="-- SELECT --"
                                                    controltovalidate="ddlBank" errormessage="Please Select Bank Name" validationgroup="group"
                                                    setfocusonerror="true" display="None">
                                                </asp:requiredfieldvalidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">2
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">Branch Name<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txtBranchName" runat="server" class="form-control txtbox" height="28px"
                                                    maxlength="40" tabindex="5" validationgroup="group" width="250px">
                                                </asp:textbox>
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator54" runat="server" controltovalidate="txtBranchName"
                                                    errormessage="Please Enter Bank Name" validationgroup="group" setfocusonerror="true"
                                                    display="None">
                                                </asp:requiredfieldvalidator>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                            </td>
                                            <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">3
                                            </td>
                                            <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">Account Number<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                            </td>
                                            <td class="style21" style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txtAccNumber" runat="server" class="form-control txtbox" height="28px"
                                                    maxlength="25" tabindex="5" validationgroup="group" width="250px">
                                                </asp:textbox>
                                                <asp:requiredfieldvalidator id="rfvAcNo" runat="server" controltovalidate="txtAccNumber"
                                                    errormessage="Please Enter Bank Account Number" validationgroup="group" setfocusonerror="true"
                                                    display="None" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">4
                                            </td>
                                            <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">IFSC Code<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txtIfscCode" runat="server" class="form-control txtbox" height="28px"
                                                    maxlength="12" tabindex="5" validationgroup="group" width="250px">
                                                </asp:textbox>
                                                <asp:requiredfieldvalidator id="rfvIFSCCode" runat="server" controltovalidate="txtIfscCode"
                                                    errormessage="Please Enter IFSC Code" validationgroup="group" setfocusonerror="true"
                                                    display="None" />
                                            </td>
                                            <td colspan="3">
                                                <a href="https://www.bankifsccode.com/" target="_blank">Find IFSC code</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">5
                                            </td>
                                            <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">Account Type<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="left">
                                                <asp:dropdownlist id="ddlaccounttype" class="form-control txtbox" width="250px" runat="server">
                                                    <asp:listitem value="0" text="--Select--"></asp:listitem>
                                                    <asp:listitem value="1" text="Savings Account"></asp:listitem>
                                                    <asp:listitem value="2" text="Current Account"></asp:listitem>
                                                    <asp:listitem value="3" text="Term Loan Account"></asp:listitem>

                                                    <asp:listitem value="4" text="Non Operative Account"></asp:listitem>
                                                </asp:dropdownlist>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">6
                                            </td>
                                            <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">Remarks<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:textbox id="txtremarks" textmode="MultiLine" runat="server" class="form-control txtbox"
                                                    height="60px" maxlength="12" tabindex="5" validationgroup="group" width="300px">
                                                </asp:textbox>
                                            </td>
                                        </tr>
                                        <%--  <tr>
                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">7
                                                        </td>
                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">Upload the letter from Banker indication Account Details
                                                        </td>
                                                        <td class="style21" style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="CS"
                                                                Height="28px" />

                                                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LBLBLACK" Width="165px" Visible="false"
                                                                Target="_blank"></asp:HyperLink>
                                                            <br />
                                                            <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>

                                                            <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning"
                                                                Height="28px" TabIndex="10" Text="Upload"
                                                                Width="72px" OnClick="BtnSave3_Click" />
                                                        </td>
                                                    </tr>--%>
                                        <%-- <tr id="troptpbutton" runat="server" visible="false">
                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"><a href="" target="_blank">Certificate from Banker</a></td>
                                                        <td class="style21" style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-xs btn-warning" Height="30px" Text="Please Click Here to Confirm Entered Details" Width="300px" OnClick="Button1_Click" ValidationGroup="group" /></td>
                                                    </tr>
                                                    <tr id="trotp" runat="server" visible="false">
                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">Please Enter OTP Recieved on your phone
                                                        </td>
                                                        <td class="style21" style="padding: 5px; margin: 5px">:
                                                        </td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtOTPVerify" Enabled="false" runat="server" class="form-control txtbox" MaxLength="6" Height="28px" Width="180px" ToolTip="Please enter OTP Rcvd on your phone here" OnTextChanged="txtOTPVerify_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                    </table>
                                </td>
                            </tr>

                        </table>
                        <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0" width="97%">

                            <tr>
                                <td style="text-align: left;" class="auto-style8">
                                    <asp:checkbox runat="server" id="chkManagementChange" text="" autopostback="true" oncheckedchanged="chkManagementChange_CheckedChanged" />
                                    Change of Management by the Enterprise</td>
                            </tr>

                            <tr id="trManagementDtls" visible="false" runat="server">
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <td style="float: left">Partner or Director dropped
                                                </td>
                                                <td>:
                                                </td>
                                                <td>

                                                    <asp:textbox id="txtManagement" runat="server" width="221px"></asp:textbox>
                                                </td>


                                                <td>Partner or Director Included
                                                </td>
                                                <td>:
                                                </td>
                                                <td>
                                                    <asp:textbox id="txtINCPartner" runat="server" width="221px"></asp:textbox>

                                                </td>
                                            </td>
                                        </tr>
                                    </table>

                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">
                                    <asp:checkbox runat="server" id="chkBreakProd" text="" autopostback="true" oncheckedchanged="chkBreakProd_CheckedChanged" />
                                    Break in Production</td>
                            </tr>
                            <tr runat="server" id="trBreakDtls" visible="false">
                                <td>
                                    <table>
                                        <tr>
                                            <td>From Date 
                                            </td>
                                            <td>:
                                            </td>
                                            <td>

                                                <asp:textbox id="txtBreakFromDate0" runat="server" maxlength="10" width="221px"></asp:textbox>

                                            </td>
                                            <td></td>
                                            <td>To date
                                            </td>
                                            <td>:
                                            </td>
                                            <td>
                                                <asp:textbox id="txtBreakFromDate" runat="server" maxlength="10" width="221px"></asp:textbox>
                                            </td>
                                            <td style="margin: 20px"></td>

                                        </tr>


                                    </table>
                                </td>




                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" class="auto-style8">
                                    <asp:checkbox runat="server" id="chkSickness" text="" autopostback="true" oncheckedchanged="chkSickness_CheckedChanged" />
                                    Closure / Sickness of the unit found</td>
                            </tr>
                            <tr runat="server" id="trSicknessDtls" visible="false">
                                <td style="text-align: left;" class="auto-style8">
                                    <asp:textbox id="txtSickness" runat="server" width="611px"></asp:textbox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" class="auto-style8">
                                    <asp:checkbox runat="server" id="chkLocationChange" text="" autopostback="true" oncheckedchanged="chkLocationChange_CheckedChanged" />
                                    Change in location of the Unit</td>
                            </tr>
                            <tr runat="server" id="trLocation" visible="false">
                                <td style="text-align: left;">
                                    <table>
                                        <tr>
                                            <td>Plot/Survey No
                                            </td>
                                            <td></td>
                                            <td>

                                                <asp:textbox id="txtSurveyNo" height="40px" textmode="MultiLine" width="180px" runat="server"></asp:textbox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>District: </td>
                                            <td style="width: 20px;"></td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:dropdownlist id="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                    height="33px" width="180px" autopostback="True" onselectedindexchanged="ddlProp_intDistrictid_SelectedIndexChanged">
                                                    <asp:listitem>--District--</asp:listitem>
                                                </asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Mandal: </td>
                                            <td style="width: 20px;"></td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:dropdownlist id="ddlProp_intMandalid" runat="server" class="form-control txtbox"
                                                    height="33px" width="180px" autopostback="True" onselectedindexchanged="ddlProp_intMandalid_SelectedIndexChanged">
                                                    <asp:listitem>--Mandal--</asp:listitem>
                                                </asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Village: </td>
                                            <td style="width: 20px;"></td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:dropdownlist id="ddlProp_intVillageid" runat="server" class="form-control txtbox"
                                                    height="33px" width="180px" autopostback="True">
                                                    <asp:listitem>--Village--</asp:listitem>
                                                </asp:dropdownlist>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" class="auto-style8">
                                    <asp:checkbox runat="server" id="chkLOAChange" text="" autopostback="true" oncheckedchanged="chkLOAChange_CheckedChanged" />
                                    Change in Line of Activity</td>
                            </tr>

                            <tr id="loatr" runat="server" visible="false">
                                <td>
                                    <table>
                                        <tr>
                                            <td style="float: left">
                                                <b>Activities Added</b>
                                            </td>
                                            <td style="width: 27px">&nbsp;</td>
                                            <td valign="top">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label387" runat="server" cssclass="LBLBLACK" width="210px">Manufacture Item <font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                            <asp:textbox id="txtitem" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="40" tabindex="1" onkeypress="Names()"
                                                                validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server"
                                                                controltovalidate="txtitem" errormessage="Please enter Item"
                                                                validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:label id="Label396" runat="server" cssclass="LBLBLACK" width="165px">Quantity Per<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:dropdownlist id="ddlQuantityper1" runat="server" class="form-control txtbox" tabindex="1"
                                                                height="33px" width="180px">
                                                                <asp:listitem>--Select--</asp:listitem>
                                                                <asp:listitem value="Day">Day</asp:listitem>
                                                                <asp:listitem value="Week">Week</asp:listitem>
                                                                <asp:listitem value="Month">Month</asp:listitem>
                                                                <asp:listitem value="Years">Years</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server"
                                                                controltovalidate="ddlQuantityper1" errormessage="Please select Quantity"
                                                                initialvalue="--Select--" validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 27px">
                                                <asp:label id="Label348" runat="server" cssclass="LBLBLACK" width="50px"></asp:label>
                                            </td>
                                            <td valign="top">
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">3</td>
                                                        <td style="width: 200px;">
                                                            <asp:label id="Label431" runat="server" cssclass="LBLBLACK" width="165px">Quantity<font
                                                                color="red">*</font></asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:textbox id="txtquantity" runat="server" class="form-control txtbox"
                                                                height="28px" maxlength="40" onkeypress="return inputOnlyNumbers(event)" tabindex="1"
                                                                validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server"
                                                                controltovalidate="txtquantity" errormessage="Please enter Quantity"
                                                                validationgroup="group">
                                                                *</asp:requiredfieldvalidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">4</td>
                                                        <td style="width: 200px;">
                                                            <asp:label id="Label429" runat="server" cssclass="LBLBLACK" width="165px">Quantity In</asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:dropdownlist id="ddlquantityin" runat="server" class="form-control txtbox" tabindex="1"
                                                                height="33px" width="180px" autopostback="True"
                                                                onselectedindexchanged="ddlquantityin_SelectedIndexChanged">
                                                                <asp:listitem>--Select--</asp:listitem>
                                                                <asp:listitem value="KG">KG</asp:listitem>
                                                                <asp:listitem value="Tone">Tone</asp:listitem>
                                                                <asp:listitem value="Liters">Liters</asp:listitem>
                                                                <asp:listitem value="Others">Others</asp:listitem>
                                                            </asp:dropdownlist>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    </tr>
                                                    <tr id="qty" runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px" class="auto-style11"></td>
                                                        <td class="auto-style12">
                                                            <asp:label id="Label432" runat="server" cssclass="LBLBLACK" width="165px">Quantity In</asp:label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style11">:</td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style11">
                                                            <asp:textbox id="txtitem2" runat="server" class="form-control txtbox" onkeypress="Names()"
                                                                height="28px" maxlength="40" tabindex="1" validationgroup="group" width="180px">
                                                            </asp:textbox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style11"></td>
                                                    </tr>
                                                    <tr id="tr2" runat="server">
                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td style="width: 200px;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:button id="BtnSave2" runat="server" cssclass="btn btn-xs btn-warning"
                                                                height="28px" tabindex="10" text="Add New" validationgroup="group"
                                                                width="72px" onclick="BtnSave2_Click1" />
                                                            &nbsp;<asp:button id="BtnClear0" runat="server" causesvalidation="False"
                                                                cssclass="btn btn-xs btn-danger" height="28px" tabindex="10" text="Cancel"
                                                                tooltip="To Clear  the Screen" width="73px" onclick="BtnClear0_Click2" /></td>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="trLOA" runat="server">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                <asp:gridview id="gvCertificate" runat="server" autogeneratecolumns="False"
                                                    bordercolor="#003399" borderstyle="Solid" borderwidth="1px" cellpadding="4"
                                                    cssclass="GRD" forecolor="#333333" gridlines="None"
                                                    onrowdatabound="gvCertificate_RowDataBound"
                                                    onrowdeleting="gvCertificate_RowDeleting" width="100%"
                                                    datakeynames="incid">
                                                    <rowstyle backcolor="#ffffff" />
                                                    <columns>
                                                        <asp:commandfield headertext="Edit" showselectbutton="True" visible="False" />
                                                        <asp:commandfield headertext="DELETE" controlstyle-forecolor="Red" controlstyle-font-bold="true" deletetext="DELETE" showdeletebutton="True" />
                                                        <asp:boundfield datafield="Manf_ItemName" headertext="Item Name" />
                                                        <asp:boundfield datafield="Manf_Item_Quantity" headertext="Item Quantity" />
                                                        <asp:boundfield datafield="Manf_Item_Quantity_In" headertext="Quantity In" />
                                                        <asp:boundfield datafield="Manf_Item_Quantity_Per" headertext="Quantity Per" />

                                                        <asp:boundfield datafield="OtherItemName" headertext="Type of Quantity" />

                                                    </columns>
                                                    <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                    <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                    <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                    <headerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                    <editrowstyle backcolor="#013161" />
                                                    <alternatingrowstyle backcolor="White" />
                                                </asp:gridview>
                                            </td>




                                        </tr>
                                        <tr id="loaSaveButton" runat="server" visible="false">
                                            <td></td>

                                            <td>
                                                <asp:button id="BtnSave1" runat="server" cssclass="btn btn-primary"
                                                    height="32px" tabindex="10" text="Save"
                                                    width="90px" onclick="BtnSave1_Click" />
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" class="auto-style8">
                                    <asp:checkbox runat="server" id="chkOther" text="" autopostback="true" oncheckedchanged="chkOther_CheckedChanged" />
                                    Any other specific reasons not worthy of receiving incentives Enterprise
                                </td>
                            </tr>
                            <tr runat="server" id="trOtherReasons" visible="false">
                                <td style="text-align: left;" class="auto-style8">
                                    <asp:textbox id="txtOtherReasons" runat="server" width="332px" height="98px" textmode="MultiLine"></asp:textbox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divAbide" runat="server" style="padding: 20px">
                        <table style="vertical-align: top; text-align: center; padding: 20px" cellpadding="0" cellspacing="0" width="97%">

                            <tr id="chkAbideTr" runat="server" visible="true">

                                <td class="auto-style10">
                                    <asp:checkbox runat="server" id="chkAbide" text="" autopostback="true" />
                                </td>
                                <td style="float: left; color: red; font-size: 20px">
                                    <b>I Hereby abide by the conditions specified in the agreement bond submitted by the Unit.</b>

                                </td>
                                <td></td>

                            </tr>
                            <%--
                                        <tr id="trselectBox">
                                            <td colspan="2" style="float:left">

                                                Please select the box, if there is</td>
                                            <td>

                                            </td>
                                        </tr>--%>
                        </table>
                    </div>
                    <div id="divmatter" runat="server">
                        <table>
                            <tr>
                                <td style="text-align: justify">
                                    <b><u>Note:</u> After uploading the Agreement Bond Copy & Assignment Letter, click on submit. Afterwards, once again open the incentives dashboard and then click on update latest details and then on "LATEST DETAILS UPDATION". In the details updation page you will be seeing the earlier uploaded documents. Please change the details if there are any and then click on "I Hereby abide by the conditions specified in the agreement bond submitted by the Unit." or if there are no changes to be made then directly click on "I Hereby abide by the conditions specified in the agreement bond submitted by the Unit." and click on Submit button for final submission. </b>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div>
                        <table>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" align="center" class="style7">
                                    <asp:button id="btnSave" runat="server" cssclass="btn btn-primary" height="32px"
                                        text="Submit" width="150px" onclick="btnSave_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
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
                            <tr>
                                <td>
                                    <asp:hiddenfield id="hdfID" runat="server" />
                                    <asp:hiddenfield id="hdfFlagID" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
</asp:content>

