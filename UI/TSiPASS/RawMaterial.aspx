<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true"  CodeFile="RawMaterial.aspx.cs" Inherits="RawMaterial_" %>

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
    .style8
    {
        height: 22px;
        width: 369px;
    }
    .style9
    {
        width: 369px;
    }
    .style10
    {
        height: 27px;
        width: 369px;
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
        <table border="1" cellspacing="0" width="90%">
            
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    1
                </td>
                <td style="font-size: 11pt; font-family: Verdana; width: 300px; height: 22px;" align="left">
                    EM No / Udyog Aadhaar:
                    <asp:Label ID="Label2" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td style="font-size: 11pt; font-family: Verdana; " align="left" class="style8">
                    <asp:TextBox ID="txtEmNo" runat="server" Width="200px"  class="form-control txtbox" ></asp:TextBox>
                    <cc1:FilteredTextBoxExtender runat="server" ID="fttxtEmNo" 
                        FilterType="LowercaseLetters, UppercaseLetters, Numbers"
                        TargetControlID="txtEmNo">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    2
                </td>
                <td  align="left">
                    Type of Application:
                    <asp:Label ID="Label5" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style9">
                    <asp:RadioButtonList ID="rbtType" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Text="Fresh Allocation"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Renewal"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    3
                </td>
                <td  align="left">
                    Unit Name:
                    <asp:Label ID="Label6" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style9">
                    <asp:TextBox ID="txtUnitName" runat="server" Width="200px"  class="form-control txtbox" ></asp:TextBox>
                    <cc1:FilteredTextBoxExtender runat="server" ID="fttxtUnitName" 
                        ValidChars=" " FilterType="Numbers, LowercaseLetters, UppercaseLetters, Custom"
                        TargetControlID="txtUnitName">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    4
                </td>
                <td  align="left">
                    District:
                    <asp:Label ID="lblh1" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style9">
                    <asp:DropDownList ID="ddlDistrict" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text="--Select District--"></asp:ListItem>
                    </asp:DropDownList>
                    <%-- <asp:TextBox ID="txtmobile"  runat="server" AutoPostBack="True" OnTextChanged="txtmobile_TextChanged"  class="form-control txtbox" ></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    5
                </td>
                <td  align="left">
                    Mandal:
                    <asp:Label ID="Label4" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style9">
                    <asp:DropDownList ID="ddlMandal" runat="server" Width="200px">
                        <asp:ListItem Value="0" Text="--Select Mandal--"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    6
                </td>
                <td  align="left">
                    Address:
                    <asp:Label ID="Label7" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style9">
                    <%--<asp:Label ID="lblEmail" runat="server"></asp:Label>--%>
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="200px"  class="form-control txtbox" ></asp:TextBox>
                    <%--<cc1:FilteredTextBoxExtender runat="server" ID="fttxtAddress" ValidChars="" 
                        FilterType="LowercaseLetters, UppercaseLetters, Custom"
                        TargetControlID="txtAddress">
                    </cc1:FilteredTextBoxExtender>--%>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    7
                </td>
                <td  align="left">
                    Raw material for Allotment:
                    <asp:Label ID="Label1" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style9">
                    <asp:DropDownList ID="ddlAllotment" runat="server" Width="200px">
                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Coal"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Alcohol"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Ethanol"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Molasses"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px; height: 27px;">
                    8
                </td>
                <td style="font-size: 11pt; font-family: Verdana; width: 300px; height: 27px;" align="left">
                    Requirement:
                    <asp:Label ID="Label10" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td class="style10">
                    <asp:TextBox ID="txtRequirement" runat="server" Width="200px"  class="form-control txtbox" ></asp:TextBox>
                    <cc1:FilteredTextBoxExtender runat="server" ID="fttxtRequirement" ValidChars="." 
                        FilterType="Numbers, Custom"
                        TargetControlID="txtRequirement">
                    </cc1:FilteredTextBoxExtender>
                    <asp:DropDownList ID="ddlUOM" runat="server">
                        <asp:ListItem Selected="True">--SELECT--</asp:ListItem>
                        <asp:ListItem Value="1">Litres</asp:ListItem>
                        <asp:ListItem Value="2">Tons</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    9
                </td>
                <td  align="left">
                    Usage details:
                    <asp:Label ID="Label3" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left" class="style9">
                    <asp:TextBox ID="txtUsage" runat="server" Width="200px"  class="form-control txtbox" ></asp:TextBox>
                    <cc1:FilteredTextBoxExtender runat="server" ID="fttxtUsage"
                        FilterType="LowercaseLetters, UppercaseLetters, Numbers"
                        TargetControlID="txtUsage">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
        </table>
        <table width="90%" border="1" cellspacing="0">
            <tr align="left">
                <td align="left" colspan="3" style="font-size: 11pt; font-family: Verdana; width: 300px;
                    height: 22px;">
                    <strong>Attachments</strong>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px; height: 26px;">
                    1
                </td>
                <td style="font-size: 11pt; font-family: Verdana; width: 300px; height: 26px;" align="left">
                    Existing Allotment Order:
                </td>
                <td style="font-size: 11pt; font-family: Verdana; width: 300px; height: 26px;" align="left">
                    <asp:FileUpload ID="fileExisting" runat="server" Width="150px" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    2
                </td>
                <td  align="left">
                    Valid CFO:
                </td>
                <td  align="left">
                    <asp:FileUpload ID="fileCFO" runat="server" Width="150px" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    3
                </td>
                <td  align="left">
                    Boiler Details:
                </td>
                <td  align="left">
                    <asp:FileUpload ID="fileBoiler" runat="server" Width="150px" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    4
                </td>
                <td  align="left">
                    Proof of production till previous month:
                    
                </td>
                <td  align="left">
                    <asp:FileUpload ID="fileproduction" runat="server" Width="150px" />
                    
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    5
                </td>
                <td  align="left">
                    VAT:
                    <asp:Label ID="Label8" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left">
                    <asp:FileUpload ID="fileVAT" runat="server" Width="150px" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    6
                </td>
                <td  align="left">
                    RG1 Register:
                </td>
                <td  align="left">
                    <asp:FileUpload ID="fileRG1" runat="server" Width="150px" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 24px">
                    7
                </td>
                <td  align="left">
                    Process Description – Flow Chart:
                    <asp:Label ID="Label9" Text="*" ForeColor="red" runat="server"></asp:Label>
                </td>
                <td  align="left">
                    <asp:FileUpload ID="fileFlowChart" runat="server" Width="150px" />
                </td>
            </tr>
            <tr align="center">
                <td align="center" colspan="3" style="height: 28px; text-align: center;">
                    &nbsp;</td>
            </tr>
            <tr align="center">
                <td align="center" colspan="3" style="height: 28px; text-align: center;">
                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn-primary" 
                        OnClick="Button1_Click" ForeColor="White" />
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

