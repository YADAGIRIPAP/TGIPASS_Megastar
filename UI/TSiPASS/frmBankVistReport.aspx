<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmBankVistReport.aspx.cs" Inherits="TSTBDCReg1" %>

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
            width: 203px;
        }
        .auto-style1 {
            width: 10px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBankVisit.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            //$("input[id$='txtDate']").datepicker(
            //   {
            //       dateFormat: "dd/mm/yy",
            //       maxDate: new Date(currentYear, currentMonth, currentDate)
            //   }); // Will run at every postback/AsyncPostback

            $("input[id$='txtDDDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  maxDate: new Date(currentYear, currentMonth, currentDate)
              }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            //$("input[id$='txtDate']").datepicker(
            //    {
            //        //dateFormat: "dd/mm/yy",
            //        dateFormat: "dd/mm/yy",
            //        maxDate: new Date(currentYear, currentMonth, currentDate)
            //    });

            $("input[id$='txtDDDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate > new Date()) {
                alert("You cannot select a day later than today!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }

        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">IPO</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Bank Visit Details</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Report 2:BANK VISIT REPORT(Loan Sanctioned Report)</h3>
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
                  s                                  /<asp:Label ID="lblmsg2" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td align="center" colspan="3" 
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Label ID="Label347" runat="server" CssClass="LBLBLACK" Width="100px">Search</asp:Label>
                                                    <asp:Button ID="btnOrgLookup0" runat="server" CausesValidation="False" 
                                                        CssClass="btn btn-primary" Font-Size="12px" Height="32px" 
                                                        OnClientClick="OpenPopup();" Style="position: static" TabIndex="1" 
                                                        Text="Look Up" ToolTip="Rate Lookup" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">Bank Visit Details<font 
                                                            color="red">*</font></asp:Label>
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
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                       
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1 </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label432" runat="server" CssClass="LBLBLACK" Width="200px">Bank Name<font 
                                                            color="red" ID="lbl2" runat="server" >*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">: </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlBank" runat="server" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlBank" ErrorMessage="Please select Bank" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label433" runat="server" CssClass="LBLBLACK" Width="200px">Bank Branch Name<font ID="lbl1" runat="server" 
                                                             color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtBankBranchName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="Names()" TabIndex="2" ValidationGroup="group" AutoComplete="off" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBankBranchName"
                                                                    ErrorMessage="Please Enter Brach Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">Bank Visit Month<font 
                                                            color="red" ID="lbl3" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMonth" runat="server" class="form-control txtbox" Height="33px"
                                                                    TabIndex="3" Width="180px">
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
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMonth"
                                                                    ErrorMessage="Please select Bank Visit Month" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                4
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="210px">Bank Visit Year<font 
                                                            color="red" ID="lbl4" runat="server">*</font></asp:Label>
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
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlYear"
                                                                    ErrorMessage="Please select Bank Visit Year" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                5
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label434" runat="server" CssClass="LBLBLACK" Width="200px">Nature of Loan<font 
                                                            color="red" ID="lbl5" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlNatureOfLoan" AutoPostBack="true"  runat="server" class="form-control txtbox" OnSelectedIndexChanged="ddlNatureOfLoan_SelectedIndexChanged"
                                                                    Height="33px" TabIndex="4" Width="180px">
                                                                    <asp:ListItem Value="0" >--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Fresh Loan</asp:ListItem>
                                                                    <asp:ListItem Value="2">WORKING CAPITAL LOAN</asp:ListItem>
                                                                    <asp:ListItem Value="3"> OVER DRAFT</asp:ListItem>
                                                                    <asp:ListItem Value="4">RESTRUCTURING LOAN</asp:ListItem>
                                                                    <asp:ListItem Value="5">Others</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlNatureOfLoan"
                                                                    ErrorMessage="Please select Nature of Loan" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                         
                                                        <tr runat="server" visible="false" id="loanothers">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">5a&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"> Nature Of Loan</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" >
                                                                <asp:TextBox ID="txtLoanOthers" runat="server" class="form-control txtbox" Height="28px" MaxLength="200" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                            ControlToValidate="txtLoanOthers" ErrorMessage="Please Enter Nature of Loan(others)" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator></td>
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
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        7</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Name 
                                                        of the Unit<font color="red" ID="lbl6" runat="server">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox" 
                                                            Height="28px" MaxLength="200" TabIndex="1" ValidationGroup="group" AutoComplete="off" 
                                                            Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                            ControlToValidate="txtUnitName" ErrorMessage="Please Enter Unit Name" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
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
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ControlToValidate="ddlUnitDIst" ErrorMessage="Please Enter Unit District" SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                    
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                9</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Mandal&nbsp; <span  ID="lbl7" runat="server" style="font-weight: bold; color: Red;">*</span>
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
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlUnitMandal"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Unit Mandal" InitialValue="--Select--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">10</td>
                                                            
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    Village&nbsp; <span ID="lbl8" runat="server" style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    :
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox"
                                                                        Visible="true" TabIndex="3" Height="33px" Width="180px" AutoPostBack="True">
                                                                        <asp:ListItem Value="0" >--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="ddlVillageunit" Visible="false"
                                                                        SetFocusOnError="true" ErrorMessage="Please Select Unit Village" InitialValue="--Select--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                        </tr>
                                                     <tr id="qty" runat="server" visible="true">
                                                    <td style="padding: 5px; margin: 5px">
                                                        11</td>
                                                    <td style="width: 200px;">
                                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">Address of the Unit<font 
                                                            color="red" ID="lbl9" runat="server">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                        :</td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control txtbox"
                                                            Height="43px" MaxLength="200" TabIndex="1" ValidationGroup="group" 
                                                            Width="180px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                            ControlToValidate="txtAddress" ErrorMessage="Please Enter Address" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                12
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Contact No(if any)<font 
                                                            color="red"></font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtContact" runat="server" class="form-control txtbox" Height="28px" 
                                                                    MaxLength="10" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group" AutoComplete="off" Width="180px"></asp:TextBox>
                                                                </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <%--<asp:RegularExpressionValidator ID="regularexpressionvalidator7" runat="server" ControlToValidate="txtcontact" ErrorMessage="Mobile number length must be exactly 10 characters" ValidationExpression="[0-9]{10}" ValidationGroup="group">*</asp:RegularExpressionValidator>--%>
                                                                &nbsp;
                                                                 </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                13a
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label431" runat="server" CssClass="LBLBLACK" Width="165px">Promoter Name<font 
                                                            color="red" ID="lbl10" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtPromoterName" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="100" onkeypress="Names()" TabIndex="5" ValidationGroup="group" AutoComplete="off" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPromoterName"
                                                                    ErrorMessage="Please enter Promoter Name" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                13b
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">Total Investment<font 
                                                            color="red" ID="Font1" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="Txtinvesment" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="100" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group" AutoComplete="off" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPromoterName"
                                                                    ErrorMessage="Please enter Promoter Name" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                14
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="165px">Total Loan Amount<font 
                                                            color="red" ID="lbl11" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtLoanAmont" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="8" onkeypress="NumberOnly()" AutoComplete="off" TabIndex="6" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLoanAmont"
                                                                    ErrorMessage="Please enter Loan Amount" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                15&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Date of sanction<font 
                                                            color="red" ID="lbl12" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="auto-style1">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtDDDate" runat="server" class="form-control txtbox" Height="28px" AutoComplete="off"
                                                                    MaxLength="40" onchange="return txtDOB();" TabIndex="8" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                                <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtRegDate"
                                                                    TargetControlID="txtDDDate" OnClientDateSelectionChanged="checkDate">
                                                                </cc1:CalendarExtender>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDDDate"
                                                                    ErrorMessage="Please Select Sanction Date" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" >
                                                                16
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style6">
                                                                <asp:Label ID="Label395" runat="server" CssClass="LBLBLACK" Width="135px">Line of Activity<font 
                                                            color="red" ID="lbl13" runat="server">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px" class="style5">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlintLineofActivity" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlintLineofActivity_SelectedIndexChanged" Width="300px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr runat="server" id="trlineofactivity" visible="false">
                                                            <td style="padding: 5px; margin: 5px">16a</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px">Line of Activity(others)</td>
                                                            <td class="style5" style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px"><asp:TextBox ID="txtLOAothers" runat="server" AutoComplete="off" class="form-control txtbox" Height="28px"
                                                                MaxLength="200" TabIndex="1" ValidationGroup="group" Width="180px" ></asp:TextBox></td>
                                                           
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>

                                                </td>
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
                                                        OnClick="BtnSave_Click" TabIndex="10" ValidationGroup="group" Text="Save" Width="90px" />
                                                    <asp:Button Visible="false" ID="BtnUpdate" runat="server" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="BtnUpdate_Click" TabIndex="10" ValidationGroup="group"
                                                        Text="Update" Width="90px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="11"
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
