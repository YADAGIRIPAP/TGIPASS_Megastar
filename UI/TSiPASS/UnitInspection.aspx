<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="UnitInspection.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server">

    //protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
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
        }
        .style11
        {
            width: 5px;
        }
        .style12
        {
            width: 156px;
        }
        .style15
        {
            width: 15px;
        }
        .style16
        {
            width: 20px;
        }
        .style19
        {
            width: 170px;
        }
        .style20
        {
            width: 175px;
        }
        .style22
        {
            width: 484px;
        }
        </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/Loolupunitinspection.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
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
                <ol class="breadcrumb">
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    UNIT INSPECTION</h3>
                            </div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" 
                                                    colspan="3">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                                    Width="136px">Targets Completed</asp:Label>
                                                            :<asp:Label ID="lblmsg1" runat="server"></asp:Label>
                                                    /<asp:Label ID="lblmsg2" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" 
                                                    style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    &nbsp;
                                                    <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-primary" 
                                                        Height="32px" OnClientClick="OpenPopup();" TabIndex="10" Text="Lookup" 
                                                        Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" class="style6">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                1</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK">Total no. of Online Applications assigned for</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtapplication" runat="server" class="form-control txtbox" 
                                                                    Height="28px" onkeypress="NumberOnly()" MaxLength="40" ontextchanged="txtRawItem_TextChanged" 
                                                                    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                                    ControlToValidate="txtapplication" 
                                                                    ErrorMessage="Please enter Total no. of Online Applications assigned for" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                2</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK">Inspection by GM (Per Month) <font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:TextBox ID="txtinspGM" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px" 
                                                                    ontextchanged="txtRawItem_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                                    ControlToValidate="txtinspGM" 
                                                                    ErrorMessage="Please enter Inspection by GM (Per Month)" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                3</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK">Inspections carried out<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:TextBox ID="txtinspcout" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px" 
                                                                    ontextchanged="txtRawItem_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                                                    ControlToValidate="txtinspcout" 
                                                                    ErrorMessage="Please enter Inspections carried out" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                4
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK">Inspection report submitted to GM<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtinsprptSgm"  runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px" 
                                                                    ontextchanged="txtRawItem_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                                                    ControlToValidate="txtinsprptSgm" 
                                                                    ErrorMessage="Please enter Inspection report submitted to GM" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                        <tr >
                                                            <td style="padding: 5px; margin: 5px">
                                                                5&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK">Inspection not done
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:TextBox ID="txtinspnot"  runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px" 
                                                                    ontextchanged="txtRawItem_TextChanged"></asp:TextBox>
                                                                </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                                                    ControlToValidate="txtinspnot" ErrorMessage="Please enter Inspection not done" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                6</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK">Year
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="7" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                7</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK">Month
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="3" Width="180px">
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
                                                                &nbsp;</td>
                                                        </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" class="style6">
                                                    <asp:Label ID="Label435" runat="server" Font-Bold="True" Width="300px" 
                                                        Text="Inspection Details :"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" class="style6">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style11">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style20">
                                                                <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK">Name of the Unit<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style19">
                                                                <asp:TextBox ID="txtnameunit" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" 
                                                                    ontextchanged="txtRawItem_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; " class="style15">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                    ControlToValidate="txtnameunit" ErrorMessage="Please enter UnitName" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style11">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style20">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK">Address of the Unit<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style19">
                                                                <asp:TextBox ID="txtaddressunit" runat="server" class="form-control txtbox" 
                                                                    Height="40px" MaxLength="500"  TabIndex="1" 
                                                                    TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style15">
                                                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                    ControlToValidate="txtaddressunit" ErrorMessage="Please enter Address" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style11">
                                                                3</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style20">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK">Date of Inspection<font 
                                                                    color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="style19">
                                                                <asp:TextBox ID="txtDDDate" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" onchange="return txtDOB();"
                                                    Width="180px"></asp:TextBox>
                                                <%--<cc1:calendarextender id="Calendarextender1" runat="server" format="dd-MM-yyyy"
                                                    popupbuttonid="txtDDDate" targetcontrolid="txtDDDate">
                                                        </cc1:calendarextender>--%>
                                                        <cc1:CalendarExtender ID="txtDDDate_CalendarExtender" runat="server" 
                                                                    format="dd-MM-yyyy" popupbuttonid="txtDDDate" 
                                                                    targetcontrolid="txtDDDate">
                                                                </cc1:CalendarExtender>
                                                        
                                                                <%--<cc1:CalendarExtender ID="txtDDDate_CalendarExtender" runat="server" 
                                                                    format="MM-dd-yyyy" popupbuttonid="txtRegDate" targetcontrolid="txtDDDate">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style15">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                                    ControlToValidate="txtDDDate" ErrorMessage="Please enter Date" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 99%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                4</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK">Type of Incentive<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlincentive" runat="server" 
                                                                    class="form-control txtbox" Height="33px" TabIndex="1" Width="180px" 
                                                                    onselectedindexchanged="ddlincentive_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">IS</asp:ListItem>
                                                                    <asp:ListItem Value="2">PV</asp:ListItem>
                                                                   
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                                    ControlToValidate="ddlincentive" ErrorMessage="Please select Type of Incentive" 
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                5</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK">Current Status<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlcstatus" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" TabIndex="1" 
                                                                    onselectedindexchanged="ddlcstatus_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Working</asp:ListItem>
                                                                    <asp:ListItem Value="2">Not working</asp:ListItem>
                                                                    <asp:ListItem Value="3">Inspected</asp:ListItem>
                                                                    <asp:ListItem Value="4">Not Inspected</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                                    ControlToValidate="ddlcstatus" ErrorMessage="Please select Current Status" 
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                         <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                6</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK">Remarks<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtremark" runat="server" class="form-control txtbox" 
                                                                    Height="40px" MaxLength="500"  TabIndex="1" 
                                                                    TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                                    ControlToValidate="txtremark" ErrorMessage="Please Enter Remarks" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top" class="style6" 
                                                    colspan="2">
                                                    &nbsp;<table>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                7
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style12">
                                                                <asp:Label ID="Label395" runat="server" CssClass="LBLBLACK" Width="100px">Line of Activity<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style16">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px" class="style22">
                                                                <asp:DropDownList ID="ddlintLineofActivity" runat="server" 
                                                                    class="form-control txtbox" Height="33px" 
                                                                    OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged" 
                                                                    Width="480px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                                                                    ControlToValidate="ddlintLineofActivity" 
                                                                    ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-xs btn-warning" 
                                                                    Height="28px" onclick="BtnSave2_Click1" TabIndex="10" Text="Add New" 
                                                                    ValidationGroup="child" Width="72px" />
                                                                &nbsp;<asp:Button ID="BtnClear0" runat="server" CausesValidation="False" 
                                                                    CssClass="btn btn-xs btn-danger" Height="28px" onclick="BtnClear0_Click2" 
                                                                    TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" class="style6">
                                                    &nbsp;</td>
                                                <td valign="top">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" colspan="2" align="center">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" colspan="2" 
                                                    align="center">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" colspan="2" align="center">
                                                    <asp:GridView ID="gvCertificate0" runat="server" AutoGenerateColumns="False" 
                                                        CellPadding="4" CssClass="GRD" ForeColor="#333333" OnRowDataBound="grdDetails_RowDataBound"
                                                        Width="100%" Height="62px" 
                                                        onpageindexchanging="grdDetails_PageIndexChanging" 
                                                        onrowcreated="grdDetails_RowCreated" 
                                                        onselectedindexchanged="grdDetails_SelectedIndexChanged"  onrowdeleting="gvCertificate0_RowDeleting" PageSize="40" 
                                                        ShowFooter="True" DataKeyNames="intUnitInspectionid" >
                                                        <RowStyle BackColor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                            verticalalign="Middle" />
                                                        <Columns>
                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                         <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate >
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                    
                                                                </asp:TemplateField>
                                                          
                                                           <%-- <asp:BoundField DataField="SLNo" HeaderText="SLNo" />--%>
                                                            <asp:BoundField DataField="Nameofunit" HeaderText="Name of Unit" />
                                                            <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" />
                                                            <asp:BoundField DataField="LineofActivity_Name" HeaderText="Line of Activity" />
                                                            <asp:BoundField DataField="DateofInspection" HeaderText="Date of Inspection" />
                                                            <asp:BoundField DataField="incentiveid" HeaderText="Type of Incentive" />
                                                            <asp:BoundField DataField="cStatus" HeaderText="Current Status" />
                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                        </Columns>
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" 
                                                            cssclass="GRDHEADER" />
                                                        <EditRowStyle BackColor="#B9D684" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" 
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" Width="90px" 
                                                        ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="Clear" ToolTip="To Clear  the Screen"
                                                        Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="padding: 5px; margin: 5px">
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
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                        <br />
                                        <asp:HiddenField ID="hdfID0" runat="server" />
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
