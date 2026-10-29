<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmLabourDetails_Act2.aspx.cs" Inherits="UI_TSiPASS_frmLabourDetails_Act2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">

   

</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay
        {
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

        .style6
        {
            width: 192px;
        }

        .auto-style1
        {
            width: 10px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <%--    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

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

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">The Building & Other Construction Workers Act</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">The Building & Other Construction Workers Act</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>1. Name and Location of the Establishment where building or other construction work is to be carried on</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lbl" runat="server" CssClass="LBLBLACK" Width="110px">1.1 Name
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEstbName" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="110px">1.2 Location
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEstbLoc" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>2. Postal address of the Establishment</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="110px">2.1 District
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
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="110px">2.2 Mandal
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
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="110px">2.3 Village/Town
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
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="110px">2.4 Door No
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
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="110px">2.5 Pin Code
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtPincodeEstdAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                 onkeypress="NumberOnly()"    MaxLength="6" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>3. Full name and Permanent Address of the establishment, if any</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="110px">3.1 Full Name
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtFullNamePermAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="110px">3.2 District
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDistrictPermAct2" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictPermAct2_SelectedIndexChanged">
                                                                    <asp:ListItem>--District--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="110px">3.3 Mandal
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMandalPermAct2" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlMandalPermAct2_SelectedIndexChanged">
                                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="110px">3.4 Village
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlVillagePermAct2" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px">
                                                                    <asp:ListItem>--Village--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="110px">3.5 Door No
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDoorNoPermAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="110px">3.6 Pin Code
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtPinCodePermAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="6" onkeypress="NumberOnly()"  TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>4. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="110px">4.1 Full Name
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtFullNameManagerAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="110px">4.2 Mobile No
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtMobileNoManagerAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="10" onkeypress="NumberOnly()"  TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="110px">4.3 Email Id
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEmailManagerAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="110px">4.4 District
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDistrictManagerAct2" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictManagerAct2_SelectedIndexChanged">
                                                                    <asp:ListItem>--District--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="110px">4.5 Mandal
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMandalManagerAct2" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlMandalManagerAct2_SelectedIndexChanged">
                                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="110px">4.6 Village
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlVillageManagerAct2" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px">
                                                                    <asp:ListItem>--Village--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="110px">4.7 Street
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtStreetManagerAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="110px">4.8 Door No
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDoorNoManagerAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK"><strong>5. Nature of work / is to be carried on in the establishment</strong>
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtNatureofWorkAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK"><strong>6. Maximum number of building workers to be employed on any day</strong>
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtMaxWorkersAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="5" onkeypress="NumberOnly()"  TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK"><strong>7. Estimated date of commencement of building or other construction work</strong>
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEstDateCommAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                                                    OnClientDateSelectionChanged="dateSelectionChanged"
                                                                    TargetControlID="txtEstDateCommAct2" PopupButtonID="imgCalendar" Format="yyyy-MM-dd">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK"><strong>8. Estimated date of completion of building or other construction work</strong>
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEstDateCompAct2" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                    OnClientDateSelectionChanged="dateSelectionChanged"
                                                                    TargetControlID="txtEstDateCompAct2" PopupButtonID="imgCalendar" Format="yyyy-MM-dd">
                                                                </cc1:CalendarExtender>
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
                                                    &nbsp;<asp:Button ID="btnNext0" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        OnClick="btnNext0_Click" TabIndex="10" Text="Previous" Width="90px" CausesValidation="False" />
                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
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
                                        <table style="width:0px">
                                            <tr>
                                                <td style="width:0px">
                                                    <table>
                                                        <tr>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtEstbName"
                                                                    ErrorMessage="Please Enter Establishment Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEstbLoc"
                                                                    ErrorMessage="Please Enter Establishment Location" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDistrictEstbAct2"
                                                                    ErrorMessage="Please Select District of Establishment" InitialValue="--District--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlMandalEstbAct2"
                                                                    ErrorMessage="Please Select Mandal of Establishment" InitialValue="--Mandal--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlVillageEstbAct2"
                                                                    ErrorMessage="Please Slect Village of Establishment (Village)" InitialValue="--Village--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEstdDoorNoEstbAct2"
                                                                    ErrorMessage="Please Enter Door Number of Establishment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPincodeEstdAct2"
                                                                    ErrorMessage="Please Enter Pincode of Establishment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFullNamePermAct2"
                                                                    ErrorMessage="Please Enter Full Name of Establishment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDistrictPermAct2"
                                                                    ErrorMessage="Please Select Permanent District" InitialValue="--District--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMandalPermAct2"
                                                                    ErrorMessage="Please Select Permanent Mandal" InitialValue="--Mandal--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlVillagePermAct2"
                                                                    ErrorMessage="Please Slect Village of Establishment (Village)" InitialValue="--Village--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtDoorNoPermAct2"
                                                                    ErrorMessage="Please Enter Permanent Door Number " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPinCodePermAct2"
                                                                    ErrorMessage="Please Enter permanent Pincode" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>


                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlDistrictManagerAct2"
                                                                    ErrorMessage="Please Select Manager District" InitialValue="--District--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlMandalManagerAct2"
                                                                    ErrorMessage="Please Select Manager Mandal" InitialValue="--Mandal--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlVillageManagerAct2"
                                                                    ErrorMessage="Please Slect Manager Village" InitialValue="--Village--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtFullNameManagerAct2"
                                                                    ErrorMessage="Please Enter Manager Full Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtMobileNoManagerAct2"
                                                                    ErrorMessage="Please Enter Manager Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtEmailManagerAct2"
                                                                    ErrorMessage="Please Enter Manager Email" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtStreetManagerAct2"
                                                                    ErrorMessage="Please Enter Manager Street" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtDoorNoManagerAct2"
                                                                    ErrorMessage="Please Enter Manager Door Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtNatureofWorkAct2"
                                                                    ErrorMessage="Please Enter Nature of work" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtMaxWorkersAct2"
                                                                    ErrorMessage="Please Enter Maximum number of building workers to be employed on any day" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                             <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtEstDateCommAct2"
                                                                    ErrorMessage="Please Enter Date of Commencement" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                             <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtEstDateCompAct2"
                                                                    ErrorMessage="Please Enter Estimated Date of Completion" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

