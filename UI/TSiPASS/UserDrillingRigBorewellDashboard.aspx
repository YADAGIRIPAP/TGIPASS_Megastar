<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="UserDrillingRigBorewellDashboard.aspx.cs" Inherits="UI_TSiPASS_UserDrillingRigBorewellDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <script language="javascript">
        function OpenPopup() {

            window.open("Lookups/frmcjfslookup.aspx", "List", "scrollbars=yes,resizable=yes,width=550,height=320");

            return false;
        }
    </script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
    <div class="clearfix"></div>
    <div class="panel-group" id="accordion">
        <div class="clearfix"></div>
        <table style="width: 100%">
            <tr>
 
                <td>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"> Drilling Rigs annd Hand Bore Set Dashboard</a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse in" style="height: auto;">
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr style="height: 40px">
                                        <td style="width: 395px; font-size: 16px;" colspan="3" valign="top">
                                            <u><b>Drilling Rigs annd Hand Bore Set</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a href="Registrationfordrillingrigshandboring.aspx" target="_blank" class="list-group-item"><span class="badge">
                                                    <asp:label id="lbl_applicationstatus" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Application Status </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href="Registrationfordrillingrigshandboring.aspx?status=B"><span class="badge">
                                                    <asp:label id="lbl_commonappformstatus" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-check"></i>Common Application Form Status</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals Required as per TS-iPASS'>
                                                    <span class="badge">
                                                        <asp:label id="lbl_approvalrequriedbytsipass" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals Required as per TS-iPASS</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals already Obtained'>
                                                    <span class="badge">
                                                        <asp:label id="lbl_approvalsalreadyobtanied" runat="server"></asp:label>
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
                                                <a class="list-group-item"  target="_blank" href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals - Applied now'>

                                                    <span class="badge">
                                                        <asp:label id="lbl_appappliedapprovalsstatus" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Applied Approvals </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals - Yet to be applied'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lbl_yettobeapplied" runat="server"></asp:label>
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
                                          <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Pre-Scrutiny - Pending'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_presrunitypending" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Pending</a>
                                            </div>
                                            </div>
                                        </td>
                                         <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Queries Raised'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_totalqueryraised" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Total Query Raised </a>
                                            </div>
                                        </td>
                                       
                                       
                                    </tr>
                                    <tr>
                                         <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href="frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Queries -Yet to Respond">
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lbl_yettprespond" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Yet to Respond</a>
                                            </div>
                                        </td>
                                          <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                       <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank" href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Queries Responded'>
                                                    <span class="badge">
                                                        <asp:Label ID="lbl_totqueryresponded" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Total Query Responded </a>
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
                                                    href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval - Issued'>
                                                    <span class="badge">
                                                        <asp:label id="lbl_approvalissued" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Issued</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Session["Applid"]%>&status=Approval - Pending'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lbl_approvalpending" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Pending</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" target="_blank"
                                                    href='frmDashboardRedirect_UserDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval - Rejected'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lblaprRejected" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Rejected</a>
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
                                                <a href="RptApplicationWiseDetailedTrakerDrillingRigs.aspx?id=<%= Request.QueryString[0].ToString()%>" target="_blank" style="font-size: 16px">Track your application
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

