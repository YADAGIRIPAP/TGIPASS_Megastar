<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="CFOJDDASHBOARD.aspx.cs" Inherits="UI_TSiPASS_CFOJDDASHBOARD" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                                                        </i> TSiPASS at a Glance Report</a>
                                                                            <ul>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="frmCommissionerReportDashboardCFO.aspx"><i
                                                                                    class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R.1:
                                                                                    TS-iPASS Master Report(CFO)</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="frmR1ReportKMRCFO.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R.2:
                                                                                    CM's Dashboard</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="DepartmentAbstractLatestCFO.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R.3:
                                                                                    Department wise performance Tracker</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="frmCFOFinancialYear.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R.4:
                                                                                    Financial Year Wise Report</a> </li>
                                                                                <%--<li><a style="text-decoration: none;" target="_blank" href="SectorWiseReportold2New.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.5:
                                                                                    Sector Wise Report</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="StageOfImplementationReportold2New.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.6:
                                                                                    Implementation Status Wise Abstract</a> </li>
                                                                                <li><a style="text-decoration: none;" target="_blank" href="StageOfImplementationReportold2NewDropped.aspx">
                                                                                    <i class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1.7:
                                                                                    Dropped Industries</a> </li>
                                                                               --%>
                                                                            </ul>
                                                                        </li>
                                                                                                                                             
                                                                    </ul>
                                                                </div>
                                                            </td>
                                                            <td style="width: 30px">
                                                                &nbsp;
                                                            </td>
                                                            <td valign="top" style="width: 395px">
                                                                
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