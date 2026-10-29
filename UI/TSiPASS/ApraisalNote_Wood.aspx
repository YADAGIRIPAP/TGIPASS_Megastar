<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="ApraisalNote_Wood.aspx.cs" Inherits="UI_TSiPASS_ApraisalNote_Wood" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>


    <script type="text/javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility  
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }


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
    <style type="text/css">
        .headerStyle {
            background-color: #FF6600;
            color: #FFFFFF;
            font-size: 12pt;
            font-weight: bold;
        }

        .itemStyle {
            background-color: #FFFFEE;
            color: #000000;
            font-size: 8pt;
        }

        .alternateItemStyle {
            background-color: #FFFFFF;
            color: #000000;
            font-size: 8pt;
        }

        .auto-style1 {
            height: 42px;
        }

        .auto-style2 {
            height: 42px;
            font-weight: bold;
        }

        .auto-style3 {
            height: 51px;
            width: 286px;
        }

        .auto-style4 {
            width: 286px;
        }

        .auto-style5 {
            width: 193px;
        }

        .auto-style6 {
            height: 42px;
            width: 193px;
        }

        .auto-style10 {
            width: 187px;
        }

        .auto-style11 {
            height: 42px;
            width: 187px;
        }

        .auto-style12 {
            width: 14px;
        }

        .auto-style13 {
            height: 42px;
            font-weight: bold;
            width: 14px;
        }

        .auto-style14 {
            font-weight: bold;
            width: 14px;
        }

        .auto-style15 {
            width: 24px;
        }

        .auto-style16 {
            height: 42px;
            width: 24px;
        }

        .auto-style18 {
            width: 3px;
        }

        .auto-style19 {
            height: 42px;
            width: 3px;
        }

        .auto-style20 {
            width: 12px;
        }

        .auto-style23 {
            height: 42px;
            width: 226px;
        }

        .auto-style24 {
            font-weight: bold;
            width: 226px;
        }

        .auto-style25 {
            width: 226px;
        }

        .auto-style26 {
            height: 51px;
            width: 294px;
        }

        .auto-style27 {
            width: 294px;
        }

        .auto-style28 {
            width: 203px;
        }

        .auto-style29 {
            width: 153px;
        }

        .auto-style30 {
            height: 42px;
            width: 271px;
        }

        .auto-style31 {
            width: 271px;
        }

        .auto-style32 {
            height: 42px;
            width: 221px;
        }

        .auto-style33 {
            width: 221px;
        }

        .auto-style39 {
            width: 226px;
            height: 49px;
        }

        .auto-style41 {
            font-weight: bold;
            width: 226px;
            height: 48px;
        }

        .auto-style42 {
            width: 286px;
            height: 48px;
        }

        .auto-style43 {
            font-weight: bold;
            width: 14px;
            height: 48px;
        }

        .auto-style44 {
            width: 187px;
            height: 48px;
        }

        .auto-style45 {
            width: 3px;
            height: 48px;
        }

        .auto-style46 {
            width: 193px;
            height: 48px;
        }

        .auto-style47 {
            width: 12px;
            height: 48px;
        }

        .auto-style48 {
            height: 48px;
        }

        .auto-style49 {
            font-weight: bold;
            width: 14px;
            height: 49px;
        }

        .auto-style50 {
            width: 187px;
            height: 49px;
        }

        .auto-style51 {
            width: 3px;
            height: 49px;
        }

        .auto-style52 {
            width: 193px;
            height: 49px;
        }

        .auto-style53 {
            width: 12px;
            height: 49px;
        }

        .auto-style54 {
            height: 49px;
        }

        .auto-style55 {
            height: 58px;
        }

        .auto-style56 {
            height: 55px;
        }

        .auto-style57 {
            width: 220px;
            height: 55px;
        }

        .auto-style58 {
            height: 53px;
        }

        .auto-style59 {
            height: 52px;
        }

        .auto-style60 {
            height: 51px;
        }

        .auto-style61 {
            height: 50px;
        }

        .auto-style62 {
            height: 54px;
        }

        .auto-style63 {
            height: 52px;
            font-weight: bold;
        }

        .auto-style64 {
            height: 52px;
            width: 221px;
        }

        .auto-style65 {
            height: 52px;
            width: 271px;
        }

        .auto-style66 {
            font-weight: bold;
            height: 50px;
        }

        .auto-style67 {
            width: 221px;
            height: 50px;
        }

        .auto-style69 {
            width: 271px;
            height: 50px;
        }

        .auto-style70 {
            height: 58px;
            font-weight: bold;
        }

        .auto-style71 {
            height: 58px;
            width: 221px;
        }

        .auto-style72 {
            height: 58px;
            width: 271px;
        }

        .auto-style73 {
            font-weight: bold;
            height: 51px;
        }

        .auto-style74 {
            width: 221px;
            height: 51px;
        }

        .auto-style75 {
            width: 271px;
            height: 51px;
        }

        .auto-style76 {
            width: 221px;
            height: 53px;
        }

        .auto-style77 {
            font-weight: bold;
            height: 53px;
        }

        .auto-style78 {
            width: 271px;
            height: 53px;
        }

        .auto-style79 {
            font-weight: bold;
            height: 49px;
        }

        .auto-style80 {
            width: 221px;
            height: 49px;
        }

        .auto-style82 {
            width: 271px;
            height: 49px;
        }

        .auto-style83 {
            font-weight: bold;
            height: 54px;
        }

        .auto-style84 {
            width: 221px;
            height: 54px;
        }

        .auto-style86 {
            height: 51px;
            width: 2%;
        }

        .auto-style87 {
            font-weight: bold;
            height: 48px;
        }

        .auto-style88 {
            width: 294px;
            height: 48px;
        }

        .auto-style90 {
            width: 294px;
            height: 54px;
        }

        .auto-style92 {
            width: 286px;
            height: 54px;
        }
    </style>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updappraosalnote">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updappraosalnote" runat="server">
      
        <ContentTemplate>

  <div class="panel-heading">
                <h3 class="panel-title"> </h3>
            </div>
    <div id="divprint">
        <table style="width: 100%">
            <tr id="tideaTr" runat="server">
                <td style="text-align: left; font-weight: bold;">
                    <asp:Label ID="lblTideaTpride" runat="server" Visible="false" Text="Label"></asp:Label>
                    Telangana State Industrial Development and Entrepreneur Advancement - G.O M.S. NO 28, Industries &amp; Commerce (IP &amp; INF) Department,
                    <br />
                    Dated : 29/11/2014
                </td>
            </tr>
            <tr id="tprideTr" runat="server">
                <td style="text-align: left; font-weight: bold;">Telangana State Program for Rapid Incubation of Dalit Entrepreneurs - G.O M.S. NO 28, Industries &amp; Commerce (IP &amp; INF) Department,
                    <br />
                    Dated : 29/11/2014
                </td>
            </tr>
                     <tr id="TRMSME" runat="server">
    <td style="text-align: left; font-weight: bold;">Micro, Small & Medium Enterprises Policy,2024 - G.O M.S. NO 6, Industries and Commerce (FP &amp; MSME) Department                   Dated : 23/03/2026
    </td>
</tr>
            <tr>
                <td style="text-align: center; font-weight: bold;">
                    <u>Sanction of Investment Subsidy - Appraisal Note</u></td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>Enter Incentive Application no
                            </td>
                            <td></td>
                            <td>

                                <asp:TextBox ID="txtINCNoEntry" class="form-control txtbox" Height="28px" MaxLength="80"
                                    TabIndex="2" runat="server" Width="150px"></asp:TextBox>

                            </td>
                            <td></td>
                            <td>
                                <asp:Button ID="btnINCSearch" CssClass="btn btn-xs btn-warning" runat="server" Text="Search" Height="30px" OnClick="btnINCSearch_Click" />
                            </td>
                            <td colspan="5px"></td>
                            <td>Print Application no
                            </td>
                            <td></td>
                            <td>

                                <asp:TextBox ID="txtPrintINCID" Visible="false" class="form-control txtbox" Height="28px" MaxLength="80"
                                    TabIndex="2" runat="server" Width="150px"></asp:TextBox>


                            </td>
                            <td id="printTD" runat="server" visible="false">Please select incentive type
                                        <asp:DropDownList ID="ddlIcnetiveName" Height="30px" runat="server" Width="89px"></asp:DropDownList>
                            </td>
                            <td>

                                <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-xs btn-warning" Height="30px" Text="Print" OnClick="btnPrint_Click" />

                            </td>
                        </tr>
                    </table>

                </td>


            </tr>
            <tr>
                <td style="height: 30px" colspan="2"></td>
            </tr>
        </table>
        <table style="width: 100%">

            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">2.0
                </td>
                <td style="padding: 5px; margin: 5px; width: 220px">Application no <font color="red">*</font>
                </td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;">
                    <asp:Label ID="lblApplicationno" runat="server" Width="150px" TabIndex="1"></asp:Label>
                </td>
                <td style="padding: 5px; margin: 5px;"></td>
                <td style="padding: 5px; margin: 5px; font-weight: bold;">2.1
                </td>
                <td style="padding: 5px; margin: 5px;">Name of Industrial Concern <font color="red">*</font>
                </td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;">
                    <asp:TextBox ID="txtunitnames" class="form-control txtbox" Height="28px" MaxLength="80"
                        TabIndex="2" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td style="padding: 5px; margin: 5px;"></td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;">2.2
                </td>
                <td style="padding: 5px; margin: 5px;">Location of the Industrial concern <font color="red">*</font>
                </td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;">
                    <asp:TextBox ID="txtLocofUnit" runat="server" class="form-control txtbox" Height="80px" TextMode="MultiLine" MaxLength="80" TabIndex="2" Width="150px"></asp:TextBox>
                </td>
                <td style="padding: 5px; margin: 5px;"></td>
                <td style="padding: 5px; margin: 5px; font-weight: bold;">2.3
                </td>
                <td style="padding: 5px; margin: 5px;">Constitution of the Industrial Concern <font color="red">*</font>
                </td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;">
                    <asp:DropDownList ID="ddlOrddlorgtypes" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" TabIndex="5" Width="180px">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="padding: 5px; margin: 5px;"></td>
            </tr>

            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;">2.4<br />
                    a.
                </td>
                <td style="padding: 5px; margin: 5px;">Whether the SSI Prov. regn. or any other regn/ approval in terms of IEM, ackngmnt LI/IL etc., has the continuity in validity of commercial production. <font color="red">*</font>
                </td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;">
                    <asp:DropDownList ID="ddlUdyogAadharType" runat="server" class="form-control txtbox" Height="33px" RepeatDirection="Horizontal" TabIndex="1" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="padding: 5px; margin: 5px;"></td>
                <td style="padding: 5px; margin: 5px; font-weight: bold;">2.4<br />
                    b. 
                </td>
                <td style="padding: 5px; margin: 5px; width: 220px">PMT/SSI/IEM acknowledgement, LI/IL No &amp; Dt <font color="red">*</font>
                </td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;">
                    <asp:TextBox ID="txtPersonIndustry" Width="150px" class="form-control txtbox" Height="28px"
                        MaxLength="100" TabIndex="6" runat="server"></asp:TextBox>
                </td>
                <td style="padding: 5px; margin: 5px;"></td>
            </tr>

            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;">2.5
                </td>
                <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold;">PRODUCTS MANUFACTURED</td>
            </tr>
            <tr>
                <td></td>
                <td>Line of Acitvity</td>
                <td></td>
                <td>

                    <asp:TextBox ID="txtLOActivity" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
                <td></td>
                <td></td>
                <td>Installed Capacity</td>
                <td></td>
                <td>

                    <asp:TextBox ID="txtinstalledccap" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>Units</td>
                <td></td>
                <td>

                    <asp:DropDownList ID="ddlquantityin" runat="server" class="form-control txtbox" TabIndex="5"
                        Height="33px" Width="180px" AutoPostBack="True" Visible="true" OnSelectedIndexChanged="ddlquantityin_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="KG">KG</asp:ListItem>
                        <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                        <asp:ListItem Value="Liters">Litres</asp:ListItem>
                        <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:TextBox ID="txtunit" runat="server" class="form-control txtbox" Visible="false"
                        Height="28px" MaxLength="40" TabIndex="5" onkeypress="Names()"
                        Width="180px"></asp:TextBox>

                </td>
                <td></td>
                <td></td>
                <td>Value in Rs.</td>
                <td></td>
                <td>

                    <asp:TextBox ID="txtvalue" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td align="center">
                    <asp:Button ID="btnInstalledcap" runat="server" CssClass="btn btn-xs btn-warning"
                        Height="28px" TabIndex="5" Text="Add" Width="72px" OnClick="btnInstalledcap_Click" />
                </td>
                <td align="right">&nbsp;
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                        Height="28px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px"
                        OnClick="Button2_Click" />
                </td>

            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="9">
                    <asp:GridView ID="gvInstalledCap" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                        GridLines="Both" Visible="false" Width="90%" OnRowDeleting="gvInstalledCap_RowDeleting" OnRowCommand="gvInstalledCap_RowCommand" OnRowDataBound="gvInstalledCap_RowDataBound" OnSelectedIndexChanged="gvInstalledCap_SelectedIndexChanged">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No">
                                <ItemTemplate>
                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                            <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
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
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="9">
                    <asp:GridView ID="gvInstalledCapNew" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                        GridLines="Both" Visible="false" Width="90%">
                        <RowStyle BackColor="#ffffff" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                            <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
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

            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">2.6
                </td>
                <td colspan="5" style="padding: 5px; margin: 5px;">
                    <b>INITIAL STEPS TAKEN FOR IMPLEMENTATION</b> </td>



                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top"></td>
                <td style="padding: 5px; margin: 5px;">Date of filing of application with the lead financial Institution for term loan/Date of openings of first Public issue is financed through public issues.</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtDateOfapplnFile" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px; font-weight: bold;" valign="top"></td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;"></td>
                <td>&nbsp;
                </td>
            </tr>

            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">2.7<br />
                    a</td>
                <td style="padding: 5px; margin: 5px;">In case term loan obtained from the Financial Institution/Bank Term loan sanction letter No. and date.</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtLoanApplnNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtDate_Loan" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px; font-weight: bold;" valign="top">2.7.<br />
                    b.</td>
                <td style="margin: 5px;">Name of the Financing Institution. Lead Instn. in case of Joint finance.</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtNameofFinIns" runat="server" Text="NA" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">2.8</td>
                <td style="padding: 5px; margin: 5px;">Date of Power connection with connected load</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px; vertical-align: bottom">
                    <asp:TextBox ID="txtPowerConn_date" runat="server" class="form-control txtbox" Height="28px" placeholder="Please enter date" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                    <br />
                    <asp:TextBox ID="txtPowerConn_load" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px; font-weight: bold;" valign="top">2.9</td>
                <td style="margin: 5px;">Date of Commencement of Commercial production</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtDCP_unit" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">2.10<br />
                    a.</td>
                <td style="padding: 5px; margin: 5px;">Date of receipt of claim application(in DIC)</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtrc_dic" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px; font-weight: bold;" valign="top">2.10<br />
                    b.</td>
                <td style="margin: 5px;">Date of communication of shortfalls to the party(in DIC)</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtquery_dic" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">2.10<br />
                    c.</td>
                <td style="padding: 5px; margin: 5px;">Date of receipt of complete information from the party(in DIC)</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtcompdate_dic" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">2.10<br />
                    a.</td>
                <td style="padding: 5px; margin: 5px;">Date of receipt of claim application(in COI)</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtcompdate_coi" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px; font-weight: bold;" valign="top">2.10<br />
                    b.</td>
                <td style="margin: 5px;">Date of communication of shortfalls to the party(in COI)</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtquery_coi" placeholder="Please enter date" Text="NA" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">2.10<br />
                    c.</td>
                <td style="padding: 5px; margin: 5px;">Date of receipt of complete information from the party<br />
                    (in COI)</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtcompdate_coi1" placeholder="Please enter date" Text="NA" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <br />

                </td>
            </tr>



            <tr id="checkTR" runat="server" visible="false">
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">2.10<br />
                    a.</td>
                <td style="padding: 5px; margin: 5px;">Date of receipt of claim application(in COI)</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="TextBox3" Text="NA" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px; font-weight: bold;" valign="top">2.10<br />
                    b.</td>
                <td style="margin: 5px;">Date of communication of shortfalls to the party(in COI)</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="TextBox4" Text="NA" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>

                <td colspan="4">
                    <b>2.12. Approved Project Cost As Per Guidelines (Rs. in Lakhs)
                    </b>

                </td>
                <td></td>
                <td></td>
                <td colspan="4">
                    <b>Means of finance(Rs in Lakhs) 
                    </b>

                </td>

            </tr>
            <tr>
                <td class="auto-style58"></td>
                <td class="auto-style58">a. Land 
                </td>
                <td class="auto-style58"></td>
                <td class="auto-style58">

                    <asp:TextBox ID="TextBox60" onkeypress="DecimalOnly()" Text="0" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
                <td class="auto-style58"></td>
                <td class="auto-style58"></td>
                <td class="auto-style58">1. Own share capital</td>
                <td class="auto-style58"></td>
                <td class="auto-style58">

                    <asp:TextBox ID="TextBox61" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px" OnTextChanged="TextBox61_TextChanged"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style59"></td>
                <td class="auto-style59">b. Building 
                </td>
                <td class="auto-style59"></td>
                <td class="auto-style59">

                    <asp:TextBox ID="TextBox5" runat="server" onkeypress="DecimalOnly()" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
                <td class="auto-style59"></td>
                <td class="auto-style59"></td>
                <td class="auto-style59">2. State Subsidy </td>
                <td class="auto-style59"></td>
                <td class="auto-style59">

                    <asp:TextBox ID="TextBox6" Text="0" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style59"></td>
                <td class="auto-style59">c. Plant &amp; M/C 
                </td>
                <td class="auto-style59"></td>
                <td class="auto-style59">

                    <asp:TextBox ID="TextBox7" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
                <td class="auto-style59"></td>
                <td class="auto-style59"></td>
                <td class="auto-style59">3. Funds through public issues </td>
                <td class="auto-style59"></td>
                <td class="auto-style59">

                    <asp:TextBox ID="TextBox8" runat="server" Text="0" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style60"></td>
                <td class="auto-style60">d. Preliminery/Preoperative expenditure 
                </td>
                <td class="auto-style60"></td>
                <td class="auto-style60">

                    <asp:TextBox ID="TextBox9" runat="server" onkeypress="DecimalOnly()" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
                <td class="auto-style60"></td>
                <td class="auto-style60"></td>
                <td class="auto-style60">4. Soft,loan/capital </td>
                <td class="auto-style60"></td>
                <td class="auto-style60">

                    <asp:TextBox ID="TextBox10" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td></td>
                <td>e. (i). Tech-know how feasibility study
                            <br />
                    and turn key charges 
                </td>
                <td></td>
                <td>

                    <asp:TextBox ID="TextBox11" runat="server" onkeypress="DecimalOnly()" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
                <td></td>
                <td></td>
                <td>5. Term loan </td>
                <td></td>
                <td>

                    <asp:TextBox ID="TextBox12" runat="server" class="form-control txtbox" Height="28px" onkeypress="DecimalOnly()" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td class="auto-style54"></td>
                <td class="auto-style54">(ii). Vehicles </td>
                <td class="auto-style54"></td>
                <td class="auto-style54">
                    <asp:TextBox ID="TextBox13" runat="server" Text="0" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td class="auto-style54"></td>
                <td class="auto-style54"></td>
                <td class="auto-style54">6. Unsecured loans </td>
                <td class="auto-style54"></td>
                <td class="auto-style54">
                    <asp:TextBox ID="TextBox14" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style61"></td>
                <td class="auto-style61">(iii). Others </td>
                <td class="auto-style61"></td>
                <td class="auto-style61">
                    <asp:TextBox ID="TextBox15" runat="server" Text="0" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td class="auto-style61"></td>
                <td class="auto-style61"></td>
                <td class="auto-style61">7. Working capital loan&nbsp; </td>
                <td class="auto-style61"></td>
                <td class="auto-style61">
                    <asp:TextBox ID="TextBox16" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style62"></td>
                <td class="auto-style62">f. Others </td>
                <td class="auto-style62"></td>
                <td class="auto-style62">
                    <asp:TextBox ID="TextBox17" runat="server" Text="0" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="auto-style58"></td>
                <td class="auto-style58">g. Working Capital </td>
                <td class="auto-style58"></td>
                <td class="auto-style58">
                    <asp:TextBox ID="TextBox18" runat="server" Text="0" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td></td>
                <td><b>Total: Rs.</b> </td>
                <td></td>
                <td>
                    <asp:TextBox ID="TextBox19" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
                <td><b>Total: Rs.</b> </td>
                <td></td>
                <td>
                    <asp:TextBox ID="TextBox20" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table style="width: 100%; font-weight: bold;">
            <tr>
                <td colspan="5">
                    <b>2.13. Details of Investment on fixed Capital assets as on:</b>
                </td>
            </tr>
            <tr>
                <td align="center" style="border: solid thin white; background: #013161; color: white">&nbsp;&nbsp;&nbsp;Name of Asset&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">Project Cost as Approved<br />
                    (In Rs.)
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">Loan Sanctioned
                                                                                            <br />
                    (In Rs.)
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">Loan Disbursed<br />
                    (In Rs.)
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">Assets Certified by<br />
                    Banks/ Fin Instn. as on<br />
                    (in Rs.)</td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">Assets expr incurred<br />
                    as per C.A (In Rs.)</td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">Value Recommended<br />
                    by G.M (In Rs.)</td>
            </tr>
            <tr>
                <td align="center" style="border: solid thin white; background: #013161; color: white">1
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">2&nbsp;
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">3
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">4
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">5
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">6
                </td>
                <td align="center" style="border: solid thin white; background: #013161; color: white">7
                </td>
            </tr>
            <tr>
                <td style="border: solid thin black; background: white; color: black">a. Land-Purchased</td>
                <td style="padding-top: 5px; border: solid thin black; background: white; color: black;">
                    <asp:TextBox ID="txtLand2" runat="server" class="form-control txtbox" Height="28px"
                        TabIndex="5" onkeypress="DecimalOnly()"></asp:TextBox>
                </td>
                <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtLand3" runat="server" class="form-control txtbox" Height="28px"
                        TabIndex="5" onkeypress="DecimalOnly()"></asp:TextBox>
                </td>
                <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtLand4" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtLand5" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtLand6" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtLand7" runat="server" class="form-control txtbox" Height="28px"
                        AutoPostBack="false" onkeypress="DecimalOnly()" MaxLength="40" TabIndex="5" OnTextChanged="txtLand7_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border: solid thin black; background: white; color: black">b. Building-Constructed
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtBuilding2" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtBuilding3" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtBuilding4" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtBuilding5" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtBuilding6" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtBuilding7" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"
                        OnTextChanged="txtBuilding7_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border: solid thin black; background: white; color: black">c. Plant &amp; M/C</td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtPM2" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtPM3" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtPM4" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtPM5" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtPM6" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtPM7" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"
                        OnTextChanged="txtPM7_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border: solid thin black; background: white; color: black">d.Tech.Knows -how feasibility<br />
                    study &amp; turn key charges</td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtMCont2" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtMCont3" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtMCont4" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtMCont5" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtMCont6" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtMCont7" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border: solid thin black; background: white; color: black">e.Vechicles</td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtErec2" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtErec3" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtErec4" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtErec5" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtErec6" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtErec7" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border: solid thin black; background: white; color: black">f.Other eligible</td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtTFS2" runat="server" class="form-control txtbox" Height="40px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtTFS3" runat="server" class="form-control txtbox" Height="40px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtTFS4" runat="server" class="form-control txtbox" Height="40px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtTFS5" runat="server" class="form-control txtbox" Height="40px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtTFS6" runat="server" class="form-control txtbox" Height="40px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtTFS7" runat="server" class="form-control txtbox" Height="40px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border: solid thin black; background: white; color: black">Total</td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtWC2" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtWC3" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtWC4" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtWC5" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtWC6" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
                <td style="border: solid thin black; background: white; color: black">
                    <asp:TextBox ID="txtWC7" runat="server" class="form-control txtbox" Height="28px"
                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                </td>
            </tr>
            <%--<tr>
                                                                    <td style="border:solid thin black; background: white; color:black">Total</td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal2" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal3" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal4" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal5" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal6" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal7" runat="server"></asp:Label></td>                                                                                    
                                                                </tr>--%>
        </table>
        <table style="width: 100%">
            <tr style="height: 30px">
                <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                    <b>2.14. </b>
                </td>
                <td colspan="4" style="padding: 5px; margin: 5px;">
                    <b>Computation of Capital Cost</b> </td>



                <td>&nbsp;
                </td>

            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                    <b>&nbsp;A.</b></td>
                <td colspan="4" style="padding: 5px; margin: 5px;">
                    <b>LAND</b></td>



                <td>
                    <b>B.</b></td>
                <td colspan="3" style="padding: 5px; margin: 5px;">
                    <b>FACTORY BUILDINGS</b></td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style63">i)&nbsp;</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style64">As per approved project cost.</td>
                <td style="margin: 5px;" class="auto-style59">:</td>
                <td style="margin: 5px;" class="auto-style59">
                    <asp:TextBox ID="txtLandcostCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td style="margin: 5px;" class="auto-style59">&nbsp;
                </td>
                <td style="margin: 5px; font-weight: bold;" valign="top" class="auto-style59">i).</td>
                <td style="margin: 5px;" class="auto-style65">As per Approved Project cost in Rs.</td>
                <td style="margin: 5px;" class="auto-style59">:</td>
                <td style="margin: 5px;" class="auto-style59">
                    <asp:TextBox ID="txtfacCostCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td class="auto-style59">&nbsp;
                </td>
            </tr>

            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style66">ii).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style67">Land measuring in Sq.mts.</td>
                <td style="margin: 5px;" class="auto-style61">:</td>
                <td style="margin: 5px;" class="auto-style61">
                    <asp:TextBox ID="txtLandAreaCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style61">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="auto-style66">ii).</td>
                <td style="margin: 5px;" class="auto-style69">Factory building's plinth area/item wise<br />
                    total value assessed by G.M,DIC.in Rs</td>
                <td style="margin: 5px;" class="auto-style61">:</td>
                <td style="margin: 5px;" class="auto-style61">
                    <asp:TextBox ID="txtfacBldgCompc" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td class="auto-style61">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style70">iii).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style71">Purchase value as per in document.</td>
                <td style="margin: 5px;" class="auto-style55">:</td>
                <td style="margin: 5px;" class="auto-style55">
                    <asp:TextBox ID="txtPurchaCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style55">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="auto-style70">iii).</td>
                <td style="margin: 5px;" class="auto-style72">As per Civil Engineer&#39;s Certificate in Rs.</td>
                <td style="margin: 5px;" class="auto-style55">:</td>
                <td style="margin: 5px;" class="auto-style55">
                    <asp:TextBox ID="txtcivilEngCompc" Text="0" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td class="auto-style55">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style73">iv).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style74">Stamp Duty in Rs.</td>
                <td style="margin: 5px;" class="auto-style60">:</td>
                <td style="margin: 5px;" class="auto-style60">
                    <asp:TextBox ID="txtStmpDutyCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style60">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="auto-style73">iv).</td>
                <td style="margin: 5px;" class="auto-style75">Value assesses as per TSSSFC rates<br />
                    in Rs.</td>
                <td style="margin: 5px;" class="auto-style60">:</td>
                <td style="margin: 5px;" class="auto-style60">
                    <asp:TextBox ID="txtsfcCompc" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td class="auto-style60">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style58">v).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style76">Registration fee in Rs.</td>
                <td style="margin: 5px;" class="auto-style58">:</td>
                <td style="margin: 5px;" class="auto-style58">
                    <asp:TextBox ID="txtRegnfeeCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style58">&nbsp;
                </td>

                <td style="margin: 5px;" valign="top" class="auto-style77">v).</td>
                <td style="margin: 5px;" class="auto-style78">Expenditure as per C.A Certificate<br />
                    in Rs.</td>
                <td style="margin: 5px;" class="auto-style58">:</td>
                <td style="margin: 5px;" class="auto-style58">
                    <asp:TextBox ID="txtCAExpCompc" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td class="auto-style58">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style79">vi)</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style80">Total</td>
                <td style="margin: 5px;" class="auto-style54">:</td>
                <td style="margin: 5px;" class="auto-style54">
                    <asp:TextBox ID="txtTotalCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style54">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="auto-style79">vi).</td>
                <td style="margin: 5px;" class="auto-style82">Computed Value</td>
                <td style="margin: 5px;" class="auto-style54">:</td>
                <td style="margin: 5px;" class="auto-style54">
                    <asp:TextBox ID="txtCompvalCompc" runat="server" Text="0" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td class="auto-style54">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">vii)</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style33">Building plinth area in Sq.Mts.</td>
                <td style="margin: 5px;">:</td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtBuildingAreCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>

                <td style="margin: 5px;" valign="top" class="ui-priority-primary">vii).</td>
                <td style="margin: 5px;" class="auto-style31">Reasons of variations with that of G.M.'s recommendation.</td>
                <td style="margin: 5px;">:</td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtrsnCompc" runat="server" class="form-control txtbox" Text="NA" TabIndex="6" Height="80px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style83">viii)</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style84">Value recommended by G.M DIC. in Rs.</td>
                <td style="margin: 5px;" class="auto-style62">:</td>
                <td style="margin: 5px;" class="auto-style62">
                    <asp:TextBox ID="txtvalDICCompc" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style62">&nbsp;
                </td>


            </tr>

            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">ix)
                </td>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style33">Value Computed in Rs.</td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;">
                    <asp:TextBox ID="txtvalCompc1" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="30px"
                        MaxLength="80" TabIndex="10"
                        Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">x)
                </td>
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top" class="auto-style33">Reasons of variations with
                    <br />
                    that of G.M.&#39;s recommendation.
                </td>
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">:
                </td>
                <td style="padding: 5px; margin: 5px; text-align: left;" valign="top">
                    <asp:TextBox ID="txtresonsCompc" Text="NA" runat="server" class="form-control txtbox" TabIndex="11"
                        Height="80px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <br />

                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                    <b>C.</b></td>
                <td colspan="4" style="padding: 5px; margin: 5px;">
                    <b>PLANT AND MACHINERY</b></td>



                <td>&nbsp;</td>
                <td colspan="3" style="padding: 5px; margin: 5px;">&nbsp;</td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style2">i)&nbsp;</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style32">As per approved project cost.</td>
                <td style="margin: 5px;" class="auto-style1">:</td>
                <td style="margin: 5px;" class="auto-style1">
                    <asp:TextBox ID="TextBox30" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td style="margin: 5px;" class="auto-style1">&nbsp;
                </td>
                <td style="margin: 5px; font-weight: bold;" valign="top" class="auto-style1">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style30">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style1"></td>
                <td style="margin: 5px;" class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;
                </td>
            </tr>

            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">ii).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style33">Technical know-how &amp; feasibility study and turnkey charges as per approved project cost.</td>
                <td style="margin: 5px;">:</td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="TextBox32" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style31">&nbsp;</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style66"></td>
                <td style="padding: 5px; text-align: center; margin: 5px;" class="auto-style67">
                    <b>Sub Total Rs.</b></td>
                <td style="margin: 5px;" class="auto-style61">:</td>
                <td style="margin: 5px;" class="auto-style61">
                    <asp:TextBox ID="TextBox31" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style61">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="auto-style66"></td>
                <td style="margin: 5px;" class="auto-style69"></td>
                <td style="margin: 5px;" class="auto-style61"></td>
                <td style="margin: 5px;" class="auto-style61"></td>
                <td class="auto-style61">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">iii).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style33">As recommended by G.M.,DIC</td>
                <td style="margin: 5px;">:</td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="TextBox34" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style31">&nbsp;</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">iv).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style33">As per the M/C Statement(s) certified by fin.Instn in case aided units. As per M/C statement supported by copies of purchase invoices and certified by G.M (in case of financed/financed through public issues without any loan).</td>
                <td style="margin: 5px;">:</td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="TextBox36" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style31">
                    <br />
                </td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">v).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style33">As per C.A. Certificate</td>
                <td style="margin: 5px;">:</td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="TextBox38" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>

                <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style31">&nbsp;</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">vi)</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style33">Whether technical know-how &amp; feasibility &amp; turnkey charges capitilised and Certificate to this effect produced from C.A.</td>
                <td style="margin: 5px;">:</td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="TextBox40" Text="0" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style31">&nbsp;</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style63">vii)</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style64">Computed value in Rs.</td>
                <td style="margin: 5px;" class="auto-style59">:</td>
                <td style="margin: 5px;" class="auto-style59">
                    <asp:TextBox ID="TextBox42" runat="server" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style59">&nbsp;
                </td>

                <td style="margin: 5px;" valign="top" class="auto-style63"></td>
                <td style="margin: 5px;" class="auto-style65"></td>
                <td style="margin: 5px;" class="auto-style59"></td>
                <td style="margin: 5px;" class="auto-style59"></td>
                <td class="auto-style59">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style2">viii)</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style32">Reasons of Variations with that of G.M. recommendation.</td>
                <td style="margin: 5px;" class="auto-style1">:</td>
                <td style="margin: 5px;" class="auto-style1">
                    <asp:TextBox ID="TextBox47" runat="server" Text="NA" class="form-control txtbox" Height="80px" TabIndex="11" TextMode="MultiLine"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style1">&nbsp;
                </td>


            </tr>

        </table>
        <table style="width: 100%">
            <tr style="height: 30px">
                <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12">D<b>. </b>
                </td>
                <td colspan="4" style="padding: 5px; margin: 5px;">
                    <b>ABSTRACT</b> </td>



                <td class="auto-style25">&nbsp;
                </td>

            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12">&nbsp;</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style10">&nbsp;</td>



                <td class="auto-style18">&nbsp;</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style5">
                    <b>As per approved costs</b></td>

                <td class="auto-style15"></td>
                <td class="auto-style25">
                    <b>Computed as eligible Investment</b>

                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style13">i)&nbsp;</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style11">Land</td>
                <td style="margin: 5px;" class="auto-style19"></td>
                <td style="margin: 5px;" class="auto-style6">
                    <asp:TextBox ID="TextBox33" runat="server" AutoPostBack="true" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px" OnTextChanged="TextBox33_TextChanged"></asp:TextBox>
                </td>

                <td style="margin: 5px; font-weight: bold;" valign="top" class="auto-style16">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style23">
                    <asp:TextBox ID="TextBox56" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" OnTextChanged="TextBox56_TextChanged" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td style="margin: 5px;" class="auto-style1"></td>
                <td style="margin: 5px;" class="auto-style1">&nbsp;</td>
                <td class="auto-style1">&nbsp;
                </td>
            </tr>

            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style49">ii).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style50">Building</td>
                <td style="margin: 5px;" class="auto-style51"></td>
                <td style="margin: 5px;" class="auto-style52">
                    <asp:TextBox ID="TextBox37" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox37_TextChanged"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style53">&nbsp;
                </td>

                <td style="margin: 5px;" class="auto-style39">
                    <asp:TextBox ID="TextBox57" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" OnTextChanged="TextBox57_TextChanged" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td style="margin: 5px;" class="auto-style54"></td>
                <td style="margin: 5px;" class="auto-style54"></td>
                <td class="auto-style54">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style43">iii).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style44">Plant and Machinery</td>
                <td style="margin: 5px;" class="auto-style45"></td>
                <td style="margin: 5px;" class="auto-style46">
                    <asp:TextBox ID="TextBox41" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox41_TextChanged"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style47">&nbsp;
                </td>
                <td style="margin: 5px;" class="auto-style41">
                    <asp:TextBox ID="TextBox58" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox58_TextChanged"></asp:TextBox>
                </td>
                <td style="margin: 5px;" class="auto-style42"></td>
                <td style="margin: 5px;" class="auto-style48"></td>
                <td style="margin: 5px;" class="auto-style48"></td>
                <td class="auto-style48">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style14">iv).</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style10">Technical Know-how feasibility study and turn Key Charges</td>
                <td style="margin: 5px;" class="auto-style18"></td>
                <td style="margin: 5px;" class="auto-style5">
                    <asp:TextBox ID="TextBox44" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox44_TextChanged"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style20">&nbsp;
                </td>
                <td style="margin: 5px;" class="auto-style24">
                    <asp:TextBox ID="TextBox45" Text="0" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox45_TextChanged"></asp:TextBox>
                </td>
                <td style="margin: 5px;" class="auto-style4">&nbsp;</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>

            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style14">&nbsp;</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style10">
                    <b>Total</b></td>
                <td style="margin: 5px;" class="auto-style18"></td>
                <td style="margin: 5px;" class="auto-style5">
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="false" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style20">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="auto-style24">
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="false" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td style="margin: 5px;" class="auto-style4">&nbsp;</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>

        </table>
        <table>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top">
                    <b>3.0.</b></td>
                <td colspan="4" style="padding: 5px; margin: 5px;">
                    <b>REMARKS</b></td>



                <td>&nbsp;</td>
                <td colspan="3" style="padding: 5px; margin: 5px;">&nbsp;</td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style73">3.1</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style26">Second Hand Machinery (Value in Rs.)</td>
                <td style="margin: 5px;" class="auto-style86">:</td>
                <td style="margin: 5px;" class="auto-style60">
                    <asp:TextBox ID="TextBox35" Text="0" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                </td>
                <td style="margin: 5px;" class="auto-style60">&nbsp;
                </td>
                <td style="margin: 5px; font-weight: bold;" valign="top" class="auto-style60"></td>
                <td style="margin: 5px;" class="auto-style3"></td>
                <td style="margin: 5px;" class="auto-style60"></td>
                <td style="margin: 5px;" class="auto-style60"></td>
                <td class="auto-style60">&nbsp;
                </td>
            </tr>

            <tr>
                <asp:HiddenField ID="HDNAMOUNT" runat="server" />
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style87">3.2</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style88">Social Status</td>
                <td style="margin: 5px;" class="auto-style48">:</td>
                <td style="margin: 5px;" class="auto-style48">
                    <asp:TextBox ID="TextBox39" Text="NA" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style48">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="auto-style87"></td>
                <td style="margin: 5px;" class="auto-style42"></td>
                <td style="margin: 5px;" class="auto-style48"></td>
                <td style="margin: 5px;" class="auto-style48"></td>
                <td class="auto-style48">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style83">3.3</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style90">Belated Claim(%Reduction)</td>
                <td style="margin: 5px;" class="auto-style62">:</td>
                <td style="margin: 5px;" class="auto-style62">
                    <asp:TextBox ID="TextBox43" Text="0" onkeypress="DecimalOnly()" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style62">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="auto-style83"></td>
                <td style="margin: 5px;" class="auto-style92"></td>
                <td style="margin: 5px;" class="auto-style62"></td>
                <td style="margin: 5px;" class="auto-style62"></td>
                <td class="auto-style62">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style87">3.4</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style88">Amt of Subsidy already availed/ availing in Rs.</td>
                <td style="margin: 5px;" class="auto-style48">:</td>
                <td style="margin: 5px;" class="auto-style48">
                    <asp:TextBox ID="TextBox46" runat="server" Text="0" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;" class="auto-style48">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="auto-style87"></td>
                <td style="margin: 5px;" class="auto-style42"></td>
                <td style="margin: 5px;" class="auto-style48"></td>
                <td style="margin: 5px;" class="auto-style48"></td>
                <td class="auto-style48">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">3.5</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style27">Conditions to be fulfilled</td>
                <td style="margin: 5px;">:</td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="TextBox48" runat="server" Text="NA" class="form-control txtbox" Height="80px" TabIndex="6" Width="150px" TextMode="MultiLine"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style4">
                    <br />
                </td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style27">Date upto Which unit shall be in<br />
                    Continous production and shall not change Management..</td>
                <td style="margin: 5px;">:
                </td>
                <td style="margin: 5px;">
                    <asp:TextBox ID="txtContProdMgm" Text="0" placeholder="Please enter date" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>


                </td>
                <td style="margin: 5px;">&nbsp;
                </td>
                <td style="margin: 5px;" valign="top" class="ui-priority-primary">&nbsp;</td>
                <td style="margin: 5px;" class="auto-style4">&nbsp;</td>
                <td style="margin: 5px;"></td>
                <td style="margin: 5px;">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>
        </table>

        <table style="width: 100%">
            <tr style="height: 30px">
                <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: middle;"></td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold; width: 20px">3.6
                </td>
                <td colspan="4" style="padding: 5px; margin: 5px;">
                    <b>EXPANSION/DIVERSIFICATION CASES</b></td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">a).&nbsp;</td>
                <td style="padding: 5px; margin: 5px;">Investment prior to E/D in Rs.</td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                    <asp:TextBox ID="txt25BldgCvl" Text="0" runat="server" class="form-control txtbox txtcomn"
                        Height="30px" MaxLength="80" TabIndex="26" Width="150px"
                        onkeypress="DecimalOnly()"></asp:TextBox>
                </td>
                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                    <strong>d).</strong></td>
                <td style="padding: 5px; margin: 5px;" class="auto-style29">Production Capacity
                    <br />
                    prior to E/D</td>
                <td style="padding: 5px; margin: 5px;">:</td>
                <td style="padding: 5px; margin: 5px;">&nbsp; 
                            <asp:TextBox ID="txtPlintharea424" Text="0" onkeypress="DecimalOnly()" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="28" Width="150px"></asp:TextBox>
                </td>
                <td style="padding: 5px; margin: 5px;">&nbsp;
                </td>
            </tr>
            <tr id="tr4221" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">b).</td>
                <td style="padding: 5px; margin: 5px; width: 220px">Investment under to E/D in Rs.
                </td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <%-- <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt822guideline422" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="27"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                    <asp:TextBox ID="txt822guideline422" Text="0" runat="server" onkeypress="DecimalOnly()" class="form-control txtbox txtcomn"
                        Height="30px" MaxLength="80" TabIndex="27" Width="150px"></asp:TextBox>
                </td>
                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                    <strong>&nbsp;e)</strong>.</td>
                <td style="padding: 5px; margin: 5px;" class="auto-style29">Additional Capacity proposed under E/D</td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <%--<td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txtPlintharea422" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="28" onkeypress="return inputOnlyNumbers(event)"  Width="150px"></asp:TextBox>
                    </td>--%>
                <td style="padding: 5px; margin: 5px;">
                    <asp:TextBox ID="txtPlintharea422" Text="0" onkeypress="DecimalOnly()" runat="server" class="form-control txtbox txtcomn"
                        Height="30px" MaxLength="80" TabIndex="28" Width="150px"></asp:TextBox>
                </td>
                <td style="padding: 5px; margin: 5px;">&nbsp;
                </td>
            </tr>
            <tr id="tr4222" runat="server" visible="true">
                <td style="padding: 5px; margin: 5px; font-weight: bold;">c).</td>
                <td style="padding: 5px; margin: 5px;">% Increase in Investment under
                    <br />
                    E/D</td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                    <asp:TextBox ID="txtTSSFCnorms422" Text="0" runat="server" class="form-control txtbox txtcomn"
                        Height="30px" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="29"
                        Width="150px" OnTextChanged="txtTSSFCnorms422_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                    <strong>&nbsp;f).</strong></td>
                <td style="padding: 5px; margin: 5px;" class="auto-style29">% Increase in Capacity under E/D</td>
                <td style="padding: 5px; margin: 5px;">:
                </td>
                <td style="padding: 5px; margin: 5px;">
                    <asp:TextBox ID="txtvalue422" Text="0" onkeypress="DecimalOnly()" runat="server"
                        class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="30"
                        Width="150px"></asp:TextBox>
                </td>
                <td style="padding: 5px; margin: 5px;">&nbsp;
                </td>
            </tr>

            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold;">&nbsp;</td>
                <td colspan="9" style="padding: 5px; margin: 5px; font-weight: bold;">
                    <br />
                </td>
            </tr>


        </table>
        <table style="width: 100%">
            <tr style="height: 30px">
                <td colspan="9" style="height: 20px"></td>
            </tr>
            <tr>
                <td style="padding: 5px; margin: 5px; font-weight: bold; width: 10px">
                </td>
                <td colspan="4" style="padding: 5px; margin: 5px;">
                    <b>Reimbursement of Wood</b></td>

            </tr>
             
            
            
            
            
                <tr>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style48"> &nbsp;&nbsp;Wood Quantity</td>
                    <td class="auto-style48">&nbsp;</td>
                    <td class="auto-style48">

                        <asp:TextBox ID="TXTWOODQUANTITY" runat="server" class="form-control txtbox txtcomn"
                            Height="30px" MaxLength="80"  TabIndex="34" Width="150px" AutoPostBack="true" OnTextChanged="TXTWOODQUANTITY_TextChanged"></asp:TextBox>

                    </td>
                </tr>

                

                
                

            <tr>
                    <td class="auto-style55"></td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">ELIGIBLE AMOUNT</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td class="auto-style55">
                        <asp:TextBox ID="TXTELIGIBLEAMOUNT"  runat="server" class="form-control txtbox txtcomn"
                            Height="30px" onkeypress="return inputOnlyNumbers(event)" Enabled="false" MaxLength="80" TabIndex="36"
                            Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                </tr>
            
            <tr>
                    <td class="auto-style55"></td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">GM Recommended Amount</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td class="auto-style55">
                        <asp:TextBox ID="txtgmRecommend"  runat="server" class="form-control txtbox txtcomn"
                            Height="30px" onkeypress="return inputOnlyNumbers(event)" Enabled="false" MaxLength="80" TabIndex="36"
                            Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                </tr>
                
            <tr>
                    <td class="auto-style55"></td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55"> FINAL SUBSIDY AMOUNT</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td class="auto-style55">
                        <asp:TextBox ID="TXTFINALSUBSIDYAMOUNT"  runat="server" class="form-control txtbox txtcomn"
                            Height="30px" onkeypress="return inputOnlyNumbers(event)" Enabled="false" MaxLength="80" TabIndex="36"
                            Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;</td>
                </tr>
            <tr runat="server" visible="false">
                    <td>4.3</td>
                    <td style="padding: 5px; margin: 5px;">TOTAL SUBSIDY(4.1 + 4.2)</td>
                    <td style="padding: 5px; margin: 5px;">:</td>
                    <td>&nbsp;
                            <asp:TextBox ID="txtvalue424" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" onkeypress="return inputOnlyNumbers(event)" Enabled="false" TabIndex="37" Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;
                    </td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;
                    </td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;
                    </td>
                </tr>
                <tr id="tradremarks" runat="server" visible="true">
                    <td></td>
                    <td style="padding: 5px; margin: 5px;">Remarks</td>
                    <td style="padding: 5px; margin: 5px;">:</td>
                    <td>&nbsp;
                            <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" class="form-control txtbox txtcomn" Height="30px" TabIndex="37" Width="150px"></asp:TextBox>
                    </td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;
                    </td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;
                    </td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                    <td style="padding: 5px; margin: 5px;">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">WorkSheet
                    </td>
                    <td class="style21" style="padding: 5px; margin: 5px">:
                    </td>
                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="CS" Height="28px" />
                        <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"
                            Visible="false" Target="_blank"></asp:HyperLink>
                        <br />
                        <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                        <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                            TabIndex="10" Text="Upload" Width="72px" OnClick="BtnSave3_Click" />
                    </td>
                    <td></td>
                </tr>
            

            <tr>
                <td colspan="11">
                    <br />
                </td>
            </tr>
            </table>
        <table>
            <tr>
                <td>
                         <table>

                 <tr>
                                            <td  style="height: 8px"><b>Please enter the following details</b></td>
                                        </tr>
                                        <tr>
                                            <td   colspan="11" >
                                                <table>
                                                    <tr>
                                                         <td class="auto-style3">Caste</td>
                                            <td>
                                                <asp:RadioButtonList id="rdbCaste" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbCaste_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem>General</asp:ListItem>
                                                    <asp:ListItem>SC</asp:ListItem>
                                                    <asp:ListItem>ST</asp:ListItem>
                                                    <asp:ListItem>PHC</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style3">Gender</td>
                                                <td>
                                                <asp:RadioButtonList id="rdbGender" AutoPostBack="True" enabled="false" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbGender_SelectedIndexChanged">
                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>
                                                    
                                                </asp:RadioButtonList></td>
                                                    </tr>
                                                     <tr>
                                                         <td class="auto-style3">Category</td>
                                            <td>
                                                <asp:RadioButtonList id="rdbCategory" AutoPostBack="True" enabled="false" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbCategory_SelectedIndexChanged">
                                                    <asp:ListItem>Micro</asp:ListItem>
                                                    <asp:ListItem>Small</asp:ListItem>
                                                    <asp:ListItem>Medium</asp:ListItem>
                                                    <asp:ListItem>Large</asp:ListItem>
                                                    <asp:ListItem>Mega</asp:ListItem>
                                                    
                                                </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                         <td class="auto-style3">Enterprise Type</td>
                                            <td>
                                                <asp:RadioButtonList id="rdbEnterprise" AutoPostBack="True" enabled="false"  runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbEnterprise_SelectedIndexChanged">
                                                    <asp:ListItem>New</asp:ListItem>
                                                    <asp:ListItem>Expansion</asp:ListItem>
                                                    
                                                </asp:RadioButtonList></td>
                                                    </tr>
                                                       <tr>
                                                         <td class="auto-style3">Sector</td>
                                            <td>
                                                <asp:RadioButtonList id="rdbSector" AutoPostBack="True"  enabled="false"  runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbSector_SelectedIndexChanged">

                                                    <asp:ListItem>Service</asp:ListItem>
                                                    <asp:ListItem>Manufacture</asp:ListItem>
                                                    
                                                </asp:RadioButtonList></td>
                                                    </tr>
                                                     <tr id="trServiceType" runat="server" visible="false">
                                                         <td>

                                                             Service Type</td>
                                                      <td>

                                                          <asp:RadioButtonList ID="rdbServiceType" runat="server" AutoPostBack="True"   RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbServiceType_SelectedIndexChanged">
                                                              <asp:ListItem Value="STT">Transport</asp:ListItem>
                                                              <asp:ListItem Value="STNT">Non - Transport(Fixed services like Hospitals,Halls,Poutlry Farms etc)</asp:ListItem> 
                                                          </asp:RadioButtonList>

                                                      </td>
                                                     </tr>
                                                    <tr id="trTransNonTrans" runat="server" visible="false">
                                                         <td  class="auto-style3">
                                                             Transport/Non-Transport Type
                                                         </td>
                                                      <td  class="auto-style3">

                                                          <asp:RadioButtonList ID="rdbTransportNonTrans" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbTransportNonTrans_SelectedIndexChanged">
                                                              <asp:ListItem Value="TP">Passenger</asp:ListItem>
                                                              <asp:ListItem Value="TG">Goods/Tractor etc</asp:ListItem>
                                                              <asp:ListItem Value="TE">Earth Movers/Borewells/JCB etc</asp:ListItem>
                                                          </asp:RadioButtonList>

                                                      </td>
                                                     </tr>
                                                </table>
                                            </td>
                                           
                                        </tr>
        </table>
                </td>
            </tr>
            <tr id="trsubmit" runat="server" visible="false">
                <td colspan="3" align="center">

                    <asp:Button ID="Button3" CssClass="btn btn-xs btn-warning" runat="server" Text="Submit" Height="30px" OnClick="Button3_Click" />
                    &nbsp; &nbsp;<asp:Button ID="btnback" runat="server"
                        CssClass="btn btn-danger" Height="32px" OnClick="btnback_Click" TabIndex="10"
                        Text="previous" Width="90px" />

                    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-danger" Height="30px" OnClick="Button1_Click" Text="Cancel" />

                </td>
                <td width="1%" align="center">

                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="9">
                    <table style="width: 100%">
                        <tr>
                            <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="lblAllwomen" runat="server" />
                    <%--<asp:Label ID="lblAllwomen" runat="server" Visible="true" Text="Industry Status"></asp:Label>--%>
                </td>
                <td>
                    <asp:HiddenField ID="hdfID" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="child" />
                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                    &nbsp;<asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="group1" />
                    <asp:HiddenField ID="hdfincentiveid" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="group1" />
                </td>
            </tr>
        </table>
    </div>

    </ContentTemplate>
    <triggers> <asp:AsyncPostBackTrigger  ControlID="TextBox56"  /> 
<asp:AsyncPostBackTrigger  ControlID="TextBox57"/>
<asp:AsyncPostBackTrigger  ControlID="TextBox58"/>
<asp:AsyncPostBackTrigger  ControlID="TextBox45"/>
<asp:AsyncPostBackTrigger  ControlID="TextBox33"/>
<asp:AsyncPostBackTrigger  ControlID="TextBox37"/> 
            <asp:AsyncPostBackTrigger  ControlID="TextBox41"/> 
            <asp:AsyncPostBackTrigger  ControlID="TextBox44"/> 
            <%--<asp:AsyncPostBackTrigger  ControlID="TextBox59"/> --%>
            <%--<asp:AsyncPostBackTrigger  ControlID="txtTSSFCnorms423"/> --%>

        </triggers>


    </asp:UpdatePanel>
    <link href="../../Masterfiles/css/StyleSheetMaster.css" rel="stylesheet" />
    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtCalenderDCP']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback
            //txtquery_dic
            //
            $("input[id$='txtContProdMgm']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });

            $("input[id$='TextBox3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });
            $("input[id$='txtquery_dic']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });
            //txtquery_coi
            $("input[id$='txtquery_coi']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                });
            $("input[id$='txtDateOfapplnFile']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            //txtPowerConn_date  txtrc_dic
            $("input[id$='txtrc_dic']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            //txtcompdate_dic
            $("input[id$='txtcompdate_dic']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            //txtcompdate_coi
            $("input[id$='txtcompdate_coi']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            //txtcompdate_coi1
            $("input[id$='txtcompdate_coi1']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            $("input[id$='txtPowerConn_date']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                });
            $("input[id$='txtDate_Loan']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtDCP_unit']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtApplClm']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtDateShrtfall']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtDtShrtFallRcvd']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                }); // Will run at every postback/AsyncPostback

        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtCalenderDCP']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtApplClm']").datepicker(
                {
                    dateFormat: "dd-mm-yy",

                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtDateOfapplnFile']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtDtShrtFallRcvd']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='TextBox3']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='TextBox4']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='txtcompdate_coi']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            console.log($(".txtcomn").length);
            var option_all = '';

            $("input[id$='chkMobileUnit']").change(function () {
                if (this.checked) {

                    option_all = $(".txtcomn").map(function () {
                        if ($.trim($(this).val()) == '') {
                            return "#" + $(this).attr('Id');
                        }
                    }).get().join(',');

                    console.log(option_all);

                    if (option_all) {
                        $(option_all).val('0')
                    }

                }
                else {
                    $(option_all).val('')
                }
            });





        });
    </script>
</asp:Content>


