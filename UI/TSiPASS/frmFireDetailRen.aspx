<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmFireDetailRen.aspx.cs" Inherits="UI_TSIPASS_frmFireDetailRen" %>

 
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

        .LBLBLACK {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>


    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8) {
                return true;
            }
            return false;
        }

    </script>

    <%--  <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
            <li class="">
                <i class="fa fa-fw fa-edit">CAF</i>
            </li>
            <li class="active">
                <i class="fa fa-edit"></i><a href="#">Fire Details</a>
            </li>
        </ol>
    </div>

    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" align="center">
                        <h3 class="panel-title">Fire Renewal Details</h3>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="200px">Height of the building (in mtrs.)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtHight_Building" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtHight_Building"
                                                    ErrorMessage="Please Enter Height of the Building" ValidationGroup="group">*</asp:RequiredFieldValidator>
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
                                            <td style="padding: 5px; margin: 5px" valign="top">2.</td>
                                            <td style="width: 200px;">
                                                <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="200px">Height of each floor (in mtrs.)<font 
                                                            color="red">*</font><br /> (min 2.9 mtrs)</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtHight_EachFloor" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtHight_EachFloor"
                                                    ErrorMessage="Please Enter Height of Each Floor" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                            <td style="width: 200px;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="280px"
                                        Font-Bold="True">A) Means of Escape</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="200px">Stair Cases <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlstaire" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Internal Stair Cases</asp:ListItem>
                                                    <asp:ListItem Value="2">External Stair Cases</asp:ListItem>
                                                    <asp:ListItem Value="3">Exits</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                    ControlToValidate="ddlstaire"
                                                    ErrorMessage="Please Select Type Of Stair Cases" InitialValue="--Select--"
                                                    ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label29" runat="server" CssClass="LBLBLACK" Width="200px">No. of Stair Cases <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtNofStairecases" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtcontact13_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                    ControlToValidate="txtNofStairecases"
                                                    ErrorMessage="Please Enter Width of Stair Cases" ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <%--   <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Internal Stair Cases (min 2) <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtInter_Stairs" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtInter_Stairs"
                                                    ErrorMessage="Please Enter Internal Stair Cases" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label429" runat="server" CssClass="LBLBLACK" Width="200px">External Stair Cases (min 1) <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtExernal_Stairs" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtcontact27_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="txtExernal_Stairs"
                                                    ErrorMessage="Please Enter External Stair Cases" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3.&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="165px">Width of Stair Case<br />(min 1)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtWidth_Stairs" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="txtWidth_Stairs"
                                                    ErrorMessage="Please Enter Width of Stair Cases" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label411" runat="server" CssClass="LBLBLACK" Width="200px">Width of Stair Case <font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtWidth_Stairs1" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtcontact13_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                    ControlToValidate="txtWidth_Stairs1"
                                                    ErrorMessage="Please Enter Width of Stair Cases" ValidationGroup="group1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <%--  <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label416" runat="server" CssClass="LBLBLACK" Width="165px">No Of Exits<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtNoofExits" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="NumberOnly()" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"
                                                    OnTextChanged="txtNoofExits_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="txtNoofExits" ErrorMessage="Please Enter Number of Exists"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label417" runat="server" CssClass="LBLBLACK" Width="165px">Width of each exit (in mts.)<br />(min 4.5 mtrs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtWidth_eachExit" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="txtWidth_eachExit"
                                                    ErrorMessage="Please Enter Width of each exit" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr2" runat="server">

                                <td style="padding: 5px; margin: 5px" colspan="10" align="center">
                                    <asp:Button ID="BtnSave2" runat="server" CssClass="btn btn-xs btn-warning"
                                        Height="28px" TabIndex="10" Text="Add" ValidationGroup="group1"
                                        Width="72px" OnClick="BtnSave2_Click1" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear0" runat="server" CausesValidation="False" Visible="false"
                                        CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="10" Text="Cancel"
                                        ToolTip="To Clear  the Screen" Width="73px" OnClick="BtnClear0_Click2" /></td>
                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="10">
                                    <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                        CssClass="GRD" ForeColor="#333333" GridLines="Both"
                                        OnRowDataBound="gvCertificate_RowDataBound"
                                        OnRowDeleting="gvCertificate_RowDeleting" Width="100%">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                            <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />
                                            <asp:BoundField DataField="Stairecase" HeaderText="Stair Case" />
                                            <asp:BoundField DataField="Width" HeaderText="Width Of Stair Case" />
                                            <asp:BoundField DataField="NoofStairecases" HeaderText="No. Of Stair Cases" />
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstaireid" runat="server" Text='<%# Bind("staireid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="375px"
                                        Font-Bold="True">B) Open spaces all around the building: (in mts)</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="200px">East (min 6 mtrs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtFire_East" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    ControlToValidate="txtFire_East"
                                                    ErrorMessage="Please Enter Spaces all around the building in East"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">West (min 6 mtrs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtFire_West" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                    ControlToValidate="txtFire_West"
                                                    ErrorMessage="Please Enter Spaces all around the building in West"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">North (min 6 mtrs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtFire_North" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                    ControlToValidate="txtFire_South"
                                                    ErrorMessage="Please Enter Spaces all around the building in North"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="165px">South (min 6 mtrs)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtFire_South" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="8" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                    ControlToValidate="txtFire_East"
                                                    ErrorMessage="Please Enter Spaces all around the building in South"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="165px">Level of the ground<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:DropDownList ID="ddlLevel_ground" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Not Levelled</asp:ListItem>
                                                    <asp:ListItem Value="2">Levelled</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                    ControlToValidate="ddlLevel_ground"
                                                    ErrorMessage="Please Select Level of Ground" InitialValue="--Select--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="200px">Fire Detection System (Automatic)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFire_Detection" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>Heat</asp:ListItem>
                                                    <asp:ListItem>Smoke</asp:ListItem>
                                                    <asp:ListItem>Gas</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                    ControlToValidate="ddlFire_Detection"
                                                    ErrorMessage="Please Select Fire Detection System" InitialValue="--Select--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label425" runat="server" CssClass="LBLBLACK" Width="200px">Fire Alarm System<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFire_Alaram" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>Automatic</asp:ListItem>
                                                    <asp:ListItem>Manual</asp:ListItem>
                                                    <asp:ListItem>Break Glass Type</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                    ControlToValidate="ddlFire_Alaram"
                                                    ErrorMessage="Please Select File Alarm System" InitialValue="--Select--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">8.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label24" runat="server" CssClass="LBLBLACK" Width="200px">Front Side Direction<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlfrontsidedir" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="East">East</asp:ListItem>
                                                    <asp:ListItem Value="West">West</asp:ListItem>
                                                    <asp:ListItem Value="North">North</asp:ListItem>
                                                    <asp:ListItem Value="South">South</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="ddlfrontsidedir"
                                                    ErrorMessage="Please Select Front Side Direction" InitialValue="--Select--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>


                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="375px"
                                        Font-Bold="True">C) Fire Fighting System:</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="200px">Sprinkler<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RadioButtonList ID="rblSprinkler" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server"
                                                    ControlToValidate="rblSprinkler" ErrorMessage="Please Select Sprinkler"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">Hose Reel<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rblHoseReel" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server"
                                                    ControlToValidate="rblHoseReel" ErrorMessage="Please Select Hose Reel"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px">Fire Extingishers<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rblCO2" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server"
                                                    ControlToValidate="rblCO2" ErrorMessage="Please SelectCO2"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="165px">Wet Riser<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rblWetRiser" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px"
                                                    OnSelectedIndexChanged="RadioButtonList14_SelectedIndexChanged"
                                                    TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server"
                                                    ControlToValidate="rblWetRiser" ErrorMessage="Please Select Wet Riser"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label426" runat="server" CssClass="LBLBLACK" Width="200px">Down Corner<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rblDownCorner" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server"
                                                    ControlToValidate="rblDownCorner"
                                                    ErrorMessage="Please Select Down Corner" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label28" runat="server" CssClass="LBLBLACK" Width="200px">Yard Hydrant<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rdbYardHydrant" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                    ControlToValidate="rdbYardHydrant"
                                                    ErrorMessage="Please Select Yard Hydrant" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">7.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label427" runat="server" CssClass="LBLBLACK" Width="200px">Manually Operated electrical fire alaram system<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <%--<asp:TextBox ID="txtUnder_ground" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px" OnTextChanged="TextBox9_TextChanged"></asp:TextBox>--%>
                                                <asp:RadioButtonList ID="rdbManuallyOperated" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server"
                                                    ControlToValidate="rdbManuallyOperated"
                                                    ErrorMessage="Please Select Manually Operated electrical fire alaram system"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">8.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="200px">Automatic Detection System<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <%--<asp:TextBox ID="txtCourt_yard_hydrants" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:RadioButtonList ID="rdbDetectionSystem" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                                    ControlToValidate="rdbDetectionSystem"
                                                    ErrorMessage="Please Select Automatic Detection System"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">9.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="200px">Under ground water sump<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%-- <asp:TextBox ID="txtFire_pumps_Electrical_15" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:RadioButtonList ID="rdbgroundwatersump" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                    ControlToValidate="rdbgroundwatersump"
                                                    ErrorMessage="Please Enter Under Ground Water Sump"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">10.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="200px">Terrace Tank<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:TextBox ID="txtFire_pumps_Diesel" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:RadioButtonList ID="rdbTerraceTank" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                    ControlToValidate="rdbTerraceTank"
                                                    ErrorMessage="Please Select Terrace Tank" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">11.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label428" runat="server" CssClass="LBLBLACK" Width="200px">Terrace Pumps<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:TextBox ID="txtFire_pumps_Electrical_30" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:RadioButtonList ID="rdbTerracePumps" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server"
                                                    ControlToValidate="rdbTerracePumps"
                                                    ErrorMessage="Please Select Terrace Pumps"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">12.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="200px">Electrical pumps<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:TextBox ID="txtFire_pumps_Electrical_30" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:RadioButtonList ID="rdbElectricalpumps" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    ControlToValidate="rdbElectricalpumps"
                                                    ErrorMessage="Please Select Electrical pumps"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">13.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="200px">Diesel Pumps<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:TextBox ID="txtFire_pumps_Electrical_30" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:RadioButtonList ID="rdbDieselPumps" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="rdbDieselPumps"
                                                    ErrorMessage="Please Select Diesel pumps"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">14.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label27" runat="server" CssClass="LBLBLACK" Width="200px">Jockey Pumps<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:TextBox ID="txtFire_pumps_Electrical_30" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:RadioButtonList ID="rdbJockeyPumps" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                    ControlToValidate="rdbJockeyPumps"
                                                    ErrorMessage="Please Select Jockey Pumps"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>


                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="375px"
                                        Font-Bold="True">D) Other protection measures:</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px">45 Ltrs. From Trolley<font 
                                                            color="red">*</font></asp:Label>--%>
                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="200px">Transformer Safety Provided<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RadioButtonList ID="rblTrolley_45" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
                                                    ControlToValidate="rblTrolley_45"
                                                    ErrorMessage="Please Select Transformer Safety Provided" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="165px">Fencing<font 
                                                            color="red">*</font></asp:Label>--%>
                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="165px">Fire Lifts Provided<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <%-- <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rblFencing" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px"
                                                    OnSelectedIndexChanged="RadioButtonList17_SelectedIndexChanged"
                                                    TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server"
                                                    ControlToValidate="rblFencing" ErrorMessage="Please Select Fencing"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>--%>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFireLiftsProvided" runat="server" class="form-control txtbox"
                                                    Height="33px" Width="180px" TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server"
                                                    ControlToValidate="ddlFireLiftsProvided"
                                                    ErrorMessage="Please Select Fire Lifts Provided" InitialValue="--Select--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%--<asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="165px">Soak pit<font 
                                                            color="red">*</font></asp:Label>--%>
                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="226px">Air Conditioning Safety Provided<font 
                                                            color="red">*</font></asp:Label>

                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rblSoakPit" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px"
                                                    OnSelectedIndexChanged="RadioButtonList18_SelectedIndexChanged"
                                                    TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server"
                                                    ControlToValidate="rblSoakPit" ErrorMessage="Please Select Air Conditioning Safety Provided"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="200px">Lightening protection<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">: 
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rblLightning_Prot" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px"
                                                    OnSelectedIndexChanged="RadioButtonList19_SelectedIndexChanged"
                                                    TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server"
                                                    ControlToValidate="rblLightning_Prot"
                                                    ErrorMessage="Please Select Lightening Protection" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="200px">Control Room<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:RadioButtonList ID="rblCont_Room" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server"
                                                    ControlToValidate="rblCont_Room" ErrorMessage="Please Select Control Room"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">6.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Width="200px">Whether the Hydraulic Platform can be moved all around the bldg<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:RadioButtonList ID="rblHydraulic_Platform" runat="server"
                                                    RepeatDirection="Horizontal" Width="200px" TabIndex="1">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server"
                                                    ControlToValidate="rblHydraulic_Platform"
                                                    ErrorMessage="Please Select Hydraulic Platform can be moved all around the bldg"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                                      <tr>
                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                    <asp:Label ID="Label31" runat="server" CssClass="LBLBLACK" Width="375px"
                                        Font-Bold="True">E) Renewal Details:</asp:Label>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5" class="auto-style1">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label33" runat="server" CssClass="LBLBLACK" Width="200px">Occupancy NOC File No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <asp:TextBox ID="txtOCFileno" runat="server" class="form-control txtbox" Height="28px" MaxLength="50"    TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server"
                                                    ControlToValidate="rblSprinkler" ErrorMessage="Please Select Sprinkler"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label35" runat="server" CssClass="LBLBLACK" Width="165px">Latest Renewal NOC, if any File No<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtLatfileNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server"
                                                    ControlToValidate="rblHoseReel" ErrorMessage="Please Select Hose Reel"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        
                                        
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label43" runat="server" CssClass="LBLBLACK" Width="200px">Fee (in Rs.)<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:TextBox ID="txtOCfee" runat="server" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server"
                                                    ControlToValidate="rdbYardHydrant"
                                                    ErrorMessage="Please Select Yard Hydrant" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                         
                                    </table>
                                </td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">
                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label45" runat="server" CssClass="LBLBLACK" Width="200px">Occupancy NOC Issued Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                <%--<asp:TextBox ID="txtCourt_yard_hydrants" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtOCDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server"
                                                    ControlToValidate="rdbDetectionSystem"
                                                    ErrorMessage="Please Select Automatic Detection System"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label46" runat="server" CssClass="LBLBLACK" Width="200px">Latest Renewal NOC, if any Issued Date<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <%-- <asp:TextBox ID="txtFire_pumps_Electrical_15" runat="server" class="form-control txtbox"
                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                    ValidationGroup="group" Width="180px"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtRenOCDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server"
                                                    ControlToValidate="rdbgroundwatersump"
                                                    ErrorMessage="Please Enter Under Ground Water Sump"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                         <td></td>
                                        </tr>
                                        
                                        
                                        
                                        
                                    </table>
                                </td>
                            </tr>


                            <tr>
                                <td style="padding: 5px; margin: 5px" valign="top"><strong>F) Fire Fighting Drawings/Plans :</strong></td>
                                <td style="width: 27px">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table style="width: 60%">
                                                                                
                                        
                                        
                                        
                                        
                                        
                                        
                                        <tr runat="server" id="tr10" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label41" runat="server" CssClass="LBLBLACK" Width="210px">Upload Latest Renewal Copy<font 
                                                            color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="flLatRenewalCopy" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hplLatestRenewal" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblLatestRenewal" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="btnLatestRenewal" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="btnLatestRenewal_Click" />
                                            </td>
                                        </tr>
                                        <tr runat="server" id="tr8" visible="true">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2.</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label42" runat="server" CssClass="LBLBLACK" Width="210px">Upload Occupancy</asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FileUploadfireOtherPlans" runat="server" class="form-control txtbox"
                                                    Height="28px" />

                                                <asp:HyperLink ID="hpOtherPlans" runat="server" CssClass="LBLBLACK" Width="165px"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblOtherPlans" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                <asp:Button ID="Button7" runat="server" CssClass="btn btn-xs btn-warning"
                                                    Height="28px" TabIndex="10" Text="Upload"
                                                    Width="72px" OnClick="Button7_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center" class="style7">&nbsp;<tr>
                                    <td style="padding: 5px; margin: 5px" colspan="3" align="center">&nbsp;</td>
                                </tr>
                                    <caption>
                                        &nbsp;</caption>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="ClearAll" ToolTip="To Clear  the Screen" ValidationGroup="group"
                                        Width="90px" /> &nbsp;&nbsp;
                                   
                                    <asp:Button ID="BtnSave1" runat="server" CausesValidation="False"
                                        CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="10"
                                        Text="Save" ValidationGroup="group" Width="90px" /> &nbsp; &nbsp;
                                   
                                            <asp:Button ID="btnNext0" runat="server"
                                                CssClass="btn btn-danger" Height="32px" OnClick="btnNext0_Click" TabIndex="10"
                                                Text="Previous"
                                                Width="90px" /> &nbsp; &nbsp;   <asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger"
                                        Height="32px" OnClick="btnNext_Click" TabIndex="10" Text="Next"
                                        ValidationGroup="group" Width="90px" /> 
                                   
                                   
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">


                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>


                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                        <asp:ValidationSummary ID="ValidationSummary3" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group1" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                        <br />
                        <asp:HiddenField ID="hdfpencode" runat="server" />
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>

    </div>
    <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>


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

        <script type="text/javascript">
         function pageLoad() {
             var date = new Date();
             var currentMonth = date.getMonth();
             var currentDate = date.getDate();
             var currentYear = date.getFullYear();

             $("input[id$='txtOCDate']").datepicker(
                 {
                     dateFormat: "dd/mm/yy",
                     //  maxDate: new Date(currentYear, currentMonth, currentDate)
                 });
             $("input[id$='txtRenOCDate']").datepicker(
                 {
                     dateFormat: "dd/mm/yy",
                     //  maxDate: new Date(currentYear, currentMonth, currentDate)
                 });
         }
             </script>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>

