<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="ForestTransitPermit.aspx.cs" Inherits="UI_TSiPASS_ForestTransitPermit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDateOfIssue']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDateOfExpiryOfPermit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtRegDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });
    </script>
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
           
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index:9999 !important;
        }
        select
        {
            color: Black !important;
        }
    </style>

    <style>
        .algnCenter
        {
            text-align: center;
        }
    </style>



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

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style6 {
            width: 192px;
        }

        .style7 {
            color: #FF3300;
        }

        .style8 {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">

        <ContentTemplate>

            <div align="left">
                <ol class="breadcrumb">
                    You are here
 &nbsp;!&nbsp; &nbsp; &nbsp; 
                     <li>
                         <i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a>
                     </li>
                    <li class="">
                        <i class="fa fa-fw fa-edit"></i>Forest
                    </li>
                    <li class="active">
                        <i class="fa fa-edit"></i><a href="#">TransitPermit Application</a>
                    </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Forest Transit Form</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="210px">1) Forest Permit Details:</asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="210px">Permit No: <font 
color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtpermitno" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="child" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                    ControlToValidate="txtpermitno" ErrorMessage="Please enter Permit No"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <!-- Details of person-->
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label447" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="502px">2) Details of the person / entity to whom permit is granted: </asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Name: <font 
                color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtName" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="child" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                                    ControlToValidate="txtName" ErrorMessage="Please enter Name"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label396" runat="server" CssClass="LBLBLACK" Width="180px"> Identity card and Number: <font 
     color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtIdentity" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="child" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                    ControlToValidate="txtIdentity" ErrorMessage="Please enter Identity card and Number: "
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label397" runat="server" CssClass="LBLBLACK" Width="165px"> Email: <font 
     color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtemail" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="child" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                    ControlToValidate="txtemail" ErrorMessage="Please enter Email: "
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>

                                                        </tr>

                                                    </table>
                                                </td>



                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label435" runat="server" CssClass="LBLBLACK" Width="165px">Address: <font 
         color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtowneraddress" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="child" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                    ControlToValidate="txtowneraddress" ErrorMessage="Please enter address"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">5&nbsp;</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label436" runat="server" CssClass="LBLBLACK" Width="165px">Mobile No. : <font 
     color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtmobile" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" TabIndex="1"
                                                                    ValidationGroup="child" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                    ControlToValidate="txtmobile" ErrorMessage="Please enter mobile number"
                                                                    ValidationGroup="child">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>



                                            <!--Produce -->
                                            <%--<tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="210px">3) Produce:</asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top">&nbsp;</td>
                                            </tr>--%>
                                            <!--Produce -->
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="165px">
Name of Produce: <font color="red">*</font>
                                                                </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtproduce" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="50" TabIndex="1"
                                                                    ValidationGroup="produce" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                    ControlToValidate="txtproduce" ErrorMessage="Please enter Name of Produce"
                                                                    ValidationGroup="produce">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>



                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top">
                                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="635px">4) Details of Species / Produce: Timber / Poles / Charcoal / Minor Forest Produce / Mineral: </asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top">&nbsp;</td>
                                            </tr>


                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblSpeciesName" runat="server" CssClass="LBLBLACK" Width="210px">
    Name of Species:
                                                                </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlSpeciesName" runat="server" class="form-control"
                                                                    Height="30px" Width="185px">
                                                                    <asp:ListItem Text="--Select Speice--" Value="-1"></asp:ListItem>
                                                                    <asp:ListItem Text="Timber" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Poles" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Charcoal" Value="3"></asp:ListItem>
                                                                    <asp:ListItem Text="Minor Forest Produce" Value="4"></asp:ListItem>
                                                                    <asp:ListItem Text="Mineral" Value="5"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblLogNumber" runat="server" CssClass="LBLBLACK" Width="210px">
    Log Number:
                                                                </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtLogNumber" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="20" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3.</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblGirth" runat="server" CssClass="LBLBLACK" Width="210px">
    Girth (cm):
                                                                </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtGirth" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="10" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>


                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">4.</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblLength" runat="server" CssClass="LBLBLACK" Width="210px">
    Length (cm):
                                                                </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtLength" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="10" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">5.</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblVolumeWeight" runat="server" CssClass="LBLBLACK" Width="210px">
    Volume (cum) / Weight (kg):
                                                                </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtVolumeWeight" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="15" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>


                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center; padding: 10px;">
                                                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" Text="Add" />
                                                </td>
                                            </tr>


                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:GridView ID="gvLogs" runat="server" AutoGenerateColumns="False"
                                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                        CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                        Width="100%" OnRowDeleting="gvLogs_RowDeleting"
                                                        DataKeyNames="SlNo">

                                                        <RowStyle BackColor="#ffffff" />

                                                        <Columns>

                                                            <asp:BoundField DataField="SlNo" HeaderText="Sl No." />
                                                            <asp:BoundField DataField="SpeciesName" HeaderText="Name of Species" />
                                                            <asp:BoundField DataField="LogNumber" HeaderText="Log Number" />
                                                            <asp:BoundField DataField="Girth" HeaderText="Girth (cm)" />
                                                            <asp:BoundField DataField="Length" HeaderText="Length (cm)" />
                                                            <asp:BoundField DataField="VolumeOrWeight" HeaderText="Volume (cum) / Weight (kg)" />
                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red"
                                                                ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />
                                                        </Columns>

                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#013161" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top">
                                                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                        Width="698px">5) Route(s) by which timber of indicated species / produces will be transported : </asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;</td>
                                                <td valign="top">&nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblState" runat="server" CssClass="LBLBLACK" Width="210px">
                        State:
                                                                </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtState" runat="server" class="form-control"
                                                                    Height="28px" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                                            <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblBarriers" runat="server" CssClass="LBLBLACK" Width="210px">
                        Barriers:
                                                                </asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtBarriers" runat="server" class="form-control"
                                                                    Height="28px" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2" style="text-align: center; padding: 10px;">
                                                    <asp:Button ID="btnAddBarrier" runat="server" CssClass="btn btn-primary"
                                                        OnClick="btnAddBarrier_Click" Text="Add Barrier" />
                                                </td>
                                            </tr>



                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top" colspan="3">
                                                    <asp:GridView ID="gvBarriers" runat="server" AutoGenerateColumns="False" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                                        OnRowDeleting="gvBarriers_RowDeleting" DataKeyNames="SlNo" ForeColor="#333333" GridLines="None" Width="100%">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>

                                                            <asp:BoundField DataField="SlNo" HeaderText="Sl No." />
                                                            <asp:BoundField DataField="State" HeaderText="State" />
                                                            <asp:BoundField DataField="Barriers" HeaderText="Barriers" />
                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                            <asp:CommandField ControlStyle-Font-Bold="true" ControlStyle-ForeColor="Red" DeleteText="DELETE" HeaderText="DELETE" ShowDeleteButton="True" />
                                                        </Columns>
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#013161" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px;" valign="top">
                                                        <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="698px">6) Vehicle Detials : </asp:Label>
                                                    </td>
                                                    <td style="width: 27px">&nbsp;</td>
                                                    <td valign="top">&nbsp;</td>
                                                </tr>
                                                <!--vehicle-->
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblVehicleType" runat="server" CssClass="LBLBLACK" Width="210px">
            Type of Vehicle with Registration Number: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtVehicleType" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="8" ValidationGroup="vehicle" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="rfvVehicleType" runat="server" ControlToValidate="txtVehicleType" ErrorMessage="Please enter Type of Vehicle with Registration Number" ValidationGroup="vehicle">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">7</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblDriverName" runat="server" CssClass="LBLBLACK" Width="210px">
            Name of the Driver: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtDriverName" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="driver" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                    <asp:RequiredFieldValidator ID="rfvDriverName" runat="server" ControlToValidate="txtDriverName" ErrorMessage="Please enter Name of the Driver" ValidationGroup="driver">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">8</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblDriverLicense" runat="server" CssClass="LBLBLACK" Width="165px">
            Driving License No. of the Driver: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtDriverLicense" runat="server" class="form-control txtbox" Height="28px" MaxLength="20" TabIndex="1" ValidationGroup="license" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvDriverLicense" runat="server" ControlToValidate="txtDriverLicense" ErrorMessage="Please enter Driving License No. of the Driver" ValidationGroup="license">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <!--Where Obtained-->
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="502px">9) Where Obtained </asp:Label>
                                                    </td>
                                                    <td style="width: 27px">&nbsp;</td>
                                                    <td valign="top">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">a)</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblCompartmentNo" runat="server" CssClass="LBLBLACK" Width="165px">
Compartment No.: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtCompartmentNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="20" TabIndex="1" ValidationGroup="compartment" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvCompartmentNo" runat="server" ControlToValidate="txtCompartmentNo" ErrorMessage="Please enter Compartment No." ValidationGroup="compartment">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">b) </td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblCircleWhereObtained" runat="server" CssClass="LBLBLACK" Width="165px">
            Circle: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtCircleWhereObtained" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="6" ValidationGroup="circleWhereObtained" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvCircleWhereObtained" runat="server" ControlToValidate="txtCircleWhereObtained" ErrorMessage="Please enter Circle" ValidationGroup="circleWhereObtained">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">c) </td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblDivisionWhereObtained" runat="server" CssClass="LBLBLACK" Width="165px">
            Division: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtDivisionWhereObtained" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="7" ValidationGroup="divisionWhereObtained" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvDivisionWhereObtained" runat="server" ControlToValidate="txtDivisionWhereObtained" ErrorMessage="Please enter Division" ValidationGroup="divisionWhereObtained">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">d)</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblRangeWhereObtained" runat="server" CssClass="LBLBLACK" Width="165px">
            Range: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtRangeWhereObtained" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="8" ValidationGroup="rangeWhereObtained" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvRangeWhereObtained" runat="server" ControlToValidate="txtRangeWhereObtained" ErrorMessage="Please enter Range" ValidationGroup="rangeWhereObtained">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">e) </td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblAddressWhereObtained" runat="server" CssClass="LBLBLACK" Width="165px">
            Address: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtAddressWhereObtained" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="9" ValidationGroup="addressWhereObtained" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvAddressWhereObtained" runat="server" ControlToValidate="txtAddressWhereObtained" ErrorMessage="Please enter Address" ValidationGroup="addressWhereObtained">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <!--Destination-->
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="502px">10) Destination: </asp:Label>
                                                    </td>
                                                    <td style="width: 27px">&nbsp;</td>
                                                    <td valign="top">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">a) </td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblDestination" runat="server" CssClass="LBLBLACK" Width="165px">
State: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtstateDestination" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="5" ValidationGroup="whereDestination" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvWhereDestination" runat="server" ControlToValidate="txtstateDestination" ErrorMessage="Please enter Destination State" ValidationGroup="whereDestination">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">b) </td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblCircle" runat="server" CssClass="LBLBLACK" Width="165px">
Circle: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtdestCircle" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="1" ValidationGroup="circle" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvCircle" runat="server" ControlToValidate="txtdestCircle" ErrorMessage="Please enter Circle" ValidationGroup="circle">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">c)</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblDivision" runat="server" CssClass="LBLBLACK" Width="165px">
Division: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtdestDivision" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="2" ValidationGroup="division" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvDivision" runat="server" ControlToValidate="txtdestDivision" ErrorMessage="Please enter Division" ValidationGroup="division">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">d) </td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblRange" runat="server" CssClass="LBLBLACK" Width="165px">
Range: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtdestRange" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="3" ValidationGroup="range" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvRange" runat="server" ControlToValidate="txtdestRange" ErrorMessage="Please enter Range" ValidationGroup="range">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">e)</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblAddress" runat="server" CssClass="LBLBLACK" Width="165px">
Address: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtdestAddress" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="4" ValidationGroup="address" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtdestAddress" ErrorMessage="Please enter Address" ValidationGroup="address">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <!--Date-->
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">11</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblDateOfIssue" runat="server" CssClass="LBLBLACK" Width="165px">
            Date of Issue: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtDateOfIssue" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="50" TabIndex="10"
                                                                        ValidationGroup="dateOfIssue" Width="180px"></asp:TextBox>


                                                                </td>
                                                                <%--<ajaxToolkit:CalendarExtender ID="calDateOfIssue" runat="server"
                                                                    TargetControlID="txtDateOfIssue"
                                                                    Format="yyyy-MM-dd">
                                                                </ajaxToolkit:CalendarExtender>--%>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvDateOfIssue" runat="server" ControlToValidate="txtDateOfIssue" ErrorMessage="Please enter Date of Issue" ValidationGroup="dateOfIssue">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">12</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblDateOfExpiryOfPermit" runat="server" CssClass="LBLBLACK" Width="165px">
            Date of Expiry of Permit: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtDateOfExpiryOfPermit" runat="server" class="form-control txtbox"
                                                                        Height="28px" MaxLength="50" TabIndex="11"
                                                                        ValidationGroup="dateOfExpiryOfPermit" Width="180px"></asp:TextBox>


                                                                </td>

                                                                <%--<ajaxToolkit:CalendarExtender ID="calDateOfExpiryOfPermit" runat="server"
                                                                    TargetControlID="txtDateOfExpiryOfPermit"
                                                                    Format="yyyy-MM-dd">
                                                                </ajaxToolkit:CalendarExtender>--%>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvDateOfExpiryOfPermit" runat="server" ControlToValidate="txtDateOfExpiryOfPermit" ErrorMessage="Please enter Date of Expiry of Permit" ValidationGroup="dateOfExpiryOfPermit">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">13</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblImprintOfTransitMark" runat="server" CssClass="LBLBLACK" Width="165px">
            Imprint of Transit Mark: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtImprintOfTransitMark" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="12" ValidationGroup="imprintOfTransitMark" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvImprintOfTransitMark" runat="server" ControlToValidate="txtImprintOfTransitMark" ErrorMessage="Please enter Imprint of Transit Mark" ValidationGroup="imprintOfTransitMark">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <!--Details Of Authority-->
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="502px">Details Of Authority Issuing the Permit: </asp:Label>
                                                    </td>
                                                    <td style="width: 27px">&nbsp;</td>
                                                    <td valign="top">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">a)</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblDesignationOfOfficial" runat="server" CssClass="LBLBLACK" Width="165px">
            Designation of Official: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtDesignationOfOfficial" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="13" ValidationGroup="designationOfOfficial" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvDesignationOfOfficial" runat="server" ControlToValidate="txtDesignationOfOfficial" ErrorMessage="Please enter Designation of Official" ValidationGroup="designationOfOfficial">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">b)</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblOfficeAddress" runat="server" CssClass="LBLBLACK" Width="165px">
            Office Address: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtOfficeAddress" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="14" ValidationGroup="officeAddress" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvOfficeAddress" runat="server" ControlToValidate="txtOfficeAddress" ErrorMessage="Please enter Office Address" ValidationGroup="officeAddress">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">c)</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblOfficialTelephoneMobile" runat="server" CssClass="LBLBLACK" Width="165px">
Official Telephone No. / Mobile No.: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtOfficialTelephoneMobile" runat="server" class="form-control txtbox" Height="28px" MaxLength="15" TabIndex="15" ValidationGroup="officialTelephoneMobile" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvOfficialTelephoneMobile" runat="server" ControlToValidate="txtOfficialTelephoneMobile" ErrorMessage="Please enter Official Telephone No. / Mobile No." ValidationGroup="officialTelephoneMobile">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">d)</td>
                                                                <td class="style8" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="lblOfficialEmail" runat="server" CssClass="LBLBLACK" Width="165px">
            Official Email: <font color="red">*</font>
                                                                    </asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:</td>
                                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtOfficialEmail" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="16" ValidationGroup="officialEmail" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="rfvOfficialEmail" runat="server" ControlToValidate="txtOfficialEmail" ErrorMessage="Please enter Official Email" ValidationGroup="officialEmail">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="style7" colspan="3" style="padding: 5px; margin: 5px">&nbsp;<tr>
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px">&nbsp;</td>
                                                    </tr>
                                                        <caption>
                                                            &nbsp;</caption>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
                                                        &nbsp;
                                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Save" ValidationGroup="child" Width="90px" OnClick="BtnSave1_Click" />
                                                        &nbsp;
                                                        <asp:Button ID="btnPrevious" runat="server" CausesValidation="False" CssClass="btn btn-danger" Height="32px" TabIndex="10" Text="Previous" Width="90px" OnClick="btnPrevious_Click" />
                                                        &nbsp;<asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px" TabIndex="10" Text="Next" ValidationGroup="child" Width="90px" OnClick="btnNext_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        <div id="success" runat="server" class="alert alert-success" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" href="AddQualification.aspx">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <br />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
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
</asp:Content>


