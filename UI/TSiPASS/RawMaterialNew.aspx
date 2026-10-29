<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true"  CodeFile="RawMaterialNew.aspx.cs" Inherits="RawMaterial_" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
    .style11
    {
        width: 43px;
        height: 39px;
    }
    .style14
    {
        height: 27px;
        width: 15%;
    }
    .style17
    {
        width: 221px;
        height: 34px;
    }
    .style18
    {
        width: 33px;
        height: 34px;
    }
    .style19
    {
        width: 308px;
        height: 34px;
    }
    .style20
    {
        height: 1px;
    }
    .style21
    {
        height: 6px;
    }
    .style28
    {
        width: 33px;
        height: 33px;
    }
    .style30
    {
        width: 308px;
        height: 33px;
    }
    .style32
    {
        height: 39px;
        width: 264px;
    }
    .style33
    {
        width: 33px;
    }
    .style36
    {
        width: 43px;
        height: 33px;
    }
    .style37
    {
        width: 519px;
        height: 22px;
    }
    .style38
    {
        width: 147px;
        height: 27px;
    }
    .style42
    {
        width: 14%;
    }
    .style43
    {
        width: 2%;
        height: 27px;
    }
    .style44
    {
        width: 10px;
        height: 27px;
    }
    .style45
    {
        width: 14%;
        height: 27px;
    }
    .style46
    {
        height: 27px;
        width: 28%;
    }
    .style51
    {
        width: 2%;
        height: 32px;
    }
    .style52
    {
        width: 15%;
        height: 32px;
    }
    .style53
    {
        width: 147px;
        height: 32px;
    }
    .style54
    {
        height: 32px;
        width: 10px;
    }
    .style55
    {
        width: 14%;
        height: 32px;
    }
    .style57
    {
        width: 264px;
        height: 33px;
    }
    .style58
    {
        width: 43px;
    }
    .style59
    {
        height: 33px;
        width: 221px;
    }
    .style61
    {
        width: 221px;
    }
    .style62
    {
        width: 308px;
    }
    .style63
    {
        width: 33px;
        height: 20px;
    }
    .style64
    {
        width: 221px;
        height: 20px;
    }
    .style65
    {
        width: 308px;
        height: 20px;
    }
    .style66
    {
        width: 43px;
        height: 20px;
    }
    .style67
    {
        height: 20px;
        width: 264px;
    }
    .style69
    {
        height: 20px;
    }
    .style70
    {
        height: 33px;
    }
    .style71
    {
        width: 33px;
        height: 8px;
    }
    .style72
    {
        height: 8px;
        width: 221px;
    }
    .style73
    {
        width: 308px;
        height: 8px;
    }
    .style74
    {
        height: 8px;
    }
    .style75
    {
        width: 43px;
        height: 8px;
    }
    .style76
    {
        width: 264px;
        height: 8px;
    }
    .style77
    {
        width: 33px;
        height: 23px;
    }
    .style78
    {
        width: 221px;
        height: 23px;
    }
    .style79
    {
        width: 308px;
        height: 23px;
    }
    .style81
    {
        width: 43px;
        height: 23px;
    }
    .style82
    {
        height: 23px;
    }
    .style83
    {
        height: 32px;
        width: 28%;
    }
    .style84
    {
        width: 2%;
    }
    .style85
    {
        width: 15%;
    }
    .style87
    {
        width: 28%;
    }
    .style88
    {
        width: 147px;
    }
    .style89
    {
        width: 10px;
    }
    .style90
    {
        width: 5%;
        height: 27px;
    }
    .style91
    {
        width: 5%;
        height: 32px;
    }
</style>

<script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

       window.open("frmViewAttachmentDetails.aspx?intApplicationid=" + document.getElementById("ctl00_ContentPlaceHolder1_hdfFlagID0").value, "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

    return false;
    }
    </script>
    <%-----------------11------------------------------------------------------%>   <%----------------12-------------------------------------------------------%>
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
                                <i class="fa fa-edit"></i> <a href="#">Raw Material Allotment Application</a>
                            </li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Raw Material Allotment Application</h3>
                            </div>
                           
                            <div class="panel-body" style="text-align: center" >
                               <table width="100%" style="width: 100%"><tr><td align="center" style="text-align: center; padding-left: 85px;" >
        <table border="0" cellspacing="0" width="90%">
            
            <tr>
                <td align="center" valign="top" class="style18">
                    1
                </td>
                <td style="font-size: 11pt; font-family: Verdana; " align="left" 
                    class="style17">
                    EM No / Udyog Aadhaar:
                    <asp:Label ID="Label2" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td style="font-size: 11pt; font-family: Verdana; " align="left" 
                    class="style19">
                <asp:TextBox ID="txtEmNo" runat="server" class="form-control txtbox" Height="28px" 
                        Width="180px" ontextchanged="txtEmNo_TextChanged"></asp:TextBox>
                   <cc1:FilteredTextBoxExtender runat="server" ID="fttxtEmNo" 
                        FilterType="LowercaseLetters, UppercaseLetters, Numbers"
                        TargetControlID="txtEmNo">
                    </cc1:FilteredTextBoxExtender>
                </td>
                <td></td>
                <td align="center" valign="top" class="style11">
                    6
                </td>
                <td  align="left" class="style32">
                    Address:
                    <asp:Label ID="Label7" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtAddress" runat="server" class="form-control txtbox" Height="28px" ValidationGroup="group" Width="180px" 
                         TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td align="center" valign="top" class="style63">
                </td>
                <td style="font-size: 11pt; font-family: Verdana; " align="left" 
                    class="style64">
                </td>
                <td style="font-size: 11pt; font-family: Verdana; " align="left" 
                    class="style65">
                </td>
                <td class="style69"></td>
                <td align="center" valign="top" class="style66">
                </td>
                <td  align="left" class="style67">
                </td>
                <td class="style69">
                </td>
            </tr>
            
            <tr>
                <td align="center" valign="top" class="style28">
                    2
                </td>
                <td  align="left" class="style59">
                    Type of Application:
                    <asp:Label ID="Label5" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style30">
                 <asp:RadioButtonList ID="rbtType" runat="server" RepeatDirection="Horizontal">
                 <asp:ListItem Value="1" Text="Fresh Allocation"></asp:ListItem>
                 <asp:ListItem Value="2" Text="Renewal"></asp:ListItem>
                 </asp:RadioButtonList>
                </td>
                <td class="style70"></td>
                <td align="center" valign="top" class="style36">
                    7
                </td>
                <td  align="left" class="style70">
                    Raw material for Allotment:
                    <asp:Label ID="Label1" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td class="style70">
                       <asp:DropDownList ID="ddlAllotment" runat="server" class="form-control txtbox" Height="33px"
                        Width="180px" AutoPostBack="True">
                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Coal"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Alcohol"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Ethanol"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Molasses"></asp:ListItem>
                        </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td align="center" valign="top" class="style63">
                </td>
                <td  align="left" class="style64">
                </td>
                <td  align="left" class="style65">
                </td>
                <td class="style69"></td>
                <td align="center" valign="top" class="style66">
                </td>
                <td  align="left" class="style69">
                </td>
                <td class="style69">
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" class="style28">
                    3
                </td>
                <td  align="left" class="style59">
                    Unit Name:
                    <asp:Label ID="Label6" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style30">
                   <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox" Height="28px" ValidationGroup="group" Width="180px"></asp:TextBox>
                  <%--  <cc1:FilteredTextBoxExtender runat="server" ID="fttxtUnitName" 
                        ValidChars=" " FilterType="Numbers, LowercaseLetters, UppercaseLetters, Custom"
                        TargetControlID="txtUnitName">
                    </cc1:FilteredTextBoxExtender>--%>
                </td>
                <td class="style70"></td>
                <td align="center" valign="top" class="style36">
                    8
                </td>
                <td style="font-size: 11pt; font-family: Verdana; " align="left" 
                    class="style57">
                    Requirement:
                    <asp:Label ID="Label10" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td class="style70">
                 <asp:TextBox ID="txtRequirement" runat="server" class="form-control txtbox"
                                                                    Height="28px" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                <asp:DropDownList ID="ddlUOM" runat="server" 
                  class="form-control txtbox" Height="33px"  Width="180px" 
                        AutoPostBack="True" >
                         <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Coal"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Alcohol"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Ethanol"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Molasses"></asp:ListItem>
                        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" class="style71">
                </td>
                <td  align="left" class="style72">
                </td>
                <td  align="left" class="style73">
                </td>
                <td class="style74"></td>
                <td align="center" valign="top" class="style75">
                </td>
                <td style="font-size: 11pt; font-family: Verdana; " align="left" 
                    class="style76">
                </td>
                <td class="style74">
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" class="style33">
                    4
                </td>
                <td  align="left" class="style61">
                    District:
                    <asp:Label ID="lblh1" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style62">
                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control txtbox"
                Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                   <asp:ListItem>--District--</asp:ListItem>
                     </asp:DropDownList>
                    <%-- <asp:TextBox ID="txtmobile"  runat="server" AutoPostBack="True" OnTextChanged="txtmobile_TextChanged"  class="form-control txtbox" ></asp:TextBox>--%>
                </td>
                <td></td>
                <td align="center" valign="top" class="style58">
                    9
                </td>
                <td  align="left">
                    Usage details:
                    <asp:Label ID="Label3" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtUsage" runat="server" class="form-control txtbox" ValidationGroup="group"
                     Width="180px" ></asp:TextBox>
                                                                    
                    <cc1:FilteredTextBoxExtender runat="server" ID="fttxtUsage"
                        FilterType="LowercaseLetters, UppercaseLetters, Numbers"
                        TargetControlID="txtUsage">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" class="style77">
                </td>
                <td  align="left" class="style78">
                </td>
                <td  align="left" class="style79">
                </td>
                <td class="style82"></td>
                <td align="center" valign="top" class="style81">
                </td>
                <td  align="left" class="style82">
                </td>
                <td class="style82">
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" class="style33">
                    5
                </td>
                <td  align="left" class="style61">
                    Mandal:
                    <asp:Label ID="Label4" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style62">
                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox"
                 Height="33px" Width="180px" AutoPostBack="True">
                 <asp:ListItem>--Mandal--</asp:ListItem>
                 </asp:DropDownList>
                </td>
            </tr>
            </table>
        <table width="90%" border="0" cellspacing="0">
            <tr align="left">
                <td align="left" colspan="3" style="font-size: 11pt; font-family: Verdana; " 
                    class="style37">
                    <strong>
                    Attachments</strong>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" class="style43">
                    1
                </td>
                <td style="font-size: 11pt; font-family: Verdana; " align="left" 
                    class="style14">
                    Existing Allotment Order:
                    <asp:Label ID="Label11" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td style="font-size: 11pt; font-family: Verdana; " align="left" 
                    class="style38">
                <asp:FileUpload ID="fileExisting" runat="server" class="form-control txtbox" 
                                                             Height="28px" Width="300px"  />
                                                             
                </td>
                <td class="style44"></td>
                <td align="center" valign="top" class="style90">
                    5
                </td>
                <td  align="left" class="style45">
                    VAT:
                    <asp:Label ID="Label8" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td class="style46">
                 <asp:FileUpload ID="fileVAT" runat="server" class="form-control txtbox" 
                                                             Height="28px"  />
                                                             
                </td>
            </tr>
            <tr><td class="style21"><br /></td></tr>
            <tr>
                <td align="center" valign="top" class="style51">
                    2
                </td>
                <td  align="left" class="style52">
                    Valid CFO:
                    <asp:Label ID="Label12" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style53">
              <asp:FileUpload ID="fileCFO"  runat="server" class="form-control txtbox" 
                                                             Height="28px" Width="300px"  />
                                                             
                </td>
                <td class="style54"></td>
                <td align="center" valign="top" class="style91">
                    6
                </td>
                <td  align="left" class="style55">
                    RG1 Register:
                    <asp:Label ID="Label13" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td class="style83">
                <asp:FileUpload ID="fileRG1"  runat="server" class="form-control txtbox" 
                                                             Height="28px"  />
                                                             
                </td>
            </tr>
            <tr><td><br /></td></tr>
            <tr>
                <td align="center" valign="top" class="style84">
                    3
                </td>
                <td  align="left" class="style85">
                    Boiler Details:
                    <asp:Label ID="Label14" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style88">
                <asp:FileUpload ID="fileBoiler"  runat="server" class="form-control txtbox" 
                                                             Height="28px"  />
                                                             
                </td>
                <td class="style89"></td>
                <td>
                    7</td>
                <td  align="left" class="style42">
                    Process Description – Flow Chart:
                    <asp:Label ID="Label9" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td class="style87">
                <asp:FileUpload ID="fileFlowChart"  runat="server" class="form-control txtbox" 
                                                             Height="28px"  />
                                                             
                </td>
            </tr>
             <tr><td class="style20"><br /></td></tr>
            <tr>
                <td align="center" valign="top" class="style84">
                    4
                </td>
                <td  align="left" class="style85">
                    Proof of production till previous month:
                    <asp:Label ID="Label15" Text="*" ForeColor="red" runat="server"></asp:Label>
                    
                </td>
                <td  align="left" class="style88">
                <asp:FileUpload ID="fileproduction"  runat="server" class="form-control txtbox" 
                                                             Height="28px"  />
                                                             
                </td>
            </tr>
            <tr align="center">
                <td align="center" colspan="7" style="height: 28px; text-align: center;">
                    &nbsp;</td>
            </tr>
            <tr align="center">
                <td align="center" colspan="7" style="height: 28px; text-align: center;">
                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                          Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Submit" 
                         ValidationGroup="group" Width="90px" />
                </td>
            </tr>
            </table>
        </td></tr></table>
        </div>
       
        </div>
   </div>
   </div>
   </div>
   
    </asp:Content>

