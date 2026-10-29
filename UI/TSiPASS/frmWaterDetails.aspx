<%@ Page Title=":: TS-iPASS ::  " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="frmWaterDetails.aspx.cs" Inherits="TSTBDCReg1" %>

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

        .style6 {
            width: 192px;
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
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
                    <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Water Details</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Water Details</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:Label ID="Label422" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="210px">A) Water Requirement<font 
                                                            color="red">*</font></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                                                                <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK" Width="200px">Water Supply From<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:GridView ID="gvmodelsnames" TabIndex="41" runat="server" Width="661px"
                                                                    border="0" CellPadding="4" AutoGenerateColumns="False" HorizontalAlign="Left" EnableModelValidation="True" ForeColor="#333333" GridLines="both">
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl. No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="srn" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Select" ShowHeader="False">
                                                                            <%--  <HeaderTemplate>
                                                            <asp:CheckBox ID="chkAll" runat="server" onclick="javascript:selectGridChkAll(this)" />
                                                        </HeaderTemplate>--%>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkmodelname" runat="server" Enabled="false" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="70px" HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemStyle Width="70px" HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Water required from" ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblModelname"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="150px" HorizontalAlign="left"></HeaderStyle>
                                                                            <ItemStyle Width="150px" HorizontalAlign="left"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Water Required per day( in KLD)" ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox runat="server" ID="txtwaterrequired" MaxLength="10" Width="180px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="left" Width="250px"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>

                                                                    <EditRowStyle BackColor="#7C6F57" />
                                                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                    <RowStyle BackColor="#E3EAEB" />
                                                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />

                                                                </asp:GridView>
                                                                <%--<asp:DropDownList ID="ddlWater_Suply_From" runat="server" class="form-control txtbox"
                                                                    TabIndex="1" Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Municipality</asp:ListItem>
                                                                    <asp:ListItem Value="2">Grama Panchayat</asp:ListItem>
                                                                    <asp:ListItem Value="3">TSIIC</asp:ListItem>
                                                                    <asp:ListItem Value="4">HMWSSB</asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlWater_Suply_From"
                                                                    ErrorMessage="Please Select Water Supply Form" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <%-- <td style="width: 27px">
                                                    <asp:Label ID="Label348" runat="server" CssClass="LBLBLACK" Width="50px"></asp:Label>
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>--%>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left">
                                                    <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="280px" Font-Bold="True">B)Water Consumption</asp:Label>
                                                </td>
                                                <td style="width: 27px">&nbsp;
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label401" runat="server" CssClass="LBLBLACK" Width="200px">Drinking Water ( in KL/Day )<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtDrink_Water" runat="server" class="form-control txtbox" Height="28px"
                                                                    MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1" ValidationGroup="group"
                                                                    Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDrink_Water"
                                                                    ErrorMessage="Please Enter Drinking Water" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lblWaterforProcessing" runat="server" CssClass="LBLBLACK" Width="200px">Water for Processing(Industrial use) ( in KL/Day )<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtWater_Processing" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWater_Processing"
                                                                    ErrorMessage="Please Enter Water for Processing" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    
                                                        <tr id="trsorucewater" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label423" runat="server" CssClass="LBLBLACK" Width="165px">Source of Water<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" ValidationGroup="group" Width="180px">
                                                                    <asp:ListItem Value="1">River</asp:ListItem>
                                                                    <asp:ListItem Value="2">Ground Water</asp:ListItem>
                                                                    <asp:ListItem Value="3">HMWSSB</asp:ListItem>
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="CheckBoxList1"
                                                                    ErrorMessage="Please Select Source of Water" InitialValue="1" ValidationGroup="group"
                                                                    Visible="False">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="trRequirement" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label424" runat="server" CssClass="LBLBLACK" Width="200px">Requirement of Water (in KL/Day)<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtRequirement_Water" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRequirement_Water"
                                                                    ErrorMessage="Please Enter Requirement of Water" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                            <tr ></tr>
                                                        <tr id="trIrrigation" runat="server" visible="false" >
                                                            <td colspan="5" style="padding-top:50px">
                                                                <table>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" colspan="5"><b>C) Additional Information for Irrigation (Rivers/Canals) Permission</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="center" >1</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Geo Coordinates of Proposed Intake Point</td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtIntakeCordinates" runat="server" class="form-control txtbox"
                                                                                Height="28px" MaxLength="40" TabIndex="1"
                                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                            <asp:HyperLink ID="OpenMapLink" runat="server" Text="Click Here to get location Cordinates" onclick="window.open('https://www.google.com/maps/@17.45127,78.5500305,12z?entry=ttu', 'NewWindow', 'width=1200,height=600');"></asp:HyperLink>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtIntakeCordinates"
                                                                                ErrorMessage="Please Enter Intake Cordinates" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="center">2</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Geo Coordinates of Proposed Storage Point/ Utilisation poit</td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtStorageCordinates" runat="server" class="form-control txtbox"
                                                                                Height="28px" MaxLength="40" TabIndex="1"
                                                                                ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Click Here to get location Cordinates" onclick="window.open('https://www.google.com/maps/@17.45127,78.5500305,12z?entry=ttu', 'NewWindow', 'width=1200,height=600');"></asp:HyperLink>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtStorageCordinates"
                                                                                ErrorMessage="Please Enter Storage Point Cordinates" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="center">3</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Minimum Water requirements
                                                                            <br />
                                                                            ( mcft) per annum</td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtMinWaterReq" runat="server" class="form-control txtbox"
                                                                                Height="28px" MaxLength="40" TabIndex="1"
                                                                                ValidationGroup="group" Width="180px"></asp:TextBox>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMinWaterReq"
                                                                                ErrorMessage="Please Enter Minimum Water Required" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;" valign="center">4</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Maximum Water requirement ( mcft) per annum </td>
                                                                        <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                            <asp:TextBox ID="txtMaxWaterReq" runat="server" class="form-control txtbox"
                                                                                Height="28px" MaxLength="40" TabIndex="1"
                                                                                ValidationGroup="group" Width="180px"></asp:TextBox>

                                                                        </td>
                                                                        <td style="padding: 5px; margin: 5px">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMaxWaterReq"
                                                                                ErrorMessage="Please Enter Maximum Water Required" InitialValue="" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp;
                                                </td>
                                                <td valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label416" runat="server" CssClass="LBLBLACK" Width="200px">Quantity of Water Required for Consumptive Use (in KL/Day)<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                                                <asp:TextBox ID="txtQuant_Water_Consumptive" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtQuant_Water_Consumptive"
                                                                    ErrorMessage="Please Enter Quantity of Water Required for Consumptive" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label417" runat="server" CssClass="LBLBLACK" Width="200px">Quantity of Water Required for Non-Consumptive Use (in KL/Day)<font 
                                                            color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtQuant_Water_NonConsumptive" runat="server" class="form-control txtbox"
                                                                    Height="28px" MaxLength="40" onkeypress="return inputOnlyNumbers(event)" TabIndex="1"
                                                                    ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuant_Water_NonConsumptive"
                                                                    ErrorMessage="Please Enter Quantity of Water fon Non-Consumptive" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr id="trarea" runat="server" visible="false">
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">5</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Area Name</td>
                                                            <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlarea" runat="server" class="form-control txtbox"
                                                                    TabIndex="1" Height="33px" Width="180px">
                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlarea"
                                                                    ErrorMessage="Please Select  Area Name" InitialValue="--Select--" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <caption>
                                                &nbsp;</caption>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">&nbsp;
                                                </td>
                                                <td style="width: 27px">&nbsp;
                                                </td>
                                                <td valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                        ValidationGroup="group" Width="90px" />
                                                    &nbsp;
                                                    <asp:Button ID="BtnSave1" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="group"
                                                        Width="90px" />
                                                    &nbsp;<asp:Button ID="btnNext0" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        OnClick="btnNext0_Click" TabIndex="10" Text="Previous" Width="90px" CausesValidation="False" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        OnClick="btnNext_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />


                                                </td>
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
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
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
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>
