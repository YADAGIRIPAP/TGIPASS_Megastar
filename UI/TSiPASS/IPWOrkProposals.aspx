<%@ Page Title=":: TSiPASS : Work Proposals " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"AutoEventWireup="true" CodeFile="IPWOrkProposals.aspx.cs" Inherits="CheckPOITD" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

function OpenPopup() 
 
   {

       window.open("Lookups/WorkProposalLookup.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

    return false;
    }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
<ContentTemplate>
<div align="left">
    <ol class="breadcrumb">You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i>  <a href="Home.aspx">Dashboard</a>
                            </li>
                            <li class="">
                                <i class="fa fa-fw fa-edit"></i> 
                                <asp:Label ID="lblSitemap" runat="server" Text=""></asp:Label>
                            </li>
                            <li class="active">
                                <i class="fa fa-edit"></i> <a href="#">
                                    <asp:Label ID="lblSite2" runat="server" Text=""></asp:Label> </a>
                            </li>
                        </ol>
     </div>
    
<div align="center">
<div class="row" align="center">
                    <div class="col-lg-11" >
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <asp:Label ID="lblheading" runat="server" Text="Label"></asp:Label>
                                </h3>
                            </div>
                            <div class="panel-body" >
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 97%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                            <asp:Label ID="Label347" runat="server" CssClass="LBLBLACK" Width="165px">Search</asp:Label>
                                            <asp:Button ID="btnOrgLookup0" runat="server" CssClass="btn btn-primary" Height="32px" 
                                                onclick="btnOrgLookup_Click" Text="Look Up" CausesValidation="False" 
                                                Font-Size="12px" Style="position: static" ToolTip="Rate Lookup" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                            &nbsp;</td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                              <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label298" runat="server" CssClass="LBLBLACK" Width="128px">IP</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlIP" runat="server" AutoPostBack="True" 
                                                            class="form-control txtbox" Height="33px" 
                                                            onselectedindexchanged="ddlIP_SelectedIndexChanged" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label380" runat="server" CssClass="LBLBLACK" Width="128px">Project Name</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="True" 
                                                            class="form-control txtbox" Height="33px" 
                                                            onselectedindexchanged="ddlProject_SelectedIndexChanged" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr id="trworkcode" runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label410" runat="server" CssClass="LBLBLACK" Width="128px">Work Code</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblworkcode" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 27px">
                                            <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label383" runat="server" CssClass="LBLBLACK" Width="136px">Target Beneficiaries</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblTargetBenefeciaries" runat="server" CssClass="LBLBLACK" 
                                                            Width="128px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="144px">Project Cost</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="lblCost" runat="server" CssClass="LBLBLACK" Width="128px"></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label432" runat="server" CssClass="LBLBLACK" Width="144px">Type of Meeting</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlMeeting" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="IP">Implementing Partner</asp:ListItem>
                                                            <asp:ListItem Value="TST">Technical Support Team</asp:ListItem>
                                                            <asp:ListItem Value="PDC">PDC/BDC</asp:ListItem>
                                                            <asp:ListItem Value="BDC">BDC/QCDC</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                                                            ControlToValidate="ddlMeeting" ErrorMessage="Please Select Type of Meeting" 
                                                            InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label350" runat="server" CssClass="LBLBLACK" Width="144px">Meeting Date</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtStartDate" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="12" onkeypress="Dates()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" 
                                                            PopupButtonID="txtStartDate" TargetControlID="txtStartDate">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                            ControlToValidate="txtStartDate" ErrorMessage="Please Enter Meeting Date" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="233px">Members Involved</asp:Label>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table border="1" cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td align="left" style="padding: 5px; margin: 5px; width: 218px;">
                                                        <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                            Width="128px">TST Members</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding: 5px; margin: 5px; width: 218px;">
                                                        <asp:CheckBoxList ID="chkTst" runat="server" CellPadding="3" CellSpacing="5" 
                                                            CssClass="LBLBLACK" Font-Bold="False" RepeatColumns="2" 
                                                            RepeatDirection="Horizontal">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table border="1" cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td align="left" style="padding: 5px; margin: 5px; width: 218px;">
                                                        <asp:Label ID="Label395" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                            Width="260px">County / Municipality Members</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding: 5px; margin: 5px; width: 218px;">
                                                        <asp:CheckBoxList ID="ChkCA" runat="server" CellPadding="3" CellSpacing="5" 
                                                            RepeatColumns="2" RepeatDirection="Horizontal">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table border="1" cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td align="left" style="padding: 5px; margin: 5px; width: 218px;">
                                                        <asp:Label ID="Label392" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                            Width="319px">Payam / Block Development Committee</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding: 5px; margin: 5px; width: 218px;">
                                                        <asp:CheckBoxList ID="ChkPDC" runat="server" CellPadding="3" CellSpacing="5" 
                                                            RepeatColumns="2" RepeatDirection="Horizontal">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table border="1" cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td align="left" style="padding: 5px; margin: 5px; width: 218px;">
                                                        <asp:Label ID="Label393" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                            Width="348px">Boma / Quarter Council Development Committee</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding: 5px; margin: 5px; width: 218px;">
                                                        <asp:CheckBoxList ID="ChkBDC" runat="server" CellPadding="3" CellSpacing="5" 
                                                            RepeatColumns="2" RepeatDirection="Horizontal">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                            <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="233px">Work Proposed Location</asp:Label>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="144px">State Name</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 224px;">
                                                        <asp:DropDownList ID="ddlState" runat="server" class="form-control txtbox" 
                                                            Height="33px" Width="180px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlState_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                            ControlToValidate="ddlState" ErrorMessage="Please Select State" 
                                                            InitialValue="--Select--" SetFocusOnError="True" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label300" runat="server" CssClass="LBLBLACK" Width="124px">County / Municipality Name</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 224px;">
                                                        <asp:DropDownList ID="ddlCounties" runat="server" class="form-control txtbox" 
                                                            Height="33px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlCounties_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                            ControlToValidate="ddlCounties" ErrorMessage="Please Select County" 
                                                            InitialValue="--Select--" SetFocusOnError="True" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label353" runat="server" CssClass="LBLBLACK" Width="124px">Payam / Block Name</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlPayam" runat="server" class="form-control txtbox" 
                                                            Height="28px" Width="180px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlPayam_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                            ControlToValidate="ddlPayam" ErrorMessage="Please Select Payam" 
                                                            InitialValue="--Select--" SetFocusOnError="True" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label400" runat="server" CssClass="LBLBLACK" Width="144px">Boma / Quarter Council Name</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlBoma" runat="server" class="form-control txtbox" 
                                                            Height="28px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                            ControlToValidate="ddlBoma" ErrorMessage="Please Select Boma" 
                                                            InitialValue="--Select--" SetFocusOnError="True" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                            <asp:Label ID="Label379" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                Width="233px">Proposed Public work Activities</asp:Label>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="128px">Work Name</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtWorkName" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="124px">Type of Work</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlAreaofWork" runat="server" class="form-control txtbox" onselectedindexchanged="ddlAreasofWork_SelectedIndexChanged"
                                                            Height="28px" AutoPostBack="True" Width="180px" >
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label403" runat="server" CssClass="LBLBLACK" Width="124px"> Work Activity</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:DropDownList ID="ddlWorkActivity" runat="server" class="form-control txtbox" 
                                                            Height="28px" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK" Width="144px">Estimated 
                                                        Manpower</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtManpower" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="137px">Estimated Man Days </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtEstDays" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label404" runat="server" CssClass="LBLBLACK" Width="137px">Type of equipment required </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtEstEquipmntReq" runat="server" class="form-control txtbox" 
                                                            Height="40px" MaxLength="40" TabIndex="1" TextMode="MultiLine" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="137px">Estimated quantity of equipment required </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtEstquantity1" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="137px">Type of materials required </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtEstiMaterial" runat="server" class="form-control txtbox" 
                                                            Height="40px" MaxLength="40" TabIndex="1" TextMode="MultiLine" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label405" runat="server" CssClass="LBLBLACK" Width="137px">Estimated quantity of materials required </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtEstquantity2" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" TabIndex="1" onkeypress="NumberOnly()" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label406" runat="server" CssClass="LBLBLACK" Width="137px">Estimated Skill Labour Required </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtSkillLabour" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label407" runat="server" CssClass="LBLBLACK" Width="137px">Estimated Work Start Date </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtWorkStartDate" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" onkeypress="NumberhyphenOnly()"   TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
Format="dd-MM-yyyy" PopupButtonID="txtWorkStartDate" 
TargetControlID="txtWorkStartDate">
</cc1:CalendarExtender>
                                                            
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label408" runat="server" CssClass="LBLBLACK" Width="137px">Estimated Work End Date </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtEndDate" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40"  TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
Format="dd-MM-yyyy" PopupButtonID="txtEndDate" 
TargetControlID="txtEndDate">
</cc1:CalendarExtender>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label409" runat="server" CssClass="LBLBLACK" Width="137px">Estimated Cost </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtEstCost" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                                            ControlToValidate="txtWorkName" ErrorMessage="Please Enter Work Name" 
                                                            SetFocusOnError="True" ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-xs btn-warning" 
                                                            Height="28px" TabIndex="10" Text="Add New" ValidationGroup="child" 
                                                            Width="72px" onclick="BtnSave2_Click" />
                                                        &nbsp;<asp:Button ID="BtnClear0" runat="server" CausesValidation="False" 
                                                            CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel" 
                                                            ToolTip="To Clear  the Screen" Width="73px" onclick="BtnClear0_Click1" />
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                            <asp:GridView ID="gvpractical0" runat="server" AutoGenerateColumns="False" 
                                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
                                                CssClass="GRD" 
                                                DataKeyNames="intWorkid,intWorkActivityId,intAreaofWork,intWorkActivity,WorkName,EstManPower,EstDays,EstEquipmnts,EstMaterial,EstSkilLabour,EstWorkStartDate,EstWorkEndDate,EstCost,EquipmntQuantity,MaterialQuantity" 
                                                Font-Names="Verdana" Font-Size="12px" 
                                                ForeColor="#333333" GridLines="None" OnRowDeleting="gvpractical0_RowDeleting" 
                                                Width="100%" onselectedindexchanged="gvpractical0_SelectedIndexChanged">
                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#FFFFFF" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Select" ShowSelectButton="True" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                    <asp:BoundField DataField="WorkName" HeaderText="Work Name" />
                                                    <asp:BoundField DataField="AreaofWork" HeaderText="Area of Work" />
                                                    <asp:BoundField DataField="WorkActivity" HeaderText="Work Activity" />
                                                    <asp:BoundField DataField="EstManPower" HeaderText="Estimated Manpower" />
                                                    <asp:BoundField DataField="EstDays" HeaderText="Estimated Days" 
                                                        Visible="False" />
                                                    <asp:BoundField DataField="EstEquipmnts" 
                                                        HeaderText="Type of Equipment required" />
                                                        <asp:BoundField DataField="EquipmntQuantity" 
                                                        HeaderText="Estimated quantity of equipment required" />
                                                        
                                                        
                                                        
                                                    <asp:BoundField DataField="EstMaterial" 
                                                        HeaderText="Type of materials required" />
                                                    <asp:BoundField DataField="MaterialQuantity" 
                                                        HeaderText="Estimated quantity of materials required" />
                                                        
                                                        
                                                    <asp:BoundField DataField="EstSkilLabour" 
                                                        HeaderText="Estimated Skill Labour Required" />
                                                    <asp:BoundField DataField="EstWorkStartDate" 
                                                        HeaderText="Estimated Work Start Date" DataFormatString="{0:MM-dd-yyyy}" />
                                                    <asp:BoundField DataField="EstWorkEndDate" 
                                                        HeaderText="Estimated Work End Date" DataFormatString="{0:MM-dd-yyyy}" />
                                                    <asp:BoundField DataField="EstCost" HeaderText="Estimated Cost" />
                                                </Columns>
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#013161" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr visible="false" id="trTSTApproval" runat="server">
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label427" runat="server" CssClass="LBLBLACK" Width="128px">Status</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px;">
                                                        <asp:DropDownList ID="ddlstatus" runat="server" 
                                                            class="form-control txtbox" Height="28px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlstatus_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem>New Proposal</asp:ListItem>
                                                            <asp:ListItem>Approved</asp:ListItem>
                                                            <asp:ListItem>Invoice Request</asp:ListItem>
                                                            <asp:ListItem>Invoice Appovals</asp:ListItem>
                                                            <asp:ListItem>InProgress</asp:ListItem>
                                                            <asp:ListItem>Closed</asp:ListItem>
                                                            <asp:ListItem>Rejected</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label426" runat="server" CssClass="LBLBLACK" Width="156px">Approved/Rejected 
                                                        Date</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; width: 192px;">
                                                        <asp:TextBox ID="txtApprRejDate" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" onkeypress="Dates()"  TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            
                                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" 
Format="dd-MM-yyyy" PopupButtonID="txtApprRejDate" 
TargetControlID="txtApprRejDate">
</cc1:CalendarExtender>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                                            ControlToValidate="txtApprRejDate" 
                                                            ErrorMessage="Please Enter Approved/Rejected Date" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 27px">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label430" runat="server" CssClass="LBLBLACK" Width="136px">Payam / Block Development Committee Approved Date</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtPDCApprvDate" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="40" onkeypress="Dates()"  TabIndex="1" 
                                                            ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            
                                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" 
Format="dd-MM-yyyy" PopupButtonID="txtPDCApprvDate" 
TargetControlID="txtPDCApprvDate">
</cc1:CalendarExtender>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 13px;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                                                            ControlToValidate="txtPDCApprvDate" 
                                                            ErrorMessage="Please Enter Payam / Block Development Committee Approved Date" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:Label ID="Label428" runat="server" CssClass="LBLBLACK" Width="136px">Remarks</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtRemarks" runat="server" class="form-control txtbox" 
                                                            Height="44px" MaxLength="50" onkeypress="Names()" TabIndex="1" 
                                                            TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 13px;">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                Height="32px" onclick="BtnSave_Click" TabIndex="10" Text="Save" 
                                                ValidationGroup="group" Width="90px" />
                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-danger" Height="32px" onclick="BtnClear_Click" TabIndex="10" 
                                                Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                            &nbsp;<asp:Button ID="BtnDelete" runat="server" CausesValidation="False" 
                                                CssClass="btn btn-warning" Height="32px" onclick="BtnClear0_Click" 
                                                OnClientClick="return confirm('Do you want to delete the record ? ');" 
                                                TabIndex="10" Text="Delete" Visible="false" Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                            <div ID="success" runat="server" class="alert alert-success" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" 
                                                    href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label 
                                                    ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                            <div ID="Failure" runat="server" class="alert alert-danger" visible="false">
                                                <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>
                                                Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfTSTID" runat="server" />
                                <asp:HiddenField ID="hdfTSTName" runat="server" />
                                <asp:HiddenField ID="hdfWorkCode" runat="server" />
                                <asp:HiddenField ID="hdfTSTEmail" runat="server" />
                                <asp:HiddenField ID="hdfIPEmail" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                                <asp:HiddenField ID="hdfRowIndex" runat="server" />
                                <asp:HiddenField ID="hdfTargetID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                            </div>
                        </div>
                    </div>
                </div>

    </div>
               <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
<ProgressTemplate>
<div class="overlay">
<%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">--%>
<div style=" z-index: 1000; margin-left: -210px;margin-top:100px;opacity: 1; -moz-opacity: 1;">
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

