<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UI/TSiPASS/CCMaster.master" CodeFile="frmincentiveformtransportduty.aspx.cs" Inherits="UI_TSiPASS_frmincentiveformtransportduty" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

        .CS {
            background-color: #abcdef;
            color: Yellow;
            border: 1px solid #1d9a5b;
            font: Verdana 10px;
            padding: 1px 4px;
            font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
        }

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

        .style6 {
            width: 300px;
        }

        .style7 {
            color: #FF3300;
        }

        .style8 {
        }

        .auto-style2 {
            height: 82px;
            width: 345px;
        }
        .auto-style8 {
            width: 551px;
            height: 89px;
        }
        .auto-style10 {
            width: 5px;
        }
        .auto-style11 {
            width: 551px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>

    <script type="text/javascript" language="javascript">
        window.onload = function () {
            var scrollY = parseInt('<%=Request.Form["scrollY"] %>');
            if (!isNaN(scrollY)) {
                window.scrollTo(0, scrollY);
            }
        };
        window.onscroll = function () {
            var scrollY = document.body.scrollTop;
            if (scrollY == 0) {
                if (window.pageYOffset) {
                    scrollY = window.pageYOffset;
                }
                else {
                    scrollY = (document.body.parentElement) ? document.body.parentElement.scrollTop : 0;
                }
            }
            if (scrollY > 0) {
                var input = document.getElementById("scrollY");
                if (input == null) {
                    input = document.createElement("input");
                    input.setAttribute("type", "hidden");
                    input.setAttribute("id", "scrollY");
                    input.setAttribute("name", "scrollY");
                    document.forms[0].appendChild(input);
                }
                input.value = scrollY;
            }
        };
    </script>
    <%--<asp:HiddenField runat="server" ID="hfPosition" Value="" />
    <script type="text/javascript">
        $(function () {
            var f = $("#<%=hfPosition.ClientID%>");
        window.onload = function () {
            var position = parseInt(f.val());
            if (!isNaN(position)) {
                $(window).scrollTop(position);
            }
        };
        window.onscroll = function () {
            var position = $(window).scrollTop();
            f.val(position);
        };
    });
    </script>--%>
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
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }

    </script>
    <%--    <asp:updatepanel id="upd1" runat="server">
        <ContentTemplate>--%>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <div class="panel panel-primary">
                    <div class="panel-heading" style="background-color: #339966">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblheadTPRIDE" runat="server" Visible="false">
                                    </asp:Label>
                                    <asp:Label ID="lblheadTIDEA" runat="server" Visible="false">
                                    </asp:Label>
                                    <asp:Label ID="lblwood" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                            

                            
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold"> Transport Details
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    
                                </td>
                            </tr>
                            <tr id="trNewIndustry" runat="server" visible="true" align="center">
                                                                <td colspan="9" align="center">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        
                                                                        <tr id="trlineofactivityNew" runat="server">
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="center">
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            1
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:Label ID="Label2" runat="server">Details of Parts/Components/Goods Transported<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:TextBox ID="txtLOActivity" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            3
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:Label ID="Label3" runat="server">Unist<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                            <asp:DropDownList ID="ddlquantityin" runat="server" class="form-control txtbox" TabIndex="5"
                                                                                                Height="33px" Width="180px" AutoPostBack="True" Visible="true" OnSelectedIndexChanged="ddlquantityin_SelectedIndexChanged">
                                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                                <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                                                <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                                                <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                                                                <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:TextBox ID="txtunit" runat="server" class="form-control txtbox" Visible="false"
                                                                                                Height="28px" MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group"
                                                                                                Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                        ControlToValidate="txtunit" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td valign="top" align="center">
                                                                                <table style="width: 100%; font-weight: bold;">
                                                                                    <tr>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            2
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Quantity<font color="red">*</font></asp:Label>
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            :
                                                                                        </td>
                                                                                        <td style="padding: 5px; margin: 5px">
                                                                                            <asp:TextBox ID="txtinstalledccap" runat="server" class="form-control txtbox" Height="28px"
                                                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                                Width="180px"></asp:TextBox>
                                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                        ControlToValidate="txtinstalledccap" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Button ID="btnInstalledcap" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                                Height="28px" TabIndex="5" Text="Add New" Width="72px" OnClick="btnInstalledcap_Click" />
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                                                                                Height="28px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px"
                                                                                                OnClick="Button2_Click" />
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3" width="100%">
                                                                                <asp:GridView ID="gvInstalledCap" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                                    GridLines="Both" Visible="false" Width="90%" 
                                                                                    OnRowDataBound="gvInstalledCap_RowDataBound" OnRowDeleting="gvInstalledCap_RowDeleting">
                                                                                    <RowStyle BackColor="#ffffff" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Partorcomponentorgoodsname" HeaderText="Line Of Activity" />
                                                                                        <asp:BoundField DataField="InstalledCapacity" HeaderText="Installed Capacity" />
                                                                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                                                                        <asp:BoundField DataField="units_others" HeaderText="Other Units" />
                                                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="Incentive_id" HeaderText="Incentive Id" Visible="false" />
                                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                                    </Columns>
                                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                                        HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                                        Font-Names="Arial" Font-Size="9px" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="center">
                                                                            <td style="padding: 5px; margin: 5px;" valign="top" align="center" colspan="9" width="100%">
                                                                                <center>
                                                                                    <asp:GridView ID="gvInstalledCapNew" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                                        GridLines="Both" Visible="false" Width="90%">
                                                                                        <RowStyle BackColor="#ffffff" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="Partorcomponentorgoodsname" HeaderText="Line Of Activity" />
                                                                                        <asp:BoundField DataField="InstalledCapacity" HeaderText="Installed Capacity" />
                                                                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                                                                        <asp:BoundField DataField="units_others" HeaderText="Other Units" />
                                                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="Incentive_id" HeaderText="Incentive Id" Visible="false" />
                                                                                        </Columns>
                                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                                            HorizontalAlign="Center" />
                                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                                    </asp:GridView>
                                                                                </center>
                                                                            </td>
                                                                        </tr>
                                                                        <%-- <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                                                <asp:GridView ID="gvInstalledCap1" runat="server" AutoGenerateColumns="False"
                                                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                                                    CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                                                    Width="100%">
                                                                                    <RowStyle BackColor="#ffffff" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                                                                        <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                                        <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                                        <asp:BoundField DataField="Column4" HeaderText="Value" />
                                                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                                    </Columns>
                                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <EditRowStyle BackColor="#013161" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>--%>
                                                                    </table>
                                                                </td>
                                                            </tr>
                            <tr id="trEnergy1" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table style="width: 100%; font-weight: bold;">
                                        
                                        
                                                                                <tr >
                                            
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style10">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                <asp:Label ID="Label14" Width="230px" runat="server">Means of Transportation<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:CheckBox ID="chkthirdpartylogistics" runat="server" Text="Third Party Logistics" AutoPostBack="true" OnCheckedChanged="chkthirdpartylogistics_CheckedChanged">  </asp:CheckBox>
                                            <br /><asp:CheckBox ID="chktrain" runat="server" Text="Train" />
                                                <br/><asp:CheckBox ID="chkowntransport" runat="server" Text="Own Transport" />
                                            </td>
                                        </tr>
                                        <tr id="trtransportagency" runat="server" visible="false" >
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2a</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label17" runat="server">Name of the third party transport agency<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtnameofthirdpartyagency" runat="server" class="form-control txtbox" 
                                                    Height="28px"  TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                            
                                        </tr>
                                        <tr >
                                            
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style10">3&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style11" >
                                                <asp:Label ID="Label18" Width="202px" runat="server">Nature of Expenditure Incurred(waybill/Fuel Bill/Freight Charges)<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                 <asp:CheckBox ID="chkwaybill" runat="server" Text="Way Bill">  </asp:CheckBox>
                                            <br /><asp:CheckBox ID="chkfuelbill" runat="server" Text="Fuel Bill" />
                                                <br/><asp:CheckBox ID="chkfreightcharges" runat="server" Text="Freightcharges" />
                                            </td>
                                             <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label13" runat="server">Total Amount of Expenditure Incurred<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txttotalamountofexpincurred" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr >
                                           
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style10">5</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                <asp:Label ID="Label15" runat="server">Amount of Subsidy being claimed(INR)<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtamountofsubsidyclaimed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                             <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label19" Width="239px" runat="server">Total amount of subsidy already sanctioned till date for Transport Subsidy(INR)<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txtalreadysanctionedamount" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>      
                                        <tr >
                                           
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style10">7</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style8">
                                                <asp:Label ID="Label1" runat="server">Financial Year<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlfinancialyeartransportduty" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                             <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label5" Width="239px" runat="server">1st/2nd half Year<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox" Height="33px" Width="180px" >
                                                    <asp:ListItem Value="--Select--" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd"></asp:ListItem>
                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>                               
                                        <tr >
                                           
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style10">&nbsp;</td>
                                            
                                        </tr>
 
                                    </table>
                                </td>
                            </tr>
                            

                                                        
                            <tr runat="server">
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold;">Documents Required:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 80%">
                                        
                                        <tr id="TRTSFDC" runat="server">
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">1 Auditor's statements providing the distance travelled and costs incurred in ferring the imported parts, components from the seaport to the Telangana plant and export of finished goods from the plant to seaport with details on goods transported, origin and destination location and date.</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupauditorsstatement" runat="server" CssClass="CS" Height="28px" />
                                                <asp:HyperLink ID="hypauditorsstatement" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblauditorsstatement" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnauditorsstatement" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btnauditorsstatement_Click" />
                                            </td>
                                        </tr>
                                        <tr >
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">2. Paid waybill/Fuel bill/Freight charges/Invoices/Payment receipts</td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupbills" runat="server" CssClass="CS" Height="28px" />
                                                <asp:HyperLink ID="hypbills" runat="server" CssClass="LBLBLACK"
                                                    Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:HiddenField ID="hdntransportdutyid" runat="server" Visible="false" />
                                                <asp:Label ID="lblbills" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnbill" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btnbill_Click" />
                                            </td>
                                        </tr>
                                        

                                        
                                        
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                            </tr>
                            
                            <tr>
                                <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                        OnClick="BtnSave_Click" TabIndex="10" Text="Submit" ValidationGroup="group" Width="90px" />
                                    &nbsp;
                                        <asp:Button ID="BtnDelete0" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                            Height="32px" OnClick="BtnDelete0_Click" TabIndex="10" Text="Previous" Width="90px" />
                                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Height="32px"
                                        OnClick="BtnClear0_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px"  />
                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                        Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                        <asp:HiddenField ID="hdfpencode" runat="server" />
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <%--            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
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
    <%--            </ContentTemplate>
        </asp:updatepanel>--%>
</asp:Content>
