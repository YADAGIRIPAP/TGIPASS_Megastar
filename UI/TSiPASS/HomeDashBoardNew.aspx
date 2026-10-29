<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="HomeDashBoardNew.aspx.cs" Inherits="UI_TSiPASS_HomeDashBoardNew" %>

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
    <div class="clearfix"></div>
    <div class="panel-group" id="accordion">
        <div class="clearfix"></div>
        <table style="width: 100%">
            <tr>
                <td style="width: 65px" valign="top">
                    <br />
                    <br />
                    <span class="detail-gif" data-balloon-length="large" data-balloon="Click Here For Apply Pre-Operation Establishment" data-balloon-pos="down">
                        <img alt="" width="60px" height="40px" src="../../images/animated-hand-image-0117.gif" /></span>
                </td>
                <td>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Entrepreneur Dashboard - CFE</a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse in" style="height: auto;">
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <b>Consent for Establishment</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a href="frmQuesstionniareReg.aspx" class="list-group-item"><span class="badge">
                                                    <asp:label id="Label4" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Application Status </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDepartmentApprovalDetails.aspx"><span class="badge">
                                                    <asp:label id="Label6" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-check"></i>Common Application Form Status</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals Required as per TS-iPASS'>
                                                    <span class="badge">
                                                        <asp:label id="Label7" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals Required as per TS-iPASS</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals already Obtained'>
                                                    <span class="badge">
                                                        <asp:label id="Label8" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals already obtained</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <b>Application Status</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Applied now'>

                                                    <span class="badge">
                                                        <asp:label id="Label10" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Applied Approvals </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Yet to be applied'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label11" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Yet to be applied</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <b>Pre-Scrutiny Status</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries Raised'>
                                                    <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label3" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Raised </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries Responded'>
                                                    <span class="badge">
                                                        <asp:label id="Label13" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Query Responded </a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href="frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries -Yet to Respond"><span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label14" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Yet to Respond</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Pre-Scrutiny - Rejected'>
                                                    <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lblpreRejected" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Rejected</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href="frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Queries -Yet to Respond">
                                                    <span class="badge">
                                                        <asp:label id="lblPreScrutinyCompleted" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Completed</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <b>Payment Status</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href="frmDepartmentApprovalPaymentDetails.aspx?AdditionalPayment=Yes"><span class="badge">
                                                        <asp:label id="Label15" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Additional Payment required</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                             <a
                                                        class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Paid for'><span
                                                            class="badge"><asp:label id="Label16" runat="server"></asp:label>
                                                        </span><i class="fa fa-fw fa-calendar"></i>Payment Paid
                                                    </a></div>
                                        </td>
                                    </tr>
                                    <tr id="trnotrequired" runat="server" visible="false">
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Payment not required'>
                                                    <span class="badge">
                                                        <asp:label id="Label12" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment not required </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                 <a class="list-group-item" href="frmDepartmentApprovalPaymentDetails.aspx">
                                                        <span class="badge" style="background-color: #d9534f;">
                                                            <asp:label id="Label17" runat="server"></asp:label>
                                                        </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Awaiting Payment</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <b>Approval Status</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                        href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Issued'>
                                                        <span class="badge">
                                                            <asp:label id="Label1" runat="server"></asp:label>
                                                        </span><i class="fa fa-fw fa-calendar"></i>Approval - Issued</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                            href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Pending'>
                                                            <span class="badge" style="background-color: #d9534f;">
                                                                <asp:label id="Label2" runat="server"></asp:label>
                                                            </span><i class="fa fa-fw fa-calendar"></i>Approval - Pending</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                 <a class="list-group-item"
                                                    href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approval - Rejected'>
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
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td valign="top" style="width: 395px">
                                            
                                            <div class="text-right">
                                                <img src="../../gif-new.gif" />
                                                <a href="RptApplicationWiseDetailedTraker.aspx" style="font-size: 16px">Track your application
                                                                        <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i>
                                                    <i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                            <br />
                                            <div class="text-right" id="TSSPDCL" runat="server">
                                                <img src="../../gif-new.gif" alt="" />
                                                <a href="RPTTSSPDCLforEntrep.aspx" style="font-size: 16px" target="_blank">TSSPDCL Feasibility
                                                                        Report <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                            <br />
                                            <div class="text-right" id="TSNPDCL" runat="server">
                                                <img src="../../gif-new.gif" alt="" />
                                                <a href="RPTTSNPDCLforEntrep.aspx" style="font-size: 16px" target="_blank">TSNPDCL Feasibility
                                                                        Report <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                            <br />
                                            <div class="text-right" id="Div1" runat="server" visible="false">
                                                <img src="../../gif-new.gif" alt="" />
                                                <asp:hyperlink id="hplPCB" runat="server" target="_blank">Click here for Online Submission to PCB for CFE/CFO</asp:hyperlink>
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
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" class="collapsed">Entrepreneur Dashboard - CFO</a>
                            </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse" style="height: 0px;">
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%" id="BtnDelete" runat="server">

                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <b>Consent for CFO</b></td>
                                        <td style="width: 30px">&nbsp;</td>
                                        <td style="width: 395px" valign="top">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">&nbsp;</td>
                                        <td style="width: 30px">&nbsp;</td>
                                        <td style="width: 395px" valign="top">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">

                                                <a href="frmQuesstionniareRegCFO.aspx" class="list-group-item">
                                                    <span class="badge">
                                                        <asp:label id="Label4new" runat="server"></asp:label>
                                                    </span>
                                                    <i class="fa fa-fw fa-calendar"></i>Questionnaire 
                                                </a>



                                                <%--<a class="list-group-item" href="frmEntrepreneurDetails.aspx">
                                                <span class="badge" style=" background-color:#d9534f;">
                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i> In Complete (Draft) </a>--%>


                                                <a class="list-group-item" href="frmDepartmentApprovalDetailsCFO.aspx"><span class="badge">
                                                    <asp:label id="Label6new" runat="server"></asp:label>
                                                </span><b><i class="fa fa-fw fa-check"></i>Common 
                                                Application Form  </b></a>


                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals Required as per TS-iPASS'><span class="badge">
                                                    <asp:label id="Label7new" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Approvals Required as per TS-iPASS</a>

                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals already Obtained'>
                                                    <span class="badge">
                                                        <asp:label id="Label8new" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals already obtained</a><a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals - Applied now'>
                                                        <i class="fa fa-fw fa-calendar"></i>Approvals - Applied now <span class="badge">
                                                            <asp:label id="Label10new" runat="server"></asp:label>
                                                        </span></a>
                                                <%--<a class="list-group-item" href='frmDashboardRedirect.aspx?id=<%= Session["uid"]%>&status=Approvals - Payment Done'>
                                                <span class="badge">
                                                <asp:Label ID="Label9" runat="server"></asp:Label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Approvals - Payment Done </a>--%>


                                                <a class="list-group-item" href="#">
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label11new" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals - Yet to be applied</a>

                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals already Obtained'><b><i class="fa fa-fw fa-check"></i>Queries </b></a>

                                                <a class="list-group-item" href="frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Queries Raised">
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label3new" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Raised </a>
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Queries Responded'><span class="badge">
                                                    <asp:label id="Label13new" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Responded </a>
                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplStatusCFO.aspx"><span class="badge" style="background-color: #d9534f;">
                                                    <asp:label id="Label14new" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Yet to Respond</a>
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Pre-Scrutiny - Rejected'>
                                                    <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lblpreRejectednew" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Rejected</a>

                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;</td>
                                        <td valign="top" style="width: 395px">
                                            <div class="list-group">

                                                <a class="list-group-item" href="frmCFEDepartmentsViewApplStatusCFO.aspx"><b><i class="fa fa-fw fa-check"></i>Payment </b></a>

                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals - Payment not required'>
                                                    <span class="badge">
                                                        <asp:label id="Label12new" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment not required </a>


                                                <a class="list-group-item" href="frmDepartmentApprovalPaymentDetailsCFO.aspx?AddtionalPayment=yes">
                                                    <span class="badge">
                                                        <asp:label id="Label15new" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Payment required</a>

                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approval - Paid for'><span class="badge">
                                                    <asp:label id="Label16new" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Paid for </a><a class="list-group-item" href="frmDepartmentApprovalPaymentDetailsCFO.aspx">
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label17new" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Awaiting Payment</a>
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approvals already Obtained'><b><i class="fa fa-fw fa-check"></i>Approvals Stage</b></a>
                                                <a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approval - Issued'>
                                                    <span class="badge">
                                                        <asp:label id="Label1new" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Issued</a><a class="list-group-item" href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approval - Pending'>
                                                        <span class="badge" style="background-color: #d9534f;">
                                                            <asp:label id="Label2new" runat="server"></asp:label>
                                                        </span><i class="fa fa-fw fa-calendar"></i>Approval - Pending</a>
                                                <a class="list-group-item"
                                                    href='frmDashboardRedirectCFO.aspx?id=<%= Session["uid"]%>&status=Approval - Rejected'>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lblaprRejectednew" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approval - Rejected</a>

                                            </div>
                                            <br />
                                            <div class="text-right">
                                                <img src="../../gif-new.gif" />
                                                <a href="RptApplicationWiseDetailedTrakerCFO.aspx" style="font-size: 16px">Track your application <i class="fa fa-arrow-circle-right"></i><i class="fa fa-arrow-circle-right"></i></a>
                                                <i class="fa fa-arrow-circle-right"></i>
                                                <br />
                                                <br />
                                                <div id="Div2" runat="server" class="text-right">
                                                    <img alt="" src="../../gif-new.gif" />
                                                    <asp:hyperlink id="hplPCBnew" runat="server" target="_blank">Click here for Online Submission to PCB for CFO</asp:hyperlink>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">&nbsp;</td>
                                        <td style="width: 30px">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree" class="collapsed">Others (Grievance,Incentive,Raw material,Help desk)</a>
                            </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">

                                <table style="width: 100%">

                                    <tr>
                                        <td align="center" style="text-align: center">&nbsp;</td>
                                        <td align="center" style="text-align: center">&nbsp;</td>
                                        <td>&nbsp;</td>
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
                                        <td align="center" style="text-align: center">&nbsp;</td>
                                        <td align="center" style="text-align: center">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            <asp:button id="Button1" runat="server" cssclass="btn btn-warning"
                                                height="91px" tabindex="10" text="GRIEVANCE"
                                                validationgroup="group" width="268px" font-bold="True"
                                                font-names="Verdana" font-size="18px" onclick="Button1_Click" />
                                        </td>
                                        <td align="center" style="text-align: center">
                                            <asp:button id="Button2" runat="server" cssclass="btn btn-info"
                                                height="91px" tabindex="10" text="INCENTIVE"
                                                validationgroup="group" width="268px" font-bold="True"
                                                font-names="Verdana" font-size="18px" onclick="Button2_Click" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center">&nbsp;</td>
                                        <td align="center" style="text-align: center">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            <asp:button id="Button3" runat="server" cssclass="btn btn-success"
                                                height="91px" tabindex="10" text="RAW MATERIAL"
                                                validationgroup="group" width="268px" font-bold="True"
                                                font-names="Verdana" font-size="18px" onclick="Button3_Click" />
                                        </td>
                                        <td align="center" style="text-align: center">
                                            <asp:button id="Button4" runat="server" cssclass="btn btn-default"
                                                height="91px" tabindex="10" text="HELP DESK"
                                                validationgroup="group" width="268px" font-bold="True"
                                                font-names="Verdana" font-size="18px" onclick="Button4_Click" />
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="text-align: center">
                                            <asp:button id="Button5" runat="server" cssclass="btn btn-info"
                                                height="91px" tabindex="10" text="RENEWALS"
                                                validationgroup="group" width="268px" font-bold="True"
                                                font-names="Verdana" font-size="18px" visible="False" />

                                        </td>


                                        <%--  <td align="center" style="text-align: center">
                                <asp:Button ID="btnAmendments" runat="server" CssClass="btn btn-info"
                                    Height="91px" TabIndex="10" Text="AMENDMENTS"
                                    ValidationGroup="group" Width="268px" Font-Bold="True"
                                    Font-Names="Verdana" Font-Size="18px"
                                    OnClick="btnAmendments_Click" />

                            </td>--%>
                                        <td>&nbsp;</td>
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

