<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmCAFFactoryDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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
        
        .style6
        {
            height: 34px;
        }
        
        .style7
        {
            width: 42px;
        }
        
        .style8
        {
            height: 34px;
            width: 42px;
        }
        
        .style10
        {
            width: 9px;
        }
        
        .style11
        {
            width: 210px;
        }
        
        .style12
        {
        }
        
        .style13
        {
            width: 13px;
        }
        
        .style14
        {
            height: 50px;
        }
        
        .style15
        {
            width: 210px;
            height: 50px;
        }
        
        .style16
        {
            width: 9px;
            height: 50px;
        }
        
        .style17
        {
            width: 5%;
        }
        
        .style18
        {
            width: 2%;
        }
        
        .style19
        {
            width: 42%;
        }
        
        .style20
        {
            width: 41%;
        }
    </style>
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 6) {
                alert("Pin number length must be exactly 6 characters")
            }
        }
    </script>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%-- <script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>--%>
    <script type="text/javascript">
        function sumPropBulk() {
            var txtFirstNumberValue = document.getElementById('txtProsPetorlClassA').value;
            var txtSecondNumberValue = document.getElementById('txtPropPetolClassB').value;
            var txtThirdNumberValue = document.getElementById('txtPropPetolClassB').value;
            var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue) + parseInt(txtThirdNumberValue);
            if (!isNaN(result)) {
                document.getElementById('txtPropPetrolTotal').value = result;
            }
        }
    </script>
    <%-- <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
            <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i><a href="#">Entrepreneur Details</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">
                            Factory Details</h3>
                    </div>
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                    <asp:Label ID="Label425" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="580px">Please fill this additional part if Factories Licence is required</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Nature of manufacturing process or processes</asp:Label>
                                            </td>
                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                                    TabIndex="1">
                                                    <asp:ListItem Value="1">Secondary</asp:ListItem>
                                                    <asp:ListItem Value="2">Main</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList1"
                                                    ErrorMessage="Please Select Nature of Manufacture Process" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                2
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="3">
                                                <asp:Label ID="Label430" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Reference by which Plans approved by the Chief Inspector (if applicable).</asp:Label>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                &nbsp;
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="180px">Ref No</asp:Label>
                                            </td>
                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtRefNo" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRefNo"
                                                    ErrorMessage="Please enter Reference Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="180px">Date(dd-MMM-yyyy)</asp:Label>
                                            </td>
                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtRefDate" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                                    PopupButtonID="txtRefDate" TargetControlID="txtRefDate">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRefDate"
                                                    ErrorMessage="Please enter Reference Date " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trmangrold" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="200px">Full name and residential address of person who shall be the Manager of the factory for the purpose of this Act.</asp:Label>
                                            </td>
                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtFullAddr" runat="server" class="form-control txtbox" Height="66px"
                                                    MaxLength="150" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFullAddr"
                                                    ErrorMessage="Please enter Full address " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label458" runat="server" CssClass="LBLBLACK" Width="200px">Date of occupation of the factory by the occupiers</asp:Label>
                                            </td>
                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtDateOccu" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                                    PopupButtonID="txtDateOccu" TargetControlID="txtDateOccu">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDateOccu"
                                                    ErrorMessage="Please select Date of Occupation" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="troccupierold" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label459" runat="server" CssClass="LBLBLACK" Width="200px">Full Name, Residential address of the Occupier and his position in the Company/Firm/Government factory or Local Fund factory</asp:Label>
                                            </td>
                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOccuAddr" runat="server" class="form-control txtbox" Height="66px"
                                                    MaxLength="180" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOccuAddr"
                                                    ErrorMessage="Please enter Occupier Complete Address" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="trresidentalold" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                6
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label460" runat="server" CssClass="LBLBLACK" Width="200px">Full Name and Residential address of the owner of the building referred to in section 93 of the Act, where separate buildings in</asp:Label>
                                            </td>
                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOwnerAddr" runat="server" class="form-control txtbox" Height="66px"
                                                    MaxLength="180" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOwnerAddr"
                                                    ErrorMessage="Please enter Address of the owner of Bilding" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                7
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                Lincese Year<font color="red">*</font>
                                            </td>
                                            <td class="style7" style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlLicenseYear" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">One Year</asp:ListItem>
                                                    <asp:ListItem Value="2">Two Year</asp:ListItem>
                                                    <asp:ListItem Value="3">Three Year</asp:ListItem>
                                                    <asp:ListItem Value="4">Four Year</asp:ListItem>
                                                    <asp:ListItem Value="5">Five Year</asp:ListItem>
                                                    <asp:ListItem Value="6">Six Year</asp:ListItem>
                                                    <asp:ListItem Value="7">Seven Year</asp:ListItem>
                                                    <asp:ListItem Value="8">Eight Year</asp:ListItem>
                                                    <asp:ListItem Value="9">Nine Year</asp:ListItem>
                                                    <asp:ListItem Value="10">Ten Year</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="ddlLicenseYear"
                                                    ErrorMessage="Please Select License Year" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                    <strong>Full name and residential address of person who shall be the Manager of the
                                        factory for the purpose of this Act.</strong>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                Full Name
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMngrFullNm" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="txtMngrFullNm"
                                                    ErrorMessage="Please Manager Full Name" ValidationGroup="group" Visible="true">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="dist1" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label352" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlMngrdistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlMngrdistrict_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="ddlMngrdistrict"
                                                    ErrorMessage="Please select Manager District" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="mandal1" visible="true" runat="server">
                                            <td style="padding: 5px; margin: 5px">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label398" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlMngrMandal" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlMngrMandal_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddlMngrMandal"
                                                    ErrorMessage="Please select Manager Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="vill1" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label399" runat="server" CssClass="LBLBLACK" Width="165px">Village/Town<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlMngrVillage" runat="server" class="form-control txtbox"
                                                    TabIndex="1" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="ddlMngrVillage"
                                                    ErrorMessage="Please select Manager Village" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr1" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                Door No<font color="red">*</font>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMngrDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtMngrDoorNo"
                                                    ErrorMessage="Please select Manager Door No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                6
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label388" runat="server" CssClass="LBLBLACK" Width="165px">Street Name<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMngrstreetName" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtMngrstreetName"
                                                    ErrorMessage="Please enter Manager Street Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                7
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                Pin Code <font color="red">*</font>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMngrpincode" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="NumberOnly()"></asp:TextBox>
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtMngrpincode"
                                                    ErrorMessage="Please enter Manager Pin code" ValidationGroup="group" onkeypress="NumberOnly()"
                                                    onblur="checkLength(this)">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                8&nbsp;
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="200px">Mobile No</asp:Label>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMngrMobileNo" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtMngrMobileNo"
                                                    ErrorMessage="Please enter Manager Mobile No" ValidationGroup="group" onkeypress="NumberOnly()"
                                                    onblur="checkLength1(this)">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                9
                                            </td>
                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                Email
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtMngrEmail" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtMngrEmail"
                                                    ErrorMessage="Please enter Manager Email" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                    <strong>Full Name, Residential address of the Occupier and his position in the Company/Firm/Government
                                        factory or Local Fund factory.</strong>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                Full Name
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOccupierFullNm" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" ControlToValidate="txtOccupierFullNm"
                                                    ErrorMessage="Please Enter Occupier Full Name" ValidationGroup="group" Visible="true">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr2" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlOccupierDistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlOccupierDistrict_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :<asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="ddlOccupierDistrict"
                                                    ErrorMessage="Please select Occupier District" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr3" visible="true" runat="server">
                                            <td style="padding: 5px; margin: 5px">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlOccupierMandal" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlOccupierMandal_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="ddlOccupierMandal"
                                                    ErrorMessage="Please select Occupier Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr4" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">Village/Town<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlOccupierVillage" runat="server" class="form-control txtbox"
                                                    TabIndex="1" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="ddlOccupierVillage"
                                                    ErrorMessage="Please select Occupier Village" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr5" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                Door No<font color="red">*</font>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOccupierDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtOccupierDoorNo"
                                                    ErrorMessage="Please select Occupier Door No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                6
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Street Name<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOccupierStreetNm" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtOccupierStreetNm"
                                                    ErrorMessage="Please enter Occupier Street Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                7
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                Pin Code <font color="red">*</font>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOccupierpincode" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="NumberOnly()"></asp:TextBox>
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txtOccupierpincode"
                                                    ErrorMessage="Please enter Occupier Pin ode" ValidationGroup="group" onkeypress="NumberOnly()"
                                                    onblur="checkLength(this)">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                8&nbsp;
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="200px">Mobile No</asp:Label>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOccupuierMobileNo" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"
                                                    onkeypress="NumberOnly()"></asp:TextBox>
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="txtOccupuierMobileNo"
                                                    ErrorMessage="Please enter Occupier Mobile No" ValidationGroup="group" onkeypress="NumberOnly()"
                                                    onblur="checkLength1(this)">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                9
                                            </td>
                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                Email
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtoccupierEmail" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="txtoccupierEmail"
                                                    ErrorMessage="Please enter Occupier Email" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                    <strong>Full Name and Residential address of the owner of the building referred to in
                                        section 93 of the Act, where separate buildings in.</strong>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                Full Name
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtownerFullNm" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ControlToValidate="txtownerFullNm"
                                                    ErrorMessage="Please Enter Owner Full Name" Visible="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr6" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                2
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlOwnerDistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                    Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlOwnerDistrict_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :<asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="ddlOwnerDistrict"
                                                    ErrorMessage="Please select Owner District" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr7" visible="true" runat="server">
                                            <td style="padding: 5px; margin: 5px">
                                                3
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlOwnerMandal" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlOwnerMandal_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="ddlOwnerMandal"
                                                    ErrorMessage="Please select Owner Mandal" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr8" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                4
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px">Village/Town<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlOwnerVillage" runat="server" class="form-control txtbox"
                                                    TabIndex="1" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="ddlOwnerVillage"
                                                    ErrorMessage="Please select Owner Village" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr id="Tr9" runat="server" visible="true">
                                            <td style="padding: 5px; margin: 5px">
                                                5
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                Door No<font color="red">*</font>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOwnerDoorNo" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="txtOwnerDoorNo"
                                                    ErrorMessage="Please select Owner Door No" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                6
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="165px">Street Name<font color="red">*</font></asp:Label>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOwnerStreetNm" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="txtOwnerStreetNm"
                                                    ErrorMessage="Please enter Owner Street Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                7
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                Pin Code <font color="red">*</font>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOwnerPinCode" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="NumberOnly()"></asp:TextBox>
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="txtOwnerPinCode"
                                                    ErrorMessage="Please enter Owner Pin ode" ValidationGroup="group" onkeypress="NumberOnly()"
                                                    onblur="checkLength(this)">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                8&nbsp;
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="200px">Mobile No</asp:Label>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOwnerMobile" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
                                            </td>
                                            <td class="style14" style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="txtOwnerMobile"
                                                    ErrorMessage="Please enter Owner Mobile" ValidationGroup="group" onkeypress="NumberOnly()"
                                                    onblur="checkLength1(this)">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                9
                                            </td>
                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                Email
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOwnerEmail" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="txtOwnerEmail"
                                                    ErrorMessage="Please enter Owner Email" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label426" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="580px">Please fill this part if Licence for Storage of Petroleum/Diesel/Naptha is required</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Situation of the premises where Petroleum is to be stored</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                1
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style11">
                                                District
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;<asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                                                    TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDistrict"
                                                    ErrorMessage="Please Select District" InitialValue="--Select--" ValidationGroup="group"
                                                    Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                2&nbsp;
                                            </td>
                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label428" runat="server" CssClass="LBLBLACK" Width="210px">Mandal</asp:Label>
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged"
                                                    TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlMandal"
                                                    ErrorMessage="Please Select Mandal" InitialValue="--Select--" ValidationGroup="group"
                                                    Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                3&nbsp;
                                            </td>
                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="210px">Village/Town</asp:Label>
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control txtbox" Height="33px"
                                                    Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlVillage"
                                                    ErrorMessage="Please Select Village" InitialValue="--Select--" ValidationGroup="group"
                                                    Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style14">
                                                4
                                            </td>
                                            <td class="style15" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="200px">Police Station</asp:Label>
                                            </td>
                                            <td class="style16" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style14">
                                                <asp:TextBox ID="txtPS" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style14">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPS"
                                                    ErrorMessage="Please enter Police Station " ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                5
                                            </td>
                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                Nearest Railway Station
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNearRail" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px" Visible="true"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNearRail"
                                                    ErrorMessage="Please enter Nearest Railway Station" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <asp:Label ID="Label427" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Quantity (In Ltrs.) of Petroleum proposed to be imported and stored.</asp:Label>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <asp:Label ID="Label461" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Quantity (in Ltrs) of Petroleum already stored in the premises.</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                &nbsp;
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px" colspan="3">
                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">In bulk (above 1000 Lts)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                1
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class A/Naptha</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtProsPetorlClassA" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" OnTextChanged="txtProsPetorlClassA_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtProsPetorlClassA"
                                                    ErrorMessage="Please enter Petorleum ClassA/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                2
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="210px">Petroleum Class B/Naptha</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtPropPetolClassB" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" onkeyup="sumPropBulk()" AutoPostBack="True" OnTextChanged="txtPropPetolClassB_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPropPetolClassB"
                                                    ErrorMessage="Please enter Petorleum ClassB/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                3
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label441" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class C/Naptha</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtPropPetrolClassC" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" onkeyup="sumPropBulk()" AutoPostBack="True" OnTextChanged="txtPropPetrolClassC_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtPropPetrolClassC"
                                                    ErrorMessage="Please enter Petorleum ClassC/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                4
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="200px">Total</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtPropPetrolTotal" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" Enabled="False" onkeyup="sumPropBulk()" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtPropPetrolTotal"
                                                    ErrorMessage="Please enter Petrolium Total" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                &nbsp;
                                            </td>
                                            <td class="style12" colspan="3" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px"> Not in bulk (less than 1000 Lts)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                5
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class A/Naptha</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtNotPropPetrolClassA" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtNotPropPetrolClassA_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtNotPropPetrolClassA"
                                                    ErrorMessage="Please enter Petorleum ClassA/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                6
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label446" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class B/Naptha</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtNotPropPetrolClassB" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtNotPropPetrolClassB_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNotPropPetrolClassB"
                                                    ErrorMessage="Please enter Petorleum ClassB/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                7
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class C/Naptha</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtNotPropPetrolClassC" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtNotPropPetrolClassC_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtNotPropPetrolClassC"
                                                    ErrorMessage="Please enter Petorleum ClassC/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                8
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" Width="200px">Total</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtNotPropPetrolTot" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtNotPropPetrolTot"
                                                    ErrorMessage="Please enter Petorleum Total" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                &nbsp;
                                            </td>
                                            <td class="style12" colspan="3" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label444" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Total</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                9
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label449" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class A/Naptha</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtProsPetrolTotClassA" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" OnTextChanged="txtProsPetrolTotClassA_TextChanged"
                                                    Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtProsPetrolTotClassA"
                                                    ErrorMessage="Please enter Petorleum ClassA/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                10
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class B/Naptha</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtProsPetrolTotClassB" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtProsPetrolTotClassB"
                                                    ErrorMessage="Please enter Petorleum ClassB/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                11
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class C/Naptha</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtProsPetrolTotClassC" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtProsPetrolTotClassC"
                                                    ErrorMessage="Please enter Petorleum ClassC/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" class="style17">
                                                12
                                            </td>
                                            <td class="style19" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="200px">Total</asp:Label>
                                            </td>
                                            <td class="style18" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style20">
                                                <asp:TextBox ID="txtProsPetrolGrandTot" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" class="style18">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtProsPetrolGrandTot"
                                                    ErrorMessage="Please enter Petorleum Total" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style12" colspan="3" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label462" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">In bulk (above 1000 Lts)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                1
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label463" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class A/Naptha</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStorPetrolClassA" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True" OnTextChanged="txtStorPetrolClassA_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtStorPetrolClassA"
                                                    ErrorMessage="Please enter Petorleum ClassA/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                2
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label464" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class B/Naptha</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStorPetrolClassB" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True" OnTextChanged="txtStorPetrolClassB_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtStorPetrolClassB"
                                                    ErrorMessage="Please enter Petorleum ClassB/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                3
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label465" runat="server" CssClass="LBLBLACK" Width="210px">Petroleum Class C/Naptha</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStorPetrolClassc" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" AutoPostBack="True" OnTextChanged="txtStorPetrolClassc_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtStorPetrolClassc"
                                                    ErrorMessage="Please enter Petorleum ClassC/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                4
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label466" runat="server" CssClass="LBLBLACK" Width="200px">Total</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStorPetrolTot" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtStorPetrolTot"
                                                    ErrorMessage="Please enter Petorleum Total" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style12" colspan="3" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label467" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px"> Not in bulk (less than 1000 Lts)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                5
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label468" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class A/Naptha</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNotStorPetrolClassA" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtNotStorPetrolClassA_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtNotStorPetrolClassA"
                                                    ErrorMessage="Please enter Petorleum ClassA/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                6
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label469" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class B/Naptha</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNotStorPetrolClassB" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtNotStorPetrolClassB_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtNotStorPetrolClassB"
                                                    ErrorMessage="Please enter Petorleum ClassB/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                7
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label470" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class C/Naptha</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNotStorPetrolClassC" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" AutoPostBack="True" OnTextChanged="txtNotStorPetrolClassC_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtNotStorPetrolClassC"
                                                    ErrorMessage="Please enter Petorleum ClassC/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                8
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label471" runat="server" CssClass="LBLBLACK" Width="200px">Total</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtNotStorPetrolTot" Style="text-align: right" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                    Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtNotStorPetrolTot"
                                                    ErrorMessage="Please enter Petorleum Total" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                            <td class="style12" colspan="3" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label472" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="450px">Total</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                9
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label473" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class A/Naptha</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStorPetrolTotClassA" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtStorPetrolTotClassA"
                                                    ErrorMessage="Please enter Petorleum ClassA/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                10
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label474" runat="server" CssClass="LBLBLACK" Width="200px">Petroleum Class B/Naptha</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStorPetrolTotClassB" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtStorPetrolTotClassB"
                                                    ErrorMessage="Please enter Petorleum ClassB/Naptha" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                11
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label475" runat="server" CssClass="LBLBLACK" Width="210px" Visible="False">Petroleum Class C/Naptha</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStorPetrolTotClassC" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtStorPetrolTotClassC"
                                                    ErrorMessage="Please enter Petrolium C/Napta" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                12
                                            </td>
                                            <td class="style12" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label476" runat="server" CssClass="LBLBLACK" Width="210px">Total</asp:Label>
                                            </td>
                                            <td class="style13" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtStorPetrolGrandTot" Style="text-align: right" runat="server"
                                                    class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()"
                                                    TabIndex="1" ValidationGroup="group" Width="180px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtStorPetrolGrandTot"
                                                    ErrorMessage="Please enter Total" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    &nbsp;
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                1
                                            </td>
                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label478" runat="server" CssClass="LBLBLACK" Width="210px">Sales Tax Registration Details</asp:Label>
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtSalesTaxRegDet" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtNearRail"
                                                    ErrorMessage="Please enter Nearest Railway Station" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">
                                    &nbsp;
                                </td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px">
                                                2&nbsp;
                                            </td>
                                            <td class="style11" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="Label480" runat="server" CssClass="LBLBLACK" Width="210px">Explosive Licnece Details</asp:Label>
                                            </td>
                                            <td class="style10" style="padding: 5px; margin: 5px">
                                                :
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtExpLicDet" runat="server" class="form-control txtbox" Height="28px"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtNearRail"
                                                    ErrorMessage="Please enter Nearest Railway Station" ValidationGroup="group" Visible="False">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="3" align="center">
                                    Maximum Amount of Horse Power to be Installed<tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        1
                                                    </td>
                                                    <td class="style11" style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label481" runat="server" CssClass="LBLBLACK" Width="210px">Regualr(in HP)</asp:Label>
                                                    </td>
                                                    <td class="style10" style="padding: 5px; margin: 5px">
                                                        :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtregularinhp" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ControlToValidate="txtregularinhp"
                                                            ErrorMessage="Please enter Regular Horse Power in HP" ValidationGroup="group">HP</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="style11" style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td class="style10" style="padding: 5px; margin: 5px">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        2&nbsp;
                                                    </td>
                                                    <td class="style11" style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label482" runat="server" CssClass="LBLBLACK" Width="210px">Stand By(in HP)</asp:Label>
                                                    </td>
                                                    <td class="style10" style="padding: 5px; margin: 5px">
                                                        :
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtstandbyHP" runat="server" class="form-control txtbox" Height="28px"
                                                            MaxLength="20" TabIndex="1" ValidationGroup="group" Width="180px" onkeypress="NumberOnly()"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" ControlToValidate="txtstandbyHP"
                                                            ErrorMessage="Please enter Stand By Horse Power in HP" ValidationGroup="group">HP</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    </br>
                                    </br>
                                    <tr id="trplan" runat="server" visible="true">
                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                            1.
                                            <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="165px">Plant layout :</asp:Label>
                                        </td>
                                        <%--<td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="165px">Plant layout</asp:Label>
                                                        </td>--%>
                                        <%--<td style="padding: 5px; margin: 5px">
                                                            &nbsp;
                                                        </td>--%>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:FileUpload ID="FileUpload15" runat="server" class="form-control txtbox" Height="48px" />
                                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                            <br />
                                            <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                            <asp:Button ID="BtnListofDir1" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                OnClick="BtnListofDir1_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                Width="72px" />
                                        </td>
                                    </tr>
                                    <tr id="trlistofdirector" runat="server" visible="true">
                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                            2.
                                            <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="165px">List Of Directors :</asp:Label>
                                        </td>
                                        <%--<td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="165px">List Of Directors</asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">
                                                            :
                                                        </td>--%>
                                        <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:FileUpload ID="FileUpload11" runat="server" class="form-control txtbox" Height="48px" />
                                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                            <br />
                                            <asp:Label ID="Label16" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                            <asp:Button ID="BtnListofDir" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                OnClick="BtnListofDir_Click" TabIndex="10" Text="Upload" ValidationGroup="group"
                                                Width="72px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                                            3.
                                            <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="165px">Partnership deed :</asp:Label>
                                        </td>
                                        <%--<td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="165px">Partnership deed</asp:Label>
                                                            </td>
                                                            <td class="style8" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>--%>
                                        <td class="style9" style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:FileUpload ID="FileUpload10" runat="server" class="form-control txtbox" Height="48px" />
                                            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                            <br />
                                            <asp:Label ID="Label18" runat="server" Visible="False"></asp:Label>
                                            <br />
                                        </td>
                                        <td class="style10" style="padding: 5px; margin: 5px;">
                                            <asp:Button ID="BtnPartDeed" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnPartDeed_Click" />
                                        </td>
                                    </tr>
                                    <%-- <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                            &nbsp;<tr>
                                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                                    &nbsp;
                                                                </td>--%>
                            </tr>
                            
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    4.
                                    <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="165px">Land OwnerShip Deed :</asp:Label>
                                </td>
                                <%--<td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="165px">Land OwnerShip Deed</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>--%>
                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:FileUpload ID="FileUpload13" runat="server" class="form-control txtbox" Height="48px" />
                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                    <br />
                                    <asp:Label ID="Label20" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                    <asp:Button ID="BtnLandDeed" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BtnLandDeed_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    5.
                                    <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="476px">List of actual number of workers employed both Contract and Regular  :</asp:Label>
                                </td>
                               
                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:FileUpload ID="FUPLISTOFWORKERS" runat="server" class="form-control txtbox" Height="48px" />
                                    <asp:HyperLink ID="HYPLISTOFWORKERS" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                    <br />
                                    <asp:Label ID="LBLLISTOFWORKERS" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                    <asp:Button ID="BTNLISTOFWORKERS" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BTNLISTOFWORKERS_Click" />
                                </td>
                            </tr>
                             <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    6.
                                    <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="422px"> Photographs of Machinery installed :</asp:Label>
                                </td>
                               
                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:FileUpload ID="FUPMACHINERYINSTALLED" runat="server" class="form-control txtbox" Height="48px" />
                                    <asp:HyperLink ID="HYPMACHINERYINSTALLED" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                    <br />
                                    <asp:Label ID="LBLMACHINERYINSTALLED" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                    <asp:Button ID="BTNMACHINERYINSTALLED" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BTNMACHINERYINSTALLED_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                    7.
                                    <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="186px"> Self Compliance check list :</asp:Label>
                                    <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/UI/TSiPASS/DisplayDocs/Self compliance check list.docx" target="_blank">Self Compliance check list</a>
                                </td>
                               
                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                    <asp:FileUpload ID="FUPSELFCOMP" runat="server" class="form-control txtbox" Height="48px" />
                                    <asp:HyperLink ID="HYPSELFCOMP" runat="server" CssClass="LBLBLACK" Width="165px"></asp:HyperLink>
                                    <br />
                                    <asp:Label ID="LBLSELFCOMP" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                    <asp:Button ID="BTNSELFCOMP" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                        TabIndex="10" Text="Upload" ValidationGroup="group" Width="72px" OnClick="BTNSELFCOMP_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px"
                                        OnClick="BtnClear0_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />
                                    &nbsp;<asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                        Height="32px" OnClick="BtnDelete0_Click" TabIndex="10" Text="Previous" ValidationGroup="group"
                                        Width="90px" />
                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" class="alert alert-success" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">
                                            ×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                        <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            </td> </tr>
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                                                                      <asp:HiddenField ID="HDNFACTSTAGEID" runat="server" />
                                                                       


                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                    </div>
                    <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />

</div>
    
</div>
</ProgressTemplate>
</asp:UpdateProgress> --%>
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
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
