<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="frmCFOMergeDuplicate.aspx.cs" Inherits="UI_TSiPASS_frmCFOMergeDuplicate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function GetRowValue(val) {
            if (val != '&nbsp;') {
                val1 = 0;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfID').value = val;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdfFlagID').value = val1;

            }
            window.opener.document.forms[0].submit();
            self.close();

        }
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
    <style type="text/css" media="print">
        @page {
            size: landscape;
        }
    </style>
    <style type="text/css">
        blink, .blink {
            animation: blinker 1s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
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
    </style>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>
            <asp:Panel ID="Panel_1" runat="server">

                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                            valign="top" align="center">



                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="15px"></asp:Label><%--<a id="A2" href="#" onserverclick="BtnSave2_Click1" runat="server">
                    <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                        alt="Excel" /></a>--%>
                                        <asp:ImageButton ImageUrl="~/Resource/Images/Excel-icon.png" ID="excel_button" OnClick="BtnSave2_Click1" Width="20px" Height="20px" Style="float: right;" runat="server" />
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                    ForeColor="#006600"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/DistrictWiseUpdateabstarct.aspx" Text="<< Back"> </asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="center" style="text-align: right" valign="middle">
                                                            <div class="input-group">
                                                                <div class="input-group-addon">
                                                                    From Date
                                                                </div>

                                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <%--<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                                                        </cc1:CalendarExtender>--%>
                                                            </div>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <div class="input-group">
                                                                <div class="input-group-addon">
                                                                    To Date
                                                                </div>
                                                                <asp:TextBox ID="txtTodate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>
                                                                <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate">
                                                        </cc1:CalendarExtender>--%>
                                                            </div>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="text-align: right" valign="middle">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="text-align: right" valign="middle">
                                                            <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">District</asp:Label>
                                                        </td>
                                                        <td>: </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlConnectLoad" runat="server" class="form-control txtbox" Height="33px" TabIndex="1" Width="180px">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>&nbsp;&nbsp;Type of Enterprise &nbsp; </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp; </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlEnterPriseType" runat="server" class="form-control txtbox" Width="180px">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                <%-- <asp:ListItem>All</asp:ListItem>--%>
                                                                <asp:ListItem Value="Micro">Micro</asp:ListItem>
                                                                <asp:ListItem Value="Small">Small</asp:ListItem>
                                                                <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                                <asp:ListItem Value="Large">Large</asp:ListItem>
                                                                <asp:ListItem Value="Mega">Mega</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>&nbsp; </td>
                                                    </tr>
                                                    <tr id="trunitname" runat="server" visible="false">
                                                        <td align="center" style="text-align: right" valign="middle">
                                                            <asp:Label ID="Label452" runat="server" CssClass="LBLBLACK" Width="200px">Unit name</asp:Label>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <asp:TextBox ID="txtUnitname" runat="server" class="form-control txtbox" Height="28px" MaxLength="80" TabIndex="2" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8" align="center">
                                                            <asp:Label ID="lblMsg0" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                                ForeColor="#006600"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" Height="32px"
                                                    OnClick="BtnSave1_Click" TabIndex="10" Text="Search" ValidationGroup="group"
                                                    Width="90px" />
                                                &nbsp;
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                        Height="32px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="90px"
                                        OnClick="BtnClear_Click" />



                                            </td>
                                        </tr>
                                        <tr id="trdup" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                                <b>Note :1) DIC has to upload Undertaking form from the unit holder, describe that they
                                        have dropped the project</b>
                                                <br />
                                                <div align="right">
                                                    <blink><b style="color: red;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2) The Uploaded file size should be less than 2MB</b></blink>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px" id="Panel1" runat="server">
                                                <%--<asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Style="width: 1000px" Height="600px">--%>
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    ForeColor="#333333" Height="62px" OnRowDataBound="grdDetails_RowDataBound"
                                                    Width="100%" OnPageIndexChanging="grdDetails_PageIndexChanging"
                                                    ShowFooter="True" OnRowCreated="grdDetails_RowCreated">
                                                    <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                 
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit Name">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLink2" Target="_blank" runat="server" NavigateUrl='<%# Eval("intQuessionaireCFOid", "ApplicationTrakerDetailedCFO.aspx?ID={0}") %>'
                                                                    Text='<%# Eval("NameofIndustrialUnder") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%-- <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />--%>
                                                        <asp:TemplateField HeaderText="UID No">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" NavigateUrl='<%# Eval("intCFEEnterpidnew", "ViewCFOPrint.aspx?Id={0}") %>'
                                                                    Text='<%# Eval("UID_No") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:BoundField DataField="UID_No" HeaderText="UID No" />--%>
                                                        <asp:BoundField DataField="Mno" HeaderText="Mobile Number" />
                                                        <asp:BoundField DataField="LineofActivity_Name" HeaderText="line of Activity" />
                                                        <asp:BoundField DataField="District_Name" HeaderText="District" />
                                                        <asp:BoundField DataField="Manda_lName" HeaderText="Mandal" />
                                                        <asp:BoundField DataField="Investment" HeaderText="Investment(Rs. in Crs)" />
                                                        <asp:BoundField DataField="NoofEmployee" HeaderText="No of Employee" />
                                                        <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="Progress" HeaderText="Progress"  Visible="false"/>
                                                        <asp:TemplateField HeaderText="Duplicate Status">
                                                            <ItemTemplate>
                                                                <table style="width: 100%" cellpadding="4" cellspacing="5">
                                                                    <tr>
                                                                        <td style="width: 132px; height: 29px">
                                                                            <asp:DropDownList ID="ddlStatus" runat="server" Width="220px" CssClass="DROPDOWN"
                                                                                AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="NO">Original</asp:ListItem>
                                                                                <asp:ListItem Value="YES">Duplicate</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trdupuidno" runat="server" visible="false"> 
                                                                        <td style="width: 132px; height: 29px">
                                                                            <b>UID NO :</b>
                                                                            <asp:TextBox ID="txtdupuidno" Height="30px" Width="150px"
                                                                                runat="server" OnTextChanged="txtdupuidno_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trremarks" runat="server" visible="false">
                                                                        <td style="width: 132px; height: 29px">
                                                                            <b>Remarks :</b>
                                                                            <asp:TextBox ID="txtreasonschange" TextMode="MultiLine" Height="80px" Width="250px"
                                                                                runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Button ID="BtnSaveg" runat="server" CssClass="btn btn-primary" Height="30px" TabIndex="10"
                                                                                Text="Submit" ValidationGroup="group" Width="80px" OnClick="BtnSaveg_Click" />
                                                                            <asp:HiddenField ID="HdfintApplicationid" runat="server" />
                                                                            <asp:HiddenField ID="hduidno" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>
                                                <%--</asp:Panel>--%>
                                                <asp:Label ID="lblresult" runat="server" CssClass="LBLBLACK" Width="200px"></asp:Label>
                                            </td>
                                        </tr>
                                        <%--<tr id="divExport" visible="false" runat="server">
                                <td align="center" style="text-align: center;" valign="top">
                                    <asp:GridView ID="grdExport1" runat="server" AutoGenerateColumns="true" ShowFooter="true">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle Wrap="true" />
                                    </asp:GridView>
                                </td>
                            </tr>--%>
                                        <tr id="Tr1" runat="server" visible="false">
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Style="width: 1000px" Height="600px">
                                                    <asp:GridView ID="GridExport" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                                            <asp:BoundField DataField="UID_No" HeaderText="UID No" />
                                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                                            <asp:BoundField DataField="lineofActivity" HeaderText="line of Activity" />
                                                            <asp:BoundField DataField="District" HeaderText="District" />
                                                            <asp:BoundField DataField="Manda_lName" HeaderText="Mandal" />
                                                            <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No" />
                                                            <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                                            <asp:BoundField DataField="Investment" HeaderText="Investment(Rs. in Crs)" />
                                                            <asp:BoundField DataField="NoofEmployee" HeaderText="No of Employee" />
                                                            <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="Progress" HeaderText="Progress" />
                                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/DistrictWiseUpdateabstarct.aspx" Text="<< Back"> </asp:HyperLink>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="excel_button" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

