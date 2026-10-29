<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmClosedUnits.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <%--<script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>--%>
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
        </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupfrmClosedUnits.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

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
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">LINE OF ACTIVITY</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    REPORT 4: CLOSED UNITS</h3>
                            </div>
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" 
                                                    colspan="3">
                                                    <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                        Width="136px">Targets Completed</asp:Label>
                                                    <asp:Label ID="lblmsg1" runat="server" Font-Bold="True"></asp:Label>
                                                    /<asp:Label ID="lblmsg2" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    
                                                </td>
                                                <td style="width: 27px" runat="server">
                                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-primary" 
                                                        Height="32px" OnClientClick="OpenPopup();" TabIndex="10" Text="Lookup" 
                                                        Width="90px" />
                                                </td>
                                                <td valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                
                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                     <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1 &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                               whether any cases registered this month or not.</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rbtcasesregmonth" AutoPostBack="true" OnSelectedIndexChanged="rbtcasesregmonth_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server" >
                            <asp:ListItem Value="Y" Selected="True">YES</asp:ListItem>
                            <asp:ListItem Value="N" >NO</asp:ListItem>
                        </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;</td>
                                                        </tr>   
                                                    <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                2</td>
                                                            <td style="width: 200px;">
                                                                Date of Entry<font id="fn1" runat="server" 
                                                            color="red">*</font></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtdateofentry" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" Visible="false"
                                                                    ControlToValidate="txtdateofentry" ErrorMessage="Please Enter Date of Entry" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">3</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">Month<font 
                                                            color="red" id="fn2" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
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
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlMonth" ErrorMessage="Please Select Month" InitialValue="--Select--" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                4</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="165px">Year<font 
                                                            color="red" id="fn3" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem>2016</asp:ListItem>
                                                                    <asp:ListItem>2020</asp:ListItem>
                                                                    <asp:ListItem>2021</asp:ListItem>
                                                                    <asp:ListItem>2022</asp:ListItem>
                                                                    <asp:ListItem>2023</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                                                                    ControlToValidate="ddlYear" ErrorMessage="Please select Year" 
                                                                    InitialValue="--Select--" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                5</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="165px">Name of the Unit<font 
                                                            color="red" id="fn4" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TxtNameofUnit" runat="server" class="form-control txtbox" 
                                                                    Height="28px" MaxLength="100"  TabIndex="1" AutoComplete="off" 
                                                                    ValidationGroup="group" Width="180px" 
                                                                    ontextchanged="TxtNameofUnit_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                              
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                                    ControlToValidate="TxtNameofUnit" ErrorMessage="Please Enter Unit name" 
                                                                    ValidationGroup="group" Visible="false">*</asp:RequiredFieldValidator>
                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                             <td style="padding: 5px; margin: 5px">6</td>
                                                            <td style="width: 200px;">District<font color="red" id="fn5" runat="server">*</font></td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px"><asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged"
                                                                    Height="33px" 
                                                                    Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td style="padding: 5px; margin: 5px"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProp_intDistrictid"
                                                                    ErrorMessage="Please Select Proposed Location (District)" ValidationGroup="group"
                                                                    InitialValue="--Select--" Visible="false">*</asp:RequiredFieldValidator></td>
                                                            
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                7</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Mandal&nbsp; <span id="fn6" runat="server" style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control txtbox" Visible="true"
                                                                        TabIndex="3" Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlUnitMandal_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" >--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddlUnitMandal"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Unit Mandal" InitialValue="--Mandal--"
                                                                        ValidationGroup="group" Visible="false">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">8</td>
                                                            
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Village&nbsp; <span id="fn7" runat="server" style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox"
                                                                        Visible="true" TabIndex="3" Height="33px" Width="180px" AutoPostBack="True">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddlVillageunit"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Unit Village" InitialValue="--Village--" Visible="false"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                9</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Address of the Unit<font 
                                                            color="red" id="fn8" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TxtAddressofUnit" runat="server" class="form-control txtbox" 
                                                                    Height="58px"  TabIndex="1" TextMode="MultiLine" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                             
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" Visible="false" 
                                                                    ControlToValidate="TxtAddressofUnit" 
                                                                    ErrorMessage="Please Enter Address of Unit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                             
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
                                                            <td style="width: 200px;">
                                                                10</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="165px">HT or LT<font 
                                                            color="red" id="fn9" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlLTHT" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem>LT</asp:ListItem>
                                                                    <asp:ListItem>HT</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                                                    ControlToValidate="ddlLTHT" ErrorMessage="Please Select HT or LT" 
                                                                    InitialValue="--Select--" ValidationGroup="group" Visible="false">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 200px;">
                                                                11</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="179px">Date of Closure of the Unit(dd/mm/yyyy)<font 
                                                            color="red" id="fn10" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TxtDateofCloser" runat="server" class="form-control txtbox" AutoComplete="off"
                                                                    Height="28px" MaxLength="13"  TabIndex="1" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    
                                                                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="TxtDateofCloser"
                                                                    TargetControlID="TxtDateofCloser">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                                                    ControlToValidate="TxtDateofCloser" ErrorMessage="Please Enter Date of Closure" 
                                                                    ValidationGroup="group" Visible="false">*</asp:RequiredFieldValidator>
                                                            
                                                            </td>
                                                       </tr>
                                                        <tr>
                                                            <td style="width: 200px;">12</td>
                                                            <td style="width: 200px;">Date of Closure Reported for the first time(dd/mm/yyyy)</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="TxtDateofCloserFirst" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidator27" runat="server" ControlToValidate="TxtDateofCloserFirst" ErrorMessage="Please Enter Date of Closure for the First time" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                       </tr>
                                                        <tr>
                                                            <td style="text-align: left;">
                                                                13&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Brief Reason for Closer<font 
                                                            color="red"  id="fn11" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="TxtBriefReason"  runat="server" 
                                                                    class="form-control txtbox" Height="58px" TabIndex="1" ValidationGroup="group" 
                                                                    Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;
                                                                
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                                                                    ControlToValidate="TxtBriefReason" ErrorMessage="Please Enter Reason" 
                                                                    ValidationGroup="group" Visible="false" >*</asp:RequiredFieldValidator>
                                                                
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                             <td style="text-align: left;">14</td>
                                                             <td style="padding: 5px; margin: 5px; text-align: left;">Current Status<font id="fn12" runat="server" color="red">*</font></td>
                                                             <td style="padding: 5px; margin: 5px">:</td>
                                                             <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                 <asp:DropDownList ID="ddlCurrentStatus" runat="server" OnSelectedIndexChanged="ddlCurrentStatus_SelectedIndexChanged" AutoPostBack="true" class="form-control txtbox" Height="33px" TabIndex="4" Width="180px">
                                                                     <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                     <asp:ListItem Value="1">Closed</asp:ListItem>
                                                                     <asp:ListItem Value="2">Others</asp:ListItem>
                                                                 </asp:DropDownList>
                                                             </td>
                                                             <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlCurrentStatus" ErrorMessage="please Select current status" InitialValue="--Select--" Visible="false"  ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                             </td>
                                                       </tr>
                                                         <tr id="trotherstatus" runat="server" visible="false">
                                                             <td style="text-align: left;">14a</td>
                                                             <td style="padding: 5px; margin: 5px; text-align: left;">others</td>
                                                             <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                             <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                 <asp:TextBox ID="txtStatusOthers" runat="server" class="form-control txtbox" Height="28px" MaxLength="200" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Width="180px" ></asp:TextBox>
                                                             </td>
                                                             <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator26" Visible="false"  runat="server" ControlToValidate="txtStatusOthers" ErrorMessage="please enter current status" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                             </td>
                                                       </tr>
                                                        <tr id="Tr3" runat="server" visible="true">
                                                    <td style="padding: 5px; margin: 5px">
                                                        15</td>
                                                    <td style="width: 200px;">
                                                        <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="165px">Whether send to TIHCL</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                           <asp:RadioButtonList ID="rbtTIHCL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtTIHCL_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                               <asp:ListItem  Value="Y">Yes</asp:ListItem>
                                                               <asp:ListItem Value="N">No</asp:ListItem>
                                                           </asp:RadioButtonList>
                                                    </td>
                                                  
                                                    <td style="padding: 5px; margin: 5px">
                                                       
                                                    </td>
                                                </tr>
                                            <tr id="Trreason" runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px">
                                                        &nbsp;</td>
                                                    <td style="width: 200px;">
                                                        <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="165px">Reason </asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                       <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="Txtreason" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="child" autoComplete="off" 
                                                            Width="180px" ></asp:TextBox>
                                                    </td>
                                                  
                                                    <td style="padding: 5px; margin: 5px">
                                                      
                                                    </td>
                                                </tr>
                                                         <tr>
                                                            <td style="text-align: left;">
                                                                16</td>
                                                             <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                 <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Any other remarks<font 
                                                            color="red" id="fn13" runat="server">*</font></asp:Label>
                                                             </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtRemarks" runat="server" class="form-control txtbox" 
                                                                    Height="58px"  TabIndex="1" ValidationGroup="group" 
                                                                    Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                                    ControlToValidate="txtRemarks" ErrorMessage="Please Enter Remarks" 
                                                                    ValidationGroup="group" Visible="false" >*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; " valign="top" align="left" colspan="3">
                                                   
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="style6" style="padding: 5px; margin: 5px">
                                                                17</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label395" runat="server" CssClass="LBLBLACK" Width="159px">Line of Activity<font 
                                                            color="red" id="fn14" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td class="style5" style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlintLineofActivity" runat="server" 
                                                                    class="form-control txtbox" Height="33px" 
                                                                    
                                                                    Width="720px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                                    ControlToValidate="ddlintLineofActivity" 
                                                                    ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" 
                                                                    ValidationGroup="group" Visible="false" >*</asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                    <td style="width: 27px">
                                                        &nbsp;
                                                    </td>
                                                    <td valign="top">
                                                        &nbsp;
                                                    </td>
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="10" Text="Save" Width="90px" 
                                                        ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                        Width="90px" />
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
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" 
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
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
     <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='TxtDateofCloser']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                     maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='TxtDateofCloserFirst']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  

            $("input[id$='txttermload']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtdatesome']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtCSTRegDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            //added newly
            $("input[id$='txtUdyogAadhaarRegdDate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtGSTDate']").datepicker(
           {
               dateFormat: "dd/mm/yy",
               //  maxDate: new Date(currentYear, currentMonth, currentDate)
           }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
            {
                dateFormat: "dd/mm/yy",
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
           {
               dateFormat: "dd/mm/yy",
               //  maxDate: new Date(currentYear, currentMonth, currentDate)
           }); // Will run at every postback/AsyncPostback  

        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='TxtDateofCloser']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='TxtDateofCloserFirst']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback   

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txttermload']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback

            $("input[id$='txtdatesome']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtCSTRegDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback 
            //added newly
            $("input[id$='txtGSTDate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 //  maxDate: new Date(currentYear, currentMonth, currentDate)
             }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
            {
                dateFormat: "dd/mm/yy",
                //  maxDate: new Date(currentYear, currentMonth, currentDate)
            }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
           {
               dateFormat: "dd/mm/yy",
               //  maxDate: new Date(currentYear, currentMonth, currentDate)
           }); // Will run at every postback/AsyncPostback  

        });
    </script>
</asp:Content>
