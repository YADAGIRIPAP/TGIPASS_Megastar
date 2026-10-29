<%@ Page Title=":: TS-iPass Govenrnment of Telengana : TST Team " Language="C#" MasterPageFile="~/UI/TSiPASS/EmptyMaster.master"
    AutoEventWireup="true" CodeFile="frmIncentive.aspx.cs" Inherits="CheckPOITD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 1px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }
        .style5
        {
            width: 15px;
        }
    </style>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">                                
                                <h3 class="panel-title">Eligible Incentive(s) List</h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                    <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                1
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label376" runat="server" CssClass="LBLBLACK" Width="165px">Caste<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" Height="28px"
                                                                    Width="180px" TabIndex="1"  AutoPostBack="true" OnSelectedIndexChanged="ddlCaste_SelectedIndexChanged">
                                                                    <asp:ListItem>-- SELECT --</asp:ListItem>
                                                                    <asp:ListItem Value="1">General</asp:ListItem>
                                                                    <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                    <asp:ListItem Value="3">SC</asp:ListItem>
                                                                    <asp:ListItem Value="4">ST</asp:ListItem>
                                                                    <asp:ListItem Value="5">Others</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                                    ControlToValidate="ddlCaste" Display="None" 
                                                                    ErrorMessage="Please Select Caste" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                3
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Type of Sector<font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                <asp:DropDownList ID="ddlSector" runat="server" class="form-control txtbox" Height="28px"
                                                                    Width="180px" TabIndex="3" AutoPostBack="true" 
                                                                    OnSelectedIndexChanged="ddlSector_SelectedIndexChanged">
                                                                    <asp:ListItem>-- SELECT --</asp:ListItem>
                                                                    <asp:ListItem Value="1">Service</asp:ListItem>
                                                                    <asp:ListItem Value="2" Selected="True">Manufacture</asp:ListItem>
                                                                    <asp:ListItem Value="3">Textiles</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                    ControlToValidate="ddlSector" Display="None"
                                                                    ErrorMessage="Please Select Sector" ValidationGroup="group" 
                                                                    InitialValue="-- SELECT --"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                5
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Is Physically Handicapped</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:CheckBox ID="cbphysicalHandicapped" runat="server" Text="Yes" AutoPostBack="true"
                                                                    OnCheckedChanged="cbphysicalHandicapped_CheckedChanged" TabIndex="5" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px"  Visible="false">I) Services</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RadioButtonList ID="rblVehicleIncetive" runat="server" TabIndex="7" Visible="false">
                                                                    <asp:ListItem Value="1">Transport allied activities</asp:ListItem>
                                                                    <asp:ListItem Value="0" Selected="True">Other Service Sector</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 27px">
                                                    <span style="padding: 10px;"></span>
                                                </td>
                                                <td valign="top" align="center">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" class="style5">
                                                                2
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK" Width="165px">Category
                                                                    <font color="red">*</font></asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="28px"
                                                                    Width="200px" TabIndex="2">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                                    ControlToValidate="ddlCategory"
                                                                    Display="None" ErrorMessage="Please Select Category" 
                                                                    ValidationGroup="group" InitialValue="-- SELECT --"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" class="style5">
                                                                4
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="165px">Entreprenuer Type</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RadioButtonList ID="rblSelection" runat="server" Width="200px" CellPadding="0"
                                                                    CellSpacing="0" TabIndex="4">
                                                                    <asp:ListItem Value="1" Selected="True">New / Existing</asp:ListItem>
                                                                    <asp:ListItem Value="2">Expansion / Diversification</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px" class="style5">
                                                                6
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">
                                                                    Municipal Corporation</asp:Label>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                :
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:RadioButtonList ID="rblGHMC" runat="server" Width="200px" TabIndex="6">
                                                                    <asp:ListItem Value="0" Selected="True">GHMC & Other municipal corporations in the state</asp:ListItem>
                                                                    <asp:ListItem Value="1">Other areas in the state</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        OnClick="btnSubmit_Click" TabIndex="8" Text="Submit" ValidationGroup="group"
                                                        Width="90px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True"
                                                        ShowSummary="true" ValidationGroup="group" HeaderText="Please select Mandatory Documents."  />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="5"
                                                        CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                        Width="100%" OnRowDataBound="grdDetails_RowDataBound" BorderColor="Black">
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:BoundField DataField="IncentiveType" HeaderText="Incentive Type" />
                                                            <asp:BoundField DataField="IncentiveName" HeaderText="Eligible Incentive" />
                                                            <asp:TemplateField HeaderText="Documents to be filled">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="lbt" runat="server" Text='<%# Eval("DocName") %>' NavigateUrl='<%# Eval("FilePath") %>'
                                                                        Target="_blank" />
                                                                </ItemTemplate>
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
                                        </table>
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
                        <div style="z-index: 1000; margin-left: 250px; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
