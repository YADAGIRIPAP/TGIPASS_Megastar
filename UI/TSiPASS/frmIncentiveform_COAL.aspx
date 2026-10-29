<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmIncentiveform_COAL.aspx.cs" Inherits="UI_TSiPASS_frmIncentiveform_COAL" %>

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

        .auto-style1 {
            width: 20px;
        }
        .auto-style2 {
            width: 231px;
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
                                    <asp:Label ID="lblcoal" runat="server">
                                    </asp:Label>
                                    <asp:Label ID="lblheadTIDEA" runat="server" Visible="false">
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
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold"> Coal Details :
                                </td>
                            </tr>
                           
                            <%--<tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <asp:GridView ID="gvSalesTax" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowDataBound="gvSalesTax_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Financial year">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="1st Half Year Amount paid in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt1Amountpaid" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="1st Half Year Amount claimed in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt1AmountClaimed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="2n Half Year Amount paid in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt2Amountpaid" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="2nd Half Year Amount claimed in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt2AmountClaimed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                            </tr>--%>
                            <tr id="trEnergy1" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table style="width: 100%; font-weight: bold;">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">1</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label11" runat="server">Financial Year<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFinYearCoal" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">2</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label16" runat="server"> 1st / 2nd Half Year<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox" Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlFin1stOr2ndHalfyear_SelectedIndexChanged">
                                                    <asp:ListItem Value="--Select--" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd"></asp:ListItem>
                                                   <%-- <asp:ListItem Value="3" Text="Both"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr id="trcoalqtyandclaimamount" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">3&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label7" runat="server">Coal Quantity<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="TXTCOALQUANTITY" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px" AutoPostBack="true" OnTextChanged="TXTCOALQUANTITY_TextChanged"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">4</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label8" runat="server">Unit of Measurement<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="TXTUNITMSMT" Text="MT" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr2" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">5&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label2" runat="server">Amount Paid<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="TXTAMOUNTPAID" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px" AutoPostBack="true" ></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">6</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label5" runat="server">Amount Claimed<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="TXTCLAIMAMOUNT" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="trFin1stHalfYear" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">7&nbsp;</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label12" runat="server">1st Half Year Amount Paid <br />(in Rs)<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt1stHalfAmountPaid" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">8</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label14" runat="server">1st Half Year Amount Claimed <br />(in Rs)<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt1stHalfamountclaimed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="trFin2ndHalfYear" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px; text-align: left;">9</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style2">
                                                <asp:Label ID="Label13" runat="server">2nd Half Year Amount Paid <br />(in Rs)<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt2ndHalfAmountPaid" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">10</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:Label ID="Label15" runat="server">2nd Half Year Amount Claimed <br />(in Rs)<font color="red">*</font></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">:</td>
                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:TextBox ID="txt2ndHalfamountclaimed" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                    Height="28px" MaxLength="40" TabIndex="36" Width="180px"></asp:TextBox>
                                            </td>
                                        </tr>

                                        
                                        
                                        <%--<tr id="tr1" runat="server">
                                            <td align="center" colspan="4"></td>
                                            <td align="center" colspan="4" style="height: 50px">
                                                <asp:Button ID="btnEnergyAdd" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="39" Text="Add New" Width="72px" OnClick="btnEnergyAdd_Click" />
                                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnEnergyClear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="40" Text="Clear" ToolTip="To Clear the Screen" Width="73px" OnClick="btnEnergyClear_Click" />
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <%--<tr id="trEnergy2" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                    <asp:GridView ID="gvEnergy" runat="server" AutoGenerateColumns="False"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                        CssClass="GRD" ForeColor="#333333" Visible="False"
                                        Width="95%" DataKeyNames="intLineofActivityMid" OnRowDataBound="gvEnergy_RowDataBound" OnRowDeleting="gvEnergy_RowDeleting" EnableModelValidation="True">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FinancialYearId" HeaderText="Financial YearId" Visible="false" />
                                            <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                                            <asp:BoundField DataField="Fin1stOr2ndHalfYear" HeaderText="1st or 2nd Half Financial Year" />
                                            <asp:BoundField DataField="1stUnitsConsumed" HeaderText="1st Half Year Amount Paid (in Rs)" />
                                            <asp:BoundField DataField="1stAmountPaid" HeaderText="1st half Year Amount Claimed (in Rs)" />
                                            <asp:BoundField DataField="2ndUnitsConsumed" HeaderText="2nd Half Year Amount Paid (in Rs)" />
                                            <asp:BoundField DataField="2ndAmountPaid" HeaderText="2nd half Year Amount Claimed (in Rs)" />
                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="False" />
                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="False" />
                                             <asp:BoundField DataField="CoalQuantity" HeaderText="Coal Quantity" />
                                             <asp:BoundField DataField="UnitofMeasurement" HeaderText="Unit Of Measurement" />
                                             <asp:BoundField DataField="AmountPaid" HeaderText="Amount Paid" />
                                             <asp:BoundField DataField="AmountClaimed" HeaderText="Amount Claimed"/>
                                             <asp:BoundField DataField="IPGQuantity" HeaderText="Quantoty(IPG)"/>
                                             <asp:BoundField DataField="IPGUnits" HeaderText="Units of Measurement(IPG)"/>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                    </asp:GridView>
                                </td>
                            </tr>--%>

                            <%--<tr id="trenergyview" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                    <asp:GridView ID="gvenergyview" runat="server" AutoGenerateColumns="False"
                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                        CssClass="GRD" ForeColor="#333333" Width="95%" EnableModelValidation="True">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FinancialYearNew" HeaderText="Financial Year" />
                                            <asp:BoundField DataField="Fin1stOr2ndHalfYear" HeaderText="1st or 2nd Half Financial Year" />
                                            <asp:BoundField DataField="F_AmountPaid" HeaderText="1st Half Year Amount Paid (in Rs)" />
                                            <asp:BoundField DataField="F_AmountClaimed" HeaderText="1st Half Year Amount Claimed (in Rs)" />
                                            <asp:BoundField DataField="S_AmountPaid" HeaderText="2nd Half Year Amount Paid (in Rs)" />
                                            <asp:BoundField DataField="S_AmountClaimed" HeaderText="2nd Half Year Amount Claimed (in Rs)" />
                                            <asp:BoundField DataField="CoalQuantity" HeaderText="Coal Quantity" />
                                             <asp:BoundField DataField="UnitofMeasurement" HeaderText="Unit Of Measurement" />
                                             <asp:BoundField DataField="AmountPaid" HeaderText="Amount Paid" />
                                             <asp:BoundField DataField="AmountClaimed" HeaderText="Amount Claimed"/>
                                             <asp:BoundField DataField="IPGQuantity" HeaderText="Quantoty(IPG)"/>
                                             <asp:BoundField DataField="IPGUnits" HeaderText="Units of Measurement(IPG)"/>
                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                    </asp:GridView>
                                </td>
                            </tr>--%>
                            <tr id="tr1" runat="server">
                                <td align="center" style="width: 100%">
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Internal Power Genaration</td>
                                        </tr>
                                        <%--<tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <asp:GridView ID="gvProductiondtls" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowDataBound="gvProductiondtls_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Financial year">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit of measurment">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtUnitofMeasurment" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Value in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtValue" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                            </tr>--%>
                                        <tr id="tr4" runat="server">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table style="width: 100%; font-weight: bold;">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">11</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server">Quantity<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtIPGQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">12</td>
                                                        <td>
                                                            <asp:Label ID="Label9" runat="server" CssClass="LBLBLACK" Width="165px">Unit of Measument<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                                                                                        <asp:TextBox ID="txtIPGunitofmeasurement" runat="server" class="form-control txtbox" Text="KWH" Enabled="false"
                                                                Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        
                                                        </td>
                                                    </tr>
                                                    <%--<tr runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label9" runat="server">Unit Of Measurment<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlquantityin" runat="server" class="form-control txtbox" TabIndex="36"
                                                                Height="33px" Width="180px" AutoPostBack="True" Visible="true"
                                                                OnSelectedIndexChanged="ddlquantityin_SelectedIndexChanged">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                                <asp:ListItem Value="Others">Others</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtUnitsConsumed" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="36" Width="180px" Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1" runat="server" visible="false">4</td>
                                                        <td runat="server" visible="false">
                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Value (in Rs.)<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" runat="server" visible="false">:</td>
                                                        <td style="padding: 5px; margin: 5px" runat="server" visible="false">
                                                            &nbsp;</td>
                                                    </tr>--%>
                                                    <%--<tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td class="auto-style1"></td>
                                                        <td align="center">
                                                            <asp:Button ID="btnPowerAdd" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="39" Text="Add New" Width="72px" OnClick="btnPowerAdd_Click" />
                                                        </td>
                                                        <td align="right">&nbsp;</td>
                                                        <td>
                                                            <asp:Button ID="btnPowerClear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="40" Text="Clear" ToolTip="To Clear the Screen" Width="73px" OnClick="btnPowerClear_Click" />
                                                        </td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>--%>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--<tr id="trpower2" runat="server">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                <asp:GridView ID="gvpower" runat="server" AutoGenerateColumns="False"
                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" GridLines="Both" Visible="false"
                                                    Width="65%" DataKeyNames="intLineofActivityMid" OnRowDataBound="gvpower_RowDataBound" OnRowDeleting="gvpower_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FinancialYearId" HeaderText="Financial YearId" Visible="false" />
                                                        <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" Visible="false" />
                                                        <asp:BoundField DataField="AmountPaid" HeaderText="Quantity" />
                                                        <asp:BoundField DataField="UnitsConsumed" HeaderText="Unit Of Measurment" />
                                                        <asp:BoundField DataField="Value" HeaderText="Value (in Rs)" Visible="false" />
                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="False" />
                                                        <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="False" />
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                                </asp:GridView>
                                            </td>
                                        </tr>--%>

                                        <%--<tr id="trpowerview" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                <asp:GridView ID="gvpowerview" runat="server" AutoGenerateColumns="False"
                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" GridLines="Both" Width="65%">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FinancialYearNew" HeaderText="Financial Year" />
                                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                        <asp:BoundField DataField="Unit" HeaderText="Unit Of Measurment" />
                                                        <asp:BoundField DataField="Value" HeaderText="Value (in Rs.)" Visible="false"/>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                                </asp:GridView>
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trSalesTaxExpansion" runat="server">
                                <td align="center" style="width: 100%">
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">Production of Paper</td>
                                        </tr>
                                        <%--<tr>
                                <td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold">
                                    <asp:GridView ID="gvProductiondtls" runat="server" AutoGenerateColumns="False" border="3"
                                        CellPadding="1" CellSpacing="1" OnRowDataBound="gvProductiondtls_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Financial year">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit of measurment">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtUnitofMeasurment" runat="server" class="form-control txtbox"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQuantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="scroll_td" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Value in Rs.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtValue" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
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
                            </tr>--%>
                                        <tr id="trpower1" runat="server">
                                            <td style="padding: 5px; margin: 5px" valign="top">
                                                <table style="width: 100%; font-weight: bold;">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">13</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label3" runat="server">Quantity<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtpaperquantity" runat="server" class="form-control txtbox" onkeypress="return inputOnlyNumbers(event)"
                                                                Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1">14&nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="Label10" runat="server" CssClass="LBLBLACK" Width="165px">Unit of Measument<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px">
                                                                                                                        <asp:TextBox ID="txtunitmeasurement_paper" runat="server" class="form-control txtbox" Text="MT" Enabled="false"
                                                                Height="28px" MaxLength="40" TabIndex="37" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                        
                                                        </td>
                                                    </tr>
                                                    <%--<tr runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">3</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label9" runat="server">Unit Of Measurment<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">:</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:DropDownList ID="ddlquantityin" runat="server" class="form-control txtbox" TabIndex="36"
                                                                Height="33px" Width="180px" AutoPostBack="True" Visible="true"
                                                                OnSelectedIndexChanged="ddlquantityin_SelectedIndexChanged">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                                <asp:ListItem Value="Others">Others</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtUnitsConsumed" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" TabIndex="36" Width="180px" Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" class="auto-style1" runat="server" visible="false">4</td>
                                                        <td runat="server" visible="false">
                                                            <asp:Label ID="Label6" runat="server" CssClass="LBLBLACK" Width="165px">Value (in Rs.)<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px" runat="server" visible="false">:</td>
                                                        <td style="padding: 5px; margin: 5px" runat="server" visible="false">
                                                            &nbsp;</td>
                                                    </tr>--%>
                                                    <%--<tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td class="auto-style1"></td>
                                                        <td align="center">
                                                            <asp:Button ID="btnPowerAdd" runat="server" CssClass="btn btn-xs btn-warning" Height="28px" TabIndex="39" Text="Add New" Width="72px" OnClick="btnPowerAdd_Click" />
                                                        </td>
                                                        <td align="right">&nbsp;</td>
                                                        <td>
                                                            <asp:Button ID="btnPowerClear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger" Height="28px" TabIndex="40" Text="Clear" ToolTip="To Clear the Screen" Width="73px" OnClick="btnPowerClear_Click" />
                                                        </td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>--%>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--<tr id="trpower2" runat="server">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                <asp:GridView ID="gvpower" runat="server" AutoGenerateColumns="False"
                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" GridLines="Both" Visible="false"
                                                    Width="65%" DataKeyNames="intLineofActivityMid" OnRowDataBound="gvpower_RowDataBound" OnRowDeleting="gvpower_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FinancialYearId" HeaderText="Financial YearId" Visible="false" />
                                                        <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" Visible="false" />
                                                        <asp:BoundField DataField="AmountPaid" HeaderText="Quantity" />
                                                        <asp:BoundField DataField="UnitsConsumed" HeaderText="Unit Of Measurment" />
                                                        <asp:BoundField DataField="Value" HeaderText="Value (in Rs)" Visible="false" />
                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="False" />
                                                        <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="False" />
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                        <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                                </asp:GridView>
                                            </td>
                                        </tr>--%>

                                        <%--<tr id="trpowerview" runat="server" visible="false">
                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                <asp:GridView ID="gvpowerview" runat="server" AutoGenerateColumns="False"
                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" GridLines="Both" Width="65%">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FinancialYearNew" HeaderText="Financial Year" />
                                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                                        <asp:BoundField DataField="Unit" HeaderText="Unit Of Measurment" />
                                                        <asp:BoundField DataField="Value" HeaderText="Value (in Rs.)" Visible="false"/>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="9px" />
                                                </asp:GridView>
                                            </td>
                                        </tr>--%>
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
                                        
                                        <tr runat="server" visible="false">
                                            <td colspan="3" style="padding: 3px; margin: 3px; text-align: left; font-weight: bold">During all subsequent claims
                                            </td>
                                        </tr>
                                        
                                        
                                        <tr>
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">1. SCCL CERTIFICATE/INVOICE
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FUPSCCLINVOICE" runat="server" CssClass="CS" Height="28px" />
                                                <asp:HyperLink ID="HYPSCCLINVOICE" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LBLSCCLINVOICE" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="BTNSCCLINVOICE" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="BTNSCCLINVOICE_Click" />
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">1(b). SCL/CA CERTIFICATE
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FUPSCLORCACERTIFICATE" runat="server" CssClass="CS" Height="28px" />
                                                <asp:HyperLink ID="HYPSCLORCACERTIFICATE" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LBLSCLORCACERTIFICATE" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="BTNSCLORCACERTIFICATE" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="BTNSCLORCACERTIFICATE_Click" />
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">2. Way Bridge Documents/CA Certificate
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupwaybilldocuments" runat="server" CssClass="CS" Height="28px" />
                                                <asp:HyperLink ID="hypwaybilldocuments" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblwaybilldocuments" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnwaybilldocuments" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btnwaybilldocuments_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">3. Proof of Payment Receipts/Bank Statements
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="fupproofofpaymentreceipts" runat="server" CssClass="CS" Height="28px" />
                                                <asp:HyperLink ID="hypproofofpaymentreceipts" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="lblproofofpaymentreceipts" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="btnproofofpaymentreceipts" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="btnproofofpaymentreceipts_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">4. CA Certificate(for Internal Power Generation/for Paper Production
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FUPCACERTIFICATE" runat="server" CssClass="CS" Height="28px" />
                                                <asp:HyperLink ID="HypCACERTIFICATE" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:Label ID="LBLCACERTIFICATE" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="BTNCACERTIFICATE" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="BTNCACERTIFICATE_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 3px; margin: 3px; text-align: left;" valign="top">5. Attested copy of Valid CFO
                                            </td>
                                            <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                <asp:FileUpload ID="FUPCFOCOPY" runat="server" CssClass="CS" Height="28px" />
                                                <asp:HyperLink ID="HypCFOCOPY" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                <br />
                                                <asp:HiddenField ID="HDNCOALID" runat="server" Visible="false" />
                                                <asp:Label ID="LBLCFOCOPY" runat="server" Visible="False"></asp:Label>
                                            </td>
                                            <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                                <asp:Button ID="BTNCFOCOPY" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                    TabIndex="10" Text="Upload" Width="72px" OnClick="BTNCFOCOPY_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                            </tr>
                            <tr>
                                <td colspan="8" style="padding: 5px; margin: 5px; text-align: left;">
                                    <b>DECLARATION :  </b>
                                    <br />
                                    I / We hereby confirm that to the best of our knowledge and belief, information given herein
before and other papers enclosed are true and correct in all respects. We further undertake to
substantiate the particulars about promoter(s) and other details with documentary evidence as
and when called for.<br />
                                    I/We hereby agree that I/We shall forthwith repay the amount to me/us under  &nbsp; <asp:Label ID="lblscheme" runat="server"></asp:Label>
                                &nbsp;, if the
amount of seed capital assistance are found to be disbursed in excess of the amount actually
admissible whatsoever the reason.

                                </td>
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
                                        OnClick="BtnClear0_Click" TabIndex="10" Text="Next" ValidationGroup="group" Width="90px"  Enabled="false"/>
                                    &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
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

