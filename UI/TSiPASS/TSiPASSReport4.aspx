<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="TSiPASSReport4.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        .style5
        {
            width: 300px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupTSiPASSReport4.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

        }
        function getChildControl() {
            if (win != null && !win.closed) {

                var form1 = win.document.getElementsbyId("ctl00_ContentPlaceHolder1_hdfID").value;
                alert(form1);
            }
        }

        function Load_hdfID(val) {
            win.close();
            $get("ctl00_ContentPlaceHolder1_hdfID").value = val;
            __doPostBack("LOOKUP", val);
            alert(val);
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Report:7 TS-IPASS
                                </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr runat="server" visible="true">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top"
                                                    colspan="3">
                                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClientClick="OpenPopup();" TabIndex="10" Text="Lookup" Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                1&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">Month<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">January</asp:ListItem>
                                                                    <asp:ListItem Value="2">February</asp:ListItem>
                                                                    <asp:ListItem Value="3">March</asp:ListItem>
                                                                    <asp:ListItem Value="4">April</asp:ListItem>
                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                    <asp:ListItem Value="6">June</asp:ListItem>
                                                                    <asp:ListItem Value="7">July</asp:ListItem>
                                                                    <asp:ListItem Value="8">August</asp:ListItem>
                                                                    <asp:ListItem Value="9">September</asp:ListItem>
                                                                    <asp:ListItem Value="10">October</asp:ListItem>
                                                                    <asp:ListItem Value="11">November</asp:ListItem>
                                                                    <asp:ListItem Value="12">December</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlMonth"
                                                                    ErrorMessage="Please Select Month" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                2
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="165px">Year<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>2016</asp:ListItem>
                                                                    <asp:ListItem>2020</asp:ListItem>
                                                                    <asp:ListItem>2021</asp:ListItem>
                                                                    <asp:ListItem>2022</asp:ListItem>
                                                                    <asp:ListItem>2023</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlYear"
                                                                    ErrorMessage="Please select Year" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                                                <asp:Label ID="Label350" runat="server" CssClass="LBLBLACK" Width="165px">Name of the IPO</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlIPOname" runat="server" class="form-control txtbox" Height="33px"
                                                                    Visible="false" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" TabIndex="1"
                                                                    Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="lblIPOname" runat="server" CssClass="LBLBLACK" Width="165px"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlIPOname"
                                                                    ErrorMessage="Please Slect IPO" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                4&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">TSIPASS UID<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtUidno" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="True"
                                                                    OnTextChanged="txtUidno_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtUidno"
                                                                    ErrorMessage="Please Enter UID No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                5
                                                            </td>
                                                            <td class="style5" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK">Name of the Unit<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onchange="return txtDOB();" OnTextChanged="txtUnitName_TextChanged"
                                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUnitName"
                                                                    ErrorMessage="Please Enter Unit Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                6
                                                            </td>
                                                            <td style="width: 200px;">
                                                                District
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlUnitDIst" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                    Enabled="false" Height="33px" TabIndex="3" Visible="true" Width="180px" OnSelectedIndexChanged="ddlUnitDIst_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ControlToValidate="ddlUnitDIst"
                                                                    ErrorMessage="Please Enter Unit District" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                7
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                Mandal&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control txtbox" Visible="true"
                                                                    Enabled="false" TabIndex="3" Height="33px" Width="180px" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlUnitMandal_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddlUnitMandal"
                                                                    SetFocusOnError="true" ErrorMessage="Please Select Unit Mandal" InitialValue="--Mandal--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                8
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                Village&nbsp; <span style="font-weight: bold; color: Red;">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox"
                                                                    Visible="true" TabIndex="3" Height="33px" Width="180px" AutoPostBack="True" Enabled="false">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddlVillageunit"
                                                                    SetFocusOnError="true" ErrorMessage="Please Select Unit Village" InitialValue="--Village--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                9&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style5">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK">Address of the Unit<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtaddressunit" runat="server" class="form-control txtbox" Height="90px"
                                                                    MaxLength="0" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="180px"
                                                                    Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtaddressunit"
                                                                    ErrorMessage="Please Address of the Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                10
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="210px">Date of Issue of approval<font 
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtDDDate" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onchange="return txtDOB();" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="txtDDDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                                    PopupButtonID="txtRegDate" TargetControlID="txtDDDate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDDDate"
                                                                    ErrorMessage="Please Enter Date of approval" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                11
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Current Status<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlcstatus" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="1" Width="180px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">COMMENCED OPERATIONS</asp:ListItem>
                                                                    <asp:ListItem Value="2">YET TO START CONSTRUCTION</asp:ListItem>
                                                                    <asp:ListItem Value="3">ADVANCED STAGE</asp:ListItem>
                                                                    <asp:ListItem Value="4">INITIAL STAGE</asp:ListItem>
                                                                    <asp:ListItem Value="5">DROPPED</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlcstatus"
                                                                    ErrorMessage="Please Current Status" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                12
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK">Remarks<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtremark" runat="server" class="form-control txtbox" Height="80px"
                                                                    MaxLength="0" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtremark"
                                                                    ErrorMessage="Please Remarks" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr id="tr3" runat="server">
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" Width="90px" ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="Clear" ToolTip="To Clear  the Screen" Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">
                                                            &times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
                                                            Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group1" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
                        <div style="z-index: 1000; margin-left: -210px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
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
    e
</asp:Content>
