<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="ReportsDashboardNew.aspx.cs" Inherits="Dashboard" %>

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
                                <h3 style="font-family: Cambria;" class="panel-title">MIS CFE Reports Dashboard</h3>
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
                                                            <td colspan="3" style="width: 100%; color: #337ab7; text-align: center; font-family: Cambria; font-size: 18px;">
                                                                <b>TG-iPASS CFE Reports</b>
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
                                                                <div id='DashBoardmenu' style="font-weight: bold; font-family: Cambria; font-size: 16px; width: 100%">
                                                                    <ul>
                                                                        <li id="Li2" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>TGiPASS at a Glance Report</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RPTGlance2New.aspx"><i
                                                                                    class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    CFE at a Glance Report</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="frmrptGlance2Newfin.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    CFE at a Glance Report-abstract</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="frmR1ReportKMRNew.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    CM's Dashboard</a> </li>
                                                                                <%--  <li><a style="text-decoration: none;" target="_blank" href="RptYEARWISEPROGRESSNew.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.3
                                                                                    Applications -Financial Year Wise</a> </li>--%>
                                                                                <li id="Lir14a" class='has-sub' runat="server"><a style="text-decoration: none;" target="_blank" href="RptCertificatePendencyNew.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    TGiPASS Approval Generation Status</a> </li>
                                                                                <li id="Lir15a" class='has-sub' runat="server"><a style="text-decoration: none;" target="_blank" href="MonthwiseStatusrpt.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    Month wise Applications Received and Status of Implementation</a> </li>
                                                                                <li id="Lir16a" class='has-sub' runat="server"><a style="text-decoration: none;" target="_blank" href="frmTodayapps.aspx"><i
                                                                                    class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    Periodic Breakup-Investment and Employemnt</a> </li>
                                                                                <li id="Lir17a" class='has-sub' runat="server" visible="false"><a style="text-decoration: none;" target="_blank" href="coiGeneralQueryAbstarct.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.6
                                                                                    Appeal, General Query, Grievance Report</a> </li>
                                                                                <%--                                 <li id="lianalasis" runat="server" visible="false" ><a style="text-decoration: none;" target="_blank" href="frmAbstractanasisreport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.6 Approval Analysis</a> </li>--%>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="Li3" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R2: Scrutiny Stage</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptSTATUSOFPRESCRUTINYDEPARTMENTWISENew.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.1
                                                                                    Status of Scrutiny - Department wise</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="Rpt1PrescrutinyStatusDepartmentwiseNew.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.2
                                                                                    Scrutiny - Query Details</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="LiR3" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R3: Total Approvals Status</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptAPPROVALSDEPARTMENTWISENew.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R3.1:
                                                                                    Total Approvals Status - Department wise</a> </li>
                                                                                <li runat="server" id="LiR32" visible="false"><a style="text-decoration: none;" target="_blank"
                                                                                    href="RPTAPPROVALSGIVENINTSiPASSNew.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R3.2: Approvals Given in TGiPASS</a> </li>
                                                                                <li runat="server" id="Li8"><a style="text-decoration: none;" target="_blank" href="frmRejectedApprovals.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R3.3:
                                                                                    Approvals Rejected</a> </li>
                                                                                <li runat="server" id="Li10Pendency" visible="false"><a style="text-decoration: none;"
                                                                                    target="_blank" href="AllApprovalsPending.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R3.4: Pendency Report </a></li>
                                                                            </ul>
                                                                        </li>
                                                                        <%--<li><a style="text-decoration: none;" target="_blank" href="RptAPPROVALSDEPARTMENTWISE.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R3: Total approvals status - Department wise</a>
                                                                        </li>--%>
                                                                        <li id="Li4" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R4: Department wise Pendency</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptApprovalspendingbeyondtimelimitNew.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R4.1:
                                                                                    Approvals Pending Beyond Time Limit - Detailed list</a> </li>
                                                                                <li id="LiR52" runat="server"><a style="text-decoration: none;" target="_blank" href="RptPendencyNew.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    R4.2: Department wise Pendency Report</a> </li>
                                                                                <li id="Li43" visible="false" runat="server"><a style="text-decoration: none;" target="_blank"
                                                                                    href="RptPendencyinvestmentwise.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp; R4.3: Investment wise Pendency Report</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="LiR5" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>Department wise progress</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="RptAPPROVALSDEPARTMENTWISENew.aspx">
    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
    Total Approvals Status - Department wise</a> </li>
                                                                                
                                                                                <li><a style="text-decoration: none;" target="_blank" href="DepartmentAbstractLatestNew1.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    Department wise performance Tracker</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="frmcfecfoReviewPendency.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    Department wise Pendency for Review Meeting</a> </li>
                                                                                <li runat="server" id="liprocessedapplicationsreport" ><a style="text-decoration: none;" target="_blank" href="frmDepartmentProcessedApplist.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    R5.3: Processed Applications Report </a></li>
                                                                                 <li  runat="server" visible="false" id="LIREVIEWPENDINCYPRINT"><a style="text-decoration: none;" target="_blank" href="frmcfecfoReviewPendency_print.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    Department wise Pendency Print for Review Meeting  </a></li>
                                                                                <li runat="server" visible="false" id="liR5ApplicationData"><a style="text-decoration: none;"
                                                                                    target="_blank" href="RptApplicationData.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp; R5.3: Application Wise Details</a> </li>
                                                                                <li runat="server" visible="false" id="li10"><a style="text-decoration: none;" target="_blank"
                                                                                    href="RptBeyondapps.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp; R5.4: TGiPASS - Applications Yet to Fall in Pendency</a>
                                                                                </li>
                                                                                <li runat="server" visible="false" id="li13"><a style="text-decoration: none;" target="_blank"
                                                                                    href="frmPlotAbstractDetails.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp; R5.4: TGIIC- Application Wise Details</a>
                                                                                </li>
                                                                            </ul>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                <div id='DashBoardmenu' style="font-weight: bold; font-family: Cambria; font-size: 16px; width: 100%">
                                                                    <ul>
                                                                        <li id="Masters" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>TGiPASS approvals Abstract</a>
                                                                            <ul>
                                                                                <li id="li6_1" runat="server" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="TotalReportold2New.aspx"><i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;District wise Abstract</a> </li>
                                                                                <%-- <li style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="SectorWiseReportold2New.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.2: Sector wise Abstract</a> </li>--%>
                                                                                <li id="li6_2" runat="server" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="SectorWiseReportold2New.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;Sector wise Abstract</a> </li>
                                                                                <%-- <li style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="SubSectorWiseReport.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.2.2: Sub-Sector wise Abstract</a> </li>--%>
                                                                                <li id="li6_3" runat="server" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="StageOfImplementationReportold2New.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;Implementation status wise Abstract</a></li>
                                                                                <li id="li6_4" runat="server" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="TableOnEmployment2New.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;Employment Potential Abstract</a> </li>
                                                                                <li id="li6_5" runat="server" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="TableOnInvestment2New.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;Investment wise Abstract</a> </li>
                                                                                <li id="li6_6" runat="server" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="SectorWiseReportUptoOneCrore.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R6.6: Investment Range Wise - Sector Report</a>
                                                                                </li>
                                                                                <li id="li6_7" runat="server" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="StageOfImplementationReportold2NewDropped.aspx"><i style="text-indent: 20px"
                                                                                        class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R6.7: Dropped Industries</a>
                                                                                </li>
                                                                                <li id="li6_8" runat="server" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="frmImplstatuspendency.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R6.8: Status of Implementation - Pendency</a> </li>
                                                                                <li id="li6_9" runat="server" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="frmImplstatuspendencyDistwise.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R6.9: Status of Implementation Abstract -District wise
                                                                                    Pendency</a> </li>

                                                                                <li id="li6_10" runat="server" visible="false" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="frmDistrictWisePollutionCategorylReport.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R6.10: Pollution Category Wise Report</a> </li>
                                                                                <li id="li6_11" runat="server" visible="false" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="WOMENENTDASHBOARDDATA.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database"></i>&nbsp;&nbsp;&nbsp;&nbsp;R6.11: Women Entrepreneurs Data</a> </li>
                                                                                <%--Added on 13/02/2024--%> 
                                                                               
                                                                                <li runat="server" id="LIR1_10" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="CommissionerReportDashboard.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.10: Applications Abstract</a>
                                                                                </li>
                                                                                <li  runat="server" id="LIR1_11" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="DistricReport.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.11: Applications Abstract (Approvals wise)</a>
                                                                                </li>
                                                                                <li   runat="server" id="LIR1_12" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="frmCommensedOperation.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.12: Commenced Operations Abstract</a>
                                                                                </li>

                                                                                 <li  runat="server" id="LIR1_13"  style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="Totalreport.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.13: Application Date wise Abstract</a>
                                                                                </li>
                                                                                <li  runat="server" id="LIR1_14"  style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
                                                                                    href="Districtwiseapproved.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
                                                                                    </i>&nbsp;&nbsp;&nbsp;&nbsp;R6.14: Approval Date wise Abstract</a>
                                                                                </li>
                                                                                <li id="LIPLOTALLOTMENT" runat="server" visible="false" style="color: #555555;"><a style="color: #555555; text-decoration: none;" target="_blank"
    href="frmPlotAbstractDetails.aspx"><i style="text-indent: 20px" class="fa fa-fw fa-database">
    </i>&nbsp;&nbsp;&nbsp;&nbsp;TGIIC Plot Allotment Abstract</a>
</li>

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
                                                                        <li id="Li1" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R7: Incentive Sanctions</a>
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
                                                                            target="_blank" href="renewalsReportsdashboard.aspx"><i class="fa fa-fw fa-database"></i>R8: Renewals Dashboard</a> </li>
                                                                        <li id="LiR9" runat="server" style="color: #337ab7;"><a id="lst1" runat="server"
                                                                            style="text-decoration: none;" target="_blank" href="frmCFEpaymentDetails.aspx">
                                                                            <i class="fa fa-fw fa-database"></i>R9: Payment Details</a> </li>
                                                                        <li id="LiR10" runat="server" style="color: #337ab7;"><a id="A1" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="MISEReport.aspx"><i class="fa fa-fw fa-database"></i>R10:
                                                                            MSME Catalogue Report</a> </li>
                                                                        <li id="LiR101" runat="server" style="color: #337ab7;"><a id="Association" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="MISEReportAssociation.aspx"><i class="fa fa-fw fa-database"></i>R10.1: MSME Catalogue Report(IAs)</a> </li>
                                                                        <li id="LiR11" runat="server" style="color: #337ab7;"><a id="VATManufacture" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="frmVATManufactureGMUpdated.aspx"><i class="fa fa-fw fa-database"></i>R11: VAT Details(Manufactures)</a> </li>
                                                                        <li id="LiR12" runat="server" style="color: #337ab7;"><a id="VATExporters" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="frmVATExportGMUpdated.aspx"><i class="fa fa-fw fa-database"></i>R12: TS Exporters</a> </li>
                                                                        <li id="Li33" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R11: Grievance Report</a>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="RptHelpdeskRpt.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R11.1:
                                                                                    TGiPASS Helpdesk - Abstract Report</a> </li>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="RptGrievance.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    R11.2: Department Wise Grievance Redressal</a> </li>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="RptGrievanceSub.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    R11.3: Subject Wise Grievance Redressal</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <%-- RankingTool.aspx--%>
                                                                        <li runat="server" id="rankingreport" style="color: #337ab7;"><a id="A2" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="#"><i class="fa fa-fw fa-database"></i>R13: RANKING of DEPTs
                                                                            - TGiPASS</a> </li>
                                                                        <li id="Li5" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R14: Incentive</a>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveDashBoard.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R14.1:
                                                                                    TGiPASS Incentive - MIS1</a> </li>
                                                                            </ul>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveClaimsReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R14.2:
                                                                                    TGiPASS Incentive - MIS2</a> </li>
                                                                            </ul>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveMISPendencyReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R14.3:
                                                                                    TGiPASS Incentive - MIS GM Pendency</a> </li>
                                                                            </ul>
                                                                            <%--  <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveSanctionMISPendencyReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R14.4:
                                                                                    TSiPASS Incentive - MIS Sanction Pendency</a> </li>
                                                                            </ul>--%>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveDisbursmentMISPendencyReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R14.4:
                                                                                    TGiPASS Incentive - MIS Disbursment Pendency</a> </li>
                                                                            </ul>
                                                                            <%--<ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentivePendencyReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R14.6:
                                                                                    TSiPASS Incentive - Pendency Report</a> </li>
                                                                            </ul>--%>
                                                                            <%-- <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveApprovalReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R14.7:
                                                                                    TSiPASS Incentive - Approval Report</a> </li>
                                                                            </ul>--%>
                                                                        </li>
                                                                        <li id="Li6" class='has-sub' visible="false" runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R15: 90% Breach</a>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="CFEMISPendencyReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R15.1:
                                                                                    CFE MIS-Pendency Report </a></li>
                                                                            </ul>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="CFOMISPendencyReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R15.1:
                                                                                    CFO MIS-Pendency Report </a></li>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="Li7" runat="server" style="color: #337ab7;"><a id="A3" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="FeedbackRptNew.aspx"><i class="fa fa-fw fa-database"></i>R16:
                                                                            Feedback Report-Retrospective</a> </li>
                                                                        <li id="Li9" runat="server" style="color: #337ab7;"><a id="A4" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="frmfeedbackprospective.aspx"><i class="fa fa-fw fa-database"></i>R17: Feedback Report-Prospective</a> </li>
                                                                        <li id="Li11" runat="server" style="color: #337ab7;"><a id="A5" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="TotalReportold2NewDuplicate.aspx"><i class="fa fa-fw fa-database"></i>R18: District Wise Abstract Latest</a> </li>
                                                                        <li id="LiRkotak" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R19: Payment Details</a>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmCFEpaymentDetails.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.1:
                                                                                    CFE Payment Details</a> </li>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmCFEpaymentDetailsKotakSplit.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.2:
                                                                                    CFE Split Payment</a> </li>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmKotakReversalResponse.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.3:
                                                                                    CFE Split Response</a> </li>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmCFESplitPaymentReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.4:
                                                                                    CFE Split Payment Report</a> </li>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmCFESplitPaymentReport_RDO.aspx?rdoFlag=Y">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.5:
                                                                                    RDO Pending Payments</a> </li>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmUTRNumberSearch.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.6:
                                                                                    Split Payment Details On UTR Number</a> </li>

                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmCFEpaymentDetailsKotakSplitTSIIC.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.7:
                                                                                    TGIIC BP Split Payment Details</a> </li>                                                                                

                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmspiltresponsebulk.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.8:
                                                                                    Split Payment Bulk Response Update</a> </li>

                                                                                 <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmCFEpaymentDetailsKotakSplitMunicipality.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.9:
                                                                                    Municipality Split Payment Details</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="Li12" class='has-sub' runat="server" visible="false"><a href='#'><i class="fa fa-fw fa-database"></i>Pendency Report</a>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="comReportDrill.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R19.1:
                                                                                    Pendency Report</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="lblmandalwisedata" runat="server" style="color: #337ab7;"><a id="A6" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="TotalReportold2New_mandalwise.aspx"><i class="fa fa-fw fa-database"></i>
                                                                            <asp:Label ID="lblR7" runat="server" Text="R20. Mandal Wise Abstract Latest"></asp:Label></a> </li>

                                                                        <li id="lblmandalwisesanctioneddata" runat="server" style="color: #337ab7;"><a id="A7" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="SANCTIONEDSLCDIPCDATA_MANDALWISE.aspx"><i class="fa fa-fw fa-database"></i>
                                                                            <asp:Label ID="lblR8" runat="server" Text="R21: Mandal Wise Sanctioned Claims (Incentives)"> </asp:Label></a> </li>



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
