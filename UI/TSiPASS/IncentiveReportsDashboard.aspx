<%@ page title="" language="C#" masterpagefile="~/UI/TSIPASS/CCMaster.master" autoeventwireup="true" codefile="IncentiveReportsDashboard.aspx.cs" inherits="UI_TSIPASS_IncentiveReportsDashboard" %>

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
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 style="font-family: Cambria;" class="panel-title">MIS Incentive Reports Dashboard</h3>
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
                                                                <b>Incentive Reports</b>
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
                                                                        <li id="Li5" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R1: TGiPASS Incentive</a>
                                                                            <ul id="gmcoi1" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveDashBoard.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.1:
                                                                                     Incentive - Master Report</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoi2" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveClaimsReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.2:
                                                                                     Incentive Claim - Approvals Report</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoi3" runat="server">
                                                                                <%--href="IncentiveMISPendencyReport.aspx"--%>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveMISPendencyReport1.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.3:
                                                                                     Incentive - MIS GM Pendency</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoi22" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveMISPendencyReportCOI.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.3.1:
                                                                                     Incentive - MIS GM Pendency with officer names</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoi4" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveSanctionMISPendencyReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.4:
                                                                                     Incentive - MIS Sanction Pendency</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoi5" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveDisbursmentMISPendencyReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.5:
                                                                                     Incentive - MIS Disbursment Pendency</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoi6" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentivePendencyReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.6:
                                                                                     Incentive - Pendency Report</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoi7" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveAbstractReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.7:
                                                                                     Incentive - Abstract Report</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoi8" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveQueryReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.8:
                                                                                   Incentive - Query Report</a> </li>
                                                                            </ul>
                                                                            <ul id="ulSLCSVCRep" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmJDSvcSlcReport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.9:
                                                                                   Incentive - SLC SVC REPORT</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoireport" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveMISPendencyReportCOI.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.3:
                                                                                    Incentive Claim - GM level Pendency Report</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoireport9" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmIncentiveProceedingabstract.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.4:
                                                                                    Post Approval - Stage Wise Abstract</a> </li>
                                                                            </ul>
                                                                            <ul id="gmcoireport10" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="ComnrReportRelases.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.5:
                                                                                    Post Approval - Stage Wise Abstract(New Process)</a> </li>
                                                                            </ul>
                                                                            <ul id="ulReleasesReport" runat="server">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmIncentivewisesReleasepending.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    Sanctioned Release Pending</a> </li>
                                                                            </ul>
                                                                            <ul id="Ulgmdelayreport" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmGMDelayReasonReportCOI.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    GM Explanation Report for Beyond Timelimit</a> </li>
                                                                            </ul>
                                                                        </li>
                                                                        <li id="Li1" class='has-sub' runat="server"><a href='#'><i class="fa fa-fw fa-database"></i>R2: Releases</a>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmIncentiveProceedingabstract.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.1:
                                                                                    Proceedings Abstarct - District Wise </a></li>
                                                                            </ul>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="ReleaseProceedingsabstractDistrictwiseSLC.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.2:
                                                                                    Release Proceedings Abstarct - District Wise - SLC </a></li>
                                                                            </ul>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="ReleaseProceedingsabstractDistrictwiseDIPC.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.3:
                                                                                    Release Proceedings Abstarct - District Wise - DIPC </a></li>
                                                                            </ul>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmProceedingsabstractSLC.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.4:
                                                                                    Release Proceedings Wise Abstarct - SLC </a></li>
                                                                            </ul>
                                                                            <ul>
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmProceedingsabstractDLC.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.5:
                                                                                    Release Proceedings Wise Abstarct - DIPC </a></li>
                                                                            </ul>
                                                                            <ul id="Ul1" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="ComnrReportRelases.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2.6:
                                                                                    Post Approval - Stage Wise Abstract(New Process)</a> </li>
                                                                            </ul>
                                                                        </li>

                                                                        <li style="color: #337ab7;"><a id="A2" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="frmdipcmeetings.aspx"><i class="fa fa-fw fa-database"></i>R3:  DIPC Meetings - Abstarct</a> </li>
                                                                        <li id="AUTOREJECTED" runat="server" style="color: #337ab7;"><a id="A1" runat="server" style="text-decoration: none;"
                                                                            target="_blank" href="IncentiveGMQueryAutoRejected.aspx"><i class="fa fa-fw fa-database"></i>R4:  Incentive AutoRejected</a> </li>
                                                                        <li id="Li2" class='has-sub' runat="server" visible="false"><a href='#'><i class="fa fa-fw fa-database"></i>
                                                                            <asp:label id="lblr5" runat="server" visible="false" text="R5: Incentives Reports New"></asp:label>
                                                                        </a>
                                                                            <ul id="uir51" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveWisePendencylist.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.1:
                                                                                    PENDANCY OF INCENTIVES </a></li>
                                                                            </ul>
                                                                            <ul id="uir52" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="IncentiveWiselistALL.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.2:
                                                                                    INCENTIVES PENDANCY SLC&DLC </a></li>
                                                                            </ul>
                                                                            <ul id="uir53" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmIncentives_Sanctioned_Yearwise.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.3:
                                                                                    Incentives Sanctioned-Financial Year Wise </a></li>
                                                                            </ul>
                                                                            <ul id="uir54" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmSanctioned_ReleasingPending_Yearwise.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.4:
                                                                                    Incentives Sanctioned & Release Pending-Financial Year Wise </a></li>
                                                                            </ul>
                                                                            <ul id="uir55" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmIncentives_Released_Yearwise.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.5:
                                                                                    Incentives Released-Financial Year Wise </a></li>
                                                                            </ul>
                                                                            <ul id="uir56" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="frmIncentivePendencyHeadOffice.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.6:
                                                                                    Officer Wise Pendency-COI </a></li>
                                                                            </ul>
                                                                            <ul id="Ul2" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="generaldistrictandcategorywisependingreport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.7:
        T IDEA District and Category Wise Report  </a></li>
                                                                            </ul>
                                                                            <ul id="Ul3" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="TPRIDEDISTandcategorywisependingreport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.8:
        T PRIDE District and Category Wise Report </a></li>
                                                                            </ul>
                                                                            <ul id="Ul4" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="generalfinancialyearandcategorywisependingreport.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.9:
        T IDEA Financal Year and Category Wise Report </a></li>
                                                                            </ul>
                                                                            <ul id="Ul5" runat="server" visible="false">
                                                                                <li style="color: #337ab7;"><a style="text-decoration: none;" target="_blank" href="TPRIDEfinancialyearandcategorywisependingreport	.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R5.10:
        T PRIDE Financal Year and Category Wise Report </a></li>
                                                                            </ul>
                                                                        </li>
                                                                        <li style="color: #337ab7;"><a id="LIHEADOFFICE" runat="server" style="text-decoration: none;" visible="false"
                                                                            target="_blank" href="HEADOFFICEOFFICERWISEPENDENCY.aspx"><i class="fa fa-fw fa-database"></i>Pendency Report - Head Office</a> </li>

                                                                        <li style="color: #337ab7;"><a id="LIPLOTREPORT" runat="server" style="text-decoration: none;" visible="false"
                                                                            target="_blank" href="frmPlotAbstractDetails.aspx"><i class="fa fa-fw fa-database"></i>TGIIC Plot Allotment Abstract Report</a> </li>
                                                                    </ul>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">&nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px"></td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                </div>
                                            </div>
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

