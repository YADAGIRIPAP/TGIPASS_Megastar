<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="IncentiveFORMVI.aspx.cs" Inherits="UI_TSiPASS_IncentiveFORMVI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="background-color: #339966">
                        <%-- <h3 class="panel-heading" style="font-size: large; text-align: center">APPLICATION CUM VERIFICATION FOR
                    <br />
                            <strong>REIMBURSEMENT OF CERTIFICATION CHARGES FOR
                                <br />
                                ACQUIRING
                        QUALITY CERTIFICATION COST UNDER T-PRIDE—TELANGANA STATE</strong><br />
                            PROGRAM FOR RAPID INCUBATION
                        OF DALIT ENTREPRENEURS INCENTIVE SCHEME.<br />
                            (G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)<br />
                        </h3>--%>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblheadTPRIDE" runat="server" Visible="false"> </asp:Label>
                                    <asp:Label ID="lblheadTIDEA" runat="server" Visible="false">  </asp:Label>
                                    <asp:Label ID="lblMSMEPolicy" runat="server" Visible="false" Text="Reimbursement of
                                        Acquiring Quality Certification Cost" ForeColor="White" Font-Bold="true" Font-Size="20px">
                                    </asp:Label><asp:HiddenField ID="hdnMSMEApplied" runat="server" />
                                </td>

                            </tr>
                        </table>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="5" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; font-size: 12pt"
                                    valign="top">Details of ISO 9000 / ISO 14001 / HACCP Certificate
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">1
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name of certifying agency<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                    <asp:TextBox ID="txtagencyName" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtagencyName"
                                        ErrorMessage="Please Enter Name of Certifying Agency" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">2
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="165px">Certificate Number<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:TextBox ID="txtCertificatNumber" runat="server" class="form-control txtbox"
                                        onkeypress="NumberOnly()" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCertificatNumber"
                                        ErrorMessage="Please Enter txtCertificat Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">3
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="200px">Date of Issue<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtDateofIssue" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDateofIssue"
                                        ErrorMessage="Please Select Date of Issue" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">4
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="200px">Period of Validity<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtPeriodofValidity" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPeriodofValidity"
                                        ErrorMessage="Please Eneter PeriodofValidity" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trMSME1" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">Items of Manufacture/Processing as indicated in UDyam Registration  </td>
                                <td style="padding: 5px; margin: 5px">:</td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtItems" runat="server" class="form-control txtbox"
                                        Height="28px"  TabIndex="1" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtItems"
                                        ErrorMessage="Please Eneter Items of Manufacture" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: left;" valign="top">
                                    <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                        Width="354px">Address of certifying agency</asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">5
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Width="165px">State<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:DropDownList ID="ddlstate" runat="server" class="form-control txtbox" Height="33px"
                                        Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"
                                        TabIndex="1">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlstate"
                                        ErrorMessage="Please select state" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="dist" runat="server" visible="false">
                                <td style="text-align: left;">6
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:TextBox ID="txtDistrict" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>
                            <tr id="mandal" runat="server" visible="false">
                                <td style="text-align: left;">7
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:TextBox ID="txtMandal" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>
                            <tr id="Vill" runat="server" visible="false">
                                <td style="text-align: left;">8
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">Village<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtVillage" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">&nbsp;
                                </td>
                            </tr>
                            <tr id="dist1" visible="false" runat="server">
                                <td style="text-align: left;">6
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label352" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                        Height="33px" TabIndex="1" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"
                                        Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddldistrict"
                                        ErrorMessage="Please select  District" InitialValue="--Select--" ValidationGroup="group"
                                        Visible="False">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="mandal1" visible="false" runat="server">
                                <td style="text-align: left;">7
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label398" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                                        Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMandal"
                                        ErrorMessage="Please select  Mandal" InitialValue="--Select--" ValidationGroup="group"
                                        Visible="False">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="vill1" runat="server" visible="false">
                                <td style="text-align: left;">8
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label399" runat="server" CssClass="LBLBLACK" Width="165px">Village/Town<font 
                                                            color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:DropDownList ID="ddlvillage" runat="server" class="form-control txtbox" TabIndex="1"
                                        Height="33px" Width="180px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlvillage"
                                        ErrorMessage="Please select  Village" InitialValue="--Select--" ValidationGroup="group"
                                        Visible="False">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">9
                                </td>
                                <td style="text-align: left;">Door No<span class="style5">*</span>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtDoorNo"
                                        ErrorMessage="Please enter Door Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">10&nbsp;
                                </td>
                                <td style="width: 200px; text-align: left;">PinCode<span class="style5">*</span>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtPincode" runat="server" class="form-control txtbox" Height="28px"
                                        MaxLength="6" TabIndex="1" onkeypress="NumberOnly()" onblur="checkLength(this)"
                                        ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPincode"
                                        ErrorMessage="Please enter PinCode number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; font-size: 12pt"
                                    valign="top">Subsidy already received for the certification in Rs.
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">11&nbsp;
                                </td>
                                <td style="text-align: left;">From Central Government<span class="style5">*</span>
                                </td>
                                <td style="text-align: left;">:
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtFromCentralGovernment" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                </td>
                                <td style="text-align: left;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtFromCentralGovernment"
                                        ErrorMessage="Please Eneter Subsidy already received for the certification in Rs. From Central Government"
                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                <td style="text-align: left; vertical-align: top;">12&nbsp;&nbsp;
                                </td>
                                <td style="text-align: left; vertical-align: top;">From State Government<span class="style5">*</span>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtFromStateGovernment" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group"
                                        Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtFromStateGovernment"
                                        ErrorMessage="Please Eneter Subsidy already received for the certification in Rs. From State Government"
                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">13&nbsp; </td>
                                <td style="text-align: left;">From Financing Institution<span class="style5">*</span>
                                </td>
                                <td style="text-align: left;">:
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtFinancingInstitution" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="text-align: left;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtFinancingInstitution"
                                        ErrorMessage="Please Eneter Subsidy already received for the certification in Rs. From Financing Fnstitution"
                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                                <td style="text-align: left; vertical-align: top;">14&nbsp;&nbsp;
                                </td>
                                <td style="text-align: left;">Amount spent in acquiring the certification<span class="style5">*</span>
                                </td>
                                <td style="padding: 5px; margin: 5px">:
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtAmountspentinacquiringthecertification" runat="server" class="form-control txtbox"
                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmountspentinacquiringthecertification"
                                        ErrorMessage="Please Enter Amount spent in acquiring the certification" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" colspan="10" align="center"></td>

                                <td style="text-align: left;" colspan="3" align="center">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" colspan="10" align="center"><b>Enclosures:</b></td>

                                <td style="text-align: left;" colspan="3" align="center">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" colspan="10" align="center"><b>Enclosures:</b></td>

                                <td style="text-align: left;" colspan="3" align="center">&nbsp;
                                </td>
                            </tr>

                            <tr id="Panelpcb1" runat="server">
                                <td style="text-align: left; vertical-align: top; height: 70px;">1&nbsp; 
                                </td>
                                <td style="text-align: left; vertical-align: top; height: 70px;"
                                    colspan="3">Certificate from GM, DIC confirming functional status at the time of acquiring ISO
                                9000 / ISO 14001 / HACCP Certificate
                                </td>
                                <td style="text-align: left; height: 70px; vertical-align: top;">:
                                </td>
                                <td class="style6" style="text-align: left; height: 70px; vertical-align: top;"
                                    colspan="3">
                                    <asp:FileUpload ID="FileUpload10" runat="server" CssClass="CS" Height="28px" />
                                    <asp:HyperLink ID="Label453" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                    <br />
                                    <asp:Label ID="Label454" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td style="height: 70px; text-align: left; vertical-align: top;">
                                    <asp:Button ID="Button8" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button8_Click" />
                                </td>
                            </tr>
                            <tr id="panelTSCT1" runat="server">
                                <td style="text-align: left; vertical-align: top; height: 70px;">2&nbsp; 
                                </td>
                                <td style="text-align: left; vertical-align: top; height: 70px;"
                                    colspan="3">Attested copy of the quality certificate acquired
                                </td>
                                <td style="text-align: left; height: 70px; vertical-align: top;">:
                                </td>
                                <td class="style6" style="text-align: left; height: 70px; vertical-align: top;"
                                    colspan="3">
                                    <asp:FileUpload ID="FileUpload11" runat="server" CssClass="CS" Height="28px" />
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                    <br />
                                    <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td style="height: 70px; text-align: left; vertical-align: top;">
                                    <asp:Button ID="Button9" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button9_Click" />
                                </td>
                            </tr>
                            <tr id="panelPRD1" runat="server">
                                <td style="text-align: left; vertical-align: top; height: 70px;">3&nbsp;&nbsp; 
                                </td>
                                <td style="text-align: left; vertical-align: top; height: 70px;"
                                    colspan="3">Certificate from CA of expenditure incurred giving the details along with bills,
                                vouchers and proof of payment Undertaking / Declaration from the Managing Director
                                / Proprietor / Partner duly notorised.<br />
                                    <asp:HyperLink ID="HyperLinkCivilEngineersFormat" runat="server" Visible="true" CssClass="LBLBLACK" Width="300px" Target="_blank" NavigateUrl="~/docs/Quality Certification CA Format.pdf">Click here for Prescribed Format</asp:HyperLink>
                                </td>
                                <td style="text-align: left; height: 70px; vertical-align: top;">&nbsp;:&nbsp;
                                </td>
                                <td class="style6" style="text-align: left; height: 70px; vertical-align: top;"
                                    colspan="3">
                                    <asp:FileUpload ID="FileUpload13" runat="server" CssClass="CS" Height="28px" />
                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                    <br />
                                    <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td style="height: 70px; text-align: left; vertical-align: top;">
                                    <asp:Button ID="Button11" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Upload" ValidationGroup="gg" Width="72px" OnClick="Button11_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="padding: 5px; margin: 5px; text-align: center;"></td>
                            </tr>
                            <tr>
                                <td colspan="86" style="padding: 5px; margin: 5px; text-align: left;">
                                    <b>DECLARATION :  
                                    <br />
                                    </b>
                                    I / we hereby declare that the particulars given in the application are correct. In
case any of the statement/information furnished in the application / documents later found to be wrong or
incorrect or misleading, I do hereby bind myself and my Enterprise to pay the full amount received as
reimbursement to the Government on demand in respect of above mentioned activity, within seven days of
the demand being made to me in writing.
                                    <br />
                                    I/We hereby agree that I/We shall forthwith repay the amount disbursed to me/us under the  &nbsp;<asp:Label ID="lblscheme" runat="server"></asp:Label>
                                    &nbsp;, if the
amount of Quality certification charges are found to be disbursed in excess of the amount actually
admissible whatsoever the reason.

                                </td>
                            </tr>
                            <td></td>
                            <tr>
                                <td colspan="4" style="padding: 5px; margin: 5px; text-align: center;"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="10" style="text-align: center; vertical-align: top;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave_Click" TabIndex="10" Text="Submit" Width="90px" ValidationGroup="group" />
                                    &nbsp;
                                <asp:Button ID="BtnDelete0" runat="server" CssClass="btn btn-danger" Height="32px"
                                    OnClick="BtnDelete0_Click" TabIndex="10" Text="Previous" Width="90px" />
                                    &nbsp; &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger"
                                        Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Next" Width="90px" Enabled="false"
                                        ValidationGroup="group" />
                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="10" style="text-align: left;">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10" style="text-align: left">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--  </div>--%>
                </div>
            </div>
        </div>
    </div>
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

            $("input[id$='txtDateofIssue']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtPeriodofValidity']").datepicker(
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
            $("input[id$='txtDateofIssue']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtPeriodofValidity']").datepicker(
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
            width: 250px;
        }

        .LBLBLACK {
        }
    </style>
</asp:Content>
