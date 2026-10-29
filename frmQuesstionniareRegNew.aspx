<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master" AutoEventWireup="true" CodeFile="frmQuesstionniareRegNew.aspx.cs" Inherits="TSTBDCReg1" %>

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
                                <h3 class="panel-title">Questionnaire - Consent for Establishment</h3>
                            </div>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                            
                                              <tr runat="server" id="trpwd">
                                                    <td style="padding: 5px; margin: 5px">
                                                        1</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK" Width="180px">Constitution of the unit<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlConst_of_unit" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">Proprietary</asp:ListItem>
                                                            <asp:ListItem Value="2">Partnership</asp:ListItem>
                                                            <asp:ListItem Value="3">Pvt Ltd</asp:ListItem>
                                                            <asp:ListItem Value="4">Public Limited</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="ddlConst_of_unit" 
                                                            ErrorMessage="Please Select Constitition of Unit" InitialValue="--Select--" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        2</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="165px">Sector of Enterprise<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                        <asp:DropDownList ID="ddlSector_Ent" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlSector_Ent_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">Manufacturing</asp:ListItem>
                                                            <asp:ListItem Value="2">Service</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="ddlSector_Ent" 
                                                            ErrorMessage="Please Select Sector of Enterprise" InitialValue="--Select--" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                        3</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="180px">Total Extent of Land <br />(in Sq mtrs)<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtTot_Extent" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="6" onkeypress="DecimalOnly()" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" 
                                                            ontextchanged="TxtTot_Extent_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                            ControlToValidate="TxtTot_Extent" 
                                                            ErrorMessage="Please Enter Total Extent of Land (In Sq mtrs)" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        4</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label352" runat="server" CssClass="LBLBLACK" Width="165px">Proposed Location<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlProp_intDistrictid_SelectedIndexChanged">
                                                            <asp:ListItem>--District--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                            ControlToValidate="ddlProp_intDistrictid" 
                                                            ErrorMessage="Please Select Proposed Location (District)" 
                                                            InitialValue="--District--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlProp_intMandalid" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlProp_intMandalid_SelectedIndexChanged">
                                                            <asp:ListItem>--Mandal--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                            ControlToValidate="ddlProp_intMandalid" 
                                                            ErrorMessage="Please Select Proposed Location (Mandal)" 
                                                            InitialValue="--Mandal--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlProp_intVillageid" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Village--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                            ControlToValidate="ddlProp_intVillageid" 
                                                            ErrorMessage="Please Select Proposed Location (Village)" 
                                                            InitialValue="--Village--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        5&nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label350" runat="server" CssClass="LBLBLACK" Width="137px">Location of the unit<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlLoc_of_unit" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlLoc_of_unit_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">Within the purview of HMDA (HMDA list of villages link)</asp:ListItem>
                                                            <asp:ListItem Value="2">Within the purview of DT&amp;CP(Outside HMDA)</asp:ListItem>
                                                            <asp:ListItem Value="3">Within the purview of KUDA</asp:ListItem>
                                                             <asp:ListItem Value="4">IALA (TSIIC)</asp:ListItem>
                                                              <asp:ListItem Value="5">Within the purview of GM DIC, HYD</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                            ControlToValidate="ddlLoc_of_unit" 
                                                            ErrorMessage="Please Select Location of Unit" InitialValue="--Select--" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trApplType" visible="false">
                                                    <td style="padding: 5px; margin: 5px">
                                                        5.a</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Width="137px">Application Type<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlAppl_Type" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">Change of Land Use</asp:ListItem>
                                                            <asp:ListItem Value="2">Industrial Building Approval</asp:ListItem>
                                                            <asp:ListItem Value="3">Both</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                            ControlToValidate="ddlAppl_Type" ErrorMessage="Please Select Application Type" 
                                                            InitialValue="0" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        6</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label388" runat="server" CssClass="LBLBLACK" Width="165px">Proposed Employment<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtProp_Emp" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="6" onkeypress="NumberOnly()" 
                                                            ValidationGroup="group" Width="180px" AutoPostBack="True" 
                                                            ontextchanged="TxtProp_Emp_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                            ControlToValidate="TxtProp_Emp" ErrorMessage="Please Enter Proposed Employment" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        7</td>
                                                    <td colspan="3" style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label389" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                            Width="355px">Project Cost (in Rs. Lakhs) : </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label390" runat="server" CssClass="LBLBLACK" Width="180px">a) Value of Land (in Lakhs)<br />(Mention Zero in case of leased premises)<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtVal_Land" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="8" onkeypress="DecimalOnly()" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" AutoPostBack="True" 
                                                            ontextchanged="TxtVal_Land_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                            ControlToValidate="TxtVal_Land" ErrorMessage="Please Enter Value of Land" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label391" runat="server" CssClass="LBLBLACK" Width="180px">b) Value of Building(in Lakhs)<br />(Mention Zero in case of leased premises)<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtVal_Build" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="8" onkeypress="DecimalOnly()" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" AutoPostBack="True" 
                                                            ontextchanged="TxtVal_Build_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                            ControlToValidate="TxtVal_Build" ErrorMessage="Please Enter Value of Building" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label392" runat="server" CssClass="LBLBLACK" Width="180px">c) Value of Plant &amp; Machinery or Service Equipment(in Lakhs)<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtVal_Plant" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="8" onkeypress="DecimalOnly()" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" AutoPostBack="True" 
                                                            ontextchanged="TxtVal_Plant_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                            ControlToValidate="TxtVal_Plant" 
                                                            ErrorMessage="Please Enter Value of Plant &amp; Machinery Or Service Equipment" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label393" runat="server" CssClass="LBLBLACK" Width="180px">Total Project Cost(in Lakhs) <font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="TxtTot_PrjCost" runat="server" CssClass="LBLBLACK" 
                                                            Font-Bold="True" Width="180px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label394" runat="server" CssClass="LBLBLACK" Width="165px">Your enterprise is</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                          <asp:Label ID="LblEnt_is" runat="server" CssClass="LBLBLACK" Width="165px" 
                                                              Font-Bold="True" Font-Size="18px"></asp:Label>
                                                          <asp:HiddenField ID="HdfLblEnt_is" runat="server" />
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                               
                                                
                                            </table>
                                        </td>
                                        <td style="width: 10px">
                                            <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="30px"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                            
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        11</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label358" runat="server" CssClass="LBLBLACK" Width="165px">Power requirement in HP<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlPower_Req" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">=<30 HP</asp:ListItem>
                                                            <asp:ListItem Value="2">>30 HP and <500 HP</asp:ListItem>
                                                            <asp:ListItem  Value="3" >>500 HP</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                            ControlToValidate="ddlPower_Req" 
                                                            ErrorMessage="Please Select Power requirement in HP" InitialValue="--Select--" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        12</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label370" runat="server" CssClass="LBLBLACK" Width="180px">Water Required per day( in KLD)<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtWater_req_Perday" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="8" onkeypress="DecimalOnly()" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                            ControlToValidate="TxtWater_req_Perday" 
                                                            ErrorMessage="Please Enter Water Required per day (In KLD)" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        13</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="137px">Water required from <font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:CheckBoxList ID="ChkWater_reg_from" runat="server">
                                                            <asp:ListItem>New Bore well</asp:ListItem>
                                                            <asp:ListItem>HMWS &amp; SB</asp:ListItem>
                                                            <asp:ListItem>Rivers/Canals</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr runat="server" id="trUserid">
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        14</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label379" runat="server" CssClass="LBLBLACK" Width="210px">Do you store Rectified Spirit/Kerosene/Naptha<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RadioButtonList ID="RdDo_Store_Kerosine" runat="server" 
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                              
                                                
                                                
                                                
                                                <tr runat="server" id="tr1">
                                                    <td style="padding: 5px; margin: 5px">
                                                        15</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="180px">Generator Requirement<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RadioButtonList ID="RdGen_Reqired" runat="server" 
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                
                                                
                                                <tr runat="server" id="tr2">
                                                    <td style="padding: 5px; margin: 5px">
                                                        16</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="180px">Height of the building(in Meters)<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtHight_Build" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="2"  TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" ></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                                            ControlToValidate="TxtHight_Build" 
                                                            ErrorMessage="Please Enter Height of Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                
                                                
                                                <tr runat="server" id="tr3">
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        17</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="180px">Built up Area (Including Parking Cellars)<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="TxtBuilt_up_Area" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="6"  TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" ></asp:TextBox>
                                                        Square Meters</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                                            ControlToValidate="TxtBuilt_up_Area" 
                                                            ErrorMessage="Please Enter Built up Area (Including Parking Cellars)" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                  <tr runat="server" id="trfallin" >
                                                    <td style="padding: 5px; margin: 5px">
                                                        18</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="180px">Does your location fall under muncipal limit<font 
                                                            color="red">*</font></asp:Label>
                                                      </td>
                                                      <td style="padding: 5px; margin: 5px">
                                                          :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RadioButtonList ID="RdFall_in_Municipal" runat="server" 
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="M">Yes</asp:ListItem>
                                                            <asp:ListItem Value="R" Selected="True">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr runat="server" id="trNoExepted">
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        19</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="180px">Is there any need to Fell trees in Proposed Site<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RadioButtonList ID="RdProp_Site" runat="server" 
                                                            RepeatDirection="Horizontal" AutoPostBack="True" 
                                                            onselectedindexchanged="RdProp_Site_SelectedIndexChanged">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                        &nbsp;</td>
                                                </tr>
                                                
                                                 <tr runat="server" id="trtrees" visible="false">
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="180px">Number of trees to be felled(Girth of tree > 30 centimeters)<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                         <asp:TextBox ID="Txt_NoofTrees" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" AutoPostBack="True" 
                                                            ontextchanged="TxtVal_Land_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                            ControlToValidate="Txt_NoofTrees" 
                                                            ErrorMessage="Please Enter Number of trees to e felled" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                                            ControlToValidate="Txt_NoofTrees" 
                                                            ErrorMessage="Please Enter Number of trees to e felled" InitialValue="0" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                     </td>
                                                </tr>
                                                
                                                <tr runat="server" id="tr4" visible="false">
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="180px">Are there any trees in Non-Exempted(Other than trees in this <a target="_blank" href="../../docs/Exempted_Trees.pdf">List</a>)<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                         <asp:RadioButtonList ID="RdbExecpted" runat="server" 
                                                            RepeatDirection="Horizontal" >
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                      
                                                     </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        20</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="180px">Name of Unit<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                         <asp:TextBox ID="TxtnameofUnit" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="50"  TabIndex="0" 
                                                            ValidationGroup="group" Width="180px" AutoPostBack="True" 
                                                            ></asp:TextBox>
                                                    </td>
                                                    <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                            ControlToValidate="TxtnameofUnit" 
                                                            ErrorMessage="Please Enter Name of Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                        
                                                     </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                            <table  width="100%"> <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        8</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label395" runat="server" CssClass="LBLBLACK" Width="165px">Line of Activity<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlintLineofActivity" runat="server" 
                                                            class="form-control txtbox" Height="33px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlintLineofActivity_SelectedIndexChanged" 
                                                            Width="600px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                            ControlToValidate="ddlintLineofActivity" 
                                                            ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                </table></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                            <table width="100%"><tr runat="server" id="trFallinPolution" >
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        9</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="180px">Does your unit fall under the list of <font 
                                                            color="red">*</font></asp:Label>
                                                            <a  style="color:Black" target="_blank" href="LIST OF POLLUTING INDUSTRIES IN SMALL SCALE SECTOR.pdf" >
                                                        66 polluting industries</a>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RadioButtonList ID="RdPol_Indus" runat="server" 
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        10</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="180px">Pollution Category of Enterprise<font 
                                                            color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px" runat="server" id="trPOPCategory">
                                                        <asp:Label ID="LblPol_Category" runat="server" CssClass="LBLBLACK" 
                                                            Width="200px" Font-Bold="True" Font-Size="18px"></asp:Label>
                                                        <asp:HiddenField ID="HdfLblPol_Category" runat="server" />
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr></table></td>
                                        <td style="width: 10px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                           <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                            &nbsp;</td>
                                    </tr> 
                                            <caption>
                                                &nbsp;</caption>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn-primary" 
                                                Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Show Approvals & Fees" 
                                                Width="170px" ValidationGroup="group" />
                                            &nbsp;&nbsp;<asp:Button ID="BtnSave" runat="server" CausesValidation="False" 
                                                CssClass="btn-success" Height="32px" onclick="BtnClear0_Click" 
                                             
                                                TabIndex="10" Text="Submit" ValidationGroup="group" Width="80px" 
                                                Visible="False" />
                                            &nbsp; 
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                CssClass="btn-warning" Height="32px" onclick="BtnClear_Click" TabIndex="10" 
                                                Text="ClearAll" ToolTip="To Clear  the Screen" Width="80px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3" 
                                            style="padding: 5px; margin: 5px; text-align: left;">
                                            
                                            <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="280px">Fee Details(in Rs.)</asp:Label>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" 
                                            style="padding: 5px; margin: 5px; text-align: center;">
                                            <asp:GridView ID="grdDetails" runat="server" 
                                                AutoGenerateColumns="False" CellPadding="4" CssClass="GRD" ForeColor="#333333" 
                                                Height="62px" PageSize="15" Width="100%" 
                                                onrowdatabound="grdDetails_RowDataBound" ShowFooter="True">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" 
                                                    verticalalign="Middle" />
                                                <columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required " >
                                                        <ItemStyle Width="450px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Dept_Full_name" HeaderText="Department" >
                                                        <ItemStyle Width="180px" />
                                                    </asp:BoundField>
                                                   <asp:BoundField DataField="Fees" FooterStyle-HorizontalAlign="Right" HeaderText="Fees (Rs.)"
                                                                DataFormatString="{0:0}">
                                                                <FooterStyle CssClass="GRDITEM2" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                <ItemStyle CssClass="GRDITEM2" Width="150px" HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" 
                                                    forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                            
                                            
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label> 
  </div>
                                            
                                            
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> 
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
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
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

