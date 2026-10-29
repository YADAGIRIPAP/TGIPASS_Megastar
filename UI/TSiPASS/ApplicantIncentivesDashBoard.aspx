<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true"
    CodeFile="ApplicantIncentivesDashBoard.aspx.cs" Inherits="UI_TSiPASS_ApplicantIncentivesDashBoard" %>

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
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    Incentive Dashboard</h3>
                            </div>
                            <div class="panel-body">
                                <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="padding: 5px; margin: 5px">
                                            <div class="panel panel-default">
                                                <div class="panel-body" align="center">
                                                    <table cellpadding="3" cellspacing="5" style="width: 80%">
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="0">
                                                                <%--<asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/ApplicantIncentivesDashBoard.aspx">Back</asp:HyperLink>--%>
                                                                <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/UI/TSiPASS/ApplicantIncentivesHistory.aspx"><b>Back</b></asp:HyperLink><br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="0">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-size: 16px; text-align: center;" colspan="0" align="left">
                                                                <b>Application No:</b>
                                                                <asp:Label ID="lblApplnNo" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <b>Applied Date:</b>
                                                                <asp:Label ID="lblApplnDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 395px" valign="top">
                                                                <div class="list-group">
                                                                    <a href="#" class="list-group-item"><span class="badge">
                                                                        <asp:Label ID="lblApplied" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                        </i>Applications Applied </a>

                                                                        <asp:HyperLink runat="server" class="list-group-item" ID="hylnkQuery">
                                                                        <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="lblQueryRaised" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Query Raised
                                                                        </asp:HyperLink>


                                                                     <%--   <a class="list-group-item" href="EnterQueryResponse.aspx">
                                                                            <span class="badge" style="background-color: #d9534f;">
                                                                                <asp:Label ID="lblQueryRaised" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Query Raised</a>--%>
                                                                            
                                                                             <a href="#" class="list-group-item">
                                                                                <span class="badge">
                                                                                    <asp:Label ID="lblQueryResponded" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                    </i>Query Responded </a><a href="#" class="list-group-item"><span class="badge">
                                                                                        <asp:Label ID="lblInspectionScheduled" runat="server"></asp:Label></span> <i class="fa fa-fw fa-calendar">
                                                                                        </i>Inspection Scheduled </a><a href="#" class="list-group-item"><span class="badge">
                                                                                            <asp:Label ID="lblInspectionReportUploaded" runat="server"></asp:Label></span> <i
                                                                                                class="fa fa-fw fa-calendar"></i>Inspection Report Uploaded
                                                                    </a><a href="#" class="list-group-item"><span class="badge" style="background-color: #d9534f;">
                                                                        <asp:Label ID="lblInspectionReportNotUploaded" runat="server"></asp:Label></span>
                                                                        <i class="fa fa-fw fa-calendar"></i>Inspection Report Not Uploaded </a><a class="list-group-item"
                                                                            href="#"><span class="badge">
                                                                                <asp:Label ID="lblRecommendedtoDIPC" runat="server"></asp:Label>
                                                                            </span><i class="fa fa-fw fa-calendar"></i>Recommended to DIPC </a><a class="list-group-item"
                                                                                href="#"><span class="badge">
                                                                                    <asp:Label ID="lblRecommendedtoCOI" runat="server"></asp:Label>
                                                                                </span><i class="fa fa-fw fa-calendar"></i>Recommended to COI </a><a class="list-group-item"
                                                                                    href="ReleasePendingViewUser.aspx"><span class="badge">
                                                                                        <asp:Label ID="lblSanctioned" runat="server"></asp:Label>
                                                                                    </span><i class="fa fa-fw fa-calendar"></i>Sanctioned</a> <a class="list-group-item"
                                                                                        href="ReleaseCompletedUserView.aspx"><span class="badge">
                                                                                            <asp:Label ID="lblReleased" runat="server"></asp:Label>
                                                                                        </span><i class="fa fa-fw fa-calendar"></i>Released </a>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table border="1px" width="800px" height="40px" style="display:none">
                                                                    <tr>
                                                                        <td style="width: 600px; height: 30px;" valign="middle" align="left">
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b>
                                                                                <asp:Label ID="lblAwaitingQueries" runat="server" Text="Awaiting Queries for Response"></asp:Label></b>
                                                                        </td>
                                                                        <td style="width: 200px; height: 30px;" valign="middle" align="right">
                                                                            <b>
                                                                                <asp:LinkButton ID="lnkAwaitingQueryResponse" runat="server" OnClick="lnkAwaitingQueryResponse_Click"></asp:LinkButton></b>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
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
