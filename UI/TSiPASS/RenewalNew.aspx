<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true" CodeFile="RenewalNew.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
 
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp;<li class="active">
                                <a href="#">Renewals </a></li>
                        </ol>
     
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Renewal Form</h3>
                            </div>
                           
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td align="center" class="style21" style="padding: 5px; margin: 2px">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td class="style26" 
                                                        style="padding: 5px; margin: 5px; text-align: left;">
                                                        &nbsp;</td>
                                                    <td class="style26" colspan="7" 
                                                        style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label562" runat="server" CssClass="LBLBLACK" Width="481px" 
                                                            Font-Bold="True">Unit 
                                                        Details</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                        1</td>
                                                    <td class="style26" 
                                                        style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label563" runat="server" CssClass="LBLBLACK" Width="197px">Name 
                                                        Of the Unit </asp:Label>
                                                    </td>
                                                    <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                        :</td>
                                                    <td class="style26" 
                                                        style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lblUnitName" runat="server" CssClass="LBLBLACK" Width="121px"></asp:Label>
                                                    </td>
                                                    <td class="style26" 
                                                        style="padding: 5px; margin: 5px; text-align: right;">
                                                        3</td>
                                                    <td class="style45" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label565" runat="server" CssClass="LBLBLACK" Width="121px">Mobile 
                                                        No</asp:Label>
                                                    </td>
                                                    <td>
                                                        :</td>
                                                    <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lblMobNo" runat="server" CssClass="LBLBLACK" Width="121px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                        2</td>
                                                    <td class="style26" 
                                                        style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label567" runat="server" CssClass="LBLBLACK" Width="221px">Location 
                                                        of the Unit</asp:Label>
                                                    </td>
                                                    <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                        :</td>
                                                    <td class="style26" 
                                                        style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lblUnitLocation" runat="server" CssClass="LBLBLACK" 
                                                            Width="121px"></asp:Label>
                                                    </td>
                                                    <td class="style26" 
                                                        style="text-align: center;" align="center">
                                                        4</td>
                                                    <td class="style45" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label569" runat="server" CssClass="LBLBLACK" Width="121px">Email 
                                                        :</asp:Label>
                                                    </td>
                                                    <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                        :</td>
                                                    <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="lblEmail" runat="server" CssClass="LBLBLACK" Width="121px"></asp:Label>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td class="style26" colspan="8" 
                                                        style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label543" runat="server" CssClass="LBLBLACK" Width="481px">Which 
                                                        Approval do you want to Renew?</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style48" colspan="8" 
                                                        style="padding: 5px; margin: 5px; text-align: left; vertical-align="top" valign="top" width="600px">
                                                        
                                                        
                                                    
                                                        <table class="style46" cellpadding="5" cellspacing="5" width="100%">
                                                           
                                                          
                                                            <tr id="BoilerFields1" runat="server" visible="true">
                                                                <td   id="Boilersupload13" runat="server" visible="true">
                                                                    <asp:CheckBox ID="ChkApproval" runat="server" AutoPostBack="True" 
                                                                       Text="Boilers" oncheckedchanged="ChkApproval_CheckedChanged" 
                                                                        style="font-weight: 700" />
                                                                </td>
                                                                <td   id="Td1" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td   id="Td2" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td width="170px" id="Td3" runat="server" >
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td4" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td5" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                            </tr>
                                                           
                                                          
                                                           
                                                            <tr id="BoilerFields" runat="server" visible="false">
                                                                <td   id="Boilersupload1" runat="server" visible="true">
                                                                    <asp:Label ID="Label574" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Font-Size="14px" Width="183px">Self Certification/ Existing CFE/Existing CFO</asp:Label>
                                                                </td>
                                                                <td width="270px" id="Boilersupload" runat="server" visible="true">
                                                                    <asp:FileUpload ID="FileUpload6" runat="server" class="form-control txtbox" 
                                                                        Height="28px" Width="180px" />
                                                                    <asp:HyperLink ID="lblFileName2" runat="server" CssClass="LBLBLACK" 
                                                                        Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                                    <br />
                                                                    <asp:Label ID="Label572" runat="server" visible="true"></asp:Label>
                                                                </td>
                                                                <td width="170px" id="boilersbtn" runat="server" >
                                                                    <asp:Button ID="BtnSave4" runat="server" CssClass="btn btn-xs btn-warning" 
                                                                        Height="28px" TabIndex="10" Text="Upload" Width="72px" 
                                                                        onclick="BtnSave4_Click" />
                                                                </td>
                                                                <td style="text-align: center; vertical-align: middle" id="Boilerfee1" runat="server" visible="true">
                                                                    <asp:Label ID="Label597" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Width="121px">Renewal 
 Period (Years)</asp:Label>
                                                                </td>
                                                                <td style="text-align: center; vertical-align: middle" id="Boilerfee" runat="server" visible="true">
                                                        <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                            <asp:ListItem  Value="3" >3</asp:ListItem>
                                                             <asp:ListItem Value="4">4</asp:ListItem>
                                                            <asp:ListItem  Value="5" >5</asp:ListItem>
                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                            <asp:ListItem  Value="8" >8</asp:ListItem>
                                                             <asp:ListItem Value="9">9</asp:ListItem>
                                                            <asp:ListItem  Value="10" >10</asp:ListItem>
                                                        </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                           
                                                          
                                                           
                                                            
                                                            <tr id="FireFields3" runat="server" visible="true">
                                                                <td   id="Fireupload13" runat="server" visible="true">
                                                                    <asp:CheckBox ID="ChkApproval0" runat="server" AutoPostBack="True" 
                                                                       Text="Fire" oncheckedchanged="ChkApproval0_CheckedChanged" 
                                                                        style="font-weight: 700" />
                                                                </td>
                                                                <td   id="Td6" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td   id="Td7" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td width="170px" id="Td8" runat="server" >
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td9" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td10" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr id="FireFields" runat="server" visible="false">
                                                                <td width="270px" id="Fireupload1" runat="server" visible="true">
                                                                    <asp:Label ID="Label610" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Font-Size="14px" Width="183px">Self Certification/ Existing CFE/Existing CFO</asp:Label>
                                                                </td>
                                                                <td width="270px" id="Fireupload" runat="server" visible="true">
                                                                    <asp:FileUpload ID="FileUpload7" runat="server" class="form-control txtbox" 
                                                                        Height="28px" Width="180px" />
                                                                    <asp:HyperLink ID="lblFileName3" runat="server" CssClass="LBLBLACK" 
                                                                        Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                                    <br />
                                                                    <asp:Label ID="Label576" runat="server" visible="true"></asp:Label>
                                                                </td>
                                                                <td width="170px" id="Firebtn" runat="server" visible="true">
                                                                    <asp:Button ID="BtnSave5" runat="server" CssClass="btn btn-xs btn-warning" 
                                                                        Height="28px" TabIndex="10" Text="Upload" Width="72px" 
                                                                        onclick="BtnSave5_Click" />
                                                                </td>
                                                                <td align="left" id="firefee1" runat="server" visible="true" >
                                                                    &nbsp;&nbsp;
                                                                    <asp:Label ID="Label598" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Width="121px">Renewal 
 Period (Years)</asp:Label>
                                                                </td>
                                                                <td align="left" id="firefee" runat="server" visible="true" >
                                                        <asp:DropDownList ID="ddlYear0" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                            <asp:ListItem  Value="3" >3</asp:ListItem>
                                                             <asp:ListItem Value="4">4</asp:ListItem>
                                                            <asp:ListItem  Value="5" >5</asp:ListItem>
                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                            <asp:ListItem  Value="8" >8</asp:ListItem>
                                                             <asp:ListItem Value="9">9</asp:ListItem>
                                                            <asp:ListItem  Value="10" >10</asp:ListItem>
                                                        </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="labourUpload1344" runat="server" visible="true">
                                                                <td width="270px" id="labourUpload13" runat="server" visible="true">
                                                                    <asp:CheckBox ID="ChkApproval1" runat="server" AutoPostBack="True" 
                                                                       Text="Labour" oncheckedchanged="ChkApproval1_CheckedChanged" 
                                                                        style="font-weight: 700" />
                                                                </td>
                                                                 <td   id="Td11" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td   id="Td12" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td width="170px" id="Td13" runat="server" >
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td14" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td15" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr id="labourFields" runat="server" visible="false">
                                                                <td width="270px" id="labourUpload1" runat="server" visible="true">
                                                                    <asp:Label ID="Label611" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Font-Size="14px" Width="183px">Self Certification/ Existing CFE/Existing CFO</asp:Label>
                                                                </td>
                                                                <td width="270px" id="labourUpload" runat="server" visible="true">
                                                                    <asp:FileUpload ID="FileUpload8" runat="server" class="form-control txtbox" 
                                                                        Height="28px" Width="180px" />
                                                                    <asp:HyperLink ID="lblFileName4" runat="server" CssClass="LBLBLACK" 
                                                                        Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                                    <br />
                                                                    <asp:Label ID="Label577" runat="server" visible="true"></asp:Label>
                                                                </td>
                                                                <td width="170px" id="labourbtn" runat="server" visible="true">
                                                                    <asp:Button ID="BtnSave6" runat="server" CssClass="btn btn-xs btn-warning" 
                                                                        Height="28px" TabIndex="10" Text="Upload" Width="72px" 
                                                                        onclick="BtnSave6_Click" />
                                                                </td>
                                                                <td style="text-align: center; vertical-align: middle" id="labourfee1" runat="server" visible="true">
                                                                    <asp:Label ID="Label599" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Width="121px">Renewal 
 Period (Years)</asp:Label>
                                                                </td>
                                                                <td style="text-align: center; vertical-align: middle" id="labourfee" runat="server" visible="true">
                                                        <asp:DropDownList ID="ddlYear1" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                            <asp:ListItem  Value="3" >3</asp:ListItem>
                                                             <asp:ListItem Value="4">4</asp:ListItem>
                                                            <asp:ListItem  Value="5" >5</asp:ListItem>
                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                            <asp:ListItem  Value="8" >8</asp:ListItem>
                                                             <asp:ListItem Value="9">9</asp:ListItem>
                                                            <asp:ListItem  Value="10" >10</asp:ListItem>
                                                        </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="labourFields1" runat="server" visible="false">
                                                                <td width="270px" id="labourUpload12" runat="server" visible="true">
                                                                    <asp:Label ID="Label596" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Width="121px">NO Of Empoyees</asp:Label>
                                                                </td>
                                                              <td width="270px" runat="server" visible="true">
                                                                    <asp:TextBox ID="txtEmployes" runat="server" class="form-control txtbox" 
                                                                        Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" 
                                                                        Width="179px"></asp:TextBox>
                                                                </td>
                                                              <td width="170px" id="Td26" runat="server" >
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td27" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td28" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr id="PCBFields4" runat="server" visible="true">
                                                                <td width="270px" id="PCBUpload14" runat="server" visible="true">
                                                                    <asp:CheckBox ID="ChkApproval2" runat="server" AutoPostBack="True" 
                                                                       Text="PCB(Auto Renewal)"  oncheckedchanged="ChkApproval2_CheckedChanged" 
                                                                        style="font-weight: 700" />
                                                                </td>
                                                              <td   id="Td16" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td   id="Td17" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td width="170px" id="Td18" runat="server" >
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td19" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td20" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr id="PCBFields" runat="server" visible="false">
                                                                <td width="270px" id="PCBUpload1" runat="server" visible="true">
                                                                    <asp:Label ID="Label603" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Font-Size="14px" Width="183px">Self Certification / Existing CFE/Existing CFO</asp:Label>
                                                                </td>
                                                                <td width="270px" id="PCBUpload" runat="server" visible="true">
                                                                    <asp:FileUpload ID="FileUpload9" runat="server" class="form-control txtbox" 
                                                                        Height="28px" Width="180px" />
                                                                    <asp:HyperLink ID="lblFileName5" runat="server" CssClass="LBLBLACK" 
                                                                        Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                                    <br />
                                                                    <asp:Label ID="Label578" runat="server" visible="true"></asp:Label>
                                                                </td>
                                                                <td width="170px" id="PCBBtn" runat="server" visible="true">
                                                                    <asp:Button ID="BtnSave7" runat="server" CssClass="btn btn-xs btn-warning" 
                                                                        Height="28px" TabIndex="10" Text="Upload" Width="72px" 
                                                                        onclick="BtnSave7_Click" />
                                                                </td>
                                                                <td style="text-align: center; vertical-align: middle" id="PCBfee1" runat="server" visible="true">
                                                                    <asp:Label ID="Label595" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Width="121px">Renewal 
 Period (Years)</asp:Label>
                                                                </td>
                                                                <td style="text-align: center; vertical-align: middle" id="PCBfee" runat="server" visible="true">
                                                        <asp:DropDownList ID="ddlYear2" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                            <asp:ListItem  Value="3" >3</asp:ListItem>
                                                             <asp:ListItem Value="4">4</asp:ListItem>
                                                            <asp:ListItem  Value="5" >5</asp:ListItem>
                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                            <asp:ListItem  Value="8" >8</asp:ListItem>
                                                             <asp:ListItem Value="9">9</asp:ListItem>
                                                            <asp:ListItem  Value="10" >10</asp:ListItem>
                                                        </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="PCBFields1" runat="server" visible="false">
                                                                <td width="270px" id="PCBUpload12" runat="server" visible="true">
                                                                    <asp:Label ID="Label592" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Font-Size="14px" Width="183px">Upload 
                                                       Bank Guarantee</asp:Label>
                                                                </td>
                                                              <td   runat="server" visible="true">
                                                                    <asp:FileUpload ID="FileUpload11" runat="server" class="form-control txtbox" 
                                                                        Height="28px" Width="180px" />
                                                                    <asp:HyperLink ID="lblFileName7" runat="server" CssClass="LBLBLACK" 
                                                                        Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                                    <br />
                                                                    <asp:Label ID="Label594" runat="server" visible="true"></asp:Label>
                                                                </td>
                                                              <td   runat="server" visible="true">
                                                                    <asp:Button ID="BtnSave10" runat="server" CssClass="btn btn-xs btn-warning" 
                                                                        Height="28px" TabIndex="10" Text="Upload" Width="72px" onclick="BtnSave10_Click" 
                                                                         />
                                                                </td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td29" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td30" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr id="FactoryFields4" runat="server" visible="true">
                                                                <td   runat="server" id="FactoryUpload14" visible="true">
                                                                    <asp:CheckBox ID="ChkApproval3" runat="server" AutoPostBack="True" 
                                                                         Text="Factories" oncheckedchanged="ChkApproval3_CheckedChanged" 
                                                                        style="font-weight: 700" Visible="False" />
                                                                </td>
                                                                 <td   id="Td21" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td   id="Td22" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td width="170px" id="Td23" runat="server" >
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td24" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                                <td style="text-align: center; vertical-align: middle" id="Td25" runat="server" visible="true">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr id="FactoryFields" runat="server" visible="false">
                                                                <td width="270px" runat="server" id="FactoryUpload1" visible="true">
                                                                    <asp:Label ID="Label612" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Font-Size="14px" Width="183px">Self Certification/ Existing CFE/Existing CFO</asp:Label>
                                                                </td>
                                                                <td width="270px" runat="server" id="FactoryUpload" visible="true">
                                                                    <asp:FileUpload ID="FileUpload10" runat="server" class="form-control txtbox" 
                                                                        Height="28px" Width="180px" />
                                                                    <asp:HyperLink ID="lblFileName6" runat="server" CssClass="LBLBLACK" 
                                                                        Target="_blank" Width="165px">[lblFileName]</asp:HyperLink>
                                                                    <br />
                                                                    <asp:Label ID="Label579" runat="server" visible="true"></asp:Label>
                                                                </td>
                                                                <td width="170px" id="Factorybtn"  runat="server" visible="true">
                                                                    <asp:Button ID="BtnSave8" runat="server" CssClass="btn btn-xs btn-warning" 
                                                                        Height="28px" TabIndex="10" Text="Upload" Width="72px" 
                                                                        onclick="BtnSave8_Click" />
                                                                </td>
                                                                <td style="text-align: center; vertical-align: middle" runat="server" id="FactoryFee1" visible="true">
                                                                    <asp:Label ID="Label600" runat="server" CssClass="LBLBLACK" Font-Bold="False" 
                                                                        Width="121px">Renewal 
 Period (Years)</asp:Label>
                                                                </td>
                                                                <td style="text-align: center; vertical-align: middle" runat="server" id="FactoryFee" visible="true">
                                                        <asp:DropDownList ID="ddlYear3" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                            <asp:ListItem  Value="3" >3</asp:ListItem>
                                                             <asp:ListItem Value="4">4</asp:ListItem>
                                                            <asp:ListItem  Value="5" >5</asp:ListItem>
                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                            <asp:ListItem  Value="8" >8</asp:ListItem>
                                                             <asp:ListItem Value="9">9</asp:ListItem>
                                                            <asp:ListItem  Value="10" >10</asp:ListItem>
                                                        </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                           
                                                            </table>
                                                    </td>
                                                </tr>
                                                </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;" 
                                            class="style47">
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnSave9" runat="server" CssClass="btn btn-primary" 
                                                                        Height="32px" onclick="BtnSave1_Click" 
                                                TabIndex="10" Text="Submit" 
                                                                        ValidationGroup="group" Width="90px" 
                                                Visible="False" />
                                                                </td>
                                    </tr>
                                   
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px" class="style47">
                                            <div ID="success0" runat="server" class="alert alert-success" >
                                                <a aria-label="close" class="close" data-dismiss="alert" 
                                                    href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label 
                                                    ID="lblmsg1" runat="server"></asp:Label>
                                            </div>
                                            <div ID="Failure0" runat="server" class="alert alert-danger" >
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>
                                                Warning!</strong>
                                                <asp:Label ID="lblmsg2" runat="server"></asp:Label>
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
                                <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                <asp:HiddenField ID="hdfFlagID1" runat="server" />
                                <asp:HiddenField ID="hdfFlagID2" runat="server" />
                                <asp:HiddenField ID="hdfFlagID3" runat="server" />
                                <asp:HiddenField ID="hdfFlagID4" runat="server" />
                                <br />
                            </div>
                            
                        </div>
                    </div>
                </div>

    </div>
           
    
</div>
</asp:Content>

