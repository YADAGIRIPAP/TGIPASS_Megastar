<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="frmCalenderReportCOI.aspx.cs" Inherits="UI_TSiPASS_frmCalenderReportCOI" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cntSelectslot">
    <script language="JavaScript" type="text/javascript" src="../JS/CFSTCommon.js"></script>
    <script type="text/javascript" language="javascript">
        function PrintDiv(divID) {
            var printContent = document.getElementById(divID);
            var windowUrl = 'about:blank';
            var windowName = 'PrintWindow';
            var printWindow = window.open(windowUrl, windowName,
                  'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
        $(function () {

            $('#MstLftMenu').remove();

        });
    </script>
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
        .update
        {
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
        .style7
        {
            width: 42px;
        }
        .style8
        {
            height: 30px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <%--<asp:ScriptManager ID="scmOnlineSlot" runat="server">
    </asp:ScriptManager>--%>
    <asp:UpdatePanel ID="updPanel" runat="server">
        <ContentTemplate>
            <table cellspacing="2" cellpadding="1" width="100%" border="0">
                <tbody>
                    <tr>
                        <td valign="top">
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/HomeCommDashboard.aspx"
                                Text="<< Back">
                            </asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <!--Body Content Starts-->
                            <table border="0" cellpadding="1" cellspacing="2" width="100%">
                                <!--Application Fiels Starts-->
                                <tbody>
                                    <tr align="center">
                                        <td align="center" style="font-weight: bold; height: 16px" id="finid" runat="server"
                                            visible="false">
                                            &nbsp;Financial Year :
                                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control txtbox" Height="33px"
                                                Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlProp_Financial_SelectedIndexChanged">
                                                <%-- <asp:ListItem>--District--</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="center" style="font-weight: bold; height: 16px">
                                            &nbsp;District :
                                            <asp:DropDownList ID="ddlProp_intDistrictid" runat="server" class="form-control txtbox"
                                                Height="33px" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlProp_intDistrictid_SelectedIndexChanged">
                                                <%-- <asp:ListItem>--District--</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" Text="Submit" ID="Submit" OnClick="CtrlBtnSubmt_Click"
                                                CssClass="btn" ToolTip="Submit Record" Visible="false"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="height: 16px">
                                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            <br />
                                            <asp:Panel ID="calendarPanel" runat="server">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Table ID="tblHeading" runat="server">
                                                                </asp:Table>
                                                                <div id="divID" runat="server">
                                                                    <asp:Table ID="tbCalendar" runat="server">
                                                                    </asp:Table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 31px" valign="middle">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 14px" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="1" valign="middle">
                                                                <asp:Label ID="lblNote" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                            <td valign="middle">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <!--Application Fiels End-->
                    <tr>
                        <td style="height: 16px" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
            <table>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="10">
                    <Columns>
                        <asp:BoundField ItemStyle-Width="150px" DataField="Month" HeaderText="Monthname" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Count" HeaderText="Count" />
                    </Columns>
                </asp:GridView>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" align="center" value="Print" name="remhnf" onclick="window.print()" />
            <%--<asp:Button ID="Button1" Text="print" runat="server" onClick="window.print()"/>--%>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updPanel">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
