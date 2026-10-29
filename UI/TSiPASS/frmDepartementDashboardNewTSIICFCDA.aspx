<%@ page title="" language="C#" masterpagefile="~/UI/TSiPASS/CCMaster.master" autoeventwireup="true" codefile="frmDepartementDashboardNewTSIICFCDA.aspx.cs" inherits="UI_TSiPASS_frmDepartementDashboardNewTSIICFCDA" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">




</script>
    <asp:updatepanel id="updatepanel1" runat="server">
        <contenttemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Department Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:hyperlink id="HyperLink1" runat="server" font-size="Small" navigateurl="~/UI/TSiPASS/HomeDeptDashboard.aspx">Back</asp:hyperlink>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                <b>Consent for Establishment</b>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">&nbsp;
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a href="#" class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny
                                                                        Stage </b></a><a href="frmCFEDepartmentsViewAppl.aspx?Stg=1&lbl=Pre-Scrutiny Applications Received"
                                                                            class="list-group-item"><span class="badge">
                                                                                <asp:label id="Label4" runat="server"></asp:label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>No of Application Received </a><a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny-Completed</b> </a><a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=2&lbl=Pre-Scrutiny Applications Within 3 Days">
                                                                                <span class="badge" style="background-color: #87D37C;">
                                                                                    <asp:label id="Label12" runat="server"></asp:label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</a> <a class="list-group-item"
                                                                                    href="frmCFEDepartmentsViewAppl.aspx?Stg=3&lbl=Pre-Scrutiny Applications Beyond 3 Days">
                                                                                    <span class="badge" style="background-color: #d9534f;">
                                                                                        <asp:label id="Label18" runat="server"></asp:label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a>
                                                                    <a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=4&lbl=Pre-Scrutiny Total Applications">
                                                                        <span class="badge">
                                                                            <asp:label id="Label3" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total </a><a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=20">
                                                                            <span class="badge">
                                                                                <asp:label id="lblrejectedatprescrutiny" runat="server"></asp:label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>No of Applications Rejected </a>
                                                                    <a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=12&lbl=Applications Awaiting Payment">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:label id="Label11" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>No of Approvals Awaiting Payment
                                                                    </a><a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Pre-Scrutiny-Pending</b>
                                                                    </a><a class="list-group-item" href="frmCFEDepartmentsViewApplTSIICFCDA.aspx?Stg=5&Pre-Scrutiny-Pending Within 3 Days">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:label id="Label21" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</a> <a class="list-group-item"
                                                                            href="frmCFEDepartmentsViewApplTSIICFCDA.aspx?Stg=6&Pre-Scrutiny-Pending Beyond 3 Days"><span
                                                                                class="badge" style="background-color: #d9534f;">
                                                                                <asp:label id="Label22" runat="server"></asp:label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </a>
                                                                    <a class="list-group-item"
                                                                        href="frmCFEDepartmentsViewAppl.aspx?Stg=21&Pre-Scrutiny-Pending Beyond 3 Days Tomorrow"><span
                                                                            class="badge" style="background-color: #d9534f;">
                                                                            <asp:label id="lblprelastday" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Today Last Day </a>
                                                                    <a class="list-group-item"
                                                                        href="frmCFEDepartmentsViewAppl.aspx?Stg=7&lbl=Pre-Scrutiny-Pending Total Applications">
                                                                        <span class="badge">
                                                                            <asp:label id="Label6" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total </a><a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=8&lbl=Applications Awaiting Query Response">
                                                                            <span class="badge" style="background-color: #87D37C;">
                                                                                <asp:label id="Label8" runat="server"></asp:label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>No of Applications Awaiting Query Response</a>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div class="list-group">
                                                                    <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Stages</b></a>
                                                                    <a class="list-group-item" href="#"><b><i class="fa fa-fw fa-check"></i>Approval Under
            Process</b></a> <a class="list-group-item" href="frmCFEDepartmentsApprovalProcess.aspx?stg=1&lbl=Approval Under Process Within Time Limits">
                <span class="badge" style="background-color: #87D37C;">
                    <asp:label id="Label1" runat="server"></asp:label>
                </span><i class="fa fa-fw fa-calendar"></i>Within Time Limits </a><a class="list-group-item"
                    href="frmCFEDepartmentsApprovalProcess.aspx?stg=2&lbl=Approval Under Process Beyond Time Limits">
                    <span class="badge" style="background-color: #d9534f;">
                        <asp:label id="Label2" runat="server"></asp:label>
                    </span><i class="fa fa-fw fa-calendar"></i>Beyond Time Limits</a>
                                                                    <a class="list-group-item"
                                                                        href="frmCFEDepartmentsApprovalProcess.aspx?stg=11&lbl=Approval Under Process Within Time Limits Tomorrow">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                            <asp:label id="lblapprlastday" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Today Last Day</a>
                                                                    <a class="list-group-item">
                                                                        <span class="badge">
                                                                            <asp:label id="Label5" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Total</a>
                                                                    <%--href="frmCFEDepartmentsApprovalProcess.aspx?stg=3&lbl=Total Approval Under Process"--%>
                                                                    <a class="list-group-item" href="#"><i class="fa fa-fw fa-check"></i><b>Approval Issued</b></a>
                                                                    <a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=13&lbl=Approval Issued Within Time Limit">
                                                                        <span class="badge" style="background-color: #87D37C;">
                                                                            <asp:label id="Label7" runat="server"></asp:label>
                                                                        </span><i class="fa fa-fw fa-calendar"></i>Within Time Limits </a><a class="list-group-item"
                                                                            href="frmCFEDepartmentsViewAppl.aspx?Stg=14&lbl=Approval Issued Beyond Time Limit">
                                                                            <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:label id="Label9" runat="server"></asp:label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Beyond Time Limits</a> <a class="list-group-item"
                                                                                href="frmCFEDepartmentsViewAppl.aspx?Stg=15&lbl=Total Approval Issued"><span class="badge">
                                                                                    <asp:label id="Label10" runat="server"></asp:label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Total</a> <a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=16&lbl=Applications Rejected">
                                                                                    <span class="badge">
                                                                                        <asp:label id="Label17" runat="server"></asp:label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>No of Applications Rejected
                                                                                </a><a class="list-group-item" href="frmCFEDepartmentsViewAppl.aspx?Stg=17&lbl=Applications appeal against Rejection">
                                                                                    <span class="badge">
                                                                                        <asp:label id="Label13" runat="server"></asp:label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>No of Applications appeal against Rejection
                                                                                </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px">&nbsp;
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                                <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" cellpadding="4"
                                                                    onrowdatabound="GridView1_RowDataBound" onrowcreated="GridView1_RowCreated" showfooter="True" width="100%">
                                                                    <headerstyle height="40px" cssclass="GridviewScrollC1Header" verticalalign="Middle" />
                                                                    <rowstyle height="40px" cssclass="GridviewScrollC1Item" />
                                                                    <pagerstyle height="40px" cssclass="GridviewScrollC1Pager" />
                                                                    <footerstyle height="30px" cssclass="GridviewScrollC1Header" />
                                                                    <alternatingrowstyle height="40px" cssclass="GridviewScrollC1Item2" />
                                                                    <columns>
                                                                        <asp:templatefield headerstyle-horizontalalign="Center" headertext="S.No" headerstyle-width="20px">
                                                                            <itemtemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:hiddenfield id="HdfQueid" runat="server" />
                                                                                <asp:hiddenfield id="HdfApprovalid" runat="server" />
                                                                            </itemtemplate>
                                                                            <headerstyle horizontalalign="Center" />
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:templatefield>
                                                                        <asp:hyperlinkfield datatextfield="ApplicationsReceived" headertext="No. of Applications Received">
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:hyperlinkfield>
                                                                        <asp:hyperlinkfield datatextfield="Approved" headertext="Approved">
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:hyperlinkfield>
                                                                        <asp:hyperlinkfield datatextfield="Rejected" headertext="Rejected">
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:hyperlinkfield>
                                                                        <asp:hyperlinkfield datatextfield="PaymenPending" headertext="Payment Pending">
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:hyperlinkfield>
                                                                        <asp:hyperlinkfield datatextfield="QueryResponsePending" headertext="Query Response Pending">
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:hyperlinkfield>
                                                                        <asp:hyperlinkfield datatextfield="PreScrutinyPending_Within" headertext="Within">
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:hyperlinkfield>
                                                                        <asp:hyperlinkfield datatextfield="PreScrutinyPending_Beyond" headertext="Beyond">
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:hyperlinkfield>
                                                                        <asp:hyperlinkfield datatextfield="ApprovalPending_Within" headertext="Within">
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:hyperlinkfield>
                                                                        <asp:hyperlinkfield datatextfield="ApprovalPending_Beyond" headertext="Beyond">
                                                                            <itemstyle horizontalalign="Center" cssclass="text-center" />
                                                                        </asp:hyperlinkfield>
                                                                    </columns>
                                                                </asp:gridview>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                    <div class="text-right">
                                                        <a href="#">View All Activity <i class="fa fa-arrow-circle-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding: 5px; margin: 5px">
                                            <table cellpadding="2" style="width: 100%">
                                                <tr>
                                                    <td style="width: 417px">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px" align="center">
                                            <asp:gridview id="grdDetails" runat="server" autogeneratecolumns="False" cellpadding="4"
                                                cssclass="GRD" forecolor="#333333" height="62px" pagesize="15" width="100%" visible="False">
                                                <footerstyle backcolor="#013161" font-bold="True" forecolor="White" />
                                                <rowstyle backcolor="#EBF2FE" cssclass="GRDITEM" horizontalalign="Left" verticalalign="Middle" />
                                                <columns>
                                                    <asp:templatefield headerstyle-horizontalalign="Center" headertext="S No" visible="True">
                                                        <itemtemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </itemtemplate>
                                                        <headerstyle horizontalalign="Center" />
                                                        <itemstyle width="50px" />
                                                    </asp:templatefield>
                                                    <asp:boundfield datafield="IPName" headertext="IP Name" />
                                                    <asp:boundfield datafield="TotalWorkProposed" headertext="Total Works Proposed" />
                                                    <asp:boundfield datafield="TotalApproved" headertext="Total Approved" />
                                                    <asp:boundfield datafield="TotalInProgress" headertext="Total InProgress" />
                                                    <asp:boundfield datafield="TotalCompleted" headertext="Total Completed" />
                                                </columns>
                                                <pagerstyle backcolor="#013161" forecolor="White" horizontalalign="Center" />
                                                <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
                                                <headerstyle backcolor="#013161" cssclass="GRDHEADER" font-bold="True" forecolor="White" />
                                                <editrowstyle backcolor="#B9D684" />
                                                <alternatingrowstyle backcolor="White" />
                                            </asp:gridview>
                                        </td>
                                    </tr>
                                </table>
                                <asp:hiddenfield id="hdfID" runat="server" />
                                <asp:hiddenfield id="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
        </contenttemplate>
    </asp:updatepanel>

</asp:content>
