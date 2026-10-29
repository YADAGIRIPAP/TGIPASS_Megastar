<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="IndustrialCataloge1.aspx.cs" Inherits="TSTBDCReg1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
        .style5
        {
            width: 13px;
        }
        .style6
        {
            width: 187px;
        }
        .style7
        {
            width: 211px;
        }
        .style8
        {
            height: 27px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupIndustryCatelog.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";         

        }

        function NumberhyphenOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue == 45) || (AsciiValue == 47))
        event.returnValue = true;
    else {
        event.returnValue = false;

        alert("Enter NumericValues, '/', '-' Only");
    }
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit"></i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#"></a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Report 6:Industrial Catalogue </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr runat="server" visible="false">
                                         <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" 
                                                    colspan="3">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True" 
                                                                    Width="136px">Targets Completed</asp:Label>
                                                            :<asp:Label ID="lblmsg1" runat="server"></asp:Label>
                                                    /<asp:Label ID="lblmsg2" runat="server"></asp:Label>
                                                </td>
                                    </tr>
                                            <tr runat="server" visible="false">
                                                <td colspan="3" style="padding: 5px; margin: 5px; text-align: center;" 
                                                    valign="top">
                                                    <asp:Button ID="btnOrgLookup0" runat="server" CausesValidation="False" 
                                                        CssClass="btn btn-primary" Font-Size="12px" Height="32px" 
                                                        onclick="btnOrgLookup_Click" Style="position: static" Text="Look Up" 
                                                        ToolTip="Rate Lookup" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; vertical-align: top;" valign="top">
                                                                1
                                                            </td>
                                                            <td class="style7">
                                                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="200px">No. of 
                                                                Units in IPO Jurisdiction(Mandals allocated by GM)<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="180px"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                  
                                                           <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                1&nbsp;</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label442" runat="server" CssClass="LBLBLACK" Width="180px">Year</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:DropDownList ID="ddlYear" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                                                                    ControlToValidate="ddlYear" ErrorMessage="Please select Year" 
                                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                2</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label443" runat="server" CssClass="LBLBLACK" Width="165px">Month</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                   <asp:ListItem Value="1">January</asp:ListItem>
                                                            <asp:ListItem Value="2">February</asp:ListItem>
                                                            <asp:ListItem Value="3">March</asp:ListItem>
                                                            <asp:ListItem Value="4">April</asp:ListItem>
                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                            <asp:ListItem Value="6">June</asp:ListItem>
                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                            <asp:ListItem Value="8">August</asp:ListItem>
                                                            <asp:ListItem Value="9">Sepetmber</asp:ListItem>
                                                            <asp:ListItem Value="10">October</asp:ListItem>
                                                            <asp:ListItem Value="11">November</asp:ListItem>
                                                            <asp:ListItem Value="12">December</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                                                                    ControlToValidate="ddlMonth" ErrorMessage="Please select month" 
                                                                    InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                            <tr runat="server" visible="true">
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                5</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK">Yet to Capture <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:TextBox ID="txtYetCapture" runat="server" class="form-control txtbox" 
                                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                                    ControlToValidate="txtYetCapture" ErrorMessage="Please enter  Yet to Capture" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    &nbsp;
                                                </td>
                                                <td align="justify" style="vertical-align: top" valign="top">
                                                    &nbsp;<table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;">
                                                                3</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK"></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:TextBox ID="txpture" runat="server" class="form-control txtbox" 
                                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                                                    ControlToValidate="txpture" ErrorMessage="Please enter  Yet to Capture" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                              <tr>
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" valign="top">
                                                                3
                                                            </td>
                                                            <td class="style7">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="180px">No.of 
                                                                Units In respective Districts (in respect to concerned jurisdiction) <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:TextBox ID="txtresMandals" runat="server" class="form-control txtbox" 
                                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                                                    ControlToValidate="txtresMandals" ErrorMessage="Please Enter No.of Units in the Respective Mandal*" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                4</td>
                                                            <td class="style7">
                                                                <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="180px">No.of 
                                                                Units Captured <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:TextBox ID="txtNoofUnit" runat="server" class="form-control txtbox" 
                                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" AutoComplete="off" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                                                    ControlToValidate="txtNoofUnit" ErrorMessage="Please Enter No.of Units Captured	" 
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                     
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label441" runat="server" Font-Bold="True" 
                                                        Text="Industrial Catalogue Details :" Width="300px"></asp:Label>
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
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        1</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="165px">Whether any Cases registered or Not
                                                        <font id="lbl" runat="server" color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:RadioButtonList ID="rdIaLa_Lst" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged"
                                                >
                                                <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="N" >No</asp:ListItem>
                                            </asp:RadioButtonList>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                            ControlToValidate="txtUnitName" ErrorMessage="Please select Unit Name" 
                                                            ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px;">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label432" runat="server" CssClass="LBLBLACK" Width="180px">Name of the Unit<font 
                                                            color="red" id="lbl1" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox" AutoComplete="off" 
                                                                    Height="28px" MaxLength="40" onkeypress="Names()" TabIndex="1" 
                                                                    ValidationGroup="group" Width="180px" 
                                                                    ontextchanged="txtUnitName_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                    ControlToValidate="txtUnitName" ErrorMessage="Please enter UnitName" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                          <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                5</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="180px">Mandal<font 
                                                            color="red" id="lbl2" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                  <asp:DropDownList ID="ddlUnitMandal1" runat="server" class="form-control txtbox" Visible="true"
                                                                        TabIndex="3" Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnitMandal1_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                    ControlToValidate="ddlcstatus" ErrorMessage="Please select Mandal" 
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                7
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="180px">Address of the Unit<font 
                                                            color="red" id="lbl3" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtaddress" runat="server" class="form-control txtbox" 
                                                                    Height="28px" MaxLength="160"  TabIndex="1" AutoComplete="off"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                    ControlToValidate="txtaddress" ErrorMessage="Please Enter Address" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                9</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="180px">Date of Visited(dd-mm-yyyy)<font 
                                                            color="red" id="lbl4" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDateofVisit" runat="server" class="form-control txtbox" 
                                                                    Height="28px" MaxLength="40" onchange="return txtDOB();" TabIndex="1" 
                                                                    ValidationGroup="group" Width="180px" AutoComplete="off" onkeypress="NumberhyphenOnly()"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="txtDateofVisit_CalendarExtender" runat="server" 
                                                                    format="dd-MM-yyyy" popupbuttonid="txtRegDate" 
                                                                    targetcontrolid="txtDateofVisit">
                                                                </cc1:CalendarExtender>
                                                                
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                    ControlToValidate="txtDateofVisit" ErrorMessage="Please select Date" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                              <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        11</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label445" runat="server" CssClass="LBLBLACK" Width="165px">Upload 
                                                        Photo</asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" 
                                                            Height="28px" />
                                                        <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Visible="false"
                                                            Width="165px"></asp:HyperLink>
                                                        <br />
                                                        <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
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
                                                            <td style="padding: 5px; margin: 5px; vertical-align: middle;" valign="top">
                                                                2</td>
                                                            <td class="style7">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="180px">No.of 
                                                                Units In respective Mandals <font color="red" id="lbl21" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px 5px 5px 85px">
                                                                <asp:TextBox ID="txtgridmaldasNo" runat="server" class="form-control txtbox" 
                                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1" 
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                               
                                                            </td>
                                                        </tr>
                                                          <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                4</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="180px">District<font 
                                                            color="red" id="lbl5" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                 
                                                                 <asp:DropDownList ID="ddlUnitDIst1" runat="server" class="form-control txtbox" Visible="true"
                                                                        TabIndex="3" Height="33px" Width="180px" OnSelectedIndexChanged="ddlUnitDIst1_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                                    ControlToValidate="ddlcstatus" ErrorMessage="Please select District " 
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                        </tr>
                                                              <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                6</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="180px">Village<font 
                                                            color="red" id="lbl6" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                  <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox"
                                                                        TabIndex="3" Height="33px" Width="180px">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                    ControlToValidate="ddlcstatus" ErrorMessage="Please select Village " 
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                8</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="180px">Current Status<font 
                                                            color="red" id="lbl7" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlcstatus" runat="server" class="form-control txtbox" 
                                                                    Height="33px" TabIndex="1" Width="180px" OnSelectedIndexChanged="ddlcstatus_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Working</asp:ListItem>
                                                                    <asp:ListItem Value="2">Others</asp:ListItem>
                                                                    
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                              <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                                    ControlToValidate="ddlcstatus" ErrorMessage="Please select Current Status" 
                                                                    InitialValue="--Select--" ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>

                                                             <tr runat="server" visible="false" id="trCurrentStatus">
                                                            <td style="padding: 5px; margin: 5px">
                                                                8a</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="180px">Current Status<font 
                                                            color="red" id="lbl8" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtOthersCurrentStatus" runat="server" class="form-control txtbox" 
                                                                    Height="40px" MaxLength="500"  TabIndex="1" 
                                                                    TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                               
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                10</td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label438" runat="server" CssClass="LBLBLACK">Remarks<font 
                                                            color="red" id="lbl9" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;:</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtremark" runat="server" class="form-control txtbox" 
                                                                    Height="40px" MaxLength="500"  TabIndex="1" 
                                                                    TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                                    ControlToValidate="txtremark" ErrorMessage="Please enter Remarks" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                   
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="padding: 5px; margin: 5px" valign="top" class="style8">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                12&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px" class="style6">
                                                                <asp:Label ID="Label395" runat="server" CssClass="LBLBLACK" Width="180px">Line of Activity<font 
                                                            color="red" id="lbl10" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style5">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlintLineofActivity" runat="server" AutoPostBack="True" 
                                                                    class="form-control txtbox" Height="33px" 
                                                                    OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged" 
                                                                    Width="600px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                                    ControlToValidate="ddlintLineofActivity" 
                                                                    ErrorMessage="Please Select Line of Activity" InitialValue="--Select--" 
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: right;" valign="top">
                                                   
                                                </td>
                                                <td style="width: 27px">
                                                    &nbsp;</td>
                                                <td valign="top">
                                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-xs btn-warning" 
                                                        Height="28px" onclick="BtnSave2_Click1" TabIndex="10" Text="Add New" 
                                                        ValidationGroup="child" Width="72px" />
                                                    &nbsp;
                                                    <asp:Button ID="BtnClear0" runat="server" CausesValidation="False" 
                                                        CssClass="btn btn-xs btn-danger" Height="28px" onclick="BtnClear0_Click2" 
                                                        TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                    <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="None" OnRowDataBound="gvCertificate_RowDataBound" OnRowDeleting="gvCertificate_RowDeleting"
                                                        Width="100%" DataKeyNames="intTrIndustrialCatalogueid" 
                                                        EnableModelValidation="True">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Edit" Visible="False" />
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                            <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                            <asp:BoundField DataField="DistricName" HeaderText="DistricName"/>
                                                      <asp:BoundField DataField="MandalName" HeaderText="MandalName"/>
                                                      <asp:BoundField DataField="VillageName" HeaderText="VillageName"/>
                                                            <asp:BoundField DataField="AddressofUnit" HeaderText="Address of Unit" >
                                                         
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="LineofActivityName" HeaderText="line of Activity" >
                                                         
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="NoofMandalsgrid" HeaderText="No of Units In Mandals"/>
                                                            <asp:BoundField DataField="DateofVisited" HeaderText="DateofVisited" >
                                                          
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CurrentStatus" HeaderText="Current Status" >
                                                         
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" >
                                                           
                                                            </asp:BoundField>
                                                             <asp:TemplateField HeaderText="Uploaded Photo" ItemStyle-Width="30">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hprlink" runat="server" NavigateUrl='<%# Eval("FilePath") %>'
                                                                    Text='View' Visible="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                            <asp:BoundField DataField="DistrictId" HeaderText="DistrictId" Visible="false"/>
                                                      <asp:BoundField DataField="MandalId" HeaderText="MandalId" Visible="false"/>
                                                      <asp:BoundField DataField="VillageId" HeaderText="VillageId" Visible="false"/>

                                                             <asp:BoundField DataField="WhetherYorN" HeaderText="WhetherYorN" Visible="false"/>
                                                             
                                                            
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
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                                    &nbsp;</td>
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

        <Triggers>
           <asp:PostBackTrigger ControlID="BtnSave1" />
<asp:PostBackTrigger ControlID="BtnSave2"></asp:PostBackTrigger>

           </Triggers>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
    e
</asp:Content>
