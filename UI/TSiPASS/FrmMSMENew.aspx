<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true" CodeFile="FrmMSMENew.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="javascript">
      function pageLoad(sender, args) 
    { 

        var f = $('#ctl00_ContentPlaceHolder1_hdnfocus').val();        
        if(f!="")
        {
            $('#'+f).focus();            
        }
    }
    </script>
<script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    
<style type="text/css">
.overlay
{
position: fixed;
z-index: 999;
height: 100%;
width: 100%;
top: 112px;
background-color:Gray;
filter: alpha(opacity=60);
opacity: 0.9;
-moz-opacity: 0.9;
}

	

    .style5
    {
    }
    
	

    .style8
    {
        width: 18px;
    }
    .style15
    {
        width: 27px;
        height: 48px;
    }
    .style16
    {
        height: 48px;
    }
    .style17
    {
        width: 19px;
        height: 48px;
    }
    .style18
    {
        height: 48px;
    }

	

    .style19
    {
        height: 48px;
        width: 172px;
    }

	

    .style20
    {
        width: 10px;
        height: 48px;
    }

	

    .style21
    {
        width: 18px;
        height: 46px;
    }
    .style22
    {
        height: 46px;
    }
    .style23
    {
        width: 194px;
    }
    .style24
    {
        height: 46px;
        width: 194px;
    }
    .style25
    {
        width: 20px;
        height: 48px;
    }

	

</style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

    window.open("Lookups/LookupBDC.aspx","List","scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

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
<input type="hidden" id="hdnfocus" value="" runat="server" />
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx"></a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit"></i> 
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">Questionnaire - Consent for Establishment</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Telangana State Industrial Catalogue</h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" class="style5">
                                            <asp:Label ID="Label570" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="180px">Unit Details :</asp:Label>
                                        </td>
                                        <td style="width: 10px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style5" style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr ID="trpwd" runat="server">
                                                    <td style="padding: 5px; margin: 5px" class="style8">
                                                        &nbsp;1&nbsp; </td>
                                                    <td style="padding: 5px; margin: 5px" class="style23">
                                                        <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK" Width="155px">Name of Unit<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtnameofUnit" runat="server" AutoPostBack="True" 
                                                            class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                            ControlToValidate="TxtnameofUnit" ErrorMessage="Please enter Name of the Unit" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" class="style8">
                                                        2&nbsp; </td>
                                                    <td style="padding: 5px; margin: 5px" class="style23">
                                                        <asp:Label ID="Label563" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" 
                                                            AutoPostBack="True" class="form-control txtbox" Height="33px" TabIndex="1" 
                                                            Width="180px" 
                                                            onselectedindexchanged="ddlProp_intDistrictid_SelectedIndexChanged1">
                                                            <asp:ListItem>--District--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" class="style8">
                                                        3&nbsp; </td>
                                                    <td style="padding: 5px; margin: 5px" class="style23">
                                                        <asp:Label ID="Label350" runat="server" CssClass="LBLBLACK" Width="137px">Mandal<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlLoc_of_unit" runat="server" 
                                                            class="form-control txtbox" Height="33px" Width="180px" 
                                                            AutoPostBack="True"  
                                                            TabIndex="1">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                            ControlToValidate="ddlLoc_of_unit" 
                                                            ErrorMessage="Please Select Location Of thr Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style21" style="padding: 5px; margin: 5px">
                                                        4</td>
                                                    <td style="padding: 5px; margin: 5px" class="style24">
                                                        <asp:Label ID="Label586" runat="server" CssClass="LBLBLACK" Width="137px">Location of the unit<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" class="style22">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px" class="style22">
                                                        <asp:DropDownList ID="ddlLoc_of_unit0" runat="server" AutoPostBack="True" 
                                                            class="form-control txtbox" Height="33px" TabIndex="1" Width="180px" 
                                                            onselectedindexchanged="ddlLoc_of_unit0_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>With in IALA/Industrial Estate/Industrial Park</asp:ListItem>
                                                            <asp:ListItem>Out Side IALA/Industrial Estate/Industrial Park</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" class="style22">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" 
                                                            ControlToValidate="ddlLoc_of_unit0" ErrorMessage="Please Select Unit Location" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8" style="padding: 5px; margin: 5px">
                                                        5</td>
                                                    <td style="padding: 5px; margin: 5px" class="style23">
                                                        <asp:Label ID="Label587" runat="server" CssClass="LBLBLACK" Width="137px" 
                                                            EnableTheming="True">Details Industrial Estate</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtUnitAddress" runat="server" class="form-control txtbox" 
                                                            Height="38px" TabIndex="0" TextMode="MultiLine" ValidationGroup="group" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" 
                                                            ControlToValidate="txtUnitAddress" ErrorMessage="Please enter Unit Address" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 10px">
                                            <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="10px"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 82%; margin-left: 0px;">
                                                
                                                <tr ID="trApplType" runat="server">
                                                    <td style="padding: 5px; margin: 5px">
                                                        6&nbsp; </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Width="137px">SSI Reg./EM/Udyog Aadhar/IEM/SIA/IEC No.<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        .:</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtEMNo" runat="server" 
                                                            class="form-control txtbox" Height="28px" MaxLength="30" 
                                                             ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                                            ControlToValidate="TxtEMNo" ErrorMessage="Please enter EM/Udyog Aadhar No" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr><tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        7</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label565" runat="server" CssClass="LBLBLACK" Width="180px">Category of enterprise<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlcategory" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">Micro</asp:ListItem>
                                                            <asp:ListItem Value="2">Small</asp:ListItem>
                                                            <asp:ListItem Value="3">Medium</asp:ListItem>
                                                            <asp:ListItem Value="4">Large</asp:ListItem>
                                                            <asp:ListItem Value="5">Mega</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                                            ControlToValidate="ddlcategory" ErrorMessage="Please selec Category" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        8</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label566" runat="server" CssClass="LBLBLACK" Width="183px">Date of Commencement of Production(DCP) (DD-MM-YYYY)<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtRegDate" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" 
                                                            PopupButtonID="txtRegDate" TargetControlID="txtRegDate">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                                            ControlToValidate="txtRegDate" ErrorMessage="Please enter Date of Commencemet" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label589" runat="server" CssClass="LBLBLACK" Width="180px">Sector<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtSector" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" 
                                                            ControlToValidate="TxtSector" ErrorMessage="Please enter Sector" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="style5" colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                            <table width="100%">
                                           <tr>
                                                    <td style="padding: 5px; margin: 5px" class="style25">
                                                        9&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px" class="style19">
                                                        <asp:Label ID="Label588" runat="server" CssClass="LBLBLACK" Width="165px">Line of Activity<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" class="style20">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px" class="style18">
                                                        <asp:DropDownList ID="ddlintLineofActivity" runat="server" AutoPostBack="True" 
                                                            class="form-control txtbox" Height="33px" 
                                                            onselectedindexchanged="ddlintLineofActivity_SelectedIndexChanged" 
                                                            Width="600px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" 
                                                            ControlToValidate="ddlintLineofActivity" 
                                                            ErrorMessage="Please Select Line of Activity" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            <tr>
                                                    <td style="padding: 5px; margin: 5px" class="style25">
                                                        10</td>
                                                    <td style="padding: 5px; margin: 5px" class="style19">
                                                        <asp:Label ID="Label564" runat="server" CssClass="LBLBLACK" Width="165px">PCB categorisation of enterprise<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" class="style20">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px" class="style18">
                                                        <asp:Label ID="LblPol_Category" runat="server" CssClass="LBLBLACK" 
                                                            Font-Bold="True" Font-Size="18px" Width="200px"></asp:Label>
                                                        <asp:HiddenField ID="HdfLblPol_Category" runat="server" />
                                                    </td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style25" style="padding: 5px; margin: 5px">
                                                        11</td>
                                                    <td class="style19" style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label585" runat="server" CssClass="LBLBLACK" Width="165px"> Product Description<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td class="style20" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtProdution" runat="server" AutoPostBack="True" 
                                                            class="form-control txtbox" Height="38px" TabIndex="0" TextMode="MultiLine" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" 
                                                            ControlToValidate="txtProdution" 
                                                            ErrorMessage="Please enter Product Description" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="style5" style="padding: 5px; margin: 5px" valign="top">
                                            <asp:Label ID="Label571" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="180px">General Details :</asp:Label>
                                        </td>
                                        <td style="width: 10px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style5" style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        12</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="137px">Caste<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px" 
                                                            onselectedindexchanged="ddlCaste_SelectedIndexChanged" AutoPostBack="True">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">OC</asp:ListItem>
                                                            <asp:ListItem Value="2">BC</asp:ListItem>
                                                            <asp:ListItem Value="3">SC</asp:ListItem>
                                                            <asp:ListItem Value="4">ST</asp:ListItem>
                                                            <asp:ListItem Value="4">ST</asp:ListItem>
                                                            <asp:ListItem Value="5">Minority</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                                                            ControlToValidate="ddlCaste" ErrorMessage="Please select Caste" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="TrMoniorty" visible="false" runat="server">
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="137px">Indicate religion :<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtMinorityType" runat="server" class="form-control txtbox" 
                                                            Height="28px" TabIndex="0" ValidationGroup="group" Width="180px" 
                                                            MaxLength="15"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="txtMinorityType" ErrorMessage="Please Enter txtMinorityType" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr ID="trUserid" runat="server">
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        13</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label379" runat="server" CssClass="LBLBLACK" Width="165px">Indicate whether women entrepreneur? <font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RadioButtonList ID="RdDo_Store_Kerosine" runat="server" 
                                                            RepeatDirection="Horizontal" 
                                                            onselectedindexchanged="RdDo_Store_Kerosine_SelectedIndexChanged">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                  <tr ID="tr6" runat="server">
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        14</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">Indicate whether differently abled ?<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                                            RepeatDirection="Horizontal" 
                                                           >
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr ID="tr1" runat="server">
                                                    <td style="padding: 5px; margin: 5px">
                                                        15</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Height="59px" 
                                                            Width="165px">Whether power connection is LT /HT?<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlPower" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">LT</asp:ListItem>
                                                            <asp:ListItem Value="2">HT</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                                                            ControlToValidate="ddlPower" ErrorMessage="Please Select Power Connection" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                 <tr ID="tr4" runat="server">
                                                    <td style="padding: 5px; margin: 5px">
                                                        16</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Height="51px" 
                                                            Width="165px">Connected load in HP<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtVoltage" runat="server" 
                                                            class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                                                            ControlToValidate="txtVoltage" ErrorMessage="Please enter Voltage" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 10px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                               
                                                <tr ID="tr2" runat="server">
                                                    <td style="padding: 5px; margin: 5px">
                                                        17</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label568" runat="server" CssClass="LBLBLACK" Width="180px">Investment in Rs.lakhs<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtInverstment" runat="server" 
                                                            class="form-control txtbox" Height="28px" MaxLength="10" 
                                                            onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group" 
                                                            Width="180px"></asp:TextBox>
                                                        <br />
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" 
                                                            ControlToValidate="txtInverstment" ErrorMessage="Please enter Investment" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        18</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label393" runat="server" CssClass="LBLBLACK" Width="180px">Employment <font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtEmployement" runat="server" 
                                                            class="form-control txtbox" Height="28px" MaxLength="10" 
                                                            onkeypress="DecimalOnly()" TabIndex="0" ValidationGroup="group" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                                                            ControlToValidate="txtEmployement" ErrorMessage="Please enter Employement" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                  <tr ID="tr7" runat="server">
                                                    <td style="padding: 5px; margin: 5px">
                                                        19</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="180px">Do you market your product outside state?<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RadioButtonList ID="RdbMarket" runat="server" 
                                                            
                                                            RepeatDirection="Horizontal" 
                                                          
                                                            AutoPostBack="True" 
                                                            onselectedindexchanged="RdbMarket_SelectedIndexChanged">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr ID="tr3" runat="server">
                                                    <td style="padding: 5px; margin: 5px" valign="middle">
                                                        20</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="180px">Indicate state1<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtMajorclients" runat="server" 
                                                            class="form-control txtbox" Height="38px" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                
                                                 <tr ID="trindicateState1" runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px" valign="middle">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="180px">Indicate state2<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtindicateState1" runat="server" 
                                                            class="form-control txtbox" Height="38px" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr ID="trindicateState2" runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px" valign="middle">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="180px">Indicate state3<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtIndicateState2" runat="server" 
                                                            class="form-control txtbox" Height="38px" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                
                                                 <tr ID="tr5" runat="server">
                                                    <td style="padding: 5px; margin: 5px">
                                                        21</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="180px">Do you export your product?<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RadioButtonList ID="RdDo_Store_Kerosine0" runat="server" 
                                                            
                                                            RepeatDirection="Horizontal" 
                                                            onselectedindexchanged="RdDo_Store_Kerosine0_SelectedIndexChanged" 
                                                            AutoPostBack="True">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr ID="trfallin" runat="server" visible="false" >
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="169px">Countries exported to1<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtOutSideclients" runat="server" 
                                                            class="form-control txtbox" Height="38px" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                 <tr ID="trCountry1" runat="server" visible="false" >
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="169px">Countries exported to2<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtCountry1" runat="server" 
                                                            class="form-control txtbox" Height="38px" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                
                                                 <tr ID="trCountry2" runat="server" visible="false" >
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="169px">Countries exported to3<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtCountry2" runat="server" 
                                                            class="form-control txtbox" Height="38px" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                            <table width="100%">
                                                
                                                
                                                <tr>
                                                    <td class="style15" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style16" style="padding: 5px; margin: 5px; text-align: center;" 
                                                        colspan="4">
                                                        <asp:Label ID="Label584" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                            ForeColor="#CC3300" Width="484px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="uploadnew" runat="server" visible="false">
                                                    <td class="style15" style="padding: 5px; margin: 5px">
                                                        21</td>
                                                    <td class="style16" style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label583" runat="server" CssClass="LBLBLACK" Width="157px">Certification(if any) obtained by the unit<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td class="style17" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        <asp:FileUpload ID="FileUpload17" runat="server" class="form-control txtbox" 
                                                            Height="28px" />
                                                        <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" 
                                                            Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                        <br />
                                                        <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                                        <br />
                                                        <asp:Button ID="BtnUpload4" runat="server" CssClass="btn btn-xs btn-warning" 
                                                            Height="28px" onclick="BtnUpload_Click" TabIndex="10" Text="Upload" 
                                                            Width="72px" />
                                                    </td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr id="uploadnew1" runat="server" visible="false">
                                                    <td class="style15" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style16" style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label579" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                            Width="210px">Product Details :</asp:Label>
                                                    </td>
                                                    <td class="style17" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr id="uploadnew2" visible="false" runat="server">
                                                    <td class="style15" style="padding: 5px; margin: 5px">
                                                        22</td>
                                                    <td class="style16" style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label580" runat="server" CssClass="LBLBLACK" Width="210px">Product Name<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td class="style17" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtOthers" runat="server" class="form-control txtbox" 
                                                            Height="38px" TabIndex="1" TextMode="MultiLine" ValidationGroup="groupproduct" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" 
                                                            ControlToValidate="txtOthers" ErrorMessage="Please enter Product Name" 
                                                            ValidationGroup="groupproduct">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="uploadnew3" visible="false" runat="server">
                                                    <td class="style15" style="padding: 5px; margin: 5px">
                                                        23</td>
                                                    <td class="style16" style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="210px">Product Document <font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td class="style17" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        <asp:FileUpload ID="FileUpload9" runat="server" class="form-control txtbox" 
                                                            Height="28px" Width="300px" />
                                                        <asp:HyperLink ID="Label577" runat="server" CssClass="LBLBLACK" Target="_blank" 
                                                            Width="165px">[Label5]</asp:HyperLink>
                                                    </td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr runat="server" id="uploadnew4" visible="false">
                                                    <td class="style15" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style16" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style17" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        <asp:Button ID="Button7" runat="server" CssClass="btn btn-xs btn-warning" 
                                                            Height="28px" onclick="Button7_Click" TabIndex="10" Text="Add" 
                                                            ValidationGroup="groupproduct" Width="72px" />
                                                    </td>
                                                    <td class="style18" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr runat="server" visible="false" id="uploadnew5" >
                                                    <td class="style15" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style16" colspan="4" style="padding: 5px; margin: 5px">
                                                        <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" 
                                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
                                                            CssClass="GRD" ForeColor="#333333" GridLines="None" 
                                                            OnRowDataBound="gvCertificate_RowDataBound" 
                                                            OnRowDeleting="gvCertificate_RowDeleting" 
                                                            onselectedindexchanged="gvCertificate_SelectedIndexChanged" Width="50%">
                                                            <rowstyle backcolor="#ffffff" />
                                                            <columns>
                                                                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
--%>
                                                                <asp:BoundField DataField="Manf_ItemName" HeaderText="Product Name" />
                                                                <asp:BoundField DataField="Manf_Item_Quantity_In" 
                                                                    HeaderText="Product Document" />
                                                            </columns>
                                                            <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                            <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                            <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                            <headerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                            <editrowstyle backcolor="#013161" />
                                                            <alternatingrowstyle backcolor="White" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style15" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style16" colspan="4" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    
                                    <table width="100%" >
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                &nbsp;<td align="center" style="padding: 5px; margin: 5px">
                                                    &nbsp;<td align="center" style="padding: 5px; margin: 5px">
                                                        &nbsp;<td align="center" style="padding: 5px; margin: 5px">
                                                            &nbsp;<td align="center" style="padding: 5px; margin: 5px">
                                                                &nbsp;<td align="center" style="padding: 5px; margin: 5px">
                                                                    &nbsp;<td align="center" style="padding: 5px; margin: 5px">
                                                                        &nbsp;<td align="center" style="padding: 5px; margin: 5px">
                                                                            &nbsp;<tr>
                                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" 
                                                                                    colspan="8">
                                                                                    <asp:Button ID="BtnSave" runat="server" 
                                                                                        CssClass="btn-success" Height="32px"  TabIndex="10" 
                                                                                        Text="Next" ValidationGroup="group" Width="80px" 
                                                                                        onclick="BtnSave_Click" />
                                                                                    &nbsp;
                                                                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                                                        CssClass="btn-warning" Height="32px"  TabIndex="10" 
                                                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="80px" 
                                                                                        onclick="BtnClear_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="8" 
                                                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                                                    <asp:Button ID="BtnSave0" runat="server" CausesValidation="False" 
                                                                                        CssClass="btn-success" Height="32px" TabIndex="10" Text="Submit" 
                                                                                        ValidationGroup="group" Visible="False" Width="80px" 
                                                                                        onclick="BtnSave0_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <caption>
                                                                                &nbsp;</caption>
                                                                        </td>
                                                                    </td>
                                                                </td>
                                                            </td>
                                                        </td>
                                                    </td>
                                                </td>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <tr>
                                        <td align="center" colspan="10" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="10" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="10" style="padding: 5px; margin: 5px">
                                            <div ID="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" 
                                                    href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label 
                                                    ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div ID="Failure" runat="server" class="alert alert-danger" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>
                                                Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="groupproduct" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                                <br />
                                <asp:HiddenField ID="hdfFlagID0" runat="server" />
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
<div style=" z-index: 1000; margin-left: 250px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
<img alt="" src="../../Resource/Images/Processing.gif" />

</div>
    
</div>
</ProgressTemplate>
</asp:UpdateProgress>   
                 
          
          <%--<br />--%>
          
                       
  </ContentTemplate>
  <Triggers>
            <%--<asp:PostBackTrigger ControlID="BtnSave3" />--%>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnSave" />
            <asp:PostBackTrigger ControlID="Button7" />
            <asp:PostBackTrigger ControlID="BtnUpload4" />
            <asp:PostBackTrigger ControlID="BtnSave" />
            <asp:PostBackTrigger ControlID="Button7" />
            <asp:PostBackTrigger ControlID="BtnUpload4" />
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnSave" />
            <asp:PostBackTrigger ControlID="Button7" />
            <asp:PostBackTrigger ControlID="BtnUpload4" />
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnSave"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Button7"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnUpload4"></asp:PostBackTrigger>
 </Triggers>
        <Triggers>
<asp:PostBackTrigger ControlID="BtnSave" />        
            <asp:PostBackTrigger ControlID="Button7" />
            <asp:PostBackTrigger ControlID="BtnUpload4" />
             </Triggers>
  </asp:UpdatePanel>
 <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

