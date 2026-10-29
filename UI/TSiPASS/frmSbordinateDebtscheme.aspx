<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/BankMaster.master" AutoEventWireup="true" CodeFile="frmSbordinateDebtscheme.aspx.cs" Inherits="UI_TSiPASS_frmSbordinateDebtscheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
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
        .auto-style1 {
            width: 116px;
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
                                <h3 class="panel-title">SUBORDINATE DEBT SCHEME</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Font-Bold="True">SUBORDINATE DEBT SCHEME<font 
                                                            color="red"></font></asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 60%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Name Of Unit<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="Names()" TabIndex="8" ValidationGroup="group" AutoComplete="off" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUnitName"
                                                                    ErrorMessage="Please Enter Unit Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">3</td>
                                                            <td class="auto-style1"><asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="200px">District<font 
                                                            color="red">*</font></asp:Label></td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlUnitDIst" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" TabIndex="3" Visible="true" Width="180px" OnSelectedIndexChanged="ddlUnitDIst_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlUnitDIst"
                                                                        ErrorMessage="Please Select Proposed Location (District)" ValidationGroup="group"
                                                                        InitialValue="--District--">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">5</td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Village&nbsp; <span style="font-weight: bold; color: Red;" id="fn3" runat="server">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
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

                                                        <tr id="trsurveyno" runat="server" visible="false"> 
                                                            <td style="padding: 5px; margin: 5px">7
                                                            </td>
                                                            <td class="auto-style1">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">Survey No</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtSrveyno" runat="server" class="form-control txtbox"
                                                                    Height="28px" TabIndex="3" ValidationGroup="group" Width="180px"
                                                                    TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSrveyno"
                                                                    ErrorMessage="Please enter Survey No" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">9
                                                            </td>
                                                            <td class="auto-style1">
                                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">Mobile No<font
                                                                    color="red" id="Font2" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtmobileNo" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="10" TabIndex="1" onkeypress="NumberOnly()"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtmobileNo"
                                                                    ErrorMessage="Please enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">11
                                                            </td>
                                                            <td class="auto-style1">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Loan Account Status<font
                                                                    color="red" id="Font5" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rbtSMANPA" AutoPostBack="true" OnSelectedIndexChanged="rbtSMANPA_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                                    <asp:ListItem Value="SMA">SMA</asp:ListItem>
                                                                    <asp:ListItem Value="NPA">NPA</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr id="troutstandingAount" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px">12
                                                            </td>
                                                            <td class="auto-style1" >
                                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="165px">OutStanding Amount as on 30.04.2020 (In Rs.) <font
                                                                    color="red" id="fn5" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtOutStandingAmount" runat="server" class="form-control txtbox" Height="28px"
                                                                    onkeypress="NumberOnly()" TabIndex="4" ValidationGroup="group"
                                                                    Width="180px" AutoPostBack="True" AutoComplete="off"
                                                                    OnTextChanged="txtOutStandingAmount_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtProjectCost"
                                                                    ErrorMessage="Please enter Project Cost" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="trassessment" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px">13
                                                            </td>
                                                            <td class="auto-style1">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="165px">Assessment for Viability done by branch Manager<font
                                                                    color="red" id="Font1" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>


                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rdAssessment" AutoPostBack="true" OnSelectedIndexChanged="rdAssessment_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>

                                                        <tr id="trviablenotviable" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px">14
                                                            </td>
                                                            <td class="auto-style1">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Is Viable or not<font
                                                                    color="red" id="Font6" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>


                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rbtviablenotviable" AutoPostBack="true" OnSelectedIndexChanged="rbtviablenotviable_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                                    <asp:ListItem Value="Viable">Viable</asp:ListItem>
                                                                    <asp:ListItem Value="Not Viable">Not Viable</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trrestructingAmontviable" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px">15&nbsp;
                                                            </td>
                                                            <td class="auto-style1">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Amount Required for Restructuring after Assessment(In Rs.) <font
                                                                    color="red" id="fn6" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtRestructAmount" runat="server" class="form-control txtbox"
                                                                    Height="28px" TabIndex="5" ValidationGroup="group" Width="180px"
                                                                    onkeypress="NumberOnly()" OnTextChanged="txtRestructAmount_TextChanged" AutoPostBack="True" AutoComplete="off"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRestructAmount"
                                                                    ErrorMessage="Please enter Amount Reqired for Restrctruing(In Rs.)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="trsubordinatedept" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">16 &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Is Amount Sanctioned Under Sub-Debt Scheme</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rbtSubordinatedept" AutoPostBack="true" OnSelectedIndexChanged="rbtSubordinatedept_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>


                                                        <tr id="tramount" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">17</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Sanctioned Amount&nbsp; Under Sub-Debt Scheme (In Rs.)</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtAmount" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" OnTextChanged="txtAmount_TextChanged" AutoPostBack="true" AutoComplete="off" TabIndex="8" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAmount"
                                                                    ErrorMessage="Please enter Amount " Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>

                                                            </td>
                                                        </tr>


                                                         <tr id="trtevstudydone" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">13 &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Is TEV Study Done or Not</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rbtTEVStudyDone" AutoPostBack="true" OnSelectedIndexChanged="rbtTEVStudyDone_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trviableTEV" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px">14
                                                            </td>
                                                            <td class="auto-style1">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="165px">Is Viable or not as per TEV Study<font
                                                                    color="red" id="Font7" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>


                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rdviableTEV" AutoPostBack="true" OnSelectedIndexChanged="rdviableTEV_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                                    <asp:ListItem Value="Viable">Viable</asp:ListItem>
                                                                    <asp:ListItem Value="Not Viable">Not Viable</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr runat="server" id="trtevstudydonerestrctamount" visible="false">
                                                            <td style="padding: 5px; margin: 5px">15&nbsp;
                                                            </td>
                                                            <td class="auto-style1">
                                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px">Amount Reqired for Restructuring(In Rs.)TEV Study done<font
                                                                    color="red" id="Font4" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtRestructAmountTEV" runat="server" class="form-control txtbox"
                                                                    Height="28px" TabIndex="5" ValidationGroup="group" Width="180px"
                                                                    onkeypress="NumberOnly()" AutoPostBack="True" OnTextChanged="txtRestructAmountTEV_TextChanged"  AutoComplete="off"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtRestructAmountTEV"
                                                                    ErrorMessage="Please enter(TEV STUDY DONE) Amount Reqired for Restrctruing(In Rs.)" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="TEVSbordinatedebtScheme" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">16 &nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Is Sanctioned Amont Under Subordinate Debt Scheme(TEV)</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:RadioButtonList ID="rbtSubordinateSchemeforTEV" AutoPostBack="true" OnSelectedIndexChanged="rbtSubordinateSchemeforTEV_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">&nbsp;</td>
                                                        </tr>
                                                        <tr id="trTEVAmount" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">17</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Sanctioned Amount Under Subordinate Debt Scheme(TEV) (In Rs.)</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtAmontTEVStudyDone" runat="server" OnTextChanged="txtAmontTEVStudyDone_TextChanged" AutoPostBack="true" class="form-control txtbox" Height="28px" onkeypress="NumberOnly()" AutoComplete="off" TabIndex="8" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAmontTEVStudyDone"
                                                                    ErrorMessage="Please enter Amount " Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>

                                                            </td>
                                                        </tr>
                                                        <tr id="trremarks" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Remarks</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtremarks" runat="server" class="form-control txtbox" Height="28px"  AutoComplete="off" TabIndex="8" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtremarks"
                                                                    ErrorMessage="Please enter Remarks " Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>

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
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="210px">Name of Entrepreneur<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEntrepreneurname" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="Names()" TabIndex="8" ValidationGroup="group" AutoComplete="off" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEntrepreneurname"
                                                                    ErrorMessage="Please enter Name of Entrepreneur" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">4</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Mandal&nbsp; <span style="font-weight: bold; color: Red;" id="fn2" runat="server">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
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
                                                            <td style="padding: 5px; margin: 5px">6
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Address</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtAddress" runat="server" class="form-control txtbox"
                                                                    Height="28px" TabIndex="3" ValidationGroup="group" Width="180px"
                                                                    TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress"
                                                                    ErrorMessage="Please enter  address" Visible="false" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">8</td>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">LineOfActivity&nbsp; <span style="font-weight: bold; color: Red;" id="Span1" runat="server">*</span>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="form-control txtbox"
                                                                    Height="33px" AutoPostBack="True"
                                                                    Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlintLineofActivity"
                                                                    SetFocusOnError="true" ErrorMessage="Please Select Line Of Activity" InitialValue="--Select--"
                                                                    ValidationGroup="group" Visible="false">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">10
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">Email Id</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtEmail"
                                                                    ErrorMessage="Please enter Email" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                                                    ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="group">*</asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>




                                                       

                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">&nbsp;
                                                </td>
                                                <td style="width: 27px">&nbsp;
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr id="trsave" runat="server">
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="BtnSave_Click" TabIndex="11" Text="Save" Width="90px" ValidationGroup="group" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click"      TabIndex="12"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" /></td>
                                            </tr>
                                            <tr id="trupdate" runat="server" visible="false">
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Height="32px"
                                                         TabIndex="11" Text="Update" Width="90px" ValidationGroup="group" OnClick="btnUpdate_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%--<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="12"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />--%></td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
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
</asp:Content>

