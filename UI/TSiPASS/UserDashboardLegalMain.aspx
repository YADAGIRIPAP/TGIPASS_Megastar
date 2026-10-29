<%@ Page Title="" Language="C#" MasterPageFile="~/UI/TSiPASS/CCMaster.master" AutoEventWireup="true" CodeFile="UserDashboardLegalMain.aspx.cs" Inherits="UI_TSiPASS_UserDashboardLegalMain" %>

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
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Entrepreneur Renewal Dashboard</a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse in" style="height: auto;">
                            <div class="panel-body">
                                <table cellpadding="3" cellspacing="5" style="width: 100%">
                                    <tr style="height: 40px">
                                        <td style="width: 395px; font-size: 16px;" colspan="3" valign="top">
                                            <u><b>Legal Metrology</b> </u>
                                        </td>
                                    </tr>
                             <%--       <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a href="frmRenewalService.aspx" class="list-group-item"><span class="badge">
                                                    <asp:label id="Label4" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-calendar"></i>Application Status </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmRenewalService.aspx?status=B"><span class="badge">
                                                    <asp:label id="Label6" runat="server"></asp:label>
                                                </span><i class="fa fa-fw fa-check"></i>Common Application Form Status</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href='frmDashboardRedirectRenewal.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals Required as per TS-iPASS'>
                                                    <span class="badge">
                                                        <asp:label id="Label7" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals Required as per TS-iPASS</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectRenewal.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals already Obtained'>
                                                    <span class="badge">
                                                        <asp:label id="Label8" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Approvals already obtained</a>
                                            </div>
                                        </td>
                                    </tr>--%>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Application Status</b></u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='LegalApprovalRejectpayment.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals - Applied now'>

                                                    <span class="badge">
                                                        <asp:label id="Label10" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Applied Approvals </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                   
                                    </tr>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Pre-Scrutiny Status</b> </u>
                                        </td>
                                  
                                    <tr>
                                         <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href="LegalApprovalRejectpayment.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Pre-Scrutiny - Completed">
                                                    <span class="badge">
                                                        <asp:label id="lblPreScrutinyCompleted" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Completed</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href='LegalApprovalRejectpayment.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Pre-Scrutiny - Rejected'>
                                                    <%--                                              frmCFEDepartmentsViewApplStatus.aspx--%>
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="lblpreRejected" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny - Rejected</a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                       
                                        <td style="width: 30px">&nbsp;
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
                                                <a class="list-group-item"
                                                    href="Legalverificationpayment.aspx?AdditionalPayment=Yes"><span class="badge">
                                                        <asp:label id="Label15" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Additional Payment required</a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a
                                                    class="list-group-item" href='Legalverificationpayment.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval - Paid for'><span
                                                        class="badge">
                                                        <asp:label id="Label16" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment Paid
                                                </a>
                                            </div>
                                        </td>
                                    </tr>
                               <%--     <tr id="trnotrequired" runat="server" visible="false">
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item" href='frmDashboardRedirectRenewal.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approvals - Payment not required'>
                                                    <span class="badge">
                                                        <asp:label id="Label12" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Payment not required </a>
                                            </div>
                                        </td>
                                        <td style="width: 30px">&nbsp;
                                        </td>
                                        <td style="width: 395px" valign="top">
                                            <div class="list-group">
                                                <a class="list-group-item" href="frmDepartmentRenewalPaymentDetails.aspx">
                                                    <span class="badge" style="background-color: #d9534f;">
                                                        <asp:label id="Label17" runat="server"></asp:label>
                                                    </span><i class="fa fa-fw fa-calendar"></i>Pre-Scrutiny Completed - Awaiting Payment</a>
                                            </div>
                                        </td>
                                    </tr>--%>
                                    <tr style="height: 40px" valign="top">
                                        <td style="width: 395px; font-size: 16px;" colspan="3">
                                            <u><b>Approval Status</b> </u>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 395px; font-size: 16px;">
                                            <div class="list-group">
                                                <a class="list-group-item"
                                                    href='LegalApprovalRejectpayment.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval - Issued'>
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
                                                    href='LegalApprovalRejectpayment.aspx?id=<%= Session["Applid"]%>&status=Approval - Pending'>
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
                                                    href='LegalApprovalRejectpayment.aspx?id=<%= Request.QueryString[0].ToString()%>&status=Approval - Rejected'>
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
                                        <td valign="top" style="width: 395px" id="trackappl" runat="server" visible="true">

                                            <div class="text-right">
                                                <img src="../../gif-new.gif" />
                                                <a href="RptApplicationWiseDetailedTrakerREN.aspx" style="font-size: 16px">Track your application
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
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
