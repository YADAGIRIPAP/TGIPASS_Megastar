<%@ Page Title="" Language="C#" MasterPageFile="CCMaster.master" AutoEventWireup="true" CodeFile="frmClusterInformation.aspx.cs" Inherits="UI_TSiPASS_frmClusterInformation" %>

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

        .style6 {
            width: 192px;
        }

        .style7 {
            color: #FF3300;
        }

        .style8 {
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
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }

    </script>

    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="index.html">Dashboard</a> </li>
            <li class=""><i class="fa fa-fw fa-table"></i>Helpdesk </li>
            <li class="active"><i class="fa fa-edit"></i>View Status </li>
        </ol>
    </div>
    <div align="center">
        <div class="row" align="center">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">CLUSTER INFORMATION</h3>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="panel-body">
                                <table style="vertical-align: top; text-align: center;" cellpadding="0" cellspacing="0"
                                    width="100%">
                                    <tr>
                                        <td align="center" style="padding: 5px; vertical-align: top; text-align: center"
                                            valign="middle">
                                            <table style="width: 96%; height: 53px">
                                                <tr>
                                                    <td style="width: 50%; height: 80px" valign="top">
                                                        <table cellpadding="0" cellspacing="0" style="width: 90%">
                                                            <tr>
                                                                <td style="padding: 3px; margin: 3px; text-align: left; font-weight: bold" class="auto-style2" colspan="7">1. Location Details
                                                                </td>


                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Mandal <font color="red">*</font></td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlMandal" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                        <asp:ListItem>--Mandal--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlMandal"
                                                                        ErrorMessage="Please Select Mandal" InitialValue="--Mandal--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                <td class="auto-style1" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                                <td>&nbsp;</td>

                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style1">Village <font color="red">*</font></td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlVillage" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                                        <asp:ListItem>--Village--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlVillage"
                                                                        ErrorMessage="Please Select Village" InitialValue="--Village--"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                <td class="auto-style1" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            </tr>
                                                            <tr>

                                                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold" class="auto-style1">2. Line of Activity <font color="red">*</font></td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtLineofActivity" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorloa" runat="server" ControlToValidate="txtLineofActivity"
                                                                        ErrorMessage="Please Enter Line of Activity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                                <td class="auto-style1" style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td style="padding: 5px; margin: 5px">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%; height: 80px" valign="top">
                                                        <table cellpadding="0" cellspacing="0" style="width: 90%">

                                                            <tr>
                                                                <td style="padding: 3px; margin: 3px; text-align: left; font-weight: bold" class="auto-style2" colspan="5">3. Infrastructure Available
                                                                </td>


                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2" colspan="5">
                                                                    <table style="width: 90%">
                                                                        <tr runat="server" visible="false">
                                                                            <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">Power Connectivity<font color="red">*</font></td>
                                                                            <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                                                <asp:DropDownList ID="ddlPowerConnectivity" runat="server" class="form-control txtbox" Height="33px">
                                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="33">33 KV</asp:ListItem>
                                                                                    <asp:ListItem Value="11">11 KV</asp:ListItem>
                                                                                    <asp:ListItem Value="133">133 KV</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorPower" runat="server" ControlToValidate="ddlPowerConnectivity"
                                                                                    ErrorMessage="Please Select Power Connectivity" InitialValue="--Select--"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">Substation Name<font color="red">*</font></td>
                                                                            <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                                                <asp:TextBox ID="txtSubstationName" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubstation" runat="server" ControlToValidate="txtSubstationName"
                                                                                    ErrorMessage="Please Enter Sub Station Name"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">Capacity of Substation<font color="red">*</font></td>
                                                                            <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                                                <asp:DropDownList ID="ddlCapacitySubstation" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="11">11 KV</asp:ListItem>
                                                                                    <asp:ListItem Value="33">33 KV</asp:ListItem>
                                                                                    <asp:ListItem Value="133">133 KV</asp:ListItem>
                                                                                </asp:DropDownList></td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCapacity" runat="server" ControlToValidate="ddlCapacitySubstation"
                                                                                    ErrorMessage="Please Select Capacity of Substation" InitialValue="--Select--"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">Details of Training facilities<font color="red">*</font></td>
                                                                            <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                                                <asp:TextBox ID="txtTrainingFacilities" runat="server" class="form-control txtbox" Height="28px" MaxLength="1550" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px" TextMode="MultiLine"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTrainingFacilities"
                                                                                    ErrorMessage="Please Enter Details of Training facilities"
                                                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>


                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" style="padding: 3px; margin: 3px; text-align: left; font-weight: bold" class="auto-style2">Details of common facility centers<font color="red">*</font>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2" colspan="5">
                                                                    <asp:GridView ID="gvCommonFacility" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvCommonFacility_RowCommand" OnRowDataBound="gvCommonFacility_RowDataBound">
                                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Common Facility Center Type">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddlCommonFacType" runat="server" AutoPostBack="true" class="form-control txtbox">
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Details">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtCommonFacDetails" runat="server" class="form-control txtbox"></asp:TextBox>
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
                                                                <td style="padding: 3px; margin: 3px; text-align: left; font-weight: bold" class="auto-style2" colspan="2">4. Raw Material Source<font color="red">*</font>
                                                                </td>

                                                                <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2">
                                                                    <asp:TextBox ID="txtRawMaterial" runat="server" class="form-control txtbox" Height="28px" MaxLength="500" TabIndex="0" TextMode="MultiLine" ToolTip="text" ValidationGroup="group" Width="238px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRawMaterial"
                                                                        ErrorMessage="Please Enter Raw Material Source"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator></td>

                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 3px; margin: 3px; text-align: left; font-weight: bold" class="auto-style2" colspan="2">5. Major Markets<font color="red">*</font>
                                                                </td>
                                                                <td class="auto-style2" style="padding: 3px; margin: 3px; text-align: left;">
                                                                    <asp:TextBox ID="txtMajorMarkets" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" TextMode="MultiLine" ToolTip="text" ValidationGroup="group" Width="242px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMajorMarkets" ErrorMessage="Please EnterMajor Markets" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 3px; margin: 3px; text-align: left; font-weight: bold;" class="auto-style2" colspan="5">6. Exports Details
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2" colspan="5">
                                                                    <asp:GridView ID="gvExports" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvExports_RowCommand" OnRowDataBound="gvExports_RowDataBound">
                                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Name of the Unit">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtUnitName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Product Exported">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtProductExported" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Country's Product Exported">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtCountryProductExported" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Quantum of Exports">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtQuantumExports" onkeypress="return inputOnlyNumbers(event)" runat="server" Style="vertical-align: top;" Height="30px" Width="65px"></asp:TextBox>
                                                                                    <asp:DropDownList ID="ddlquantityin" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlquantityin_SelectedIndexChanged" Style="vertical-align: top;" Height="30px" TabIndex="1">
                                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                                        <asp:ListItem Value="Tone">Tone</asp:ListItem>
                                                                                        <asp:ListItem Value="Liters">Liters</asp:ListItem>
                                                                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:TextBox ID="txtitem2" runat="server" MaxLength="40" onkeypress="Names()" TabIndex="1" ValidationGroup="group" Visible="false" Width="65px" Height="30px"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Value of Exports">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtValueExports" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                                                                <td style="padding: 3px; margin: 3px; text-align: left; font-weight: bold" class="auto-style2" colspan="5">7. List of Industries

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" class="auto-style2" style="padding: 3px; margin: 3px; text-align: left; font-weight: bold">
                                                                    <asp:GridView ID="gvIndustriesList" runat="server" AutoGenerateColumns="False" Width="100%" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvIndustriesList_RowCommand" OnRowDataBound="gvIndustriesList_RowDataBound">
                                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Name of the Industry">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtIndusName" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Unit Type">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddlUnitType" runat="server" class="form-control txtbox"
                                                                                        Height="33px" Width="180px" TabIndex="1">
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="1">Micro</asp:ListItem>
                                                                                        <asp:ListItem Value="2">Small</asp:ListItem>
                                                                                        <asp:ListItem Value="3">Medium</asp:ListItem>
                                                                                        <asp:ListItem Value="4">Large</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                           <%-- <asp:TemplateField HeaderText="No.of Units">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtNoofUnits" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>--%>
                                                                            <asp:TemplateField HeaderText="Line of Activity">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtLineofActivity" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Investment<br/> (Rs. in Lakhs)">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtInvestment" onkeypress="return inputOnlyNumbers(event)" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Employment">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtEmployment" onkeypress="return inputOnlyNumbers(event)" runat="server" class="form-control txtbox"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Turnover<br/> (Rs. in Lakhs)">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtTurnover" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" runat="server" OnTextChanged="txtTurnover_TextChanged" AutoPostBack="True"></asp:TextBox>
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
                                                                    <br />
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr runat="server" visible="false" id="tr8unit">
                                                                <td style="padding: 3px; margin: 3px; text-align: left; font-weight: bold" class="auto-style2" colspan="5">8. Unit Details
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" visible="false" id="tr8unit1">
                                                                <td style="padding: 3px; margin: 3px; text-align: left;" class="auto-style2" colspan="5">
                                                                    <asp:GridView ID="gvUnitDetails" runat="server" AutoGenerateColumns="False" Width="100%" border="3" CellPadding="1" CellSpacing="1" OnRowDataBound="gvUnitDetails_RowDataBound">
                                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Unit Type">
                                                                                <ItemTemplate>
                                                                                    <asp:Label Width="150px" ID="lblType" Font-Size="15px" Font-Bold="true" runat="server" Text='<%# Eval("Unit_Type") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="No of Units">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtNoofUnits" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" runat="server" OnTextChanged="txtNoofUnits_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Investment<br/> (Rs. in Lakhs)">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtIvestment" onkeypress="return inputOnlyNumbers(event)" runat="server" class="form-control txtbox" OnTextChanged="txtIvestment_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Employment">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtEmployment" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" runat="server" OnTextChanged="txtEmployment_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Turnover<br/> (Rs. in Lakhs)">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtTurnover" onkeypress="return inputOnlyNumbers(event)" class="form-control txtbox" runat="server" OnTextChanged="txtTurnover_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#B9D684" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                </td>


                                                            </tr>
                                                            <tr runat="server" visible="false" id="trRemarks">
                                                                <td style="padding: 5px; margin: 3px; text-align: left;">Remarks </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRemarks" runat="server" class="form-control txtbox" Height="71px" MaxLength="2000" TabIndex="0" TextMode="MultiLine" ToolTip="text" ValidationGroup="group" Width="291px"></asp:TextBox></td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" style="text-align: center">
                                                                    <table cellpadding="0" cellspacing="0" style="width: 90%">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 3px; text-align: center;">
                                                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave1_Click" TabIndex="10" Text="Save" ValidationGroup="group" Width="90px" />


                                                                            </td>
                                                                            <td runat="server" id="tdPrint" visible="false"><a href="ClusterPrint.aspx" class="btn btn-primary" height="32px" tabindex="11" target="_blank">Print Cluster Data</a></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>

                                                            </tr>

                                                        </table>
                                                </tr>
                                            </table>
                                            <%-- <asp:TextBox ID="txtPrno0" runat="server" AutoPostBack="True" CssClass="TXTBOX" 
                                                                                            MaxLength="30" onkeypress="CharbarOnly()" OnTextChanged="txtPrno_TextChanged" 
                                                                                            TabIndex="1" Width="130px"></asp:TextBox>--%>
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
                                    <tr id="Tr1" runat="server">
                                        <td align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle; padding-top: 5px; text-align: center"
                                            valign="middle">
                                            <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                                ForeColor="Green" Style="position: static"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="Reject">
                                        <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                            valign="middle">
                                            <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="270px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="Close">
                                        <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                            valign="middle">
                                            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Width="272px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; vertical-align: middle; height: 35px; text-align: left"
                                            valign="middle">&nbsp; &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle; padding-top: 5px; height: 35px; text-align: center"
                                            valign="middle">&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:ValidationSummary ID="vg" runat="server" ForeColor="Green" ShowMessageBox="True"
                                    ShowSummary="False" Style="position: static" ValidationGroup="group" />
                                </td> </tr> </table>
                                        <asp:HiddenField ID="hdfusercode" runat="server" />
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <br />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

