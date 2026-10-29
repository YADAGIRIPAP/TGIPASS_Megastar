<%@ Page Title=":: TSiPASS : MIS Reports " Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master"
    AutoEventWireup="true" CodeFile="ReportsDashboard.aspx.cs" Inherits="Dashboard" %>

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
                                    MIS CFE Reports Dashboard</h3>
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
                                                                <b>TS-iPASS CFE Reports</b>
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
                                                                        </i>R1: TSiPASS at a Glance Report</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="rptglance2.aspx"><i class="fa fa-fw fa-database"
                                                                                    style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.1: CFE at a Glance Report</a>
                                                                                </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="frmR1ReportKMR.aspx"><i
                                                                                    class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.2:
                                                                                    CM's Dashboard</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptYEARWISEPROGRESS.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.3
                                                                                    Applications -Financial Year Wise</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptCertificatePendency.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.4:
                                                                                    TSiPASS Approval Generation Status</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="Li3" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>R2: Pre-scrutiny Stage</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptSTATUSOFPRESCRUTINYDEPARTMENTWISE.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.1
                                                                                    Status of Prescrutiny - Department wise</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="Rpt1PrescrutinyStatusDepartmentwise.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.2
                                                                                    Pre-scrutiny - Query Details</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="LiR3" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>R3: Total Approvals Status</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptAPPROVALSDEPARTMENTWISE.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R3.1:
                                                                                    Total Approvals Status - Department wise</a> </li>
                                                                                <li runat="server" id="LiR32" visible="false"><a style="text-decoration: none;" target="_blank"
                                                                                    href="RPTAPPROVALSGIVENINTSiPASS.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R3.2: Approvals Given in TSiPASS</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <%--<li><a style="text-decoration: none;" target="_blank" href="RptAPPROVALSDEPARTMENTWISE.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R3: Total approvals status - Department wise</a>
                                                                        </li>--%>
                                                                        <li id="Li4" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>R4: Department wise Pendency - Abstract</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptApprovalspendingbeyondtimelimit.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R4.1:
                                                                                    Approvals Pending Beyond Time Limit - Detailed list</a> </li>
                                                                                <li id="LiR52" runat="server"><a style="text-decoration: none;" target="_blank" href="RptPendency.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    R4.2: Department wise Pendency Report - Abstract</a> </li>
                                                                                    <li id="Li43" visible="false" runat="server"><a style="text-decoration: none;" target="_blank" href="RptPendencyinvestmentwise.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    R4.3: Investment wise Pendency Report</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <%--<li><a style="text-decoration: none;" target="_blank" href="RptDEPARTMENTWISEPROGRESS.aspx"><i class="fa fa-fw fa-database">
                                                                        </i>R5: Department wise progress</a> </li>--%>
                                                                        <%--<li ><a style="text-decoration: none;" target="_blank" href="DepartmentAbstractLatest.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R5: Department wise performance Tracker</a>
                                                                        </li>--%>
                                                                        <li id="LiR5" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>R5: Department wise progress</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="DepartmentAbstractLatest.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    R5.1: Department wise performance Tracker</a> </li>
                                                                                <li runat="server" visible="false" id="liR5ApplicationData"><a style="text-decoration: none;" target="_blank"
                                                                                    href="RptApplicationData.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp; R5.2: Application Wise Details</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                    <%--<a href="frmR1ReportKMR.aspx" class="list-group-item"><i class="fa fa-fw fa-database">
                                                                        </i>R1: CM's Dashboard </a><a class="list-group-item" href="RptYEARWISEPROGRESS.aspx">
                                                                            <i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.1
                                                                            Applications -Financial Year Wise</a> <a class="list-group-item" href="#"><i class="fa fa-fw fa-database">
                                                                            </i>R2: Pre-scrutiny Stage </a><a href="RptSTATUSOFPRESCRUTINYDEPARTMENTWISE.aspx"
                                                                                class="list-group-item"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                </i>&nbsp;&nbsp;&nbsp;&nbsp;R2.1 Status of Prescrutiny - Department wise</a>
                                                                        <a class="list-group-item" href="Rpt1PrescrutinyStatusDepartmentwise.aspx"><i style="text-indent: 20px"
                                                                            class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.2 Pre-scrutiny - Query
                                                                            Details </a><a style="color:#337ab7;" href="RptAPPROVALSDEPARTMENTWISE.aspx" class="list-group-item"><i
                                                                                class="fa fa-fw fa-database"></i>R3: Total approvals status - Department wise</a>
                                                                        <a style="color:#337ab7;" class="list-group-item" href="RptApprovalspendingbeyondtimelimit.aspx"><i class="fa fa-fw fa-database">
                                                                        </i>R4: Approvals pending beyond time limit </a><a href="RptDEPARTMENTWISEPROGRESS.aspx"
                                                                            class="list-group-item"><i class="fa fa-fw fa-database"></i>R5: Department wise
                                                                            progress </a><a style="color:#337ab7;" href="DepartmentAbstractLatest.aspx" class="list-group-item"><i class="fa fa-fw fa-database">
                                                                            </i>R6: TS-iPASS Applications - Department wise performance tracker</a>
                                                                        <a href="DIstrictwiseExistingList.aspx" class="list-group-item">
                                                                            <i class="fa fa-fw fa-database"></i>R7: Detailed list of Industry approvals - District
                                                                            wise </a>--%>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div id='DashBoardmenu' style="font-weight: bold; font-family: Cambria; font-size: 16px;
                                                                    width: 100%">
                                                                    <ul>
                                                                        <li id="Masters" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>R6: TS-iPASS approvals Abstract</a>
                                                                            <ul>
                                                                                <li style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="TotalReportold2.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.1: District wise Abstract</a> </li>
                                                                                <li style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="SectorWiseReportold2.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.2: Sector wise Abstract</a> </li>
                                                                                <li style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="StageOfImplementationReportold2.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.3: Implementation status wise Abstract</a></li>
                                                                                <li style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="TableOnEmployment2.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.4: Employment Potential Abstract</a> </li>
                                                                                <li style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="TableOnInvestment2.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.5: Investment wise Abstract</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <%--<li id="R7" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i><b>R7: TS-iPASS approvals Abstract</b></a>
                                                                            <ul>
                                                                                <li><a class="list-group-item" href="TotalReportold.aspx"><i class="fa fa-fw fa-database"
                                                                                    style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R7.1: District wise Abstract</a>
                                                                                </li>
                                                                                <li><a class="list-group-item" href="SectorWiseReportold.aspx"><i style="text-indent: 20px"
                                                                                    class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R7.2: Sector wise Abstract</a>
                                                                                </li>
                                                                                <li><a class="list-group-item" href="StageOfImplementationReportold.aspx"><i style="text-indent: 20px"
                                                                                    class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R7.3: Implementation status
                                                                                    wise Abstract</a></li>
                                                                                <li><a class="list-group-item" href="TableOnEmployment.aspx"><i style="text-indent: 20px"
                                                                                    class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R7.4: Table On Employment</a>
                                                                                </li>
                                                                                <li><a class="list-group-item" href="TableOnInvestment.aspx"><i style="text-indent: 20px"
                                                                                    class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R7.5: Table On Investment</a>
                                                                                </li>
                                                                            </ul>
                                                                        </li>--%>
                                                                        <li id="Li1" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>R7: Incentive Sanctions</a>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="SanctionedIncentives.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R7.1:
                                                                                    Industry wise Incentives sanctioned by SLC</a> </li>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="SanctionedIncentivesDCIP.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R7.2:
                                                                                    Industry wise Incentives sanctioned DIPC</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <%--<a href="#" class="list-group-item"><i class="fa fa-fw fa-database"></i><b>R8: Incentive
                                                                                sanctions</b></a> <a class="list-group-item" href="SanctionedIncentives.aspx"><i
                                                                                    style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;</a> <a class="list-group-item" href="SanctionedIncentivesDCIP.aspx">
                                                                                        <i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R8.2:
                                                                                        Industry wise Incentives sanctioned DIPC</a>--%>
                                                                        <li id="LiR8" runat="server" style="color: #337ab7;"><a style="text-decoration: none;"
                                                                            target="_blank" href="renewalsReportsdashboard.aspx"><i class="fa fa-fw fa-database">
                                                                            </i>R8: Renewals Dashboard</a> </li>
                                                                        <li id="LiR9" runat="server" style="color: #337ab7;"><a id="lst1" runat="server"
                                                                            style="text-decoration: none;" target="_blank" href="frmCFEpaymentDetails.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R9: Payment Details</a> </li>
                                                                        <li id="LiR10" runat="server" style="color: #337ab7;"><a id="A1" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="MISEReport.aspx"><i class="fa fa-fw fa-database"></i>R10:
                                                                            MSME Catalogue Report</a> </li>
                                                                        <li style="color: #337ab7;"><a id="Association" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="MISEReportAssociation.aspx"><i class="fa fa-fw fa-database">
                                                                            </i>R10.1: MSME Catalogue Report(IAs)</a> </li>
                                                                        <li style="color: #337ab7;"><a id="VATManufacture" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="frmVATManufactureGMUpdated.aspx"><i class="fa fa-fw fa-database">
                                                                            </i>R11: VAT Details(Manufactures)</a> </li>
                                                                        <li style="color: #337ab7;"><a id="VATExporters" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="frmVATExportGMUpdated.aspx"><i class="fa fa-fw fa-database">
                                                                            </i>R12: TS Exporters</a> </li>
                                                                            
                                                                             <li id="Li33" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database">
                                                                        </i>R11: Grievance Report</a>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="RptHelpdeskRpt.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R11.1:
                                                                                    TSiPASS Helpdesk - Abstract Report</a> </li>
                                                                               
                                                                            </ul>
                                                                        </li>
                                                                        <%-- <a class="list-group-item" href="renewalsReportsdashboard.aspx"><i class="fa fa-fw fa-database">
                                                                    </i>R9: Renewals Dashboard</a> <a id="lst1" runat="server" target="_blank" class="list-group-item"
                                                                        href="frmCFEpaymentDetails.aspx"><i class="fa fa-fw fa-database"></i>R10: Payment
                                                                        Details</a>--%>
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
