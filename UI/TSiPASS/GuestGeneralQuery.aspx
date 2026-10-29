<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="GuestGeneralQuery.aspx.cs" Inherits="UI_TSiPASS_GuestGeneralQuery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


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
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp;<li class="active">
            <a href="#">
                <asp:Label ID="lblHead1" runat="server" CssClass="LBLBLACK" Font-Bold="True"></asp:Label></a></li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            <asp:Label ID="lblHead2" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                Width="199px"></asp:Label></h3>
                    </div>

                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td align="center" class="style21" style="padding: 5px; margin: 2px">
                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td class="style26" colspan="5"
                                                style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label558" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                    Width="199px"></asp:Label>
                                            </td>
                                            <td class="style27" colspan="5" style="padding: 5px; margin: 5px;"><font 
                                                            color="red"><strong>* Fields are mandatory</strong></font></td>
                                        </tr>
                                        <tr id="trgrivenance" runat="server" visible="true">
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="199px">Register Your:</asp:Label>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlRegisterAs" runat="server" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="270px" AutoPostBack="True" OnSelectedIndexChanged="ddlRegisterAs_SelectedIndexChanged">
                                                    <%--<asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="G">Grievance</asp:ListItem>
                                                    <asp:ListItem Value="F">Feedback</asp:ListItem>--%>
                                                    <asp:ListItem Value="Q" Selected="True">General Query</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="ddlRegisterAs" ErrorMessage="Please Select Register Your"
                                                    ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;"
                                                valign="middle"></td>
                                            <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="100px">District Name:</asp:Label>--%>
                                            </td>
                                            <td class="style46" style="padding: 5px; margin: 5px"></td>
                                            <td class="style46" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                        </tr>
                                        <tr runat="server" id="trData" visible="false">
                                            <td colspan="10">
                                                <table>
                                                    <tr>
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                        <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label567" runat="server" CssClass="LBLBLACK" Width="250px">TS-ipass UID Number:</asp:Label>
                                                            <asp:Label ID="lblstar" runat="server" CssClass="LBLBLACK" Width="250" Text="*" Visible="false"><font 
                                                            color="red">*</font></asp:Label>
                                                            <asp:Label ID="LBLAVAIABLE" runat="server" CssClass="LBLBLACK" Width="250px" Text="(If Applicable)" Visible="false"></asp:Label>
                                                        </td>
                                                        <td class="style26" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="6">
                                                            <asp:TextBox ID="txtuidno" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                                Width="200px" AutoPostBack="True" OnTextChanged="txtuidno_TextChanged"></asp:TextBox>

                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                        <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label537" runat="server" CssClass="LBLBLACK" Width="199px">Industry Name</asp:Label>
                                                            <asp:Label ID="lblindustar" runat="server" CssClass="LBLBLACK" Width="250" Text="*" Visible="false"><font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td class="style26" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style26" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="6">
                                                            <asp:TextBox ID="txtindname" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                                Width="643px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="Reqfvindname" runat="server"
                                                                ControlToValidate="txtindname" ErrorMessage="Please Enter Industry Name"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="TRdEPTnAME">
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                        <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label566" runat="server" CssClass="LBLBLACK" Width="162px">Department Name<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddldept" runat="server" class="form-control txtbox"
                                                                Height="33px" TabIndex="1" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                ControlToValidate="ddldept" ErrorMessage="Please Select Department"
                                                                ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td colspan="5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;"
                                                            valign="middle">
                                                            <asp:Label ID="lblSlno3" runat="server" Text="Label">4</asp:Label></td>
                                                        <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label565" runat="server" CssClass="LBLBLACK" Width="100px">District Name<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddldist" runat="server" class="form-control txtbox"
                                                                Height="33px" TabIndex="1" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:RequiredFieldValidator ID="ReqfvDist" runat="server"
                                                                ControlToValidate="ddldist" ErrorMessage="Please Select District"
                                                                ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;"
                                                            valign="middle">&nbsp;</td>
                                                        <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="lblSlno4" runat="server" Text="Label">5</asp:Label></td>
                                                        <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label556" runat="server" CssClass="LBLBLACK" Width="148px">E-Mail<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:RequiredFieldValidator ID="Refvemail" runat="server"
                                                                ControlToValidate="txtEmail" ErrorMessage="Please Enter Email"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                ControlToValidate="txtEmail" ErrorMessage="Please Enter Correct Email"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                            &nbsp;</td>
                                                        <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;"
                                                            valign="middle">
                                                            <asp:Label ID="lblSlno5" runat="server" Text="Label">6</asp:Label></td>
                                                        <td class="style49" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label564" runat="server" CssClass="LBLBLACK" Height="18px"
                                                                Width="111px">Mobile Number<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td class="style46" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtMob" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                                Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="reqfvmob" runat="server"
                                                                ControlToValidate="txtMob" ErrorMessage="Please Enter Mobile Number"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="trSubject">
                                                        <td class="style21"
                                                            style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="lblSlno6" runat="server" Text="Label">7</asp:Label></td>
                                                        <td class="style35" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label563" runat="server" CssClass="LBLBLACK" Width="137px">Subject<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td class="style21" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style21" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="6">
                                                            <asp:TextBox ID="txtSub" runat="server" class="form-control txtbox"
                                                                Height="28px" MaxLength="40" TabIndex="1" TextMode="MultiLine"
                                                                ValidationGroup="group" Width="643px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RefvSub" runat="server"
                                                                ControlToValidate="txtSub" ErrorMessage="Please Enter Grievance Subject"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style41" style="padding: 5px; margin: 5px; text-align: left;"
                                                            valign="middle">
                                                            <asp:Label ID="lblSlno7" runat="server" Text="Label">8</asp:Label></td>
                                                        <td class="style42" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label543" runat="server" CssClass="LBLBLACK" Width="210px">Description<font 
                                                            color="red">*</font></asp:Label>
                                                        </td>
                                                        <td class="style41" style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style41" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="6">
                                                            <asp:TextBox ID="txtDesc" runat="server" class="form-control txtbox"
                                                                Height="58px" MaxLength="40" TabIndex="1" TextMode="MultiLine"
                                                                ValidationGroup="group" Width="643px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RefvDesc" runat="server"
                                                                ControlToValidate="txtDesc" ErrorMessage="Please Enter Grievance Description"
                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="rem" runat="server">
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"
                                                            valign="middle">
                                                            <asp:Label ID="lblSlno8" runat="server" Text="Label">9</asp:Label></td>
                                                        <td class="style36" style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label549" runat="server" CssClass="LBLBLACK" Width="114px">Upload:</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;"
                                                            colspan="3">
                                                            <asp:FileUpload ID="FileUpload" runat="server" class="form-control txtbox"
                                                                Height="28px" />
                                                            <asp:HyperLink ID="lblFileName1" runat="server" CssClass="LBLBLACK"
                                                                Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                            <br />
                                                            <asp:Label ID="Label560" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td class="style6" colspan="3"
                                                            style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                            <asp:Button ID="BtnUpload" runat="server" CssClass="btn btn-xs btn-warning"
                                                                Height="28px" TabIndex="10" Text="Upload" Width="72px"
                                                                OnClick="BtnUpload_Click" Visible="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center; height: 50px" colspan="10">&nbsp;&nbsp;<asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                                                            Height="32px" TabIndex="10" Text="Submit" ValidationGroup="group"
                                                            Width="90px" OnClick="BtnSave_Click" />
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
                                        <asp:Label
                                            ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>

                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                </td>
                            </tr>
                        </table>



                    </div>

                </div>
            </div>
        </div>

    </div>



    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

