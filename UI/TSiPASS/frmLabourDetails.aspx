<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmLabourDetails.aspx.cs"
    Inherits="UI_TSiPASS_frmLabourDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .update {
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

        .style6 {
            width: 192px;
        }

        .auto-style1 {
            width: 200px;
        }

        .auto-style2 {
            width: 47px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

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
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">The Shops & Establishments Act</a> </li>
                </ol>
            </div>
            <div align="left">
                <div align="left" class="row">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div align="center" class="panel-heading">
                                <h3 class="panel-title">The Shops & Establishments Act</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5">
                                                        <tr>

                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1. Classification of Establishment
                                                                <font color="red">*</font>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">: </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:DropDownList ID="ddlEstClassification" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlEstClassification"
                                                                    ErrorMessage="Please Select Classification of Establishment" InitialValue="--Select--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label402" runat="server" CssClass="LBLBLACK" Width="200px">2. Category of Establishment<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">: </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlCategoryofEstablishment" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlCategoryofEstablishment"
                                                                    ErrorMessage="Please Select Category of Establishment" InitialValue="--Select--"
                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3. Name of Shop/Establishment <font color="red">*</font> </td>
                                                            <td style="padding: 5px; margin: 5px">: </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtNameofShopAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtNameofShopAct1"
                                                                    ErrorMessage="Please Enter Name of the Shop/Establishment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" colspan="3">4. Address of the Shop/Establishment </td>

                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <table>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2"></td>
                                                                        <td class="auto-style1" style="text-align: left">Door No. <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtShopDoorNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtShopDoorNo"
                                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Locality <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtShopLocality" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtShopLocality"
                                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2"></td>
                                                                        <td class="auto-style1" style="text-align: left">District <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlShopDistrict" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlShopDistrict_SelectedIndexChanged">
                                                                                <asp:ListItem>--District--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlShopDistrict"
                                                                                ErrorMessage="Please Select District of Shop/Establishment" InitialValue="--District--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Mandal <font color="red">*</font></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlShopMandal" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlShopMandal_SelectedIndexChanged">
                                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlShopMandal"
                                                                                ErrorMessage="Please Select Mandal of Shop/Establishment" InitialValue="--Mandal--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2"></td>
                                                                        <td class="auto-style1" style="text-align: left">Village <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlShopVillage" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlShopVillage"
                                                                                ErrorMessage="Please Slect Village of Shop/Establishment (Village)" InitialValue="--Village--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Pin Code <font color="red">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtShopPincode" runat="server" class="form-control txtbox" Height="28px" MaxLength="6" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtShopPincode"
                                                                                ErrorMessage="Please Enter Address of the Shop/Establishment (Pin Code)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">5. Location of Office, Godown, Warehouse or workplace attached to the shop/establishment but situated outside the premisis of it </td>
                                                            <%--<td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>--%>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="text-align: left;">
                                                                <asp:GridView ID="gvWorkerDtls" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvWorkerDtls_RowCommand" OnRowDataBound="gvWorkerDtls_RowDataBound">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Work Place">
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlWorkPlace" runat="server">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Door No.">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtDoorNo" runat="server"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Locality">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtLocality" runat="server"></asp:TextBox>
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
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">6. Employer, Managing Partner or Managing Director as the case may be (Name, Father Name, Designation, Age, Mobile, e-Mail)</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <table>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Name <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="TxtnameofUnitAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TxtnameofUnitAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Name)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Father's Name <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtPGNameAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtPGNameAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Father's Name)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Designation <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtDesigAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDesigAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Designation)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Age <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtAgeAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="4" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAgeAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Age)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mobile <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtMobileAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" onkeypress="NumberOnly()" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtMobileAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Mobile)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Email <font color="red" size="3"><font color="red">*</font></font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtEmailAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtEmailAct1"
                                                                                ErrorMessage="Please Enter Employer, Managing Partner or Managing Director (Email)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">7. Residential address of the employer</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <table>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Door No.<font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtDoorNoResidentialAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtDoorNoResidentialAct1"
                                                                                ErrorMessage="Please Enter  Residential address of the employer (Door No)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Locality <font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtLocalResidentialAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtLocalResidentialAct1"
                                                                                ErrorMessage="Please Enter  Residential address of the employer (Locality)" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">District <font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlDistrictResidentialAct1" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px"
                                                                                OnSelectedIndexChanged="ddlDistrictResidentialAct1_SelectedIndexChanged" Width="180px">
                                                                                <%--<asp:ListItem>--District--</asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDistrictResidentialAct1"
                                                                                ErrorMessage="Please Select District of Employer" InitialValue="--District--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mandal <font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlMandalResidentialAct1" runat="server" class="form-control txtbox" Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlMandalResidentialAct1_SelectedIndexChanged">
                                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMandalResidentialAct1"
                                                                                ErrorMessage="Please Select Mandal of Employer" InitialValue="--Mandal--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2"></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Village <font color="red" size="3">*</font></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlVillageResidentialAct1" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlVillageResidentialAct1"
                                                                                ErrorMessage="Please Select Residential Village of the Employer (Village)" InitialValue="--Village--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">8. Manager/Agent if any (with residential address):
                                                                 <asp:RadioButtonList ID="Rd_ManagerResidenceAct1" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Width="100px" OnSelectedIndexChanged="Rd_ManagerResidenceAct1_SelectedIndexChanged">
                                                                     <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                     <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                 </asp:RadioButtonList></td>
                                                            <%--<td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:RadioButtonList ID="Rd_ManagerResidenceAct1" runat="server" OnSelectedIndexChanged="Rd_ManagerResidenceAct1_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True">
                                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>--%>
                                                            <%--<td style="padding: 5px; margin: 5px">
                                                                
                                                            </td>--%>
                                                        </tr>
                                                        <tr id="trManagerResidenceAct1" runat="server" visible="false">
                                                            <td colspan="2" style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Name <font color="red" size="3">*</font> </td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtManagerNameAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Father&#39;s Name <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtManagerPGNameAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Designation <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtManagerDesignationAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Door <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtManagerDoorNoAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Locality <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtManagerLocalityAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">District <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlManagerDistrictAct1" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlManagerDistrictAct1_SelectedIndexChanged">
                                                                                <asp:ListItem>--District--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlManagerDistrictAct1"
                                                                                ErrorMessage="Please Select District of Manager/Agent" InitialValue="--District--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Mandal <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlManagerMandalAct1" runat="server" AutoPostBack="true" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlManagerMandalAct1_SelectedIndexChanged">
                                                                                <asp:ListItem>--Mandal--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlManagerMandalAct1"
                                                                                ErrorMessage="Please Select Mandal of Manager/Agent" InitialValue="--Mandal--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>--%>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Village <span class="reqFields" style="display: inline;"><font color="red" size="3">*</font> </span></td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:DropDownList ID="ddlManagerVillageAct1" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                                <asp:ListItem>--Village--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlManagerVillageAct1"
                                                                                ErrorMessage="Please Select Manager/Agent (Village)" InitialValue="--Village--"
                                                                                ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="padding: 5px; margin: 5px; text-align: left;">9. Nature of business *</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtNatureofBusinessAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding-bottom: 2px; margin-bottom: 2px;" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNatureofBusinessAct1"
                                                                    ErrorMessage="Please Enter Nature of business " ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="padding: 5px; margin: 5px; text-align: left;">10. Date of Commencement of business *</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDateofCommenceAct1" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd"  PopupButtonID="txtDateofCommenceAct1" TargetControlID="txtDateofCommenceAct1">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">11. Name of family members of employees family engaged in Shop / Establishment</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="text-align: left">
                                                                <asp:GridView ID="gvFamilyMembersAct1" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvFamilyMembersAct1_RowCommand" OnRowDataBound="gvFamilyMembersAct1_RowDataBound">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Name">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtFamilyNameAct1" runat="server"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Relationship">
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlRelationshipAct1" runat="server">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Gender">
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlFamilyGenderAct1" runat="server">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Adult/Young Person">
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlFamilyAdultAct1" runat="server">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    <%-- <asp:ListItem Value="1">Adult</asp:ListItem>
                                                                                      <asp:ListItem Value="2">Young Person</asp:ListItem>--%>
                                                                                </asp:DropDownList>
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
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 35px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-weight: bold">12. Total No. of Employees *:
                                                            </td>
                                                            <td colspan="2" style="height: 35px">
                                                                <asp:TextBox ID="txtTotalEmployees" runat="server" class="form-control txtbox" MaxLength="6" onkeypress="NumberOnly()" Width="50px" Enabled="false"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">

                                                                <asp:Table ID="tblNoofEmployees" runat="server" CellPadding="1" CellSpacing="1" Font-Size="Medium" Width="400" GridLines="Both">
                                                                    <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" Style="color: White; background-color: #013161; font-weight: bold;">
                                                                        <asp:TableHeaderCell Width="50px"></asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell Width="150px">Adults (18 years and above)</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell Width="170px">Young Persons (From 14 years to Below 18 years)</asp:TableHeaderCell>
                                                                    </asp:TableHeaderRow>
                                                                    <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                                                        <asp:TableCell>MALE</asp:TableCell>
                                                                        <asp:TableCell Height="29px">
                                                                            <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Male" Width="40px" OnTextChanged="txtAbove18Male_TextChanged"></asp:TextBox>
                                                                        </asp:TableCell>
                                                                        <asp:TableCell Height="29px">
                                                                            <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18Male" Width="40px" OnTextChanged="txtBelow18Male_TextChanged"></asp:TextBox>
                                                                        </asp:TableCell>
                                                                    </asp:TableRow>
                                                                    <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                                                        <asp:TableCell Height="29px">FEMALE</asp:TableCell>
                                                                        <asp:TableCell>
                                                                            <asp:TextBox runat="server" AutoPostBack="true" ID="txtAbove18Female" Width="40px" OnTextChanged="txtAbove18Female_TextChanged"></asp:TextBox>
                                                                        </asp:TableCell>
                                                                        <asp:TableCell>
                                                                            <asp:TextBox runat="server" AutoPostBack="true" ID="txtBelow18FeMale" Width="40px" OnTextChanged="txtBelow18FeMale_TextChanged"></asp:TextBox>
                                                                        </asp:TableCell>
                                                                    </asp:TableRow>
                                                                    <asp:TableFooterRow ID="TableFooterRow1" runat="server" HorizontalAlign="Center" Style="background-color: #EBF2FE;">
                                                                        <asp:TableCell Height="29px">Total</asp:TableCell>
                                                                        <asp:TableCell>
                                                                            <asp:TextBox runat="server" ID="txtTotalAbove18" Width="40px" Enabled="false"></asp:TextBox>
                                                                        </asp:TableCell>
                                                                        <asp:TableCell>
                                                                            <asp:TextBox runat="server" ID="txtTotalBelow18" Width="40px" Enabled="false"></asp:TextBox>
                                                                        </asp:TableCell>
                                                                    </asp:TableFooterRow>
                                                                </asp:Table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 20px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="font-weight: bold">13. Name of Employees (Optional):</td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="text-align: left">
                                                                <asp:GridView ID="gvEmployeeNames" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvEmployeeNames_RowCommand" OnRowDataBound="gvEmployeeNames_RowDataBound">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Occupation">
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlOccupationAct1" runat="server">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Name">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtEmployeeNameAct1" runat="server"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Gender">
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="ddlEmployeeGenderAct1" runat="server">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                </asp:DropDownList>
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
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp; </td>
                                                <td valign="top">&nbsp;</td>
                                            </tr>
                                            <caption>
                                                &nbsp;</caption>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp; </td>
                                                <td style="width: 27px">&nbsp; </td>
                                                <td valign="top">&nbsp; </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" OnClick="BtnSave1_Click" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server"
                                                        CssClass="btn btn-danger" Height="32px" OnClick="btnNext_Click" TabIndex="10"
                                                        Text="Next" Width="90px" ValidationGroup="group" />
                                                    <asp:Button ID="btnNext0" runat="server"
                                                        CssClass="btn btn-danger" Height="32px" OnClick="btnNext0_Click" TabIndex="10"
                                                        Text="Previous" Width="90px" CausesValidation="False" />
                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                                        CssClass="btn btn-warning" Height="32px" OnClick="BtnClear_Click" TabIndex="10"
                                                        Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px"
                                                        ValidationGroup="group" />
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
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <asp:HiddenField ID="hdfFlagID0" runat="server" />
                                        <br />
                                        <asp:HiddenField ID="hdfpencode" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upd1">
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>


