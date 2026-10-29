<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="CommencedUnitsStatus.aspx.cs" Inherits="UI_TSiPASS_CommencedUnitsStatus" %>

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
    <script type="text/javascript" language="javascript">

        function OpenPopup() {
            window.open("UpdateCommencedUnitsStatus.aspx", "List", "scrollbars=yes,resizable=yes,width=1500,height=950;display = block;position=absolute");
            return false;
        }
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
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="15px"></asp:Label>
                                        <asp:ImageButton ImageUrl="~/Resource/Images/Excel-icon.png" ID="excel_button" OnClick="excel_button_Click" Width="20px" Height="20px" Style="float: right;" runat="server" />
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                                    ForeColor="#006600"> Commenced Operations Units</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/HomeDeptDashboard.aspx" Text="<< Back"> </asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding: 5px; margin: 5px">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="center" style="text-align: right" valign="middle">
                                                            <asp:Label ID="Label450" runat="server" CssClass="LBLBLACK" Width="200px">District</asp:Label>
                                                        </td>
                                                        <td>:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDistricts" runat="server" class="form-control txtbox"
                                                                Height="33px" Width="180px" TabIndex="1">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>&nbsp;&nbsp; &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label451" runat="server" CssClass="LBLBLACK" Width="200px">Unit name</asp:Label>
                                                        </td>
                                                        <td>&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtUnitname" runat="server" class="form-control txtbox" Height="28px"
                                                                MaxLength="80" TabIndex="2" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;
                                                        </td>
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
                                            <td align="center" style="padding: 5px; margin: 5px" id="Panel1" runat="server">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    ForeColor="#333333" Height="62px" Width="100%" ShowFooter="True" OnRowDataBound="grdDetails_RowDataBound">
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
                                                                <asp:HyperLink ID="hplUnitName" Target="_blank" runat="server" NavigateUrl='<%# Eval("intQuessionaireid", "ApplicationTrakerDetailed.aspx?ID={0}") %>'
                                                                    Text='<%# Eval("UnitName") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="UID No">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hplUIDNo" Target="_blank" runat="server" NavigateUrl='<%# Eval("intCFEEnterpidnew", "ViewCFEPrint.aspx?Id={0}") %>'
                                                                    Text='<%# Eval("UID_No") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Mno" HeaderText="Mobile Number" />
                                                        <asp:BoundField DataField="lineofActivity" HeaderText="line of Activity" />
                                                        <asp:BoundField DataField="District" HeaderText="District" />
                                                        <asp:BoundField DataField="Manda_lName" HeaderText="Mandal" />
                                                        <asp:BoundField DataField="Investment" HeaderText="Investment(Rs. in Crs)" />
                                                        <asp:BoundField DataField="NoofEmployee" HeaderText="No of Employee" />
                                                        <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="ApprovalDate" HeaderText="Approval Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="Progress" HeaderText="Progress" />
                                                        <asp:BoundField DataField="LastUpdateddate" ItemStyle-Font-Bold="true" HeaderText="Last Updated Date" />

                                                        <asp:TemplateField HeaderText="Update The Status">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Height="30px" TabIndex="10"
                                                                    Text="Update Status" ValidationGroup="group" Width="150px" OnClick="btnUpdate_Click" />
                                                                <asp:HiddenField ID="HdfintApplicationid" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:Label ID="lblresult" runat="server" CssClass="LBLBLACK" Width="200px"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="text-align: left">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" NavigateUrl="~/UI/TSiPASS/HomeDeptDashboard.aspx" Text="<< Back"> </asp:HyperLink>
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


