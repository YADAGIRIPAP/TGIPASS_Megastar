<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="UserGroundwaterDashboard.aspx.cs" Inherits="UI_TSiPASS_UserGroundwaterDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
        function OpenPopup() {
            window.open("Lookups/frmcjfslookup.aspx", "List", "scrollbars=yes,resizable=yes,width=550,height=320");
            return false;
        }
        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;
                alert("Enter Alphabets, '.' and Space Only");
            }
        }
        function DecimalOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127) || AsciiValue == 46)
                event.returnValue = true;
            else {
                event.returnValue = false;
                alert("Enter DecimalValues Only");
            }
        }
        function AlphaNumericOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue >= 48 && AsciiValue <= 57))
                event.returnValue = true;
            else {
                event.returnValue = false;
                alert("Enter Alphabets,  and Characters  Only");
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration1]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtration2]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtsurveynum]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtExtent]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=txtCJFSBeneficiery]').bind('cut copy paste', function (e) {
                e.preventDefault();
                alert('You cannot ' + e.type + ' text!');
            });
        });
    </script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css" />
    <div class="clearfix"></div>
    <div class="panel-group" id="accordion">
        <div class="clearfix"></div>
        <table style="width: 100%">
            <tr>

                <td>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Ground Water Dashboard</a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse in" style="height: auto;">
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr style="height: 40px">
                                        <td style="width: 395px; font-size: 16px;" colspan="3" valign="top">
                                            <u><b>Ground water</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a href="waltaform2.aspx" target="_blank" class="list-group-item"><span class="badge">
                                                    <asp:Label ID="lbl_applicationstatus" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Application Status </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href="waltaform2.aspx?status=B"><span class="badge">
                                                    <asp:Label ID="lbl_commonappformstatus" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-check"></i>Common Application Form Status</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals-Required as per TS-iPASS'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_approvalrequriedbytsipass" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals Required as per TS-iPASS</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals already Obtained'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_approvalsalreadyobtanied" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals already obtained</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Application Status</b></u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Applied Approvals'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_appappliedapprovalsstatus" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Applied Approvals </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Yet to be applied'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_yettobeapplied" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Yet to be applied</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Pre-Scrutiny Status</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Pre-Scrutiny-Pending'>

                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_PreScrutinyPending" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny-Pending</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Total Query Raised'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_totalqueryraised" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Total Query Raised</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Queries-Yet to Respond'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_yettprespond" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Yet to Respond</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Total Query Responded'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_totqueryresponded" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Total Query Responded</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Query Raised by MRO'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_QueryRaisedbyMRO" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Raised by MRO</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Query Responded to MRO'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_QueryRespondedtoMRO" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Responded to MRO</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Forward to Ground water'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_forwardtogroundwater" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Forward to Ground water </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Rejected by MRO'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_rejectedbymro" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Rejected by MRO </a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Query Raised by Ground Water'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_QueryRaisedbyGroundWater" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Raised by Ground Water</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Query Responded by Ground Water'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_QueryRespondedbyGroundWater" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Responded by Ground Water</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href="frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Recommended by Groundwater">
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_recommendedbygroundwater" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Recommended by Ground water</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Not Recommended by Ground water'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lblnotrecommenedbygroundwater" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Not Recommended by Ground water</a>
                                            </div>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Forward to TRANSCO Department'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_forwardtoTRANSCODEPARTMENT" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Forward to TRANSCO Department </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Query Raised by TRANSCO Department'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_QueryRaisedbyTranscodept" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Raised by TRANSCO Department</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Query Responded to TRANSCO Department'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_QueryRespondedbyTranscoDept" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Responded to TRANSCO Department</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href="frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Recommended by TRANSCO Department">
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_recommendedbyTranscoDept" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Recommended by TRANSCO Department</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Not Recommended by TRANSCO Department'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lblnotrecommenedbyTranscoDept" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Not Recommended by TRANSCO Department</a>
                                            </div>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                    </tr>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Approval Status</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval-Issued'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_approvalissued" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval-Issued</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Session["Applid"]%>&status=Approval-Pending'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_approvalpending" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Pending</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UseGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval-Rejected'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lblaprRejected" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval-Rejected</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td valign="top" style="width: 395px" id="trackappl" runat="server" visible="true">

                                            <div class="text-right">
                                                <img src="../../gif-new.gif" />
                                                <a target="_blank" href="RptApplicationWiseDetailedTrakerGroundwater.aspx?id=<%= Request.QueryString[0].ToString()%>" style="font-size: 16px">Track your application
                                                                        <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i>
                                                    <i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                            <br />
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
                                </table>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>


</asp:Content>

