<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmLabourShopRenewal.aspx.cs" Inherits="UI_TSiPASS_frmLabourShopRenewal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtpreviousrendate']").datepicker(
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
            $("input[id$='txtpreviousrendate']").datepicker(
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

            $("input[id$='txtDateofCommenceAct1']").datepicker(
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
            $("input[id$='txtDateofCommenceAct1']").datepicker(
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
    </style>

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

        .style6 {
            width: 192px;
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

    <%-- <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Renewal Application for Shops & Establishments (FORM-III)</h3>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 90%">
                                        <tr>
                                            <td colspan="7">
                                                <strong>1. Name and Location of the Establishment where building or other construction work is to be carried on</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                            <asp:Label ID="lbl" runat="server" CssClass="LBLBLACK">1.1 Previous Registration Certificate Number
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtcertificateno" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px" OnTextChanged="txtcertificateno_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>


                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="4" cellspacing="5" style="width: 90%"  id="trvisibleregno" runat="server" visible="false">
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td colspan="6" style="padding: 5px; margin: 5px;" class="text-center"><strong>Renewal Application for Shops &amp; Establishments (FORM-III)</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;">1 Previous Registration Certificate No.<font color="red">*</font></td>
                                                        <td>:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtregnno" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr id="tdpreviousren" runat="server" visible="true">
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;">1.1 Previous Renewal Date:</td>
                                                        <td>:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtrenewalvalidfromdate" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr1" runat="server" visible="true">
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td>&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtrenewalvalidtodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tragree" runat="server" visible="true">
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;">1.2 Do you Agree with above details</td>
                                                        <td>:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:RadioButtonList ID="rdagreelist" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdagreelist_SelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trpreviousrendate" runat="server" visible="false">
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;">1.2.1 Previous Renewal Date</td>
                                                        <td>&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtpreviousrendate" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tdpreviousYear" runat="server" visible="false">
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;">1.2.2 Valid Previous Renewal Year</td>
                                                        <td>&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlprerenyear" runat="server">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="2017">2017</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="lbluploadrencer" runat="server" CssClass="LBLBLACK" Text="1.2.3 Upload Previous Renewal Certificate"></asp:Label></td>
                                                        <td>&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:FileUpload ID="FilePreviouscertificate" runat="server" class="form-control txtbox"
                                                                Height="28px" />
                                                            <asp:Button ID="BtnPreviouscertificate" runat="server" CssClass="btn btn-xs btn-warning"
                                                                Height="28px" TabIndex="10" Text="Upload"
                                                                Width="72px" OnClick="BtnPreviouscertificate_Click" />
                                                            <asp:HyperLink ID="HyperlinkPreviouscertificate" runat="server" CssClass="LBLBLACK" Width="165px"
                                                                Target="_blank"></asp:HyperLink>
                                                            <br />
                                                            <asp:Label ID="LabelPreviouscertificate" runat="server" Visible="False"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="trclassification" runat="server" visible="false">
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;">1. Classification of Establishment <font color="red">*</font> </td>
                                                        <td>:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlEstClassification" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;">2 . Category of Establishments</td>
                                                        <td>&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlCategoryofEstablishment" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                                ControlToValidate="ddlCategoryofEstablishment" ErrorMessage="Please Select Category of Establishment"
                                                                InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;">3. Name of Establishments</td>
                                                        <td>&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtnameofestablishment" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="7">
                                                            <strong>&nbsp;address of the Establishment</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="110px">District
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDistrictEstbAct2" runat="server" class="form-control txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictEstbAct2_SelectedIndexChanged"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="110px">Mandal
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlMandalEstbAct2" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlMandalEstbAct2_SelectedIndexChanged">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="110px">Village/Town
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlVillageEstbAct2" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="110px">Door No
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtEstdDoorNoEstbAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="110px">Pin Code
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtPincodeEstdAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                onkeypress="NumberOnly()" MaxLength="6" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">Locality</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtEstdlocality" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="7">
                                                            <strong>4. Employer Details</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="110px">Full Name
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtFullNameemp" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="110px">Locality                                                        <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtemplocality" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="110px">Mobile Number
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtEmpMobileNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                                ControlToValidate="txtEmpMobileNo" ErrorMessage="Please Enter Employer Mobile Number"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="110px">Age                                                         <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtempAge" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="110px">S/o/D/o/W/o                                                            <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtEmpSo" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">Designation</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtempdesignation" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                ControlToValidate="txtempdesignation" ErrorMessage="Please Enter Employer Designation"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="7">
                                                            <strong>5. Manager Details</strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="110px">Full Name
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtFullNameManager" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                ControlToValidate="txtFullNameManager" ErrorMessage="Please Enter Manager Name"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="110px">Age<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerAge" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="10" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                ControlToValidate="txtManagerAge" ErrorMessage="Please Enter Manager Age"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="110px">S/o/D/o/W/o
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtManagerSo" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                ControlToValidate="txtManagerSo" ErrorMessage="Please Enter Manager S/O/W/O"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                    </tr>
                                                    <tr id="trresidentialddress" runat="server" visible="false">
                                                        <td colspan="7">
                                                            <strong>&nbsp;Residential address of the employer</strong>
                                                        </td>
                                                    </tr>
                                                    <tr id="trresidentiDistrict" runat="server" visible="false">
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="110px">District
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlDistrictResidentialAct1" runat="server" class="form-control txtbox" AutoPostBack="True"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--District--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="110px">Mandal
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlMandalResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" AutoPostBack="True">
                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trresidentialVillage" runat="server" visible="false">
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="110px">Village/Town
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlVillageResidentialAct1" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px">
                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="110px">Door No
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtresidoorno" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="trresidentialPincode" runat="server" visible="false">
                                                        <td></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="110px">Pin Code
                                                                <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtresdipincode" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                onkeypress="NumberOnly()" MaxLength="6" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">Locality</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtresdilocality" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="trnatureofbussiness" runat="server" visible="false">
                                                        <td colspan="6">
                                                            <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK"><strong>Nature of business<font color="red">*</font>:</strong>
                                                            </asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtNatureofBusinessAct1" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNatureofBusinessAct1"
                                                                ErrorMessage="Please Enter Nature of business " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="trdateofcommencement" runat="server" visible="false">
                                                        <td colspan="6">
                                                            <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK"><strong>Date of Commencement of business<font color="red">*</font>:</strong>
                                                            </asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtDateofCommenceAct1" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK"><strong>6. Total No. of Employees<font color="red">*</font>:</strong>
                                                            </asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtTotalEmployees" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px" Enabled="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tremploycount" align="left" runat="server" visible="false">
                                                        <td colspan="7">
                                                            <asp:Table ID="tblNoofEmployees" runat="server" CellPadding="1" CellSpacing="1" Font-Size="Medium" Width="400" GridLines="Both">
                                                                <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" Style="color: White; background-color: #013161; font-weight: bold;">
                                                                    <asp:TableHeaderCell Width="50px"></asp:TableHeaderCell>
                                                                    <asp:TableHeaderCell Width="150px">Adults (18 years and above)</asp:TableHeaderCell>
                                                                    <asp:TableHeaderCell Width="170px">Young Persons (From 14 years to Below 18 years)</asp:TableHeaderCell>
                                                                </asp:TableHeaderRow>
                                                                <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                                                    <asp:TableCell>MALE</asp:TableCell>
                                                                    <asp:TableCell Height="29px">
                                                                        <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Male" Width="40px" OnTextChanged="txtAbove18Male_TextChanged"></asp:TextBox>
                                                                    </asp:TableCell>
                                                                    <asp:TableCell Height="29px">
                                                                        <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18Male" Width="40px" OnTextChanged="txtBelow18Male_TextChanged"></asp:TextBox>
                                                                    </asp:TableCell>
                                                                </asp:TableRow>
                                                                <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                                                    <asp:TableCell Height="29px">FEMALE</asp:TableCell>
                                                                    <asp:TableCell>
                                                                        <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Female" Width="40px" OnTextChanged="txtAbove18Female_TextChanged"></asp:TextBox>
                                                                    </asp:TableCell>
                                                                    <asp:TableCell>
                                                                        <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18FeMale" Width="40px" OnTextChanged="txtBelow18FeMale_TextChanged"></asp:TextBox>
                                                                    </asp:TableCell>
                                                                </asp:TableRow>
                                                                <asp:TableFooterRow ID="TableFooterRow1" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                                                    <asp:TableCell Height="29px">Total</asp:TableCell>
                                                                    <asp:TableCell>
                                                                        <asp:TextBox runat="server" ID="txtTotalAbove18" Width="40px" Enabled="false"></asp:TextBox>
                                                                    </asp:TableCell>
                                                                    <asp:TableCell>
                                                                        <asp:TextBox runat="server" ID="txtTotalBelow18" Width="40px" Enabled="false"></asp:TextBox>
                                                                    </asp:TableCell>
                                                                </asp:TableFooterRow>
                                                            </asp:Table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;
                                </td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <caption>
                                &nbsp;</caption>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;
                                </td>
                                <td style="width: 27px">&nbsp;
                                </td>
                                <td valign="top">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group"
                                        Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                        OnClick="btnNext_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                        ValidationGroup="group" Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                        <br />
                        <asp:HiddenField ID="hdfpencode" runat="server" />
                    </div>
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%-- %><asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
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
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

