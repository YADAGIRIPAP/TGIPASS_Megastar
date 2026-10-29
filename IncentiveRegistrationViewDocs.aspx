<%@ Page Title=":: TS-iPass Govenrnment of Telengana : TST Team " Language="C#" MasterPageFile="~/EmptyMaster2.master"
    AutoEventWireup="true" CodeFile="IncentiveRegistrationViewDocs.aspx.cs" Inherits="CheckPOITD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

    <style type="text/css">
        .overlay {
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
    </style>
    <style>
        .blink_text {
            animation: 1s blinker linear infinite;
            -webkit-animation: 1s blinker linear infinite;
            -moz-animation: 1s blinker linear infinite;
            color: white;
            background-color: green;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.5;
            }

            100% {
                opacity: 10.5;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.5;
            }

            100% {
                opacity: 10.5;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.5;
            }

            100% {
                opacity: 10.5;
            }
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupTST.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>

    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 12) {
                alert("Aadhar number length must be exactly 12 characters")
            }
        }
    </script>

    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <asp:Label ID="lblHeading" runat="server" Text="Incentive Registration / View Eligible Incentive"></asp:Label></h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <table runat="server" align="center" cellpadding="10" cellspacing="5">
                                            <tr>
                                                <td style="vertical-align: middle; text-align: center; width: 100%;" valign="middle"
                                                    colspan="2" align="center">
                                                    <table cellpadding="4" cellspacing="5" style="width: 100%;">
                                                        <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center" colspan="2">
                                                                <asp:Label ID="Label386" runat="server" Font-Bold="True" ForeColor="#FF0066" Style="vertical-align: middle; text-align: center; font-size: large">Check for eligible Incentives</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%--  <tr>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:ImageButton ID="btnRegister" runat="server" src="../../images/register.jpg"
                                                                    PostBackUrl="~/UI/TSiPASS/AddnewuserRegistration.aspx" />
                                                            </td>
                                                            <td style="padding: 5px; margin: 5px">
                                                                <asp:ImageButton ID="btnLogin" runat="server" PostBackUrl="~/IpassLogin.aspx" src="../../images/login.jpg" />
                                                            </td>
                                                        </tr>
                                                       <tr>
                                                            <td style="padding: 5px; margin: 5px; text-align: center;" align="center" colspan="2">
                                                                <span style="vertical-align: middle; text-align: center; font-size: large; font-weight: bold;">
                                                                    <a href="http://udyogaadhaar.gov.in/UA/UAM_Registration.aspx" target="_blank">Click here
                                                                        for Udyog Aadhaar Registration </a></span>
                                                            </td>
                                                        </tr>--%>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div class="panel panel-primary">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">Eligible Incentive(s) List</h3>
                                            </div>
                                            <div class="panel-body">
                                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px" valign="top">
                                                            <table cellpadding="4" cellspacing="5" style="width: 83%">
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px">1
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label376" runat="server" CssClass="LBLBLACK" Width="165px">Caste<font color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                        <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" Height="28px"
                                                                            Width="180px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlCaste_SelectedIndexChanged">
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
                                                                            ControlToValidate="ddlCaste" Display="None" InitialValue="-- SELECT --"
                                                                            ErrorMessage="Please Select Caste" ValidationGroup="group">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px">3
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">Type of Sector<font color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 192px;">
                                                                        <asp:DropDownList ID="ddlSector" runat="server" class="form-control txtbox" Height="28px"
                                                                            Width="180px" TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged">
                                                                            <asp:ListItem>-- SELECT --</asp:ListItem>
                                                                            <asp:ListItem Value="1">Service</asp:ListItem>
                                                                            <asp:ListItem Value="2" Selected="True">Manufacture</asp:ListItem>
                                                                            <asp:ListItem Value="3">Textiles</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 10px;">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSector"
                                                                            Display="None" ErrorMessage="Please Select Sector" ValidationGroup="group" InitialValue="-- SELECT --"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px">5
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="165px">Is Physically Handicapped</asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:CheckBox ID="cbphysicalHandicapped" runat="server" Text="Yes" AutoPostBack="true"
                                                                            OnCheckedChanged="cbphysicalHandicapped_CheckedChanged" TabIndex="5" />
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px"></td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px" Visible="false">I) Services</asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RadioButtonList ID="rblVehicleIncetive" runat="server" TabIndex="7" Visible="false">
                                                                            <asp:ListItem Value="1">Transport allied activities</asp:ListItem>
                                                                            <asp:ListItem Value="0" Selected="True">Other Service Sector</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width: 27px">
                                                            <span style="padding: 10px;"></span>
                                                        </td>
                                                        <td valign="top" align="center">
                                                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px" class="style5">2
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK" Width="165px">Category
 <font color="red">*</font></asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; width: 192px;" colspan="2">
                                                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="30px"
                                                                            Width="200px" TabIndex="2">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlCategory"
                                                                            Display="None" ErrorMessage="Please Select Category" ValidationGroup="group"
                                                                            InitialValue="-- SELECT --"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px" class="style5">4
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK" Width="165px">Entreprenuer Type</asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px" colspan="2">
                                                                        <asp:RadioButtonList ID="rblSelection" runat="server" Width="200px" CellPadding="0"
                                                                            CellSpacing="0" TabIndex="4">
                                                                            <asp:ListItem Value="1" Selected="True">New / Existing</asp:ListItem>
                                                                            <asp:ListItem Value="2">Expansion / Diversification</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; vertical-align: middle;" class="style5">6
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="165px">Municipal Corporation</asp:Label>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px" colspan="2">
                                                                        <asp:RadioButtonList ID="rblGHMC" runat="server" TabIndex="6">
                                                                            <asp:ListItem Value="0" Selected="True">GHMC & Other municipal corporations in the state</asp:ListItem>
                                                                            <asp:ListItem Value="1">Other areas in the state</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>

                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Height="45px"
                                                                OnClick="btnSubmit_Click" TabIndex="8" Text="Show Eligible Incentives" ValidationGroup="group"
                                                                Width="180px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="btnApplyIncentives" runat="server" Height="45px"
                                                                TabIndex="8" Text="Apply For Incentives" PostBackUrl="~/IpassLogin.aspx" class="blink_text"
                                                                Width="180px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <br /> <br />
                                                                <asp:HyperLink ID="HyperLink2" NavigateUrl="~/docs/Incentivesmanual.pdf" ForeColor="Green" Font-Bold="true" runat="server" Font-Size="Large" Target="_blank">Incentives User Manual</asp:HyperLink>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3"
                                                            style="padding: 5px; margin: 5px; text-align: center;">
                                                            <asp:HyperLink ID="HyperLink5" NavigateUrl="~/UI/TSiPASS/SanctionedIncentives.aspx"  runat="server" Font-Size="Large" Target="_blank">Industry wise Incentives Sanctioned by SLC</asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr id="trdipc" runat="server" visible="false">
                                                        <td align="center" colspan="3"
                                                            style="padding: 5px; margin: 5px; text-align: center;">
                                                            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/UI/TSiPASS/SanctionedIncentivesDCIP.aspx" runat="server" Font-Size="Large" Target="_blank">Industry wise Incentives Sanctioned by DIPC</asp:HyperLink></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="True" ShowSummary="true"
                                                                ValidationGroup="group" HeaderText="Please select Mandatory fields." />
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
                                                    <tr>
                                                        <td align="center" style="padding: 5px; margin: 5px" colspan="3">
                                                            <div class="alert alert-success">
                                                                <table style="width: 100%; padding: 5px;" cellpadding="2" cellspacing="4">
                                                                    <tr>
                                                                        <td align="center" style="padding: 5px; margin: 5px" colspan="3">Note:
                                                                            <br />
                                                                            <ul>
                                                                                <li>Large Industries are not Eligible for Land Conversion Incentive</li>
                                                                                <li>Projects Proposed to be set up under T-PRIDE in Municipal Corporation limits of
                                                                                    Greater Hyderabad shall obtain pollution clearances where ever neccessary</li>
                                                                                <li>Textile Units other than Large industries may select Sector type as Manufacture
                                                                                    for applying eligible Incentives</li>
                                                                                <li>For service sector enter Equipment Value, for others enter Plant & Machinery Value</li>
                                                                            </ul>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <br />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">The limit for investment in plant and machinery/equipment for manufacturing / service
                                                                            enterprises are as under:
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <table style="width: 100%; padding: 5px;" cellpadding="3" cellspacing="4" border="1">
                                                                                <tr>
                                                                                    <th class="paddingleft">Enterprises
                                                                                    </th>
                                                                                    <th class="paddingleft">Type
                                                                                    </th>
                                                                                    <th class="paddingleft">Investment in plant & machinery/equipment
                                                                                    </th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Micro Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">Does not exceed 25 lakh rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">Does not exceed 10 lakh rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Small Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 25 lakh rupees but does not exceed 5 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 10 lakh rupees but does not exceed 2 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Medium Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 5 crore rupees but does not exceed 10 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 2 crore rupees but does not exceed 5 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Large Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 10 crore rupees but does not exceed 200 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">-
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td rowspan="2" class="paddingleft">Mega Enterprises
                                                                                    </td>
                                                                                    <td class="paddingleft">Manufacturing
                                                                                    </td>
                                                                                    <td class="paddingleft">More than 200 crore rupees
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="paddingleft">Service
                                                                                    </td>
                                                                                    <td class="paddingleft">-
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <%--<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="overlay">
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
