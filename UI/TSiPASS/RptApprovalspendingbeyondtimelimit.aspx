<%@ Page Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="RptApprovalspendingbeyondtimelimit.aspx.cs"
    Inherits="LookupCA" Title=":: TSiPASS Online Management System ::" %>

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
    
    </script>

    <script type="text/javascript" language="javascript">
        var win = new Object();
        function Popup(intval) {

            win = window.open("CFEPopup.aspx?UID=" + intval, "List", "scrollbars=yes,resizable=yes,width=780,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");
            //win = window.open("RptVillageOraganisationNameClickDetails.aspx?id="+intval, "List", "scrollbars=yes,resizable=yes,width=600,height=400,left=" + ((window.screen.width / 2) - 320) + ",top=" + ((window.screen.height / 2) - 200) + ";display : block;position:absolute");

        }
    </script>

    <%--<script type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../../js/gridviewScroll.min.js"></script>--%>

    <script type="text/javascript">

//        function pageLoad() {
//            $('#<%=grdDetails.ClientID%>').gridviewScroll({
//                width: 1090,
//                height: "100%",
//                arrowsize: 30,
//                varrowtopimg: "../../images/arrowvt.png",
//                varrowbottomimg: "../../images/arrowvb.png",
//                harrowleftimg: "../../images/arrowhl.png",
//                harrowrightimg: "../../images/arrowhr.png"
//            });
//        } 
           
    </script>
    <style>
    .algnRight
        {
            text-align: center;
            padding-right: 5px;
        }
    </style>

    <table runat="server" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="padding-top: 10px; padding-bottom: 20px; padding-left: 9px; height: 675px;"
                valign="top" align="center">
                <div class="panel panel-default">
                    <div class="panel-heading" style="text-align: center">
                        <h3 class="panel-title" style="font-weight: bold;">
                            R4.1: Approvals Pending Beyond Time Limit Report - Detailed list<a id="A1" href="#" onserverclick="Button2_Click"
                                runat="server">
                                <img src="../../Resource/Images/pdf-icon.png" width="20px;" height="20px;" style="float: right;"
                                    alt="PDF" /></a> <a id="A2" href="#" onserverclick="BtnSave2_Click" runat="server">
                                        <img src="../../Resource/Images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                            alt="Excel" /></a></h3>
                    </div>
                    <div class="panel-body">
                        <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                            <tr id="trFilter" runat="server">
                                <td style="padding: 5px; margin: 5px" valign="top">
                                    <table cellpadding="4" cellspacing="5">
                                        <tr>
                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:HyperLink CssClass="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/UI/TSiPASS/ReportsDashboard.aspx" Text="<< Back">
                                                </asp:HyperLink>
                                            </td>
                                            <td class="col-xs-3" style="padding: 5px; margin: 5px">
                                                <div class="input-group">
                                                    <div class="input-group-addon">
                                                        Department</div>
                                                    <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox" Height="33px"
                                                        Width="180px">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="padding: 5px; margin: 5px" align="right">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-default" TabIndex="10"
                                                    Text="Submit" OnClick="BtnSave_Click" />
                                            &nbsp;</td>
                                            <td class="col-xs-5" style="padding: 5px; text-align: right; margin: 5px">
                                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">Report as on date</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="2" align="center" style="padding: 5px; margin: 5px">
                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                        ForeColor="#006600"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr id="divPrint" runat="server">
                                <td align="center" style="padding: 5px; height: 100%; margin: 5px">
                                    <asp:GridView ID="grdDetails" CssClass="floatingTable" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        OnPageIndexChanging="grdDetails_PageIndexChanging" OnRowDataBound="grdDetails_RowDataBound"
                                        Width="100%" BorderColor="Black" ShowFooter="True">
                                        <HeaderStyle Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UID Number">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Name of The Unit" DataField="Name" />
                                            <asp:BoundField HeaderText="Line of Activity" DataField="Line of Activity" />
                                            <asp:BoundField HeaderText="Type of Approval" DataField="Type of Approval" />
                                            <%-- <asp:BoundField HeaderText="Address of The Unit" DataField="PropAddress" />--%>
                                            <asp:BoundField HeaderText="Investment (Rs. in Cr)" DataField="Investment">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Date of Application" DataField="Date of Application" />
                                            <asp:BoundField HeaderText="Date of Payment" DataField="Date of Payment" />
                                            <asp:BoundField HeaderText="Date of Pre-scruitiny" DataField="Date of Pre-scruitiny" />
                                            <asp:BoundField HeaderText="Time Period as per TS-iPASS" DataField="Time Period as per TS-iPASS">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Due Date for giving approval" DataField="Due Date for giving approval" />
                                            <asp:BoundField HeaderText="Delay(Number of days)" DataField="Delay(Number of days">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                             <tr id="divExport" runat="server">
                                <td align="center" style="padding: 5px; height: 100%; margin: 5px">
                                    <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="False">
                                        
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="UID Number" DataField="UID Number"/>
                                                
                                            <asp:BoundField HeaderText="Name of The Unit" DataField="Name" />
                                            <asp:BoundField HeaderText="Line of Activity" DataField="Line of Activity" />
                                            <asp:BoundField HeaderText="Type of Approval" DataField="Type of Approval" />
                                            <%-- <asp:BoundField HeaderText="Address of The Unit" DataField="PropAddress" />--%>
                                            <asp:BoundField HeaderText="Investment (Rs. in Cr)" DataField="Investment">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Date of Application" DataField="Date of Application" />
                                            <asp:BoundField HeaderText="Date of Payment" DataField="Date of Payment" />
                                            <asp:BoundField HeaderText="Date of Pre-scruitiny" DataField="Date of Pre-scruitiny" />
                                            <asp:BoundField HeaderText="Time Period as per TS-iPASS" DataField="Time Period as per TS-iPASS">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Due Date for giving approval" DataField="Due Date for giving approval" />
                                            <asp:BoundField HeaderText="Delay(Number of days)" DataField="Delay(Number of days">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
