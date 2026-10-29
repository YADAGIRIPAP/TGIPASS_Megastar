<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="UpdateMajorIndustries.aspx.cs" Inherits="UI_TSiPASS_UpdateMajorIndustries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

        .auto-style1 {
            width: 1032px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }

        function validateInputName(input) {
            input.value = input.value.replace(/[^A-Za-z ]/g, '');
            input.value = input.value.replace(/ {2,}/g, ' ');
            input.value = input.value.split(' ').map(function (word) {
                return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
            }).join(' ');
        }
        function validateEmail(txtEmail) {
            var pattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
            var errorMessage = document.getElementById("error-message");

            if (txtEmail === "") {
                errorMessage.innerHTML = "";
            } else if (pattern.test(txtEmail)) {
                errorMessage.innerHTML = "";
            } else {
                errorMessage.style.color = "red";
                errorMessage.innerHTML = "Invalid email address";
            }
        }
    </script>


    <%-- <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp;<li class="active">
            <a href="#">
                <asp:Label ID="lblHead1" runat="server" CssClass="LBLBLACK" Font-Bold="True"></asp:Label></a></li>
        </ol>
    </div>--%>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="500px">Assigning Nodal Officer to Major Industries</asp:Label></h3>
                    </div>

                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td align="center" class="style21" style="padding: 5px; margin: 2px">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="style26" colspan="5"
                                                style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lblhdng" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                    Width="199px">Assign Nodal Officer</asp:Label>
                                            </td>
                                            <td class="style27" colspan="4" style="padding: 5px; margin: 5px;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Select Major Industry: </asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlIndustries" runat="server" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlIndustries_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="ddlRegisterAs" ErrorMessage="Please Select Register Your"
                                                    ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;"
                                                valign="middle"></td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td class="style46" style="padding: 5px; margin: 5px"></td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                        </tr>

                                        <tr>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label567" runat="server" CssClass="LBLBLACK" Width="199px">TSIpass UID Number:</asp:Label>
                                            </td>
                                            <td class="style26" style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;"
                                                colspan="6">
                                                <asp:TextBox ID="txtUIDno" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                    Width="200px" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <%--<tr>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                            <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label537" runat="server" CssClass="LBLBLACK" Width="199px">Industry Name:</asp:Label>
                                            </td>
                                            <td class="style26" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;"
                                                colspan="6">
                                                <asp:TextBox ID="txtIndname" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="Reqfvindname" runat="server"
                                                    ControlToValidate="txtindname" ErrorMessage="Please Enter Industry Name"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>

                                        <tr>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">3&nbsp;</td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label556" runat="server" CssClass="LBLBLACK" Width="148px">Industry E-Mail:</asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                    onkeyup="validateEmail(this.value)"
                                                    Width="200px"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                            <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="199px">Industry Mobile Number:</asp:Label>
                                            </td>
                                            <td class="style26" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style26" style="padding: 5px; margin: 5px; text-align: left;"
                                                colspan="6">
                                                <asp:TextBox ID="txtmobile" runat="server" class="form-control txtbox" AutoCompleteType="Disabled" onpaste="return false"
                                                    Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" onkeypress="NumberOnly()"
                                                    Width="200px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtindname" ErrorMessage="Please Enter Industry Name"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style21"
                                                style="padding: 5px; margin: 5px; text-align: left;">5</td>
                                            <td class="style35" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label563" runat="server" CssClass="LBLBLACK" Width="137px">Nodal Officer Name:</asp:Label>
                                            </td>
                                            <td class="style21" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;"
                                                colspan="6">
                                                <%--   <asp:TextBox ID="txtofcrName" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1" oninput="validateInputName(this)"
                                                    ValidationGroup="group" Width="200px"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddlOfficerName" runat="server" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlOfficerName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr runat="server" id="tr1">
                                            <td class="style21"
                                                style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                            <td class="style35" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Nodal Officer Designation:</asp:Label>
                                            </td>
                                            <td class="style21" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;"
                                                colspan="6">
                                                <asp:TextBox ID="txtofcrDesgn" runat="server" class="form-control txtbox"
                                                    Height="28px" TabIndex="1"
                                                    ValidationGroup="group" Width="200px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;"
                                                valign="middle">7</td>
                                            <td class="style42" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label543" runat="server" CssClass="LBLBLACK" Width="210px">Nodal Officer Mobile number:</asp:Label>
                                            </td>
                                            <td class="style41" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;"
                                                colspan="6">
                                                <asp:TextBox ID="txtofcrMobile" runat="server" class="form-control txtbox"
                                                    MaxLength="10" TabIndex="1" onkeypress="NumberOnly()" Height="28px"
                                                    ValidationGroup="group" Width="200px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;"
                                                valign="middle">8</td>
                                            <td class="style42" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="210px">Nodal Officer E-mail:</asp:Label>
                                            </td>
                                            <td class="style41" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style41" style="padding: 5px; margin: 5px; text-align: left;"
                                                colspan="6">
                                                <asp:TextBox ID="txtofcremail" runat="server" class="form-control txtbox"
                                                    TabIndex="1" onkeyup="validateEmail(this.value)" Height="28px"
                                                    ValidationGroup="group" Width="200px"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center; height: 50px" colspan="10">&nbsp;&nbsp;<asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                                                Height="32px" TabIndex="10" Text="Send Details" ValidationGroup="group"
                                                Width="120px" OnClick="BtnSave_Click" />
                                                &nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                        <table>
                            <tr>
                                <td colspan="9" align="center" style="padding: 5px; margin: 5px; text-align: center;" class="auto-style1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="9" style="padding: 5px; margin: 5px" class="auto-style1">
                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert"
                                            href="#">×</a> <strong>Success!</strong><asp:Label
                                                ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                </td>
                            </tr>
                        </table>

                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="8">
                                    <asp:Label ID="lblForGrid" Visible="false" runat="server" Font-Bold="true">The Details of alloted Officers to Industries:</asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <asp:GridView ID="grdNodalOfficers" runat="server" AutoGenerateColumns="true" Width="90%"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333">
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>
            </div>
        </div>

    </div>

</asp:Content>

