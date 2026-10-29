<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="IPORptStampDutySubsidy.aspx.cs" Inherits="UI_TSiPASS_IPORptStampDutySubsidy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style5 {
            color: #FF0000;
        }
    </style>
    <%--<script type="text/javascript">
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
    <script type="text/javascript">
        function alpha(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>
    <script type="text/javascript">
        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }
    </script>
    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 6) {
                alert("Pin number length must be exactly 6 characters")
            }
        }
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="background-color: #339966">
                        <table style="width: 100%">
                            <tr>
                                <td style="font-size: x-large; text-align: center">RECOMMENDATION OF THE INSPECTING OFFICER<br />
                                    <span style="font-weight: bold; font-size: large;"><u>
                                        <asp:Label ID="lblsubsidytype" runat="server"></asp:Label></u></span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                            <tr>
                                <td colspan="6" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; font-size: 12pt"
                                    valign="top"></td>
                            </tr>
                                 <tr>
                                <td colspan="5" style="padding: 5px; margin: 5px; text-align: left;"
                                    valign="top">
                                     <table style="width: 100%;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; width:15px"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; width:180px">
                                                <asp:Label ID="Label5" runat="server">Unit Name<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width:2px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; width:220px">
                                                 <asp:Label ID="lblUnitname" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left; width:2px"></td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label6" runat="server"> DCP<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="lbldcp" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; width: 20px">1.
                                </td>
                                <td style="text-align: left; width: 500px">
                                    <asp:Label ID="Label387" runat="server" CssClass="LBLBLACK">Whether the Enterprise has already availed any exemption on purchase of land<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 150px; text-align: left;" colspan="2">
                                    <asp:DropDownList ID="ddlexemptionpurchaseofland" runat="server" Height="32px" Width="215px" AutoPostBack="true" OnSelectedIndexChanged="ddlexemptionpurchaseofland_SelectedIndexChanged">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlexemptionpurchaseofland" InitialValue="--Select--" ErrorMessage="Please Select exemption on purchase of land" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trlandexemption" runat="server">
                                <td style="text-align: center; width: 20px">&nbsp;</td>
                                <td style="text-align: left; width: 350px">&nbsp;</td>
                                <td style="padding: 5px; margin: 5px; width: 10px">&nbsp;</td>
                                <td style="padding: 5px; margin: 5px; width: 10px">Rs.</td>
                                <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;">
                                    <asp:TextBox ID="txtexemptiononland" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="80" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtexemptiononland" ErrorMessage="Please Enter exemption on purchase of land" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr runat="server" id="TrStampduty1">
                                <td style="text-align: center; width: 20px" runat="server" id="tdTrStampduty1">2.
                                </td>
                                <td style="text-align: left; width: 350px">
                                    <asp:Label ID="Label351" runat="server" CssClass="LBLBLACK" Width="200px">Stamp Duty/Transfer Duty<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">Rs.
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtstampduty" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtstampduty" ErrorMessage="Please Enter Stamp Duty/Transfer Duty" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr runat="server" id="TrStampduty2">
                                <td style="text-align: center; width: 20px" runat="server" id="tdTrStampduty2">3.
                                </td>
                                <td style="text-align: left; width: 350px">
                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="300px">Mortgage and Hypothecations Duty<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">Rs.
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtMortgageDuty" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" onkeypress="DecimalOnly()" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMortgageDuty" ErrorMessage="Please Enter Mortgage and Hypothecations Duty" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr runat="server" id="TrStampduty3">
                                <td style="text-align: center; width: 20px" runat="server" id="tdTrStampduty3">4.
                                </td>
                                <td style="text-align: left; width: 350px">
                                    <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK" Width="300px">25% Land Conversion Charges<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">Rs.
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtLandConversionCharges" runat="server" class="form-control txtbox" Height="28px" onkeypress="DecimalOnly()" MaxLength="30" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLandConversionCharges" ErrorMessage="Please Enter Land Conversion Charges" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr runat="server" id="TrStampduty4">
                                <td style="text-align: center; width: 20px" runat="server" id="tdTrStampduty4">5.
                                </td>
                                <td style="text-align: left; width: 350px">
                                    <asp:Label ID="Label3" runat="server" CssClass="LBLBLACK" Width="300px">25% Land Cost purchase in IE/IDA/IP’s<font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">Rs.
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:TextBox ID="txtLandCost" runat="server" class="form-control txtbox" Height="28px" MaxLength="30" TabIndex="1" onkeypress="DecimalOnly()" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLandCost" ErrorMessage="Please Enter 25% Land Cost purchase" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; width: 20px"  runat="server" id="tdTrStampduty5">6.
                                </td>
                                <td style="text-align: left; width: 350px">
                                    <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="300px">Whether is DLC (or) SLC <font color="red">*</font></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">:
                                </td>
                                <td style="padding: 5px; margin: 5px; width: 10px">
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                       <asp:RadioButtonList ID="rblDLCSLC" runat="server" Height="16px" RepeatDirection="Horizontal" Width="200px" TabIndex="7">
                                                <asp:ListItem Value="DLC">DLC</asp:ListItem>
                                                <asp:ListItem Value="SLC">SLC</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style="padding: 5px; margin: 5px">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; width: 20px" valign="top"  runat="server" id="tdTrStampduty6">7.</td>
                                <td style="text-align: left; width: 350px" valign="top">
                                    Remarks<font color="red">*</font></td>
                                <td style="padding: 5px; margin: 5px; width: 10px" valign="top">:</td>
                                <td></td>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <asp:TextBox ID="txtremarks" runat="server" class="form-control txtbox" Height="100px" TabIndex="1" TextMode="MultiLine" ValidationGroup="group" Width="180px"></asp:TextBox>
                                </td>
                                <td style="padding: 5px; margin: 5px" valign="top">
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtremarks" ErrorMessage="Please Enter Remarks" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trEnergy1" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top" colspan="5">
                                    <table style="width: 100%; font-weight: bold;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" runat="server" id="tdTrStampduty7">8.1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label11" runat="server">Claimed Financial Year<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFinYearEnergy" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;"  runat="server" id="tdTrStampduty8">8.2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label16" runat="server"> 1st/2nd half Year<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox" Height="33px" Width="180px" >
                                                    <asp:ListItem Value="--Select--" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st Half"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd Half"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Both"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                     
                                        <tr id="tr1" runat="server">
                                           <%-- <td align="center" colspan="4"></td>--%>
                                            <td align="center" colspan="8" style="height: 50px">
                                                <asp:Button ID="btnEnergyAdd" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="39" Text="Add New" Width="72px" OnClick="btnEnergyAdd_Click" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnEnergyClear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="40" Text="Clear" ToolTip="To Clear the Screen" Width="73px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                                 <tr id="trEnergy2" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                    <asp:GridView ID="gvEnergy" runat="server" AutoGenerateColumns="False"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                        CssClass="GRD"  GridLines="Both" Visible="false"
                                        Width="95%" OnRowDataBound="gvEnergy_RowDataBound" OnRowDeleting="gvEnergy_RowDeleting">
                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FinancialYearId" HeaderText="Financial YearId" Visible="false" />
                                            <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                                          <%--  <asp:BoundField DataField="Fin1stOr2ndHalfYear" HeaderText="1st or 2nd Half Financial Year" />       --%>                                    
                                              <asp:BoundField DataField="Fin1stOr2ndHalfYearText" HeaderText="1st or 2nd Half Financial Year" />       
                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="False" />
                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="False" />
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                        </Columns>
                                            <FooterStyle BackColor="Tan" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                   <%--     <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />--%>
                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                    </asp:GridView>
                                </td>
                            </tr>
                             <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">9&nbsp;</td>
                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                <asp:Label ID="Label439" runat="server" CssClass="LBLBLACK" Width="300px">Supporting Documents (if any)<font 
                                                            color="red">*</font></asp:Label>
                            </td>
                            <td style="padding: 5px; margin: 5px">:</td>
                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;" colspan="2">
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control txtbox" />
                                <br />
                                <asp:Button ID="Button6" runat="server" CssClass="btn btn-xs btn-warning"
                                    Height="28px" TabIndex="10" Text="Attach Files" ValidationGroup="group"
                                    Width="120px" OnClick="Button6_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                            <td style="padding: 10px; margin: 5px; text-align: left;" colspan="5">
                                <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                    CssClass="GRD" ForeColor="Black" GridLines="Both"
                                     Width="50%" BackColor="LightGoldenrodYellow" EnableModelValidation="True">
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <%-- <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />--%>
                                        <%-- <asp:CommandField HeaderText="DELETE" ItemStyle-Width="100px" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />--%>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfilepath" runat="server" Text='<%# Bind("filepath") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                </asp:GridView>
                            </td>

                        </tr>
                            <tr>
                                <td colspan="6" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; font-size: 12pt"
                                    valign="top"></td>

                            </tr>
                                <tr>
                                            <td style="height: 8px" colspan="6"><b>Please enter the following details</b></td>

                                        </tr>


                        <%--    fromhere--%>


                     <tr>
                                            <td colspan="6">
                                                <table>
                                                    <tr>
                                                         <td style="width:200px">Caste</td>
                                                        <td>
:
                                                        </td>
                                            <td>
                                                <asp:RadioButtonList id="rdbCaste" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbCaste_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem>General</asp:ListItem>
                                                    <asp:ListItem>SC</asp:ListItem>
                                                    <asp:ListItem>ST</asp:ListItem>
                                                    <asp:ListItem>PHC</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                                    </tr>

</table></td></tr>

                              <tr>
                                            <td colspan="6">

                                         <table>
                                             <tr>
                                                   <td style="width:200px">Gender</td>
                                                 <td>

                                                     :</td>
                                                 <td>
                                                           <asp:RadioButtonList id="rdbGender" AutoPostBack="True" enabled="false" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbGender_SelectedIndexChanged">
                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>
                                                    
                                                </asp:RadioButtonList> 
                                                 </td>
                                             </tr>
                                         </table>
                                          
                                                </td>
                                  </tr>
                            <tr>
                                <td colspan="6">
                                    <table>
                                        <tr>
                                              <td style="width:200px">Category</td>
                                            <td>

                                                :</td>
                                            <td>
                                                <asp:RadioButtonList id="rdbCategory" AutoPostBack="True" enabled="false" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbCategory_SelectedIndexChanged">
                                                    <asp:ListItem>Micro</asp:ListItem>
                                                    <asp:ListItem>Small</asp:ListItem>
                                                    <asp:ListItem>Medium</asp:ListItem>
                                                    <asp:ListItem>Large</asp:ListItem>
                                                    <asp:ListItem>Mega</asp:ListItem>
                                                    
                                                </asp:RadioButtonList></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table>
                                         <tr>
                                                         <td style="width:200px">Enterprise Type</td>
                                             <td>:</td>
                                            <td>
                                                <asp:RadioButtonList id="rdbEnterprise" AutoPostBack="True" Width="200px" enabled="false"  runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbEnterprise_SelectedIndexChanged">
                                                    <asp:ListItem>New</asp:ListItem>
                                                    <asp:ListItem>Expansion</asp:ListItem>
                                                    
                                                </asp:RadioButtonList></td>
                                                    </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table>
                                        <tr>
                                                         <td style="width:200px">Sector</td>
                                            <td>

                                                :</td>
                                            <td>
                                                <asp:RadioButtonList id="rdbSector" AutoPostBack="True"  enabled="false"  runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbSector_SelectedIndexChanged">

                                                    <asp:ListItem>Service</asp:ListItem>
                                                    <asp:ListItem>Manufacture</asp:ListItem>
                                                    
                                                </asp:RadioButtonList></td>
                                                    </tr>
                                    </table>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table>
                                        <tr id="trServiceType" runat="server" visible="false">
                                                         <td style="width:200px">

                                                             Service Type</td>
                                            <td>
                                                :
                                            </td>
                                                      <td>

                                                          <asp:RadioButtonList ID="rdbServiceType" runat="server" AutoPostBack="True" enabled="false"   RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbServiceType_SelectedIndexChanged">
                                                              <asp:ListItem Value="STT">Transport</asp:ListItem>
                                                              <asp:ListItem Value="STNT">Non - Transport(Fixed services like Hospitals,Halls,Poutlry Farms etc)</asp:ListItem> 
                                                          </asp:RadioButtonList>

                                                      </td>
                                                     </tr>
                                    </table>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <table>
                                                        
                                                    <tr id="trTransNonTrans" runat="server" visible="false">
                                                         <td style="width:200px">
                                                             Transport/Non-Transport Type
                                                         </td>
                                                        <td>
                                                            :
                                                        </td>
                                                      <td>

                                                          <asp:RadioButtonList ID="rdbTransportNonTrans" runat="server" AutoPostBack="True" enabled="false"  RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbTransportNonTrans_SelectedIndexChanged">
                                                              <asp:ListItem Value="TP">Passenger</asp:ListItem>
                                                              <asp:ListItem Value="TG">Goods/Tractor etc</asp:ListItem>
                                                              <asp:ListItem Value="TE">Earth Movers/Borewells/JCB etc</asp:ListItem>
                                                          </asp:RadioButtonList>

                                                      </td>
                                                     </tr>
                                                </table>
                                            </td>
                                           
                                        </tr>
                                  
                           
                 <%--           tillhere--%>
                                        
                            <tr>
                                        <td colspan="10" style="padding: 10px; margin: 5px; font-weight: bold;">Attachments
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px; margin: 5px;" colspan="12">
                                            <asp:GridView ID="GridView3att" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView3att_RowDataBound"
                                        Width="90%" HorizontalAlign="Left" ShowHeader="true">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type of Attachment">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attachments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Verificationflg" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVerified" runat="server" Text='<%# Eval("Verified")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Verify Attachment">
                                                <ItemTemplate>
                                                   <%--<asp:CheckBox ID="chkverified" runat="server" Text="Verified" />--%>
                                                   <asp:RadioButtonList ID="rbtverified"  runat="server"
                                            RepeatDirection="Horizontal" >
                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:RadioButtonList>  
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attachments" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblatchid" runat="server" Text='<%# Eval("AttachmentId")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attachment" Visible="false">
                                                                    <itemtemplate>
                                                                        <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("LINKNEW") %>'></asp:Label>
                                                                    </itemtemplate>
                                                                </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                        </td>
                                    </tr>
                            <tr>
                                <td colspan="6" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; font-size: 12pt" valign="top">
                                    <p>
                                        The claim application of the captioned Enterprise/Industry is verified as per the operational guidelines. The
                                        Enterprise/Industry is eligible for availing incentives under T-IDEA 2014. The Enterprise/Industry did not
                                        add or removed any Plant & Machinery and there is no change of line of activity and capacity. Further, the
                                        Enterprise/Industry is in continuous operation, there is no break-in-production (if so the details of the breakin-
                                        production) and I recommend the above incentives to the captioned Enterprise/Industry.
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; font-size: 12pt"
                                    valign="top"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" style="text-align: center; vertical-align: top;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px" TabIndex="10" Text="Save" Width="90px" ValidationGroup="group" OnClick="BtnSave1_Click" />
                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="BtnPrevious" Visible="false" runat="server" CssClass="btn btn-danger" Height="32px" TabIndex="10" Text="Previous" Width="90px" OnClick="BtnPrevious_Click" />
                                    &nbsp; &nbsp;&nbsp;<asp:Button ID="BtnNext" runat="server" CssClass="btn btn-danger" Height="32px" TabIndex="10" Text="Next" Visible="false" Width="90px" ValidationGroup="group" OnClick="BtnNext_Click" />
                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" OnClick="BtnClear_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; font-size: 12pt" valign="top"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6" style="text-align: left;">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="10" style="text-align: left">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group" />
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                    <%--  </div>--%>
                </div>
            </div>
        </div>
    </div>
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

            $("input[id$='txtDateofIssue']").datepicker(
               {
                   dateFormat: "dd/mm/yy",
                   //  maxDate: new Date(currentYear, currentMonth, currentDate)
               }); // Will run at every postback/AsyncPostback

            $("input[id$='txtPeriodofValidity']").datepicker(
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
            $("input[id$='txtDateofIssue']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtPeriodofValidity']").datepicker(
               {
                   //dateFormat: "dd/mm/yy",
                   dateFormat: "dd/mm/yy",
                   //maxDate: new Date(currentYear, currentMonth, currentDate)
               });
        });
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
            width: 250px;
        }

        .LBLBLACK {
        }
    </style>
</asp:Content>

