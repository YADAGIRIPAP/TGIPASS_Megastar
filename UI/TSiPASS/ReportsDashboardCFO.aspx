<%@ Page Title=":: TSiPASS : MIS Reports " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="ReportsDashboardCFO.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">




    </script>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div align="left">
                <ol class="breadcrumb">
                    You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                    <li><i class="fa fa-dashboard"></i><a href="Home.aspx">Dashboard</a> </li>
                </ol>
            </div>
            <div align="center">
                <div class="row" align="center">
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 style="font-family: Cambria;" class="panel-title">
                                    MIS CFO Reports Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 100%">
                                                        <%--<tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="3">
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/Home.aspx">Back</asp:HyperLink>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td colspan="3" style="width: 100%; color: #337ab7; text-align: center; font-family: Cambria;
                                                                font-size: 18px;">
                                                                <b>TS-iPASS CFO Reports</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px; font-size: 16px;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 395px" valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div id='DashBoardmenu' style="font-weight: bold; font-family: Cambria; font-size: 16px;
                                                                    width: 100%">
                                                                    <ul>
                                                                        <li id="Li2" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>CFO CM's Dashboard</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="frmR1ReportKMRCFO.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1:
                                                                                    CFO CM's Dashboard</a> </li>
                                                                                <li id="licfofin" runat="server" visible="false"><a style="text-decoration: none;" target="_blank" href="RptYEARWISEPROGRESSCFO.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.1
                                                                                    Applications -Financial Year Wise</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="Li3" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>R2: Scrutiny Stage</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptSTATUSOFPRESCRUTINYDEPARTMENTWISECFO.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.1
                                                                                    Status of Scrutiny - Department wise</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="Rpt1PrescrutinyStatusDepartmentwiseCFO.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.2
                                                                                    Scrutiny - Query Details</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <li runat="server" id="LIR3"><a style="text-decoration: none;" target="_blank" href="RptAPPROVALSDEPARTMENTWISECFO.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R3: Total approvals status - Department wise</a>
                                                                        </li>
                                                                        <li runat="server" id="LIR4"><a style="text-decoration: none;" target="_blank" href="RptApprovalspendingbeyondtimelimitCFO.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R4: Approvals pending beyond time limit</a>
                                                                        </li>
                                                                        <%--<li><a style="text-decoration: none;" target="_blank" href="RptDEPARTMENTWISEPROGRESS.aspx"><i class="fa fa-fw fa-database">
                                                                        </i>R5: Department wise progress</a> </li>--%>
                                                                        <li runat="server" id="LIR5"><a style="text-decoration: none;" target="_blank" href="DepartmentAbstractLatestCFO.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>Department wise performance Tracker</a>
                                                                        </li>
                                                                        <%--<li><a style="text-decoration: none;" target="_blank" href="frmCFOFinancialYear.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R6: Financial Year Wise Report</a>
                                                                        </li>--%>
                                                                        <li  runat="server" id="LIR6"><a style="text-decoration: none;" target="_blank" href="frmDepartmentProcessedApplistCFO.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R6: Processed Applications Report</a>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div id='DashBoardmenu' style="font-weight: bold; font-family: Cambria; font-size: 16px;
                                                                    width: 100%">
                                                                    <ul>
                                                                        
                                                                        <li id="LiR9" visible="false"  runat="server" style="color: #337ab7;"><a id="lst1" runat="server"
                                                                            style="text-decoration: none;" target="_blank" href="frmCFOpaymentDetails.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R6: Payment Details</a> </li>
                                                                        
                                                                    </ul>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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
