<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"AutoEventWireup="true" CodeFile="GuestInsturction.aspx.cs" Inherits="TSTBDCReg1" %>

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
    .style21
    {
        height: 35px;
    }
    .style26
    {
        height: 21px;
    }
    .style27
    {
        height: 21px;
    }
    .style34
    {
        height: 21px;
        width: 261px;
    }
    .style46
    {
        height: 44px;
    }
    .style47
    {
        height: 44px;
        width: 261px;
    }
    .style48
    {
        width: 10px;
        height: 44px;
    }
    .style49
    {
        width: 206px;
        height: 44px;
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
                                <a href="#">Loan Application to Bank</a></li>
                        </ol>
     </div>
    
<div align="left">
<div class="row" align="left">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Loan Application to Bank</h3>
                            </div>
                          
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                    
                                    <tr>
                                        <td align="center" class="style21" style="padding: 5px; margin: 2px">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td class="style26" colspan="5" 
                                                        style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label558" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                            Width="199px">Loan Application to Bank</asp:Label>
                                                    </td>
                                                    <td class="style27" colspan="4" style="padding: 5px; margin: 5px; ">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style26" style="padding: 5px; margin: 5px; text-align: left;">
                                                        1</td>
                                                    <td class="style34" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label537" runat="server" CssClass="LBLBLACK" Width="199px">Name 
                                                        of Applicant</asp:Label>
                                                    </td>
                                                    <td class="style26" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style26" style="padding: 5px; margin: 5px; text-align: left;" 
                                                        colspan="6">
                                                        <asp:TextBox ID="txtindname" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" 
                                                            Width="95%"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="txtindname" ErrorMessage="Please enter Industry name" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        2</td>
                                                    <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label564" runat="server" CssClass="LBLBLACK" Height="18px" 
                                                            Width="111px">Mobile Number</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtMob" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="10"  onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" 
                                                            Width="170px"></asp:TextBox>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:RequiredFieldValidator ID="reqfvmob" runat="server" 
                                                            ControlToValidate="txtMob" ErrorMessage="Please Enter Mobile Number" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" 
                                                        valign="middle">
                                                        5</td>
                                                    <td class="style49" style="padding: 5px; margin: 5px; text-align: left;" 
                                                        width="180px">
                                                        <asp:Label ID="Label565" runat="server" CssClass="LBLBLACK" Width="100px">District Name:</asp:Label>
                                                        </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;" 
                                                        align="center">
                                                        <asp:DropDownList ID="ddldist" runat="server" class="form-control txtbox" 
                                                            Height="33px" TabIndex="1" Width="170px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddldist_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                     <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="ReqfvDist" runat="server" 
                                                            ControlToValidate="ddldist" ErrorMessage="Please Select District" 
                                                            ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        3</td>
                                                    <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label556" runat="server" CssClass="LBLBLACK" Width="148px">E-Mail:</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" 
                                                            Width="170px"></asp:TextBox>
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
                                                        6</td>
                                                    <td class="style49" style="padding: 5px; margin: 5px; text-align: left;" 
                                                        width="180px">
                                                        <asp:Label ID="Label568" runat="server" CssClass="LBLBLACK" Width="100px">Mandal 
                                                        Name</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="170px" TabIndex="1">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="ReqfvDist0" runat="server" 
                                                            ControlToValidate="ddlMandal" ErrorMessage="Please Select Mandal" 
                                                            ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        4</td>
                                                    <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label567" runat="server" CssClass="LBLBLACK" Width="148px">Line 
                                                        of Activity</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                        <asp:DropDownList ID="ddlintLineofActivity" runat="server" 
                                                            class="form-control txtbox" Height="33px" 
                                                            Width="95%">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="ReqfvDist2" runat="server" 
                                                            ControlToValidate="ddlintLineofActivity" ErrorMessage="Please Select line of Activity" 
                                                            ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        7</td>
                                                    <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label569" runat="server" CssClass="LBLBLACK" Width="148px">Bank 
                                                        Name</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtBankName" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" 
                                                            Width="170px"></asp:TextBox>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:RequiredFieldValidator ID="reqfvmob0" runat="server" 
                                                            ControlToValidate="txtBankName" ErrorMessage="Please Enter Bank Name" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                    <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" 
                                                        valign="middle">
                                                        10</td>
                                                    <td class="style49" style="padding: 5px; margin: 5px; text-align: left;" 
                                                        width="180px">
                                                        <asp:Label ID="Label571" runat="server" CssClass="LBLBLACK" Width="180px">Amount 
                                                        of Loan Required (In Rupees)</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtAmount" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="10"  onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" 
                                                            Width="170px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    <asp:RequiredFieldValidator ID="reqfvmob2" runat="server" 
                                                            ControlToValidate="txtAmount" ErrorMessage="Please Enter Amount" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        8</td>
                                                    <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label573" runat="server" CssClass="LBLBLACK" Width="148px">Bank 
              Branch                                          Name</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtBankBranchName" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" 
                                                            Width="170px"></asp:TextBox>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:RequiredFieldValidator ID="reqfvmob4" runat="server" 
                                                            ControlToValidate="txtBankBranchName" ErrorMessage="Please Enter Bank Branch Name" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                    <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" 
                                                        valign="middle">
                                                        11</td>
                                                    <td class="style49" style="padding: 5px; margin: 5px; text-align: left;" 
                                                        width="180px">
                                                        <asp:Label ID="Label572" runat="server" CssClass="LBLBLACK" Width="100px">Status</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="170px" TabIndex="1" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged"
                                                            >
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>Submitted</asp:ListItem>
                                                            <asp:ListItem>Under Process</asp:ListItem>
                                                            <asp:ListItem>Sanctioned</asp:ListItem>
                                                            <asp:ListItem>Rejected</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="ReqfvDist1" runat="server" 
                                                            ControlToValidate="ddlStatus" ErrorMessage="Please Select status" 
                                                            ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        9&nbsp;</td>
                                                    <td class="style47" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label570" runat="server" CssClass="LBLBLACK" Width="160px">Loan Application Date(dd-MM-yyyy)</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtRegDate" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="13"  TabIndex="1" 
                                                            ValidationGroup="group" Width="170px"></asp:TextBox>
                                                            
                                                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" 
                                                            PopupButtonID="txtRegDate" TargetControlID="txtRegDate">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:RequiredFieldValidator ID="reqfvmob1" runat="server" 
                                                            ControlToValidate="txtRegDate" ErrorMessage="Please Enter Loan Application Date" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                    <td class="style48" style="padding: 5px; margin: 5px; vertical-align: middle;" 
                                                        valign="middle">
                                                        &nbsp;</td>
                                                    <td class="style49" style="padding: 5px; margin: 5px; text-align: left;" 
                                                        width="180px">
                                                        <asp:Label ID="Label574" runat="server" CssClass="LBLBLACK" Width="160px">Sanctioned / Rejected Date (dd-MM-yyyy)</asp:Label>
                                                    </td>
                                                    <td class="style46" style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td class="style46" style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="TxtSanctionedDate" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="13"  TabIndex="1" 
                                                            ValidationGroup="group" Width="170px"></asp:TextBox>
                                                            
                                                             <cc1:CalendarExtender ID="TxtSanctionedDate_CalendarExtender" 
                                                            runat="server" Format="dd-MM-yyyy" 
                                                            PopupButtonID="TxtSanctionedDate" TargetControlID="TxtSanctionedDate">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td>
                                                    <asp:RequiredFieldValidator ID="reqfvmob3" runat="server" 
                                                            ControlToValidate="TxtSanctionedDate" ErrorMessage="Please Enter Sactioned / Rejected Date" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;&nbsp;<asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
                                                Height="32px" TabIndex="10" Text="Submit" ValidationGroup="group" 
                                                Width="90px" onclick="BtnSave_Click" />
                                            &nbsp;
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10" 
                                                Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                    <td align="center" colspan="2" style="padding: 5px; margin: 5px">
                                        <div ID="success" runat="server" class="alert alert-success" >
                                            <a aria-label="close" class="close" data-dismiss="alert" 
                                                href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label 
                                                ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div ID="Failure" runat="server" class="alert alert-danger" >
                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>
                                            Warning!</strong>
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

