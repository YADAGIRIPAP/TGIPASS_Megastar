<%@ Page Language="C#" MasterPageFile="CCMaster.master" AutoEventWireup="true" CodeFile="HomeDashboard.aspx.cs"
    Inherits="Default3" Title=":: TS-iPass Govenrnment of Telengana :: Home" %>

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
    <%--<div class="col-md-12">
        <h1 class="page-head-line" align="left" style="font-size: x-large">Entrepreneur Dashboard</h1>
        <div class="clearfix"></div>
    </div>--%>
    <%--<link href="../../Masterfiles/css/HandGif.css" rel="stylesheet" />--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
    <div class="clearfix">
    </div>
    <div class="panel-group" id="accordion">
        <div class="clearfix">
        </div>
        <table style="width: 100%">
            <tr>
                <%--<td style="width: 65px" valign="top">
                    <br />
                    <br />
                    <span class="detail-gif" data-balloon-length="large" data-balloon="Click Here For Apply Pre-Establishment Approval" data-balloon-pos="down">
                        <img alt="" width="60px" height="40px" src="../../images/animated-hand-image-0117.gif" /></span>
                </td>--%>
                <td>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Entrepreneur
                                    Dashboard - CFE (Pre-Establishment Approval)</a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse" style="height: auto;">
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr style="height: 40px">
                                        <td style="width: 395px; font-size: 16px;" colspan="3" valign="top">
                                            <u><b>Consent for Establishment</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a href="frmQuesstionniareReg.aspx" class="list-group-item"><span class="badge">
                                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Application Status </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDepartmentApprovalDetails.aspx"><span class="badge">
                                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-check"></i>Common Application Form Status</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals Required as per TS-iPASS'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label7" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals Required as per TG-iPASS</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals already Obtained'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label8" runat="server"></asp:Label>
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
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Applied now'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label10" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Applied Approvals </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Yet to be applied'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="Label11" runat="server"></asp:Label>
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
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries Raised'>
                                                    <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Total Query Raised </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries Responded'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label13" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Total Query Responded </a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries -Yet to Respond">
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="Label14" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Yet to Respond</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Pre-Scrutiny - Rejected'>
                                                    <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lblpreRejected" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Rejected</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Pre-Scrutiny - Completed">
                                                    <span class="badge">
                                                        <asp:Label ID="lblPreScrutinyCompleted" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Completed</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Pre-Scrutiny - Pending">
                                                    <span class="badge">
                                                        <asp:Label ID="lblScrPndng" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Pending</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Payment Status</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDepartmentApprovalPaymentDetails.aspx?AdditionalPayment=Yes">
                                                    <span class="badge">
                                                        <asp:Label ID="Label15" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Additional Payment required</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Paid for'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label16" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment Paid </a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trnotrequired" runat="server" visible="false">
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Payment not required'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label12" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment not required </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDepartmentApprovalPaymentDetails.aspx"><span
                                                    class="badge" style="background-color: #d9534f;">
                                                    <asp:Label ID="Label17" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Awaiting Payment</a>
                                            </div>
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
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Issued'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Issued</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Pending'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Pending</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Rejected'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lblaprRejected" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Rejected</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
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
                                                <%--<a class="list-group-item" href="frmEntrepreneurDetails.aspx">
                                                <span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> In Complete (Draft) </a>--%>
                                                <%--<a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Payment Done'>
                                                <span class="badge">
                                                <asp:Label ID="Label9" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Approvals - Payment Done </a>--%>
                                                <%--<a class="list-group-item"
                                                                                    href="frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries -Yet to Respond"><span class="badge" style="background-color: #d9534f;">--%>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td valign="top" style="width: 395px">
                                            <div class="text-right">
                                                <img src="../../gif-new.gif" />
                                                <%-- <a href="RptApplicationWiseDetailedTraker.aspx" style="font-size: 16px">--%>
                                                <a href="ApplicationTrakerDetailed.aspx" target="_blank" style="font-size: 16px">Track
                                                    your application <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right">
                                                    </i><i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                            <br />
                                            <div class="text-right" id="TSSPDCL" runat="server">
                                                <img src="../../gif-new.gif" alt="" />
                                                <a href="RPTTSSPDCLforEntrep.aspx" style="font-size: 16px" target="_blank">TSSPDCL Feasibility
                                                    Report <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right">
                                                    </i><i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                            <br />
                                            <div class="text-right" id="TSNPDCL" runat="server">
                                                <img src="../../gif-new.gif" alt="" />
                                                <a href="RPTTSNPDCLforEntrep.aspx" style="font-size: 16px" target="_blank">TSNPDCL Feasibility
                                                    Report <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right">
                                                    </i><i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                            <br />
                                            <div class="text-right" id="Div1" runat="server" visible="false">
                                                <img src="../../gif-new.gif" alt="" />
                                                <asp:HyperLink ID="hplPCB" runat="server" Target="_blank">Click here for Online Submission to PCB for CFE/CFO</asp:HyperLink>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" class="collapsed">
                                    Entrepreneur Dashboard - CFO (Pre-Operational Approval)</a>
                            </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%" id="BtnDelete" runat="server">
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <b>Consent for Operation</b>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <a href="frmQuesstionniareRegCFO.aspx" class="list-group-item"><span class="badge">
                                                <asp:Label ID="Label4new" runat="server"></asp:Label>
                                            </span><i class="fa fa-fw fa-calendar"></i>
                                                <%--Questionnaire--%>
                                                Applicaton Status </a>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDepartmentApprovalDetailsCFO.aspx"><span class="badge">
                                                    <asp:Label ID="Label6new" runat="server"></asp:Label>
                                                </span><b><i class="fa fa-fw fa-check"></i>Common Application Form Status </b></a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals Required as per TS-iPASS'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label7new" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals Required as per TS-iPASS</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals already Obtained'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label8new" runat="server"></asp:Label>
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
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals - Applied now'>
                                                    <i class="fa fa-fw fa-calendar"></i>Applied Approvals <span class="badge">
                                                        <asp:Label ID="Label10new" runat="server"></asp:Label>
                                                    </span></a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="#"><span class="badge" style="background-color: #d9534f;">
                                                    <asp:Label ID="Label11new" runat="server"></asp:Label>
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
                                                <a class="list-group-item" href="frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Queries Raised">
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="Label3new" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Raised </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Queries Responded'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label13new" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Responded</a></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplStatusCFO.aspx"><span class="badge"
                                                    style="background-color: #d9534f;">
                                                    <asp:Label ID="Label14new" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Yet to Respond</a></div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Pre-Scrutiny - Rejected'>
                                                    <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lblpreRejectednew" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Rejected</a></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Pre-Scrutiny - Completed'>
                                                    <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lblcomplted" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Completed</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <%--<td style="width: 395px" valign="top">
                                            <div class="list-group">
                                            </div>
                                        </td>--%>
                                         <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Pre-Scrutiny - Pending">
                                                    <span class="badge">
                                                        <asp:Label ID="lblScrPndgCFO" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Pending</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Payment Status</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDepartmentApprovalPaymentDetailsCFO.aspx?AddtionalPayment=yes">
                                                    <span class="badge">
                                                        <asp:Label ID="Label15new" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Additional Payment required</a></div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approval - Paid for'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label16new" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment Paid</a></div>
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false" id="cfopayment">
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals - Payment not required'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label12new" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment not required </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDepartmentApprovalPaymentDetailsCFO.aspx"><span
                                                    class="badge" style="background-color: #d9534f;">
                                                    <asp:Label ID="Label17new" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Awaiting Payment</a></div>
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
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approval - Issued'>
                                                    <span class="badge">
                                                        <asp:Label ID="Label1new" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Issued</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approval - Pending'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="Label2new" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Pending</a></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approval - Rejected'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:Label ID="lblaprRejectednew" runat="server"></asp:Label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Rejected</a></div>
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <div class="text-right">
                                                <img src="../../gif-new.gif" />
                                                <%--<a href="RptApplicationWiseDetailedTrakerCFO.aspx" style="font-size: 16px">--%>
                                                <a href="ApplicationTrakerDetailedCFO.aspx" style="font-size: 16px">Track your application
                                                    <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i>
                                                </a><i class="fa fa-arrow-circle-right"></i>
                                                <br />
                                                <br />
                                                <div id="Div2" runat="server" class="text-right">
                                                    <img alt="" src="../../gif-new.gif" />
                                                    <asp:HyperLink ID="hplPCBnew" runat="server" Target="_blank">Click here for Online Submission to PCB for CFO</asp:HyperLink>
                                                </div>
                                                <br />
                                                <div id="Div3" runat="server" class="text-right" visible="false">
                                                    <img alt="" src="../../gif-new.gif" />
                                                    <asp:HyperLink ID="hplerectionpermission" runat="server" Target="_blank">Erection Permission Granted Report</asp:HyperLink>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading" >
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree" class="collapsed">
                                    Others (Grievance,Incentive,Raw material,Help desk)</a>
                            </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">
                                <table style="width: 100%">
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            &nbsp;
                                        </td>
                                        <td align="center" style="text-align: center">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <%--      <tr>
                        <td align="center" style="text-align: center">
                                            <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-primary" 
                                                Height="91px" onclick="BtnSave1_Click" TabIndex="10" Text="CFE DASHBOARD" 
                                                ValidationGroup="group" Width="268px" Font-Bold="True" 
                                                Font-Names="Verdana" Font-Size="18px" />
                                            </td>
                        <td align="center" style="text-align: center">
                                            <asp:Button ID="BtnDelete" runat="server" 
                                                CssClass="btn btn-danger"  Height="91px" onclick="BtnDelete_Click" TabIndex="10" 
                                                Text="CFO DASHBOARD" Font-Bold="True"  Width="268px"  
                                                
                                                ValidationGroup="group" Font-Names="Verdana" Font-Size="18px" />
                                            </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            &nbsp;
                                        </td>
                                        <td align="center" style="text-align: center">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-warning" Height="91px"
                                                TabIndex="10" Text="GRIEVANCE" ValidationGroup="group" Width="268px" Font-Bold="True"
                                                Font-Names="Verdana" Font-Size="18px" OnClick="Button1_Click" />
                                        </td>
                                        <td align="center" style="text-align: center" runat="server" visible="false">
                                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-info" Height="91px" TabIndex="10"
                                                Text="INCENTIVE" ValidationGroup="group" Width="268px" Font-Bold="True" Font-Names="Verdana"
                                                Font-Size="18px" OnClick="Button2_Click" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            &nbsp;
                                        </td>
                                        <td align="center" style="text-align: center">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            <asp:Button ID="Button3" runat="server" Visible="true" CssClass="btn btn-success" Height="91px"
                                                TabIndex="10" Text="RAW MATERIAL" ValidationGroup="group" Width="268px" Font-Bold="True"
                                                Font-Names="Verdana" Font-Size="18px" OnClick="Button3_Click" />
                                        </td>
                                        <td align="center" style="text-align: center">
                                            <asp:Button ID="Button4" runat="server" CssClass="btn btn-default" Height="91px"
                                                TabIndex="10" Text="HELP DESK" ValidationGroup="group" Width="268px" Font-Bold="True"
                                                Font-Names="Verdana" Font-Size="18px" OnClick="Button4_Click" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            <asp:Button ID="Button5" runat="server" CssClass="btn btn-info" Height="91px" TabIndex="10"
                                                Text="RENEWALS" ValidationGroup="group" Width="268px" Font-Bold="True" Font-Names="Verdana"
                                                Font-Size="18px" Visible="False" />
                                        </td>
                                        <%--  <td align="center" style="text-align: center">
                                <asp:Button ID="btnAmendments" runat="server" CssClass="btn btn-info"
                                    Height="91px" TabIndex="10" Text="AMENDMENTS"
                                    ValidationGroup="group" Width="268px" Font-Bold="True"
                                    Font-Names="Verdana" Font-Size="18px"
                                    OnClick="btnAmendments_Click" />

                            </td>--%>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                  
                </td>
            </tr>
            <tr style="height:40px">
                <td style="height:20px">

                </td>
            </tr>
            <tr style="height:20px; color: #ff4615;">
                <td>
                    <div>
                       <span style="font-weight:bold">Note : "As per the New Panchayath Raj Act (No.5 of 2018 published in gazette on 30-03-2018) and Memo (No.7578/Pts.II/A1/2017 Dt 11.05.2018) GP NOC (No Objection Certificate from Panchayat Secretary of Village) is no longer required for establishing industries."
                           </span> 
                            <br /> <br />
                           <a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/TSIPASSActs/GPNOCMemo7578.pdf" target="_blank" >Click here For Memo </a>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
