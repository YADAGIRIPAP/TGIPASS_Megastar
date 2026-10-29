<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmLegalAct_New.aspx.cs" Inherits="UI_TSiPASS_frmLegalAct_New" %>


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

        .update
        {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style6
        {
            width: 192px;
        }

        .style7
        {
            color: #FF3300;
        }

        .style8
        {
        }

        .LBLBLACK
        {
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

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
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8) {
                return true;
            }
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
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
                    <li class="">
                        <i class="fa fa-fw fa-edit">CAF</i>
                    </li>
                    <li class="active">
                        <i class="fa fa-edit"></i><a href="#">Legal Metrology Details</a>
                    </li>
                </ol>
            </div>

            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Legal Metrology Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                          <%--  <tr>
                                                <td colspan="3" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <asp:Label ID="Label437" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                                        Width="210px">Registration Firm Details</asp:Label>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                            </tr>--%>

                                            <tr>
                                                <%--<td>
                                                    <table >
                                                        <tr>--%>
                                                            <td valign="middle">Application for Registration as a :
                                                            </td>
                                                            <%--  <td style="padding: 5px; margin: 5px">&nbsp;</td>--%>
                                                            <td style="padding: 5px; margin: 5px;text-align:left">
                                                                <asp:ListBox ID="lstRegistrationas" runat="server" SelectionMode="Multiple"></asp:ListBox></td>
                                                              <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        <%--</tr>
                                                    </table>
                                                </td>--%>


                                            </tr>
                                            <tr>
                                                <td >Date of Commencement of Pre-packing/Importing</td>
                                               <%-- <td style="padding: 5px; margin: 5px">:</td>--%>
                                                <td style="padding: 5px; margin: 5px;text-align:left">
                                                    <asp:TextBox ID="txtDateofCommenceAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateofCommenceAct1">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                            </tr>
                                            <tr runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="210px">Door No. <font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtFirmDoorNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirmDoorNo"
                                                                    ErrorMessage="Please enter Firm Door No" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Mandal</td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">

                                                                <asp:DropDownList ID="ddlFirmMandal0" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlFirmMandal_SelectedIndexChanged" Width="180px" InitialValue="--Mandal--">
                                                                    <asp:ListItem>--Mandal--</asp:ListItem>
                                                                </asp:DropDownList>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlFirmMandal0"
                                                                    ErrorMessage="Please Select Firm Mandal" ValidationGroup="group" InitialValue="--Mandal--">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Pin Code</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtFirmPincode" runat="server" class="form-control txtbox" Height="28px" MaxLength="6" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"  onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Email Id</td>
                                                            <td style="padding: 5px; margin: 5px">:</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEmailId0" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">District<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlFirmDistrict" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlFirmDistrict_SelectedIndexChanged" Width="180px">
                                                                    <asp:ListItem>--District--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFirmDistrict" InitialValue="--District--"
                                                                    ErrorMessage="Please select Firm District" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td style="width: 200px;">Village/Area</td>
                                                            <td style="padding: 5px; margin: 5px">: </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:DropDownList ID="ddlFirmVillage" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                                    <asp:ListItem>--Village--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlFirmVillage" ErrorMessage="Please select Village" InitialValue="--Village--" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 200px;">Landline Number</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtFirmLandLine0" runat="server"  onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" Height="28px" MaxLength="13" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>


                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <table align="left" cellpadding="10" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                                                    Width="285px">Proprietors/Partners/Directors Details</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                <table width="90%">
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:GridView ID="gvDirector" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvDirector_RowCommand" OnRowDataBound="gvDirector_RowDataBound">
                                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Sl No.">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Partner/Director Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtDirectorName" runat="server" class="form-control txtbox" ></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="House No/Door No.">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtDirectorDoorNo" runat="server" class="form-control txtbox" ></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="District">
                                                                                        <ItemTemplate>
                                                                                            <asp:DropDownList ID="ddlDirectorDistrict" runat="server" AutoPostBack="true" lass="form-control txtbox"  OnSelectedIndexChanged="ddlDirectorDistrict_SelectedIndexChanged">
                                                                                                <asp:ListItem Value="0">--District--</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Mandal">
                                                                                        <ItemTemplate>
                                                                                            <asp:DropDownList ID="ddlDirectorMandal" runat="server" lass="form-control txtbox"  AutoPostBack="true" OnSelectedIndexChanged="ddlDirectorMandal_SelectedIndexChanged">
                                                                                                <asp:ListItem Value="0">--Mandal--</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Village">
                                                                                        <ItemTemplate>
                                                                                            <asp:DropDownList ID="ddlDirectorVillage" lass="form-control txtbox"  runat="server">
                                                                                                <asp:ListItem Value="0">--Village--</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Pin Code">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtDirectorPincode" runat="server" MaxLength="6"  class="form-control txtbox"  onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField Visible="false" HeaderText="Aadhar Number">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtadhar1" onpaste="return false" runat="server" MaxLength="4" Width="45px"></asp:TextBox>
                                                                                            <asp:TextBox ID="txtadhar2" onpaste="return false" runat="server" MaxLength="4" Width="45px"></asp:TextBox>
                                                                                            <asp:TextBox onblur="validateVerhoeff()" ID="txtadhar3" onpaste="return false" runat="server"
                                                                                                MaxLength="4" Width="45px"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:ButtonField CommandName="Add" Text="Add">
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:ButtonField>
                                                                                    <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:ButtonField>
                                                                                </Columns>
                                                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                                <EditRowStyle BackColor="#B9D684" />
                                                                                <AlternatingRowStyle BackColor="White" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                        <%-- <td></td>

                                                                        <td></td>
                                                                        <td></td>--%>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <table align="left" cellpadding="10" cellspacing="5" style="width: 83%">
                                                        <%-- <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">&nbsp;</td>
                                                        </tr>--%>
                                                        <%--  <tr>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                                                    Width="210px">Premises Details</asp:Label></td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                        </tr>--%>
                                                        <tr runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Premises Name</td>
                                                                        <td style="padding: 5px; margin: 5px">:
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                            <asp:TextBox ID="txtPremisesName0" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPremisesName0"
                                                                                ErrorMessage="Please enter Premises Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">District</td>
                                                                        <td style="padding: 5px; margin: 5px">:
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">

                                                                            <asp:DropDownList ID="ddlPremisesDistrict" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlPremisesDistrict_SelectedIndexChanged" Width="180px">
                                                                                <asp:ListItem>--District--</asp:ListItem>
                                                                            </asp:DropDownList>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlPremisesDistrict"
                                                                                ErrorMessage="Please select Premises District" ValidationGroup="group" InitialValue="--District--">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Village</td>
                                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlPremisesVillage" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Land Line No.</td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtPremisesLandLine0" runat="server" class="form-control txtbox" Height="28px" MaxLength="13" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                    </tr>

                                                                </table>
                                                            </td>
                                                            <td style="width: 27px">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                            </td>
                                                            <td valign="top" runat="server" visible="false">
                                                                <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">House No./Door No.</td>
                                                                        <td style="padding: 5px; margin: 5px">:
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtPremisesDoorNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPremisesDoorNo"
                                                                                ErrorMessage="Please enter Premises Door No." ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 200px;">Mandal</td>
                                                                        <td style="padding: 5px; margin: 5px">:
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:DropDownList ID="ddlPremisesMandal" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" OnSelectedIndexChanged="ddlPremisesMandal_SelectedIndexChanged" Width="180px">
                                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlPremisesMandal"
                                                                                ErrorMessage="Please enter PinCode number" ValidationGroup="group" InitialValue="--Mandal--">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 200px;">Pincode</td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:TextBox ID="txtPremisesPincode" runat="server" class="form-control txtbox" Height="28px" MaxLength="6" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 200px;">Short Address (If any applied for Registration Under Rule 36)</td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:TextBox ID="txtShortAddress" runat="server" class="form-control txtbox" Height="28px" MaxLength="150" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateofCommenceAct1">
                                                                            </cc1:CalendarExtender>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                    </tr>

                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Trade License of municipality or Gram Panchayat</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtTradeLicense0" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Label Details</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtLabelDetails" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 200px;">TIN Number (Issued by Sales Tax Department)</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:TextBox ID="txtTinNo0" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="3" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <table align="left" cellpadding="10" cellspacing="5" style="width: 83%">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                                                    Width="210px">Brand Details</asp:Label></td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                                <table width="90%">
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:GridView ID="gvBrandDtls" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvBrandDtls_RowCommand" OnRowDataBound="gvBrandDtls_RowDataBound">
                                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Sl No.">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Brand Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtBrandName" runat="server" class="form-control txtbox" ></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>

                                                                                    <asp:ButtonField CommandName="Add" Text="Add">
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:ButtonField>
                                                                                    <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:ButtonField>
                                                                                </Columns>
                                                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                                <EditRowStyle BackColor="#B9D684" />
                                                                                <AlternatingRowStyle BackColor="White" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                        <%-- <td></td>

                                                                        <td></td>
                                                                        <td></td>--%>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                            </tr>


                                            <tr>
                                                <td colspan="3" style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                    <table align="left" cellpadding="10" cellspacing="5" style="width: 83%">
                                                        
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Font-Bold="True" Font-Names="Verdana"
                                                                    Width="210px">Commodity Details</asp:Label></td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="3" style="padding: 5px; margin: 5px" valign="top">
                                                                <table width="90%">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="gvCommodityDtls" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvCommodityDtls_RowCommand" OnRowDataBound="gvCommodityDtls_RowDataBound">
                                                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Sl No.">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Commodity Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtCommodityName" runat="server" class="form-control txtbox" ></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Net Quantity">
                                                                                        <ItemTemplate>
                                                                                            <asp:TextBox ID="txtCommodityQuantity" runat="server"  class="form-control txtbox"  onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:ButtonField CommandName="Add" Text="Add">
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:ButtonField>
                                                                                    <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                                        <ItemStyle CssClass="scroll_td" />
                                                                                    </asp:ButtonField>
                                                                                </Columns>
                                                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                                <EditRowStyle BackColor="#B9D684" />
                                                                                <AlternatingRowStyle BackColor="White" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                        <%-- <td></td>

                                                                        <td></td>
                                                                        <td></td>--%>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="center" colspan="3"
                                                    style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save"
                                                        Width="90px" ValidationGroup="group" />
                                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server"
                                                        CssClass="btn btn-danger" Height="32px" OnClick="BtnClear0_Click" TabIndex="10"
                                                        Text="Next" Width="90px"
                                                        ValidationGroup="group" />
                                                    &nbsp;
                                            <asp:Button ID="BtnDelete0" runat="server"
                                                CssClass="btn btn-danger" Height="32px" OnClick="BtnDelete0_Click" TabIndex="10"
                                                Text="Previous" Width="90px" CausesValidation="False" />
                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />
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
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
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



