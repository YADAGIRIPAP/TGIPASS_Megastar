<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmLabourDetails_Act4.aspx.cs" Inherits="UI_TSiPASS_frmLabourDetails_Act4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />

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

        .style6
        {
            width: 192px;
        }

        .auto-style1
        {
            width: 10px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <%--    <script type="text/javascript">
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
                    <li class="active"><i class="fa fa-edit"></i><a href="#">Principal Employer Registration under
Interstate Migrant Workman Act</a> </li>
                </ol>
            </div>
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Principal Employer Registration under
Interstate Migrant Workman Act</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>1. Name and Location of the Establishment Details</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="lbl" runat="server" CssClass="LBLBLACK" Width="110px">1.1 Name
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEstbName" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="110px">1.2 Location
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEstbLoc" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="LBLBLACK" Width="110px">1.3 Category of establishment
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlCatEstbAct4" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>2. Postal address of the Establishment</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label5" runat="server" CssClass="LBLBLACK" Width="110px">2.1 Door No
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEstdDoorNoEstbAct4" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="110px">2.2 District
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDistrictEstbAct4" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlDistrictEstbAct4_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="110px">2.3 Mandal
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMandalEstbAct4" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlMandalEstbAct4_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="110px">2.4 Village/Town
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlVillageEstbAct4" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px">
                                                                </asp:DropDownList>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>3. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="LBLBLACK" Width="110px">3.1 Full Name
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtFullNamePermAct4" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label8" runat="server" CssClass="LBLBLACK" Width="110px">3.2 Father's Name
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtFatherNamePermAct4" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="110px">3.3 Mobile No
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtMobileNoPermAct4" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="10" onkeypress="NumberOnly()"  TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="110px">3.4 Email Id
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtEmailPermAct4" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label11" runat="server" CssClass="LBLBLACK" Width="110px">3.5 Door No
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDoorNoPermAct4" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="110px">3.6 District
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDistrictPermAct4" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlDistrictPermAct4_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label12" runat="server" CssClass="LBLBLACK" Width="110px">3.7 Mandal
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMandalPermAct4" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlMandalPermAct4_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label26" runat="server" CssClass="LBLBLACK" Width="110px">3.8 Village
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlVillagePermAct4" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>4.  Name and address of the Director / Partners (in case of companies/firm)</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Width="110px">4.1 Full Name
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDirFullName" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label19" runat="server" CssClass="LBLBLACK" Width="110px">4.2 Door No
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtDirDoorNo" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label20" runat="server" CssClass="LBLBLACK" Width="110px">4.3 District
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDirDistrict" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlDirDistrict_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK" Width="110px">4.4 Mandal
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDirMandal" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlDirMandal_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="LBLBLACK" Width="110px">4.5 Village/Town
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlDirVillage" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px">
                                                                </asp:DropDownList>

                                                            </td>
                                                            <td style="padding: 5px; margin: 5px"></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>5. Full name and address of the Manager or person responsible for the Supervison and control of the Establishment</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="LBLBLACK" Width="110px">5.1 Full Name
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtManagerFullName" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label14" runat="server" CssClass="LBLBLACK" Width="110px">5.2 Door No
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:TextBox ID="txtMgrDoorNo" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="12" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label16" runat="server" CssClass="LBLBLACK" Width="110px">5.3 District
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMgrDistrict" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlMgrDistrict_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label15" runat="server" CssClass="LBLBLACK" Width="110px">5.4 Mandal
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMgrMandal" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px" OnSelectedIndexChanged="ddlMgrMandal_SelectedIndexChanged" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Width="110px">5.5 Village/Town
                                                                <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td>:
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                <asp:DropDownList ID="ddlMgrVillage" runat="server" class="form-control txtbox"
                                                                    Height="33px" Width="180px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <strong>6. Nature of work carried out in the Establishment</strong>
                                                                </td>
                                                                <td>
                                                                 <asp:TextBox ID="txtNatureofWorkAct4" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            </td>
                                                           <%-- <td style="padding: 5px; margin: 5px; text-align: left;">
                                                               
                                                            </td>--%>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <strong>7. Particulars of Contractors and migrant workmen</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">
                                                                <asp:GridView ID="gvContractorAct4" runat="server" AutoGenerateColumns="False" border="3" CellPadding="1" CellSpacing="1" OnRowCommand="gvContractorAct4_RowCommand" OnRowDataBound="gvContractorAct4_RowDataBound">
                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Name of the Contractor">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorNameAct4" runat="server" Width="150px" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Address">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorAddressAct4" TextMode="MultiLine" runat="server" Width="150px" Height="50px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Mobile No.">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorMobileNoAct4" runat="server" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Nature of Work">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorNatureAct4" runat="server" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Maximum No. of Migrant Workmen">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox  onkeypress="NumberOnly()" ID="txtContractorMaximumNoAct4" runat="server" Width="35" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estimated Date of Commencement">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorCommenceAct4" runat="server" Height="25px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle CssClass="scroll_td" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estimated Date of Completion">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtContractorCompAct4" runat="server" Height="25px"></asp:TextBox>
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
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <strong>Total No.of Contract Employees * :</strong>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                <asp:TextBox ID="txtTotalContractors" Enabled="false" runat="server" class="form-control txtbox" Height="28px" ToolTip="text"
                                                                    MaxLength="50" TabIndex="0" ValidationGroup="group" Width="54px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">&nbsp;
                                                </td>
                                                <td valign="top">&nbsp;</td>
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
                                                    <asp:Button ID="BtnSave1" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                                        Height="32px" OnClick="BtnSave_Click" TabIndex="10" Text="Save" ValidationGroup="ggg"
                                                        Width="90px" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        OnClick="btnNext_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px" />
                                                    &nbsp;<asp:Button ID="btnNext0" runat="server" CssClass="btn btn-danger" Height="32px"
                                                        OnClick="btnNext0_Click" TabIndex="10" Text="Previous" Width="90px" CausesValidation="False" />
                                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                                        ValidationGroup="group" Width="90px" />
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
            <%-- %><asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
                        <%--<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>
       </td>
        </tr>
    </table>--%>
</asp:Content>




