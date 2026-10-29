<%@ Page Title=":: TS-iPASS ::" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmPMEGPandMUDRA.aspx.cs" Inherits="TSTBDCReg1" %>

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
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupPMEGPandMUDRA.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtgroundeddate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback


        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtgroundeddate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });


        });
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
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                   REPORT 8: PMEGP &amp; MUDRA REGISTRATION</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: center;" colspan="3" align="center">
                                                    <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="136px" 
                                                        Font-Bold="True">Targets Completed</asp:Label>
                                                    <asp:Label ID="lblmsg1" runat="server" Font-Bold="True"></asp:Label>
                                                    /<asp:Label ID="lblmsg2" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server" visible="true">
                                                <td align="center" colspan="3" 
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Label ID="Label347" runat="server" CssClass="LBLBLACK" Width="100px">Search</asp:Label>
                                                    <asp:Button ID="btnOrgLookup0" runat="server" CausesValidation="False" 
                                                        CssClass="btn btn-primary" Font-Size="12px" Height="32px" 
                                                        OnClientClick="OpenPopup();" Style="position: static" TabIndex="1" 
                                                        Text="Look Up" ToolTip="Search Look Up" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Font-Bold="True">PMEGP & Mudra(Grounding Status)<font 
                                                            color="red"></font></asp:Label>
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
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Month<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="2" Width="180px">
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
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMonth"
                                                                    ErrorMessage="Please select Bank Visit Month" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">Year<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="7" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlYear"
                                                                    ErrorMessage="Please select Year" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3 </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label432" runat="server" CssClass="LBLBLACK" Width="200px">Bank Name<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">: </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlBank" runat="server" class="form-control txtbox" Height="33px" TabIndex="6" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBank" ErrorMessage="Please select Bank" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="200px">Bank Brach Name<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtBankBranchName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="Names()" TabIndex="8" ValidationGroup="group" AutoComplete="off" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtBankBranchName"
                                                                    ErrorMessage="Please Enter Bank Branch Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                5&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                Type of Loan</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlTypeOfLoan" runat="server" class="form-control txtbox" Height="33px" TabIndex="9" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlTypeOfLoan_SelectedIndexChanged">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">PMEGP</asp:ListItem>
                                                                    <asp:ListItem Value="2">MUDRA</asp:ListItem>
                                                                    <asp:ListItem Value="3">MSME CLUSTER</asp:ListItem>
                                                                    <asp:ListItem Value="4">OTHER</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTypeOfLoan"
                                                                    ErrorMessage="Please select loan type" ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr runat="server" visible="false" id="trtypeofloanothers">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">5a</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">other</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtLoanTypeOthers" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="8" ValidationGroup="group" AutoComplete="off" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtLoanTypeOthers"
                                                                    ErrorMessage="Please enter other loan type " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                       </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                               6 &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                whether any cases registered or not</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rbtcasesregistered" AutoPostBack="true" OnSelectedIndexChanged="rbtcasesregistered_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server" >
                            <asp:ListItem Value="Y" Selected="True">YES</asp:ListItem>
                            <asp:ListItem Value="N" >NO</asp:ListItem>
                        </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                7&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Beneficary Name<font 
                                                            color="red" id="fn1" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtBeneficaryName" onkeypress="Names()" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="180px" AutoComplete="off"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBeneficaryName"
                                                                    ErrorMessage="Please enter Beneficary Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">8</td>
                                                            <td style="width: 200px;">District</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlUnitDIst" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" TabIndex="3" Visible="true" Width="180px" OnSelectedIndexChanged="ddlUnitDIst_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidator70" runat="server" ControlToValidate="ddlUnitDIst" ErrorMessage="Please Enter Unit District" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                9</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;"  >
                                                                    Mandal&nbsp; <span style="font-weight: bold; color: Red;" id="fn2" runat="server">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control txtbox" Visible="true" OnSelectedIndexChanged="ddlUnitMandal_SelectedIndexChanged"
                                                                        TabIndex="3" Height="33px" Width="180px" AutoPostBack="True">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator Visible="false" ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddlUnitMandal"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Unit Mandal" InitialValue="--Mandal--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">10</td>
                                                            
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Village&nbsp; <span style="font-weight: bold; color: Red;" id="fn3" runat="server">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox"
                                                                        Visible="true" TabIndex="3" Height="33px" Width="180px">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddlVillageunit"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Unit Village" InitialValue="--Village--"
                                                                        ValidationGroup="group" Visible="false">*</asp:RequiredFieldValidator>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                11
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Beneficary address<font 
                                                            color="red" id="fn4" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtbeneficiaryAddress" runat="server" class="form-control txtbox"
                                                                    Height="28px"  TabIndex="3" ValidationGroup="group" Width="180px"
                                                                    TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbeneficiaryAddress"
                                                                    ErrorMessage="Please enter Benificiary address" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                12
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="165px">Project Cost<font 
                                                            color="red" id="fn5" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtProjectCost" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="8" onkeypress="NumberOnly()" TabIndex="4" ValidationGroup="group"
                                                                    Width="180px" AutoPostBack="True" AutoComplete="off" 
                                                                    ontextchanged="txtProjectCost_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProjectCost"
                                                                    ErrorMessage="Please enter Project Cost" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                13&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Amount sanctioned<font 
                                                            color="red" id="fn6" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtAmontScanctioned" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="8" TabIndex="5" ValidationGroup="group" Width="180px"
                                                                    onkeypress="NumberOnly()" AutoPostBack="True" AutoComplete="off" 
                                                                    ontextchanged="txtAmontScanctioned_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmontScanctioned"
                                                                    ErrorMessage="Please enter Amont Scanctioned" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                       
                                                        
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                14</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="200px">Current Status of the Unit<font 
                                                            color="red" id="fn7" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlStatusOfUnit" runat="server" class="form-control txtbox"
                                                                    Height="33px" TabIndex="9" Width="180px" OnSelectedIndexChanged="ddlStatusOfUnit_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Apporoval Stages</asp:ListItem>
                                                                    <asp:ListItem Value="2">Grounded</asp:ListItem>
                                                                    <asp:ListItem Value="3">OTHERS</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlStatusOfUnit"
                                                                    ErrorMessage="Please select Status" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                           --%> </td>
                                                        </tr>
                                                        <tr id="trcurrentstatusothers" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">14a</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">status others</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtStatusOthers" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="Names()" AutoComplete="off" TabIndex="8" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtStatusOthers"
                                                                    ErrorMessage="Please Enter other unit status" ValidationGroup="group">*</asp:RequiredFieldValidator>--%></td>
                                                        </tr>
                                                        <tr id="trgroundeddate" runat="server" visible="false">
                                                            <td style="width: 200px;">&nbsp; 14b&nbsp;</td>
                                                            <td style="width: 200px;">Grounded Date</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtgroundeddate" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px" MaxLength="13" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                            </td>
                                                       </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                15</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="200px">Remarks<font 
                                                            color="red" id="fn8" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtRemarks" runat="server" class="form-control txtbox" Height="28px"
                                                                     TabIndex="10" ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRemarks"
                                                                    ErrorMessage="Please Enter Remarks" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top" align="left" colspan="3">
                                                    <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" DataKeyNames="intLineofActivityMid"
                                                        EnableModelValidation="True" ForeColor="#333333" GridLines="None" OnRowDataBound="gvCertificate_RowDataBound"
                                                        OnRowDeleting="gvCertificate_RowDeleting" Width="100%">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                            <asp:BoundField DataField="Beneficiary_Name" HeaderText="Beneficiary Name" />
                                                            <asp:BoundField DataField="Beneficiary_address" HeaderText="Beneficiary Address">
                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Project_cost" HeaderText="Project Cost">
                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Amount_sanctioned" HeaderText="Amount Sanctioned">
                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Bank_Name" HeaderText="Bank Name">
                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Branch_Name" HeaderText="Branch Name">
                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Current_Status_of_the_Unit" HeaderText="Current Status of the Unit">
                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <%--                                                    
                                                    <asp:BoundField DataField="OtherItemName" HeaderText="Type of Quantity" />--%>
                                                        </Columns>
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#013161" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                    <td style="width: 27px">
                                                        &nbsp;
                                                    </td>
                                                    <td valign="top">
                                                        &nbsp;
                                                    </td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
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
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="11" Text="Save" Width="90px" ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="12"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
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
                                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group1" />
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
    e
</asp:Content>
