<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmIndustryReport.aspx.cs" Inherits="UI_TSiPASS_frmIndustryReport" MasterPageFile="~/UI/TSiPASS/BankMaster.master" %>

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

    <style>
        .teamCalendar .ajax__calendar_container {
            border: 2px solid black;
            background-color: white;
            font-size: 11px;
            color: green;
        }
    </style>
    <%--   <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDate']").datepicker(
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
            $("input[id$='txtDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtFromDate']").datepicker(
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
            $("input[id$='txtFromDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtTodate']").datepicker(
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
            $("input[id$='txtTodate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>--%>

    <%--blink--%>
    <style type="text/css">
        <!--
        /* @group Blink */
        .blink {
            -webkit-animation: blink .75s linear infinite;
            -moz-animation: blink .75s linear infinite;
            -ms-animation: blink .75s linear infinite;
            -o-animation: blink .75s linear infinite;
            animation: blink .75s linear infinite;
        }

        @-webkit-keyframes blink {
            0% {
                opacity: 1;
            }

            50% {
                opacity: 1;
            }

            50.01% {
                opacity: 0;
            }

            100% {
                opacity: 0;
            }
        }

        @-moz-keyframes blink {
            0% {
                opacity: 1;
            }

            50% {
                opacity: 1;
            }

            50.01% {
                opacity: 0;
            }

            100% {
                opacity: 0;
            }
        }

        @-ms-keyframes blink {
            0% {
                opacity: 1;
            }

            50% {
                opacity: 1;
            }

            50.01% {
                opacity: 0;
            }

            100% {
                opacity: 0;
            }
        }

        @-o-keyframes blink {
            0%;

        {
            opacity: 1;
        }

        50% {
            opacity: 1;
        }

        50.01% {
            opacity: 0;
        }

        100% {
            opacity: 0;
        }

        }

        @keyframes blink {
            0% {
                opacity: 1;
            }

            50% {
                opacity: 1;
            }

            50.01% {
                opacity: 0;
            }

            100% {
                opacity: 0;
            }
        }
        /* @end */
        -->
    </style>
    <%-- blink--%>

    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="BtnSave3" />--%>
            <%--<asp:PostBackTrigger ControlID="btnUpload2" />--%>
        </Triggers>
        <ContentTemplate>

            <div align="left">
                <ol class="breadcrumb">
                    You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="frmBankLoanSanctionList.aspx">ADMIN</a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-table"></i>
                    </li>

                </ol>
            </div>
            <%--<div class="alert alert-warning fade in" id="warning" runat="server" visible="false">
    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
    <strong>Warning!</strong> <asp:Label ID="lbluserid0" runat="server" 
        CssClass="" ></asp:Label>
    &nbsp;
  </div>--%>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <p class="tab blink" style="color: white">Banker's Application.....</p>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                                    <tr>
                                        <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                            <table cellpadding="7" cellspacing="7" width="100%">
                                                <tr>
                                                    <td valign="top"></td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="180px">Name of Unit</asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TxtnameofUnit" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                            Height="28px" MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    </td>
                                                    <td valign="top">&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label381" runat="server" CssClass="LBLBLACK" Width="180px">District</asp:Label>
                                                    </td>
                                                    <td>:
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                            Height="33px" TabIndex="1" Width="180px">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td valign="top">&nbsp;
                                                    </td>
                                                    <td valign="top">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" class="auto-style1">&nbsp;
                                                    </td>
                                                    <td class="auto-style1">&nbsp;
                                                    </td>
                                                    <td class="auto-style1">&nbsp;
                                                    </td>
                                                    <td class="auto-style1">&nbsp;
                                                    </td>
                                                    <td align="center" colspan="3" class="auto-style1">&nbsp;
                                                    </td>
                                                    <td valign="top" class="auto-style1">&nbsp;
                                                    </td>
                                                    <td valign="top" class="auto-style1">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td align="center" colspan="3">
                                                        <asp:Button ID="BtnSave0" runat="server" CausesValidation="False" CssClass="btn-success"
                                                            Height="32px" OnClick="BtnClear0_Click" TabIndex="10" Text="Search" ValidationGroup="group"
                                                            Width="80px" />
                                                    </td>
                                                    <td valign="top">&nbsp;
                                                    </td>
                                                    <td valign="top">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <caption>
                                        <br />
                                        <br />
                                        <tr>
                                            <td align="left" colspan="5" style="padding: 5px; margin: 5px" valign="top">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333" Height="62px" ShowFooter="True" Width="100%">
                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>--%>
                                                        <asp:BoundField DataField="SNO" HeaderText="S NO" Visible="true" />
                                                        <asp:BoundField DataField="NAME_OF_THE_UNIT" HeaderText="Name Of The Unit" />
                                                        <asp:BoundField DataField="LINE_OF_ACTIVITY" HeaderText="Line of Activity" />
                                                        <asp:BoundField DataField="District_Name" HeaderText="District Name" />
                                                        <asp:BoundField DataField="Manda_lName" HeaderText="Mandal Name" />
                                                        <asp:BoundField DataField="CONTACT_NO" HeaderText="Contact No" />
                                                        <asp:BoundField DataField="EMAIL_ID" HeaderText="Email Id" />
                                                        <asp:BoundField DataField="TYPEName" HeaderText="Type of Account" />
                                                        <asp:BoundField DataField="SICKDATE" HeaderText="Notified Date" />
                                                        <asp:BoundField DataField="Loan_Amount" HeaderText="Loan Amount" />
                                                        <asp:BoundField DataField="loan_application_date" HeaderText="Loan Sanctioned date" />
                                                        <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                                        <asp:BoundField DataField="BranchName" HeaderText="Branch Name" />
                                                        <asp:BoundField DataField="IFSCCODE" HeaderText="IFSCCODE" />
                                                        <asp:TemplateField Visible="false">
                                                            <%--<ItemTemplate>
                                                                <asp:Label ID="lblIncid" runat="server" Text='<%# Eval("IncentiveID") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="IncentiveTypeID" runat="server" Text='<%# Eval("IncentiveTypeID") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>--%>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Click for Update">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkApproval" runat="server" OnCheckedChanged="ChkApproval_CheckedChanged" AutoPostBack="true" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                        </asp:TemplateField>
                                                         
                                                        <%--<asp:BoundField Visible="false" DataField="TYPE" HeaderText="TYPE" />--%>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </caption>



                                </table>
                                <br />
                                <br />
                                <table align="center" runat="server" id="tblappldetails" cellpadding="10" cellspacing="5" style="width: 90%" visible="false">

                                    <tr>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                                <tr>
                                                    <td style="width: 27px">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top"></td>
                                                    <td style="width: 27px">&nbsp;
                                                    </td>
                                                    <td valign="top" class="style6">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">1
                                                                </td>
                                                                <td style="width: 200px;">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Type of Account<font 
                                                            color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:DropDownList ID="ddlType" runat="server" class="form-control txtbox" Height="33px"
                                                                        TabIndex="1" Width="180px">
                                                                       
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlType"
                                                                        ErrorMessage="Please select Type" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr1" runat="server">
                                                                <td style="padding: 5px; margin: 5px">2
                                                                </td>
                                                                <td style="width: 200px;">&nbsp;
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="137px">Notified Date or Since When <font 
                                                            color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp; &nbsp;
                                                                <asp:TextBox ID="txtDate" runat="server" AutoComplete="off" class="form-control txtbox"
                                                                    Height="28px" MaxLength="15" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate"
                                                                        ErrorMessage="Please Select Date" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">3
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Width="165px">Name 
                                                        of the Unit<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                    <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="200" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtUnitName"
                                                                        ErrorMessage="Please Enter Unit Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">4
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label395" runat="server" CssClass="LBLBLACK" Width="165px" data-balloon="Please Select Line of Activity"
                                                                        data-balloon-length="large" data-balloon-pos="down">Sector</asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="custom-select"
                                                                        Height="33px" Width="180px" AutoPostBack="True">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlintLineofActivity"
                                                                        ErrorMessage="Please select Line Of Activity" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">5
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Width="200px">District<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Height="33px" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged"
                                                                        Width="180px">
                                                                        <asp:ListItem>--District--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlProp_intDistrictid"
                                                                        ErrorMessage="Please Select Proposed Location (District)" ValidationGroup="group"
                                                                        InitialValue="--District--">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">6
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label448" runat="server" CssClass="LBLBLACK" Width="200px">Mandal<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlProp_intMandalid" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Height="33px" Width="180px">
                                                                        <asp:ListItem>--Mandal--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlProp_intMandalid"
                                                                        ErrorMessage="Please Select Proposed Location (Mandal)" InitialValue="--Mandal--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                    <td style="width: 27px">
                                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                    </td>
                                                    <td valign="top" class="style6">
                                                        <table cellpadding="4" cellspacing="5" style="width: 100%">

                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">7</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="165px">Mobile No of Unit Holder<font 
                                                            color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtcontact" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="requiredfieldvalidator4" runat="server" ControlToValidate="txtcontact"
                                                                        ErrorMessage="please enter your mobile number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="regularexpressionvalidator1" runat="server" ControlToValidate="txtcontact"
                                                                        ErrorMessage="Mobile number length must be exactly 10 characters" ValidationExpression="[0-9]{10}"
                                                                        ValidationGroup="group">*</asp:RegularExpressionValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">8</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="165px">Email Id of Unit Holder (If Any)<font 
                                                            color="red"></font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtemail" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtemail"
                                                                        ErrorMessage="Please Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                        ValidationGroup="group">*</asp:RegularExpressionValidator></td>
                                                            </tr>

                                                            <tr id="Tr3" runat="server" visible="true">
                                                                <td style="padding: 5px; margin: 5px">9
                                                                </td>
                                                                <td style="width: 200px;">
                                                                    <asp:Label ID="Label440" runat="server" CssClass="LBLBLACK" Width="137px">Loan Sanctioned Date</asp:Label></td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtLoanDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="15" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                        ControlToValidate="txtLoanDate" ErrorMessage="Please Enter Loan Sanctioned Date"
                                                                        ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px">10
                                                                </td>
                                                                <td style="width: 200px;">Loan Sanctioned Amount (More than Rs.5 Lakhs)</td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtLoanAmount" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" Width="180px"></asp:TextBox></td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                            ControlToValidate="txtemail" ErrorMessage="Please Enter Email" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">11
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">Nature of Account<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlnatureofaccount" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                        Height="33px" OnSelectedIndexChanged="ddlnatureofaccount_SelectedIndexChanged"
                                                                        Width="180px">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlnatureofaccount"
                                                                        ErrorMessage="Please Select Nature of Account" ValidationGroup="group"
                                                                        InitialValue="--Select--">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                             <tr id="trotheraccounts" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px">11.a
                                                                </td>
                                                                <td style="width: 200px;">Other</td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtotheraccounts" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" Width="180px"></asp:TextBox></td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                            ControlToValidate="txtemail" ErrorMessage="Please Enter Email" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td style="padding: 5px; margin: 5px">12.
                                                                </td>
                                                                <td style="width: 200px;">Remarks (if Any)</td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtremarks" runat="server" class="form-control txtbox" Height="28px" TextMode="MultiLine" TabIndex="1" Width="180px"></asp:TextBox></td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                            ControlToValidate="txtemail" ErrorMessage="Please Enter Email" 
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                        <asp:Button ID="BtnSave1" runat="server" OnClick="BtnSave1_Click" CssClass="btn btn-primary"
                                                            Height="32px" TabIndex="10" Text="Save"
                                                            Width="90px" ValidationGroup="group" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnclear" runat="server"
                                                            CssClass="btn btn-warning" Height="32px" TabIndex="10"
                                                            Text="clearall" ToolTip="to clear  the screen" Width="90px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>

                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>




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

    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDateofCommencement']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txtNewPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
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
            $("input[id$='txtBridgeLoanDate']").datepicker(
             {
                 dateFormat: "dd/mm/yy",
                 maxDate: new Date(currentYear, currentMonth, currentDate)
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
            $("input[id$='txtDateofCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtNewPowerReleaseDate']").datepicker(
              {
                  dateFormat: "dd/mm/yy",
                  //  maxDate: new Date(currentYear, currentMonth, currentDate)
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
    <style type="text/css">
        .ui at k r font- 8pt; i or eight: 250px; d n 0.2 em 0 dth; 2 px; .auto-style8 {
            height: 29px;
        }

        .auto-style1 {
            height: 27px;
        }
    </style>
</asp:Content>
